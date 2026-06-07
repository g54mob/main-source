using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Music volume")]
	[Description("Change the Volume of Music")]
	[Category("Audio/Change Music volume")]
	[Parameter("Volume", "A value between 0 and 1 that indicates the volume percentage")]
	[Keywords(new string[] { "Audio", "Music", "Background", "Volume", "Level" })]
	[Image(typeof(IconVolume), ColorTheme.Type.Green)]
	public class InstructionCommonAudioVolumeMusic : Instruction
	{
		public PropertyGetDecimal m_Volume = new PropertyGetDecimal(1f);

		public override string Title => $"Change Music volume to {m_Volume}";

		protected override Task Run(Args args)
		{
			Singleton<AudioManager>.Instance.Volume.Music = (float)m_Volume.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
