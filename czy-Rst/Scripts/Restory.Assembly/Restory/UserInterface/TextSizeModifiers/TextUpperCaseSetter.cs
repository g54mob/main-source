using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface.TextSizeModifiers
{
	public class TextUpperCaseSetter : MonoBehaviour
	{
		private enum TextCheckingMode
		{
			OnEnable = 0,
			Update = 10,
			LateUpdate = 20,
			LoopInSeconds = 30
		}

		[SerializeField]
		private Text text;

		[SerializeField]
		private TextCheckingMode textCheckingMode = TextCheckingMode.LateUpdate;

		[SerializeField]
		private float loopTime = 0.5f;

		private string originalText = string.Empty;

		private string cachedCurrentText = string.Empty;

		private bool forceUpperCase;

		private Coroutine textCheckingCoroutine;

		private Coroutine initializeAfterEndOfFrameCoroutine;

		public bool ForceUpperCase
		{
			get
			{
				return forceUpperCase;
			}
			set
			{
				if (forceUpperCase != value)
				{
					forceUpperCase = value;
					if (initializeAfterEndOfFrameCoroutine == null && base.isActiveAndEnabled)
					{
						text.text = (value ? originalText.ToUpper() : originalText);
						cachedCurrentText = text.text;
					}
				}
			}
		}

		private void OnEnable()
		{
			initializeAfterEndOfFrameCoroutine = StartCoroutine(InitializeAfterEndOfFrameCoroutine());
		}

		private void OnDisable()
		{
			if (textCheckingCoroutine != null)
			{
				StopCoroutine(textCheckingCoroutine);
				textCheckingCoroutine = null;
			}
			if (initializeAfterEndOfFrameCoroutine != null)
			{
				StopCoroutine(initializeAfterEndOfFrameCoroutine);
				initializeAfterEndOfFrameCoroutine = null;
			}
			if (text != null)
			{
				text.text = originalText;
			}
			cachedCurrentText = (originalText = string.Empty);
			forceUpperCase = false;
		}

		private IEnumerator InitializeAfterEndOfFrameCoroutine()
		{
			yield return new WaitForEndOfFrame();
			RefreshText();
			if (textCheckingMode == TextCheckingMode.LoopInSeconds)
			{
				textCheckingCoroutine = StartCoroutine(TextCheckingCoroutine());
			}
			initializeAfterEndOfFrameCoroutine = null;
		}

		private void Update()
		{
			if (textCheckingMode == TextCheckingMode.Update)
			{
				CheckText();
			}
		}

		private void LateUpdate()
		{
			if (textCheckingMode == TextCheckingMode.LateUpdate)
			{
				CheckText();
			}
		}

		private IEnumerator TextCheckingCoroutine()
		{
			WaitForSeconds waitForSeconds = new WaitForSeconds(loopTime);
			while (base.isActiveAndEnabled)
			{
				yield return waitForSeconds;
				CheckText();
			}
			textCheckingCoroutine = null;
		}

		private void CheckText()
		{
			if (!(cachedCurrentText == text.text))
			{
				RefreshText();
			}
		}

		private void RefreshText()
		{
			if (text.text != originalText.ToUpper())
			{
				originalText = text.text;
			}
			if (ForceUpperCase)
			{
				text.text = text.text.ToUpper();
			}
			cachedCurrentText = text.text;
		}
	}
}
