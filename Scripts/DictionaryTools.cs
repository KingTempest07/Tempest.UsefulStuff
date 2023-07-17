using System.Collections.Generic;
using System.Linq;

namespace Tempest.UsefulStuff {
    public static class DictionaryTools {
        /// <summary>
        /// Does what you'd expect ('dict.Keys' contains 4 of something and 'keysToRemove' contains 1, so this would return 3). Does nothing on unshared keys.<br />
        /// <br />
        /// When using this function to return a value, make sure to assign 'dict' as a new dictionary rather than referencing a previous one (ex: 'new(dictValue)'), as not doing so will subtract from both.
        /// </summary>
        public static Dictionary<T1, T2> Subtract<T1, T2>(this Dictionary<T1, T2> dict, Dictionary<T1, T2>.KeyCollection keysToRemove) {
            keysToRemove.ToList().ForEach(key => {
                dict.Remove(key);
            });
            return dict;
        }

        /// <summary>
        /// Does what you'd expect ('dict.Values' contains 4 of something and 'valuesToRemove' contains 1, so this would return 3). Does nothing on unshared values.<br />
        /// <br />
        /// When using this function to return a value, make sure to assign 'dict' as a new dictionary rather than referencing a previous one (ex: 'new(dictValue)'), as not doing so will subtract from both.
        /// </summary>
        public static Dictionary<T1, T2> Subtract<T1, T2>(this Dictionary<T1, T2> dict, Dictionary<T1, T2>.ValueCollection valuesToRemove) {
            valuesToRemove.ToList().ForEach(value => {
                if (dict.ContainsValue(value)) {
                    dict.Remove(dict.First(kvp => kvp.Value.Equals(value)).Key);
                }
            });
            return dict;
        }



        /// <summary>
        /// Removes ALL key-value pairs from 'dict' that correspond with the keys in 'keysToRemove'. Does nothing on unshared keys.<br />
        /// <br />
        /// When using this function to return a value, make sure to assign 'dict' as a new dictionary rather than referencing a previous one (ex: 'new(dictValue)'), as not doing so will subtract from both.
        /// </summary>
        public static Dictionary<T1, T2> RemoveAllCorresponding<T1, T2>(this Dictionary<T1, T2> dict, Dictionary<T1, T2>.KeyCollection keysToRemove) {
            dict.Keys.ToList().ForEach(key => {
                if (keysToRemove.Contains(key)) {
                    dict.Remove(key);
                }
            });
            return dict;
        }



        public static T1 GetKeyByValue<T1, T2>(this Dictionary<T1, T2> dict, T2 value) {
            return dict.FirstOrDefault(kvp => kvp.Value.Equals(value)).Key;
        }
    }
}