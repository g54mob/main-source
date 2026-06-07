using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Volume Master")]
	[Category("Audio/Volume Master")]
	[Image(typeof(IconVolume), ColorTheme.Type.Blue)]
	[Description("The Master volume value. Ranges between 0 and 1")]
	[Keywords(new string[] { "Audio", "Sound" })]
	public class GetDecimalVolumeMaster : PropertyTypeGetDecimal
	{
		public override string String => "Master Volume";

		public override double Get(Args args)
		{
			return Singleton<AudioManager>.Instance.Volume.Master;
		}

		public override double Get(GameObject gameObject)
		{
			return Singleton<AudioManager>.Instance.Volume.Master;
		}
	}
}
