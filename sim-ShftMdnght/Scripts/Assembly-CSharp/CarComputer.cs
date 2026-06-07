using System;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CarComputer : Interactable
{
	[Serializable]
	public class DialogueEntry
	{
		public string name;

		public List<ValueEntry> values;
	}

	[Serializable]
	public class ValueEntry
	{
		public string key;

		public string value;
	}

	[Serializable]
	public class DialogueData
	{
		public List<DialogueEntry> entries;
	}

	public GameObject newCam;

	public new PlayerManager curPlayerMan;

	private bool interacting;

	public UnityEvent stopInteractEvent;

	public GameObject otherComputerCanvas;

	public TextMeshProUGUI regoText;

	public TextMeshProUGUI[] descObj;

	public GameObject emptyScrollView;

	public GameObject noResultsScrollView;

	public GameObject resultsWindow;

	public List<string> dBNames;

	public TextMeshProUGUI searchField;

	public string curDBName;

	public TMP_InputField inputText;

	public override void Interact(PlayerManager playerMan)
	{
		if (interactable)
		{
			base.enabled = true;
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
		}
	}

	public void StopInteract()
	{
		ClientPlayer.Instance.playerMan.interactMan.checkForInteractables = true;
		ClientPlayer.Instance.playerMan.dontAllowLockCursor = false;
		stopInteractEvent.Invoke();
		ClientPlayer.Instance.playerMan.Invoke("TurnPauseBackOn", 0.1f);
		ClientPlayer.Instance.inventoryMan.UnpauseUseItem();
		newCam.SetActive(value: false);
		ClientPlayer.Instance.fpsScript.playerCamera.gameObject.SetActive(value: true);
		ClientPlayer.Instance.fpsScript.lockMove = false;
		ClientPlayer.Instance.fpsScript.lockCam = false;
		ClientPlayer.Instance.fpsScript.LockCursor();
		interacting = false;
	}

	private void Update()
	{
		if (interacting && Input.GetKeyDown(KeyCode.Escape))
		{
			StopInteract();
		}
	}

	public void SearchOnAllClients()
	{
		if (base.isServer)
		{
			SearchOnAllClientsRpc(searchField.text);
		}
		else
		{
			SearchOnAllClientsCmd(searchField.text);
		}
	}

	[Command(requiresAuthority = false)]
	public void SearchOnAllClientsCmd(string s)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(s);
		SendCommandInternal("System.Void CarComputer::SearchOnAllClientsCmd(System.String)", 1824112928, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void SearchOnAllClientsRpc(string s)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(s);
		SendRPCInternal("System.Void CarComputer::SearchOnAllClientsRpc(System.String)", -871458371, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void Search()
	{
		noResultsScrollView.SetActive(value: false);
		noResultsScrollView.SetActive(value: true);
		emptyScrollView.SetActive(value: false);
		string text = searchField.text;
		new List<string>();
		new List<int>();
		text = text.Replace("\u200b", "").Replace("\u200c", "").Replace("\u200d", "");
		text = text.ToLower();
		if (text == "")
		{
			emptyScrollView.SetActive(value: false);
			emptyScrollView.SetActive(value: true);
			noResultsScrollView.SetActive(value: false);
		}
		bool flag = false;
		for (int i = 0; i < dBNames.Count; i++)
		{
			if (dBNames[i].Replace("\u200b", "").Replace("\u200c", "").Replace("\u200d", "")
				.ToLower() == text)
			{
				if ((bool)Car.Instance && text == Car.Instance.localizedCarLicencePlate.ToLower())
				{
					Car.Instance.carDescriptionQuestion.SetActive(value: true);
					Car.Instance.NewQuestioningTopicHint();
				}
				noResultsScrollView.SetActive(value: false);
				emptyScrollView.SetActive(value: false);
				resultsWindow.SetActive(value: false);
				resultsWindow.SetActive(value: true);
				flag = true;
				SetDescValues(text);
			}
		}
		if (!flag)
		{
			noResultsScrollView.SetActive(value: false);
			noResultsScrollView.SetActive(value: true);
			emptyScrollView.SetActive(value: false);
			resultsWindow.SetActive(value: false);
		}
	}

	public void SetDescValues(string plateInput)
	{
		curDBName = plateInput;
		for (int i = 0; i < descObj.Length; i++)
		{
			descObj[i].gameObject.SetActive(value: false);
		}
		if (JSONAccess.Instance == null)
		{
			Debug.LogError("JSONAccess.Instance is null.");
			return;
		}
		if (!JSONAccess.Instance.TryGetCarDatabaseEntryDict(plateInput, out var dict) || dict == null)
		{
			Debug.LogWarning("Car DB entry not found for '" + plateInput + "'.");
			return;
		}
		if (!dict.TryGetValue("Name", out var value) || string.IsNullOrWhiteSpace(value))
		{
			value = plateInput;
		}
		regoText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		regoText.text = value.ToUpperInvariant();
		for (int j = 1; j <= descObj.Length; j++)
		{
			string key = "DESC" + j;
			if (dict.TryGetValue(key, out var value2) && !string.IsNullOrWhiteSpace(value2))
			{
				int num = j - 1;
				descObj[num].font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
				descObj[num].gameObject.SetActive(value: true);
				descObj[num].text = value2;
				continue;
			}
			break;
		}
	}

	private void LoadDbNames()
	{
		dBNames.Clear();
		List<string> names;
		if (JSONAccess.Instance == null)
		{
			Debug.LogError("JSONAccess.Instance is null. Ensure JSONAccess exists in the scene before CarComputer.Awake.");
		}
		else if (!JSONAccess.Instance.TryGetCarDatabaseNames(out names) || names == null)
		{
			Debug.LogError("Failed to load Car DB names. If on Android/WebGL, ensure PreloadCarDatabaseAsync() ran first.");
		}
		else
		{
			dBNames.AddRange(names);
		}
	}

	private void Awake()
	{
		LoadDbNames();
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_SearchOnAllClientsCmd__String(string s)
	{
		SearchOnAllClientsRpc(s);
	}

	protected static void InvokeUserCode_SearchOnAllClientsCmd__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SearchOnAllClientsCmd called on client.");
		}
		else
		{
			((CarComputer)obj).UserCode_SearchOnAllClientsCmd__String(reader.ReadString());
		}
	}

	protected void UserCode_SearchOnAllClientsRpc__String(string s)
	{
		inputText.text = s;
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
			((CarComputer)obj).UserCode_SearchOnAllClientsRpc__String(reader.ReadString());
		}
	}

	static CarComputer()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(CarComputer), "System.Void CarComputer::SearchOnAllClientsCmd(System.String)", InvokeUserCode_SearchOnAllClientsCmd__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(CarComputer), "System.Void CarComputer::SearchOnAllClientsRpc(System.String)", InvokeUserCode_SearchOnAllClientsRpc__String);
	}
}
