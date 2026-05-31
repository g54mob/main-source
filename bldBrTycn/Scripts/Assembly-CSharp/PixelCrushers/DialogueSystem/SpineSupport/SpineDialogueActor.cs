using UnityEngine;

namespace PixelCrushers.DialogueSystem.SpineSupport
{
	[RequireComponent(typeof(DialogueActor))]
	public class SpineDialogueActor : MonoBehaviour
	{
		public GameObject spineGameObject;

		public string showTrigger = "Show";

		public string hideTrigger = "Hide";

		public string focusTrigger = "Focus";

		public string unfocusTrigger = "Unfocus";

		protected bool wasInactive;

		private UIAnimatorMonitor m_animatorMonitor;

		public UIAnimatorMonitor animatorMonitor
		{
			get
			{
				if (m_animatorMonitor == null && spineGameObject != null)
				{
					m_animatorMonitor = new UIAnimatorMonitor(base.gameObject);
				}
				return m_animatorMonitor;
			}
		}

		public virtual void Show(StandardUISubtitlePanel subtitlePanel)
		{
			if (!(spineGameObject == null))
			{
				wasInactive = !spineGameObject.activeSelf;
				spineGameObject.SetActive(value: true);
				animatorMonitor.SetTrigger(showTrigger, null, wait: false);
			}
		}

		public virtual void Hide(StandardUISubtitlePanel subtitlePanel)
		{
			if (!(spineGameObject == null))
			{
				spineGameObject.SetActive(value: false);
				animatorMonitor.SetTrigger(hideTrigger, OnHidden);
			}
		}

		protected void OnHidden()
		{
			if (wasInactive)
			{
				spineGameObject.SetActive(value: false);
			}
		}
	}
}
