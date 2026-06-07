using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class LabeledInputUI : MonoBehaviour, ISelectableUI, IUIObject, ISubmitHandler, IEventSystemHandler, IDeselectHandler
	{
		[SerializeField]
		private TextMeshProUGUI _Label;

		[SerializeField]
		private TMP_InputField _Input;

		[SerializeField]
		private TouchScreenKeyboardType _KeyboardType;

		private bool _HasBeenActivated;

		private TouchScreenKeyboard _softKeyboard;

		public TextMeshProUGUI Label => null;

		public TMP_InputField Input => null;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void LateUpdate()
		{
		}

		public void SetKeyboardType(TouchScreenKeyboardType t)
		{
		}

		public void SetContentType(TMP_InputField.ContentType contentType)
		{
		}

		public void SetLabel(string text)
		{
		}

		public bool IsFocused()
		{
			return false;
		}

		public void SetInputPlaceholderText(string value)
		{
		}

		public string GetText()
		{
			return null;
		}

		public Selectable GetSelectable()
		{
			return null;
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		public void UpdateNavigation(Selectable up, Selectable down, Selectable left, Selectable right)
		{
		}

		public void ActivateInputField()
		{
		}

		public void OnSubmit(BaseEventData eventData)
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}

		private void OnInputSelected(string arg0)
		{
		}

		private void OnEndEdit(string arg0)
		{
		}

		private void OnFloatingGamepadTextInputDismissed()
		{
		}

		private bool IsRunningOnXboxHandheld()
		{
			return false;
		}

		private void TryShowXboxVirtualKeyboard()
		{
		}

		private void TryHideXboxVirtualKeyboard()
		{
		}
	}
}
