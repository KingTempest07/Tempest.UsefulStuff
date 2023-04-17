using System.Collections.Generic;

namespace Tempest.UsefulStuff {
    public static class GenericTools {

    }

    public struct GenericInfoStorage<T> {
        public GenericInfoStorage(T valueToStore) {
            storedValue = valueToStore;
        }

        public T storedValue;
    }
}