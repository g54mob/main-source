using System.Collections;
using System.Runtime.InteropServices;
using DG.Tweening;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Localization;

public class TrainBreak : NetworkBehaviour, IInteractable
{
	[Header("Break Settings")]
	[SerializeField]
	private Transform breakLever;

	[SerializeField]
	private Vector3 trainBreakOffRotation = Vector3.zero;

	[SerializeField]
	private Vector3 trainBreakOnRotation = new Vector3(45f, 0f, 0f);

	[SerializeField]
	private float animationDuration = 1f;

	[Header("Interaction")]
	[SerializeField]
	private Transform interactionParent;

	[Header("Custom Interaction Distance")]
	[SerializeField]
	private float customInteractionDistance = 2f;

	[Header("References")]
	private TrainController trainController;

	private bool isProcessingAction;

	[Header("Network Sync")]
	[SyncVar(hook = "OnBreakStateChanged")]
	private bool isBreakOn = true;

	public InteractionPanel interactionPanel;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString applyBrakeLocalized;

	[SerializeField]
	private LocalizedString releaseBrakeLocalized;

	[Header("Debug")]
	[SerializeField]
	private bool debugMode;

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

	public bool IsActive { get; set; }

	public float CustomInteractionDistance => customInteractionDistance;

	public bool IsBreakOn => isBreakOn;

	public bool NetworkisBreakOn
	{
		get
		{
			return isBreakOn;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isBreakOn, 1uL, OnBreakStateChanged);
		}
	}

	private void Start()
	{
		trainController = GetComponentInParent<TrainController>();
		if (trainController == null)
		{
			trainController = Object.FindObjectOfType<TrainController>();
		}
		interactionPanel = InteractionPanel.Instance;
		if (breakLever != null)
		{
			breakLever.localEulerAngles = (isBreakOn ? trainBreakOnRotation : trainBreakOffRotation);
		}
		if (trainController != null)
		{
			trainController.SetTrainBreak(this);
		}
	}

	public void Interact(PlayerInventory player, Vector3 hitPoint)
	{
		if (!isProcessingAction)
		{
			ShowBreakUI(player.transform);
			if (Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey))
			{
				Debug.Log(string.Format("[TrainBreak] Fren değiştiriliyor - CustomInteractionDistance: {0}m - Mevcut Durum: {1}", CustomInteractionDistance, isBreakOn ? "AÇIK" : "KAPALI"));
				ToggleBreak();
			}
		}
	}

	public void StopInteract()
	{
		HideBreakUI();
	}

	public void ToggleBreak()
	{
		if (!isProcessingAction)
		{
			if (base.isServer)
			{
				ToggleBreakServer();
			}
			else
			{
				CmdToggleBreak();
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdToggleBreak()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void TrainBreak::CmdToggleBreak()", 140623085, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void ToggleBreakServer()
	{
		isProcessingAction = true;
		NetworkisBreakOn = !isBreakOn;
		Debug.Log("Fren durumu değiştirildi: " + (isBreakOn ? "AÇIK" : "KAPALI"));
		StartCoroutine(ResetProcessingFlag());
	}

	private void OnBreakStateChanged(bool oldValue, bool newValue)
	{
		if (oldValue && !newValue)
		{
			TaskEventManager.OnReleaseBrakeTaskCompleted.Invoke();
		}
		if (breakLever != null)
		{
			Vector3 endValue = (newValue ? trainBreakOnRotation : trainBreakOffRotation);
			breakLever.DOLocalRotate(endValue, animationDuration).SetEase(Ease.OutQuad);
		}
		if (trainController != null)
		{
			trainController.OnBreakStateChanged(newValue);
		}
		Debug.Log("Fren animasyonu: " + (newValue ? "AÇILIYOR" : "KAPANILIYOR"));
	}

	private void ShowBreakUI(Transform player)
	{
		string message = (isBreakOn ? GetLocalizedString(releaseBrakeLocalized, "RELEASE BRAKE") : GetLocalizedString(applyBrakeLocalized, "APPLY BRAKE"));
		interactionPanel.ShowInteractionOverlay(InteractionParent, player, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, message);
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

	private void HideBreakUI()
	{
		interactionPanel.HideAllInteractions();
	}

	private IEnumerator ResetProcessingFlag()
	{
		yield return new WaitForSeconds(0.5f);
		isProcessingAction = false;
	}

	public void SetBreakState(bool state)
	{
		if (base.isServer)
		{
			NetworkisBreakOn = state;
		}
		else
		{
			CmdSetBreakState(state);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdSetBreakState(bool state)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(state);
		SendCommandInternal("System.Void TrainBreak::CmdSetBreakState(System.Boolean)", 997232685, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void Update()
	{
		if (debugMode && Input.GetKeyDown(KeyCode.B))
		{
			ToggleBreak();
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdToggleBreak()
	{
		ToggleBreakServer();
	}

	protected static void InvokeUserCode_CmdToggleBreak(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdToggleBreak called on client.");
		}
		else
		{
			((TrainBreak)obj).UserCode_CmdToggleBreak();
		}
	}

	protected void UserCode_CmdSetBreakState__Boolean(bool state)
	{
		NetworkisBreakOn = state;
	}

	protected static void InvokeUserCode_CmdSetBreakState__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetBreakState called on client.");
		}
		else
		{
			((TrainBreak)obj).UserCode_CmdSetBreakState__Boolean(reader.ReadBool());
		}
	}

	static TrainBreak()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(TrainBreak), "System.Void TrainBreak::CmdToggleBreak()", InvokeUserCode_CmdToggleBreak, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TrainBreak), "System.Void TrainBreak::CmdSetBreakState(System.Boolean)", InvokeUserCode_CmdSetBreakState__Boolean, requiresAuthority: false);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(isBreakOn);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(isBreakOn);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref isBreakOn, OnBreakStateChanged, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isBreakOn, OnBreakStateChanged, reader.ReadBool());
		}
	}
}
