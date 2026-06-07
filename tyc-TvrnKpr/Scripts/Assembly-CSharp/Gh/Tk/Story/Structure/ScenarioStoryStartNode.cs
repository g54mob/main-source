using UnityEngine;
using UnityEngine.Serialization;
using XNode;

namespace Gh.Tk.Story.Structure
{
	[NodeTint("#4b662b")]
	[NodeWidth(265)]
	public class ScenarioStoryStartNode : StartNode, IStoryNodeHasComplexity
	{
		public GameLevel level;

		[Range(0f, 5f)]
		public float maxTavernStars;

		public StoryComplexity complexity;

		public string scenarioId;

		[StoryNodeTranslateFieldContent("Scenario Name", "Node")]
		public string scenarioName;

		[FormerlySerializedAs("scenarioDescripton")]
		[TextArea(5, 8)]
		[StoryNodeTranslateFieldContent("Scenario Description", "Node")]
		public string scenarioDescription;

		public int gazetteStartingIssueNumber;

		public ScenarioPreset presetData;

		public StoryComplexity StoryComplexity => default(StoryComplexity);

		public override bool CanTrigger()
		{
			return false;
		}

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
