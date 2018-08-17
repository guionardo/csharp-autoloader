using System;
using System.Runtime.Serialization;

namespace Autoload
{
    [Serializable]
    internal class AutoloadException : Exception
    {
        public AutoloadException()
        {
        }

        public AutoloadException(string message) : base(message)
        {
        }

        public AutoloadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AutoloadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}