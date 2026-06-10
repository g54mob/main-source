using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ManageGroupDropdownLayoutItemView : LayoutGroupItemView
	{
		[SerializeField]
		private TMP_Dropdown dropdown;

		public TMP_Dropdown Dropdown => dropdown;
	}
}
