using UnityEngine;

namespace Gh.Tk.Story.Conversations
{
	public class ConversationAnimationNode : ConversationNode
	{
		[Header("preset animation")]
		[DropDownChoice(typeof(StoryHelper), "GetConversationAnimationPresets")]
		public string animationPreset;

		[DropDownChoice(typeof(StoryHelper), "GetConversationAnimationPresets")]
		public string[] animationPresets;

		public bool suspendAutomaticReaction;

		public bool speakerShouldLookStraight;

		public bool listenersShouldLookStraight;

		public bool immediateReactions;

		[DropDownChoice(typeof(StoryHelper), "GetSpawnableItemsForConversations")]
		public string[] spawnableItems;

		[Header("icon")]
		[DropDownChoice(typeof(StoryHelper), "GetIconsAndIconPresets")]
		public string icon;

		[DropDownChoice(typeof(StoryHelper), "GetIconsAndIconPresets")]
		public string[] icons;

		public virtual (EmotionalState, string, bool) GetAnimationSetting()
		{
			return default((EmotionalState, string, bool));
		}

		private string GetSelectedIconName()
		{
			return null;
		}

		public string GetIcon(Actor actor)
		{
			return null;
		}
	}
}
