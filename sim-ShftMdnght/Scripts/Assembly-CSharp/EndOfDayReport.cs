using System;
using System.Collections.Generic;
using Dissonance;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfDayReport : NetworkBehaviour
{
	public bool demo;

	public float showingRevenue;

	public float actualRevenue;

	public TextMeshProUGUI todaysQuotaText;

	public TextMeshProUGUI totalRevenueText;

	public GameObject quotaReached;

	public GameObject quotaMissed;

	public GameObject nextDayButton;

	public GameObject restartDayButton;

	public GameObject finishGameButton;

	private bool alreadyCompleted;

	public int amountOfCompletions;

	public TextMeshProUGUI amountToLookAtText;

	public GameObject fadeOut;

	public SaveManager saveMan;

	public EODReportValues eodValues;

	public PlayAudioArray moneyAudioArray;

	public NPCFolder[] npcFolders;

	private bool shownQuotaGoal;

	private bool shownTickDown;

	public string[] npcNames;

	public string[] npcDescs;

	public Sprite[] npcIcons;

	public List<int> npcKilledID = new List<int>();

	public float todayMoneyLost;

	public float showingMoneyLoss;

	private bool tickRevenue;

	private bool tickDownRevenue;

	public GameObject noTickDownObj;

	public GameObject tickDownObj;

	public TextMeshProUGUI tickDownText;

	public int playerCount;

	[SerializeField]
	private DissonanceComms comms;

	private const string PrefKey = "voice.input.device";

	public bool hitQuota;

	private int curCharacterIndex;

	public static EndOfDayReport Instance { get; private set; }

	public void CompleteDay()
	{
		if (!alreadyCompleted)
		{
			alreadyCompleted = true;
			if (base.isServer)
			{
				Invoke("AnotherPlayerCompletedRpc", 0.5f);
				InvokeRepeating("CheckWhosCompletedDay", 1f, 1f);
			}
			else
			{
				Invoke("AnotherPlayerCompletedCmd", 0.5f);
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void AnotherPlayerCompletedCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void EndOfDayReport::AnotherPlayerCompletedCmd()", 1569209366, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void AnotherPlayerCompletedRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void EndOfDayReport::AnotherPlayerCompletedRpc()", -1895416567, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void CheckWhosCompletedDay()
	{
		if (amountOfCompletions >= playerCount)
		{
			if (base.isServer)
			{
				EveryoneConfirmNextRpc();
			}
			else
			{
				EveryoneConfirmNextCmd();
			}
		}
		amountToLookAtText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		amountToLookAtText.text = JSONAccess.Instance.GetMiscText("UI Text 4", "Waiting...") + " ( " + amountOfCompletions + " / " + playerCount + " )";
	}

	[Command(requiresAuthority = false)]
	private void EveryoneConfirmNextCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void EndOfDayReport::EveryoneConfirmNextCmd()", -1748091591, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void EveryoneConfirmNextRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void EndOfDayReport::EveryoneConfirmNextRpc()", -1646741814, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcUpdatePlayerCount(int count)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(count);
		SendRPCInternal("System.Void EndOfDayReport::RpcUpdatePlayerCount(System.Int32)", 1258966352, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void BackToGameScene()
	{
		if (base.isServer)
		{
			NetworkManager.singleton.ServerChangeScene("Game");
		}
	}

	public void Start()
	{
		Invoke("DoStartThings", 2f);
		ApplySavedMic();
	}

	public void ApplySavedMic()
	{
		if (comms == null)
		{
			comms = UnityEngine.Object.FindObjectOfType<DissonanceComms>(includeInactive: true);
		}
		if (comms == null)
		{
			Debug.LogError("[DissonanceMicSetter] No DissonanceComms found in scene.");
			return;
		}
		string text = PlayerPrefs.GetString("voice.input.device", string.Empty);
		string text2 = (string.IsNullOrEmpty(text) ? null : text);
		if (text2 != null && Array.IndexOf(Microphone.devices, text2) < 0)
		{
			text2 = null;
		}
		comms.MicrophoneName = text2;
		comms.IsMuted = false;
		Debug.Log("[DissonanceMicSetter] Applied mic: " + (text2 ?? "System Default"));
	}

	private void DoStartThings()
	{
		UnlockCursor();
		saveMan = SaveManager.Instance;
		eodValues = EODReportValues.Instance;
		if (base.isServer)
		{
			Invoke("StartTickingRevenue", 4.5f);
			GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
			for (int i = 0; i < array.Length; i++)
			{
				NetworkServer.Destroy(array[i]);
			}
			UpdateVariables(eodValues.todayMoneyGained, eodValues.todayMoneyLost, eodValues.npcKilledID, eodValues.mandatoryRevenue);
		}
	}

	[ClientRpc]
	private void UpdateVariables(float revenue, float moneyLost, List<int> killedID, float quota)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(revenue);
		writer.WriteFloat(moneyLost);
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(writer, killedID);
		writer.WriteFloat(quota);
		SendRPCInternal("System.Void EndOfDayReport::UpdateVariables(System.Single,System.Single,System.Collections.Generic.List`1<System.Int32>,System.Single)", 1133794981, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void StartTickingRevenue()
	{
		tickRevenue = true;
	}

	private void FixedUpdate()
	{
		if (tickRevenue && base.isServer)
		{
			TickRevenue();
		}
		if (tickDownRevenue && base.isServer)
		{
			TickDownRevenue();
		}
	}

	[ClientRpc]
	private void TickRevenue()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void EndOfDayReport::TickRevenue()", 1897817812, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void CheckTickDown()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void EndOfDayReport::CheckTickDown()", -1457805954, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void TickDownRevenue()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void EndOfDayReport::TickDownRevenue()", -1483171516, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void ShowQuota()
	{
		if (actualRevenue - todayMoneyLost >= eodValues.mandatoryRevenue)
		{
			ShowQuotaRpc(hitQuota_: true);
		}
		else
		{
			ShowQuotaRpc(hitQuota_: false);
		}
		if (base.isServer)
		{
			Invoke("ShowNextCharacter", 0.5f);
		}
	}

	[ClientRpc]
	private void ShowQuotaRpc(bool hitQuota_)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(hitQuota_);
		SendRPCInternal("System.Void EndOfDayReport::ShowQuotaRpc(System.Boolean)", -520126284, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void ShowNextCharacter()
	{
		if (curCharacterIndex >= eodValues.npcID.Count && base.isServer)
		{
			Invoke("ShowNextButton", 0.5f);
			return;
		}
		ShowNextCharacterRpc(eodValues.npcID[curCharacterIndex]);
		if (base.isServer)
		{
			Invoke("ShowNextCharacter", 0.5f);
		}
	}

	[ClientRpc]
	private void ShowNextCharacterRpc(int id)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(id);
		SendRPCInternal("System.Void EndOfDayReport::ShowNextCharacterRpc(System.Int32)", 393458644, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ShowNextButton()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void EndOfDayReport::ShowNextButton()", -825964513, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void EnableNextDayBTN()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void EndOfDayReport::EnableNextDayBTN()", 1936557067, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void EnableRestartDayBTN()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void EndOfDayReport::EnableRestartDayBTN()", 516056875, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void EnableFinishGameBTN()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void EndOfDayReport::EnableFinishGameBTN()", 100228109, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void ResetAllValues()
	{
		if ((bool)eodValues)
		{
			UnityEngine.Object.Destroy(eodValues.gameObject);
		}
	}

	public void FinishGame()
	{
		Invoke("LoadEndScene", 1f);
	}

	private void LoadEndScene()
	{
		if (base.isServer)
		{
			LoadEndSceneRpc();
		}
		else
		{
			LoadEndSceneCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void LoadEndSceneCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void EndOfDayReport::LoadEndSceneCmd()", 386613790, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void LoadEndSceneRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void EndOfDayReport::LoadEndSceneRpc()", 1612160417, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void ServerLoadEndScene()
	{
		SceneManager.LoadScene("EndMenu");
	}

	private void Awake()
	{
		Instance = this;
	}

	public void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public void UnlockCursor()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_AnotherPlayerCompletedCmd()
	{
		AnotherPlayerCompletedRpc();
	}

	protected static void InvokeUserCode_AnotherPlayerCompletedCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command AnotherPlayerCompletedCmd called on client.");
		}
		else
		{
			((EndOfDayReport)obj).UserCode_AnotherPlayerCompletedCmd();
		}
	}

	protected void UserCode_AnotherPlayerCompletedRpc()
	{
		if (base.isServer)
		{
			RpcUpdatePlayerCount(NetworkServer.connections.Count);
		}
		amountOfCompletions++;
		Invoke("CheckWhosCompletedDay", 0.2f);
		Invoke("CheckWhosCompletedDay", 0.5f);
		Invoke("CheckWhosCompletedDay", 1f);
		Invoke("CheckWhosCompletedDay", 1.5f);
		Invoke("CheckWhosCompletedDay", 2f);
		Invoke("CheckWhosCompletedDay", 5f);
		Invoke("CheckWhosCompletedDay", 10f);
	}

	protected static void InvokeUserCode_AnotherPlayerCompletedRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC AnotherPlayerCompletedRpc called on server.");
		}
		else
		{
			((EndOfDayReport)obj).UserCode_AnotherPlayerCompletedRpc();
		}
	}

	protected void UserCode_EveryoneConfirmNextCmd()
	{
		EveryoneConfirmNextRpc();
	}

	protected static void InvokeUserCode_EveryoneConfirmNextCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command EveryoneConfirmNextCmd called on client.");
		}
		else
		{
			((EndOfDayReport)obj).UserCode_EveryoneConfirmNextCmd();
		}
	}

	protected void UserCode_EveryoneConfirmNextRpc()
	{
		CancelInvoke("CheckWhosCompletedDay");
		ResetAllValues();
		fadeOut.SetActive(value: true);
		Invoke("BackToGameScene", 0.5f);
	}

	protected static void InvokeUserCode_EveryoneConfirmNextRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC EveryoneConfirmNextRpc called on server.");
		}
		else
		{
			((EndOfDayReport)obj).UserCode_EveryoneConfirmNextRpc();
		}
	}

	protected void UserCode_RpcUpdatePlayerCount__Int32(int count)
	{
		playerCount = count;
	}

	protected static void InvokeUserCode_RpcUpdatePlayerCount__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdatePlayerCount called on server.");
		}
		else
		{
			((EndOfDayReport)obj).UserCode_RpcUpdatePlayerCount__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_UpdateVariables__Single__Single__List_00601__Single(float revenue, float moneyLost, List<int> killedID, float quota)
	{
		actualRevenue = revenue;
		todayMoneyLost = moneyLost;
		npcKilledID = killedID;
		todaysQuotaText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		todaysQuotaText.text = JSONAccess.Instance.GetMiscText("UI Text 4", "MANDATORY REVENUE:") + " $" + quota.ToString("0");
	}

	protected static void InvokeUserCode_UpdateVariables__Single__Single__List_00601__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC UpdateVariables called on server.");
		}
		else
		{
			((EndOfDayReport)obj).UserCode_UpdateVariables__Single__Single__List_00601__Single(reader.ReadFloat(), reader.ReadFloat(), GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(reader), reader.ReadFloat());
		}
	}

	protected void UserCode_TickRevenue()
	{
		if (showingRevenue < actualRevenue)
		{
			if (actualRevenue - showingRevenue > 1f)
			{
				showingRevenue += 1f;
			}
			else
			{
				if (!shownTickDown)
				{
					if (base.isServer)
					{
						Invoke("CheckTickDown", 0.5f);
					}
					shownTickDown = true;
				}
				showingRevenue = actualRevenue;
			}
			moneyAudioArray.PlayAudio();
			totalRevenueText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			totalRevenueText.text = "$" + showingRevenue.ToString("0.00");
			return;
		}
		if (showingRevenue > actualRevenue)
		{
			if (showingRevenue - actualRevenue > 1f)
			{
				showingRevenue -= 1f;
			}
			else
			{
				if (!shownTickDown)
				{
					if (base.isServer)
					{
						Invoke("CheckTickDown", 0.5f);
					}
					shownTickDown = true;
				}
				showingRevenue = actualRevenue;
			}
			moneyAudioArray.PlayAudio();
			totalRevenueText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			totalRevenueText.text = "$" + showingRevenue.ToString("0.00");
			return;
		}
		if (!shownTickDown)
		{
			if (base.isServer)
			{
				Invoke("CheckTickDown", 0.5f);
			}
			shownTickDown = true;
		}
		showingRevenue = actualRevenue;
	}

	protected static void InvokeUserCode_TickRevenue(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC TickRevenue called on server.");
		}
		else
		{
			((EndOfDayReport)obj).UserCode_TickRevenue();
		}
	}

	protected void UserCode_CheckTickDown()
	{
		if (todayMoneyLost > 0f)
		{
			tickRevenue = false;
			tickDownRevenue = true;
			tickDownObj.SetActive(value: true);
		}
		else
		{
			noTickDownObj.SetActive(value: true);
			Invoke("ShowQuota", 0.5f);
		}
	}

	protected static void InvokeUserCode_CheckTickDown(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC CheckTickDown called on server.");
		}
		else
		{
			((EndOfDayReport)obj).UserCode_CheckTickDown();
		}
	}

	protected void UserCode_TickDownRevenue()
	{
		if (showingMoneyLoss < todayMoneyLost)
		{
			if (todayMoneyLost - showingMoneyLoss > 1f)
			{
				showingMoneyLoss += 1f;
			}
			else
			{
				if (!shownQuotaGoal)
				{
					if (base.isServer)
					{
						Invoke("ShowQuota", 0.5f);
					}
					shownQuotaGoal = true;
				}
				showingMoneyLoss = todayMoneyLost;
			}
			moneyAudioArray.PlayAudio();
			tickDownText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			tickDownText.text = "-$" + showingMoneyLoss.ToString("0.00");
			showingRevenue -= 1f;
			moneyAudioArray.PlayAudio();
			totalRevenueText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			totalRevenueText.text = "$" + showingRevenue.ToString("0.00");
		}
		else if (!shownQuotaGoal)
		{
			if (base.isServer)
			{
				Invoke("ShowQuota", 0.5f);
			}
			shownQuotaGoal = true;
		}
	}

	protected static void InvokeUserCode_TickDownRevenue(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC TickDownRevenue called on server.");
		}
		else
		{
			((EndOfDayReport)obj).UserCode_TickDownRevenue();
		}
	}

	protected void UserCode_ShowQuotaRpc__Boolean(bool hitQuota_)
	{
		if (hitQuota_)
		{
			hitQuota = true;
			quotaReached.SetActive(value: true);
		}
		else
		{
			hitQuota = false;
			quotaMissed.SetActive(value: true);
		}
	}

	protected static void InvokeUserCode_ShowQuotaRpc__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ShowQuotaRpc called on server.");
		}
		else
		{
			((EndOfDayReport)obj).UserCode_ShowQuotaRpc__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_ShowNextCharacterRpc__Int32(int id)
	{
		if (curCharacterIndex >= eodValues.npcID.Count && base.isServer)
		{
			ShowNextButton();
		}
		npcFolders[curCharacterIndex].nameText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		npcFolders[curCharacterIndex].nameText.text = JSONAccess.Instance.GetMiscText("EOD Report Names", id.ToString());
		npcFolders[curCharacterIndex].descText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		npcFolders[curCharacterIndex].descText.text = JSONAccess.Instance.GetMiscText("EOD Report Descs", id.ToString());
		npcFolders[curCharacterIndex].idPhoto.sprite = npcIcons[id];
		foreach (int item in npcKilledID)
		{
			if (item == id)
			{
				npcFolders[curCharacterIndex].killedIcon.SetActive(value: true);
			}
		}
		npcFolders[curCharacterIndex].gameObject.SetActive(value: true);
		curCharacterIndex++;
	}

	protected static void InvokeUserCode_ShowNextCharacterRpc__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ShowNextCharacterRpc called on server.");
		}
		else
		{
			((EndOfDayReport)obj).UserCode_ShowNextCharacterRpc__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_ShowNextButton()
	{
		if (base.isServer)
		{
			if (demo)
			{
				if (eodValues.curDay == 3)
				{
					EnableFinishGameBTN();
				}
				else if (hitQuota)
				{
					EnableNextDayBTN();
				}
				else
				{
					EnableRestartDayBTN();
				}
			}
			else if (hitQuota)
			{
				EnableNextDayBTN();
			}
			else
			{
				EnableRestartDayBTN();
			}
		}
		ResetAllValues();
	}

	protected static void InvokeUserCode_ShowNextButton(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ShowNextButton called on server.");
		}
		else
		{
			((EndOfDayReport)obj).UserCode_ShowNextButton();
		}
	}

	protected void UserCode_EnableNextDayBTN()
	{
		nextDayButton.SetActive(value: true);
	}

	protected static void InvokeUserCode_EnableNextDayBTN(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC EnableNextDayBTN called on server.");
		}
		else
		{
			((EndOfDayReport)obj).UserCode_EnableNextDayBTN();
		}
	}

	protected void UserCode_EnableRestartDayBTN()
	{
		restartDayButton.SetActive(value: true);
	}

	protected static void InvokeUserCode_EnableRestartDayBTN(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC EnableRestartDayBTN called on server.");
		}
		else
		{
			((EndOfDayReport)obj).UserCode_EnableRestartDayBTN();
		}
	}

	protected void UserCode_EnableFinishGameBTN()
	{
		finishGameButton.SetActive(value: true);
	}

	protected static void InvokeUserCode_EnableFinishGameBTN(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC EnableFinishGameBTN called on server.");
		}
		else
		{
			((EndOfDayReport)obj).UserCode_EnableFinishGameBTN();
		}
	}

	protected void UserCode_LoadEndSceneCmd()
	{
		LoadEndSceneRpc();
	}

	protected static void InvokeUserCode_LoadEndSceneCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command LoadEndSceneCmd called on client.");
		}
		else
		{
			((EndOfDayReport)obj).UserCode_LoadEndSceneCmd();
		}
	}

	protected void UserCode_LoadEndSceneRpc()
	{
		if (base.isServer)
		{
			Invoke("ServerLoadEndScene", 1f);
		}
		else
		{
			SceneManager.LoadScene("EndMenu");
		}
	}

	protected static void InvokeUserCode_LoadEndSceneRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC LoadEndSceneRpc called on server.");
		}
		else
		{
			((EndOfDayReport)obj).UserCode_LoadEndSceneRpc();
		}
	}

	static EndOfDayReport()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(EndOfDayReport), "System.Void EndOfDayReport::AnotherPlayerCompletedCmd()", InvokeUserCode_AnotherPlayerCompletedCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(EndOfDayReport), "System.Void EndOfDayReport::EveryoneConfirmNextCmd()", InvokeUserCode_EveryoneConfirmNextCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(EndOfDayReport), "System.Void EndOfDayReport::LoadEndSceneCmd()", InvokeUserCode_LoadEndSceneCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(EndOfDayReport), "System.Void EndOfDayReport::AnotherPlayerCompletedRpc()", InvokeUserCode_AnotherPlayerCompletedRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(EndOfDayReport), "System.Void EndOfDayReport::EveryoneConfirmNextRpc()", InvokeUserCode_EveryoneConfirmNextRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(EndOfDayReport), "System.Void EndOfDayReport::RpcUpdatePlayerCount(System.Int32)", InvokeUserCode_RpcUpdatePlayerCount__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(EndOfDayReport), "System.Void EndOfDayReport::UpdateVariables(System.Single,System.Single,System.Collections.Generic.List`1<System.Int32>,System.Single)", InvokeUserCode_UpdateVariables__Single__Single__List_00601__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(EndOfDayReport), "System.Void EndOfDayReport::TickRevenue()", InvokeUserCode_TickRevenue);
		RemoteProcedureCalls.RegisterRpc(typeof(EndOfDayReport), "System.Void EndOfDayReport::CheckTickDown()", InvokeUserCode_CheckTickDown);
		RemoteProcedureCalls.RegisterRpc(typeof(EndOfDayReport), "System.Void EndOfDayReport::TickDownRevenue()", InvokeUserCode_TickDownRevenue);
		RemoteProcedureCalls.RegisterRpc(typeof(EndOfDayReport), "System.Void EndOfDayReport::ShowQuotaRpc(System.Boolean)", InvokeUserCode_ShowQuotaRpc__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(EndOfDayReport), "System.Void EndOfDayReport::ShowNextCharacterRpc(System.Int32)", InvokeUserCode_ShowNextCharacterRpc__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(EndOfDayReport), "System.Void EndOfDayReport::ShowNextButton()", InvokeUserCode_ShowNextButton);
		RemoteProcedureCalls.RegisterRpc(typeof(EndOfDayReport), "System.Void EndOfDayReport::EnableNextDayBTN()", InvokeUserCode_EnableNextDayBTN);
		RemoteProcedureCalls.RegisterRpc(typeof(EndOfDayReport), "System.Void EndOfDayReport::EnableRestartDayBTN()", InvokeUserCode_EnableRestartDayBTN);
		RemoteProcedureCalls.RegisterRpc(typeof(EndOfDayReport), "System.Void EndOfDayReport::EnableFinishGameBTN()", InvokeUserCode_EnableFinishGameBTN);
		RemoteProcedureCalls.RegisterRpc(typeof(EndOfDayReport), "System.Void EndOfDayReport::LoadEndSceneRpc()", InvokeUserCode_LoadEndSceneRpc);
	}
}
