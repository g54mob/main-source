using System;

namespace MLAPI.Messaging
{
	public abstract class RpcResponseBase
	{
		public ulong Id { get; internal set; }

		public bool IsDone { get; internal set; }

		public bool IsSuccessful { get; set; }

		public ulong ClientId { get; internal set; }

		public float Timeout { get; set; } = 10f;

		internal abstract object Result { set; }

		internal Type Type { get; set; }
	}
}
