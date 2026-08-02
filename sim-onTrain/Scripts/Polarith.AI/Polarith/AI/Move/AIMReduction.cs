using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Processing/AIM Reduction")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-reduction.html")]
	public sealed class AIMReduction : AIMPerceptBehaviour<SteeringPercept>
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public Reduction Reduction = new Reduction();

		[Tooltip("Sets up the visualization of the velocity.")]
		[SerializeField]
		private VelocityGizmo velocityGizmo = new VelocityGizmo();

		[Tooltip("Sets up the visualization of the outer radius.")]
		[SerializeField]
		private CircleGizmo maxDistanceGizmo = new CircleGizmo();

		public override PerceptBehaviour<SteeringPercept> PerceptBehaviour => Reduction;

		public override bool ThreadSafe => true;

		public override void PrepareEvaluation()
		{
			base.PrepareEvaluation();
			if (Reduction.TargetObjective < 0 || Reduction.TargetObjective >= context.Problem.ObjectiveCount)
			{
				Debug.LogWarning("(" + typeof(AIMReduction).Name + ") " + base.gameObject.name + ": the set target objective with value '" + Reduction.TargetObjective + "' is not valid");
			}
		}

		protected override void Reset()
		{
			Order = 1000;
			base.Reset();
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			CheckFirstAndCentralOrder(typeof(AIMReduction));
		}

		private void OnDrawGizmos()
		{
			if (aimContext != null && aimContext.Sensor != null)
			{
				float predictionMagnitude = 0f;
				if (Reduction.Prediction == PredictionType.PredictionMagnitude)
				{
					predictionMagnitude = Reduction.PredictionMagnitude;
				}
				if (Reduction.Prediction == PredictionType.VelocityMagnitude)
				{
					predictionMagnitude = Reduction.Self.Velocity.magnitude;
				}
				velocityGizmo.Draw(base.transform.position, Reduction.Self.Velocity.normalized, Reduction.Self.Velocity.magnitude, predictionMagnitude);
				if (maxDistanceGizmo.Enabled)
				{
					maxDistanceGizmo.Draw(base.gameObject.transform.position, base.transform.rotation * aimContext.Sensor.Sensor.Rotation, Reduction.MaxDistance);
				}
			}
		}
	}
}
