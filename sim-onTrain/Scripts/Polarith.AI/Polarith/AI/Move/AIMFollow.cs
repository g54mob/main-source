using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Follow")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-follow.html")]
	public sealed class AIMFollow : AIMSteeringBehaviour
	{
		[Tooltip("The target game object used by the agent to move towards.")]
		public GameObject Target;

		[Tooltip("The target position used by the agent to move towards, therefore, the 'Target' must be 'null'.")]
		public Vector3 TargetPosition;

		[Tooltip("Allows to specify the settings of this behaviour.")]
		public Follow Follow = new Follow();

		[Tag]
		[SerializeField]
		private string targetTag = "Untagged";

		public override SteeringBehaviour SteeringBehaviour => Follow;

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
