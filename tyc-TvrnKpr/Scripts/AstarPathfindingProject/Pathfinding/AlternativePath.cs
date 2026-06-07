using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	[AddComponentMenu("Pathfinding/Modifiers/Alternative Path Modifier")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/alternativepath.html")]
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
