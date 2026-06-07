using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Volume SFX")]
	[Category("Audio/Volume SFX")]
	[Image(typeof(IconVolume), ColorTheme.Type.Green)]
	[Description("The SFX volume value. Ranges between 0 and 1")]
	[Keywords(new string[] { "Audio", "Sound", "Effect" })]
	public class GetDecimalVolumeSFX : PropertyTypeGetDecimal
	{
		public override string String => "SFX Volume";

		public override double Get(Args args)
		{
			return Singleton<AudioManager>.Instance.Volume.SoundEffects;
		}

		public override double Get(GameObject gameObject)
		{
			return Singleton<AudioManager>.Instance.Volume.SoundEffects;
		}
	}
}
