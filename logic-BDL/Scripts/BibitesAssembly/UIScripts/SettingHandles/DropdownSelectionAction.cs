using ManagementScripts;
using SettingScripts;

namespace UIScripts.SettingHandles
{
	public class DropdownSelectionAction<TSetting, TType> : IRevertableAction where TSetting : Setting<TType>
	{
		private SettingDropdown<TSetting, TType> dropdown;

		private int prev;

		private int val;

		public DropdownSelectionAction(SettingDropdown<TSetting, TType> fromDropdown, int fromValue, int toValue)
		{
			dropdown = fromDropdown;
			prev = fromValue;
			val = toValue;
		}

		public void Revert()
		{
			bool dropdownSelectionRevertable = dropdown.dropdownSelectionRevertable;
			dropdown.dropdownSelectionRevertable = false;
			dropdown.dropdown.value = prev;
			dropdown.dropdownSelectionRevertable = dropdownSelectionRevertable;
		}

		public void ReDo()
		{
			bool dropdownSelectionRevertable = dropdown.dropdownSelectionRevertable;
			dropdown.dropdownSelectionRevertable = false;
			dropdown.dropdown.value = val;
			dropdown.dropdownSelectionRevertable = dropdownSelectionRevertable;
		}
	}
}
