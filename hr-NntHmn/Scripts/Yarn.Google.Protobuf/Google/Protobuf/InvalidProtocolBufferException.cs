using System;
using System.IO;

namespace Google.Protobuf
{
	public sealed class InvalidProtocolBufferException : IOException
	{
		internal InvalidProtocolBufferException(string message)
		{
		}

		internal InvalidProtocolBufferException(string message, Exception innerException)
		{
		}

		internal static InvalidProtocolBufferException MoreDataAvailable()
		{
			return null;
		}

		internal static InvalidProtocolBufferException TruncatedMessage()
		{
			return null;
		}

		internal static InvalidProtocolBufferException NegativeSize()
		{
			return null;
		}

		internal static InvalidProtocolBufferException MalformedVarint()
		{
			return null;
		}

		internal static InvalidProtocolBufferException InvalidTag()
		{
			return null;
		}

		internal static InvalidProtocolBufferException InvalidWireType()
		{
			return null;
		}

		internal static InvalidProtocolBufferException InvalidBase64(Exception innerException)
		{
			return null;
		}

		internal static InvalidProtocolBufferException InvalidEndTag()
		{
			return null;
		}

		internal static InvalidProtocolBufferException RecursionLimitExceeded()
		{
			return null;
		}

		internal static InvalidProtocolBufferException JsonRecursionLimitExceeded()
		{
			return null;
		}

		internal static InvalidProtocolBufferException SizeLimitExceeded()
		{
			return null;
		}

		internal static InvalidProtocolBufferException InvalidMessageStreamTag()
		{
			return null;
		}

		internal static InvalidProtocolBufferException MissingFields()
		{
			return null;
		}
	}
}
