using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        public ProAgilContext _context { get; }

        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        // Gerais
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        // Evento
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            if (includePalestrante)
            {
                query = query.Include(pe => pe.PalestrantesEventos)
                .ThenInclude(p => p.Palestrante);
            }

            query = query
                .AsNoTracking()
                .OrderByDescending(c => c.DataEvento);

            return await query.ToArrayAsync();
        }


        public Task<Evento[]> GetAllEventsoAsyncById(int EventoId, bool includePalestrante)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Evento[]> GetAllEventosAsyncByTema(string tema, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            if (includePalestrante)
            {
                query = query.Include(pe => pe.PalestrantesEventos)
                .ThenInclude(p => p.Palestrante);
            }

            query = query
                .AsNoTracking()
                .OrderByDescending(c => c.DataEvento)
                .Where(c => c.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoAsyncById(int EventoId, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            if (includePalestrante)
            {
                query = query.Include(pe => pe.PalestrantesEventos)
                .ThenInclude(p => p.Palestrante);
            }

            query = query
                .AsNoTracking()
                .OrderByDescending(c => c.DataEvento)
                .Where(c => c.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }

        // Palestrante
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(pe => pe.PalestrantesEventos)
                .ThenInclude(e => e.Evento);
            }

            query = query
                .AsNoTracking()
                .OrderBy(c => c.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsyncByName(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(pe => pe.PalestrantesEventos)
                .ThenInclude(e => e.Evento);
            }

            query = query
                .AsNoTracking()
                .OrderBy(c => c.Nome)
                .Where(c => c.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteAsyncById(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(pe => pe.PalestrantesEventos)
                .ThenInclude(e => e.Evento);
            }

            query = query
                .AsNoTracking()
                .OrderBy(c => c.Nome)
                .Where(c => c.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}