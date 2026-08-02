using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Orbit")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-orbit.html")]
	public sealed class AIMOrbit : AIMSteeringBehaviour
	{
		[Tooltip(" Determines the center of the orbit.")]
		public GameObject Target;

		[Tooltip("The target position used by the agent to move towards, therefore, the 'Target' must be 'null'.")]
		public Vector3 TargetPosition;

		[Tooltip("Allows to specify the settings of this behaviour.")]
		public Orbit Orbit = new Orbit();

		[SerializeField]
		private CircleGizmo orbitGizmo = new CircleGizmo();

		[SerializeField]
		private CircleGizmo deviationGizmo = new CircleGizmo();

		[SerializeField]
		private SphereGizmo targetGizmo = new SphereGizmo();

		[Tag]
		[SerializeField]
		private string targetTag = "Untagged";

		public override SteeringBehaviour SteeringBehaviour => Orbit;

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
			Quaternion rotation = Quaternion.identity;
			if (Orbit.Plane == Orbit.PlaneType.PlaneXZ)
			{
				rotation = Quaternion.Euler(90f, 0f, 0f);
			}
			if (Orbit.Plane == Orbit.PlaneType.PlaneYZ)
			{
				rotation = Quaternion.Euler(0f, 90f, 0f);
			}
			if (orbitGizmo.Enabled)
			{
				orbitGizmo.Draw(center, rotation, Orbit.Radius);
			}
			if (deviationGizmo.Enabled)
			{
				deviationGizmo.Draw(center, rotation, Orbit.Radius + Orbit.MaxDeviation);
				deviationGizmo.Draw(center, rotation, Orbit.Radius - Orbit.MinDeviation);
			}
			if (targetGizmo.Enabled)
			{
				targetGizmo.Draw(Orbit.TargetPosition);
			}
		}

		protected override void Reset()
		{
			base.Reset();
			deviationGizmo.Color = Colors.Yellow;
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
