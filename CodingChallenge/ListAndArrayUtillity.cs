using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge
{
    /// <summary>
    /// Helper for list, array, IEnumerable ...
    /// </summary>
    public class ListAndArrayUtility
    {
        /// <summary>
        /// Gibt an, ob expectedValue mindestens 1x in values enthalten ist.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="expectedValue"></param>
        /// <returns></returns>
        public static bool Contains(IEnumerable<int> values, int expectedValue)
        {
            if (values != null)
            {
                return values.Any(value => value == expectedValue);
            }

            Debug.Assert(false, "values must not be null");

            return false;
        }

        /// <summary>
        /// Trennt am Delimiter ",".
        /// Whitespace wird nicht entfernt!
        /// </summary>
        /// <param name="stringWithDelimiters">e.g. "a1,a2 ,a3"</param>
        /// <returns>null if input is null.</returns>
        public static List<string> ConvertToList(string stringWithDelimiters)
        {
            if (stringWithDelimiters == null) { return null; }

            List<string> list = new List<string>(stringWithDelimiters.Split(','));

            return list;
        }

        /// <summary>Converts from list to array. Accepts input null.</summary>
        /// <returns>null if input is null.</returns>
        public static T[] ConvertToArray<T>(List<T> source)
        {
            T[] result = null;

            if (source != null)
            {
                result = source.ToArray();
            }

            return result;
        }

        /// <summary>
        /// Converts list of <see cref="long"/> into list of <see cref="string"/>.
        /// Null will be converted to empty list.
        /// </summary>
        /// <param name="input">May be null.</param>
        /// <returns>Will not be null.</returns>
        public static IList<string> ConvertToListOfStrings(IList<long> input)
        {
            var result = new List<string>();

            if (input == null)
            {
                return result;
            }

            foreach (var child in input)
            {
                result.Add(child.ToString());
            }

            return result;
        }

        /// <summary>
        /// Elemente einer Liste werden als 1 String zurückgeliefert. Beispiel "a1,a2"
        /// </summary>
        /// <param name="items">e.g. "a1,a2 ,a3"</param>
        /// <returns>null if input is null.</returns>
        public string ToString<T>(IList<T> items)
        {
            if (items == null) { return null; }

            var builder = new StringBuilder();

            foreach (T item in items)
            {
                if (builder.Length > 0)
                {
                    builder.Append(",");
                }

                builder.Append(item);
            }

            return builder.ToString();
        }

        /// <summary>Fügt die Elemente von source zu target hinzu. Es wird nicht verhindert, 
        /// dass Doubletten entstehen. Bisher werden keine neuen Strings erstellt.</summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        /// <param name="isAddUniqueOnly"></param>
        /// <returns>true: mindestens 1 Wert wurde hinzugefügt.</returns>
        public static bool AddValues(IList<string> target, IList<string> source, bool isAddUniqueOnly = true)
        {
            if (target == null
                || source == null)
            {
                return false;
            }

            bool isValueAdded = false;

            foreach (string zipCodeOfDescendant in source)
            {
                bool isDoAdd = true;

                if (isAddUniqueOnly
                    && target.IndexOf(zipCodeOfDescendant) >= 0)
                {
                    isDoAdd = false;
                }

                if (isDoAdd)
                {
                    target.Add(zipCodeOfDescendant);
                }

                isValueAdded = true;
            }

            return isValueAdded;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="toAdd"></param>
        public static bool AddUniquely(IList<string> target, string toAdd)
        {
            if (target == null
                || String.IsNullOrEmpty(toAdd))
            {
                return false;
            }

            if (target.IndexOf(toAdd) < 0)
            {
                target.Add(toAdd);
                return true;
            }

            return false;
        }

        /// <summary>
        /// true: Array ist null oder leer.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(string[] array)
        {
            if (array == null
                || array.Length == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Concats all elements to a string easily read by humans.
        /// </summary>
        /// <param name="elements">Elements to visualize.</param>
        /// <returns>all concatenated elements</returns>
        /// <remarks>Marks the start of each elemment by  "--{number}--: ".
        /// Number is the elements position.
        /// in <paramref name="elements"/>.</remarks>
        public static string VisualizeContent(ICollection<string> elements)
        {
            var builder = new StringBuilder();
            var number = 0;

            foreach (var current in elements)
            {
                if (number > 0)
                {
                    builder.Append(" ");
                }

                builder.Append($"--{number}--: '{current}'");

                number++;
            }

            return builder.ToString();
        }
    }
}
