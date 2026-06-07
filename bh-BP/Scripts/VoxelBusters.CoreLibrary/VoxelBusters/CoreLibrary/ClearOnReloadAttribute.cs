using System;

namespace VoxelBusters.CoreLibrary
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event)]
	public class ClearOnReloadAttribute : Attribute
	{
		public ClearOnReloadOption Option { get; private set; }

		public object CustomValue { get; private set; }

		public ClearOnReloadAttribute()
		{
		}

		public ClearOnReloadAttribute(object customValue)
		{
		}

		public ClearOnReloadAttribute(ClearOnReloadOption option, object customValue = null)
		{
		}
	}
}
