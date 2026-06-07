using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Volume Ambient")]
	[Category("Audio/Volume Ambient")]
	[Image(typeof(IconVolume), ColorTheme.Type.Green)]
	[Description("The Ambient volume value. Ranges between 0 and 1")]
	public class SetNumberVolumeAmbient : PropertyTypeSetNumber
	{
		public override string String => "Ambient Volume";

		public override void Set(double value, Args args)
		{
			Singleton<AudioManager>.Instance.Volume.Ambient = (float)value;
		}

		public override double Get(Args args)
		{
			return Singleton<AudioManager>.Instance.Volume.Ambient;
		}
	}
}
