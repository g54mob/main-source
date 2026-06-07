using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace UnityWebSocketSharp.Net
{
	[Serializable]
	internal class HttpListenerException : Win32Exception
	{
		public override int ErrorCode => 0;

		protected HttpListenerException(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
		}

		public HttpListenerException()
		{
		}

		public HttpListenerException(int errorCode)
		{
		}

		public HttpListenerException(int errorCode, string message)
		{
		}
	}
}
