using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Interface;
using ProEventos.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class LotePersistence : ILotePersist
    {
        private readonly ProEventosContext _context;

        public LotePersistence(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Lote[]> GetAllLotesAsync(int eventoId)
        {
            IQueryable<Lote> query = _context.Lotes;
            query = query.AsNoTracking().Where(lote => lote.EventoId == eventoId);
            return await query.ToArrayAsync();
        }

        public async Task<Lote> GetLoteByIdAsync(int eventoId, int loteId)
        {
            IQueryable<Lote> query = _context.Lotes;
            query = query.AsNoTracking().Where(lote => lote.EventoId == eventoId && lote.Id == loteId);
            return await query.FirstOrDefaultAsync();
        }
    }
}
