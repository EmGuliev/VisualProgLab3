using System;

namespace VisualProgLab3
{
    public class RomanNumberException : Exception
    {
        public RomanNumberException (string message)
            : base(message)
        {}
    }
}
