using System;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Restory.UserInterface.Dialogue
{
	public class GUI_RestoryDialogueContinueButton : StandardUIContinueButtonFastForward
	{
		private Coroutine doCallbackAfterEndOfFrameCoroutine;

		private void OnDisable()
		{
			if (doCallbackAfterEndOfFrameCoroutine != null)
			{
				StopCoroutine(doCallbackAfterEndOfFrameCoroutine);
				doCallbackAfterEndOfFrameCoroutine = null;
			}
		}

		public override void OnFastForward()
		{
			if (doCallbackAfterEndOfFrameCoroutine == null)
			{
				doCallbackAfterEndOfFrameCoroutine = StartCoroutine(DoCallbackAfterEndOfFrame(delegate
				{
					base.OnFastForward();
				}));
			}
		}

		private IEnumerator DoCallbackAfterEndOfFrame(Action callback)
		{
			yield return new WaitForEndOfFrame();
			callback?.Invoke();
			doCallbackAfterEndOfFrameCoroutine = null;
		}
	}
}
