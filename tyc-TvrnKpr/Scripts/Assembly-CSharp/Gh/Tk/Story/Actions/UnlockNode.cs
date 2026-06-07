using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class UnlockNode : ConnectedStoryNode
	{
		public bool MarkAsSeen;

		[Header("Props")]
		[DropDownChoice(typeof(StoryHelper), "GetAllPropOptionsWithoutAnyX")]
		public string[] propIds;

		[DropDownChoice(typeof(StoryHelper), "GetAllDecoProps")]
		public string[] decoProps;

		[Tooltip("If true the props/decoProps will not be unlocked immediately but added to the waiting to be unlocked list")]
		public bool addPropsToWaitingToBeUnlockedList;

		[Header("Other stuff")]
		[DropDownChoice(typeof(StoryHelper), "GetAllZones")]
		public string[] zones;

		[DropDownChoice(typeof(StoryHelper), "GetAllScheduleItems")]
		public string[] scheduleItems;

		[DropDownChoice(typeof(StoryHelper), "GetAllRatingCategories")]
		public string[] ratingCategories;

		[DropDownChoice(typeof(StoryHelper), "GetAllWeapons")]
		public string[] weapons;

		[DropDownChoice(typeof(StoryHelper), "GetAllCraftProcessOptions")]
		public string[] craftProcesses;

		[DropDownChoice(typeof(StoryHelper), "GetAllUnlockableTraits")]
		public string[] traits;

		[DropDownChoice(typeof(StoryHelper), "GetAllUnlockableGameItemTemplateIds")]
		public string[] gameItems;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
