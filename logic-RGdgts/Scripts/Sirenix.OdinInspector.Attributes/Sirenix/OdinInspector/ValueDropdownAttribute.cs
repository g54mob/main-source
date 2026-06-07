using System;

namespace Sirenix.OdinInspector
{
	public class ValueDropdownAttribute : Attribute
	{
		public string ValuesGetter;

		public int NumberOfItemsBeforeEnablingSearch;

		public bool IsUniqueList;

		public bool DrawDropdownForListElements;

		public bool DisableListAddButtonBehaviour;

		public bool ExcludeExistingValuesInList;

		public bool ExpandAllMenuItems;

		public bool AppendNextDrawer;

		public bool DisableGUIInAppendedDrawer;

		public bool DoubleClickToConfirm;

		public bool FlattenTreeView;

		public int DropdownWidth;

		public int DropdownHeight;

		public string DropdownTitle;

		public bool SortDropdownItems;

		public bool HideChildProperties;

		public bool CopyValues;

		[Obsolete]
		public string MemberName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ValueDropdownAttribute(string valuesGetter)
		{
		}
	}
}
