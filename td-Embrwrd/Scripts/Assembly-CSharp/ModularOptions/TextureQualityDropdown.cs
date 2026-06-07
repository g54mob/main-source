using UnityEngine;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Display/Texture Quality Dropdown")]
	public sealed class TextureQualityDropdown : DropdownOption
	{
		public enum TextureResolution
		{
			Full = 0,
			Half = 1,
			Quarter = 2,
			Eighth = 3
		}

		[Tooltip("Setting for the corresponding dropdown index.")]
		public TextureResolution[] textureResolutionOptions;

		[Tooltip("Setting for the corresponding dropdown index. Enable is per-texture (chosen in import settings), ForceEnable means 8xAF.")]
		public AnisotropicFiltering[] anisotropicFilteringOptions;

		protected override void ApplySetting(int _value)
		{
		}
	}
}
