using Gh.Tk.Story.Config;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.Serialization;
using XNode;

namespace Gh.Tk.Story.Actions
{
	[InitializeOnGameStarted]
	public class AddPatronGroupRequestActionNode : ConnectedStoryNode, IPatronPawnModifyingConfig, IPatronPawnModifyingFilterConfig
	{
		[Range(0f, 23f)]
		public int targetHour;

		public int targetHourMargin;

		public int offsetInDays;

		[TextArea(1, 2)]
		[StoryNodeTranslateFieldContent("Patron group description", "Node")]
		public string description;

		[TextArea(1, 2)]
		[StoryNodeTranslateFieldContent("Patron group mechanical effect description", "Node")]
		public string effectDescription;

		public bool isVip;

		[Range(1f, 5f)]
		public int tier;

		[DropDownChoice(typeof(StoryHelper), "GetRaces")]
		public string race;

		[Range(1f, 20f)]
		public int pawnCount;

		public int pawnCountMargin;

		[FormerlySerializedAs("allowMovingByXHours")]
		[Range(0f, 6f)]
		[Header("Optional Group Settings")]
		[Tooltip("If set, this is how many hours the player can move the group around from the original position")]
		public int hourMargin;

		public int goldBonus;

		[Tooltip("used in challenges to track specific groups against story flag goals")]
		[DropDownChoice(typeof(StoryHelper), "GetAllStoryFlags")]
		public string storyFlagHint;

		public GameObject[] models;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection onGroupSatisfied;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection onGroupNotSatisfied;

		public int minTier => 0;

		public int maxTier => 0;

		public int percentageAffected => 0;

		public bool deletePawns => false;

		[field: SerializeField]
		[field: Header("Behaviour Config")]
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
		public string[] conversationThemes { get; set; }

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void OnGroupLeft(bool wasGroupSatisfied, ActiveStory story)
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		private bool NeedToWaitForGroupResult()
		{
			return false;
		}

		private void OnValidate()
		{
		}
	}
}
