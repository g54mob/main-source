using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	public abstract class AIMRadiusSteeringBehaviour : AIMSteeringBehaviour
	{
		[Tooltip("Sets up the visualization of the inner radius.")]
		[SerializeField]
		protected WireSphereGizmo innerRadiusGizmo = new WireSphereGizmo();

		[Tooltip("Sets up the visualization of the outer radius.")]
		[SerializeField]
		protected WireSphereGizmo outerRadiusGizmo = new WireSphereGizmo();

		[Tooltip("Sets up the visualization of the inner radius for planar sensor shapes.")]
		[SerializeField]
		protected CircleGizmo innerCircleGizmo = new CircleGizmo();

		[Tooltip("Sets up the visualization of the outer radius for planar sensor shapes.")]
		[SerializeField]
		protected CircleGizmo outerCircleGizmo = new CircleGizmo();

		[SerializeField]
		[HideInInspector]
		private bool radiusSteeringFoldout = true;

		public abstract RadiusSteeringBehaviour RadiusSteeringBehaviour { get; }

		public override SteeringBehaviour SteeringBehaviour => RadiusSteeringBehaviour;

		public AIMRadiusSteeringBehaviour()
		{
			innerRadiusGizmo.Color = new Color(0.59607846f, 1f, 29f / 51f);
		}

		protected override void OnDrawGizmos()
		{
			base.OnDrawGizmos();
			innerCircleGizmo.Color = innerRadiusGizmo.Color;
			outerCircleGizmo.Color = outerRadiusGizmo.Color;
			if (!(aimContext != null) || !(aimContext.Sensor != null))
			{
				return;
			}
			float num = 0f;
			Vector3 vector = Vector3.zero;
			if (innerRadiusGizmo.Enabled || outerRadiusGizmo.Enabled)
			{
				if (SteeringBehaviour.Prediction == PredictionType.PredictionMagnitude)
				{
					num = SteeringBehaviour.PredictionMagnitude;
				}
				if (SteeringBehaviour.Prediction == PredictionType.VelocityMagnitude)
				{
					num = SteeringBehaviour.Self.Velocity.magnitude;
				}
				vector = SteeringBehaviour.Self.Velocity.normalized * num;
			}
			if (innerRadiusGizmo.Enabled)
			{
				if (aimContext.Sensor is AIMSpatialSensor)
				{
					innerRadiusGizmo.Draw(base.gameObject.transform.position + vector, RadiusSteeringBehaviour.InnerRadius);
				}
				else
				{
					innerCircleGizmo.Draw(base.gameObject.transform.position + vector, base.transform.rotation * aimContext.Sensor.Sensor.Rotation, RadiusSteeringBehaviour.InnerRadius);
				}
			}
			if (outerRadiusGizmo.Enabled)
			{
				if (aimContext.Sensor is AIMSpatialSensor)
				{
					outerRadiusGizmo.Draw(base.gameObject.transform.position + vector, RadiusSteeringBehaviour.OuterRadius);
				}
				else
				{
					outerCircleGizmo.Draw(base.gameObject.transform.position + vector, base.transform.rotation * aimContext.Sensor.Sensor.Rotation, RadiusSteeringBehaviour.OuterRadius);
				}
			}
		}
	}
}
