using System;
using UnityEngine;
using UnityEngine.Audio;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Audio Mixer Parameter")]
	[Category("Audio/Audio Mixer Parameter")]
	[Image(typeof(IconAudioMixer), ColorTheme.Type.Yellow)]
	[Description("The specified Audio Mixer parameter value")]
	[Keywords(new string[] { "Audio", "Sound" })]
	public class GetDecimalAudioMixer : PropertyTypeGetDecimal
	{
		[SerializeField]
		private AudioMixer m_AudioMixer;

		[SerializeField]
		private string m_Parameter;

		public override string String => string.Format("{0}[{1}]", (m_AudioMixer != null) ? m_AudioMixer.name : "(none)", m_Parameter);

		public override double Get(Args args)
		{
			if (m_AudioMixer == null)
			{
				return 0.0;
			}
			float value;
			return m_AudioMixer.GetFloat(m_Parameter, out value) ? value : 0f;
		}
	}
}
