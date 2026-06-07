using System;

namespace Coherence.Toolkit
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class OnValueSyncedAttribute : Attribute
	{
		public readonly string Callback;

		public bool SuppressNotBoundError { get; set; }

		public bool SuppressParamOrderError { get; set; }

		public OnValueSyncedAttribute(string callback)
		{
		}
	}
}
