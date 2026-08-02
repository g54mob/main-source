using System.Collections.Generic;
using UnityEngine;

namespace Polarith.AI.Move
{
	public abstract class PerceptBehaviour<T> : MoveBehaviour where T : IPercept<GameObject>, new()
	{
		public readonly IList<T> Percepts = new List<T>();

		public abstract T Self { get; set; }
	}
}
