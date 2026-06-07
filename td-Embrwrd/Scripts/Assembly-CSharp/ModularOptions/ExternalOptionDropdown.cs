using UnityEngine;
using UnityEngine.UI;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/External/Dropdown")]
	public class ExternalOptionDropdown : DropdownOption
	{
		public Dropdown.DropdownEvent onValueChange;

		protected override void ApplySetting(int _value)
		{
		}
	}
}
