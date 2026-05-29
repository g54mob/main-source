using UnityEngine;

namespace UniversalSettings
{
	[AddComponentMenu("Universal Settings/Graphic/Texture Resolution Dropdown")]
	public class TextureResolutionController : SettingsComponentDropdown
	{
		[SerializeField]
		private bool autoApply;

		protected override void Setup()
		{
			CreateOptions(universalSettings.GetDropdownTextureResolutionOptions());
		}

		protected override ref int SettingsValue()
		{
			return ref universalSettings.viewSettings.textureResolutionIndex;
		}

		protected override bool AutoApplyValue()
		{
			return autoApply;
		}

		protected override void AutoApply()
		{
			universalSettings.SetTextureResolution((TextureResolution)SettingsValue());
		}
	}
}
