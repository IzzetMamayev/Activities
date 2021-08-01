using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistance;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<Result<List<ActivityDTO>>> { }

        public class Handler : IRequestHandler<Query, Result<List<ActivityDTO>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            // private readonly ILogger _logger;

            public Handler(DataContext context, IMapper mapper  /*, ILogger<List> logger*/)
            {
                _context = context;
                _mapper = mapper;

                // _logger = logger;
            }

            public async Task<Result<List<ActivityDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                // Budem ispolzovat AutoMapper.Queryable.Extension vmesto eager loading
                var activities = await _context.Activities
                    .ProjectTo<ActivityDTO>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                // Zdes Mi ispolzuyem eager loading
                // var activities = await _context.Activities
                //     .Include(a => a.Attendees)
                //     .ThenInclude(u => u.AppUser)
                //     .ToListAsync(cancellationToken);
                // var activitiesToReturn = _mapper.Map<List<ActivityDTO>>(activities);  

                return Result<List<ActivityDTO>>.Success(activities);


                //Kod nije pokazivayet rabotu CancellationToken (kogda client ostanovil request(zakril browser, ili sdelal cancel))
                // try
                // { 
                //     for (int i = 0; i < 10; i++)
                //     {
                //         cancellationToken.ThrowIfCancellationRequested();
                //         await Task.Delay(1000, cancellationToken);
                //         _logger.LogInformation($"Task {i} has completed");
                //     }
                // }
                // catch (Exception ex)
                // {
                //     _logger.LogInformation("Task was cancelled", ex.Message);                    
                // }



            }
        }
    }
}