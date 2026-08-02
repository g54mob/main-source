using System.Collections.Generic;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	public abstract class AIMPerceptBehaviour<T> : AIMBehaviour where T : IPercept<GameObject>, new()
	{
		[Tooltip("All environments to obtain the percepts for. A name correspond to an environment label.")]
		[FilteredEnvironment]
		public List<string> FilteredEnvironments = new List<string>();

		[Tooltip("Allows to specify custom objects which should be processed by this behaviour. This is especially suitable for a few special targeted objects. When the specified objects are needed by multiple behaviours and/or agents, let the agents perceive them via the environment/perceiver/filter pipeline to increase the overall performance.")]
		public List<GameObject> GameObjects = new List<GameObject>();

		private AIMFilter<T> filter;

		public abstract PerceptBehaviour<T> PerceptBehaviour { get; }

		public override MoveBehaviour Behaviour => PerceptBehaviour;

		public override void PrepareEvaluation()
		{
			base.PrepareEvaluation();
			IList<T> percepts = PerceptBehaviour.Percepts;
			if (filter != null)
			{
				filter.GetPercepts(FilteredEnvironments, percepts);
				PerceptBehaviour.Self = filter.Self;
			}
			else
			{
				PerceptBehaviour.Self.Receive(aimContext.SelfObject);
			}
			int num = ((FilteredEnvironments.Count > 0 && filter != null) ? percepts.Count : 0);
			Collections.ResizeList(percepts, num + GameObjects.Count);
			for (int i = 0; i < GameObjects.Count; i++)
			{
				percepts[i + num].Receive(GameObjects[i]);
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			filter = GetComponent<AIMFilter<T>>();
		}
	}
}
