using System;
using System.Collections.Generic;
using UnityEngine;

namespace FuryStudios.FurySDK.Utils
{
	public abstract class PlatformSystemMessengerBase : MonoBehaviour, ISystemMessenger
	{
		private enum MessageType
		{
			Overlay = 0,
			Confirm = 1,
			Prompt = 2
		}

		private class Message
		{
			public MessageType type;

			public float duration;

			public string message;

			public string btnPrimaryText;

			public string btnSecondaryText;

			public Action btnPrimaryCallback;

			public Action btnSecondaryCallback;
		}

		private Message activeMessage;

		private readonly Queue<Message> messages;

		protected abstract bool IsShowingMessage { get; }

		protected abstract bool IsReadyToShowMessage { get; }

		private void OnPrimaryButtonClick()
		{
		}

		private void OnSecondaryButtonClick()
		{
		}

		protected abstract void OnShowOverlay(string message);

		protected abstract void OnDiscardOverlay();

		protected abstract void OnShowConfirm(string message, string okButtonText, Action okButtonCallback);

		protected abstract void OnShowPrompt(string message, string yesButtonText, string noButtonText, Action yesButtonCallback, Action noButtonCallback);

		protected abstract void OnDiscardMessage(string message);

		protected virtual void LateUpdate()
		{
		}

		public void ShowOverlay(string message, float duration)
		{
		}

		public void ShowConfirm(string message, string confirmButtonText, Action callback)
		{
		}

		public void ShowPrompt(string message, string positiveButtonText, string negativeButtonText, Action<bool> callback)
		{
		}

		public void Discard(string message)
		{
		}
	}
}
