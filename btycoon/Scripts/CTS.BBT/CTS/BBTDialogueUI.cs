using System.Collections.Generic;
using PixelCrushers.DialogueSystem;

namespace CTS
{
	public class BBTDialogueUI : StandardDialogueUI
	{
		public override void Open()
		{
			Conversation conversation = DialogueManager.MasterDatabase.GetConversation(DialogueManager.lastConversationStarted);
			if (conversation != null)
			{
				List<DialogueActor> list = new List<DialogueActor>();
				list.Add(DialogueActor.GetDialogueActorComponent(DialogueManager.currentActor));
				list.Add(DialogueActor.GetDialogueActorComponent(DialogueManager.currentConversant));
				for (int i = 0; i < conversation.dialogueEntries.Count; i++)
				{
					DialogueActor dialogueActorFromID = GetDialogueActorFromID(conversation.dialogueEntries[i].ActorID);
					if (!list.Contains(dialogueActorFromID))
					{
						list.Add(dialogueActorFromID);
					}
				}
				SetPanelToUse(list, conversation.LookupBool("Is a dialogue"));
			}
			base.Open();
		}

		private void SetPanelToUse(List<DialogueActor> actors, bool isDialogue)
		{
			foreach (DialogueActor actor in actors)
			{
				if (actor != null)
				{
					actor.standardDialogueUISettings.subtitlePanelNumber = ((!isDialogue) ? SubtitlePanelNumber.Panel1 : SubtitlePanelNumber.Default);
				}
			}
		}

		private DialogueActor GetDialogueActorFromID(int actorID)
		{
			return DialogueActor.GetDialogueActorComponent(CharacterInfo.GetRegisteredActorTransform(DialogueManager.masterDatabase.GetActor(actorID).Name));
		}
	}
}
