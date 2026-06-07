using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Thruster;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class VtolThrusterData : BindableDronePartData
	{
		public ESensorDirectionTarget DirectionTarget { get; set; }

		public EThrusterRotationMode RotationMode { get; set; }

		public ESensorDirectionTarget DirectionTargetFallback { get; set; }
	}
}
