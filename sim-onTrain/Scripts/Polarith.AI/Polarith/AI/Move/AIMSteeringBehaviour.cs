using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	public abstract class AIMSteeringBehaviour : AIMPerceptBehaviour<SteeringPercept>
	{
		[Tooltip("Sets up the visualization of the velocity.")]
		[SerializeField]
		protected VelocityGizmo velocityGizmo = new VelocityGizmo();

		[SerializeField]
		[HideInInspector]
		private bool steeringFoldout = true;

		public abstract SteeringBehaviour SteeringBehaviour { get; }

		public override PerceptBehaviour<SteeringPercept> PerceptBehaviour => SteeringBehaviour;

		public override void PrepareEvaluation()
		{
			base.PrepareEvaluation();
			if (SteeringBehaviour.TargetObjective < 0 || SteeringBehaviour.TargetObjective >= context.Problem.ObjectiveCount)
			{
				Debug.LogWarning("(" + typeof(AIMSteeringBehaviour).Name + ") " + base.gameObject.name + ": the set target objective with value '" + SteeringBehaviour.TargetObjective + "' is not valid");
			}
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			CheckFirstAndCentralOrder(typeof(AIMSteeringBehaviour));
		}

		protected virtual void OnDrawGizmos()
		{
			if (velocityGizmo.Enabled)
			{
				float predictionMagnitude = 0f;
				if (SteeringBehaviour.Prediction == PredictionType.PredictionMagnitude)
				{
					predictionMagnitude = SteeringBehaviour.PredictionMagnitude;
				}
				if (SteeringBehaviour.Prediction == PredictionType.VelocityMagnitude)
				{
					predictionMagnitude = SteeringBehaviour.Self.Velocity.magnitude;
				}
				velocityGizmo.Draw(base.transform.position, SteeringBehaviour.Self.Velocity.normalized, SteeringBehaviour.Self.Velocity.magnitude, predictionMagnitude);
			}
		}
	}
}
