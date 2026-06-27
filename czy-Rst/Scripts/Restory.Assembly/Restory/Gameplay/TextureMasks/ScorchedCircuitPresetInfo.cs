using Mandragora.PWS;
using UnityEngine;

namespace Restory.Gameplay.TextureMasks
{
	[CreateAssetMenu(menuName = "Restory/TextureMaskGeneration/Create ScorchedCircuitPreset", fileName = "ScorchedCircuitPreset", order = 0)]
	public class ScorchedCircuitPresetInfo : MaskPresetInfoBase
	{
		[SerializeField]
		private MaskCreatorPresetInfo maskCreatorPreset;

		public override ChannelGenerationEntry RedChannel => maskCreatorPreset.RedChannel;

		public override ChannelGenerationEntry GreenChannel => maskCreatorPreset.GreenChannel;

		public override ChannelGenerationEntry BlueChannel => maskCreatorPreset.BlueChannel;

		public override bool IsInDebugMode => maskCreatorPreset.IsInDebugMode;

		public override float PredefinedSeed => maskCreatorPreset.PredefinedSeed;

		public MaskCreatorPresetInfo MaskCreatorPreset => maskCreatorPreset;
	}
}
