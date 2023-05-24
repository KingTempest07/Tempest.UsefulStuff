using System;
using UnityEngine;

namespace Tempest.UsefulStuff {
    public static class MathTools {
        public enum Operations {
            addition, subtraction, multiplication, division, exponent, root
        }

        public static Operations GetOpposite(this Operations operation) {
            return operation switch {
                Operations.addition => Operations.subtraction,
                Operations.subtraction => Operations.addition,
                Operations.multiplication => Operations.division,
                Operations.division => Operations.multiplication,
                Operations.exponent => Operations.root,
                Operations.root => Operations.exponent,
                _ => throw new NotImplementedException()
            };
        }

        public static float PerformOperation(this float input, Operations operation, float editAmount) {
            if(operation == Operations.division && editAmount == 0) {
                Debug.LogError("Attempted to divide by zero. Dividing by one instead.");

                editAmount = 1f;
            }

            return operation switch {
                Operations.addition => input + editAmount,
                Operations.subtraction => input - editAmount,
                Operations.multiplication => input * editAmount,
                Operations.division => input / editAmount,
                Operations.exponent => Mathf.Pow(input, editAmount),
                // add Operations.root
                _ => throw new NotImplementedException()
            };
        }
    }
}