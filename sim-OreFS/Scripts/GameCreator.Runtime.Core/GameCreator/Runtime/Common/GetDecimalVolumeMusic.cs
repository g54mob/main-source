using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Volume Music")]
	[Category("Audio/Volume Music")]
	[Image(typeof(IconVolume), ColorTheme.Type.Green)]
	[Description("The Music volume value. Ranges between 0 and 1")]
	[Keywords(new string[] { "Audio", "Sound" })]
	public class GetDecimalVolumeMusic : PropertyTypeGetDecimal
	{
		public override string String => "Music Volume";

		public override double Get(Args args)
		{
			return Singleton<AudioManager>.Instance.Volume.Music;
		}

		public override double Get(GameObject gameObject)
		{
			return Singleton<AudioManager>.Instance.Volume.Music;
		}
	}
}
