using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.Audio;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Play Speech")]
	[Description("Plays an Audio Clip speech over just once")]
	[Category("Audio/Play Speech")]
	[Parameter("Audio Clip", "The Audio Clip to be played")]
	[Parameter("Wait To Complete", "Check if you want to wait until the sound finishes")]
	[Parameter("Spatial Blending", "Whether the sound is placed in a 3D space or not")]
	[Parameter("Target", "A Game Object reference that the sound follows as its source")]
	[Keywords(new string[] { "Audio", "Voice", "Voices", "Sounds", "Character" })]
	[Image(typeof(IconFace), ColorTheme.Type.Yellow)]
	public class InstructionCommonAudioSpeechPlay : Instruction
	{
		[SerializeField]
		private PropertyGetAudio m_AudioClip = GetAudioClip.Create;

		[SerializeField]
		private bool m_WaitToComplete;

		[SerializeField]
		private AudioConfigSpeech m_Config = new AudioConfigSpeech();

		public override string Title => $"Play Speech: {m_AudioClip}";

		protected override async Task Run(Args args)
		{
			AudioClip audioClip = m_AudioClip.Get(args);
			if (!(audioClip == null))
			{
				if (m_WaitToComplete)
				{
					await Singleton<AudioManager>.Instance.Speech.Play(audioClip, m_Config, args);
				}
				else
				{
					Singleton<AudioManager>.Instance.Speech.Play(audioClip, m_Config, args);
				}
			}
		}
	}
}
