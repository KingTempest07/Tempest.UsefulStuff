using System;
using System.Linq;

namespace Tempest.UsefulStuff {
    public static class ReflectionTools {
        [Obsolete("Might not work")]
        public static Type[] GetAllScriptsOfType<T>() {
            return GetAllTypesInAssembly().Where(type => typeof(T).IsAssignableFrom(type)).ToArray();
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
                throw new Exception($"Failed to get a static property by the name of \"{propertyName}\" from type \"{type}\". {e.Message}");
            }
        }
        public static bool TryGetStaticProperty(this Type type, string propertyName, out object value) {
            value = type.GetProperty(propertyName).GetValue(null);
            return value != null;
        }
    }
}
