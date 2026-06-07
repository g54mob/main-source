using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using I2.Loc;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class T_Forklift : NetworkBehaviour, IGameSave
{
	[Header("References")]
	[SerializeField]
	private Transform palletPoint;

	[SerializeField]
	private float attachDuration = 0.25f;

	[SerializeField]
	private float attachDetachTime = 0.4f;

	[Header("Vehicle Net")]
	[SerializeField]
	private SCC_Network vehicleNet;

	[Header("Tags")]
	[SerializeField]
	private string activatorTag = "Activator";

	[Header("Lift Status")]
	[SerializeField]
	private bool canLift;

	[SyncVar(hook = "OnHasPalletChanged")]
	[SerializeField]
	private bool hasPallet;

	[SerializeField]
	private NetworkIdentity candidatePalletIdentity;

	[SyncVar(hook = "OnAttachedPalletChanged")]
	private NetworkIdentity attachedPalletIdentity;

	[Header("Detach Drop Block Check")]
	[SerializeField]
	private Transform detachCheckOrigin;

	[SerializeField]
	private float detachCheckDownDistance = 0.6f;

	[SerializeField]
	private float detachCheckRadius = 0.25f;

	[SerializeField]
	private LayerMask detachBlockMask = -1;

	[SerializeField]
	private QueryTriggerInteraction detachCheckTriggers = QueryTriggerInteraction.Ignore;

	[Header("Events (All Clients)")]
	public UnityEvent OnAttach;

	public UnityEvent OnDetach;

	private double lastAttachDetachTimeServer;

	private float nextLocalAttachTime;

	private BuildingObject cachedAttachedBuildingObj;

	private BuildingObject cachedCandidateBuildingObj;

	private float nextPalletValidationTime;

	private const float PalletValidationInterval = 0.5f;

	protected uint ___attachedPalletIdentityNetId;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate_hasPallet;

	public Action<NetworkIdentity, NetworkIdentity> _Mirror_SyncVarHookDelegate_attachedPalletIdentity;

	public string SaveID => "forklift";

	public bool IsShared => false;

	public Type SaveType => typeof(ForkliftSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	public bool NetworkhasPallet
	{
		get
		{
			return hasPallet;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref hasPallet, 1uL, _Mirror_SyncVarHookDelegate_hasPallet);
		}
	}

	public NetworkIdentity NetworkattachedPalletIdentity
	{
		get
		{
			return GetSyncVarNetworkIdentity(___attachedPalletIdentityNetId, ref attachedPalletIdentity);
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter_NetworkIdentity(value, ref attachedPalletIdentity, 2uL, _Mirror_SyncVarHookDelegate_attachedPalletIdentity, ref ___attachedPalletIdentityNetId);
		}
	}

	private void Awake()
	{
		if (vehicleNet == null)
		{
			vehicleNet = GetComponentInParent<SCC_Network>();
		}
	}

	private void Update()
	{
		if (base.isOwned && canLift)
		{
			bool flag = false;
			if (candidatePalletIdentity == null)
			{
				flag = true;
			}
			else if (cachedCandidateBuildingObj != null && !cachedCandidateBuildingObj.IsPlaced)
			{
				flag = true;
			}
			if (flag)
			{
				candidatePalletIdentity = null;
				canLift = false;
				cachedCandidateBuildingObj = null;
				if (GameManager.Instance != null && GameManager.Instance.UImanager != null)
				{
					GameManager.Instance.UImanager.Forklift_OnPalletExit();
					GameManager.Instance.UImanager.Forklift_RefreshState(hasPallet, palletInRange: false);
				}
			}
		}
		if (!base.isServer || !hasPallet)
		{
			return;
		}
		if (NetworkattachedPalletIdentity == null)
		{
			Debug.LogWarning("[T_Forklift] Attached pallet null oldu (destroy/resale?), hasPallet temizleniyor.");
			NetworkhasPallet = false;
			cachedAttachedBuildingObj = null;
		}
		else if (!(Time.time < nextPalletValidationTime))
		{
			nextPalletValidationTime = Time.time + 0.5f;
			if (cachedAttachedBuildingObj != null && !cachedAttachedBuildingObj.IsPlaced)
			{
				Debug.LogWarning("[T_Forklift] Attached palet artık IsPlaced değil (relocate/resale?), zorla detach ediliyor.");
				NetworkhasPallet = false;
				NetworkattachedPalletIdentity = null;
				cachedAttachedBuildingObj = null;
			}
		}
	}

	public void SetCandidatePallet(NetworkIdentity palletNi)
	{
		if (!hasPallet)
		{
			candidatePalletIdentity = palletNi;
			canLift = palletNi != null;
			cachedCandidateBuildingObj = ((palletNi != null) ? palletNi.GetComponent<BuildingObject>() : null);
			if (base.isOwned && GameManager.Instance != null && GameManager.Instance.UImanager != null)
			{
				bool palletInRange = canLift && candidatePalletIdentity != null;
				GameManager.Instance.UImanager.Forklift_RefreshState(hasPallet, palletInRange);
			}
		}
	}

	public void ClearCandidatePallet(NetworkIdentity palletNi)
	{
		if (candidatePalletIdentity == palletNi)
		{
			candidatePalletIdentity = null;
			canLift = false;
			cachedCandidateBuildingObj = null;
			if (base.isOwned && GameManager.Instance != null && GameManager.Instance.UImanager != null)
			{
				bool palletInRange = canLift && candidatePalletIdentity != null;
				GameManager.Instance.UImanager.Forklift_RefreshState(hasPallet, palletInRange);
			}
		}
	}

	public void NotifyLocalPalletEnter(NetworkIdentity palletNi)
	{
		if (base.isOwned && GameManager.Instance != null && GameManager.Instance.UImanager != null)
		{
			GameManager.Instance.UImanager.Forklift_OnPalletEnter();
		}
	}

	public void NotifyLocalPalletExit(NetworkIdentity palletNi)
	{
		if (base.isOwned && GameManager.Instance != null && GameManager.Instance.UImanager != null)
		{
			GameManager.Instance.UImanager.Forklift_OnPalletExit();
		}
	}

	[Client]
	public void TryAttach()
	{
		if (!NetworkClient.active)
		{
			Debug.LogWarning("[Client] function 'System.Void T_Forklift::TryAttach()' called when client was not active");
		}
		else
		{
			if (!base.isOwned)
			{
				return;
			}
			bool flag = hasPallet && NetworkattachedPalletIdentity != null;
			bool flag2 = !flag && canLift && !hasPallet && candidatePalletIdentity != null;
			if (!(flag || flag2))
			{
				return;
			}
			if (flag)
			{
				if (IsDropBlocked(out var _))
				{
					return;
				}
				PalletPlacementValidator palletPlacementValidator = ((NetworkattachedPalletIdentity != null) ? NetworkattachedPalletIdentity.GetComponent<PalletPlacementValidator>() : null);
				if (palletPlacementValidator != null && !palletPlacementValidator.CanPlace(out var _))
				{
					if (NotificationManager.Instance != null)
					{
						NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_CannotPlacePalletHere"));
					}
				}
				else if (!(Time.time < nextLocalAttachTime))
				{
					nextLocalAttachTime = Time.time + attachDetachTime;
					if (vehicleNet != null)
					{
						vehicleNet.BeginForkliftOpLock(attachDetachTime);
					}
					CmdTryDetach();
				}
			}
			else
			{
				if (!flag2)
				{
					return;
				}
				BuildingObject component = candidatePalletIdentity.GetComponent<BuildingObject>();
				if (component != null && !component.IsPlaced)
				{
					return;
				}
				if (TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning && TutorialManager.Instance.IsSubStepCompleted(TutorialSubStepType.PutPalletInWarehouseSub) && T_Warehouse.Instance != null && T_Warehouse.Instance.IsPalletInWarehouse(candidatePalletIdentity.netId))
				{
					if (NotificationManager.Instance != null)
					{
						NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_NotAvailableDuringTutorial"));
					}
				}
				else if (!(Time.time < nextLocalAttachTime))
				{
					nextLocalAttachTime = Time.time + attachDetachTime;
					if (vehicleNet != null)
					{
						vehicleNet.BeginForkliftOpLock(attachDetachTime);
					}
					CmdTryAttach(candidatePalletIdentity);
				}
			}
		}
	}

	private bool IsDropBlocked(out Vector3 hitPoint)
	{
		hitPoint = Vector3.zero;
		Transform transform = ((detachCheckOrigin != null) ? detachCheckOrigin : palletPoint);
		if (transform == null)
		{
			return false;
		}
		if (Physics.SphereCast(transform.position, detachCheckRadius, Vector3.down, out var hitInfo, detachCheckDownDistance, detachBlockMask, detachCheckTriggers))
		{
			hitPoint = hitInfo.point;
			return true;
		}
		return false;
	}

	[Command]
	private void CmdTryAttach(NetworkIdentity palletNi)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTryAttach__NetworkIdentity(palletNi);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkIdentity(palletNi);
		SendCommandInternal("System.Void T_Forklift::CmdTryAttach(Mirror.NetworkIdentity)", -1501263360, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	private void CmdTryDetach()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTryDetach();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Forklift::CmdTryDetach()", 2045818889, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private void OnHasPalletChanged(bool oldValue, bool newValue)
	{
		if (base.isOwned && !(GameManager.Instance == null) && !(GameManager.Instance.UImanager == null) && !newValue && NetworkattachedPalletIdentity == null)
		{
			OnDetach?.Invoke();
			GameManager.Instance.UImanager.Forklift_OnDetach();
			bool palletInRange = canLift && candidatePalletIdentity != null;
			GameManager.Instance.UImanager.Forklift_RefreshState(hasPallet: false, palletInRange);
			RefreshForkliftIndicators();
		}
	}

	private void OnAttachedPalletChanged(NetworkIdentity oldPallet, NetworkIdentity newPallet)
	{
		if (newPallet != null)
		{
			ApplyPalletAttachState(newPallet);
			return;
		}
		if (oldPallet != null)
		{
			ApplyPalletDetachState(oldPallet);
			return;
		}
		OnDetach?.Invoke();
		if (base.isOwned && GameManager.Instance != null && GameManager.Instance.UImanager != null)
		{
			GameManager.Instance.UImanager.Forklift_OnDetach();
			bool palletInRange = canLift && candidatePalletIdentity != null;
			GameManager.Instance.UImanager.Forklift_RefreshState(hasPallet: false, palletInRange);
		}
		if (base.isOwned)
		{
			RefreshForkliftIndicators();
		}
	}

	private void ApplyPalletAttachState(NetworkIdentity palletNi)
	{
		Transform transform = palletNi.transform;
		DisableActivatorOnPallet(transform);
		NetworkTransformHybrid component = palletNi.GetComponent<NetworkTransformHybrid>();
		if (component != null)
		{
			component.enabled = false;
		}
		transform.SetParent(palletPoint, worldPositionStays: true);
		T_Pallet component2 = palletNi.GetComponent<T_Pallet>();
		if (component2 != null)
		{
			component2.OnLifted();
		}
		else
		{
			T_DeliveryPallet component3 = palletNi.GetComponent<T_DeliveryPallet>();
			if (component3 != null)
			{
				component3.OnLifted();
			}
		}
		StopAllCoroutines();
		StartCoroutine(SmoothAttachRoutine(transform));
		OnAttach?.Invoke();
		if (base.isOwned && GameManager.Instance != null && GameManager.Instance.UImanager != null)
		{
			GameManager.Instance.UImanager.Forklift_OnAttach();
			bool palletInRange = canLift && candidatePalletIdentity != null;
			GameManager.Instance.UImanager.Forklift_RefreshState(hasPallet, palletInRange);
		}
		if (base.isOwned)
		{
			RefreshForkliftIndicators();
		}
	}

	private void ApplyPalletDetachState(NetworkIdentity palletNi)
	{
		StopAllCoroutines();
		StartCoroutine(DetachRoutine(palletNi));
	}

	private void DisableActivatorOnPallet(Transform palletRoot)
	{
		Transform[] componentsInChildren = palletRoot.GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform transform in componentsInChildren)
		{
			if (transform.CompareTag(activatorTag))
			{
				transform.gameObject.SetActive(value: false);
				break;
			}
		}
	}

	private void EnableActivatorOnPallet(Transform palletRoot)
	{
		Transform[] componentsInChildren = palletRoot.GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform transform in componentsInChildren)
		{
			if (transform.CompareTag(activatorTag))
			{
				transform.gameObject.SetActive(value: true);
				break;
			}
		}
	}

	private IEnumerator SmoothAttachRoutine(Transform palletTransform)
	{
		Vector3 startLocalPos = palletTransform.localPosition;
		Quaternion startLocalRot = palletTransform.localRotation;
		Vector3 targetLocalPos = Vector3.zero;
		float t = Mathf.Round(startLocalRot.eulerAngles.y / 90f) * 90f;
		t = Mathf.Repeat(t, 360f);
		Quaternion targetLocalRot = Quaternion.Euler(0f, t, 0f);
		float t2 = 0f;
		while (t2 < attachDuration)
		{
			t2 += Time.deltaTime;
			float t3 = Mathf.Clamp01(t2 / attachDuration);
			palletTransform.localPosition = Vector3.Lerp(startLocalPos, targetLocalPos, t3);
			palletTransform.localRotation = Quaternion.Slerp(startLocalRot, targetLocalRot, t3);
			yield return null;
		}
		palletTransform.localPosition = targetLocalPos;
		palletTransform.localRotation = targetLocalRot;
	}

	private IEnumerator DetachRoutine(NetworkIdentity palletNi)
	{
		Transform palletTransform = palletNi.transform;
		OnDetach?.Invoke();
		if (base.isOwned && GameManager.Instance != null && GameManager.Instance.UImanager != null)
		{
			GameManager.Instance.UImanager.Forklift_OnDetach();
		}
		yield return new WaitForSeconds(attachDetachTime);
		palletTransform.SetParent(null, worldPositionStays: true);
		T_Pallet component = palletNi.GetComponent<T_Pallet>();
		if (component != null)
		{
			component.OnPlaced();
		}
		else
		{
			T_DeliveryPallet component2 = palletNi.GetComponent<T_DeliveryPallet>();
			if (component2 != null)
			{
				component2.OnPlaced();
			}
		}
		NetworkTransformHybrid component3 = palletNi.GetComponent<NetworkTransformHybrid>();
		if (component3 != null)
		{
			component3.enabled = true;
		}
		EnableActivatorOnPallet(palletTransform);
		if (base.isOwned && GameManager.Instance != null && GameManager.Instance.UImanager != null)
		{
			bool palletInRange = canLift && candidatePalletIdentity != null;
			GameManager.Instance.UImanager.Forklift_RefreshState(hasPallet, palletInRange);
		}
		if (base.isOwned)
		{
			RefreshForkliftIndicators();
		}
	}

	private void LocalDriverSyncUIToCurrentState()
	{
		if (base.isOwned && !(GameManager.Instance == null) && !(GameManager.Instance.UImanager == null))
		{
			bool palletInRange = canLift && candidatePalletIdentity != null;
			if (hasPallet && NetworkattachedPalletIdentity != null)
			{
				GameManager.Instance.UImanager.Forklift_OnAttach();
			}
			else
			{
				GameManager.Instance.UImanager.Forklift_OnDetach();
			}
			GameManager.Instance.UImanager.Forklift_RefreshState(hasPallet, palletInRange);
		}
	}

	public void LocalDriverEntered()
	{
		if (base.isOwned)
		{
			LocalDriverSyncUIToCurrentState();
			if (GameManager.Instance != null && GameManager.Instance.UImanager != null)
			{
				GameManager.Instance.UImanager.liftObj.SetActive(value: true);
			}
			if (TutorialManager.Instance != null)
			{
				TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Warehouse, TutorialStepType.PutPalletInWarehouse, TutorialSubStepType.GetInForklift);
			}
			if (ComputerContractManager.Instance != null)
			{
				ComputerContractManager.Instance.onDeliveryContractChanged.AddListener(OnDeliveryContractChanged);
			}
			RefreshForkliftIndicators();
		}
	}

	public void LocalDriverExited()
	{
		if (GameManager.Instance != null && GameManager.Instance.UImanager != null)
		{
			GameManager.Instance.UImanager.Forklift_OnDriverExit();
		}
		if (ComputerContractManager.Instance != null)
		{
			ComputerContractManager.Instance.onDeliveryContractChanged.RemoveListener(OnDeliveryContractChanged);
		}
		T_PalletMachine.Instance?.HideForkliftIndicator();
		T_DeliveryZone.Instance?.HideForkliftIndicator();
	}

	private void OnDeliveryContractChanged(string contractId)
	{
		RefreshForkliftIndicators();
	}

	private void RefreshForkliftIndicators()
	{
		T_PalletMachine.Instance?.HideForkliftIndicator();
		T_DeliveryZone.Instance?.HideForkliftIndicator();
		if (!hasPallet || NetworkattachedPalletIdentity == null)
		{
			return;
		}
		T_Pallet component = NetworkattachedPalletIdentity.GetComponent<T_Pallet>();
		if (component != null)
		{
			if (T_PalletMachine.Instance != null && T_PalletMachine.Instance.IsItemNeededForDelivery(component.PaletItemId))
			{
				T_PalletMachine.Instance.ShowForkliftIndicator();
			}
			return;
		}
		T_DeliveryPallet component2 = NetworkattachedPalletIdentity.GetComponent<T_DeliveryPallet>();
		if (component2 != null && T_DeliveryZone.Instance != null && T_DeliveryZone.Instance.IsDeliveryPalletNeeded(component2))
		{
			T_DeliveryZone.Instance.ShowForkliftIndicator();
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		SaveLoadManager.Subscribe(this, 55);
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
	}

	private void OnDestroy()
	{
		SaveLoadManager.Unsubscribe(this);
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return new ForkliftSaveData();
		}
		string attachedPalletBuildingId = "";
		string attachedDeliveryPalletId = "";
		bool isDeliveryPallet = false;
		if (hasPallet && NetworkattachedPalletIdentity != null)
		{
			T_DeliveryPallet component = NetworkattachedPalletIdentity.GetComponent<T_DeliveryPallet>();
			if (component != null)
			{
				attachedDeliveryPalletId = component.UniqueId;
				isDeliveryPallet = true;
			}
			else
			{
				T_Pallet component2 = NetworkattachedPalletIdentity.GetComponent<T_Pallet>();
				if (component2 != null && component2.buildingObject != null)
				{
					attachedPalletBuildingId = component2.buildingObject.UniqueBuildingId;
				}
			}
		}
		Vector3 position = base.transform.position;
		Quaternion rotation = base.transform.rotation;
		if (vehicleNet != null && vehicleNet.rb != null)
		{
			position = vehicleNet.rb.position;
			rotation = vehicleNet.rb.rotation;
		}
		return new ForkliftSaveData
		{
			position = position,
			rotation = rotation,
			attachedPalletBuildingId = attachedPalletBuildingId,
			attachedDeliveryPalletId = attachedDeliveryPalletId,
			isDeliveryPallet = isDeliveryPallet
		};
	}

	public Task OnLoad(object value)
	{
		if (!(value is ForkliftSaveData data))
		{
			return Task.CompletedTask;
		}
		if (!base.isServer)
		{
			return Task.CompletedTask;
		}
		StartCoroutine(Co_RestoreForkliftState(data));
		return Task.CompletedTask;
	}

	private IEnumerator Co_RestoreForkliftState(ForkliftSaveData data)
	{
		Debug.Log($"[T_Forklift] Co_RestoreForkliftState başladı. Hedef pozisyon: {data.position}");
		float timeout = 2f;
		float elapsed = 0f;
		while (vehicleNet == null && elapsed < timeout)
		{
			if (vehicleNet == null)
			{
				vehicleNet = GetComponentInParent<SCC_Network>();
			}
			yield return null;
			elapsed += Time.deltaTime;
		}
		if (vehicleNet == null)
		{
			Debug.LogError("[T_Forklift] vehicleNet bulunamadı! Pozisyon restore edilemedi.");
			yield break;
		}
		elapsed = 0f;
		while (vehicleNet.rb == null && elapsed < timeout)
		{
			yield return null;
			elapsed += Time.deltaTime;
		}
		Debug.Log($"[T_Forklift] ServerTeleport çağrılıyor: {data.position}, vehicleNet: {vehicleNet != null}, rb: {vehicleNet.rb != null}");
		vehicleNet.ServerTeleport(data.position, data.rotation);
		Debug.Log($"[T_Forklift] Pozisyon restore edildi: {data.position}");
		if (data.isDeliveryPallet && !string.IsNullOrEmpty(data.attachedDeliveryPalletId))
		{
			Debug.Log("[T_Forklift] DeliveryPallet aranıyor: " + data.attachedDeliveryPalletId);
			T_DeliveryPallet deliveryPallet = null;
			while (deliveryPallet == null && SaveLoadGameManager.IsLoadPendingOrInProgress)
			{
				deliveryPallet = FindDeliveryPalletByUniqueId(data.attachedDeliveryPalletId);
				if (deliveryPallet == null)
				{
					yield return new WaitForSeconds(0.1f);
				}
			}
			if (deliveryPallet != null)
			{
				Debug.Log("[T_Forklift] DeliveryPallet bulundu, kaldırılıyor: " + deliveryPallet.UniqueId);
				ServerAttachDeliveryPalletFromLoad(deliveryPallet);
			}
			else
			{
				Debug.LogWarning("[T_Forklift] DeliveryPallet bulunamadı (loading bitti): " + data.attachedDeliveryPalletId);
			}
		}
		else
		{
			if (string.IsNullOrEmpty(data.attachedPalletBuildingId))
			{
				yield break;
			}
			Debug.Log("[T_Forklift] Palet aranıyor: " + data.attachedPalletBuildingId);
			T_Pallet pallet = null;
			while (pallet == null && SaveLoadGameManager.IsLoadPendingOrInProgress)
			{
				pallet = FindPalletByBuildingId(data.attachedPalletBuildingId);
				if (pallet == null)
				{
					yield return new WaitForSeconds(0.1f);
				}
			}
			if (pallet == null)
			{
				Debug.LogWarning("[T_Forklift] Palet bulunamadı (loading bitti): " + data.attachedPalletBuildingId);
				yield break;
			}
			NetworkIdentity component = pallet.GetComponent<NetworkIdentity>();
			if (component == null)
			{
				Debug.LogWarning("[T_Forklift] Palet NetworkIdentity bulunamadı");
				yield break;
			}
			Debug.Log($"[T_Forklift] Palet bulundu, kaldırılıyor: {component.netId}");
			ServerReattachPallet(component);
		}
	}

	private T_Pallet FindPalletByBuildingId(string buildingId)
	{
		if (string.IsNullOrEmpty(buildingId))
		{
			return null;
		}
		if (GameManager.Instance == null)
		{
			return null;
		}
		foreach (BuildingObject allBuilding in GameManager.Instance.GetAllBuildings())
		{
			if (allBuilding != null && allBuilding.UniqueBuildingId == buildingId)
			{
				T_Pallet component = allBuilding.GetComponent<T_Pallet>();
				if (component != null)
				{
					return component;
				}
			}
		}
		return null;
	}

	private T_DeliveryPallet FindDeliveryPalletByUniqueId(string uniqueId)
	{
		if (string.IsNullOrEmpty(uniqueId))
		{
			return null;
		}
		if (DynamicObjectSpawner.Instance != null)
		{
			T_DeliveryPallet deliveryPalletByUniqueId = DynamicObjectSpawner.Instance.GetDeliveryPalletByUniqueId(uniqueId);
			if (deliveryPalletByUniqueId != null)
			{
				return deliveryPalletByUniqueId;
			}
		}
		T_DeliveryPallet[] array = UnityEngine.Object.FindObjectsOfType<T_DeliveryPallet>();
		foreach (T_DeliveryPallet t_DeliveryPallet in array)
		{
			if (t_DeliveryPallet.UniqueId == uniqueId)
			{
				return t_DeliveryPallet;
			}
		}
		return null;
	}

	[Server]
	private void ServerReattachPallet(NetworkIdentity palletNi)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Forklift::ServerReattachPallet(Mirror.NetworkIdentity)' called when server was not active");
		}
		else if (!(palletNi == null) && !hasPallet)
		{
			NetworkhasPallet = true;
			NetworkattachedPalletIdentity = palletNi;
			cachedAttachedBuildingObj = palletNi.GetComponent<BuildingObject>();
			ApplyPalletAttachStateImmediate(palletNi);
			Debug.Log($"[T_Forklift] Palet yeniden kaldırıldı: {palletNi.netId}");
		}
	}

	[Server]
	public void ServerAttachDeliveryPalletFromLoad(T_DeliveryPallet deliveryPallet)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Forklift::ServerAttachDeliveryPalletFromLoad(T_DeliveryPallet)' called when server was not active");
		}
		else if (!(deliveryPallet == null) && !hasPallet)
		{
			NetworkIdentity component = deliveryPallet.GetComponent<NetworkIdentity>();
			if (!(component == null))
			{
				NetworkhasPallet = true;
				NetworkattachedPalletIdentity = component;
				cachedAttachedBuildingObj = component.GetComponent<BuildingObject>();
				ApplyPalletAttachStateImmediate(component);
				Debug.Log($"[T_Forklift] DeliveryPallet load'dan kaldırıldı: {component.netId}");
			}
		}
	}

	private void ApplyPalletAttachStateImmediate(NetworkIdentity palletNi)
	{
		Transform transform = palletNi.transform;
		DisableActivatorOnPallet(transform);
		NetworkTransformHybrid component = palletNi.GetComponent<NetworkTransformHybrid>();
		if (component != null)
		{
			component.enabled = false;
		}
		transform.SetParent(palletPoint, worldPositionStays: false);
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
		T_Pallet component2 = palletNi.GetComponent<T_Pallet>();
		if (component2 != null)
		{
			component2.OnLifted();
		}
		else
		{
			T_DeliveryPallet component3 = palletNi.GetComponent<T_DeliveryPallet>();
			if (component3 != null)
			{
				component3.OnLifted();
			}
		}
		OnAttach?.Invoke();
	}

	public T_Forklift()
	{
		_Mirror_SyncVarHookDelegate_hasPallet = OnHasPalletChanged;
		_Mirror_SyncVarHookDelegate_attachedPalletIdentity = OnAttachedPalletChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdTryAttach__NetworkIdentity(NetworkIdentity palletNi)
	{
		if (NetworkTime.time - lastAttachDetachTimeServer < (double)attachDetachTime || hasPallet || palletNi == null)
		{
			return;
		}
		BuildingObject component = palletNi.GetComponent<BuildingObject>();
		if (component != null && !component.IsPlaced)
		{
			return;
		}
		T_Pallet component2 = palletNi.GetComponent<T_Pallet>();
		if ((!(component2 != null) || !component2.IsBeingProcessed) && (!(TutorialManager.Instance != null) || !TutorialManager.Instance.IsTutorialRunning || !TutorialManager.Instance.IsSubStepCompleted(TutorialSubStepType.PutPalletInWarehouseSub) || !(T_Warehouse.Instance != null) || !T_Warehouse.Instance.IsPalletInWarehouse(palletNi.netId)))
		{
			if (vehicleNet != null)
			{
				vehicleNet.ServerBeginForkliftOpLock(attachDetachTime);
			}
			NetworkhasPallet = true;
			NetworkattachedPalletIdentity = palletNi;
			cachedAttachedBuildingObj = component;
			lastAttachDetachTimeServer = NetworkTime.time;
			if (TutorialManager.Instance != null)
			{
				TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Warehouse, TutorialStepType.PutPalletInWarehouse, TutorialSubStepType.PickUpPallet);
			}
		}
	}

	protected static void InvokeUserCode_CmdTryAttach__NetworkIdentity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdTryAttach called on client.");
		}
		else
		{
			((T_Forklift)obj).UserCode_CmdTryAttach__NetworkIdentity(reader.ReadNetworkIdentity());
		}
	}

	protected void UserCode_CmdTryDetach()
	{
		if (!(NetworkTime.time - lastAttachDetachTimeServer < (double)attachDetachTime) && hasPallet && !(NetworkattachedPalletIdentity == null))
		{
			if (vehicleNet != null)
			{
				vehicleNet.ServerBeginForkliftOpLock(attachDetachTime);
			}
			NetworkhasPallet = false;
			NetworkattachedPalletIdentity = null;
			cachedAttachedBuildingObj = null;
			lastAttachDetachTimeServer = NetworkTime.time;
		}
	}

	protected static void InvokeUserCode_CmdTryDetach(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdTryDetach called on client.");
		}
		else
		{
			((T_Forklift)obj).UserCode_CmdTryDetach();
		}
	}

	static T_Forklift()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(T_Forklift), "System.Void T_Forklift::CmdTryAttach(Mirror.NetworkIdentity)", InvokeUserCode_CmdTryAttach__NetworkIdentity, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Forklift), "System.Void T_Forklift::CmdTryDetach()", InvokeUserCode_CmdTryDetach, requiresAuthority: true);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(hasPallet);
			writer.WriteNetworkIdentity(NetworkattachedPalletIdentity);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(hasPallet);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteNetworkIdentity(NetworkattachedPalletIdentity);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref hasPallet, _Mirror_SyncVarHookDelegate_hasPallet, reader.ReadBool());
			GeneratedSyncVarDeserialize_NetworkIdentity(ref attachedPalletIdentity, _Mirror_SyncVarHookDelegate_attachedPalletIdentity, reader, ref ___attachedPalletIdentityNetId);
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref hasPallet, _Mirror_SyncVarHookDelegate_hasPallet, reader.ReadBool());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize_NetworkIdentity(ref attachedPalletIdentity, _Mirror_SyncVarHookDelegate_attachedPalletIdentity, reader, ref ___attachedPalletIdentityNetId);
		}
	}
}
