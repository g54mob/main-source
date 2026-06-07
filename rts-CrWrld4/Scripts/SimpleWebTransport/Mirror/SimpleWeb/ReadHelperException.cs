using System;
using System.Runtime.Serialization;

namespace Mirror.SimpleWeb
{
	[Serializable]
	public class ReadHelperException : Exception
	{
		public ReadHelperException(string message)
		{
		}

		protected ReadHelperException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
