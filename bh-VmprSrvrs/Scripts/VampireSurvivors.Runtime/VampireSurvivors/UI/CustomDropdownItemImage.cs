using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class CustomDropdownItemImage : CustomDropdownItem
	{
		[SerializeField]
		private Image _Image;

		public override void Initialize(object option, CustomDropDown dropdown)
		{
		}
	}
}
