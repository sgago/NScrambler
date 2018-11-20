namespace NScramble
{
    /// <summary>
    /// Represents a psuedo-random number generator.
    /// </summary>
    public interface IRandom
    {
        /// <summary>
        /// Returns a random integer within the specified range.
        /// Note that maxValue is exclusive.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound.</param>
        /// <param name="maxValue">The exclusive upper bound.</param>
        /// <returns>A 32-bit signed integer within the specified range.</returns>
        int Next(int minValue, int maxValue);

        /// <summary>
        /// Returns a random integer within the specified range
        /// 0 to maxValue.
        /// Note that maxValue is exclusive.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound.</param>
        /// <returns>A 32-bit signed integer within the specified range 0 to maxValue.</returns>
        int Next(int maxValue);

        /// <summary>
        /// Returns a random integer within the specified range
        /// 0 to 2147483647.  Note that 2147483647 is exclusive.
        /// </summary>
        /// <returns>A 32-bit signed integer within the specified range 0 to 2147483647</returns>
        int Next();
    }
}
