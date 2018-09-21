using System;

namespace EfCoreNpgsqlTest
{
    public class DateTimeEntity
    {
        public int Id { get; set; }
        public NpgsqlTypes.NpgsqlRange<DateTime> Valid { get; set; }
    }
}