using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;

public class CheatsMenu : NetworkBehaviour
{
	public TextMeshProUGUI godMode;

	public TextMeshProUGUI money;

	public TextMeshProUGUI speed;

	public GameObject godModeOff;

	public GameObject godModeOn;

	public GameObject decryptOff;

	public GameObject decryptOn;

	public bool cheatsMenuOpen;

	public GameObject cheatsMenu;

	public TextMeshProUGUI customerIdText;

	public GameObject customerIdFound;

	public GameObject customerIdNotFound;

	private void Update()
	{
		if (Input.GetKeyDown("p") && ClientPlayer.Instance.playerMan.canPause)
		{
			UpdateText();
			SpeakingManager.Instance.ignoreClicks = true;
			ClientPlayer.Instance.playerMan.paused = true;
			ClientPlayer.Instance.fpsScript.UnlockCursor();
			ClientPlayer.Instance.fpsScript.lockMove = true;
			ClientPlayer.Instance.fpsScript.lockCam = true;
			cheatsMenu.SetActive(value: true);
			cheatsMenuOpen = !cheatsMenuOpen;
		}
	}

	public void SpawnCustomer()
	{
		if (base.isServer)
		{
			SpawnCustomerRpc(CleanId(customerIdText.text.ToLower()));
		}
		else
		{
			SpawnCustomerCmd(CleanId(customerIdText.text.ToLower()));
		}
	}

	[Command(requiresAuthority = false)]
	private void SpawnCustomerCmd(string custId)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(custId);
		SendCommandInternal("System.Void CheatsMenu::SpawnCustomerCmd(System.String)", -1805846111, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void SpawnCustomerRpc(string custId)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(custId);
		SendRPCInternal("System.Void CheatsMenu::SpawnCustomerRpc(System.String)", -23859752, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private string CleanId(string s)
	{
		return s.Trim().ToLower().Replace("\u200b", "")
			.Replace("\u00a0", "")
			.Replace("\n", "")
			.Replace("\r", "");
	}

	public void ExitCheatMenu()
	{
		SpeakingManager.Instance.ignoreClicks = false;
		ClientPlayer.Instance.playerMan.paused = false;
		ClientPlayer.Instance.fpsScript.LockCursor();
		ClientPlayer.Instance.fpsScript.lockMove = false;
		ClientPlayer.Instance.fpsScript.lockCam = false;
		cheatsMenu.SetActive(value: false);
		cheatsMenuOpen = false;
	}

	public void AddShopRefresh()
	{
		PurchaseManager.Instance.AddRefreshes(1);
	}

	public void UpdateText()
	{
		if (PlayerPrefs.GetInt("GodMode") == 1)
		{
			godMode.text = "GOD MODE: ON";
		}
		else
		{
			godMode.text = "GOD MODE: OFF";
		}
		money.text = "MONEY: $" + SaveManager.Instance.money.ToString("0.00");
		speed.text = "SPEED: x" + Time.timeScale.ToString("0.0");
	}

	public void ChangeGodMode(bool on)
	{
		if (on)
		{
			PlayerPrefs.SetInt("GodMode", 1);
		}
		else
		{
			PlayerPrefs.SetInt("GodMode", 0);
		}
		UpdateText();
	}

	public void ChangeDecryptText(bool on)
	{
		if (on)
		{
			PlayerPrefs.SetInt("DecryptText", 1);
		}
		else
		{
			PlayerPrefs.SetInt("DecryptText", 0);
		}
		UpdateText();
	}

	public void ChangeMoney(float moneyChange)
	{
		if (base.isServer)
		{
			ChangeMoneyRpc(moneyChange);
		}
		else
		{
			ChangeMoneyCmd(moneyChange);
		}
	}

	[Command(requiresAuthority = false)]
	public void ChangeMoneyCmd(float moneyChange)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(moneyChange);
		SendCommandInternal("System.Void CheatsMenu::ChangeMoneyCmd(System.Single)", -2060353735, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ChangeMoneyRpc(float moneyChange)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(moneyChange);
		SendRPCInternal("System.Void CheatsMenu::ChangeMoneyRpc(System.Single)", -565795812, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ChangeSpeed(float newSpeed)
	{
		if (base.isServer)
		{
			ChangeSpeedRpc(newSpeed);
		}
		else
		{
			ChangeSpeedCmd(newSpeed);
		}
	}

	[Command(requiresAuthority = false)]
	public void ChangeSpeedCmd(float newSpeed)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(newSpeed);
		SendCommandInternal("System.Void CheatsMenu::ChangeSpeedCmd(System.Single)", -827176938, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ChangeSpeedRpc(float newSpeed)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(newSpeed);
		SendRPCInternal("System.Void CheatsMenu::ChangeSpeedRpc(System.Single)", 1984374027, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SkipToNextDay()
	{
		if (base.isServer)
		{
			SkipToNextDayRpc();
		}
		else
		{
			SkipToNextDayCmd();
		}
	}

	[Command(requiresAuthority = false)]
	public void SkipToNextDayCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void CheatsMenu::SkipToNextDayCmd()", 547560977, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void SkipToNextDayRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void CheatsMenu::SkipToNextDayRpc()", 1829061874, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_SpawnCustomerCmd__String(string custId)
	{
		SpawnCustomerRpc(custId);
	}

	protected static void InvokeUserCode_SpawnCustomerCmd__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SpawnCustomerCmd called on client.");
		}
		else
		{
			((CheatsMenu)obj).UserCode_SpawnCustomerCmd__String(reader.ReadString());
		}
	}

	protected void UserCode_SpawnCustomerRpc__String(string custId)
	{
		Npc[] allRandomSpawningNpcs = CurrentDayManager.Instance.customerGenManager.allRandomSpawningNpcs;
		foreach (Npc npc in allRandomSpawningNpcs)
		{
			if (!(npc == null) && CleanId(npc.id.ToLower()) == custId)
			{
				CurrentDayManager.Instance.listOfOccurrences.Insert(CurrentDayManager.Instance.curOccurrence, "NPC");
				CurrentDayManager.Instance.todaysNpcs.Insert(CurrentDayManager.Instance.npcIndex, npc);
				customerIdFound.SetActive(value: false);
				customerIdFound.SetActive(value: true);
				return;
			}
		}
		customerIdNotFound.SetActive(value: false);
		customerIdNotFound.SetActive(value: true);
	}

	protected static void InvokeUserCode_SpawnCustomerRpc__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SpawnCustomerRpc called on server.");
		}
		else
		{
			((CheatsMenu)obj).UserCode_SpawnCustomerRpc__String(reader.ReadString());
		}
	}

	protected void UserCode_ChangeMoneyCmd__Single(float moneyChange)
	{
		ChangeMoneyRpc(moneyChange);
	}

	protected static void InvokeUserCode_ChangeMoneyCmd__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeMoneyCmd called on client.");
		}
		else
		{
			((CheatsMenu)obj).UserCode_ChangeMoneyCmd__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_ChangeMoneyRpc__Single(float moneyChange)
	{
		if (base.isServer)
		{
			StoreManager.Instance.ChangeRevenue("Cheats", moneyChange);
			UpdateText();
		}
	}

	protected static void InvokeUserCode_ChangeMoneyRpc__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeMoneyRpc called on server.");
		}
		else
		{
			((CheatsMenu)obj).UserCode_ChangeMoneyRpc__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_ChangeSpeedCmd__Single(float newSpeed)
	{
		ChangeSpeedRpc(newSpeed);
	}

	protected static void InvokeUserCode_ChangeSpeedCmd__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeSpeedCmd called on client.");
		}
		else
		{
			((CheatsMenu)obj).UserCode_ChangeSpeedCmd__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_ChangeSpeedRpc__Single(float newSpeed)
	{
		Time.timeScale = newSpeed;
		UpdateText();
	}

	protected static void InvokeUserCode_ChangeSpeedRpc__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeSpeedRpc called on server.");
		}
		else
		{
			((CheatsMenu)obj).UserCode_ChangeSpeedRpc__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_SkipToNextDayCmd()
	{
		SkipToNextDayRpc();
	}

	protected static void InvokeUserCode_SkipToNextDayCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SkipToNextDayCmd called on client.");
		}
		else
		{
			((CheatsMenu)obj).UserCode_SkipToNextDayCmd();
		}
	}

