using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using Steamworks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChatPanelController : NetworkBehaviour
{
	private static ChatPanelController _instance;

	[Header("UI Elements")]
	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private Text chatHistory;

	[SerializeField]
	private Scrollbar scrollbar;

	[SerializeField]
	private InputField chatMessage;

	[SerializeField]
	private Button sendButton;

	[Header("Auto-Hide Settings")]
	[SerializeField]
	private float autoHideDelay = 2f;

	[SerializeField]
	private float fadeDuration = 0.3f;

	[Header("Player Colors")]
	public List<Color> playerColors = new List<Color>
	{
		Color.cyan,
		Color.yellow,
		Color.green,
		Color.magenta,
		new Color(1f, 0.5f, 0f),
		Color.white
	};

	public static string localPlayerName;

	internal static readonly Dictionary<NetworkConnectionToClient, string> connNames;

	public bool isChatActive;

	public bool cheatsEnabled;

	public static bool isInputFocused;

	private Coroutine autoHideCoroutine;

	private Coroutine fadeCoroutine;

	private Coroutine activateInputCoroutine;

	private bool justSentMessage;

	private float panelOpenTime;

	private const string CHAT_LOCK_KEY = "chat";

	private List<string> messageHistory = new List<string>();

	private const int maxHistorySize = 30;

	private int messageHistoryIndex = -1;

	private string currentDraftMessage = "";

	public static ChatPanelController Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = UnityEngine.Object.FindObjectOfType<ChatPanelController>();
			}
			return _instance;
		}
	}

	private void Start()
	{
		if (_instance == null)
		{
			_instance = this;
		}
		else if (_instance != this)
		{
			Debug.LogWarning("Multiple ChatPanelController instances detected!");
		}
		if (canvasGroup == null)
		{
			canvasGroup = GetComponent<CanvasGroup>();
		}
		if (chatMessage != null)
		{
			chatMessage.onValueChanged.AddListener(ToggleButton);
			chatMessage.onEndEdit.AddListener(OnEndEdit);
		}
		if (sendButton != null)
		{
			sendButton.onClick.AddListener(SendChatMessage);
		}
		HidePanel(immediate: true);
	}

	private void OnDestroy()
	{
		if (_instance == this)
		{
			_instance = null;
		}
		if (chatMessage != null)
		{
			chatMessage.onValueChanged.RemoveListener(ToggleButton);
			chatMessage.onEndEdit.RemoveListener(OnEndEdit);
		}
		if (sendButton != null)
		{
			sendButton.onClick.RemoveListener(SendChatMessage);
		}
	}

	public override void OnStartServer()
	{
		connNames.Clear();
	}

	public override void OnStartClient()
	{
		if (chatHistory != null)
		{
			chatHistory.text = "";
		}
	}

	private void OnApplicationFocus(bool hasFocus)
	{
		if (!hasFocus && isChatActive)
		{
			isInputFocused = false;
			HidePanel(immediate: true);
		}
	}

	private void Update()
	{
		if (isChatActive && isInputFocused && !IsInputFieldFocused() && Time.unscaledTime - panelOpenTime > 1f)
		{
			isInputFocused = false;
			HidePanel();
			return;
		}
		if (cheatsEnabled && !IsInputFieldFocused() && Input.GetKeyDown(KeyCode.X))
		{
			SpawnCheatZombie();
		}
		if (isChatActive && IsInputFieldFocused() && messageHistory.Count > 0)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (messageHistoryIndex == -1)
				{
					currentDraftMessage = chatMessage.text;
					messageHistoryIndex = messageHistory.Count;
				}
				if (messageHistoryIndex > 0)
				{
					messageHistoryIndex--;
					chatMessage.text = messageHistory[messageHistoryIndex];
					chatMessage.caretPosition = chatMessage.text.Length;
				}
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow) && messageHistoryIndex != -1)
			{
				messageHistoryIndex++;
				if (messageHistoryIndex >= messageHistory.Count)
				{
					messageHistoryIndex = -1;
					chatMessage.text = currentDraftMessage;
				}
				else
				{
					chatMessage.text = messageHistory[messageHistoryIndex];
				}
				chatMessage.caretPosition = chatMessage.text.Length;
			}
		}
		if (Input.GetKeyDown(KeyCode.Return) && !IsInputFieldFocused() && !justSentMessage && (isChatActive || !(Singleton<MainUIManager>.Instance != null) || !Singleton<MainUIManager>.Instance.isInGamePanelOpened))
		{
			if (!isChatActive)
			{
				OpenPanel();
			}
			else if (string.IsNullOrWhiteSpace(chatMessage.text))
			{
				HidePanel();
			}
		}
	}

	private bool IsInputFieldFocused()
	{
		if (chatMessage == null)
		{
			return false;
		}
		if (EventSystem.current != null)
		{
			return EventSystem.current.currentSelectedGameObject == chatMessage.gameObject;
		}
		return false;
	}

	private void OpenPanel()
	{
		isChatActive = true;
		ShowPanel();
		TrainGameManager.RequestInputLock("chat");
		TrainGameManager.RequestMouseLock("chat");
		if (autoHideCoroutine != null)
		{
			StopCoroutine(autoHideCoroutine);
			autoHideCoroutine = null;
		}
		messageHistoryIndex = -1;
		currentDraftMessage = "";
		panelOpenTime = Time.unscaledTime;
		if (activateInputCoroutine != null)
		{
			StopCoroutine(activateInputCoroutine);
		}
		activateInputCoroutine = StartCoroutine(ActivateInputFieldDelayed());
	}

	private IEnumerator ActivateInputFieldDelayed()
	{
		yield return new WaitForSeconds(fadeDuration);
		yield return null;
		if (EventSystem.current != null)
		{
			EventSystem.current.SetSelectedGameObject(chatMessage.gameObject);
		}
		chatMessage.ActivateInputField();
		chatMessage.Select();
		yield return null;
		isInputFocused = true;
		activateInputCoroutine = null;
	}

	private void ShowPanel()
	{
		if (fadeCoroutine != null)
		{
			StopCoroutine(fadeCoroutine);
		}
		fadeCoroutine = StartCoroutine(FadePanel(1f));
	}

	private void HidePanel(bool immediate = false)
	{
		if (immediate || !chatMessage.isFocused)
		{
			isChatActive = false;
			if (activateInputCoroutine != null)
			{
				StopCoroutine(activateInputCoroutine);
				activateInputCoroutine = null;
			}
			chatMessage.DeactivateInputField();
			isInputFocused = false;
			if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject == chatMessage.gameObject)
			{
				EventSystem.current.SetSelectedGameObject(null);
			}
			TrainGameManager.ReleaseInputLock("chat");
			TrainGameManager.ReleaseMouseLock("chat");
			if (fadeCoroutine != null)
			{
				StopCoroutine(fadeCoroutine);
			}
			if (immediate)
			{
				canvasGroup.alpha = 0f;
				canvasGroup.interactable = false;
				canvasGroup.blocksRaycasts = false;
			}
			else
			{
				fadeCoroutine = StartCoroutine(FadePanel(0f));
			}
		}
	}

	private IEnumerator FadePanel(float targetAlpha)
	{
		float startAlpha = canvasGroup.alpha;
		float elapsed = 0f;
		while (elapsed < fadeDuration)
		{
			elapsed += Time.deltaTime;
			canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsed / fadeDuration);
			yield return null;
		}
		canvasGroup.alpha = targetAlpha;
		if (targetAlpha == 1f)
		{
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;
		}
		else
		{
			canvasGroup.interactable = false;
			canvasGroup.blocksRaycasts = false;
		}
		fadeCoroutine = null;
	}

	private void StartAutoHideTimer(float? customDelay = null)
	{
		if (autoHideCoroutine != null)
		{
			StopCoroutine(autoHideCoroutine);
		}
		float delay = customDelay ?? autoHideDelay;
		autoHideCoroutine = StartCoroutine(AutoHideCoroutine(delay));
	}

	private IEnumerator AutoHideCoroutine(float delay)
	{
		yield return new WaitForSeconds(delay);
		HidePanel();
		autoHideCoroutine = null;
	}

	[Command(requiresAuthority = false)]
	private void CmdSend(string message, NetworkConnectionToClient sender = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(message);
		SendCommandInternal("System.Void ChatPanelController::CmdSend(System.String,Mirror.NetworkConnectionToClient)", 632877152, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private string GetPlayerNameFromConnection(NetworkConnectionToClient conn)
	{
		if (conn != null && conn.identity != null)
		{
			TsNetworkPlayer component = conn.identity.GetComponent<TsNetworkPlayer>();
			if (component != null && !string.IsNullOrEmpty(component.playerName))
			{
				return component.playerName;
			}
		}
		return "Player_" + ((conn != null) ? conn.connectionId.ToString() : "Unknown");
	}

	private Color GetPlayerColor(string playerName)
	{
		if (Singleton<TSNetworkObjetManager>.Instance == null || Singleton<TSNetworkObjetManager>.Instance.playerConnections == null)
		{
			return Color.white;
		}
		GameObject gameObject = null;
		foreach (GameObject playerConnection in Singleton<TSNetworkObjetManager>.Instance.playerConnections)
		{
			if (playerConnection != null)
			{
				TsNetworkPlayer component = playerConnection.GetComponent<TsNetworkPlayer>();
				if (component != null && component.playerName == playerName)
				{
					gameObject = playerConnection;
					break;
				}
			}
		}
		if (gameObject == null)
		{
			return Color.white;
		}
		int num = Singleton<TSNetworkObjetManager>.Instance.playerConnections.IndexOf(gameObject);
		if (num < 0)
		{
			return Color.white;
		}
		int index = num % playerColors.Count;
		return playerColors[index];
	}

	[ClientRpc]
	private void RpcReceive(string playerName, string message)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(playerName);
		writer.WriteString(message);
		SendRPCInternal("System.Void ChatPanelController::RpcReceive(System.String,System.String)", -124922565, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void AppendMessage(string message)
	{
		StartCoroutine(AppendAndScroll(message));
	}

	private IEnumerator AppendAndScroll(string message)
	{
		Text text = chatHistory;
		text.text = text.text + message + "\n";
		yield return null;
		yield return null;
		scrollbar.value = 0f;
	}

	public void ToggleButton(string input)
	{
		sendButton.interactable = !string.IsNullOrWhiteSpace(input);
	}

	public void OnEndEdit(string input)
	{
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetButtonDown("Submit"))
		{
			SendChatMessage();
		}
	}

	public void SendChatMessage()
	{
		justSentMessage = true;
		StartCoroutine(ClearSentMessageFlag());
		if (string.IsNullOrWhiteSpace(chatMessage.text))
		{
			chatMessage.DeactivateInputField();
			isInputFocused = false;
			if (EventSystem.current != null)
			{
				EventSystem.current.SetSelectedGameObject(null);
			}
			isChatActive = false;
			TrainGameManager.ReleaseInputLock("chat");
			TrainGameManager.ReleaseMouseLock("chat");
			if (fadeCoroutine != null)
			{
				StopCoroutine(fadeCoroutine);
			}
			fadeCoroutine = StartCoroutine(FadePanel(0f));
			messageHistoryIndex = -1;
			currentDraftMessage = "";
			return;
		}
		string text = chatMessage.text.Trim();
		if (!string.IsNullOrEmpty(text))
		{
			if (messageHistory.Count == 0 || messageHistory[messageHistory.Count - 1] != text)
			{
				messageHistory.Add(text);
				if (messageHistory.Count > 30)
				{
					messageHistory.RemoveAt(0);
				}
			}
			messageHistoryIndex = -1;
			currentDraftMessage = "";
		}
		chatMessage.text = string.Empty;
		if (text.Trim() == "/creat?_?_x")
		{
			cheatsEnabled = true;
			AppendMessage("<color=yellow>[Sistem]: Cheat modları aktifleştirildi.</color>");
		}
		else if (text.StartsWith("/") && cheatsEnabled)
		{
			ProcessCheatCode(text.Substring(1).Trim());
		}
		else
		{
			CmdSend(text);
		}
		chatMessage.DeactivateInputField();
		isInputFocused = false;
		if (EventSystem.current != null)
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
		isChatActive = false;
		TrainGameManager.ReleaseInputLock("chat");
		TrainGameManager.ReleaseMouseLock("chat");
		if (fadeCoroutine != null)
		{
			StopCoroutine(fadeCoroutine);
		}
		fadeCoroutine = StartCoroutine(FadePanel(0f));
	}

	private IEnumerator ClearSentMessageFlag()
	{
		yield return new WaitForEndOfFrame();
		justSentMessage = false;
	}

	private void SpawnCheatZombie()
	{
		TrainGameManager instance = TrainGameManager.Instance;
		if (instance == null || instance.mainPlayer == null)
		{
			return;
		}
		TsPlayerNetworkHelper component = instance.mainPlayer.GetComponent<TsPlayerNetworkHelper>();
		if (!(component == null))
		{
			component.CmdCheatSpawnZombieNear(instance.mainPlayer.transform.position);
			if (Singleton<UserMessagePanel>.Instance != null)
			{
				Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Cheat: Zombie spawned nearby!");
			}
		}
	}

	private void ProcessCheatCode(string code)
	{
		string[] array = code.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length != 0)
		{
			string commandName = array[0];
			string[] array2 = new string[array.Length - 1];
			Array.Copy(array, 1, array2, 0, array2.Length);
			CheatCode cheatCode = CheatCodes.cheatCodes.Find((CheatCode x) => x.Code.Equals(commandName, StringComparison.OrdinalIgnoreCase));
			if (cheatCode != null)
			{
				ExecuteCheatCode(cheatCode.Type, array2);
			}
			else
			{
				Debug.Log("Bilinmeyen code: " + commandName);
			}
		}
	}

	private void ExecuteCheatCode(CheatCodeType cheatType, string[] args)
	{
		TrainGameManager instance = TrainGameManager.Instance;
		if (instance == null)
		{
			Debug.LogError("TrainGameManager bulunamadı!");
			return;
		}
		if (instance.mainPlayer == null)
		{
			Debug.LogError("Local player bulunamadı!");
			return;
		}
		TSPlayerController component = instance.mainPlayer.GetComponent<TSPlayerController>();
		if (component == null)
		{
			Debug.LogError("TSPlayerController component bulunamadı!");
			return;
		}
		TSPlayerStatusHolder component2 = component.GetComponent<TSPlayerStatusHolder>();
		TsPlayerNetworkHelper component3 = component.GetComponent<TsPlayerNetworkHelper>();
		switch (cheatType)
		{
		case CheatCodeType.CreativeMode:
			instance.currentGameMode = GameMode.Creative;
			if (component3 != null)
			{
				component3.CmdSetGameMode(GameMode.Creative);
			}
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Creative Mode activated!");
			if (component2 != null)
			{
				component2.playerHpFuel = 100f;
				component2.playerFoodFuel = 100f;
				component2.playerWaterFuel = 100f;
			}
			break;
		case CheatCodeType.SurvivalMode:
			instance.currentGameMode = GameMode.Survival;
			if (component3 != null)
			{
				component3.CmdSetGameMode(GameMode.Survival);
			}
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Survival Mode activated!");
			break;
		case CheatCodeType.HardcoreMode:
			instance.currentGameMode = GameMode.Hardcore;
			if (component3 != null)
			{
				component3.CmdSetGameMode(GameMode.Hardcore);
			}
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Hardcore Mode activated!");
			break;
		case CheatCodeType.HealPlayer:
			if (component2 != null)
			{
				component2.playerHpFuel = 100f;
				Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Health restored!");
			}
			break;
		case CheatCodeType.FeedMe:
			if (component2 != null)
			{
				component2.playerFoodFuel = 100f;
				Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Hunger restored!");
			}
			break;
		case CheatCodeType.WaterMe:
			if (component2 != null)
			{
				component2.playerWaterFuel = 100f;
				Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Thirst restored!");
			}
			break;
		case CheatCodeType.GiveItem:
			ExecuteGiveItem(args);
			break;
		case CheatCodeType.SetTime:
			ExecuteSetTime(args);
			break;
		case CheatCodeType.SkipNextTutorial:
			if (TSPlayerTutorialManager.Instance != null)
			{
				TSPlayerTutorialManager.Instance.SkipToNextTask();
				Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Tutorial task skipped!");
			}
			else
			{
				Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Tutorial manager not found!");
			}
			break;
		case CheatCodeType.RefillStamina:
		case CheatCodeType.GiveExperience:
		case CheatCodeType.LevelUp:
		case CheatCodeType.SpawnEnemy:
		case CheatCodeType.SpawnVehicle:
			break;
		}
	}

	private void ExecuteGiveItem(string[] args)
	{
		if (args.Length < 1)
		{
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Command Not Found");
			return;
		}
		string text = null;
		int num = 1;
		int num2 = -1;
		if (args.Length >= 2 && int.TryParse(args[^1], out var result) && result > 0)
		{
			num = result;
			num2 = args.Length - 1;
		}
		int num3 = 0;
		int num4 = ((num2 >= 0) ? (num2 - 1) : (args.Length - 1));
		if (args.Length >= 2 && FindPlayerByName(args[0]) != null)
		{
			text = args[0];
			num3 = 1;
		}
		if (num3 > num4)
		{
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Command Not Found");
			return;
		}
		List<string> list = new List<string>();
		for (int i = num3; i <= num4; i++)
		{
			list.Add(args[i]);
		}
		string itemName = string.Join(" ", list);
		CollectableItemData collectableItemData = Singleton<DataManager>.Instance.collectableDatas.Find((CollectableItemData x) => x.name.Equals(itemName, StringComparison.OrdinalIgnoreCase) || x.itemName.Equals(itemName, StringComparison.OrdinalIgnoreCase));
		if (collectableItemData == null)
		{
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Command Not Found");
			return;
		}
		TSPlayerController tSPlayerController;
		if (string.IsNullOrEmpty(text))
		{
			TrainGameManager instance = TrainGameManager.Instance;
			if (instance == null || instance.mainPlayer == null)
			{
				Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Command Not Found");
				return;
			}
			tSPlayerController = instance.mainPlayer.GetComponent<TSPlayerController>();
			if (tSPlayerController == null)
			{
				Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Command Not Found");
				return;
			}
		}
		else
		{
			tSPlayerController = FindPlayerByName(text);
			if (tSPlayerController == null)
			{
				Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Command Not Found");
				return;
			}
		}
		PlayerInventory component = tSPlayerController.GetComponent<PlayerInventory>();
		if (component == null)
		{
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Command Not Found");
			return;
		}
		if (!component.CanAddToInventory(collectableItemData, num))
		{
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Command Not Found");
			return;
		}
		component.AddItemInventory(collectableItemData, num, collectableItemData.startDurability);
		string playerDisplayName = GetPlayerDisplayName(tSPlayerController);
		Singleton<UserMessagePanel>.Instance.SendMessageToPanel($"Gave {num}x {collectableItemData.itemName} to {playerDisplayName}");
	}

	private TSPlayerController FindPlayerByName(string playerName)
	{
		TSPlayerController[] array = UnityEngine.Object.FindObjectsOfType<TSPlayerController>();
		foreach (TSPlayerController tSPlayerController in array)
		{
			TsNetworkPlayer component = tSPlayerController.GetComponent<TsNetworkPlayer>();
			if (component != null && component.playerName.Equals(playerName, StringComparison.OrdinalIgnoreCase))
			{
				return tSPlayerController;
			}
			try
			{
				if (SteamManager.Initialized && tSPlayerController.isLocalPlayer && SteamFriends.GetPersonaName().Equals(playerName, StringComparison.OrdinalIgnoreCase))
				{
					return tSPlayerController;
				}
			}
			catch
			{
			}
		}
		return null;
	}

	private string GetPlayerDisplayName(TSPlayerController player)
	{
		if (player == null)
		{
			return "Unknown";
		}
		TsNetworkPlayer component = player.GetComponent<TsNetworkPlayer>();
		if (component != null && !string.IsNullOrEmpty(component.playerName))
		{
			return component.playerName;
		}
		try
		{
			if (SteamManager.Initialized && player.isLocalPlayer)
			{
				string personaName = SteamFriends.GetPersonaName();
				if (!string.IsNullOrEmpty(personaName))
				{
					return personaName;
				}
			}
		}
		catch
		{
		}
		return "Unknown Player";
	}

	private void ExecuteSetTime(string[] args)
	{
		if (args.Length < 1)
		{
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Usage: /settime <hour> (0-24)");
			return;
		}
		if (!float.TryParse(args[0], out var result) || result < 0f || result > 24f)
		{
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Invalid time. Use 0-24");
			return;
		}
		if (TrainGameManager.Instance == null)
		{
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("TrainGameManager not found!");
			return;
		}
		CmdSetTime(result);
		Singleton<UserMessagePanel>.Instance.SendMessageToPanel($"Time set to {result:F1}");
	}

	[Command(requiresAuthority = false)]
	private void CmdSetTime(float hour)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(hour);
		SendCommandInternal("System.Void ChatPanelController::CmdSetTime(System.Single)", 1486044817, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	static ChatPanelController()
	{
		connNames = new Dictionary<NetworkConnectionToClient, string>();
		RemoteProcedureCalls.RegisterCommand(typeof(ChatPanelController), "System.Void ChatPanelController::CmdSend(System.String,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdSend__String__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ChatPanelController), "System.Void ChatPanelController::CmdSetTime(System.Single)", InvokeUserCode_CmdSetTime__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(ChatPanelController), "System.Void ChatPanelController::RpcReceive(System.String,System.String)", InvokeUserCode_RpcReceive__String__String);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSend__String__NetworkConnectionToClient(string message, NetworkConnectionToClient sender)
	{
		if (!connNames.ContainsKey(sender))
		{
			string playerNameFromConnection = GetPlayerNameFromConnection(sender);
			connNames.Add(sender, playerNameFromConnection);
		}
		if (!string.IsNullOrWhiteSpace(message))
		{
			RpcReceive(connNames[sender], message.Trim());
		}
	}

	protected static void InvokeUserCode_CmdSend__String__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSend called on client.");
		}
		else
		{
			((ChatPanelController)obj).UserCode_CmdSend__String__NetworkConnectionToClient(reader.ReadString(), senderConnection);
		}
	}

	protected void UserCode_RpcReceive__String__String(string playerName, string message)
	{
		string text = ColorUtility.ToHtmlStringRGB(GetPlayerColor(playerName));
		string message2 = "<color=#" + text + ">" + playerName + ":</color> " + message;
		AppendMessage(message2);
		ShowPanel();
		StartAutoHideTimer();
	}

	protected static void InvokeUserCode_RpcReceive__String__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcReceive called on server.");
		}
		else
		{
			((ChatPanelController)obj).UserCode_RpcReceive__String__String(reader.ReadString(), reader.ReadString());
		}
	}

	protected void UserCode_CmdSetTime__Single(float hour)
	{
		TrainGameManager instance = TrainGameManager.Instance;
		if (instance != null)
		{
			instance.NetworkcurrentTime = hour;
		}
	}

	protected static void InvokeUserCode_CmdSetTime__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetTime called on client.");
		}
		else
		{
			((ChatPanelController)obj).UserCode_CmdSetTime__Single(reader.ReadFloat());
		}
	}
}
