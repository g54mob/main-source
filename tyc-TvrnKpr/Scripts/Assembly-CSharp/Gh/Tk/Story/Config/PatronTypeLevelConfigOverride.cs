using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Config
{
	public class PatronTypeLevelConfigOverride : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection parent;

		public string patronType;

		[Header("Group Chance")]
		public bool overrideGroupChance;

		public float spawnGroupChanceOverride;
	}
}
