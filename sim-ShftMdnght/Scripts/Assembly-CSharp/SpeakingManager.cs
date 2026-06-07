using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeakingManager : NetworkBehaviour
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

	public string curId;

	public string curKey;

	public string curName;

	public bool curOnlyClientSide;

	public DialogueInteractable curDialogueScript;

	public int curKeyIndex;

	public bool moreDialogueToScroll;

	public GameObject subtitleHolder;

	public TextMeshProUGUI subtitleText;

	public PlayAudioArray chatAudioArray;

	private bool playChatAudio;

	public bool stillScrollingText;

	public bool inChat;

	public Image[] chatLogImages;

	public Queue<ChatLogNode> chatQueue = new Queue<ChatLogNode>();

	public RectTransform chatContent;

	public GameObject chatLogNode;

	public Transform chatLogNodeHolder;

	public GameObject chatLogHolder;

	public float dialogueScrollSpeed;

	public TransactionManager transactionManager;

	public bool ignoreClicks;

	public static SpeakingManager Instance { get; private set; }

	private void Update()
	{
		if (Input.GetButtonDown("Fire1") && !ignoreClicks)
		{
			ClickNext();
		}
		if (Input.GetKeyDown(KeyCode.Escape) && inChat)
		{
			Image[] array = chatLogImages;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = false;
			}
			if (ClientPlayer.Instance.playerMan.canPause)
			{
				ClientPlayer.Instance.fpsScript.LockCursor();
				ClientPlayer.Instance.fpsScript.lockMove = false;
				ClientPlayer.Instance.fpsScript.lockCam = false;
			}
			foreach (ChatLogNode item in chatQueue)
			{
				item.anim.SetBool("Show", value: false);
			}
			ClientPlayer.Instance.playerMan.dontAllowLockCursor = false;
			Invoke("TurnOffInChat", 0.1f);
		}
		if (!Input.GetKeyDown("t") || ClientPlayer.Instance.playerMan.paused || !ClientPlayer.Instance.playerMan.canPause)
		{
			return;
		}
		if (inChat)
		{
			Image[] array = chatLogImages;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = false;
			}
			if (ClientPlayer.Instance.playerMan.canPause)
			{
				ClientPlayer.Instance.fpsScript.LockCursor();
				ClientPlayer.Instance.fpsScript.lockMove = false;
				ClientPlayer.Instance.fpsScript.lockCam = false;
			}
			foreach (ChatLogNode item2 in chatQueue)
			{
				item2.anim.SetBool("Show", value: false);
			}
			ClientPlayer.Instance.playerMan.dontAllowLockCursor = false;
		}
		else
		{
			Image[] array = chatLogImages;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = true;
			}
			if (ClientPlayer.Instance.playerMan.canPause)
			{
				ClientPlayer.Instance.fpsScript.UnlockCursor();
				ClientPlayer.Instance.fpsScript.lockMove = true;
				ClientPlayer.Instance.fpsScript.lockCam = true;
			}
			foreach (ChatLogNode item3 in chatQueue)
			{
				item3.anim.SetBool("Show", value: true);
			}
			ClientPlayer.Instance.playerMan.dontAllowLockCursor = true;
		}
		inChat = !inChat;
	}

	private void TurnOffInChat()
	{
		inChat = false;
	}

	private void SetText(string text, bool clientSideOnly)
	{
		if (!clientSideOnly)
		{
			AddChatLogNode(curName, text, 0);
		}
		ClientPlayer.Instance.playerMan.interactMan.checkForInteractables = false;
		subtitleHolder.SetActive(value: true);
		subtitleText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		if (curName != null)
		{
			subtitleText.text = curName + ": " + text;
		}
		else
		{
			subtitleText.text = text;
		}
		if ((bool)curDialogueScript)
		{
			curDialogueScript.mouthAnim.SetBool("Talking", value: true);
		}
		stillScrollingText = true;
		dialogueScrollSpeed = 0.01f;
		StartCoroutine(RevealTextUniversal());
	}

	private IEnumerator RevealTextUniversal()
	{
		subtitleText.ForceMeshUpdate();
		int total = subtitleText.textInfo.characterCount;
		subtitleText.maxVisibleCharacters = 0;
		stillScrollingText = true;
		float charProgress = 0f;
		int visible = 0;
		float audioTimer = 0f;
		while (visible < total)
		{
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			float num = Mathf.Max(1E-05f, dialogueScrollSpeed);
			charProgress += unscaledDeltaTime / num;
			int num2 = (int)charProgress;
			if (num2 > 0)
			{
				charProgress -= (float)num2;
				visible = Mathf.Min(total, visible + num2);
				subtitleText.maxVisibleCharacters = visible;
			}
			audioTimer += unscaledDeltaTime;
			while (audioTimer >= 0.03f && visible < total)
			{
				audioTimer -= 0.03f;
				chatAudioArray.PlayAudio();
			}
			yield return null;
		}
		if (curDialogueScript != null && (bool)curDialogueScript.mouthAnim)
		{
			curDialogueScript.mouthAnim.SetBool("Talking", value: false);
		}
		yield return new WaitForSecondsRealtime(0.2f);
		stillScrollingText = false;
	}

	public void ClickNext()
	{
		if (!subtitleHolder.activeInHierarchy)
		{
			if ((bool)ClientPlayer.Instance.playerMan.curNpcScript && !ClientPlayer.Instance.playerMan.curNpcScript.inQuestioningMenu)
			{
				ClientPlayer.Instance.playerMan.curNpcScript.ExitDialogue();
			}
			CancelAllDialogue();
			return;
		}
		if (stillScrollingText)
		{
			dialogueScrollSpeed = 1E-05f;
			return;
		}
		if (moreDialogueToScroll)
		{
			NextDialogueBranch();
			return;
		}
		if ((bool)ClientPlayer.Instance.playerMan.curNpcScript && !ClientPlayer.Instance.playerMan.curNpcScript.inQuestioningMenu)
		{
			ClientPlayer.Instance.playerMan.curNpcScript.ExitDialogue();
			ClientPlayer.Instance.playerMan.curNpcScript.ActuallyPersonallyExitDialogue();
		}
		CancelAllDialogue();
	}

	private void Start()
	{
		transactionManager = TransactionManager.Instance;
	}

	public void CancelAllDialogue()
	{
		StopAllCoroutines();
		subtitleText.text = "";
		subtitleText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		subtitleText.maxVisibleCharacters = 0;
		subtitleHolder.SetActive(value: false);
		ClientPlayer.Instance.playerMan.interactMan.checkForInteractables = true;
	}

	public void NewDialogueBranch(string id, string key, string nameInDialogue, DialogueInteractable dialogueScript, bool onlyClientSide = false)
	{
		curKeyIndex = 1;
		curId = id;
		curKey = key;
		curOnlyClientSide = onlyClientSide;
		curDialogueScript = dialogueScript;
		SetText(GetDialogueText(id, key, usesKeyIndex: true), curOnlyClientSide);
	}

	public void NextDialogueBranch()
	{
		curKeyIndex++;
		SetText(GetDialogueText(curId, curKey, usesKeyIndex: true), curOnlyClientSide);
	}

	public string GetDialogueText(string id, string key, bool usesKeyIndex)
	{
		string text = (usesKeyIndex ? curKeyIndex.ToString() : null);
		if (!TryGetDialogueEntryDict(id, out var dict))
		{
			return "[DIALOGUE NOT FOUND IN FILES]";
		}
		if (dict.TryGetValue("Name", out var value))
		{
			curName = value;
		}
		else
		{
			curName = id;
		}
		string key2 = key + text;
		if (dict.ContainsKey(key2))
		{
			moreDialogueToScroll = dict.ContainsKey(key + (curKeyIndex + 1));
			string text2 = dict[key2] ?? string.Empty;
			if (text2.StartsWith("<WRONG>", StringComparison.Ordinal))
			{
				text2 = text2.Substring(7);
			}
			return InsertLineBreaks(text2);
		}
		string key3 = "Unknown" + (curKeyIndex + 1);
		moreDialogueToScroll = dict.ContainsKey(key3);
		string key4 = "Unknown" + text;
		if (!dict.TryGetValue(key4, out var value2) || value2 == null)
		{
			return "[KEY NOT FOUND IN DIALOGUE FILES]";
		}
		if (value2.StartsWith("<WRONG>", StringComparison.Ordinal))
		{
			value2 = value2.Substring(7);
		}
		return InsertLineBreaks(value2);
	}

	private bool TryGetDialogueEntryDict(string id, out Dictionary<string, string> dict)
	{
		dict = null;
		if (JSONAccess.Instance == null)
		{
			return false;
		}
		return JSONAccess.Instance.TryGetEntryDictionaryFromDialogue(id, out dict);
	}

	private string InsertLineBreaks(string input, int interval = 50)
	{
		if (string.IsNullOrEmpty(input))
		{
			return input;
		}
		string text = PlayerPrefs.GetString("Language");
		bool flag = text == "JAPANESE" || text == "SIMPLIFIED CHINESE" || text == "TRADITIONAL CHINESE";
		if (flag)
		{
			interval = 25;
		}
		StringBuilder stringBuilder = new StringBuilder(input);
		int num = interval;
		while (num < stringBuilder.Length)
		{
			int num2 = -1;
			if (flag)
			{
				num2 = num;
			}
			else
			{
				int num3 = num;
				while (num3 > num - interval && num3 >= 0)
				{
					if (stringBuilder[num3] == ' ')
					{
						num2 = num3;
						break;
					}
					num3--;
				}
				if (num2 == -1)
				{
					for (int i = num; i < stringBuilder.Length; i++)
					{
						if (stringBuilder[i] == ' ')
						{
							num2 = i;
							break;
						}
					}
				}
				if (num2 == -1)
				{
					break;
				}
			}
			stringBuilder.Insert(num2, "<br>");
			if (!flag && stringBuilder[num2 + "<br>".Length] == ' ')
			{
				stringBuilder.Remove(num2 + "<br>".Length, 1);
			}
			num = num2 + "<br>".Length + interval;
		}
		return stringBuilder.ToString();
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	public void AddChatLogNode(string title, string text, int correctStatus)
	{
		if (base.isServer)
		{
			AddChatLogNodeRpc(title, text, correctStatus);
		}
		else
		{
			AddChatLogNodeCmd(title, text, correctStatus);
		}
	}

	[Command(requiresAuthority = false)]
	private void AddChatLogNodeCmd(string title, string text, int correctStatus)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(title);
		writer.WriteString(text);
		writer.WriteVarInt(correctStatus);
		SendCommandInternal("System.Void SpeakingManager::AddChatLogNodeCmd(System.String,System.String,System.Int32)", -2114508270, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void AddChatLogNodeRpc(string title, string text, int correctStatus)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(title);
		writer.WriteString(text);
		writer.WriteVarInt(correctStatus);
		SendRPCInternal("System.Void SpeakingManager::AddChatLogNodeRpc(System.String,System.String,System.Int32)", -774555003, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_AddChatLogNodeCmd__String__String__Int32(string title, string text, int correctStatus)
	{
		AddChatLogNodeRpc(title, text, correctStatus);
	}

	protected static void InvokeUserCode_AddChatLogNodeCmd__String__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command AddChatLogNodeCmd called on client.");
		}
		else
		{
			((SpeakingManager)obj).UserCode_AddChatLogNodeCmd__String__String__Int32(reader.ReadString(), reader.ReadString(), reader.ReadVarInt());
		}
	}

	protected void UserCode_AddChatLogNodeRpc__String__String__Int32(string title, string text, int correctStatus)
	{
		Vector2 anchoredPosition = chatContent.anchoredPosition;
		anchoredPosition.y = -349.5758f;
		chatContent.anchoredPosition = anchoredPosition;
		text = text.Replace("<br>", " ");
		ChatLogNode component = UnityEngine.Object.Instantiate(this.chatLogNode, chatLogNodeHolder).GetComponent<ChatLogNode>();
		component.Start_();
		component.nameText.text = title;
		component.subtitleText.text = text;
		component.nameText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		component.subtitleText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		chatQueue.Enqueue(component);
		if (chatQueue.Count > 10)
		{
			ChatLogNode chatLogNode = chatQueue.Dequeue();
			if (chatLogNode != null)
			{
				UnityEngine.Object.Destroy(chatLogNode.gameObject);
			}
		}
	}

	protected static void InvokeUserCode_AddChatLogNodeRpc__String__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC AddChatLogNodeRpc called on server.");
		}
		else
		{
			((SpeakingManager)obj).UserCode_AddChatLogNodeRpc__String__String__Int32(reader.ReadString(), reader.ReadString(), reader.ReadVarInt());
		}
	}

	static SpeakingManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(SpeakingManager), "System.Void SpeakingManager::AddChatLogNodeCmd(System.String,System.String,System.Int32)", InvokeUserCode_AddChatLogNodeCmd__String__String__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(SpeakingManager), "System.Void SpeakingManager::AddChatLogNodeRpc(System.String,System.String,System.Int32)", InvokeUserCode_AddChatLogNodeRpc__String__String__Int32);
	}
}
