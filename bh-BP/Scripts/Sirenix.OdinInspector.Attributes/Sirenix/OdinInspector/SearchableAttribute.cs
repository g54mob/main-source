using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[Conditional("UNITY_EDITOR")]
	[DontApplyToListElements]
	public class SearchableAttribute : Attribute
	{
		public bool FuzzySearch;

		public SearchFilterOptions FilterOptions;

		public bool Recursive;
	}
}
