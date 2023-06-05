using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tempest.UsefulStuff {
    public static class ReflectionTools {
        public static Type[] GetAllScriptsOfType<T>() {
            return GetAllTypesInAssembly().Where(type => typeof(T).IsInstanceOfType(type)).ToArray();
        }
        public static Type[] GetAllScriptsOfInterface<T>() {
            return GetAllTypesInAssembly().Where(type => type.GetInterfaces().Contains(typeof(T))).ToArray();
        }

        public static Type[] GetAllTypesInAssembly() {
            return System.Reflection.Assembly.GetCallingAssembly().GetTypes();
        }

        public static object GetStaticProperty(this Type type, string propertyName) {
            try {
                return type.GetProperty(propertyName).GetValue(null);
            }
            catch (Exception e) {
                Debug.LogError($"Failed to get a static property by the name of \"{propertyName}\" from type \"{type}\". {e.Message}");
                return null;
            }
        }
        public static bool TryGetStaticProperty(this Type type, string propertyName, out object value) {
            value = type.GetProperty(propertyName).GetValue(null);
            return value != null;
        }
    }
}
