using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.Audio;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Play UI sound")]
	[Description("Plays a non-diegetic user interface Audio Clip")]
	[Category("Audio/Play UI sound")]
	[Parameter("Audio Clip", "The Audio Clip to be played")]
	[Parameter("Wait To Complete", "Check if you want to wait until the sound finishes")]
	[Parameter("Pitch", "A random pitch value ranging between two values")]
	[Parameter("Spatial Blending", "Whether the sound is placed in a 3D space or not")]
	[Parameter("Target", "A Game Object reference that the sound follows as its source")]
	[Keywords(new string[] { "Audio", "Sounds", "User", "Interface", "Beep", "Button" })]
	[Image(typeof(IconUIButton), ColorTheme.Type.Yellow)]
	public class InstructionCommonAudioUIPlay : Instruction
	{
		[SerializeField]
		private PropertyGetAudio m_AudioClip = GetAudioClip.Create;

		[SerializeField]
		private bool m_WaitToComplete;

		[SerializeField]
		private AudioConfigSoundUI m_Config = new AudioConfigSoundUI();

		public override string Title => $"Play UI sound: {m_AudioClip}";

		protected override async Task Run(Args args)
		{
			AudioClip audioClip = m_AudioClip.Get(args);
			if (!(audioClip == null))
			{
				if (m_WaitToComplete)
				{
					await Singleton<AudioManager>.Instance.UserInterface.Play(audioClip, m_Config, args);
				}
				else
				{
					Singleton<AudioManager>.Instance.UserInterface.Play(audioClip, m_Config, args);
				}
			}
		}
	}
}
