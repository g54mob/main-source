using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Align")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-align.html")]
	public sealed class AIMAlign : AIMSteeringBehaviour
	{
		[Tooltip("The 'ResultDirection' matches with the orientation of this game object.")]
		public GameObject Target;

		[Tooltip("The target position used by the agent to move towards, therefore, the 'Target' must be 'null'.")]
		public Vector3 TargetRotation;

		[Tooltip("Allows to specify the settings of this behaviour.")]
		public Align Align = new Align();

		[Tag]
		[SerializeField]
		private string targetTag = "Untagged";

		public override SteeringBehaviour SteeringBehaviour => Align;

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
				PerceptBehaviour.Percepts[0].Rotation = Quaternion.Euler(TargetRotation);
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
