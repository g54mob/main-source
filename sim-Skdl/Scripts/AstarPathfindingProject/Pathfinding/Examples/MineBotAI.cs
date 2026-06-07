using System;
using UnityEngine;

namespace Pathfinding.Examples
{
	[RequireComponent(typeof(Seeker))]
	[Obsolete("This script has been replaced by Pathfinding.Examples.MineBotAnimation. Any uses of this script in the Unity editor will be automatically replaced by one AIPath component and one MineBotAnimation component.")]
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_mine_bot_a_i.php")]
	public class MineBotAI : AIPath
	{
		public Animation anim;

		public float sleepVelocity;

		public float animationSpeed;

		public GameObject endOfPathEffect;
	}
}
