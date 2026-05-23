using System;
using System.Diagnostics;

namespace LBG
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public sealed class SubclassSelectorAttribute : Attribute
	{
		private string _customTypeFilter = string.Empty;

		private bool _hasCustomTypeFilter;

		private string _onTypesSelected = string.Empty;

		private bool _hasOnTypesSelected;

		public bool AllowDuplicates { get; set; } = true;

		public bool HideReferencePicker { get; set; } = true;

		public bool DrawDropdownForListElements { get; set; } = true;

		public bool DrawBoxForListElements { get; set; }

		public bool HideClassLabel { get; set; }

		public bool HideChildProperties { get; set; }

		public bool DrawClassFoldout { get; set; } = true;

		public string CustomTypeFilter
		{
			get
			{
				return _customTypeFilter;
			}
			set
			{
				_hasCustomTypeFilter = !string.IsNullOrEmpty(value);
				_customTypeFilter = value;
			}
		}

		public bool HasCustomTypeFilter => _hasCustomTypeFilter;

		public string OnTypesSelected
		{
			get
			{
				return _onTypesSelected;
			}
			set
			{
				_hasOnTypesSelected = !string.IsNullOrEmpty(value);
				_onTypesSelected = value;
			}
		}

		public bool HasOnTypesSelected => _hasOnTypesSelected;
	}
}
