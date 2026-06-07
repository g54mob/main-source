using System;
using System.Diagnostics;

namespace SaintsField.Playa
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class ListDrawerSettingsAttribute : Attribute, IPlayaAttribute
	{
		public readonly int NumberOfItemsPerPage;

		public readonly bool Searchable;

		public readonly bool Delayed;

		public ListDrawerSettingsAttribute(bool searchable = false, int numberOfItemsPerPage = 0, bool delayedSearch = false)
		{
			NumberOfItemsPerPage = numberOfItemsPerPage;
			Delayed = delayedSearch;
			Searchable = Delayed || searchable;
		}
	}
}
