using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.Audio;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Stop Speech on Game Object")]
	[Description("Stops any Speech clips being played by a specific Game Object")]
	[Category("Audio/Stop Speech on Game Object")]
	[Parameter("Target", "A game object that is set as the source of the speech")]
	[Keywords(new string[] { "Audio", "Voice", "Voices", "Sounds", "Character", "Silence", "Mute", "Fade" })]
	[Image(typeof(IconFace), ColorTheme.Type.TextLight, typeof(OverlayCross))]
	public class InstructionCommonAudioSpeechStopGameObject : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Target = GetGameObjectPlayer.Create();

		public override string Title => $"Stop {m_Target} speech";

		protected override Task Run(Args args)
		{
			GameObject target = m_Target.Get(args);
			target = AudioConfigSpeech.GetSpeechSource(target);
			Singleton<AudioManager>.Instance.Speech.Stop(target, 0.1f);
			return Instruction.DefaultResult;
		}
	}
}
