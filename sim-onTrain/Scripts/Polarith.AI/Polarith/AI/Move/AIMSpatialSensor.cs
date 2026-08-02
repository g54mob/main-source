using UnityEngine;

namespace Polarith.AI.Move
{
	[CreateAssetMenu(fileName = "SpatialSensor.asset", menuName = "Polarith AI » Move/Sensors/AIM Spatial Sensor", order = 0)]
	public sealed class AIMSpatialSensor : AIMSensor
	{
		[Tooltip("The serialized sensor data.")]
		[HideInInspector]
		public SpatialSensor SpatialSensor = new SpatialSensor();

		public override Sensor Sensor => SpatialSensor;
	}
}
