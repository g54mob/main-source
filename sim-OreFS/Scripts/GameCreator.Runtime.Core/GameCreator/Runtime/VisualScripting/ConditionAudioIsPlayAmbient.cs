using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Ambient Playing")]
	[Description("Returns true if the given Ambient sound is playing")]
	[Category("Audio/Is Ambient Playing")]
	[Parameter("Audio Clip", "The audio clip to check")]
	[Keywords(new string[] { "SFX", "Music", "Audio", "Running" })]
	[Image(typeof(IconBird), ColorTheme.Type.Blue)]
	public class ConditionAudioIsPlayAmbient : Condition
	{
		[SerializeField]
		private PropertyGetAudio m_AudioClip = new PropertyGetAudio();

		protected override string Summary => $"is Ambient {m_AudioClip} playing";

		protected override bool Run(Args args)
		{
			AudioClip audioClip = m_AudioClip.Get(args);
			if (audioClip != null)
			{
				return Singleton<AudioManager>.Instance.Ambient.IsPlaying(audioClip);
			}
			return false;
		}
	}
}
