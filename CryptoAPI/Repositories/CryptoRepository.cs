using CryptoAPI.Modules;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAPI.Repositories
{
    public class CryptoRepository : ICryptoRepository
    {
        private readonly CryptoContext _context;

        public CryptoRepository(CryptoContext context)
        {
            _context = context;
        }

        public async Task<Crypto> Create(Crypto crypto)
        {
            _context.Cryptocurrencies1.Add(crypto);
            await _context.SaveChangesAsync();
            return crypto;
        }

        public async Task Delete(int id)
        {
            var cryptoToDelete = await _context.Cryptocurrencies1.FindAsync(id);
            _context.Cryptocurrencies1.Remove(cryptoToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Crypto>> Get()
        {
            return await _context.Cryptocurrencies1.ToListAsync();
        }

        public async Task<Crypto> Get(int id)
        {
            return await _context.Cryptocurrencies1.FindAsync(id);
        }

        public async Task<List<CryptoWithoutPrice>> GetWithoutPrices()
        {
            List<CryptoWithoutPrice> cryptos = await _context.Cryptocurrencies1.Select(c => new CryptoWithoutPrice
            {
                Name = c.Name,
                Id = c.Id,
                UpdateDate = c.UpdateDate
            }).ToListAsync();
            return cryptos;
        }

        public async Task Update(Crypto crypto)
        {
             _context.Entry(crypto).State = EntityState.Modified;
            await _context.SaveChangesAsync();  
        }
        
    }
}
