using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Volume UI")]
	[Category("Audio/Volume UI")]
	[Image(typeof(IconVolume), ColorTheme.Type.Green)]
	[Description("The UI volume value. Ranges between 0 and 1")]
	public class SetNumberVolumeUI : PropertyTypeSetNumber
	{
		public override string String => "UI Volume";

		public override void Set(double value, Args args)
		{
			Singleton<AudioManager>.Instance.Volume.UI = (float)value;
		}

		public override double Get(Args args)
		{
			return Singleton<AudioManager>.Instance.Volume.UI;
		}
	}
}
