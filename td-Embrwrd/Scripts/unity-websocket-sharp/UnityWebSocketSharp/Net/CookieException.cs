using System;
using System.Runtime.Serialization;

namespace UnityWebSocketSharp.Net
{
	[Serializable]
	internal class CookieException : FormatException, ISerializable
	{
		internal CookieException(string message)
		{
		}

		internal CookieException(string message, Exception innerException)
		{
		}

		protected CookieException(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
		}

		public CookieException()
		{
		}

		public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
		}

		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
		}
	}
}
