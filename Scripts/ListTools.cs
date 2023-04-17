using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tempest.UsefulStuff {
    public static class ListTools {
        public static void Subtract<T>(this List<T> list, List<T> valuesToRemove) {
            list.ToList().ForEach(value => {
                if (valuesToRemove.Contains(value)) {
                    list.Remove(value);
                }
            });
        }



        public static bool GetFirstOfType<TType, TListType>(this List<TListType> list, Type type, out TListType value) where TType : class {
            value = list.GetFirstOfType(type);
            return value != null;
        }
        public static TListType GetFirstOfType<TType, TListType>(this List<TListType> list, TType type) where TType : class {
            Debug.Log(type);
            return list.Find(value => value.GetType() == type.GetType());
        }

        public static bool GetFirstOfType<TType, TListType>(this List<TListType> list, out TListType value) where TType : class {
            value = list.GetFirstOfType<TType, TListType>();
            return value != null;
        }
        public static TListType GetFirstOfType<TType, TListType>(this List<TListType> list) where TType : class {
            return list.Find(value => value.GetType() == typeof(TType));
        }

        /*private static string listAsString;
        public static string ConvertToString(this List<string> list) {
            listAsString = "";

            list.ForEach(item => {
                listAsString += item + item != list[list.Count - 1] ? ", " : "";
            });

            return listAsString;
        }*/
    }
}