	protected void UserCode_SkipToNextDayRpc()
	{
		EventManager.Instance.EODBus();
	}

	protected static void InvokeUserCode_SkipToNextDayRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SkipToNextDayRpc called on server.");
		}
		else
		{
			((CheatsMenu)obj).UserCode_SkipToNextDayRpc();
		}
	}

	static CheatsMenu()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(CheatsMenu), "System.Void CheatsMenu::SpawnCustomerCmd(System.String)", InvokeUserCode_SpawnCustomerCmd__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(CheatsMenu), "System.Void CheatsMenu::ChangeMoneyCmd(System.Single)", InvokeUserCode_ChangeMoneyCmd__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(CheatsMenu), "System.Void CheatsMenu::ChangeSpeedCmd(System.Single)", InvokeUserCode_ChangeSpeedCmd__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(CheatsMenu), "System.Void CheatsMenu::SkipToNextDayCmd()", InvokeUserCode_SkipToNextDayCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(CheatsMenu), "System.Void CheatsMenu::SpawnCustomerRpc(System.String)", InvokeUserCode_SpawnCustomerRpc__String);
		RemoteProcedureCalls.RegisterRpc(typeof(CheatsMenu), "System.Void CheatsMenu::ChangeMoneyRpc(System.Single)", InvokeUserCode_ChangeMoneyRpc__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(CheatsMenu), "System.Void CheatsMenu::ChangeSpeedRpc(System.Single)", InvokeUserCode_ChangeSpeedRpc__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(CheatsMenu), "System.Void CheatsMenu::SkipToNextDayRpc()", InvokeUserCode_SkipToNextDayRpc);
	}
}
