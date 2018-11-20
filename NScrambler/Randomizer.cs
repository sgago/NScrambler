using System;

namespace NScramble
{
    /// <summary>
    /// Represents a psuedo-random number generator.
    /// </summary>
    public class Randomizer : IRandom
    {
        /// <summary>
        /// The psuedo-random number generator.
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        /// Returns a random integer within the specified range.
        /// Note that maxValue is exclusive.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound.</param>
        /// <param name="maxValue">The exclusive upper bound.</param>
        /// <returns>A 32-bit signed integer within the specified range.</returns>
        public int Next(int minValue, int maxValue)
        {
            // Note that the minValue is inclusive and
            // the maxValue is exclusive!
            // I might be tempted to make both bounds inclusive
            // for less ambiguity.  Then again, it takes
            // less coding elsewhere.
            return Random.Next(minValue, maxValue);
        }

        /// <summary>
        /// Returns a random integer within the specified range
        /// 0 to maxValue.
        /// Note that maxValue is exclusive.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound.</param>
        /// <returns>A 32-bit signed integer within the specified range 0 to maxValue.</returns>
        public int Next(int maxValue)
        {
            return Next(0, maxValue);
        }

        /// <summary>
        /// Returns a random integer within the specified range
        /// 0 to 2147483647.  Note that 2147483647 is exclusive.
        /// </summary>
        /// <returns>A 32-bit signed integer within the specified range 0 to 2147483647</returns>
        public int Next()
        {
            return Next(0, int.MaxValue);
        }
    }
}
