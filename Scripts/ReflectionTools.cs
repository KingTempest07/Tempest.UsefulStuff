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

        public static bool TryGetStaticProperty(Type type, string propertyName, out object value) {
            value = TryGetStaticProperty(type, propertyName);
            return value != null;
        }
        public static object TryGetStaticProperty(Type type, string propertyName) {
            try {
                return type.GetProperty(propertyName).GetValue(null);
            }
            catch (Exception e) {
                Debug.LogError($"Failed to get the \"{propertyName}\" property from type \"{type}.\" Make sure you input the correct property name and that the one you want is static. {e.Message}");
                return null;
            }
        }
    }
}
