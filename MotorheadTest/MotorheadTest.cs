using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace MotorheadTest
{
    public class UnitTest1
    {
        [Fact]
        public void SquareGenerator_LengthIsOneFift_ExpectedResults()
        {
            // Arrange
            IList expected = new List<bool>()
            {
                false, false, false, false, true,
                false, false, false, false, true
            };

            // Assert
            IList results = new List<bool>();
            previousTime = 0;
            for (int i = 0; i < 10; i++)
            {
                long interval = 4;
                long length = 1;
                results.Add(SquareGenerator(interval, length, i));
            }

            // Act
            Assert.Equal(expected, results);
        }

        [Fact]
        public void SquareGenerator_LengthIsOneHalf_ExpectedResults()
        {
            // Arrange
            IList expected = new List<bool>()
            {
                false, false, true, true,
                false, false, true, true
            };

            // Assert
            IList results = new List<bool>();
            previousTime = 0;
            for (int i = 0; i < 8; i++)
            {
                long interval = 2;
                long length = 2;
                results.Add(SquareGenerator(interval, length, i));
            }

            // Act
            Assert.Equal(expected, results);
        }

        //       Interval  Length   
        //            /_____/             _____
        //            |     |            |     |
        //            |     |            |     |
        //------------       ------------       ------------
        private long previousTime = 0;
        private bool SquareGenerator(long interval, long length, long time)
        {
            long offset = time - previousTime;
            if (offset >= interval)
            {
                if (interval + length <= offset)
                {
                    previousTime = time;
                    return false;
                }
                return true;
            }

            return false;
        }
    }
}
