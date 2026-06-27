using Mandragora.Utils;
using UnityEngine;

namespace Mandragora.PWS
{
	[CreateAssetMenu(menuName = "Mandragora/PowerwashSimulator/Create MaskCreatorPreset", fileName = "MaskCreatorPreset", order = 0)]
	public class MaskCreatorPreset : ScriptableObject
	{
		public ChannelGenerationEntry RedChannel;

		public ChannelGenerationEntry GreenChannel;

		public ChannelGenerationEntry BlueChannel;

		[BoolButton(25, 0, Red = false)]
		public bool IsInDebugMode;

		public float RandomSeed;
	}
}
