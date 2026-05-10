using System.Collections;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public abstract class StarQuest : Quest
	{
		[SerializeField]
		[Range(0f, 6f)]
		private int _scoreToReward = 6;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _outroConversation;

		[SerializeField]
		private RewardData _outroReward;

		protected override IEnumerator QuestOutroCoroutine()
		{
			yield return DialogueHelper.DialogueCoroutine(_outroConversation, _outroReward);
			CTSSingleton<GameMode>.Instance.LevelInfo.SetScoreInProfile(_scoreToReward);
		}
	}
}
