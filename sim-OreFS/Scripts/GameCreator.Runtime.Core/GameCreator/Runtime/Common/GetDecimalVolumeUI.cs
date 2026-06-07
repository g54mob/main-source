using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Volume UI")]
	[Category("Audio/Volume UI")]
	[Image(typeof(IconVolume), ColorTheme.Type.Green)]
	[Description("The UI volume value. Ranges between 0 and 1")]
	[Keywords(new string[] { "Audio", "Sound", "Effect" })]
	public class GetDecimalVolumeUI : PropertyTypeGetDecimal
	{
		public override string String => "UI Volume";

		public override double Get(Args args)
		{
			return Singleton<AudioManager>.Instance.Volume.UI;
		}

		public override double Get(GameObject gameObject)
		{
			return Singleton<AudioManager>.Instance.Volume.UI;
		}
	}
}
