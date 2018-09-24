using System;
using Npgsql.Logging;
using Xunit.Abstractions;

namespace Optiro.Data.Tests
{
    public class MyNpgsqlLogger : NpgsqlLogger
    {
        private readonly ITestOutputHelper _outputHelper;
        public MyNpgsqlLogger(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        public override bool IsEnabled(NpgsqlLogLevel level)
        {
            return true;
        }

        public override void Log(NpgsqlLogLevel level, int connectorId, string msg, Exception exception = null)
        {
            _outputHelper.WriteLine(msg);
        }
    }
}