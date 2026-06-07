using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Volume Speech")]
	[Category("Audio/Volume Speech")]
	[Image(typeof(IconVolume), ColorTheme.Type.Green)]
	[Description("The Speech volume value. Ranges between 0 and 1")]
	[Keywords(new string[] { "Audio", "Sound" })]
	public class GetDecimalVolumeSpeech : PropertyTypeGetDecimal
	{
		public override string String => "Speech Volume";

		public override double Get(Args args)
		{
			return Singleton<AudioManager>.Instance.Volume.Speech;
		}

		public override double Get(GameObject gameObject)
		{
			return Singleton<AudioManager>.Instance.Volume.Speech;
		}
	}
}
