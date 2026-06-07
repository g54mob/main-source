using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Volume Master")]
	[Category("Audio/Volume Master")]
	[Image(typeof(IconVolume), ColorTheme.Type.Blue)]
	[Description("The Master volume value. Ranges between 0 and 1")]
	public class SetNumberVolumeMaster : PropertyTypeSetNumber
	{
		public override string String => "Master Volume";

		public override void Set(double value, Args args)
		{
			Singleton<AudioManager>.Instance.Volume.Master = (float)value;
		}

		public override double Get(Args args)
		{
			return Singleton<AudioManager>.Instance.Volume.Master;
		}
	}
}
