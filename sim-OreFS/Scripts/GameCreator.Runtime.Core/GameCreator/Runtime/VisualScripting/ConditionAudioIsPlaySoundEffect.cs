using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Sound Effect Playing")]
	[Description("Returns true if the given sound effect is playing")]
	[Category("Audio/Is Sound Effect Playing")]
	[Parameter("Audio Clip", "The audio clip to check")]
	[Keywords(new string[] { "SFX", "Music", "Audio", "Running" })]
	[Image(typeof(IconMusicNote), ColorTheme.Type.Blue)]
	public class ConditionAudioIsPlaySoundEffect : Condition
	{
		[SerializeField]
		private PropertyGetAudio m_AudioClip = new PropertyGetAudio();

		protected override string Summary => $"is SFX {m_AudioClip} playing";

		protected override bool Run(Args args)
		{
			AudioClip audioClip = m_AudioClip.Get(args);
			if (audioClip != null)
			{
				return Singleton<AudioManager>.Instance.SoundEffect.IsPlaying(audioClip);
			}
			return false;
		}
	}
}
