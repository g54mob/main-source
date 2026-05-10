using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	[AddComponentMenu("Pathfinding/Modifiers/Alternative Path")]
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_alternative_path.php")]
	public class AlternativePath : MonoModifier
	{
		public int penalty;

		public int randomStep;

		private List<GraphNode> prevNodes;

		private int prevPenalty;

		private readonly System.Random rnd;

		private bool destroyed;

		public override int Order => 0;

		public override void Apply(Path p)
		{
		}

		protected void OnDestroy()
		{
		}

		private void ClearOnDestroy()
		{
		}

		private void InversePrevious()
		{
		}

		private void ApplyNow(List<GraphNode> nodes)
		{
		}
	}
}
