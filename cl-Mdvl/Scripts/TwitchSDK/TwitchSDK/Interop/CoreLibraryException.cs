using System;
using System.Runtime.Serialization;

namespace TwitchSDK.Interop
{
	[Serializable]
	public class CoreLibraryException : Exception
	{
		public CoreLibraryException()
		{
		}

		public CoreLibraryException(string message)
			: base(message)
		{
		}

		public CoreLibraryException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected CoreLibraryException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
