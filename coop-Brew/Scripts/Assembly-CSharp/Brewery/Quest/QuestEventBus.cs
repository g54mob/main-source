using System;
using System.Runtime.CompilerServices;

namespace Brewery.Quest
{
	public static class QuestEventBus
	{
		public static event Action<QuestEventType, string> OnQuestEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<QuestEventType, string, ulong> OnQuestEventWithPlayer
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void TriggerEvent(QuestEventType type, string context = "")
		{
		}

		public static void TriggerEventWithPlayer(QuestEventType type, string context, ulong triggeringClientId)
		{
		}

		public static void ClearListeners()
		{
		}
	}
}
