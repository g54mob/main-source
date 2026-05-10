using System;

namespace CTS.Core.Pooling
{
	public class PoolGuid
	{
		public Guid Guid { get; internal set; }

		public static implicit operator Guid(PoolGuid poolGuid)
		{
			return poolGuid.Guid;
		}

		internal PoolGuid()
		{
		}
	}
}
