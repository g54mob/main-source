using System;
using PixelCrushers.DialogueSystem;
using Restory.Data.NPCs;
using Restory.Gameplay.NPCs;
using Restory.Utils;
using Zenject;

namespace Restory.Gameplay.Dialogue
{
	public class DialogueNpcEmotionsPlayerService : IInitializable, IDisposable
	{
		private readonly NpcServiceMain npcServiceMain;

		private readonly DialogueSystemEvents dialogueSystemEvents;

		private readonly NpcEmotionInfo defaultEmotion;

		private readonly DialogueNpcSFX dialogueNpcSfx;

		[Inject]
		private DialogueNpcEmotionsPlayerService(DialogueSystemEvents dialogueSystemEvents, NpcServiceMain npcServiceMain, DialogueNpcSFX dialogueNpcSfx, NpcEmotionInfo defaultEmotion)
		{
			this.dialogueNpcSfx = dialogueNpcSfx;
			this.defaultEmotion = defaultEmotion;
			this.dialogueSystemEvents = dialogueSystemEvents;
			this.npcServiceMain = npcServiceMain;
		}

		public void Initialize()
		{
			dialogueSystemEvents.conversationEvents.onConversationLine.AddListener(ResolveConversationLineStarted);
			npcServiceMain.OnBeforeNpcStartedMovingToExit += ResolveNpcStartedLeaving;
		}

		public void Dispose()
		{
			if ((bool)dialogueSystemEvents)
			{
				dialogueSystemEvents.conversationEvents.onConversationLine.RemoveListener(ResolveConversationLineStarted);
			}
			if (npcServiceMain.MonoShellExists())
			{
				npcServiceMain.OnBeforeNpcStartedMovingToExit -= ResolveNpcStartedLeaving;
			}
		}

		private void ResolveConversationLineStarted(Subtitle subtitle)
		{
			if (!subtitle.speakerInfo.isPlayer && !string.IsNullOrEmpty(subtitle.dialogueEntry.DialogueText) && npcServiceMain.CurrentNpc is StoryNpcInfo storyNpcInfo && storyNpcInfo.TryToGetEmotionDataByInfo(defaultEmotion, out var emotionData))
			{
				dialogueNpcSfx.PlayNpcSound(emotionData);
			}
		}

		private void ResolveNpcStartedLeaving()
		{
			dialogueNpcSfx.StopCurrentNpcSound();
		}
	}
}
