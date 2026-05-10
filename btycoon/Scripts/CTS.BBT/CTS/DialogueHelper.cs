using System;
using System.Collections;
using CTS.Core;
using CTS.Core.Utilities;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public static class DialogueHelper
	{
		public static IEnumerator DialogueCoroutine(string dialogue, RewardDataBase reward = null)
		{
			yield return DialogueRoutine(dialogue);
			yield return RewardRoutine(reward);
		}

		public static IEnumerator DialogueCoroutine(string dialogue, params RewardDataBase[] reward)
		{
			yield return DialogueRoutine(dialogue);
			foreach (RewardDataBase reward2 in reward)
			{
				yield return RewardRoutine(reward2);
			}
		}

		public static IEnumerator MessageRoutine(IUIMessage[] messages)
		{
			foreach (IUIMessage message in messages)
			{
				yield return MessageRoutine(message);
			}
		}

		public static IEnumerator MessageRoutine(IUIMessage message)
		{
			if (!message.EqualsNull())
			{
				UIMessage messageManager = CTSSingleton<UIMessage>.Instance;
				Guid id = messageManager.ShowMessage(message);
				while (messageManager.IsPlaying(id))
				{
					yield return null;
				}
			}
		}

		private static IEnumerator DialogueRoutine(string dialogue)
		{
			bool _conversationEnded;
			if (!(dialogue == ""))
			{
				_conversationEnded = false;
				StartConversation(dialogue);
				DialogueManager.instance.conversationEnded += OnConversationEnded;
				yield return new WaitUntil(() => _conversationEnded);
			}
			void OnConversationEnded(Transform actor)
			{
				DialogueManager.instance.conversationEnded -= OnConversationEnded;
				_conversationEnded = true;
			}
		}

		public static IEnumerator RewardRoutine(RewardDataBase reward)
		{
			if ((bool)reward)
			{
				LastDialogueHelper.EDialogueScore lastDialogueScore = LastDialogueHelper.LastDialogueScore;
				Guid message = reward.ShowMessage(lastDialogueScore);
				UIMessage messageManager = CTSSingleton<UIMessage>.Instance;
				while (messageManager.IsPlaying(message))
				{
					yield return null;
				}
			}
		}

		public static void StartConversation(string dialogue)
		{
			if (!(dialogue == ""))
			{
				DialogueManager.StopAllConversations();
				DialogueManager.StartConversation(dialogue);
			}
		}

		public static void StartFeedback(string dialogue)
		{
			if (!(dialogue == "") && (!MonoSingleton<ConstructionSystem>.Instance || MonoSingleton<ConstructionSystem>.Instance.CurrentMode == EConstructionMode.None))
			{
				DialogueManager.StopAllConversations();
				DialogueManager.StartConversation(dialogue);
			}
		}

		public static T TryConvertEnum<T>(string value) where T : struct
		{
			Enum.TryParse<T>(value.Replace(" ", ""), out var result);
			return result;
		}
	}
}
