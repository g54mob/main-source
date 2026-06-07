using System.Collections.Generic;
using Gh.Tk.Story.Requirements;
using UnityEngine;
using UnityEngine.Serialization;
using XNode;

namespace Gh.Tk.Story.Structure
{
	[NodeWidth(300)]
	[NodeTint("#18786e")]
	public class RandomStoryStartNode : StartNode, IRequirementProvider, IStoryNodeHasComplexity
	{
		[Header("Random Story Settings")]
		[FormerlySerializedAs("isRepeatable")]
		public StoryRepeatStrategy repeatStrategy;

		public StoryChaosInclusion chaosInclusion;

		public GameLevel level;

		public StoryEffect storyEffect;

		public StoryComplexity complexityValue;

		[Tooltip("if set, stories of the same group will share a cooldown and not trigger one after the other.\nAdd new ids in the Story/StoryHelperReference assets")]
		[DropDownChoice(typeof(StoryHelper), "GetRandomStoryGroupIds")]
		public string groupId;

		[Range(1f, 200f)]
		[Tooltip("Note: mini stories are automatically more likely to spawn than major stories and multiply with this weighting")]
		public int randomWeighting;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection requirements;

		public StoryComplexity StoryComplexity => default(StoryComplexity);

		public override bool CanTrigger()
		{
			return false;
		}

		public IEnumerable<RequirementNode> GetRequirements()
		{
			return null;
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		public float GetSpawnWeighting()
		{
			return 0f;
		}
	}
}
