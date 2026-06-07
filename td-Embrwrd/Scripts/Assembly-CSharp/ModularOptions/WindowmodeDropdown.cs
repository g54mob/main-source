using UnityEngine;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Display/Windowmode Dropdown")]
	public sealed class WindowmodeDropdown : DropdownOption
	{
		[Tooltip("Setting for the corresponding dropdown index.")]
		public FullScreenMode[] options;

		protected override void ApplySetting(int _value)
		{
		}
	}
}
