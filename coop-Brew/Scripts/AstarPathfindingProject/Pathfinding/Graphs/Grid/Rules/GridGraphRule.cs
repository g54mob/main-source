using Pathfinding.Serialization;

namespace Pathfinding.Graphs.Grid.Rules
{
	[JsonDynamicType]
	[JsonDynamicTypeAlias("Pathfinding.RuleTexture", typeof(RuleTexture))]
	[JsonDynamicTypeAlias("Pathfinding.RuleAnglePenalty", typeof(RuleAnglePenalty))]
	[JsonDynamicTypeAlias("Pathfinding.RuleElevationPenalty", typeof(RuleElevationPenalty))]
	[JsonDynamicTypeAlias("Pathfinding.RulePerLayerModifications", typeof(RulePerLayerModifications))]
	public abstract class GridGraphRule
	{
		public enum Pass
		{
			BeforeCollision = 0,
			BeforeConnections = 1,
			AfterConnections = 2,
			AfterErosion = 3,
			PostProcess = 4,
			AfterApplied = 5
		}

		[JsonMember]
		public bool enabled;

		private int dirty;

		public virtual int Hash => 0;

		public virtual void SetDirty()
		{
		}

		public virtual void DisposeUnmanagedData()
		{
		}

		public virtual void Register(GridGraphRules rules)
		{
		}
	}
}
