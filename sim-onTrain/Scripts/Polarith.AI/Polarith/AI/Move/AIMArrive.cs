using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Arrive")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-arrive.html")]
	public sealed class AIMArrive : AIMRadiusSteeringBehaviour
	{
		[Tooltip("The target game object used by the agent to adapt its velocity for.")]
		public GameObject Target;

		[Tooltip("The target position used by the agent to move towards, therefore, the 'Target' must be 'null'.")]
		public Vector3 TargetPosition;

		[Tooltip("Allows to specify the settings of this behaviour.")]
		public Arrive Arrive = new Arrive();

		[Tag]
		[SerializeField]
		private string targetTag = "Untagged";

		public override RadiusSteeringBehaviour RadiusSteeringBehaviour => Arrive;

		public override bool ThreadSafe => true;

		public override void PrepareEvaluation()
		{
			if (FilteredEnvironments.Count != 0)
			{
				FilteredEnvironments.Clear();
			}
			if (GameObjects.Count == 1)
			{
				GameObjects[0] = Target;
			}
			else
			{
				GameObjects.Clear();
				GameObjects.Add(Target);
			}
			base.PrepareEvaluation();
			if (Target == null)
			{
				PerceptBehaviour.Percepts[0].Position = TargetPosition;
				PerceptBehaviour.Percepts[0].Active = true;
				PerceptBehaviour.Percepts[0].Significance = 1f;
			}
		}

		protected override void OnDrawGizmos()
		{
			base.OnDrawGizmos();
			Vector3 center = ((Target == null) ? TargetPosition : Target.transform.position);
			if (outerRadiusGizmo.Enabled)
			{
				if (aimContext.Sensor is AIMSpatialSensor)
				{
					outerRadiusGizmo.Draw(center, Arrive.OuterRadius);
				}
				else
				{
					outerCircleGizmo.Draw(center, base.transform.rotation * aimContext.Sensor.Sensor.Rotation, Arrive.OuterRadius);
				}
			}
			if (innerRadiusGizmo.Enabled)
			{
				if (aimContext.Sensor is AIMSpatialSensor)
				{
					innerRadiusGizmo.Draw(center, Arrive.InnerRadius);
				}
				else
				{
					innerCircleGizmo.Draw(center, base.transform.rotation * aimContext.Sensor.Sensor.Rotation, Arrive.InnerRadius);
				}
			}
		}

		protected override void Reset()
		{
			base.Reset();
			Arrive.ValueWriting = ValueWritingType.Subtraction;
		}

		private void Start()
		{
			if (Target == null && targetTag != "Untagged")
			{
				GameObject gameObject = GameObject.FindGameObjectWithTag(targetTag);
				if (gameObject != null)
				{
					Target = gameObject;
				}
			}
		}
	}
}
