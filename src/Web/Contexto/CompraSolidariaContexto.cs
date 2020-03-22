using Microsoft.EntityFrameworkCore;

namespace Web.Contexto
{
    public class CompraSolidariaContexto : DbContext
    {
        public CompraSolidariaContexto(DbContextOptions<CompraSolidariaContexto> options) : base(options)
        {

        }
    }
}
