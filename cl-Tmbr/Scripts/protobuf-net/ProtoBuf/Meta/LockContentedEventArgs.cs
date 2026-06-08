using System;

namespace ProtoBuf.Meta
{
	public sealed class LockContentedEventArgs : EventArgs
	{
		public string OwnerStackTrace { get; }

		internal LockContentedEventArgs(string ownerStackTrace)
		{
			OwnerStackTrace = ownerStackTrace;
		}
	}
}
