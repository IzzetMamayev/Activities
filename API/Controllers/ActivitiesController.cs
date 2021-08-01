using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

        // Popisan danniy Mediator v BaseController
        // private readonly IMediator _mediator;
        // public ActivitiesController(IMediator mediator)
        // {
        //     _mediator = mediator;
        // }

        // [Authorize]  // Mi nastroili Auth Policy v startup, poetomu ne nujni attribut Authorize
        
        // [Authorize]  // Mi nastroili Auth Policy v startup, poetomu ne nujni attribut Authorize
        [HttpGet]
        public async Task<IActionResult> GetActivities(/*CancellationToken ct*/) // Yesli client delayet cancel request
        {
            return HandleResult(await Mediator.Send(new List.Query()));
            // return await Mediator.Send(new List.Query() /*ct*/);
        }

        // [Authorize]  // Mi nastroili Auth Policy v startup, poetomu ne nujni attribut Authorize
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity(Guid id)
        {

            var result = await Mediator.Send(new Details.Query { Id = id });
        
            return HandleResult(result);
            
            // Kod nije priveden yesli bil ne bilo patterna CQRS
            // var activity =  await Mediator.Send(new Details.Query { Id = id });

            // if (activity == null)
            // {
            //     return NotFound();
            // }

            // return activity;
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Activity = activity }));
        }

        [Authorize(Policy = "IsActivityHost")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, [FromBody] Activity activity)
        {
            activity.Id = id;
            return  HandleResult(await Mediator.Send(new Edit.Command { Activity = activity }));
        }

        [Authorize(Policy = "IsActivityHost")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }


        [HttpPost("{id}/attend")]
        public async Task<IActionResult> Attend(Guid id)
        {
            return HandleResult(await Mediator.Send(new UpdateAttendance.Command { Id = id }));
        }
    }
}