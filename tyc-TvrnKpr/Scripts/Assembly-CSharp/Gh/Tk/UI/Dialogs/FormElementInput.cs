using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Gh.Tk.UI.Dialogs
{
	public class FormElementInput : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
	{
		public bool autoSwitchTypingMode;

		private InputMode _lastInputMode;

		[Tooltip("If true, then this input field will show * when privacy mode is enabled.")]
		public bool showsPrivateInfo;

		private TMP_InputField.ContentType? _originalContentType;

		private Action<InputAction.CallbackContext> _submitActionWrapped;

		public bool tabOnSubmit;

		public static FormElementInput LastSelected { get; private set; }

		public event EventHandler<EventArgs> FormElementSubmitted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void InvalidatePrivacySetting(object sender, EventArgs e)
		{
		}

		private void InvalidatePrivacyMode()
		{
		}

		private void OnSubmit(InputAction.CallbackContext obj)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public virtual void OnDeselect(BaseEventData eventData)
		{
		}

		private void OnDisable()
		{
		}

		private void OnEnable()
		{
		}

		private void UnhookSubmitAction()
		{
		}
	}
}
