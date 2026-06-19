using System.Collections.Generic;

public class RadicalConnectBiliBiliMenu : RadicalEnterTextMenu
{
	private const string MenuBilibiliConnectSucceeded = "StreamIntegration/ConnectToBilibiliSuccessDesc";

	private const string MenuBilibiliConnectFailed = "StreamIntegration/ConnectToBilibiliFailedDesc";

	private const string MenuBilibiliConnect = "Menu/ConnectText";

	private const string MenuBilibiliDisconnect = "Menu/DisconnectText";

	public RadicalMenuOptionTextInput bilibiliCodeText;

	public RadicalMenuOption_Toggle saveCodeToggle;

	public PugText connectingText;

	public PugText connectingTime;

	public RadicalEnterTextMenu_EnterButtonOption enterButtonOption;

	private bool _isConnecting;

	private bool _isCanceled;

	public override bool IsConnecting => _isConnecting;

	public override void Activate()
	{
		UpdateConnectingText();
		base.Activate();
	}

	public override void Deactivate(bool pop)
	{
		if (_isConnecting)
		{
			CancelConnect();
		}
		base.Deactivate(pop);
	}

	public override void ButtonPressed()
	{
		if (Manager.stream.StreamIntegrationManager.IsConnected())
		{
			Manager.stream.StreamIntegrationManager.Disconnect();
		}
		else if (!_isConnecting)
		{
			if (!string.IsNullOrEmpty(bilibiliCodeText.pugText.GetText()))
			{
				_isConnecting = true;
				Manager.stream.StreamIntegrationManager.ConnectToRoom(bilibiliCodeText.pugText.GetText().ToUpper(), saveCodeToggle.isOn, ConnectResultCallback);
			}
		}
		else
		{
			CancelConnect();
		}
	}

	private void Update()
	{
		UpdateConnectingText();
	}

	private void CancelConnect()
	{
		_isCanceled = true;
		Manager.stream.StreamIntegrationManager.CancelConnect();
	}

	private void ConnectResultCallback(bool result)
	{
		if (result)
		{
			ConnectSucceeded();
		}
		else if (!_isCanceled)
		{
			ConnectFailed();
		}
		_isCanceled = false;
		_isConnecting = false;
	}

	private void ConnectSucceeded()
	{
		Manager.menu.centerPopUpText.StartNewDisplaySequence("StreamIntegration/ConnectToBilibiliSuccessDesc", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate
		{
		}, new List<string> { "ok" }, 10f, 0f, 0, 20f);
	}

	private void ConnectFailed()
	{
		Manager.menu.centerPopUpText.StartNewDisplaySequence("StreamIntegration/ConnectToBilibiliFailedDesc", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate
		{
		}, new List<string> { "ok" }, 10f, 0f, 0, 20f);
	}

	private void UpdateConnectingText()
	{
		connectingText.gameObject.SetActive(_isConnecting);
		connectingTime.gameObject.SetActive(value: false);
		if (BiliBiliManager.currentConnectDelay > 0)
		{
			connectingTime.SetText("(" + BiliBiliManager.currentConnectDelay + ")");
			connectingTime.gameObject.SetActive(_isConnecting);
		}
		bool flag = Manager.stream.StreamIntegrationManager.IsConnected();
		enterButtonOption.joinTerm = (flag ? "Menu/DisconnectText" : "Menu/ConnectText");
	}
}
