using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PimDeWitte.UnityMainThreadDispatcher;
using Pug.UnityExtensions;
using UnityEngine;

public class RadicalJoinGameMenu : RadicalEnterTextMenu
{
	[Serializable]
	private struct SubMenuTab
	{
		public WorldSettingsTab tab;

		public GameObject subMenu;
	}

	public enum JoinMethod
	{
		ID = 0,
		IP = 1
	}

	public RadicalMenuOptionTextInput hostText;

	public RadicalMenuOptionTextInput ipText;

	public RadicalMenuOptionTextInput portText;

	public RadicalMenuOptionTextInput passwordText;

	public PugText connectingText;

	public PugText menuText;

	private bool _isConnecting;

	public bool _isErrorShown;

	private bool _cleaning;

	private float _timeoutTimer = 35f;

	private JoinMethod _joinMethod;

	[SerializeField]
	private GameObject[] _allMenus;

	public override bool IsConnecting => _isConnecting;

	public override void Activate()
	{
		UpdateConnectingText();
		base.Activate();
		ChangeJoinMethod(_joinMethod);
	}

	public override void Deactivate(bool pop)
	{
		if (_isConnecting)
		{
			if (Manager.networking.connectionFailed)
			{
				ConnectFailed();
			}
			else
			{
				StopJoin();
			}
			Update();
		}
		base.Deactivate(pop);
	}

	public override void ButtonPressed()
	{
		if (!_isConnecting)
		{
			ServerConnectionInfo address = GetJoinText();
			if (_joinMethod == JoinMethod.ID)
			{
				Manager.networking.CanUserPlayMultiplayer(delegate(bool hasAllRequestedPrivileges)
				{
					if (hasAllRequestedPrivileges)
					{
						Join(address);
					}
				}, joining: true);
			}
			else
			{
				Join(address);
			}
		}
		else
		{
			StopJoin();
		}
	}

	private void Join(ServerConnectionInfo connectionInfo)
	{
		if (IsValidJoinInfo(connectionInfo))
		{
			Manager.networking.ResetConnectSettings();
			_isConnecting = true;
			_timeoutTimer = 35f;
			UpdateConnectingText();
			WallClockTimer frameWorkloadTimer = new WallClockTimer(TimeSpan.FromMilliseconds(30.0));
			Manager.ecs.StartEcs(startClient: true, -1, frameWorkloadTimer, delegate(bool result)
			{
				if (!result)
				{
					Debug.LogWarning("RadicalJoinGameMenu.Join: ECS start failed or was cancelled.");
					ConnectFailed();
				}
				else
				{
					Manager.networking.Connect(connectionInfo, delegate(bool b)
					{
						if (!b && _isConnecting)
						{
							ConnectFailed();
						}
					});
				}
			});
		}
		else
		{
			Debug.LogError("Not valid join address");
		}
	}

	private ServerConnectionInfo GetJoinText()
	{
		JoinMethod joinMethod = _joinMethod;
		if (joinMethod != JoinMethod.ID && joinMethod == JoinMethod.IP)
		{
			return new ServerConnectionInfo
			{
				PublicIP = ipText.GetInputText().Trim(),
				Port = portText.GetInputText().Trim(),
				Password = passwordText.GetInputText().Trim(),
				JoinedWithIP = true
			};
		}
		return new ServerConnectionInfo
		{
			GameID = hostText.GetInputText().Trim(),
			JoinedWithIP = false
		};
	}

	private bool IsValidJoinInfo(ServerConnectionInfo joinInfo)
	{
		JoinMethod joinMethod = _joinMethod;
		if (joinMethod != JoinMethod.ID && joinMethod == JoinMethod.IP)
		{
			if (string.IsNullOrEmpty(joinInfo.PublicIP) || string.IsNullOrEmpty(joinInfo.Port) || string.IsNullOrEmpty(joinInfo.Password))
			{
				Debug.Log(string.Format("{0}.{1}: Given join info isn't valid.", this, "IsValidJoinInfo"));
				return false;
			}
			return true;
		}
		return !string.IsNullOrEmpty(joinInfo.GameID);
	}

	private void StopJoin()
	{
		Debug.Log("RadicalJoinGameMenu.StopJoin");
		_isConnecting = false;
	}

	protected void Update()
	{
		if (_isConnecting)
		{
			if (Manager.networking.connectionFailed)
			{
				ConnectFailed();
			}
			else if (Manager.networking.isConnected)
			{
				_isConnecting = false;
				if ((Manager.networking.serverWorldMode & WorldMode.Creative) != WorldMode.Normal)
				{
					Manager.menu.PushMenu(MenuType.CREATIVE_CHARACTER_CHOOSER);
				}
				else
				{
					Manager.menu.PushMenu(MenuType.CHARACTER_CHOOSER);
				}
			}
			if (!Manager.networking.isCheckingPrivileges)
			{
				_timeoutTimer -= Time.deltaTime;
			}
			if (_timeoutTimer <= 0f && _isConnecting)
			{
				_isConnecting = false;
				Manager.networking.connectionFailedReason = "Error/Timeout";
				ConnectFailed();
			}
		}
		else if (Manager.ecs.ClientWorld != null)
		{
			Manager.ecs.CancelECSWorldConversionOrUnloadWorlds();
		}
		UpdateConnectingText();
		UpdateTextFields();
	}

