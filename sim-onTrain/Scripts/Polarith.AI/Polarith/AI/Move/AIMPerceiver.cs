using System.Collections.Generic;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[DisallowMultipleComponent]
	public abstract class AIMPerceiver<T> : MonoBehaviour where T : IPercept<GameObject>, new()
	{
		public readonly IDictionary<string, IList<T>> Percepts = new Dictionary<string, IList<T>>();

		[Tooltip("All environment components which should be considered for the extraction of the percept data.")]
		public List<AIMEnvironment> Environments = new List<AIMEnvironment>();

		private readonly List<bool> perceptionStates = new List<bool>();

		private readonly List<AIMEnvironment> oldEnvironments = new List<AIMEnvironment>();

		public virtual void Update()
		{
			for (int i = 0; i < oldEnvironments.Count; i++)
			{
				if (!(oldEnvironments[i] == null))
				{
					int num = Environments.IndexOf(oldEnvironments[i]);
					if (num < 0 || (Environments[num] != null && Environments[num].Label != oldEnvironments[i].Label))
					{
						Percepts.Remove(oldEnvironments[i].Label);
					}
				}
			}
			for (int i = 0; i < Environments.Count; i++)
			{
				if (Environments[i] != null && !Percepts.ContainsKey(Environments[i].Label))
				{
					Percepts.Add(Environments[i].Label, new List<T>());
				}
			}
			Collections.ResizeList(perceptionStates, Environments.Count);
			Collections.ResizeListDefault(oldEnvironments, Environments.Count);
			for (int i = 0; i < oldEnvironments.Count; i++)
			{
				oldEnvironments[i] = Environments[i];
			}
			StartPerceiving();
			for (int i = 0; i < Environments.Count; i++)
			{
				if (Environments[i] != null && Percepts.ContainsKey(Environments[i].Label) && i < perceptionStates.Count && (!Environments[i].Static || !perceptionStates[i]))
				{
					PerceiveEnvironment(Environments[i], Percepts[Environments[i].Label]);
					perceptionStates[i] = true;
				}
			}
		}

		public void PerceiveStatic()
		{
			for (int i = 0; i < perceptionStates.Count; i++)
			{
				perceptionStates[i] = false;
			}
		}

		protected abstract void PerceiveEnvironment(AIMEnvironment environment, IList<T> percepts);

		protected virtual void StartPerceiving()
		{
		}
	}
}
