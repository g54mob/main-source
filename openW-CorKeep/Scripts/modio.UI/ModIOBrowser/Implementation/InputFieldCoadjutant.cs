using System.Collections;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ModIOBrowser.Implementation
{
	internal class InputFieldCoadjutant : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler, ISubmitHandler
	{
		[SerializeField]
		private bool editOnFocus;

		[SerializeField]
		private string inputFieldTitle;

		[SerializeField]
		private string inputFieldPlaceholderText;

		[SerializeField]
		private Browser.VirtualKeyboardType keyboardtype;

		[SerializeField]
		private TMP_InputField inputField;

		private void Reset()
		{
			inputField = GetComponent<TMP_InputField>();
		}

		private void OnEnable()
		{
			if (!SharedUi.settings.ShouldWeUseVirtualKeyboardDelegate())
			{
				Object.Destroy(this);
			}
		}

		public void OnSelect(BaseEventData eventData)
		{
			if (SharedUi.settings.ShouldWeUseVirtualKeyboardDelegate())
			{
				if (editOnFocus)
				{
					OpenKeyboard();
					return;
				}
				StartCoroutine(UnFocusByDefault());
				InputReceiver.currentSelectedInputField = this;
			}
		}

		private IEnumerator UnFocusByDefault()
		{
			yield return new WaitForEndOfFrame();
			inputField.DeactivateInputField();
		}

		public void OnDeselect(BaseEventData eventData)
		{
			if (SharedUi.settings.ShouldWeUseVirtualKeyboardDelegate() && InputReceiver.currentSelectedInputField == this)
			{
				InputReceiver.currentSelectedInputField = null;
			}
		}

		public void OnSubmit(BaseEventData eventData)
		{
			if (SharedUi.settings.ShouldWeUseVirtualKeyboardDelegate())
			{
				OpenKeyboard();
			}
		}

		private void OpenKeyboard()
		{
			Browser.OpenVirtualKeyboard?.Invoke(inputFieldTitle, inputField.text, inputFieldPlaceholderText, keyboardtype, inputField.characterLimit, inputField.multiLine, OnCloseVirtualKeyboard);
		}

		private void OnCloseVirtualKeyboard(string text)
		{
			SelfInstancingMonoSingleton<MonoDispatcher>.Instance.Run(delegate
			{
				inputField.text = text;
				StartCoroutine(UnFocusByDefault());
			});
		}
	}
}
