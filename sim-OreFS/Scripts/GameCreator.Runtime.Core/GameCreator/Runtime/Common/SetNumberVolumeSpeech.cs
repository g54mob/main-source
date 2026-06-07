using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Volume Speech")]
	[Category("Audio/Volume Speech")]
	[Image(typeof(IconVolume), ColorTheme.Type.Green)]
	[Description("The Speech volume value. Ranges between 0 and 1")]
	public class SetNumberVolumeSpeech : PropertyTypeSetNumber
	{
		public override string String => "Speech Volume";

		public override void Set(double value, Args args)
		{
			Singleton<AudioManager>.Instance.Volume.Speech = (float)value;
		}

		public override double Get(Args args)
		{
			return Singleton<AudioManager>.Instance.Volume.Speech;
		}
	}
}
