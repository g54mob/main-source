using System.Collections;
using Assets.Scripts.Design.UI;
using Assets.Scripts.Flight.UI.Events;
using Assets.Scripts.Multiplayer;
using Jundroo.Common.Utils;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class MultiplayerChatScript : WidgetScript
	{
		private const int MaxMessageLength = 500;

		private InputWidget _chatInput;

		private Widget _chatPreview;

		private FlightUIScript _flightUI;

		private FlightSceneNetworkScript _fsn;

		private float? _hidePreviewTime;

		private float _lastTimeStamp;

		private bool _open;

		private bool _refreshMessages = true;

		private int OwnerId => FlightSceneScript.Instance.LocalPlayer.NetworkPlayer.OwnerId;

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_fsn = ((FlightSceneScript.Instance != null) ? FlightSceneScript.Instance.FlightSceneNetwork : null);
			if (_fsn != null)
			{
				_fsn.ChatMessages.ChatMessageReceived += OnChatMessageReceived;
				_chatPreview = base.Widget.FindWidget("chat-preview");
				_chatInput = base.Widget.FindWidget<InputWidget>("chat-input");
				_chatInput.Input.onSubmit.AddListener(delegate(string s)
				{
					SendChatMessage(s);
					FocusInput();
				});
				_flightUI = FlightSceneScript.Instance.FlightUI;
				_flightUI.MultiplayerStateChanged += OnFlightUIMultiplayerStateChanged;
				UpdateVisibility();
				_chatInput.Input.characterLimit = 500;
				bool flag = GetComponentInParent<DesignerUIScript>() != null;
				base.Widget.EnableClass("flight-chat", !flag);
				base.Widget.EnableClass("designer-chat", flag);
			}
			else
			{
				base.Widget.Destroy();
			}
		}

		protected void OnDestroy()
		{
			if (_fsn != null)
			{
				_fsn.ChatMessages.ChatMessageReceived -= OnChatMessageReceived;
			}
			if (_flightUI != null)
			{
				_flightUI.MultiplayerStateChanged -= OnFlightUIMultiplayerStateChanged;
			}
		}

		protected virtual void Update()
		{
			if (_refreshMessages)
			{
				_refreshMessages = false;
				foreach (ChatMessages.ChatMessage message in _fsn.ChatMessages.Messages)
				{
					if (message.TimeStamp > _lastTimeStamp)
					{
						CreateMessageWidget(message);
					}
				}
				_lastTimeStamp = Time.unscaledTime;
			}
			if (_hidePreviewTime.HasValue && Time.unscaledTime > _hidePreviewTime.Value)
			{
				_hidePreviewTime = null;
				_chatPreview.Hide(null, force: true);
			}
			if (_open && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				SetOpen(open: false);
			}
		}

		private void CreateMessageWidget(ChatMessages.ChatMessage message)
		{
			Widget parent = base.Widget.FindWidget("chat-messages");
			Widget widget = base.Widget.Context.CreateWidgetFromTemplate("chat-message", parent);
			widget.SetIndex(0);
			widget.GetComponentInChildren<TextWidget>().RichText = FormatMessageRichText(message.PlayerName, message.MessageText);
			widget.Show(force: true);
		}

		private void FocusInput()
		{
			StartCoroutine(FocusInputCoroutine());
		}

		private IEnumerator FocusInputCoroutine()
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			_chatInput.Input.ActivateInputField();
		}

		private string FormatMessageRichText(string playerName, string message)
		{
			return base.Widget.Stylesheet.GetConstant((playerName == null) ? "ServerMessageFormat" : "ChatMessageFormat").Replace("{Name}", playerName).Replace("{Message}", message);
		}

		private void OnChatButtonClicked(Widget widget)
		{
			SetOpen(!_open);
		}

		private void OnChatMessageReceived(object sender, ChatMessages.ChatMessageEventArgs e)
		{
			string richText = FormatMessageRichText(e.Message.PlayerName, StringUtility.ClampString(e.Message.MessageText, 200));
			_chatPreview.Show(force: true);
			_chatPreview.FindWidget<TextWidget>("chat-preview-text").RichText = richText;
			_hidePreviewTime = Time.unscaledTime + 5f;
			_refreshMessages = true;
		}

		private void OnFlightUIMultiplayerStateChanged(object sender, MultiplayerStateChangedEventArgs e)
		{
			UpdateVisibility();
		}

		private void OnSendClicked(Widget widget)
		{
			SendChatMessage(_chatInput.Text);
		}

		private void SendChatMessage(string message)
		{
			if (!string.IsNullOrWhiteSpace(message))
			{
				message = StringUtility.ClampString(message, 500);
				message = StringUtility.StripRichText(message);
				_fsn.SendChatMessageToAllClients(OwnerId, message);
				_chatInput.Text = string.Empty;
			}
		}

		private void SetOpen(bool open)
		{
			_open = open;
			base.Widget.EnableClass("chat-open", _open);
			if (_open)
			{
				FocusInput();
			}
		}

		private void UpdateVisibility()
		{
			base.Widget.Visible = _flightUI.MultiplayerState != FlightUIScript.MultiplayerStateType.SinglePlayer;
		}
	}
}
