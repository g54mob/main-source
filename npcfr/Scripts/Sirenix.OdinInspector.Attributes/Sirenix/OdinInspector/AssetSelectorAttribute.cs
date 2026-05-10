using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[Conditional("UNITY_EDITOR")]
	public class AssetSelectorAttribute : Attribute
	{
		[LabelWidth(200f)]
		public bool IsUniqueList;

		[LabelWidth(200f)]
		public bool DrawDropdownForListElements;

		[LabelWidth(200f)]
		public bool DisableListAddButtonBehaviour;

		[LabelWidth(200f)]
		public bool ExcludeExistingValuesInList;

		[LabelWidth(200f)]
		public bool ExpandAllMenuItems;

		[LabelWidth(200f)]
		public bool FlattenTreeView;

		public int DropdownWidth;

		public int DropdownHeight;

		public string DropdownTitle;

		public string[] SearchInFolders;

		public string Filter;

		[ShowInInspector]
		[DelayedProperty]
		[OdinDesignerBinding(new string[] { "SearchInFolders" })]
		public string Paths
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
	}
}
