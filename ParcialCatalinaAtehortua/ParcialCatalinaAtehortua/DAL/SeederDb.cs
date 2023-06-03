using ParcialCatalinaAtehortua.Entities;

namespace ParcialCatalinaAtehortua.DAL
{
    public class SeederDb
    {
       private readonly DataBaseContext _context;

        public SeederDb(DataBaseContext context)
        {
            _context = context;
        }
        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await PopulateTicketsAsync();
            await _context.SaveChangesAsync();
        }
        private async Task PopulateTicketsAsync()
        {
            if (!_context.Tickets.Any())
            {
                for (int i = 0; i < 50000; i++)
                {
                    _context.Tickets.Add(new Ticket
                    {
                        Id = new Guid(),
                        EntranceGate = "null",
                        IsUsed = false,
                        UseDate = null
                    });

                }
            }
            await _context.SaveChangesAsync();
        }
    }


}

