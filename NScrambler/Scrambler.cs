using System;

namespace NScramble
{
    /// <summary>
    /// Contains the three separate shuffling algorithms.
    /// </summary>
    public class Scrambler
    {
        /// <summary>
        /// Gets or sets the Randomizer for generating
        /// random integers.
        /// </summary>
        private static IRandom Randomizer { get; set; }
        
        /// <summary>
        /// Instantiates a new instance of the StringShuffler class.
        /// </summary>
        /// <param name="randomizer">The Randomizer for generating random integers.</param>
        /// <remarks>
        /// The IRandom interface allows us to isolate this code during unit testing
        /// via test substitutes, null-object pattern, etc.
        /// </remarks>
        public Scrambler(IRandom randomizer)
        {
            // Set dependencies
            Randomizer = randomizer;
        }

        /// <summary>
        /// Swaps characters in a given string at the given indicies.
        /// </summary>
        /// <param name="text">The given string to swap characters for.</param>
        /// <param name="index1">The first index to swap.</param>
        /// <param name="index2">The second index to swap.</param>
        /// <returns>A string with the given indicies swapped.</returns>
        private string Swap(string text, int index1, int index2)
        {
            // I learned C and C++ first, so I tend to avoid the
            // var keyword and declare my variables first.
            // Otherwise, I would follow a coding standard or try to
            // match the rest of the source code for readability.
            char temporary;
            char[] charArray;

            // I might consider checking arguments for null, bad
            // indicies, etc. if this code had a chance being
            // copy-n-pasted.

            // Convert string to an array so we can swap the characters
            charArray = text.ToCharArray();

            temporary = charArray[index2];
            charArray[index2] = charArray[index1];
            charArray[index1] = temporary;

            return new string(charArray);
        }

        /// <summary>
        /// The shuffle algorithm shuffles characters
        /// in a given string a set number of times or cycles.
        /// </summary>
        /// <param name="text">The text to shuffle.</param>
        /// <param name="cycles">The number of times to shuffle characters.</param>
        /// <returns>The shuffled string.</returns>
        /// <remarks>
        /// This algorithm is based around bubble sort.
        /// 
        /// After analyzing the space and time complexities of
        /// this method, I was surprised to find that this might be the most efficient
        /// of my scrambling algorithms, theoretically
        /// speaking.  We could start measuring actual execution times
        /// or looking at the IL code, but that seems like overkill.
        /// 
        /// I would tend to use this algorithm in most situations
        /// unless provided with a more compelling reason to do otherwise.
        /// Use of the char[] and extra integer is negligible for even most embedded computers
        /// such as the Raspberry PI using Windows IoT.
        /// It's runtime execution could be
        /// better than Scrambler2 since there's no overhead from
        /// string concatenation, StringBuilders, etc.
        /// The readability of this method is on par with Scrambler2
        /// and much better than Scrambler3.
        /// 
        /// TIME COMPLEXITY
        /// The time complexity is O(n) efficiency assuming
        /// that Random.Next is O(1).
        /// 
        /// SPACE COMPLEXITY
        /// The space complexity, ignoring any inputs,
        /// is O(n) due to use of the character array in the Swap method.
        /// </remarks>
        public string Scramble1(string text, int cycles)
        {
            int randomIndex1 = -1;
            int randomIndex2 = -1;

            // Verify text argument; otherwise return
            if (!string.IsNullOrEmpty(text))
            {
                for (int i = 0; i < cycles; i++)
                {
                    randomIndex1 = Randomizer.Next(text.Length);
                    randomIndex2 = Randomizer.Next(text.Length);

                    text = Swap(text, randomIndex1, randomIndex2);
                }
            }

            return text;
        }

        /// <summary>
        /// The shuffle algorithm shuffles characters
        /// in a given string a set number of times or cycles.
        /// </summary>
        /// <param name="text">The text to shuffle.</param>
        /// <returns>The shuffled string.</returns>
        public string Scramble(string text)
        {
            return Scramble1(text, text.Length);
        }

