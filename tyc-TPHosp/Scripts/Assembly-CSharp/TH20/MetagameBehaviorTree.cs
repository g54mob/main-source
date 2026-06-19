using BehaviorDesigner.Runtime;
using UnityEngine;

namespace TH20
{
	[AddComponentMenu("TH20/Metagame Behavior Tree")]
	public class MetagameBehaviorTree : BehaviorTree
	{
		public Metagame Metagame { get; set; }

		public MetagameMap MetagameMap { get; set; }
	}
}
