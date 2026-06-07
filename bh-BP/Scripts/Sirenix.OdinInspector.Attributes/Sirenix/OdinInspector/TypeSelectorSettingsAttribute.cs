using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class TypeSelectorSettingsAttribute : Attribute
	{
		public const string FILTER_TYPES_FUNCTION_NAMED_VALUE = "type";

		public string FilterTypesFunction;

		private bool? showNoneItem;

		private bool? showCategories;

		private bool? preferNamespaces;

		public bool ShowNoneItem
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ShowCategories
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool PreferNamespaces
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ShowNoneItemIsSet => false;

		public bool ShowCategoriesIsSet => false;

		public bool PreferNamespacesIsSet => false;
	}
}