        /// <summary>
        /// Shuffles a string using a variation of the Fisher-Yates
        /// shuffling algorithm.
        /// </summary>
        /// <param name="text">The text to shuffle.</param>
        /// <returns>The shuffled string.</returns>
        /// <remarks>
        /// This method is a version of the Fisher-Yates Shuffle.
        /// <see cref="https://www.dotnetperls.com/fisher-yates-shuffle"/>
        /// This shuffle uses in-place randomization via swapping elements
        /// in an array.
        /// In my opinion, the implementation is not immediately obvious as
        /// Scramble1's swap implementation is.
        /// 
        /// Doing a straight copy of the from a Google search seems like
        /// cheating, so I've chosen to use a string instead of a char[].
        /// 
        /// I like this shuffling algorithm a lot except for the
        /// whole micro-optimization theatre business surrounding
        /// string concatenation, StringBuilder, etc.  A character
        /// array would remove this concern and boost performance.
        /// Otherwise, this would the the goto method for shuffling lists,
        /// arrays, etc.
        /// 
        /// Time Complexity
        /// This method has O(n) time complexity.  This assumes
        /// Random.Next is O(1).  Note that the runtime complexity
        /// (looks like O(n^2) due to  the string concatenation) but
        /// is unknown at this time.
        /// 
        /// Space Complexity
        /// This method, excluding any inputs, is O(n).
        /// Note that the space complexity of Random.Next is unknown at
        /// this time.
        /// </remarks>
        public string Scramble2(string text)
        {
            int randomIndex = -1;

            // Verify text argument; otherwise return
            if (!string.IsNullOrEmpty(text))
            {
                for (int i = 0; i < text.Length; i++)
                {
                    randomIndex = Randomizer.Next(text.Length - i);

                    // I prefer straightforward string concatentation to avoid micro-optimization theatre.
                    // Alternatively, if this is a "hot" method, we could worry about it
                    // during performance testing or similar.
                    // See Jeff Attwood's great blog post on the topic here: https://blog.codinghorror.com/the-sad-tragedy-of-micro-optimization-theater/
                    text += text[randomIndex];
                    text = text.Remove(randomIndex, 1);
                }
            }

            return text;
        }

        /// <summary>
        /// Shuffles a given string via the Array.Sort algorithm
        /// and a lambda comparator.
        /// </summary>
        /// <param name="text">The text to shuffle.</param>
        /// <returns>The shuffled string.</returns>
        /// <remarks>
        /// This shuffle method uses the Array.Sort and a lambda comparer to scramble the
        /// characters.
        /// 
        /// I like that this can be implemented in only a few lines of
        /// code.  This makes it appealing.
        /// 
        /// Unfortunately, this feels like an abuse of the Array.Sort algorithm.
        /// In my opinion, the intent of Array.Sort is to sort elements into 
        /// ascending or descending order.  I assume that is what other
        /// programmers would read first which could lead to confusion.
        /// Randomness is without order or reason -
        /// the opposite of something that is sorted.
        /// 
        /// Also, the lambda could be seen as complicated to other developers
        /// that have not experienced lamdas, delegates, anonymous functions
        /// etc.
        /// 
        /// Due to the lack of readability, abuse of the sort algorithm, and a
        /// potentially biased shuffle, I would tend to avoid this algoirthm.
        /// 
        /// TIME COMPLEXITY
        /// Since Microsoft's Array.Sort method uses the QuickSort algorithm,
        /// the time complexity is O(n * log(n)) at best and O(n^2) at worst
        /// for this shuffle method.
        /// Note that the lambda adds its own complexity at runtime as well.
        /// 
        /// SPACE COMPLEXITY
        /// A Google search on "QuickSort space complexity" leads me to believe
        /// Microsoft's QuickSort is O(log(n)) space complexity.  Therefore,
        /// the space complexity is, not including inputs, is O(M + log(n)).
        /// </remarks>
        public string Scramble3(string text)
        {
            char[] charArray = new char[]{ };

            // Verify text argument; otherwise return
            if (!string.IsNullOrEmpty(text))
            {
                charArray = text.ToCharArray();

                // Randomizer.Next(-1, 1) will return -1 or 0 only
                // Removing the lambda would help with efficiency
                Array.Sort(charArray, (a, b) => Randomizer.Next(-1, 1));
            }

            return new string(charArray);
        }
    }
}
