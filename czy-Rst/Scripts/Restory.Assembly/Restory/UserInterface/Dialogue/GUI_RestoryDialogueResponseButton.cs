using System;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UserInterface.Dialogue
{
	public class GUI_RestoryDialogueResponseButton : StandardUIResponseButton, IPointerExitHandler, IEventSystemHandler
	{
		private Coroutine doCallbackAfterEndOfFrameCoroutine;

		public event Action OnClicked;

		private void OnDisable()
		{
			if (doCallbackAfterEndOfFrameCoroutine != null)
			{
				StopCoroutine(doCallbackAfterEndOfFrameCoroutine);
				doCallbackAfterEndOfFrameCoroutine = null;
			}
		}

		public override void OnClick()
		{
			if (doCallbackAfterEndOfFrameCoroutine == null)
			{
				doCallbackAfterEndOfFrameCoroutine = StartCoroutine(DoCallbackAfterEndOfFrame(delegate
				{
					this.OnClicked?.Invoke();
					base.OnClick();
				}));
			}
		}

		private IEnumerator DoCallbackAfterEndOfFrame(Action callback)
		{
			yield return new WaitForEndOfFrame();
			callback?.Invoke();
			doCallbackAfterEndOfFrameCoroutine = null;
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject == base.gameObject)
			{
				EventSystem.current.SetSelectedGameObject(null);
			}
		}
	}
}
