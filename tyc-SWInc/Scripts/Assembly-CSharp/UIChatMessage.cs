using System;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class UIChatMessage : ComplexListItem
{
	public const float MessageHorizontalOffset = 32f;

	public Text Header;

	public Text Message;

	public RectTransform Container;

	public GameObject ActionPanel;

	public GameObject Accept;

	public GameObject Reject;

	public GameObject Cancel;

	public GameObject Focus;

	public Text StatusLabel;

	public Text SentLabel;

	public Image Back;

	public Image HeaderBack;

	public float ExtraHeight;

	private ChatWindow.Message _message;

	[NonSerialized]
	private NetworkTrade.Status _lastState;

	public Color DefaultColor;

	public Color TradeColor;

	public Color TradeAccepted;

	public Color TradeRejected;

	protected override void InitializeContent(object item)
	{
		Back.color = DefaultColor;
		_message = (ChatWindow.Message)item;
		HeaderBack.color = HUD.GetThemeColor(_message.SenderID - 1);
		Header.text = _message.Sender;
		Message.text = _message.Content;
		Container.offsetMax = new Vector2(_message.Self ? (-32f) : 0f, 0f);
		Container.offsetMin = new Vector2(_message.Self ? 0f : 32f, 0f);
		ActionPanel.SetActive(_message.Trade != null);
		if (_message.Trade != null)
		{
			UpdateTradeUI();
		}
	}

	public void AcceptTrade()
	{
		NetworkManager.Instance.TradeController.AcceptTrade(_message.Trade);
		UpdateTradeUI();
	}

	public void RejectTrade()
	{
		NetworkManager.Instance.TradeController.CancelTrade(_message.Trade, true);
		UpdateTradeUI();
	}

	public void CancelTrade()
	{
		NetworkManager.Instance.TradeController.CancelTrade(_message.Trade, false);
		UpdateTradeUI();
	}

	public void FocusTrade()
	{
		_message.Trade.Focus();
	}

	private void UpdateTradeUI()
	{
		if (_message.Trade.State == NetworkTrade.Status.Waiting)
		{
			Back.color = TradeColor;
			if (_message.Trade.Receiver == null)
			{
				Accept.SetActive(false);
				Reject.SetActive(false);
				Focus.SetActive(false);
				Cancel.SetActive(false);
				StatusLabel.gameObject.SetActive(false);
			}
			else if (_message.Trade.Receiver.Self)
			{
				Accept.SetActive(true);
				Reject.SetActive(true);
				Focus.SetActive(true);
				Cancel.SetActive(false);
				StatusLabel.gameObject.SetActive(false);
			}
			else
			{
				Accept.SetActive(false);
				Reject.SetActive(false);
				Focus.SetActive(false);
				Cancel.SetActive(true);
				StatusLabel.gameObject.SetActive(false);
			}
		}
		else
		{
			Back.color = ((_message.Trade.State == NetworkTrade.Status.Accepted) ? TradeAccepted : TradeRejected);
			Accept.SetActive(false);
			Reject.SetActive(false);
			Focus.SetActive(false);
			Cancel.SetActive(false);
			StatusLabel.text = _message.Trade.State.ToString().Loc();
			StatusLabel.gameObject.SetActive(true);
		}
	}

	private void Update()
	{
		SentLabel.text = (DateTime.Now - _message.Sent).GetString();
		if (_message.Trade != null && _message.Trade.State != _lastState)
		{
			UpdateTradeUI();
			_lastState = _message.Trade.State;
		}
	}

	public override void SetSelectedUI(bool toggle)
	{
	}

	public override float GetHeight(object content, float width)
	{
		ChatWindow.Message message = (ChatWindow.Message)content;
		TextGenerationSettings generationSettings = Message.GetGenerationSettings(new Vector2(width - 32f - 8f, 0f));
		return Message.cachedTextGeneratorForLayout.GetPreferredHeight(message.Content, generationSettings) / Options.UISize + ExtraHeight + (float)((message.Trade != null) ? 32 : 0);
	}
}
