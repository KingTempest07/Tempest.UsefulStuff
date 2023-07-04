using System;

using UnityEngine;

namespace Tempest.UsefulStuff {
    public static class VectorTools {
        public static Vector2 DegreesToVector(this float input) {
            return new Vector2((float) Math.Cos(input * Math.PI / 180), (float) Math.Sin(input * Math.PI / 180)).normalized;
        }
    }
}
