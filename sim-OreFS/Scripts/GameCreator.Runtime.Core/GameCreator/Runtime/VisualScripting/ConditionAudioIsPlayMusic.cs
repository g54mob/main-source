using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Music Playing")]
	[Description("Returns true if the given music is playing")]
	[Category("Audio/Is Music Playing")]
	[Parameter("Audio Clip", "The audio clip to check")]
	[Keywords(new string[] { "SFX", "Music", "Audio", "Running" })]
	[Image(typeof(IconHeadset), ColorTheme.Type.Blue)]
	public class ConditionAudioIsPlayMusic : Condition
	{
		[SerializeField]
		private PropertyGetAudio m_AudioClip = new PropertyGetAudio();

		protected override string Summary => $"is Music {m_AudioClip} playing";

		protected override bool Run(Args args)
		{
			AudioClip audioClip = m_AudioClip.Get(args);
			if (audioClip != null)
			{
				return Singleton<AudioManager>.Instance.Music.IsPlaying(audioClip);
			}
			return false;
		}
	}
}
