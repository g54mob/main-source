using System;
using Coherence.Toolkit.Bindings;

namespace Coherence.Toolkit
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class SyncAttribute : Attribute
	{
		public SyncMode DefaultSyncMode;

		public string OldName { get; }

		public SyncAttribute()
		{
		}

		public SyncAttribute(string oldName = null)
		{
		}
	}
}
