using System;

namespace Muna.Beta
{
	[Serializable]
	[Preserve]
	public sealed class RemoteValue
	{
		public string? data;

		public Dtype dtype;

		public int[]? shape;
	}
}
