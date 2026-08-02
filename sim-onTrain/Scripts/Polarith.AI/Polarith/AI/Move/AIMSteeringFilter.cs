using System.Collections.Generic;
using Polarith.UnityUtils;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Perception/AIM Steering Filter")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-steeringfilter.html")]
	public sealed class AIMSteeringFilter : AIMFilter<SteeringPercept>
	{
		[Tooltip("The input component to get extracted percept data for.")]
		public AIMSteeringPerceiver SteeringPerceiver;

		[Tooltip("If the 'Steering Perceiver' is 'null', this component searches for an appropriate object specified by this tag using Unity's tag system.")]
		[Tag]
		public string ObjectTag = "Untagged";

		[Tooltip("Percepts within this range are made available to the behaviours by, whereby all values smaller than 0 correspond to infinity. If the applied 'Steering Perceiver' uses no spatial structure, a negative value results in no distance check at all.")]
		public float Range = -1f;

		[Tooltip("Visualizes the 'Range' parameter within the scene.")]
		[SerializeField]
		private CircleGizmo rangeGizmo = new CircleGizmo();

		public override AIMPerceiver<SteeringPercept> Perceiver => SteeringPerceiver;

		public override void GetPercepts(IList<string> environments, IList<SteeringPercept> percepts)
		{
			if (SteeringPerceiver == null)
			{
				percepts.Clear();
				return;
			}
			int num = 0;
			for (int i = 0; i < environments.Count; i++)
			{
				if (SteeringPerceiver.Percepts.TryGetValue(environments[i], out var value))
				{
					num += value.Count;
				}
			}
			Collections.ResizeListDefault(percepts, num);
			SteeringPerceiver.GetPerceptsInRange(base.transform.position, Range, environments, percepts);
		}

		protected override void Awake()
		{
			base.Awake();
			if (SteeringPerceiver == null && !(ObjectTag == ""))
			{
				GameObject gameObject = GameObject.FindGameObjectWithTag(ObjectTag);
				if (gameObject != null)
				{
					SteeringPerceiver = gameObject.GetComponent<AIMSteeringPerceiver>();
				}
			}
		}

		private void OnDrawGizmos()
		{
			if (rangeGizmo.Enabled && aimContext != null && aimContext.Sensor != null)
			{
				rangeGizmo.Draw(base.gameObject.transform.position, base.transform.rotation * aimContext.Sensor.Sensor.Rotation, Range);
			}
		}
	}
}
