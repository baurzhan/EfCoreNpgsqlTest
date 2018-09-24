using Npgsql.Logging;
using Xunit.Abstractions;

namespace Optiro.Data.Tests
{
    public class NpgsqlLogginProvider : INpgsqlLoggingProvider
    {
        private readonly ITestOutputHelper _outputHelper;

        public NpgsqlLogginProvider(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        public NpgsqlLogger CreateLogger(string name)
        {
            return new MyNpgsqlLogger(_outputHelper);
        }
    }
}