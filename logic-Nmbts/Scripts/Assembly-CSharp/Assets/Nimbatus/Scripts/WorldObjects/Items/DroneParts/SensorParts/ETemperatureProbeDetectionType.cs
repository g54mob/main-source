using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	[Serializable]
	[Flags]
	public enum ETemperatureProbeDetectionType
	{
		None = 0,
		OtherObjects = 1,
		DroneParts = 2
	}
}
