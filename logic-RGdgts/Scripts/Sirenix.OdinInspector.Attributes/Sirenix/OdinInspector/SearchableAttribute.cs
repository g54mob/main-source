using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	public class SearchableAttribute : Attribute
	{
		public bool FuzzySearch;

		public SearchFilterOptions FilterOptions;

		public bool Recursive;
	}
}
