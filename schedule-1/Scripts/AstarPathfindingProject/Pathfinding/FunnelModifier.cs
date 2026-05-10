using System;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	[AddComponentMenu("Pathfinding/Modifiers/Funnel")]
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_funnel_modifier.php")]
	public class FunnelModifier : MonoModifier
	{
		public bool unwrap;

		public bool splitAtEveryPortal;

		public override int Order => 0;

		public override void Apply(Path p)
		{
		}
	}
}
