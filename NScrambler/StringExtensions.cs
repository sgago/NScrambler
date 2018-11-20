namespace NScramble
{
    /// <summary>
    /// Provide Scramble string extensions for ease of use.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// A static instance of Scrambler to shuffle strings.
        /// </summary>
        private static readonly Scrambler Scrambler =
            new Scrambler(new Randomizer());

        /// <summary>
        /// The shuffle algorithm shuffles characters
        /// in a given string a set number of times or cycles.
        /// </summary>
        /// <param name="text">The text to shuffle.</param>
        /// <param name="cycles">The number of times to shuffle characters.</param>
        /// <returns>The shuffled string.</returns>
        public static string Scramble1(this string text, int cycles)
        {
            return Scrambler.Scramble1(text, cycles);
        }

        /// <summary>
        /// The shuffle algorithm shuffles characters
        /// in a given string a set number of times or cycles.
        /// </summary>
        /// <param name="text">The text to shuffle.</param>
        /// <returns>The shuffled string.</returns>
        public static string Scramble1(this string text)
        {
            return Scrambler.Scramble(text);
        }

        /// <summary>
        /// Shuffles a string using a variation of the Fisher-Yates
        /// shuffling algorithm.
        /// </summary>
        /// <param name="text">The text to shuffle.</param>
        /// <returns>The shuffled string.</returns>
        public static string Scramble2(this string text)
        {
            return Scrambler.Scramble2(text);
        }

        /// <summary>
        /// Shuffles a given string via the Array.Sort algorithm
        /// and a lambda comparator.
        /// </summary>
        /// <param name="text">The text to shuffle.</param>
        /// <returns>The shuffled string.</returns>
        public static string Scramble3(this string text)
        {
            return Scrambler.Scramble3(text);
        }
    }
}
