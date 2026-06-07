using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Speech volume")]
	[Description("Change the Volume of character Speech")]
	[Category("Audio/Change Speech volume")]
	[Parameter("Volume", "A value between 0 and 1 that indicates the volume percentage")]
	[Keywords(new string[] { "Audio", "Character", "Voice", "Voices", "Volume", "Level" })]
	[Image(typeof(IconVolume), ColorTheme.Type.Green)]
	public class InstructionCommonAudioVolumeSpeech : Instruction
	{
		public PropertyGetDecimal m_Volume = new PropertyGetDecimal(1f);

		public override string Title => $"Change Speech volume to {m_Volume}";

		protected override Task Run(Args args)
		{
			Singleton<AudioManager>.Instance.Volume.Speech = (float)m_Volume.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
