using System;
using Xunit;
using Bot.Core;
namespace XUnitTestProject1
{
    public class EnviromentTest
    {
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(false, false, true)]
        [InlineData(null, true, true)]
        [InlineData(null, false, true)]
        [InlineData(true, null, true)]
        [InlineData(false, null, true)]
        [InlineData(null, null, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, false)]
        public void CompareProperties(bool? value1, bool? value2, bool expected)
        {
            var actual = Bot.Core.Environment.CompareProperties(value1, value2);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void DoesMatch_EmptyEnviroment()
        {
            var env1 = new Bot.Core.Environment();
            var env2 = new Bot.Core.Environment();
            var expected = true;
            var actual = env1.DoesMatch(env2);
            var actual2 = env2.DoesMatch(env1);



            Assert.Equal(expected, actual);
            Assert.Equal(expected, actual2);
        }


        [Fact]
        public void DoesMatch_EmptyAgainstRandomEnviroment()
        {
            var env1 = new Bot.Core.Environment();
            var env2 = new Bot.Core.Environment().Random();
            var expected = true;
            var actual = env1.DoesMatch(env2);
            var actual2 = env2.DoesMatch(env1);



            Assert.Equal(expected, actual);
            Assert.Equal(expected, actual2);
        }




        [Fact]
        public void DoesMatch_ShouldNotMatch()
        {
            var env1 = new Bot.Core.Environment
            {
                IsDay = true
            };
            var env2 = new Bot.Core.Environment
            {
                IsDay = false
            };
            var expected = false;
            var actual = env1.DoesMatch(env2);
            var actual2 = env2.DoesMatch(env1);



            Assert.Equal(expected, actual);
            Assert.Equal(expected, actual2);
        }
    }
}
