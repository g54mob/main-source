using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class AudioPartData : BindableDronePartData
	{
		public int Volume;

		public int Pitch;

		public ESoundEffect SoundEffect;

		public ELoopMode LoopMode { get; set; }

		public float SpatialBlend { get; set; }
	}
}
