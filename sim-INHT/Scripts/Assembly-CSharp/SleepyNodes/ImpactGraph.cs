using System;
using System.Collections.Generic;
using UnityEngine;

namespace SleepyNodes
{
	[CreateAssetMenu(fileName = "ImpactGraph_", menuName = "Graphs/Impact Graph")]
	public class ImpactGraph : StateGraph
	{
		public override List<Type> NodeRestriction => null;

		public override List<Type> NodeTypeExludes => null;

		public virtual void ResetNodes()
		{
		}

		public List<MapEntity> StartImpact(ShellDefinition shell, Vector2 impactLocation)
		{
			return null;
		}

		public override void Run()
		{
		}
	}
}
