using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class ConversationEndUIMessage : MonoBehaviour
	{
		private void OnDisable()
		{
			if ((bool)DialogueManager.instance)
			{
				DialogueManager.instance.conversationEnded -= OnConversationEnded;
			}
		}

		private void OnEnable()
		{
			if ((bool)DialogueManager.instance)
			{
				DialogueManager.instance.conversationEnded += OnConversationEnded;
			}
		}

		private void OnConversationEnded(Transform t)
		{
			if (LastDialogueHelper.LastDialogueHaveRewardDescription)
			{
				_ = LastDialogueHelper.LastDialogueRewardNameEntryName;
				switch (LastDialogueHelper.LastDialogueScore)
				{
				case LastDialogueHelper.EDialogueScore.Positive:
					_ = LastDialogueHelper.LastDialogueRewardPositiveEntryName;
					break;
				case LastDialogueHelper.EDialogueScore.Negative:
					_ = LastDialogueHelper.LastDialogueRewardNegativeEntryName;
					break;
				case LastDialogueHelper.EDialogueScore.Neutral:
					_ = LastDialogueHelper.LastDialogueRewardNeutralEntryName;
					break;
				}
			}
		}
	}
}
