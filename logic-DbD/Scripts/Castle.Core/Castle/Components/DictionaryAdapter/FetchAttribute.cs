using System;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface, AllowMultiple = false)]
	public class FetchAttribute : Attribute
	{
		public bool Fetch { get; private set; }

		public FetchAttribute()
			: this(fetch: true)
		{
		}

		public FetchAttribute(bool fetch)
		{
			Fetch = fetch;
		}
	}
}
