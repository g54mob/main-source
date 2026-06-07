using System;
using I18n;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class SimpleInputDialog3DUIView : BaseDialog3DUIView
	{
		public bool closeOnSubmit;

		[SerializeField]
		protected Button3DUIView _closeButton;

		[SerializeField]
		protected Button3DUIView _submitButton;

		[SerializeField]
		protected TMP_InputField _textInputField;

		[SerializeField]
		protected TextMeshProUGUII18n _titleText;

		[SerializeField]
		protected TMP_Text _feedbackText;

		public string invalidInputFeedbackText;

		private InputMode _lastInputMode;

		public Action<string> inputChangedAction;

		public Action<string> submitAction;

		protected override void Awake()
		{
		}

		public void SetData(string title, string currentText, string submitButtonText, string invalidInputText)
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void Opened()
		{
		}

		private void Submit()
		{
		}

		private bool IsInputValidInternal()
		{
			return false;
		}

		protected virtual bool IsInputValid(string inputTextValue)
		{
			return false;
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}
	}
}
