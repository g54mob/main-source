using System;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	[AddComponentMenu("Pathfinding/Modifiers/Funnel Modifier")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/funnelmodifier.html")]
	public class FunnelModifier : MonoModifier
	{
		public enum FunnelQuality
		{
			Medium = 0,
			High = 1
		}

		public FunnelQuality quality;

		public bool splitAtEveryPortal;

		public bool accountForGridPenalties;

		public override int Order => 0;

		public override void Apply(Path p)
		{
		}
	}
}
