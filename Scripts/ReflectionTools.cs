using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tempest.UsefulStuff {
    public static class ReflectionTools {
        public static List<Type> GetAllScriptsOfType<T>() {
            return System.Reflection.Assembly.GetCallingAssembly().GetTypes().Where(mytype => mytype.GetInterfaces().Contains(typeof(T))).ToList();
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
