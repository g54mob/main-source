using UnityEngine;

namespace PixelCrushers.DialogueSystem.SpineSupport
{
	public class SpineDialogueUI : StandardDialogueUI
	{
		public override void Open()
		{
			Conversation conversation = DialogueManager.masterDatabase.GetConversation(DialogueManager.lastConversationID);
			for (int i = 0; i < conversationUIElements.subtitlePanels.Length; i++)
			{
				bool flag = conversation.LookupBool("Panel " + i + " Start Visible");
				StandardUISubtitlePanel standardUISubtitlePanel = conversationUIElements.subtitlePanels[i];
				standardUISubtitlePanel.visibility = (flag ? UIVisibility.AlwaysFromStart : UIVisibility.AlwaysOnceShown);
				if (!(standardUISubtitlePanel is SpineSubtitlePanel))
				{
					continue;
				}
				int id = conversation.LookupInt("Panel " + i + " Actor");
				Actor actor = DialogueManager.masterDatabase.GetActor(id);
				if (actor == null)
				{
					continue;
				}
				Transform registeredActorTransform = CharacterInfo.GetRegisteredActorTransform(actor.Name);
				if (!(registeredActorTransform == null))
				{
					DialogueActor component = registeredActorTransform.GetComponent<DialogueActor>();
					if (!(component == null))
					{
						component.SetSubtitlePanelNumber(PanelNumberUtility.IntToSubtitlePanelNumber(i));
						(standardUISubtitlePanel as SpineSubtitlePanel).ShowSpineDialogueActor(registeredActorTransform);
					}
				}
			}
			base.Open();
		}
	}
}
