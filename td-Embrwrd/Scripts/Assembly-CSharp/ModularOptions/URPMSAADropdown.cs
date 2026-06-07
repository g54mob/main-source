using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Display/Universal Render Pipeline/MSAA Dropdown")]
	public sealed class URPMSAADropdown : DropdownOption
	{
		public enum MSAASamples
		{
			None = 1,
			MSAA2x = 2,
			MSAA4x = 4,
			MSAA8x = 8
		}

		public UniversalRenderPipelineAsset pipelineAsset;

		[Tooltip("Setting for the corresponding dropdown index.")]
		public MSAASamples[] options;

		protected override void ApplySetting(int _value)
		{
		}
	}
}
