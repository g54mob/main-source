using Mandragora.PWS;
using Mandragora.Utils;
using UnityEngine;

namespace Restory.Gameplay.TextureMasks
{
	[CreateAssetMenu(menuName = "Restory/TextureMaskGeneration/Create MaskCreatorPreset", fileName = "MaskCreatorPreset", order = 0)]
	public class MaskCreatorPresetInfo : MaskPresetInfoBase
	{
		[SerializeField]
		private ChannelGenerationEntry redChannel;

		[SerializeField]
		private ChannelGenerationEntry greenChannel;

		[SerializeField]
		private ChannelGenerationEntry blueChannel;

		[SerializeField]
		private float predefinedSeed;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool isInDebugMode;

		public override ChannelGenerationEntry RedChannel => redChannel;

		public override ChannelGenerationEntry GreenChannel => greenChannel;

		public override ChannelGenerationEntry BlueChannel => blueChannel;

		public override bool IsInDebugMode => false;

		public override float PredefinedSeed => predefinedSeed;
	}
}
