using TMPro;
using UnityEngine;

namespace VampireSurvivors.UI
{
	public class CustomDropdownItemText : CustomDropdownItem
	{
		[SerializeField]
		private TextMeshProUGUI _Label;

		public override void Initialize(object option, CustomDropDown dropdown)
		{
		}
	}
}
