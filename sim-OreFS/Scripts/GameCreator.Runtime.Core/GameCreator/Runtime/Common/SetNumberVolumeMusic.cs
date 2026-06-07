using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Volume Music")]
	[Category("Audio/Volume Music")]
	[Image(typeof(IconVolume), ColorTheme.Type.Green)]
	[Description("The Music volume value. Ranges between 0 and 1")]
	public class SetNumberVolumeMusic : PropertyTypeSetNumber
	{
		public override string String => "Music Volume";

		public override void Set(double value, Args args)
		{
			Singleton<AudioManager>.Instance.Volume.Music = (float)value;
		}

		public override double Get(Args args)
		{
			return Singleton<AudioManager>.Instance.Volume.Music;
		}
	}
}
