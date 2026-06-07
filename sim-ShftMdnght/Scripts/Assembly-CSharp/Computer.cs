using System;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Computer : Interactable
{
	public GameObject newCam;

	public new PlayerManager curPlayerMan;

	private bool interacting;

	public GameObject tutorialScreen;

	public UnityEvent stopInteractEvent;

	public AudioSource dialoguePickSFX;

	public GameObject otherComputerCanvas;

	public GameObject computerScreen;

	private bool justAskedQuestion;

	public GameObject personWindow;

	public TextMeshProUGUI nameText;

	public Image idPhoto;

	public TextMeshProUGUI dobText;

	public TextMeshProUGUI statusText;

	public GameObject descButton;

	public Transform descScrollRect;

	public List<GameObject> descList;

	public GameObject emptyScrollView;

	public GameObject resultsScrollView;

	public GameObject noResultsScrollView;

	public Sprite emptyIdPhoto;

	public List<string> dBNames;

	public List<string> dBShowingNames;

	public GameObject resultButton;

	public TextMeshProUGUI searchField;

	public Transform resultsHolder;

	public string curDBName;

	public string curShowingName;

	public List<GameObject> resultsList;

	public bool npcAtCounter;

	public DialogueInteractable dialogueScript;

	public TMP_InputField inputText;

	public static Computer Instance { get; private set; }

	public override void Interact(PlayerManager playerMan)
	{
		if (interactable)
		{
			playerMan.lookingAtComputer = true;
			justAskedQuestion = false;
			if ((bool)StoreManager.Instance.dialogueTutorialCanv)
			{
				StoreManager.Instance.dialogueTutorialCanv.SetActive(value: false);
			}
			ClientPlayer.Instance.playerMan.dontAllowLockCursor = true;
			playerMan.canPause = false;
			ClientPlayer.Instance.inventoryMan.PauseUseItem();
			if (interactSFX != null)
			{
				interactSFX.Play();
			}
			if (interactAnim != null)
			{
				interactAnim.SetTrigger("Interact");
			}
			ClientPlayer.Instance.playerMan.interactMan.checkForInteractables = false;
			interactEvent.Invoke();
			base.StopLookAt();
			newCam.SetActive(value: true);
			playerMan.fpsScript.playerCamera.gameObject.SetActive(value: false);
			curPlayerMan = playerMan;
			playerMan.fpsScript.lockMove = true;
			playerMan.fpsScript.lockCam = true;
			curPlayerMan.fpsScript.UnlockCursor();
			interacting = true;
			PlayerPrefs.SetInt("CheckedComputer", 1);
			if (CurrentDayManager.Instance.curDay == 1 && CurrentDayManager.Instance.curOccurrence < 2 && !DialogueTutorialManager.Instance.questionedOccupation.gameObject.activeInHierarchy && !DialogueTutorialManager.Instance.questionedOccupation.sprite != !DialogueTutorialManager.Instance.tickedCheckbox)
			{
				tutorialScreen.SetActive(value: true);
			}
		}
	}

	public void TurnOffComputer()
	{
		computerScreen.SetActive(value: false);
		ChangeInteractableStatus(change: false);
	}

	[ClientRpc]
	public void TurnOnComputer()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Computer::TurnOnComputer()", -478251327, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void Wishlist()
	{
		Application.OpenURL("https://store.steampowered.com/app/3722330/Shift_At_Midnight/");
	}

	public void StopInteract()
	{
		PurchaseManager.Instance.UnhoverInfo();
		ClientPlayer.Instance.playerMan.interactMan.checkForInteractables = true;
		ClientPlayer.Instance.playerMan.lookingAtComputer = false;
		if ((bool)StoreManager.Instance.dialogueTutorialCanv)
		{
			StoreManager.Instance.dialogueTutorialCanv.SetActive(value: true);
		}
		ClientPlayer.Instance.playerMan.dontAllowLockCursor = false;
		stopInteractEvent.Invoke();
		tutorialScreen.SetActive(value: false);
		ClientPlayer.Instance.playerMan.Invoke("TurnPauseBackOn", 0.1f);
		ClientPlayer.Instance.inventoryMan.UnpauseUseItem();
		newCam.SetActive(value: false);
		curPlayerMan = ClientPlayer.Instance.playerMan;
		if (!curPlayerMan.dontAllowLockCursor && !curPlayerMan.lookingAtShelf && !curPlayerMan.lookingAtComputer && !curPlayerMan.paused)
		{
			ClientPlayer.Instance.fpsScript.playerCamera.gameObject.SetActive(value: true);
			ClientPlayer.Instance.fpsScript.lockMove = false;
			ClientPlayer.Instance.fpsScript.lockCam = false;
			ClientPlayer.Instance.fpsScript.LockCursor();
		}
		interacting = false;
	}

	private void Update()
	{
		if (interacting && Input.GetKeyDown(KeyCode.Escape))
		{
			StopInteract();
		}
	}

	public void ClickResult(string index)
	{
		if (base.isServer)
		{
			ClickResultRpc(index);
		}
		else
		{
			ClickResultCmd(index);
		}
	}

	[Command(requiresAuthority = false)]
	public void ClickResultCmd(string index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(index);
		SendCommandInternal("System.Void Computer::ClickResultCmd(System.String)", 2053174557, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ClickResultRpc(string index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(index);
		SendRPCInternal("System.Void Computer::ClickResultRpc(System.String)", -1614751516, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SetIDValues(string name)
	{
		curDBName = name;
		if (string.IsNullOrWhiteSpace(name))
		{
			return;
		}
		bool flag = false;
		string item = name.ToLowerInvariant().Replace(" ", "");
		if (SaveManager.Instance != null && SaveManager.Instance.npcsKilled != null && (from k in SaveManager.Instance.npcsKilled
			where !string.IsNullOrWhiteSpace(k)
			select k.ToLowerInvariant().Replace(" ", "")).ToHashSet().Contains(item))
		{
			flag = true;
		}
		foreach (GameObject desc in descList)
		{
			UnityEngine.Object.Destroy(desc);
		}
		descList.Clear();
		if (JSONAccess.Instance == null)
		{
			Debug.LogError("JSONAccess.Instance is null.");
			return;
		}
		if (!JSONAccess.Instance.TryGetIDDatabaseEntryDict(name, out var dict) || dict == null)
		{
			Debug.LogWarning("Name '" + name + "' not found in ID Database.");
			return;
		}
		dict.TryGetValue("DOB", out var value);
		dict.TryGetValue("PHOTO ID", out var value2);
		if (!flag)
		{
			if (int.TryParse(value2, out var result) && result >= 0)
			{
				if (TransactionManager.Instance != null && TransactionManager.Instance.idPhotos != null && result < TransactionManager.Instance.idPhotos.Length)
				{
					idPhoto.sprite = TransactionManager.Instance.idPhotos[result];
				}
				else
				{
					idPhoto.sprite = emptyIdPhoto;
				}
			}
			else
			{
				idPhoto.sprite = emptyIdPhoto;
			}
			dobText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			dobText.text = value ?? string.Empty;
			statusText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			statusText.text = JSONAccess.Instance.GetStatus(name);
			int num = 1;
			while (true)
			{
				string key = "DESC" + num;
				if (dict.TryGetValue(key, out var value3))
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(descButton, descScrollRect);
					SearchResultButton component = gameObject.GetComponent<SearchResultButton>();
					component.nameText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
					component.nameText.text = value3 ?? string.Empty;
					component.descIndex = num;
					descList.Add(gameObject);
					num++;
					continue;
				}
				break;
			}
		}
		else
		{
			idPhoto.sprite = emptyIdPhoto;
			dobText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			dobText.text = value ?? string.Empty;
			statusText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			statusText.text = JSONAccess.Instance.GetMiscText("UI Text 4", "Deceased");
			GameObject gameObject2 = UnityEngine.Object.Instantiate(descButton, descScrollRect);
			SearchResultButton component2 = gameObject2.GetComponent<SearchResultButton>();
			component2.nameText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			component2.nameText.text = JSONAccess.Instance.GetMiscText("UI Text 4", "CAUSE OF DEATH: Unknown");
			component2.descIndex = -1;
			descList.Add(gameObject2);
		}
	}

	public void CloseResult()
	{
		if (base.isServer)
		{
			CloseResultRpc();
		}
		else
		{
			CloseResultCmd();
		}
	}

	[Command(requiresAuthority = false)]
	public void CloseResultCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Computer::CloseResultCmd()", 1568374289, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void CloseResultRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Computer::CloseResultRpc()", -1445092110, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SearchOnAllClients()
	{
		string text = searchField.text;
		if (base.isServer)
		{
			SearchOnAllClientsRpc(text);
		}
		else
		{
			SearchOnAllClientsCmd(text);
		}
	}

	[Command(requiresAuthority = false)]
	public void SearchOnAllClientsCmd(string txt)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(txt);
		SendCommandInternal("System.Void Computer::SearchOnAllClientsCmd(System.String)", 463660854, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void SearchOnAllClientsRpc(string txt)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(txt);
		SendRPCInternal("System.Void Computer::SearchOnAllClientsRpc(System.String)", 113410087, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void Search()
	{
		foreach (GameObject results in resultsList)
		{
			UnityEngine.Object.Destroy(results);
		}
		resultsList = new List<GameObject>();
		noResultsScrollView.SetActive(value: false);
		emptyScrollView.SetActive(value: false);
		resultsScrollView.SetActive(value: true);
		string text = searchField.text;
		List<string> list = new List<string>();
		List<int> list2 = new List<int>();
		text = text.Replace("\u200b", "").Replace("\u200c", "").Replace("\u200d", "");
		text = text.ToLower();
		if (text == "")
		{
			emptyScrollView.SetActive(value: true);
			resultsScrollView.SetActive(value: false);
		}
		for (int i = 0; i < dBShowingNames.Count; i++)
		{
			string text2 = dBShowingNames[i].Replace("\u200b", "").Replace("\u200c", "").Replace("\u200d", "");
			text2 = text2.ToLower();
			bool flag = false;
			if (text2.StartsWith(text))
			{
				flag = true;
			}
			else if (text.Length > 3 && Math.Abs(text2.Length - text.Length) <= 2)
			{
				int num = 0;
				int num2 = Math.Min(text2.Length, text.Length);
				for (int j = 0; j < num2; j++)
				{
					if (text2[j] != text[j])
					{
						num++;
						if (num > 2)
						{
							break;
						}
					}
				}
				if (num <= 2)
				{
					flag = true;
				}
			}
			if (flag)
			{
				list.Add(dBNames[i]);
				list2.Add(i);
			}
		}
		if (list.Count == 0)
		{
			noResultsScrollView.SetActive(value: true);
			emptyScrollView.SetActive(value: false);
			resultsScrollView.SetActive(value: false);
			return;
		}
		foreach (string item in list)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(resultButton, resultsHolder);
			gameObject.GetComponent<SearchResultButton>().nameText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			gameObject.GetComponent<SearchResultButton>().nameText.text = JSONAccess.Instance.GetShowingName(item);
			gameObject.GetComponent<SearchResultButton>().dbName = item;
			gameObject.GetComponent<SearchResultButton>().statusText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			gameObject.GetComponent<SearchResultButton>().statusText.text = JSONAccess.Instance.GetStatus(item);
			resultsList.Add(gameObject);
		}
	}

	private void LoadDbNames()
	{
		dBNames.Clear();
		if (JSONAccess.Instance == null)
		{
			Debug.LogError("JSONAccess.Instance is null.");
			return;
		}
		if (!JSONAccess.Instance.TryGetIDDatabaseNames(out var realNames, out var showingNames))
		{
			Debug.LogError("Failed to load ID Database names (cache not loaded / file missing / decrypt failed).");
			return;
		}
		dBNames.AddRange(realNames);
		dBShowingNames.AddRange(showingNames);
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		LoadDbNames();
	}

	public void CheckDesc(int descIndex)
	{
		if (descIndex == 1)
		{
			DialogueTutorialManager.Instance.QuestionedOccupation();
		}
		if (!npcAtCounter)
		{
			StoreManager.Instance.SetAlert("There is no one at the counter.", "red");
			return;
		}
		if ((bool)dialogueScript && !dialogueScript.interactable)
		{
			StoreManager.Instance.SetAlert("This person is busy.", "red");
			return;
		}
		if (StoreManager.Instance.examinationsRemaining < 1)
		{
			StoreManager.Instance.outOfQuestions.SetActive(value: false);
			StoreManager.Instance.outOfQuestions.SetActive(value: true);
			StoreManager.Instance.SetExaminationsRemaining(0);
			return;
		}
		if (CurrentDayManager.Instance.curDay == 1 && CurrentDayManager.Instance.curOccurrence < 2)
		{
			StoreManager.Instance.SetExaminationsRemaining(StoreManager.Instance.examinationsRemaining - 1);
		}
		interacting = false;
		StopInteract();
		SpeakingManager.Instance.chatLogHolder.SetActive(value: false);
		SpeakingManager.Instance.NewDialogueBranch(dialogueScript.dialogueId, curDBName + " DESC" + descIndex, null, dialogueScript);
		dialogueScript.EnterDialogue();
		dialoguePickSFX.Play();
		ClientPlayer.Instance.playerMan.CancelInvoke("TurnPauseBackOn");
		curPlayerMan.canPause = false;
		ClientPlayer.Instance.playerMan.curNpcScript = dialogueScript;
	}

	public void CheckStatus()
	{
		if (!npcAtCounter)
		{
			StoreManager.Instance.SetAlert("There is no one at the counter.", "red");
			return;
		}
		if ((bool)dialogueScript && !dialogueScript.interactable)
		{
			StoreManager.Instance.SetAlert("This person is busy.", "red");
			return;
		}
		if (StoreManager.Instance.examinationsRemaining < 1)
		{
			StoreManager.Instance.outOfQuestions.SetActive(value: false);
			StoreManager.Instance.outOfQuestions.SetActive(value: true);
			StoreManager.Instance.SetExaminationsRemaining(0);
			return;
		}
		if (CurrentDayManager.Instance.curDay == 1 && CurrentDayManager.Instance.curOccurrence < 2)
		{
			StoreManager.Instance.SetExaminationsRemaining(StoreManager.Instance.examinationsRemaining - 1);
		}
		interacting = false;
		StopInteract();
		SpeakingManager.Instance.chatLogHolder.SetActive(value: false);
		SpeakingManager.Instance.NewDialogueBranch(dialogueScript.dialogueId, curDBName + " STATUS", null, dialogueScript);
		dialogueScript.EnterDialogue();
		dialoguePickSFX.Play();
		ClientPlayer.Instance.playerMan.CancelInvoke("TurnPauseBackOn");
		curPlayerMan.canPause = false;
		ClientPlayer.Instance.playerMan.curNpcScript = dialogueScript;
	}

	public void CheckDOB()
	{
		if (!npcAtCounter)
		{
			StoreManager.Instance.SetAlert("There is no one at the counter.", "red");
			return;
		}
		if ((bool)dialogueScript && !dialogueScript.interactable)
		{
			StoreManager.Instance.SetAlert("This person is busy.", "red");
			return;
		}
		if (StoreManager.Instance.examinationsRemaining < 1)
		{
			StoreManager.Instance.outOfQuestions.SetActive(value: false);
			StoreManager.Instance.outOfQuestions.SetActive(value: true);
			StoreManager.Instance.SetExaminationsRemaining(0);
			return;
		}
		if (CurrentDayManager.Instance.curDay == 1 && CurrentDayManager.Instance.curOccurrence < 2)
		{
			StoreManager.Instance.SetExaminationsRemaining(StoreManager.Instance.examinationsRemaining - 1);
		}
		interacting = false;
		StopInteract();
		SpeakingManager.Instance.chatLogHolder.SetActive(value: false);
		SpeakingManager.Instance.NewDialogueBranch(dialogueScript.dialogueId, curDBName + " DOB", null, dialogueScript);
		dialogueScript.EnterDialogue();
		dialoguePickSFX.Play();
		ClientPlayer.Instance.playerMan.CancelInvoke("TurnPauseBackOn");
		curPlayerMan.canPause = false;
		ClientPlayer.Instance.playerMan.curNpcScript = dialogueScript;
	}

	public void CheckPicture()
	{
		if (!npcAtCounter)
		{
			StoreManager.Instance.SetAlert("There is no one at the counter.", "red");
			return;
		}
		if ((bool)dialogueScript && !dialogueScript.interactable)
		{
			StoreManager.Instance.SetAlert("This person is busy.", "red");
			return;
		}
		if (StoreManager.Instance.examinationsRemaining < 1)
		{
			StoreManager.Instance.outOfQuestions.SetActive(value: false);
			StoreManager.Instance.outOfQuestions.SetActive(value: true);
			StoreManager.Instance.SetExaminationsRemaining(0);
			return;
		}
		if (CurrentDayManager.Instance.curDay == 1 && CurrentDayManager.Instance.curOccurrence < 2)
		{
			StoreManager.Instance.SetExaminationsRemaining(StoreManager.Instance.examinationsRemaining - 1);
		}
		interacting = false;
		StopInteract();
		SpeakingManager.Instance.chatLogHolder.SetActive(value: false);
		SpeakingManager.Instance.NewDialogueBranch(dialogueScript.dialogueId, curDBName + " Photo", null, dialogueScript);
		dialogueScript.EnterDialogue();
		dialoguePickSFX.Play();
		ClientPlayer.Instance.playerMan.CancelInvoke("TurnPauseBackOn");
		curPlayerMan.canPause = false;
		ClientPlayer.Instance.playerMan.curNpcScript = dialogueScript;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_TurnOnComputer()
	{
		computerScreen.SetActive(value: true);
		ChangeInteractableStatus(change: true);
	}

	protected static void InvokeUserCode_TurnOnComputer(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC TurnOnComputer called on server.");
		}
		else
		{
			((Computer)obj).UserCode_TurnOnComputer();
		}
	}

	protected void UserCode_ClickResultCmd__String(string index)
	{
		ClickResultRpc(index);
	}

	protected static void InvokeUserCode_ClickResultCmd__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ClickResultCmd called on client.");
		}
		else
		{
			((Computer)obj).UserCode_ClickResultCmd__String(reader.ReadString());
		}
	}

	protected void UserCode_ClickResultRpc__String(string index)
	{
		SetIDValues(index);
		personWindow.SetActive(value: true);
		nameText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		nameText.text = JSONAccess.Instance.GetShowingName(index).ToUpper();
	}

	protected static void InvokeUserCode_ClickResultRpc__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ClickResultRpc called on server.");
		}
		else
		{
			((Computer)obj).UserCode_ClickResultRpc__String(reader.ReadString());
		}
	}

	protected void UserCode_CloseResultCmd()
	{
		CloseResultRpc();
	}

	protected static void InvokeUserCode_CloseResultCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CloseResultCmd called on client.");
		}
		else
		{
			((Computer)obj).UserCode_CloseResultCmd();
		}
	}

	protected void UserCode_CloseResultRpc()
	{
		personWindow.SetActive(value: false);
	}

	protected static void InvokeUserCode_CloseResultRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC CloseResultRpc called on server.");
		}
		else
		{
			((Computer)obj).UserCode_CloseResultRpc();
		}
	}

	protected void UserCode_SearchOnAllClientsCmd__String(string txt)
	{
		SearchOnAllClientsRpc(txt);
	}

	protected static void InvokeUserCode_SearchOnAllClientsCmd__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SearchOnAllClientsCmd called on client.");
		}
		else
		{
			((Computer)obj).UserCode_SearchOnAllClientsCmd__String(reader.ReadString());
		}
	}

	protected void UserCode_SearchOnAllClientsRpc__String(string txt)
	{
		inputText.text = txt;
		Search();
	}

	protected static void InvokeUserCode_SearchOnAllClientsRpc__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SearchOnAllClientsRpc called on server.");
		}
		else
		{
			((Computer)obj).UserCode_SearchOnAllClientsRpc__String(reader.ReadString());
		}
	}

	static Computer()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(Computer), "System.Void Computer::ClickResultCmd(System.String)", InvokeUserCode_ClickResultCmd__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Computer), "System.Void Computer::CloseResultCmd()", InvokeUserCode_CloseResultCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Computer), "System.Void Computer::SearchOnAllClientsCmd(System.String)", InvokeUserCode_SearchOnAllClientsCmd__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(Computer), "System.Void Computer::TurnOnComputer()", InvokeUserCode_TurnOnComputer);
		RemoteProcedureCalls.RegisterRpc(typeof(Computer), "System.Void Computer::ClickResultRpc(System.String)", InvokeUserCode_ClickResultRpc__String);
		RemoteProcedureCalls.RegisterRpc(typeof(Computer), "System.Void Computer::CloseResultRpc()", InvokeUserCode_CloseResultRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(Computer), "System.Void Computer::SearchOnAllClientsRpc(System.String)", InvokeUserCode_SearchOnAllClientsRpc__String);
	}
}
