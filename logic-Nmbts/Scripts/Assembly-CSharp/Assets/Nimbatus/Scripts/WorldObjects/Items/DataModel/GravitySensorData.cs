using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class GravitySensorData : SensorPartData
	{
		public int Tolerance { get; set; }

		public ESensorDirectionTarget DirectionTarget { get; set; }

		public ESensorDirectionTarget DirectionTargetFallback { get; set; }
	}
}
