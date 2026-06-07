using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.GuiNew;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class MessageManager
	{
		public class Message
		{
			public bool CanFloat { get; set; }

			public bool Highlighted { get; set; }

			public string Text { get; set; }

			public float Time { get; set; }
		}

		private Widget _messageParent;

		private List<IFadingMessage> _messages = new List<IFadingMessage>();

		private Coroutine _refreshParentCoroutine;

		private bool _refreshParentLayout;

		private XrUiScript _xrUiScript;

		public MessageManager(Widget parent)
		{
			_messageParent = parent;
			_xrUiScript = FlightSceneScript.Instance.FlightUI.XrUiScript;
		}

		public void FadeCurrentTutorialMessage()
		{
			throw new NotImplementedException();
		}

		public void SetTutorialMessage(string message, bool showContinueButton)
		{
			throw new NotImplementedException();
		}

		public void ShowMessage(string messageText, float time, bool logMessage, bool highlighted = false)
		{
			Message message = new Message
			{
				Text = messageText,
				Time = time,
				CanFloat = logMessage,
				Highlighted = highlighted
			};
			if (_messages.Count > 0 && !_messages[0].CanFloat)
			{
				_messages[0].Destroy(immediate: true);
				_messages.RemoveAt(0);
			}
			if (!logMessage && string.IsNullOrEmpty(messageText))
			{
				if (_messages.Count > 0 && !_messages[0].CanFloat)
				{
					_messages[0].Destroy(immediate: true);
					_messages.RemoveAt(0);
				}
				return;
			}
			IFadingMessage item = ShowMessage(message);
			_messages.Insert(0, item);
			int num = 10;
			while (_messages.Count > num)
			{
				_messages[num].Destroy(immediate: true);
				_messages.RemoveAt(num);
			}
		}

		public void Update()
		{
			for (int i = 0; i < _messages.Count; i++)
			{
				if (_messages[i].IsDead)
				{
					_messages[i].Destroy(immediate: false);
					_messages.RemoveAt(i);
					i--;
				}
				else
				{
					_messages[i].Update(Time.unscaledDeltaTime);
				}
			}
			if (_refreshParentLayout && _messageParent.gameObject.activeInHierarchy)
			{
				_refreshParentLayout = false;
				if (_refreshParentCoroutine != null)
				{
					_messageParent.StopCoroutine(_refreshParentCoroutine);
					_refreshParentCoroutine = null;
				}
				_refreshParentCoroutine = _messageParent.StartCoroutine(RefreshParent());
			}
		}

		private IEnumerator RefreshParent()
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			_messageParent.gameObject.SetActive(value: false);
			_messageParent.gameObject.SetActive(value: true);
		}

		private IFadingMessage ShowMessage(Message message)
		{
			IFadingMessage fadingMessage;
			if (Game.Instance.Device.IsVRBuild && Game.Instance.XRDeviceManager.HmdActive)
			{
				fadingMessage = _xrUiScript.ShowMessage(message);
			}
			else
			{
				fadingMessage = _messageParent.Context.CreateWidgetFromTemplate("status-message", _messageParent).GetComponent<FadingMessageScript>();
				fadingMessage.ShowMessage(message);
				_refreshParentLayout = true;
			}
			return fadingMessage;
		}
	}
}
