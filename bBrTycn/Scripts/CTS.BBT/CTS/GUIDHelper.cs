using PixelCrushers.DialogueSystem;

namespace CTS
{
	public static class GUIDHelper
	{
		public static string GenerateQuestGUID(string questName)
		{
			return "Quest." + questName.Replace("/", ".");
		}

		public static string GenerateQuestGUID(Item quest)
		{
			return GenerateQuestGUID(quest.Name);
		}

		public static string GenerateQuestIntroGUID(string questName)
		{
			return GenerateQuestGUID(questName) + "_Intro";
		}

		public static string GenerateQuestIntroDescriptionGUID(string questName)
		{
			return GenerateQuestGUID(questName) + "_FailureDescription";
		}

		public static string GenerateActorGUID(Actor actor)
		{
			return "ActorName." + actor.Name.Replace("/", ".");
		}

		public static string GenerateConversationGUID(string conversationTitle)
		{
			return conversationTitle.Replace("/", ".");
		}

		public static string GenerateConversationGUID(Conversation conversation)
		{
			return GenerateConversationGUID(conversation.Title);
		}

		public static string GenerateConversationRewardNameGUID(Conversation conversation)
		{
			return GenerateConversationGUID(conversation) + ".rewardname";
		}

		public static string GenerateConversationRewardPositiveGUID(Conversation conversation)
		{
			return GenerateConversationGUID(conversation) + ".rewardpositive";
		}

		public static string GenerateConversationRewardNeutralGUID(Conversation conversation)
		{
			return GenerateConversationGUID(conversation) + ".rewardneutral";
		}

		public static string GenerateConversationRewardNegativeGUID(Conversation conversation)
		{
			return GenerateConversationGUID(conversation) + ".rewardnegative";
		}

		public static string GenerateConversationEntryGUID(Conversation conversation, DialogueEntry entry)
		{
			return GenerateConversationGUID(conversation) + "." + entry.Title.Replace("/", ".");
		}

		public static string FindTableID(string stringToCheck)
		{
			string result = "";
			if (stringToCheck.Contains("Main"))
			{
				return "MainQuests";
			}
			if (stringToCheck.Contains("Secondary"))
			{
				return "SecondaryQuests";
			}
			if (stringToCheck.Contains("Circumstantial"))
			{
				return "CircumstantialQuests";
			}
			return result;
		}
	}
}
