using Application.Core;
using Application.Profiles;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities.Profiles
{
    public class Details
    {
        public class Query : IRequest<Result<Profile>>
        {
            public string UserName { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Profile>>
        {
            private readonly DataContext _context;
            private readonly AutoMapper.IMapper _mapper;

            public Handler(DataContext context, AutoMapper.IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Profile>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.ProjectTo<Profile>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(x => x.UserName == request.UserName);
                   
                if (user == null)
                {
                    return null;
                }

                return Result<Profile>.Success(user);

            
            }
        }
    }
}