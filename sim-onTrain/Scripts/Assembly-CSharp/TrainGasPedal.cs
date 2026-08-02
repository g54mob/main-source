using System.Diagnostics;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Localization;

public class TrainGasPedal : NetworkBehaviour, IInteractable
{
	[Header("Gas Pedal Settings")]
	[SerializeField]
	private Transform gasPedalTransform;

	[SerializeField]
	private Vector3 gasPedalOffRotation = Vector3.zero;

	[SerializeField]
	private Vector3 gasPedalOnRotation = new Vector3(45f, 0f, 0f);

	[SerializeField]
	private float mouseSensitivity = 2f;

	[SerializeField]
	private float animationSpeed = 5f;

	[Header("Interaction")]
	[SerializeField]
	private Transform interactionParent;

	[Header("Custom Interaction Distance")]
	[SerializeField]
	private float customInteractionDistance = 2f;

	[Header("References")]
	private TrainController trainController;

	private Camera playerCamera;

	private bool isInteracting;

	private bool isHoldingF;

	private Vector3 lastMousePosition;

	[Header("Network Sync")]
	[SyncVar(hook = "OnGasValueChanged")]
	private float gasValue;

	private float localGasValue;

	private float displayGasValue;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString gasLocalized;

	[Header("Debug")]
	[SerializeField]
	private bool debugMode;

	private float lastDebugLogTime;

	private const float DEBUG_LOG_INTERVAL = 0.5f;

	public InteractionPanel interactionPanel;

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

