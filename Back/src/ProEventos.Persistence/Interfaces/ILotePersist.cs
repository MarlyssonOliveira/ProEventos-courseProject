using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Interfaces
{
    public interface ILotePersist
    {
        /// <summary>
        /// Metodo get que retorna todos os lotes de um evento
        /// </summary>
        /// <param name="eventoId">Codigo chave do evento</param>
        /// <returns></returns>
        Task<Lote[]> GetAllLotesAsync(int eventoId);
        /// <summary>
        /// Metodo get que tras 1 lote
        /// </summary>
        /// <param name="eventoId">Codigo chave do evento</param>
        /// <param name="loteId">Codigo chave da table lote</param>
        /// <returns></returns>
        Task<Lote> GetLoteByIdAsync(int eventoId, int loteId);
    }
}
