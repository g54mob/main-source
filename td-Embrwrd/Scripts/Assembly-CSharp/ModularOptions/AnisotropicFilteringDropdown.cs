using UnityEngine;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Display/Anisotropic Filtering Dropdown")]
	public sealed class AnisotropicFilteringDropdown : DropdownOption
	{
		[Tooltip("Setting for the corresponding dropdown index. Enable is per-texture (chosen in import settings), ForceEnable means 8xAF.")]
		public AnisotropicFiltering[] anisotropicFilteringOptions;

		protected override void ApplySetting(int _value)
		{
		}
	}
}
