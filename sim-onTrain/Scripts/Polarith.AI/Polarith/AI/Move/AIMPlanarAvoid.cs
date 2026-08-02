using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Planar Avoid")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-planaravoid.html")]
	public sealed class AIMPlanarAvoid : AIMRadiusSteeringBehaviour
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public PlanarAvoid PlanarAvoid = new PlanarAvoid();

		public override RadiusSteeringBehaviour RadiusSteeringBehaviour => PlanarAvoid;

		public override bool ThreadSafe => true;

		protected override void Reset()
		{
			base.Reset();
			if (aimContext.Sensor != null)
			{
				if (PlanarAvoid.UseSensorProjection)
				{
					PlanarAvoid.Up = ((aimContext.Sensor.Sensor.ProjectionMode == VectorProjectionType.PlaneXZ) ? Vector3.up : Vector3.forward);
				}
				else
				{
					PlanarAvoid.Up = ((PlanarAvoid.VectorProjection == VectorProjectionType.PlaneXZ) ? Vector3.up : Vector3.forward);
				}
			}
		}
	}
}
