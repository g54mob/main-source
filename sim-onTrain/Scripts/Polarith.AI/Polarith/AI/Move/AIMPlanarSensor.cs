using UnityEngine;

namespace Polarith.AI.Move
{
	[CreateAssetMenu(fileName = "PlanarSensor.asset", menuName = "Polarith AI » Move/Sensors/AIM Planar Sensor", order = 0)]
	[HelpURL("http://docs.polarith.com/ai/component-aim-planarsensor.html")]
	public sealed class AIMPlanarSensor : AIMSensor
	{
		[Tooltip("The serialized sensor data.")]
		[HideInInspector]
		public PlanarSensor PlanarSensor = new PlanarSensor();

		public override Sensor Sensor => PlanarSensor;
	}
}
