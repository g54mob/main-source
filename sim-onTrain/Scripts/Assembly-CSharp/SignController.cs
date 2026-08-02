using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class SignController : NetworkBehaviour, IInteractable
{
	[SerializeField]
	private bool isActive;

	[Header("References")]
	[Tooltip("Tabela uzerinde yazinin gosterilecegi dunya-uzayi TextMeshPro")]
	[SerializeField]
	private TMP_Text worldText;

	[SerializeField]
	private Transform interactionParent;

	[Header("Limits")]
	[Tooltip("Maksimum karakter sayisi")]
	public int maxCharacters = 60;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString writeSignLocalized;

	[SyncVar(hook = "OnSignTextChanged")]
	public string signText = "";

	private bool isShowingInteraction;

	private SignTextInputPanel inputPanel;

	public bool IsActive
	{
		get
		{
			return isActive;
		}
		set
		{
			isActive = value;
		}
	}

	public Transform InteractionParent
	{
		get
		{
			return interactionParent;
		}
		set
		{
			interactionParent = value;
		}
	}

	public string NetworksignText
	{
		get
		{
			return signText;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref signText, 1uL, OnSignTextChanged);
		}
	}

	private void Awake()
	{
		inputPanel = Object.FindObjectOfType<SignTextInputPanel>(includeInactive: true);
		isActive = true;
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		RefreshWorldText();
	}

	public void Interact(PlayerInventory player, Vector3 hitPoint)
	{
		if (IsActive)
		{
			InteractionPanel.Instance.ShowInteractionOverlay((interactionParent != null) ? interactionParent : base.transform, player.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, GetLocalizedString(writeSignLocalized, "Write"));
			isShowingInteraction = true;
			if (Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey) && !Singleton<MainUIManager>.Instance.isInGamePanelOpened && inputPanel != null)
			{
				Singleton<MainUIManager>.Instance.OnInGamePanelOpened.Invoke(inputPanel);
				inputPanel.Open(signText, maxCharacters, SubmitText);
			}
		}
	}

	public void StopInteract()
	{
		isShowingInteraction = false;
		InteractionPanel.Instance.HidePanels();
	}

	private void SubmitText(string newText)
	{
		if (newText == null)
		{
			newText = "";
		}
		if (newText.Length > maxCharacters)
		{
			newText = newText.Substring(0, maxCharacters);
		}
		CmdSetSignText(newText);
	}

	[Command(requiresAuthority = false)]
	public void CmdSetSignText(string newText)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(newText);
		SendCommandInternal("System.Void SignController::CmdSetSignText(System.String)", -1587128206, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void OnSignTextChanged(string oldText, string newText)
	{
		RefreshWorldText();
	}

	private void RefreshWorldText()
	{
		if (worldText != null)
		{
			worldText.text = signText;
		}
	}

	private void OnDestroy()
	{
		if (isShowingInteraction && InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HideInteraction();
		}
	}

	private void OnDisable()
	{
		if (isShowingInteraction && InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HideInteraction();
			isShowingInteraction = false;
		}
	}

	private string GetLocalizedString(LocalizedString localizedString, string fallback)
	{
		if (localizedString != null && !localizedString.IsEmpty)
		{
			string localizedString2 = localizedString.GetLocalizedString();
			if (!string.IsNullOrEmpty(localizedString2))
			{
				return localizedString2;
			}
		}
		return fallback;
	}

	public string SaveState()
	{
		return signText ?? "";
	}

	public void LoadState(string data)
	{
		if (base.isServer)
		{
			NetworksignText = data ?? "";
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSetSignText__String(string newText)
	{
		if (newText == null)
		{
			newText = "";
		}
		if (newText.Length > maxCharacters)
		{
			newText = newText.Substring(0, maxCharacters);
		}
		NetworksignText = newText;
	}

	protected static void InvokeUserCode_CmdSetSignText__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetSignText called on client.");
		}
		else
		{
			((SignController)obj).UserCode_CmdSetSignText__String(reader.ReadString());
		}
	}

	static SignController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(SignController), "System.Void SignController::CmdSetSignText(System.String)", InvokeUserCode_CmdSetSignText__String, requiresAuthority: false);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteString(signText);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteString(signText);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref signText, OnSignTextChanged, reader.ReadString());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref signText, OnSignTextChanged, reader.ReadString());
		}
	}
}
