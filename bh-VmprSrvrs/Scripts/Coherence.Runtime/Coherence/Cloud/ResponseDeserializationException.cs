using System;
using Coherence.Runtime;

namespace Coherence.Cloud
{
	public class ResponseDeserializationException : Exception
	{
		public Result ErrorCode;

		public ResponseDeserializationException(Result code, string message)
		{
		}
	}
}
