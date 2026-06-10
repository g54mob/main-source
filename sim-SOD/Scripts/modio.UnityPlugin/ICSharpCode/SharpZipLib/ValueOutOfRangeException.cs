using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib
{
	[Serializable]
	public class ValueOutOfRangeException : StreamDecodingException
	{
		public ValueOutOfRangeException(string nameOfValue)
		{
		}

		public ValueOutOfRangeException(string nameOfValue, long value, long maxValue, long minValue = 0L)
		{
		}

		public ValueOutOfRangeException(string nameOfValue, string value, string maxValue, string minValue = "0")
		{
		}

		private ValueOutOfRangeException()
		{
		}

		private ValueOutOfRangeException(string message, Exception innerException)
		{
		}

		protected ValueOutOfRangeException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
