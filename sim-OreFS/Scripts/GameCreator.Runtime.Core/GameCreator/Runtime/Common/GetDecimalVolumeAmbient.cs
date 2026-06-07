using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Volume Ambient")]
	[Category("Audio/Volume Ambient")]
	[Image(typeof(IconVolume), ColorTheme.Type.Green)]
	[Description("The Ambient volume value. Ranges between 0 and 1")]
	[Keywords(new string[] { "Audio", "Sound" })]
	public class GetDecimalVolumeAmbient : PropertyTypeGetDecimal
	{
		public override string String => "Ambient Volume";

		public override double Get(Args args)
		{
			return Singleton<AudioManager>.Instance.Volume.Ambient;
		}

		public override double Get(GameObject gameObject)
		{
			return Singleton<AudioManager>.Instance.Volume.Ambient;
		}
	}
}
