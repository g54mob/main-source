using PixelCrushers.DialogueSystem;

namespace CTS
{
	public static class LastDialogueHelper
	{
		public enum EDialogueScore
		{
			Neutral = 0,
			Positive = 1,
			Negative = 2
		}

		public static EDialogueScore LastDialogueScore
		{
			get
			{
				int asInt = DialogueLua.GetVariable("Dialogue.BonusMalus").asInt;
				if (asInt == 0)
				{
					return EDialogueScore.Neutral;
				}
				if (asInt > 0)
				{
					return EDialogueScore.Positive;
				}
				return EDialogueScore.Negative;
			}
		}

		public static bool LastDialogueAccepted => DialogueLua.GetVariable("Dialogue.Accepted").asBool;

		public static bool LastDialogueHaveRewardDescription => DialogueLua.GetConversationField(DialogueManager.lastConversationID, "Reward Name").asString != "";

		public static string LastDialogueRewardNameEntryName => DialogueManager.GetConversationTitle(DialogueManager.lastConversationID).Replace("/", ".") + ".rewardname";

		public static string LastDialogueRewardPositiveEntryName => DialogueManager.GetConversationTitle(DialogueManager.lastConversationID).Replace("/", ".") + ".rewardpositive";

		public static string LastDialogueRewardNegativeEntryName => DialogueManager.GetConversationTitle(DialogueManager.lastConversationID).Replace("/", ".") + ".rewardnegative";

		public static string LastDialogueRewardNeutralEntryName => DialogueManager.GetConversationTitle(DialogueManager.lastConversationID).Replace("/", ".") + ".rewardneutral";
	}
}
