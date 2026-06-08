using System;
using Amazon.Runtime.EventStreams.Internal;

namespace Amazon.S3.Model
{
	public class S3EventStreamException : EventStreamException
	{
		public S3EventStreamException()
		{
		}

		public S3EventStreamException(string message)
			: base(message)
		{
		}

		public S3EventStreamException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
