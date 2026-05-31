using Spine.Unity;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SpineSupport
{
	[RequireComponent(typeof(DialogueActor))]
	public class SpineDialogueActorUI : SpineDialogueActor
	{
		public override void Show(StandardUISubtitlePanel subtitlePanel)
		{
			if (spineGameObject == null || subtitlePanel == null || subtitlePanel.portraitImage == null)
			{
				return;
			}
			wasInactive = !spineGameObject.activeSelf;
			foreach (Transform item in subtitlePanel.transform)
			{
				SkeletonGraphic component = item.GetComponent<SkeletonGraphic>();
				if (component != null)
				{
					component.gameObject.SetActive(value: false);
				}
			}
			spineGameObject.SetActive(value: true);
			spineGameObject.transform.SetParent(subtitlePanel.transform, worldPositionStays: false);
			if (subtitlePanel.portraitName != null)
			{
				spineGameObject.transform.SetSiblingIndex(subtitlePanel.portraitName.gameObject.transform.GetSiblingIndex());
			}
			spineGameObject.GetComponent<RectTransform>().anchoredPosition = subtitlePanel.portraitImage.GetComponent<RectTransform>().anchoredPosition;
			subtitlePanel.GetComponent<Animator>().Rebind();
			subtitlePanel.GetComponent<Animator>().SetTrigger(subtitlePanel.showAnimationTrigger);
		}
	}
}
