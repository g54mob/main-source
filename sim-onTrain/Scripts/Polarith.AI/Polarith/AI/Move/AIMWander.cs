using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Wander")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-wander.html")]
	public sealed class AIMWander : AIMSteeringBehaviour
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public Wander Wander = new Wander();

		private static GameObject wanderTarget;

		public override SteeringBehaviour SteeringBehaviour => Wander;

		public override bool ThreadSafe => true;

		public override void PrepareEvaluation()
		{
			if (FilteredEnvironments.Count != 0)
			{
				FilteredEnvironments.Clear();
			}
			if (GameObjects.Count == 1)
			{
				GameObjects[0] = wanderTarget;
			}
			else
			{
				GameObjects.Clear();
				GameObjects.Add(wanderTarget);
			}
			base.PrepareEvaluation();
		}

		protected override void Awake()
		{
			base.Awake();
			if (wanderTarget == null)
			{
				wanderTarget = new GameObject("WanderTarget");
				wanderTarget.hideFlags = HideFlags.HideInHierarchy;
			}
			if (aimContext.Sensor.Sensor is PlanarSensor planarSensor)
			{
				Wander.SetPlanarMappingType(Wander.PlanarMappingType, planarSensor.PlanarOrientation);
			}
			else
			{
				Wander.SetPlanarMappingType(PlanarMappingType.None);
			}
		}
	}
}
