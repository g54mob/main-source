using UnityEngine;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Display/Texture Resolution Dropdown")]
	public sealed class TextureResolutionDropdown : DropdownOption
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

		protected override void ApplySetting(int _value)
		{
		}
	}
}
