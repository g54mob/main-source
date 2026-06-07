using UnityEngine;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Display/Builtin Render Pipeline/MultiSample Anti-Aliasing Dropdown")]
	public sealed class MSAADropdown : DropdownOption
	{
		public enum MSAASamples
		{
			None = 1,
			MSAA2x = 2,
			MSAA4x = 4,
			MSAA8x = 8
		}

		[Tooltip("Setting for the corresponding dropdown index.")]
		public MSAASamples[] options;

		protected override void ApplySetting(int _value)
		{
		}
	}
}
