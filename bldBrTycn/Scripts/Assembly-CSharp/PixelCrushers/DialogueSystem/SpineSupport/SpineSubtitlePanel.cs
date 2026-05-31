using UnityEngine;

namespace PixelCrushers.DialogueSystem.SpineSupport
{
	public class SpineSubtitlePanel : StandardUISubtitlePanel
	{
		private SpineDialogueActor visibleSpineDialogueActor;

		public override void OpenOnStartConversation(Sprite portraitSprite, string portraitName, DialogueActor dialogueActor)
		{
			base.OpenOnStartConversation(portraitSprite, portraitName, dialogueActor);
			if (dialogueActor != null)
			{
				ShowSpineDialogueActor(dialogueActor.transform);
			}
		}

		public override void ShowSubtitle(Subtitle subtitle)
		{
			base.ShowSubtitle(subtitle);
			ShowSpineDialogueActor(subtitle.speakerInfo.transform);
		}

		public virtual void ShowSpineDialogueActor(Transform actorTransform)
		{
			if (actorTransform == null)
			{
				return;
			}
			SpineDialogueActor component = actorTransform.GetComponent<SpineDialogueActor>();
			if (component != visibleSpineDialogueActor)
			{
				if (visibleSpineDialogueActor != null)
				{
					visibleSpineDialogueActor.Hide(this);
				}
				if (component != null)
				{
					component.Show(this);
				}
				visibleSpineDialogueActor = component;
			}
		}

		public override void Close()
		{
			if (visibleSpineDialogueActor != null)
			{
				visibleSpineDialogueActor.Hide(this);
			}
			visibleSpineDialogueActor = null;
			base.Close();
		}
	}
}
