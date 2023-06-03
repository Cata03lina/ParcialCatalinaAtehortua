﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcialCatalinaAtehortua.DAL;
using ParcialCatalinaAtehortua.Entities;

namespace ParcialCatalinaAtehortua.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly DataBaseContext _context;
        public TicketsController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetTicketById/{ticketId}")]
        public async Task<ActionResult<Ticket>> GetTicketById(Guid? ticketId)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId);

            if (ticket == null) return NotFound();

            return Ok(ticket);
        }


        [HttpPost, ActionName("Create")]
        [Route("CreateTicket")]
        public async Task<ActionResult> CreateTicket(Ticket ticket)
        {
            try
            {
                ticket.Id = new Guid();
                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(ticket);
        }

        [HttpPut, ActionName("Edit")]
        [Route("EditTicket/{ticketId}")]
        public async Task<ActionResult> EditTicket(Guid ticketId, Ticket ticket)
        {
            try
            {
                if (ticketId != ticket.Id) return NotFound("Boleta no válida");

                ticket.UseDate = DateTime.Now;
                ticket.IsUsed = true;

                _context.Tickets.Update(ticket);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(ticket);
        }
    }
}



