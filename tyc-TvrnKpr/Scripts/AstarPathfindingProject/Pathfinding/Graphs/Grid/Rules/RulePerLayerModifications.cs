using Pathfinding.Util;

namespace Pathfinding.Graphs.Grid.Rules
{
	[Preserve]
	public class RulePerLayerModifications : GridGraphRule
	{
		public struct PerLayerRule
		{
			public int layer;

			public RuleAction action;

			public int tag;
		}

		public enum RuleAction
		{
			SetTag = 0,
			MakeUnwalkable = 1
		}

		public PerLayerRule[] layerRules;

		private const int SetTagBit = 1073741824;

		public override void Register(GridGraphRules rules)
		{
		}
	}
}