	private async Task WaitForSessionCleanup()
	{
		_cleaning = true;
		int retryIntervalMs = 500;
		int retryCounter = 0;
		int retryMax = 30;
		while (Manager.networking.CurrentSession != default(ServerConnectionInfo))
		{
			Debug.Log("RadicalJoinGameMenu.WaitForSessionCleanup: waiting for session to be cleaned up.");
			await Task.Delay(retryIntervalMs);
			int num = retryCounter + 1;
			retryCounter = num;
			if (num >= retryMax)
			{
				int num2 = retryIntervalMs * retryCounter / 1000;
				Debug.Log(string.Format("{0}.{1}: waited {2} for session to be cleaned up but it's still not. Check previous logs for potential reason.", "RadicalJoinGameMenu", "WaitForSessionCleanup", num2));
			}
		}
		if (!_isErrorShown)
		{
			UnityMainThreadDispatcher.Instance().EnqueueAsync(delegate
			{
				Manager.menu.centerPopUpText.FadeOutCurrentDisplaySequence();
				Manager.input.EnableSystemInput();
				Manager.menu.PopUntil(MenuType.SELECT_SESSION);
				if (!Manager.menu.HasMenuInStack(MenuType.SELECT_SESSION))
				{
					Manager.menu.PushMenu(MenuType.SELECT_SESSION);
				}
			});
		}
		_cleaning = false;
	}

	private void ConnectFailed()
	{
		_isErrorShown = true;
		StopJoin();
		string text = Manager.networking.connectionFailedReason;
		Manager.input.EnableSystemInput();
		int num = 0;
		if (!string.IsNullOrEmpty(text) && !text.Contains("/"))
		{
			text = "Error/" + text;
		}
		bool localizePlaceholders = true;
		string[] formatFields;
		if (!(text == "Consoles/SessionFull") || num <= 0)
		{
			formatFields = ((!(text != "Consoles/MissingPrivilegeReason")) ? new string[1] { "Consoles/Crossplay" } : new string[1] { "unsupported" });
		}
		else
		{
			text = "Consoles/SessionFullWithPlayerCount";
			localizePlaceholders = false;
			formatFields = new string[1] { num.ToString() };
		}
		PopUpText centerPopUpText = Manager.menu.centerPopUpText;
		string text2 = (string.IsNullOrEmpty(text) ? "connectionFailed" : text);
		Action<PopupResponse> optionsCallback = PopUpCallBack;
		List<string> options = new List<string> { "ok" };
		centerPopUpText.StartNewDisplaySequence(text2, formatFields, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, optionsCallback, options, 10f, 0f, 0, 20f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: false, localizePlaceholders);
	}

	private void PopUpCallBack(PopupResponse response)
	{
	}

	private void WaitingPopUp()
	{
		if (!_isErrorShown)
		{
			Manager.input.DisableSystemInput();
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Error/PleaseWait", null, menuInputCooldown: true, 0f, 60f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, null, null, 10f);
		}
	}

	private void UpdateConnectingText()
	{
		connectingText.gameObject.SetActive(_isConnecting);
	}

	private void UpdateTextFields()
	{
		if (ServerConnectionInfo.IsDirectServerIP(ipText.GetInputText()))
		{
			string inputText = ipText.GetInputText();
			ipText.SetInputText("");
			SetSessionData(ServerConnectionInfo.UnPackConnectionID(inputText));
		}
	}

	public void ChangeJoinMethod(JoinMethod joinMethod)
	{
		_joinMethod = joinMethod;
		for (int i = 0; i < _allMenus.Length; i++)
		{
			_allMenus[i].SetActive(i == (int)_joinMethod);
		}
	}

	public void SetSessionData(string sessionData)
	{
		SetSessionData(ServerConnectionInfo.UnPackConnectionID(sessionData));
	}

	public void SetSessionData(ServerConnectionInfo serverConnectionInfo)
	{
		if (!string.IsNullOrEmpty(serverConnectionInfo.PublicIP))
		{
			ipText.SetInputText(serverConnectionInfo.PublicIP);
		}
		if (!string.IsNullOrEmpty(serverConnectionInfo.Port))
		{
			portText.SetInputText(serverConnectionInfo.Port);
		}
		if (!string.IsNullOrEmpty(serverConnectionInfo.Password))
		{
			passwordText.SetInputText(serverConnectionInfo.Password);
		}
		if (!string.IsNullOrEmpty(serverConnectionInfo.GameID))
		{
			hostText.SetInputText(serverConnectionInfo.GameID);
		}
	}
}
