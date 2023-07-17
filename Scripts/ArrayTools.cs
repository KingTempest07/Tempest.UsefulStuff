namespace Tempest.UsefulStuff {
    public static class ArrayTools {
        public static string[] ToUpper(this string[] array) {
            for (int i = 0 ; i < array.Length ; i++) {
                array[i] = array[i].ToUpper();
            }

            return array;
        }
    }
}