using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.Audio;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Play Ambient")]
	[Description("Plays a looped Audio Clip. Useful for background effects or persistent sounds.")]
	[Category("Audio/Play Ambient")]
	[Parameter("Audio Clip", "The Audio Clip to be played")]
	[Parameter("Transition In", "Time it takes for the sound to fade in")]
	[Parameter("Spatial Blending", "Whether the sound is placed in a 3D space or not")]
	[Parameter("Target", "A Game Object reference that the sound follows as the source")]
	[Keywords(new string[] { "Audio", "Ambience", "Background" })]
	[Image(typeof(IconBird), ColorTheme.Type.Yellow)]
	public class InstructionCommonAudioAmbientPlay : Instruction
	{
		[SerializeField]
		private PropertyGetAudio m_AudioClip = GetAudioClip.Create;

		[SerializeField]
		private AudioConfigAmbient m_Config = new AudioConfigAmbient();

		public override string Title => $"Play Ambient: {m_AudioClip}";

		protected override Task Run(Args args)
		{
			AudioClip audioClip = m_AudioClip.Get(args);
			if (audioClip == null)
			{
				return Instruction.DefaultResult;
			}
			if (!Singleton<AudioManager>.Instance.Ambient.IsPlaying(audioClip))
			{
				Singleton<AudioManager>.Instance.Ambient.Play(audioClip, m_Config, args);
			}
			return Instruction.DefaultResult;
		}
	}
}
