using System.Collections.Generic;
using Gh.Tk.Story.GameModifiers;
using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Config
{
	public class PatronGroupConfigNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection parent;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection modifyGeneratedPatrons;

		[Range(1f, 5f)]
		public int minTier;

		[Range(1f, 5f)]
		public int maxTier;

		public int minPatrons;

		public int maxPatrons;

		public bool spawnAsGroup;

		public bool isGroupEvent;

		[Range(0f, 24f)]
		public int groupEventTimeRange;

		[StoryNodeTranslateFieldContent("Patron Group Label", "Node")]
		public string patronLabel;

		public bool enableRevealClarity;

		public bool generateFakes;

		public IEnumerable<PatronPopulationData> GeneratePawns(PatronSpawnModifierNode node, int startInHours)
		{
			return null;
		}

		private IEnumerable<PatronPopulationData> GenerateFakes(List<PatronPopulationData> pawnsAdded)
		{
			return null;
		}
	}
}
