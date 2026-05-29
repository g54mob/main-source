using System;
using AeLa.EasyFeedback.FormInput;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AeLa.EasyFeedback.InputSystemSupport
{
	public class ShowFeedbackFormInputSystem : MonoBehaviour, IToggleFormInput
	{
		[Tooltip("Input used to toggle the feedback form")]
		public InputActionReference Toggle;

		[Tooltip("Input used to show the feedback form")]
		public InputActionReference Show;

		[Tooltip("Input used to hide the feedback form")]
		public InputActionReference Hide;

		private FeedbackForm form;

		public string Descriptor => null;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void EnableAction(InputAction action, Action<InputAction.CallbackContext> callback)
		{
		}

		private void DisableAction(InputAction action, Action<InputAction.CallbackContext> callback)
		{
		}

		private void OnToggle(InputAction.CallbackContext ctx)
		{
		}

		private void OnOpen(InputAction.CallbackContext ctx)
		{
		}

		private void OnClose(InputAction.CallbackContext ctx)
		{
		}
	}
}
