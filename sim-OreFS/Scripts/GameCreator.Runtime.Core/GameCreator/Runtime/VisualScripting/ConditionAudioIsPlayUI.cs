using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is UI Playing")]
	[Description("Returns true if the given UI sound is playing")]
	[Category("Audio/Is UI Playing")]
	[Parameter("Audio Clip", "The audio clip to check")]
	[Keywords(new string[] { "SFX", "Music", "Audio", "Running" })]
	[Image(typeof(IconUIButton), ColorTheme.Type.Blue)]
	public class ConditionAudioIsPlayUI : Condition
	{
		[SerializeField]
		private PropertyGetAudio m_AudioClip = new PropertyGetAudio();

		protected override string Summary => $"is UI {m_AudioClip} playing";

		protected override bool Run(Args args)
		{
			AudioClip audioClip = m_AudioClip.Get(args);
			if (audioClip != null)
			{
				return Singleton<AudioManager>.Instance.UserInterface.IsPlaying(audioClip);
			}
			return false;
		}
	}
}
