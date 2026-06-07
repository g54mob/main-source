using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Volume SFX")]
	[Category("Audio/Volume SFX")]
	[Image(typeof(IconVolume), ColorTheme.Type.Green)]
	[Description("The SFX volume value. Ranges between 0 and 1")]
	public class SetNumberVolumeSFX : PropertyTypeSetNumber
	{
		public override string String => "SFX Volume";

		public override void Set(double value, Args args)
		{
			Singleton<AudioManager>.Instance.Volume.SoundEffects = (float)value;
		}

		public override double Get(Args args)
		{
			return Singleton<AudioManager>.Instance.Volume.SoundEffects;
		}
	}
}
