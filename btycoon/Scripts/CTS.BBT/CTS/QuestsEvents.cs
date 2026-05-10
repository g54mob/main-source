using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class QuestsEvents : MonoBehaviour
	{
		public static event Action<string, QuestState> QuestStateChanged;

		public void OnQuestStateChanged(string questName)
		{
			QuestsEvents.QuestStateChanged?.Invoke(questName, QuestLog.GetQuestState(questName));
		}
	}
}
