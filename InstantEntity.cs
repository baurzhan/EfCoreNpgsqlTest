using NodaTime;

namespace EfCoreNpgsqlTest
{
    public class InstantEntity
    {
        public int Id { get; set; }
        public NpgsqlTypes.NpgsqlRange<Instant> Valid { get; set; }
    }
}