using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Config
{
	public class PatronModifyPawnsConfigNode : StoryNode, IPatronPawnModifyingConfig, IPatronPawnModifyingFilterConfig
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection parent;

		[field: SerializeField]
		[field: Range(1f, 5f)]
		public int minTier { get; set; }

		[field: SerializeField]
		[field: Range(1f, 5f)]
		public int maxTier { get; set; }

		[field: SerializeField]
		[field: Range(1f, 100f)]
		public int percentageAffected { get; set; }

		[field: SerializeField]
		public bool deletePawns { get; set; }

		[field: SerializeField]
		public bool removeAllNonBasicNeeds { get; set; }

		[field: SerializeField]
		public bool disableImpromptuOptionalNeeds { get; set; }

		[field: SerializeField]
		[field: DropDownChoice(typeof(StoryHelper), "GetAllPatronNeedTypes")]
		public string[] removeNeeds { get; set; }

		[field: SerializeField]
		[field: DropDownChoice(typeof(StoryHelper), "GetAllPatronNeedTypes")]
		public string[] forceNeeds { get; set; }

		[field: SerializeField]
		public SecondaryNeedConfig[] secondaryNeeds { get; set; }

		[field: SerializeField]
		public bool removeReputationRequirements { get; set; }

		[field: SerializeField]
		[field: DropDownChoice(typeof(StoryHelper), "GetPatronTraits")]
		public string[] traits { get; set; }

		[field: SerializeField]
		[field: DropDownChoice(typeof(StoryHelper), "GetConversationThemes")]
		public string[] conversationThemes { get; }
	}
}
