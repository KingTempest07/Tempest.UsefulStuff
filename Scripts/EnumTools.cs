using System;

namespace Tempest.UsefulStuff {
    public static class EnumTools {
        /// <summary>
        /// Moves to the next highest value in the enum.
        /// </summary>
        /// <remarks>
        /// Original version made by husayt on StackOverflow: https://stackoverflow.com/a/643438/19321997
        /// </remarks>
        public static T Next<T>(this T src) where T : struct {
            if (!typeof(T).IsEnum) {
                throw new ArgumentException($"Argument {typeof(T).FullName} is not an Enum");
            }

            T[] Arr = (T[]) Enum.GetValues(src.GetType());
            int j = Array.IndexOf(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }
    }
}