	public float NetworkgasValue
	{
		get
		{
			return gasValue;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref gasValue, 1uL, OnGasValueChanged);
		}
	}

	public float GetGasValue()
	{
		if (!isHoldingF)
		{
			return gasValue;
		}
		return localGasValue;
	}

	private void Start()
	{
		interactionPanel = Object.FindObjectOfType<InteractionPanel>();
		trainController = GetComponentInParent<TrainController>();
		if (trainController == null)
		{
			trainController = Object.FindObjectOfType<TrainController>();
		}
		if (gasPedalTransform != null)
		{
			gasPedalTransform.localEulerAngles = gasPedalOffRotation;
		}
		if (trainController != null)
		{
			trainController.SetGasPedal(this);
			UnityEngine.Debug.Log("[GasPedal] Start: trainController BULUNDU");
		}
		else
		{
			UnityEngine.Debug.LogWarning("[GasPedal] Start: trainController NULL!");
		}
	}

	public void Interact(PlayerInventory player, Vector3 hitPoint)
	{
		if (!isInteracting)
		{
			UnityEngine.Debug.Log($"[GasPedal] Interact BASLADI | isServer={base.isServer} | gasValue={gasValue:F3}");
		}
		isInteracting = true;
		playerCamera = player.GetComponentInChildren<Camera>();
		ShowGasPedalUI(player.transform);
	}

	public void StopInteract()
	{
		UnityEngine.Debug.Log($"[GasPedal] StopInteract | isServer={base.isServer} | gasValue={gasValue:F3} | localGasValue={localGasValue:F3}");
		if (isHoldingF && TrainGameManager.isMouseLocked)
		{
			TrainGameManager.isMouseLocked = false;
		}
		isInteracting = false;
		isHoldingF = false;
		if (!Singleton<MainUIManager>.Instance.isInGamePanelOpened)
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
		HideGasPedalUI();
	}

	private void Update()
	{
		if (isInteracting)
		{
			if (Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey))
			{
				isHoldingF = true;
				localGasValue = gasValue;
				TrainGameManager.isMouseLocked = true;
				lastMousePosition = Input.mousePosition;
			}
			else if (Input.GetKeyUp(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey))
			{
				isHoldingF = false;
				TrainGameManager.isMouseLocked = false;
			}
			if (isHoldingF)
			{
				HandleGasPedalControl();
			}
		}
		UpdatePedalVisual();
	}

	private void HandleGasPedalControl()
	{
		float axis = Input.GetAxis("Mouse Y");
		float value = localGasValue + axis * mouseSensitivity * Time.deltaTime;
		value = Mathf.Clamp01(value);
		if (!(Mathf.Abs(value - localGasValue) > 0.001f))
		{
			return;
		}
		localGasValue = value;
		if (base.isServer)
		{
			NetworkgasValue = value;
			if (trainController != null)
			{
				trainController.OnGasValueChanged(value);
			}
			if (Time.time - lastDebugLogTime > 0.5f)
			{
				UnityEngine.Debug.Log(string.Format("[GasPedal] SERVER HandleControl | gasValue={0:F3} | trainController={1}", gasValue, (trainController != null) ? "OK" : "NULL"));
				lastDebugLogTime = Time.time;
			}
		}
		else
		{
			CmdSetGasValue(value);
			if (Time.time - lastDebugLogTime > 0.5f)
			{
				UnityEngine.Debug.Log($"[GasPedal] CLIENT HandleControl | localGasValue={localGasValue:F3} | CmdSetGasValue gonderildi");
				lastDebugLogTime = Time.time;
			}
		}
	}

	private void UpdatePedalVisual()
	{
		if (!(gasPedalTransform == null))
		{
			float target = (isHoldingF ? localGasValue : gasValue);
			displayGasValue = Mathf.MoveTowards(displayGasValue, target, animationSpeed * Time.deltaTime);
			Vector3 localEulerAngles = Vector3.Lerp(gasPedalOffRotation, gasPedalOnRotation, displayGasValue);
			gasPedalTransform.localEulerAngles = localEulerAngles;
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdSetGasValue(float value)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(value);
		SendCommandInternal("System.Void TrainGasPedal::CmdSetGasValue(System.Single)", -958414139, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void OnGasValueChanged(float oldValue, float newValue)
	{
		UnityEngine.Debug.Log($"[GasPedal] SyncVar HOOK | isServer={base.isServer} | isInteracting={isInteracting} | old={oldValue:F3} → new={newValue:F3}");
		if (oldValue == 0f && newValue > 0f)
		{
			TaskEventManager.OnPressGasPedalTaskCompleted.Invoke();
		}
	}

	private void ShowGasPedalUI(Transform player)
	{
		string message = GetLocalizedString(gasLocalized, "ACCELERATE") + " (" + Singleton<UserPrefencesManager>.Instance.keyData.InteractKey.ToString() + " + Mouse)";
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

	private void HideGasPedalUI()
	{
		InteractionPanel.Instance.HidePanels();
	}

	public void SetGasValue(float value)
	{
		UnityEngine.Debug.Log($"[GasPedal] SetGasValue CAGIRILDI | isServer={base.isServer} | value={value:F3} | caller={new StackTrace().GetFrame(1)?.GetMethod()?.Name}");
		if (base.isServer)
		{
			NetworkgasValue = Mathf.Clamp01(value);
			if (trainController != null)
			{
				trainController.OnGasValueChanged(gasValue);
			}
		}
		else
		{
			CmdSetGasValue(value);
		}
	}

	public void SetGasValueFromNetwork(float value)
	{
		UnityEngine.Debug.Log($"[GasPedal] SetGasValueFromNetwork | isServer={base.isServer} | isInteracting={isInteracting} | value={value:F3}");
	}

	public void ResetGasPedal()
	{
		UnityEngine.Debug.Log("[GasPedal] ResetGasPedal CAGIRILDI");
		SetGasValue(0f);
	}

	private void OnDisable()
	{
		UnityEngine.Debug.LogWarning($"[GasPedal] OnDisable CAGIRILDI! isServer={base.isServer} | gameObject={base.gameObject.name}");
		if (Singleton<MainUIManager>.Instance != null && !Singleton<MainUIManager>.Instance.isInGamePanelOpened && Cursor.lockState != CursorLockMode.Locked)
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSetGasValue__Single(float value)
	{
		float num = gasValue;
		NetworkgasValue = Mathf.Clamp01(value);
		if (trainController != null)
		{
			trainController.OnGasValueChanged(gasValue);
		}
		UnityEngine.Debug.Log(string.Format("[GasPedal] CmdSetGasValue SERVER'DA CALISTI | old={0:F3} → new={1:F3} | trainController={2}", num, gasValue, (trainController != null) ? "OK" : "NULL"));
	}

	protected static void InvokeUserCode_CmdSetGasValue__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdSetGasValue called on client.");
		}
		else
		{
			((TrainGasPedal)obj).UserCode_CmdSetGasValue__Single(reader.ReadFloat());
		}
	}

	static TrainGasPedal()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(TrainGasPedal), "System.Void TrainGasPedal::CmdSetGasValue(System.Single)", InvokeUserCode_CmdSetGasValue__Single, requiresAuthority: false);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(gasValue);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(gasValue);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref gasValue, OnGasValueChanged, reader.ReadFloat());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref gasValue, OnGasValueChanged, reader.ReadFloat());
		}
	}
}
