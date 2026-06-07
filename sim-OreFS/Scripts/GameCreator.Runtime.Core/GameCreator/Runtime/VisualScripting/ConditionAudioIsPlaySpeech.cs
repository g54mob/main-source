using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Speech Playing")]
	[Description("Returns true if the given Speech sound is playing")]
	[Category("Audio/Is Speech Playing")]
	[Parameter("Audio Clip", "The audio clip to check")]
	[Keywords(new string[] { "SFX", "Music", "Audio", "Running" })]
	[Image(typeof(IconFace), ColorTheme.Type.Blue)]
	public class ConditionAudioIsPlaySpeech : Condition
	{
		[SerializeField]
		private PropertyGetAudio m_AudioClip = new PropertyGetAudio();

		protected override string Summary => $"is Speech {m_AudioClip} playing";

		protected override bool Run(Args args)
		{
			AudioClip audioClip = m_AudioClip.Get(args);
			if (audioClip != null)
			{
				return Singleton<AudioManager>.Instance.Speech.IsPlaying(audioClip);
			}
			return false;
		}
	}
}
