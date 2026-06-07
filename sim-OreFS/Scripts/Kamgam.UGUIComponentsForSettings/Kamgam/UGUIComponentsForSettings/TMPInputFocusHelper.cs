using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Kamgam.UGUIComponentsForSettings
{
	[RequireComponent(typeof(TMP_InputField))]
	public class TMPInputFocusHelper : MonoBehaviour, ISelectHandler, IEventSystemHandler, ISubmitHandler
	{
		[SerializeField]
		[Header("Touch Settings")]
		[Tooltip("Which keyboard type should be opened on touch devices?")]
		private TouchScreenKeyboardType keyboardType;

		protected TMP_InputField inputTf;

		public TMP_InputField InputTf
		{
			get
			{
				if (inputTf == null)
				{
					inputTf = GetComponent<TMP_InputField>();
				}
				return inputTf;
			}
		}

		public void OnSelect(BaseEventData eventData)
		{
			StartCoroutine(UnFocusByDefault());
		}

		private IEnumerator UnFocusByDefault()
		{
			yield return new WaitForEndOfFrame();
			InputTf.DeactivateInputField();
		}

		public void OnSubmit(BaseEventData eventData)
		{
			TouchScreenKeyboard.Open(InputTf.text, keyboardType);
		}

		public void Update()
		{
			if (InputUtils.SubmitDown() && InputTf.isFocused && InputTf.isFocused && Keyboard.current != null && !Keyboard.current.enterKey.wasPressedThisFrame && !Keyboard.current.numpadEnterKey.wasPressedThisFrame)
			{
				InputTf.DeactivateInputField();
			}
		}
	}
}
