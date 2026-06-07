using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using I2.Loc;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class T_Equipments : NetworkBehaviour
{
	[Header("Tools")]
	public GameObject networkToolsRoot;

	public List<GameObject> networkTools = new List<GameObject>();

	public List<T_Tool> localTools = new List<T_Tool>();

	[Header("Input")]
	public bool inputActive;

	public InputActionReference useActionReference;

	public InputActionReference secondUseActionReference;

	[Header("Building Input")]
	public InputActionReference activateBuildingModeActionReference;

	public InputActionReference placeActionReference;

	public InputActionReference rotateActionReference;

	public InputActionReference buildActionReference;

	public InputActionReference cancelActionReference;

	public InputActionReference hideEquipmentActionReference;

	[Header("Contract HUD Input")]
	public InputActionReference toggleContractHUDActionReference;

	[Header("Quick Equip Input")]
	public InputActionReference quickEquipActionReference;

	[Header("Radial Building Input")]
	[Tooltip("Scroll ile building değiştirmek için input action (Radial Menu modunda)")]
	public InputActionReference scrollBuildingActionReference;

	[Header("Throw Settings")]
	public float maxForce;

	public float chargeTime;

	public bool isCharging;

	public float currentForce;

	[Header("Dig Control Settings")]
	[SerializeField]
	private LayerMask terrainMask = -1;

	[SerializeField]
	private float rayMaxDistance = 40f;

	[Header("Audio")]
	public AudioSource toolAudioSource;

	[Header("References")]
	public PlayerInteractionManager interactionManager;

	[Header("Events")]
	public UnityEvent onHitEvent;

	[Header("Relocate State")]
	private ItemType previousToolTypeBeforeRelocate;

	[Header("Syncvar")]
	[SyncVar(hook = "OnEquippedIndexChanged")]
	public int equippedIndex = -1;

	public GameObject pickupNetworkRoot;

	public GameObject pickupRoot;

	public GameObject pickupItem;

	[Header("Building")]
	public BuildingInteractionManager buildingInteractionManager;

	[Header("Building Mode State")]
	[SerializeField]
	private BuildingModeSource currentBuildingSource;

	[SerializeField]
	private T_BuildingItemSO currentRadialBuildingSO;

	[Header("Vehicle State")]
	private bool onVehicle;

	[Header("Dirt Inventory")]
	public int currentDirt;

	public int maxDirt = 10;

	[Header("Events")]
	public UnityEvent onUnequip;

	[Header("Dart")]
	public T_DartManager dartManager;

	private bool _useHeld;

	private Coroutine _useHoldRoutine;

	private bool _secondUseHeld;

	private Coroutine _secondUseHoldRoutine;

	private GameManager gameManager;

	public Action<int, int> _Mirror_SyncVarHookDelegate_equippedIndex;

	public BuildingModeSource CurrentBuildingSource => currentBuildingSource;

	public int NetworkequippedIndex
	{
		get
		{
			return equippedIndex;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref equippedIndex, 1uL, _Mirror_SyncVarHookDelegate_equippedIndex);
		}
	}

	public event Action<int, int> OnDirtChanged;

	public void ClearPickupItem()
	{
		pickupItem = null;
		if (isCharging)
		{
			isCharging = false;
			currentForce = 0f;
		}
	}

	private void OnEnable()
	{
		StartCoroutine(OnEnableActions());
	}

	private IEnumerator OnEnableActions()
	{
		yield return new WaitForSeconds(0.5f);
		if (base.isOwned)
		{
			gameManager = GameManager.Instance;
			if (gameManager != null && gameManager.localEquipments == null)
			{
				gameManager.localEquipments = this;
			}
			if ((bool)useActionReference && useActionReference.action != null)
			{
				useActionReference.action.performed += OnUsePerformed;
				useActionReference.action.canceled += OnUseCanceled;
				useActionReference.action.Enable();
			}
			if ((bool)secondUseActionReference && secondUseActionReference.action != null)
			{
				secondUseActionReference.action.performed += OnSecondUsePerformed;
				secondUseActionReference.action.canceled += OnSecondUseCanceled;
				secondUseActionReference.action.Enable();
			}
			if ((bool)activateBuildingModeActionReference && activateBuildingModeActionReference.action != null)
			{
				activateBuildingModeActionReference.action.performed += OnActivateBuildingModePerformed;
				activateBuildingModeActionReference.action.Enable();
			}
			if ((bool)placeActionReference && placeActionReference.action != null)
			{
				placeActionReference.action.performed += OnPlacePerformed;
				placeActionReference.action.Enable();
			}
			if ((bool)rotateActionReference && rotateActionReference.action != null)
			{
				rotateActionReference.action.performed += OnRotatePerformed;
				rotateActionReference.action.Enable();
			}
			if ((bool)buildActionReference && buildActionReference.action != null)
			{
				buildActionReference.action.performed += OnBuildPerformed;
				buildActionReference.action.Enable();
			}
			if ((bool)cancelActionReference && cancelActionReference.action != null)
			{
				cancelActionReference.action.performed += OnCancelPerformed;
				cancelActionReference.action.Enable();
			}
			if ((bool)hideEquipmentActionReference && hideEquipmentActionReference.action != null)
			{
				hideEquipmentActionReference.action.performed += OnHideEquipmentPerformed;
				hideEquipmentActionReference.action.Enable();
			}
			if ((bool)toggleContractHUDActionReference && toggleContractHUDActionReference.action != null)
			{
				toggleContractHUDActionReference.action.performed += OnToggleContractHUDPerformed;
				toggleContractHUDActionReference.action.Enable();
			}
			if ((bool)scrollBuildingActionReference && scrollBuildingActionReference.action != null)
			{
				scrollBuildingActionReference.action.performed += OnScrollBuildingPerformed;
				scrollBuildingActionReference.action.Enable();
			}
			if ((bool)quickEquipActionReference && quickEquipActionReference.action != null)
			{
				quickEquipActionReference.action.performed += OnQuickEquipPerformed;
				quickEquipActionReference.action.Enable();
			}
		}
	}

	private void OnDisable()
	{
		if (base.isOwned)
		{
			if ((bool)useActionReference && useActionReference.action != null)
			{
				useActionReference.action.Disable();
				useActionReference.action.performed -= OnUsePerformed;
				useActionReference.action.canceled -= OnUseCanceled;
			}
			if ((bool)secondUseActionReference && secondUseActionReference.action != null)
			{
				secondUseActionReference.action.Disable();
				secondUseActionReference.action.performed -= OnSecondUsePerformed;
				secondUseActionReference.action.canceled -= OnSecondUseCanceled;
			}
			if ((bool)activateBuildingModeActionReference && activateBuildingModeActionReference.action != null)
			{
				activateBuildingModeActionReference.action.Disable();
				activateBuildingModeActionReference.action.performed -= OnActivateBuildingModePerformed;
			}
			if ((bool)placeActionReference && placeActionReference.action != null)
			{
				placeActionReference.action.Disable();
				placeActionReference.action.performed -= OnPlacePerformed;
			}
			if ((bool)rotateActionReference && rotateActionReference.action != null)
			{
				rotateActionReference.action.Disable();
				rotateActionReference.action.performed -= OnRotatePerformed;
			}
			if ((bool)buildActionReference && buildActionReference.action != null)
			{
				buildActionReference.action.Disable();
				buildActionReference.action.performed -= OnBuildPerformed;
			}
			if ((bool)cancelActionReference && cancelActionReference.action != null)
			{
				cancelActionReference.action.Disable();
				cancelActionReference.action.performed -= OnCancelPerformed;
			}
			if ((bool)hideEquipmentActionReference && hideEquipmentActionReference.action != null)
			{
				hideEquipmentActionReference.action.Disable();
				hideEquipmentActionReference.action.performed -= OnHideEquipmentPerformed;
			}
			if ((bool)toggleContractHUDActionReference && toggleContractHUDActionReference.action != null)
			{
				toggleContractHUDActionReference.action.Disable();
				toggleContractHUDActionReference.action.performed -= OnToggleContractHUDPerformed;
			}
			if ((bool)scrollBuildingActionReference && scrollBuildingActionReference.action != null)
			{
				scrollBuildingActionReference.action.Disable();
				scrollBuildingActionReference.action.performed -= OnScrollBuildingPerformed;
			}
			if ((bool)quickEquipActionReference && quickEquipActionReference.action != null)
			{
				quickEquipActionReference.action.Disable();
				quickEquipActionReference.action.performed -= OnQuickEquipPerformed;
			}
			StopBuildingMode();
		}
	}

	private void Update()
	{
		if (!base.isOwned)
		{
			return;
		}
		if (isCharging)
		{
			currentForce += maxForce / chargeTime * Time.deltaTime;
			currentForce = Mathf.Clamp(currentForce, 0f, maxForce);
			if (gameManager.UImanager.playerInteractionUI.throwProgressCircle != null)
			{
				gameManager.UImanager.playerInteractionUI.throwProgressCircle.fillAmount = currentForce / maxForce;
			}
		}
		else if (gameManager != null && gameManager.UImanager != null && gameManager.UImanager.playerInteractionUI != null && gameManager.UImanager.playerInteractionUI.throwProgressCircle != null && gameManager.UImanager.playerInteractionUI.throwProgressCircle.fillAmount != 0f)
		{
			gameManager.UImanager.playerInteractionUI.throwProgressCircle.fillAmount = 0f;
		}
	}

	public void SetInputActive(bool active)
	{
		inputActive = active;
	}

	public void SetOnVehicle(bool value)
	{
		onVehicle = value;
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		ApplyEquipState(equippedIndex, callLocalEvents: false);
	}

	public void TryEquipByIndex(int index)
	{
		if ((!base.isOwned && inputActive) || onVehicle)
		{
			return;
		}
		if (buildingInteractionManager != null && buildingInteractionManager.InputActive)
		{
			Debug.Log($"[Equipments] Building mode aktifken item equip edilmeye çalışıldı - Building mode iptal ediliyor. Source: {currentBuildingSource}");
			if (currentBuildingSource == BuildingModeSource.RadialMenu)
			{
				if (RadialBuildingManager.Instance != null)
				{
					RadialBuildingManager.Instance.CancelBuilding();
				}
				else
				{
					buildingInteractionManager.CancelBuilding();
					StopBuildingMode();
				}
			}
			else
			{
				buildingInteractionManager.CancelBuilding();
				StopBuildingMode();
			}
		}
		if (pickupItem != null && index >= 0 && index < localTools.Count && localTools[index] != null)
		{
			T_Pickup component = pickupItem.GetComponent<T_Pickup>();
			ItemType itemType = ((component != null) ? component.itemType : ItemType.None);
			ItemType itemType2 = localTools[index].itemType;
			if (itemType == ItemType.Pickup && itemType2 == ItemType.Building)
			{
				Debug.LogWarning("[Equipments] Elde Pickup var, Building equip edilemez!");
				return;
			}
			if (itemType == ItemType.Building && itemType2 == ItemType.Pickup)
			{
				Debug.LogWarning("[Equipments] Elde Building var, Pickup equip edilemez!");
				return;
			}
			if ((itemType == ItemType.Pickup || itemType == ItemType.Building) && (itemType2 == ItemType.Shovel || itemType2 == ItemType.Pickaxe || itemType2 == ItemType.Dynamite || itemType2 == ItemType.Detector || itemType2 == ItemType.Hammer || itemType2 == ItemType.Jackhammer) && component != null)
			{
				Vector3 normalized = (Camera.main.transform.forward + Vector3.up * 0.25f).normalized;
				float power = 5f;
				component.TryRelease(normalized, power);
				ClearPickupItem();
				Debug.Log($"[Equipments] Eldeki {itemType} yere atıldı, {itemType2} equip ediliyor.");
			}
		}
		int num = equippedIndex;
		ApplyEquipState(index, callLocalEvents: true, num);
		if (index >= 0 && index < localTools.Count && localTools[index] != null)
		{
			if (index == num)
			{
				gameManager.UImanager.ClearEquipmentUI();
			}
			else
			{
				gameManager.UImanager.SetEquipmentUI(localTools[index].itemType);
			}
		}
		else if (index == -1)
		{
			gameManager.UImanager.ClearEquipmentUI();
		}
		CmdEquip(index);
	}

	public void TryEquipByItemType(ItemType itemType)
	{
		if (itemType == ItemType.None)
		{
			TryUnequip();
			return;
		}
		for (int i = 0; i < localTools.Count; i++)
		{
			if (localTools[i] != null && localTools[i].itemType == itemType)
			{
				TryEquipByIndex(i);
				return;
			}
		}
		Debug.LogWarning($"T_Equipments: {itemType} tipinde bir araç bulunamadı!");
	}

	public void TryUnequip()
	{
		if ((base.isOwned || !inputActive) && !(pickupItem != null))
		{
			ApplyEquipState(-1, callLocalEvents: true, equippedIndex);
			CmdEquip(-1);
		}
	}

	[Command]
	private void CmdEquip(int index)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdEquip__Int32(index);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(index);
		SendCommandInternal("System.Void T_Equipments::CmdEquip(System.Int32)", -557805326, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public void OnEquippedIndexChanged(int oldIndex, int newIndex)
	{
		if (!base.isOwned)
		{
			ApplyEquipState(newIndex, callLocalEvents: false, oldIndex);
		}
	}

	private void ApplyEquipState(int newIndex, bool callLocalEvents, int oldIndex = -1)
	{
		for (int i = 0; i < localTools.Count; i++)
		{
			bool flag = i == newIndex;
			if (oldIndex == newIndex && flag)
			{
				onUnequip?.Invoke();
				localTools[i].gameObject.SetActive(value: false);
				if (networkTools.Count - 1 >= i)
				{
					networkTools[i].gameObject.SetActive(value: false);
				}
				if (base.isOwned)
				{
					localTools[i].OnLocalDisable();
					gameManager.UImanager.ClearEquipmentUI();
				}
			}
			else
			{
				if (!localTools[i] || localTools[i].gameObject.activeSelf == flag)
				{
					continue;
				}
				localTools[i].gameObject.SetActive(flag);
				if (networkTools.Count - 1 >= i)
				{
					networkTools[i].gameObject.SetActive(flag);
				}
				if (base.isOwned)
				{
					if (flag)
					{
						if (networkTools.Count > i)
						{
							MeshRenderer[] componentsInChildren = networkTools[i].GetComponentsInChildren<MeshRenderer>(includeInactive: true);
							for (int j = 0; j < componentsInChildren.Length; j++)
							{
								componentsInChildren[j].shadowCastingMode = ShadowCastingMode.ShadowsOnly;
							}
						}
						localTools[i].OnLocalEnable();
						localTools[i].RunAnimationOnEquip();
					}
					else
					{
						localTools[i].OnLocalDisable();
						gameManager.UImanager.ClearEquipmentUI();
					}
				}
				if (flag)
				{
					localTools[i].onEquip.Invoke();
				}
			}
		}
		if (callLocalEvents && oldIndex >= 0 && oldIndex < localTools.Count && localTools[oldIndex] != null)
		{
			if (localTools[oldIndex].itemType == ItemType.Dart && dartManager != null && dartManager.IsInDartGame)
			{
				dartManager.CancelDartGame();
			}
			onUnequip?.Invoke();
		}
	}

	private void OnUsePerformed(InputAction.CallbackContext ctx)
	{
		if (!base.isOwned || !inputActive || onVehicle || (buildingInteractionManager != null && buildingInteractionManager.InputActive) || equippedIndex < 0 || equippedIndex >= localTools.Count)
		{
			return;
		}
		T_Tool t_Tool = localTools[equippedIndex];
		if (!t_Tool)
		{
			return;
		}
		if (t_Tool.itemType == ItemType.Pickup || t_Tool.itemType == ItemType.Building)
		{
			if (!isCharging)
			{
				isCharging = true;
				currentForce = 0f;
			}
		}
		else if (t_Tool.itemType == ItemType.Shovel || t_Tool.itemType == ItemType.Pickaxe || t_Tool.itemType == ItemType.Jackhammer)
		{
			_useHeld = true;
			if (_useHoldRoutine == null)
			{
				_useHoldRoutine = StartCoroutine(UseHoldLoop());
			}
		}
		else if (t_Tool.itemType == ItemType.Dart)
		{
			if (dartManager != null && dartManager.IsInDartGame && !isCharging)
			{
				isCharging = true;
				currentForce = 0f;
			}
		}
		else
		{
			t_Tool.OnUse();
		}
	}

	private void OnUseCanceled(InputAction.CallbackContext ctx)
	{
		if (!base.isOwned || !inputActive || onVehicle || (buildingInteractionManager != null && buildingInteractionManager.InputActive) || equippedIndex < 0 || equippedIndex >= localTools.Count)
		{
			return;
		}
		T_Tool t_Tool = localTools[equippedIndex];
		if (!t_Tool)
		{
			return;
		}
		if (t_Tool.itemType == ItemType.Shovel || t_Tool.itemType == ItemType.Pickaxe || t_Tool.itemType == ItemType.Jackhammer)
		{
			_useHeld = false;
			if (_useHoldRoutine != null)
			{
				StopCoroutine(_useHoldRoutine);
				_useHoldRoutine = null;
			}
		}
		else if (t_Tool.itemType == ItemType.Dart)
		{
			if (isCharging && dartManager != null && dartManager.IsInDartGame)
			{
				dartManager.ThrowDart(currentForce);
				isCharging = false;
				currentForce = 0f;
			}
		}
		else if (!(pickupItem == null) && (t_Tool.itemType == ItemType.Pickup || t_Tool.itemType == ItemType.Building) && isCharging)
		{
			ApplyForce();
			isCharging = false;
		}
	}

	private void OnSecondUsePerformed(InputAction.CallbackContext ctx)
	{
		if (!base.isOwned || !inputActive || onVehicle || (buildingInteractionManager != null && buildingInteractionManager.InputActive) || equippedIndex < 0 || equippedIndex >= localTools.Count)
		{
			return;
		}
		T_Tool t_Tool = localTools[equippedIndex];
		if (!t_Tool)
		{
			return;
		}
		if (t_Tool.itemType == ItemType.Shovel || t_Tool.itemType == ItemType.Pickaxe || t_Tool.itemType == ItemType.Jackhammer)
		{
			_secondUseHeld = true;
			if (_secondUseHoldRoutine == null)
			{
				_secondUseHoldRoutine = StartCoroutine(SecondUseHoldLoop());
			}
			return;
		}
		if (t_Tool.itemType == ItemType.Pickup && pickupItem != null)
		{
			T_Sack component = pickupItem.GetComponent<T_Sack>();
			if (component != null)
			{
				component.TryAddToInventoryFromHand();
				return;
			}
		}
		t_Tool.OnSecondUse();
	}

	private void OnSecondUseCanceled(InputAction.CallbackContext ctx)
	{
		if (base.isOwned)
		{
			_secondUseHeld = false;
			if (_secondUseHoldRoutine != null)
			{
				StopCoroutine(_secondUseHoldRoutine);
				_secondUseHoldRoutine = null;
			}
		}
	}

	private IEnumerator UseHoldLoop()
	{
		while (_useHeld && base.isOwned && inputActive && !onVehicle && (!(buildingInteractionManager != null) || !buildingInteractionManager.InputActive) && equippedIndex >= 0 && equippedIndex < localTools.Count)
		{
			T_Tool t_Tool = localTools[equippedIndex];
			if (!t_Tool || (t_Tool.itemType != ItemType.Shovel && t_Tool.itemType != ItemType.Pickaxe && t_Tool.itemType != ItemType.Jackhammer))
			{
				break;
			}
			t_Tool.OnUse();
			float num = t_Tool.TimeUntilNextUse();
			if (num <= 0f)
			{
				yield return null;
			}
			else
			{
				yield return new WaitForSeconds(num);
			}
		}
		_useHoldRoutine = null;
		_useHeld = false;
	}

	private IEnumerator SecondUseHoldLoop()
	{
		while (_secondUseHeld && base.isOwned && inputActive && !onVehicle && (!(buildingInteractionManager != null) || !buildingInteractionManager.InputActive) && equippedIndex >= 0 && equippedIndex < localTools.Count)
		{
			T_Tool t_Tool = localTools[equippedIndex];
			if (!t_Tool || (t_Tool.itemType != ItemType.Shovel && t_Tool.itemType != ItemType.Pickaxe && t_Tool.itemType != ItemType.Jackhammer))
			{
				break;
			}
			t_Tool.OnSecondUse();
			float num = t_Tool.TimeUntilNextSecondUse();
			if (num <= 0f)
			{
				yield return null;
			}
			else
			{
				yield return new WaitForSeconds(num);
			}
		}
		_secondUseHoldRoutine = null;
		_secondUseHeld = false;
	}

	public void ApplyForce()
	{
		if (pickupItem != null)
		{
			T_Pickup component = pickupItem.GetComponent<T_Pickup>();
			if (component != null)
			{
				Vector3 normalized = (Camera.main.transform.forward + Vector3.up * 0.25f).normalized;
				component.TryRelease(normalized, currentForce);
				ClearPickupItem();
				TryUnequip();
			}
		}
	}

	public void DigableAreaCheck()
	{
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		if (!Physics.Raycast(ray, out var hitInfo, 2f, terrainMask, QueryTriggerInteraction.Ignore))
		{
			return;
		}
		GamePlayer gamePlayer = null;
		if (hitInfo.transform.gameObject.layer == 21)
		{
			gamePlayer = hitInfo.transform.root.GetComponent<GamePlayer>();
			if (gamePlayer == null)
			{
				gamePlayer = hitInfo.transform.root.GetComponentInChildren<GamePlayer>();
			}
		}
		if (gamePlayer != null && !gamePlayer.isOwned)
		{
			float num = 0f;
			if (equippedIndex >= 0 && equippedIndex < localTools.Count && localTools[equippedIndex] != null)
			{
				switch (localTools[equippedIndex].itemType)
				{
				case ItemType.Shovel:
					num = UpgradeManager.Instance.shovelPlayerDamageValue;
					break;
				case ItemType.Pickaxe:
					num = UpgradeManager.Instance.pickaxePlayerDamageValue;
					break;
				case ItemType.Jackhammer:
					num = UpgradeManager.Instance.jackhammerPlayerDamageValue;
					break;
				}
			}
			if (num > 0f)
			{
				onHitEvent.Invoke();
				gamePlayer.SendDamage(num);
				Debug.Log($"[T_Equipments] Player'a hasar gönderildi: {num} -> {gamePlayer.playerName}");
			}
		}
		else if (hitInfo.transform.gameObject.layer == 7 && DiggerController.Instance != null)
		{
			if (!DiggerController.Instance.IsInsideDigBoundary(hitInfo.point))
			{
				if (gameManager.notificationManager != null)
				{
					gameManager.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_NotDiggable"));
				}
				TrySendNotDigableVFX(hitInfo.point, -ray.direction);
			}
		}
		else if (hitInfo.transform.gameObject.layer != 7 && hitInfo.transform.gameObject.layer != 18)
		{
			if (gameManager.notificationManager != null)
			{
				gameManager.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_NotDiggable"));
			}
			TrySendNotDigableVFX(hitInfo.point, -ray.direction);
			onHitEvent.Invoke();
		}
	}

	public void TrySendNotDigableVFX(Vector3 vfxPos, Vector3 vfxRot)
	{
		ExecuteNotDigableVFX(vfxPos, vfxRot);
		if (base.isServer)
		{
			RunNotDigableVFX(vfxPos, vfxRot);
		}
		else
		{
			CMDNotDigableVFX(vfxPos, vfxRot);
		}
	}

	[Command(requiresAuthority = false)]
	public void CMDNotDigableVFX(Vector3 vfxPos, Vector3 vfxRot)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CMDNotDigableVFX__Vector3__Vector3(vfxPos, vfxRot);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(vfxPos);
		writer.WriteVector3(vfxRot);
		SendCommandInternal("System.Void T_Equipments::CMDNotDigableVFX(UnityEngine.Vector3,UnityEngine.Vector3)", -1269434364, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void RunNotDigableVFX(Vector3 vfxPos, Vector3 vfxRot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(vfxPos);
		writer.WriteVector3(vfxRot);
		SendRPCInternal("System.Void T_Equipments::RunNotDigableVFX(UnityEngine.Vector3,UnityEngine.Vector3)", 1169793193, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ExecuteNotDigableVFX(Vector3 vfxPos, Vector3 vfxRot)
	{
		GameManager gameManager = ((this.gameManager != null) ? this.gameManager : GameManager.Instance);
		if (!(gameManager == null) && !(gameManager.poolingManager == null))
		{
			GameObject pooledObjectByType = gameManager.poolingManager.GetPooledObjectByType(LayerVFX.ConcreteVFX);
			if (pooledObjectByType != null)
			{
				pooledObjectByType.transform.position = new Vector3(vfxPos.x, vfxPos.y, vfxPos.z);
				Vector3 normalized = vfxRot.normalized;
				pooledObjectByType.transform.rotation = Quaternion.FromToRotation(pooledObjectByType.transform.up, normalized) * pooledObjectByType.transform.rotation;
				pooledObjectByType.SetActive(value: true);
			}
			if (SoundManager.Instance != null)
			{
				SoundManager.Instance.PlaySFXAtPosition(LayerSFX.ConcreteSFX, vfxPos);
			}
		}
	}

	public bool TryAddDirt(int amount = 1)
	{
		if (currentDirt >= maxDirt)
		{
			return false;
		}
		currentDirt = Mathf.Min(currentDirt + amount, maxDirt);
		this.OnDirtChanged?.Invoke(currentDirt, maxDirt);
		return true;
	}

	public bool TryRemoveDirt(int amount = 1)
	{
		if (currentDirt < amount)
		{
			return false;
		}
		currentDirt -= amount;
		this.OnDirtChanged?.Invoke(currentDirt, maxDirt);
		return true;
	}

	public bool HasDirt()
	{
		return currentDirt > 0;
	}

	public bool IsDirtFull()
	{
		return currentDirt >= maxDirt;
	}

	public void StartBuildingMode(int toolIndex = -1)
	{
		Debug.Log($"[Building] StartBuildingMode() çağrıldı. toolIndex: {toolIndex}, equippedIndex: {equippedIndex}");
		if (buildingInteractionManager == null)
		{
			Debug.LogError("[Building] BuildingInteractionManager referansı eksik! T_Equipments component'inde buildingInteractionManager referansını atamalısın!");
			return;
		}
		if (pickupItem == null)
		{
			Debug.LogError("[Building] pickupItem null! Building kutusu ele alınmamış olabilir.");
			return;
		}
		T_Building component = pickupItem.GetComponent<T_Building>();
		if (component == null)
		{
			Debug.LogError("[Building] T_Building component'i pickupItem'da bulunamadı! Building kutusu prefab'ında T_Building component'i olmalı!");
			return;
		}
		GameObject buildingPrefab = component.GetBuildingPrefab();
		if (buildingPrefab == null)
		{
			Debug.LogError("[Building] Building prefab referansı T_Building component'inde eksik! BuildingItemSO'da Prefab referansını atamalısın!");
			return;
		}
		if (isCharging)
		{
			isCharging = false;
			currentForce = 0f;
		}
		currentBuildingSource = BuildingModeSource.BuildingBox;
		currentRadialBuildingSO = null;
		if (RadialBuildingManager.Instance != null)
		{
			RadialBuildingManager.Instance.SetBuildingModeSource(BuildingModeSource.BuildingBox);
		}
		Debug.Log("[Building] Building modu başlatılıyor (BuildingBox). Prefab: " + buildingPrefab.name);
		buildingInteractionManager.SetInputActive(input: true);
		SpawnBuildingPreview(buildingPrefab);
		if (gameManager != null && gameManager.UImanager != null)
		{
			gameManager.UImanager.StartBuildingBoxPlaceMode(component.BuildingItemSO);
		}
	}

	public void StartBuildingModeFromRadialMenu(T_BuildingItemSO buildingSO)
	{
		Debug.Log("[Building] StartBuildingModeFromRadialMenu() çağrıldı. BuildingSO: " + buildingSO?.Name);
		if (buildingInteractionManager == null)
		{
			Debug.LogError("[Building] BuildingInteractionManager referansı eksik!");
			return;
		}
		if (buildingSO == null)
		{
			Debug.LogError("[Building] BuildingSO null!");
			return;
		}
		if (buildingSO.Prefab == null)
		{
			Debug.LogError("[Building] BuildingSO.Prefab null! SO: " + buildingSO.Name);
			return;
		}
		if (pickupItem != null)
		{
			T_Pickup component = pickupItem.GetComponent<T_Pickup>();
			if (component != null)
			{
				Debug.Log($"[Building] Radial menu building başlatılıyor - Eldeki kutu yere atılıyor: {component.itemType}");
				Vector3 normalized = (Camera.main.transform.forward + Vector3.up * 0.25f).normalized;
				float power = 5f;
				component.TryRelease(normalized, power);
				ClearPickupItem();
			}
		}
		if (equippedIndex >= 0 && equippedIndex < localTools.Count && localTools[equippedIndex] != null)
		{
			Debug.Log($"[Building] Radial menu building başlatılıyor - Eldeki tool unequip ediliyor: {localTools[equippedIndex].itemType}");
			ApplyEquipState(-1, callLocalEvents: true, equippedIndex);
			CmdEquip(-1);
			gameManager.UImanager.ClearEquipmentUI();
		}
		currentBuildingSource = BuildingModeSource.RadialMenu;
		currentRadialBuildingSO = buildingSO;
		Debug.Log("[Building] Building modu başlatılıyor (Equipments). SO: " + buildingSO.Name + ", Prefab: " + buildingSO.Prefab.name);
		buildingInteractionManager.SetInputActive(input: true);
		SpawnBuildingPreviewFromSO(buildingSO);
	}

	public void ChangeBuildingInRadialMode(T_BuildingItemSO newBuildingSO)
	{
		if (currentBuildingSource != BuildingModeSource.RadialMenu)
		{
			Debug.LogWarning("[Building] ChangeBuildingInRadialMode: Source Equipments değil!");
			return;
		}
		if (newBuildingSO == null || newBuildingSO.Prefab == null)
		{
			Debug.LogError("[Building] ChangeBuildingInRadialMode: newBuildingSO veya Prefab null!");
			return;
		}
		Debug.Log("[Building] Building değiştiriliyor (Equipments). Yeni SO: " + newBuildingSO.Name);
		if (buildingInteractionManager != null)
		{
			buildingInteractionManager.CancelBuilding();
		}
		currentRadialBuildingSO = newBuildingSO;
		SpawnBuildingPreviewFromSO(newBuildingSO);
	}

	public void ContinueBuildingInRadialMode(T_BuildingItemSO buildingSO)
	{
		Debug.Log($"[Building] ContinueBuildingInRadialMode çağrıldı - currentBuildingSource: {currentBuildingSource}, buildingSO: {buildingSO?.Name}");
		if (currentBuildingSource != BuildingModeSource.RadialMenu)
		{
			Debug.LogWarning($"[Building] ContinueBuildingInRadialMode: Source Equipments değil! currentBuildingSource: {currentBuildingSource}");
			return;
		}
		if (buildingSO == null || buildingSO.Prefab == null)
		{
			Debug.LogError("[Building] ContinueBuildingInRadialMode: buildingSO veya Prefab null!");
			return;
		}
		Debug.Log("[Building] Aynı building ile devam ediliyor (Equipments). SO: " + buildingSO.Name);
		SpawnBuildingPreviewFromSO(buildingSO);
	}

	public void StopBuildingMode()
	{
		BuildingModeSource buildingModeSource = currentBuildingSource;
		if (buildingInteractionManager != null)
		{
			buildingInteractionManager.SetInputActive(input: false);
			buildingInteractionManager.ClearBuildingObject();
		}
		currentBuildingSource = BuildingModeSource.None;
		currentRadialBuildingSO = null;
		if (RadialBuildingManager.Instance != null)
		{
			RadialBuildingManager.Instance.SetBuildingModeSource(BuildingModeSource.None);
		}
		if (gameManager != null && gameManager.UImanager != null)
		{
			switch (buildingModeSource)
			{
			case BuildingModeSource.Relocate:
				gameManager.UImanager.CloseBuildingUI();
				gameManager.UImanager.CloseBuildingPlaceModeUI();
				ShowCurrentTool();
				break;
			case BuildingModeSource.BuildingBox:
				gameManager.UImanager.StopBuildingBoxPlaceMode();
				break;
			}
		}
		else if (buildingModeSource == BuildingModeSource.Relocate)
		{
			ShowCurrentTool();
		}
	}

	public void SaveToolTypeForRelocate(ItemType itemType)
	{
		previousToolTypeBeforeRelocate = itemType;
		Debug.Log($"[T_Equipments] SaveToolTypeForRelocate: Tool type kaydedildi - {itemType}");
	}

	public void SetCurrentBuildingSource(BuildingModeSource source)
	{
		currentBuildingSource = source;
		Debug.Log($"[T_Equipments] SetCurrentBuildingSource: Building source set edildi - {source}");
	}

	private void ShowCurrentTool()
	{
		if (previousToolTypeBeforeRelocate != ItemType.None)
		{
			Debug.Log($"[T_Equipments] ShowCurrentTool: Tool tekrar equip ediliyor - ItemType: {previousToolTypeBeforeRelocate}");
			TryEquipByItemType(previousToolTypeBeforeRelocate);
			previousToolTypeBeforeRelocate = ItemType.None;
		}
		else
		{
			Debug.LogWarning("[T_Equipments] ShowCurrentTool: Önceki tool type bulunamadı (None)");
		}
	}

	private void SpawnBuildingPreview(GameObject prefab)
	{
		Debug.Log(string.Format("[Building] SpawnBuildingPreview() çağrıldı. isOwned: {0}, prefab: {1}", base.isOwned, (prefab != null) ? prefab.name : "null"));
		if (!base.isOwned)
		{
			Debug.LogWarning("[Building] SpawnBuildingPreview: isOwned false!");
			return;
		}
		if (prefab == null)
		{
			Debug.LogError("[Building] SpawnBuildingPreview: Prefab null!");
			return;
		}
		Debug.Log("[Building] SpawnBuildingPreview: Prefab: " + prefab.name);
		if (pickupItem == null)
		{
			Debug.LogError("[Building] SpawnBuildingPreview: pickupItem null!");
			return;
		}
		NetworkIdentity component = pickupItem.GetComponent<NetworkIdentity>();
		if (component == null)
		{
			Debug.LogError("[Building] SpawnBuildingPreview: pickupItem'da NetworkIdentity yok!");
			return;
		}
		uint pickupItemNetId = component.netId;
		Vector3 position = base.transform.position;
		Quaternion rotation = Quaternion.identity;
		if (buildingInteractionManager != null)
		{
			buildingInteractionManager.TryGetInitialSpawnTransform(prefab, out position, out rotation);
		}
		else
		{
			Transform transform = (Camera.main ? Camera.main.transform : base.transform);
			position = transform.position + transform.forward * 2f;
			rotation = Quaternion.identity;
		}
		if (NetworkServer.active)
		{
			ServerSpawnBuildingPreview(pickupItemNetId, position, rotation);
		}
		else
		{
			CmdSpawnBuildingPreview(pickupItemNetId, position, rotation);
		}
	}

	private void SpawnBuildingPreviewFromSO(T_BuildingItemSO buildingSO)
	{
		Debug.Log($"[Building] SpawnBuildingPreviewFromSO() çağrıldı. isOwned: {base.isOwned}, SO: {buildingSO?.Name}");
		if (!base.isOwned)
		{
			Debug.LogWarning("[Building] SpawnBuildingPreviewFromSO: isOwned false!");
			return;
		}
		if (buildingSO == null || buildingSO.Prefab == null)
		{
			Debug.LogError("[Building] SpawnBuildingPreviewFromSO: BuildingSO veya Prefab null!");
			return;
		}
		IReadOnlyList<T_BuildingItemSO> allBuildingItemSOs = ScriptableListManager.Instance.AllBuildingItemSOs;
		int num = -1;
		for (int i = 0; i < allBuildingItemSOs.Count; i++)
		{
			if (allBuildingItemSOs[i] == buildingSO)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			Debug.LogError("[Building] SpawnBuildingPreviewFromSO: SO index bulunamadı! SO: " + buildingSO.Name);
			return;
		}
		Debug.Log($"[Building] SpawnBuildingPreviewFromSO: SO: {buildingSO.Name}, Index: {num}");
		Vector3 position = base.transform.position;
		Quaternion rotation = Quaternion.identity;
		if (buildingInteractionManager != null)
		{
			buildingInteractionManager.TryGetInitialSpawnTransform(buildingSO.Prefab, out position, out rotation);
		}
		else
		{
			Transform transform = (Camera.main ? Camera.main.transform : base.transform);
			position = transform.position + transform.forward * 2f;
			rotation = Quaternion.identity;
		}
		if (NetworkServer.active)
		{
			ServerSpawnBuildingPreviewFromSO(num, position, rotation);
		}
		else
		{
			CmdSpawnBuildingPreviewFromSO(num, position, rotation);
		}
	}

	[Server]
	private void ServerSpawnBuildingPreviewFromSO(int soIndex, Vector3 spawnPosition, Quaternion spawnRotation)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Equipments::ServerSpawnBuildingPreviewFromSO(System.Int32,UnityEngine.Vector3,UnityEngine.Quaternion)' called when server was not active");
			return;
		}
		IReadOnlyList<T_BuildingItemSO> allBuildingItemSOs = ScriptableListManager.Instance.AllBuildingItemSOs;
		if (soIndex < 0 || soIndex >= allBuildingItemSOs.Count)
		{
			Debug.LogError($"[Building] ServerSpawnBuildingPreviewFromSO: Geçersiz SO index! Index: {soIndex}");
			return;
		}
		T_BuildingItemSO t_BuildingItemSO = allBuildingItemSOs[soIndex];
		if (t_BuildingItemSO == null || t_BuildingItemSO.Prefab == null)
		{
			Debug.LogError($"[Building] ServerSpawnBuildingPreviewFromSO: BuildingSO veya Prefab null! Index: {soIndex}");
			return;
		}
		GameObject prefab = t_BuildingItemSO.Prefab;
		Debug.Log("[Building] ServerSpawnBuildingPreviewFromSO() çağrıldı. SO: " + t_BuildingItemSO.Name + ", Prefab: " + prefab.name);
		GameObject gameObject = UnityEngine.Object.Instantiate(prefab, spawnPosition, spawnRotation);
		if (gameObject == null)
		{
			Debug.LogError("[Building] ServerSpawnBuildingPreviewFromSO: Instantiate başarısız!");
			return;
		}
		NetworkIdentity component = gameObject.GetComponent<NetworkIdentity>();
		if (component == null)
		{
			Debug.LogError("[Building] ServerSpawnBuildingPreviewFromSO: Building prefab'ında NetworkIdentity component'i yok!");
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		BuildingObject component2 = gameObject.GetComponent<BuildingObject>();
		if (component2 != null)
		{
			component2.buildingPrefab = prefab;
			component2.buildingItemSO = t_BuildingItemSO;
			component2.SetBuildingItemSOIndex(soIndex);
			component2.SetBuildingModeSource(BuildingModeSource.RadialMenu);
			Debug.Log("[Building] BuildingObject'e SO set edildi (Equipments server): " + t_BuildingItemSO.Name);
		}
		NetworkConnectionToClient ownerConnection = null;
		if (base.connectionToClient != null)
		{
			ownerConnection = base.connectionToClient;
		}
		else if (base.isLocalPlayer)
		{
			ownerConnection = NetworkServer.localConnection;
		}
		NetworkServer.Spawn(gameObject, ownerConnection);
		Debug.Log($"[Building] Building instance spawn edildi (Equipments). NetId: {component.netId}");
		RpcSetBuildingObject(gameObject, BuildingModeSource.RadialMenu);
	}

	[Command]
	private void CmdSpawnBuildingPreviewFromSO(int soIndex, Vector3 spawnPosition, Quaternion spawnRotation)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSpawnBuildingPreviewFromSO__Int32__Vector3__Quaternion(soIndex, spawnPosition, spawnRotation);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(soIndex);
		writer.WriteVector3(spawnPosition);
		writer.WriteQuaternion(spawnRotation);
		SendCommandInternal("System.Void T_Equipments::CmdSpawnBuildingPreviewFromSO(System.Int32,UnityEngine.Vector3,UnityEngine.Quaternion)", 1047253485, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerSpawnBuildingPreview(uint pickupItemNetId, Vector3 spawnPosition, Quaternion spawnRotation)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Equipments::ServerSpawnBuildingPreview(System.UInt32,UnityEngine.Vector3,UnityEngine.Quaternion)' called when server was not active");
			return;
		}
		if (!NetworkServer.spawned.TryGetValue(pickupItemNetId, out var value))
		{
			Debug.LogError($"[Building] ServerSpawnBuildingPreview: pickupItem NetId ({pickupItemNetId}) bulunamadı!");
			return;
		}
		GameObject gameObject = value.gameObject;
		T_Building component = gameObject.GetComponent<T_Building>();
		if (component == null)
		{
			Debug.LogError("[Building] ServerSpawnBuildingPreview: pickupItem'da T_Building component'i bulunamadı!");
			return;
		}
		GameObject buildingPrefab = component.GetBuildingPrefab();
		if (buildingPrefab == null)
		{
			Debug.LogError("[Building] ServerSpawnBuildingPreview: Building prefab referansı T_Building component'inde eksik! BuildingItemSO'da Prefab referansını atamalısın!");
			return;
		}
		Debug.Log("[Building] ServerSpawnBuildingPreview() çağrıldı. Prefab: " + buildingPrefab.name);
		GameObject gameObject2 = UnityEngine.Object.Instantiate(buildingPrefab, spawnPosition, spawnRotation);
		if (gameObject2 == null)
		{
			Debug.LogError("[Building] ServerSpawnBuildingPreview: Instantiate başarısız!");
			return;
		}
		NetworkIdentity component2 = gameObject2.GetComponent<NetworkIdentity>();
		if (component2 == null)
		{
			Debug.LogError("[Building] ServerSpawnBuildingPreview: Building prefab'ında NetworkIdentity component'i yok!");
			UnityEngine.Object.Destroy(gameObject2);
			return;
		}
		BuildingObject component3 = gameObject2.GetComponent<BuildingObject>();
		if (component3 != null)
		{
			component3.buildingPrefab = buildingPrefab;
			component3.SetBuildingModeSource(BuildingModeSource.BuildingBox);
			if (gameObject != null)
			{
				T_Building component4 = gameObject.GetComponent<T_Building>();
				if (component4 != null && component4.BuildingItemSO != null)
				{
					component3.buildingItemSO = component4.BuildingItemSO;
					Debug.Log("[Building] BuildingObject'e SO set edildi (server): " + component4.BuildingItemSO.Name);
					IReadOnlyList<T_BuildingItemSO> allBuildingItemSOs = ScriptableListManager.Instance.AllBuildingItemSOs;
					int num = -1;
					for (int i = 0; i < allBuildingItemSOs.Count; i++)
					{
						if (allBuildingItemSOs[i] == component4.BuildingItemSO)
						{
							num = i;
							break;
						}
					}
					if (num >= 0)
					{
						component3.SetBuildingItemSOIndex(num);
						Debug.Log($"[Building] BuildingObject'e SO index set edildi (server): {num}, SO: {component4.BuildingItemSO.Name}");
					}
					else
					{
						Debug.LogWarning("[Building] BuildingObject SO index bulunamadı! SO: " + component4.BuildingItemSO.Name);
					}
				}
			}
		}
		NetworkConnectionToClient ownerConnection = null;
		if (base.connectionToClient != null)
		{
			ownerConnection = base.connectionToClient;
		}
		else if (base.isLocalPlayer)
		{
			ownerConnection = NetworkServer.localConnection;
		}
		NetworkServer.Spawn(gameObject2, ownerConnection);
		Debug.Log($"[Building] Building instance spawn edildi. NetId: {component2.netId}");
		BuildingObject component5 = gameObject2.GetComponent<BuildingObject>();
		if (component5 != null)
		{
			component5.SetPickupItemNetId(pickupItemNetId);
			Debug.Log($"[Building] BuildingObject'e pickupItem NetId set edildi: {pickupItemNetId}");
		}
		RpcSetBuildingObject(gameObject2, BuildingModeSource.BuildingBox);
	}

	[Command]
	private void CmdSpawnBuildingPreview(uint pickupItemNetId, Vector3 spawnPosition, Quaternion spawnRotation)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSpawnBuildingPreview__UInt32__Vector3__Quaternion(pickupItemNetId, spawnPosition, spawnRotation);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(pickupItemNetId);
		writer.WriteVector3(spawnPosition);
		writer.WriteQuaternion(spawnRotation);
		SendCommandInternal("System.Void T_Equipments::CmdSpawnBuildingPreview(System.UInt32,UnityEngine.Vector3,UnityEngine.Quaternion)", -498841394, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcSetBuildingObject(GameObject buildingInstance, BuildingModeSource buildingSource)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(buildingInstance);
		GeneratedNetworkCode._Write_BuildingModeSource(writer, buildingSource);
		SendRPCInternal("System.Void T_Equipments::RpcSetBuildingObject(UnityEngine.GameObject,BuildingModeSource)", -1068012175, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnActivateBuildingModePerformed(InputAction.CallbackContext ctx)
	{
		if (base.isOwned && inputActive && !onVehicle)
		{
			if (pickupItem == null)
			{
				Debug.LogWarning("[Building] Building mode başlatılamadı: pickupItem null!");
			}
			else if (pickupItem.GetComponent<T_Building>() == null)
			{
				Debug.LogWarning("[Building] Building mode başlatılamadı: pickupItem'da T_Building component'i yok!");
			}
			else
			{
				StartBuildingMode();
			}
		}
	}

	private void OnPlacePerformed(InputAction.CallbackContext ctx)
	{
		if (!base.isOwned || !inputActive || onVehicle || buildingInteractionManager == null || !buildingInteractionManager.InputActive)
		{
			return;
		}
		if (currentBuildingSource == BuildingModeSource.RadialMenu)
		{
			buildingInteractionManager.PlaceBuilding();
		}
		else if (currentBuildingSource == BuildingModeSource.Relocate)
		{
			buildingInteractionManager.PlaceBuilding();
		}
		else if (equippedIndex >= 0 && equippedIndex < localTools.Count)
		{
			T_Tool t_Tool = localTools[equippedIndex];
			if (!(t_Tool == null) && t_Tool.itemType == ItemType.Building)
			{
				buildingInteractionManager.PlaceBuilding();
			}
		}
	}

	private void OnRotatePerformed(InputAction.CallbackContext ctx)
	{
		if (!base.isOwned || !inputActive || onVehicle)
		{
			return;
		}
		if (equippedIndex >= 0 && equippedIndex < localTools.Count)
		{
			T_Tool t_Tool = localTools[equippedIndex];
			if (t_Tool != null && t_Tool.itemType == ItemType.Detector)
			{
				DetectorScanner detectorScanner = t_Tool.GetComponent<DetectorScanner>();
				if (detectorScanner == null)
				{
					detectorScanner = t_Tool.GetComponentInChildren<DetectorScanner>();
				}
				if (!(detectorScanner != null))
				{
					return;
				}
				UIManager uIManager = gameManager?.UImanager;
				if (uIManager != null)
				{
					if (uIManager.IsDetectorTargetSelectionPanelOpen())
					{
						uIManager.CloseDetectorTargetSelectionPanel();
					}
					else if (ComputerPropertyManager.Instance == null || ComputerPropertyManager.Instance.GetActivePropertyItems() == null || ComputerPropertyManager.Instance.GetActivePropertyItems().Count == 0)
					{
						GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_NoDigsiteAvailable"));
					}
					else
					{
						uIManager.OpenDetectorTargetSelectionPanel();
					}
				}
				return;
			}
		}
		if (buildingInteractionManager == null || !buildingInteractionManager.InputActive)
		{
			return;
		}
		float num = ctx.ReadValue<float>();
		if (currentBuildingSource == BuildingModeSource.RadialMenu)
		{
			buildingInteractionManager.RotateBuilding((num > 0f) ? 1f : (-1f));
		}
		else if (currentBuildingSource == BuildingModeSource.Relocate)
		{
			buildingInteractionManager.RotateBuilding((num > 0f) ? 1f : (-1f));
		}
		else if (equippedIndex >= 0 && equippedIndex < localTools.Count)
		{
			T_Tool t_Tool2 = localTools[equippedIndex];
			if (!(t_Tool2 == null) && t_Tool2.itemType == ItemType.Building)
			{
				buildingInteractionManager.RotateBuilding((num > 0f) ? 1f : (-1f));
			}
		}
	}

	private void OnBuildPerformed(InputAction.CallbackContext ctx)
	{
		if (!base.isOwned || !inputActive || onVehicle || buildingInteractionManager == null || !buildingInteractionManager.InputActive)
		{
			return;
		}
		if (currentBuildingSource == BuildingModeSource.RadialMenu)
		{
			buildingInteractionManager.PlaceBuilding();
		}
		else if (currentBuildingSource == BuildingModeSource.Relocate)
		{
			buildingInteractionManager.PlaceBuilding();
		}
		else if (equippedIndex >= 0 && equippedIndex < localTools.Count)
		{
			T_Tool t_Tool = localTools[equippedIndex];
			if (!(t_Tool == null) && t_Tool.itemType == ItemType.Building)
			{
				buildingInteractionManager.PlaceBuilding();
			}
		}
	}

	private void OnCancelPerformed(InputAction.CallbackContext ctx)
	{
		if (!base.isOwned || !inputActive || onVehicle || buildingInteractionManager == null || !buildingInteractionManager.InputActive)
		{
			return;
		}
		if (currentBuildingSource == BuildingModeSource.RadialMenu)
		{
			if (RadialBuildingManager.Instance != null)
			{
				RadialBuildingManager.Instance.CancelBuilding();
			}
			else
			{
				buildingInteractionManager.CancelBuilding();
				StopBuildingMode();
			}
			Debug.Log("[Building] Building mode iptal edildi (Equipments).");
		}
		else if (currentBuildingSource == BuildingModeSource.Relocate)
		{
			buildingInteractionManager.CancelBuilding();
			StopBuildingMode();
			Debug.Log("[Building] Building mode iptal edildi (Relocate).");
		}
		else if (equippedIndex >= 0 && equippedIndex < localTools.Count)
		{
			T_Tool t_Tool = localTools[equippedIndex];
			if (!(t_Tool == null) && t_Tool.itemType == ItemType.Building)
			{
				buildingInteractionManager.CancelBuilding();
				StopBuildingMode();
				Debug.Log("[Building] Building mode iptal edildi (BuildingBox).");
			}
		}
	}

	private void OnHideEquipmentPerformed(InputAction.CallbackContext ctx)
	{
		if (base.isOwned && inputActive && !onVehicle)
		{
			TryUnequip();
		}
	}

	private void OnToggleContractHUDPerformed(InputAction.CallbackContext ctx)
	{
		if (base.isOwned && gameManager != null && gameManager.UImanager != null)
		{
			gameManager.UImanager.ToggleContractHUDDetails();
		}
	}

	private void OnQuickEquipPerformed(InputAction.CallbackContext ctx)
	{
		if (base.isOwned && inputActive && !onVehicle && (!(buildingInteractionManager != null) || !buildingInteractionManager.InputActive) && (equippedIndex < 0 || equippedIndex >= localTools.Count || !(localTools[equippedIndex] != null) || localTools[equippedIndex].itemType != ItemType.Detector))
		{
			TryEquipByIndex(4);
		}
	}

	private void OnScrollBuildingPerformed(InputAction.CallbackContext ctx)
	{
		if (!base.isOwned || !inputActive || onVehicle || currentBuildingSource != BuildingModeSource.RadialMenu || buildingInteractionManager == null || !buildingInteractionManager.InputActive)
		{
			return;
		}
		float num = ctx.ReadValue<float>();
		if (!(Mathf.Abs(num) < 0.1f))
		{
			int direction = ((num > 0f) ? 1 : (-1));
			if (RadialBuildingManager.Instance != null)
			{
				RadialBuildingManager.Instance.CycleBuilding(direction);
			}
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdResaleBuilding(uint buildingNetId, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdResaleBuilding__UInt32__NetworkConnectionToClient(buildingNetId, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(buildingNetId);
		SendCommandInternal("System.Void T_Equipments::CmdResaleBuilding(System.UInt32,Mirror.NetworkConnectionToClient)", -600750494, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdRelocateBuilding(uint buildingNetId, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRelocateBuilding__UInt32__NetworkConnectionToClient(buildingNetId, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(buildingNetId);
		SendCommandInternal("System.Void T_Equipments::CmdRelocateBuilding(System.UInt32,Mirror.NetworkConnectionToClient)", 1905050747, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public T_Equipments()
	{
		_Mirror_SyncVarHookDelegate_equippedIndex = OnEquippedIndexChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdEquip__Int32(int index)
	{
		if (index == equippedIndex)
		{
			index = -1;
		}
		if (index >= -1 && index < localTools.Count)
		{
			NetworkequippedIndex = index;
		}
	}

	protected static void InvokeUserCode_CmdEquip__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdEquip called on client.");
		}
		else
		{
			((T_Equipments)obj).UserCode_CmdEquip__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_CMDNotDigableVFX__Vector3__Vector3(Vector3 vfxPos, Vector3 vfxRot)
	{
		RunNotDigableVFX(vfxPos, vfxRot);
	}

	protected static void InvokeUserCode_CMDNotDigableVFX__Vector3__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CMDNotDigableVFX called on client.");
		}
		else
		{
			((T_Equipments)obj).UserCode_CMDNotDigableVFX__Vector3__Vector3(reader.ReadVector3(), reader.ReadVector3());
		}
	}

	protected void UserCode_RunNotDigableVFX__Vector3__Vector3(Vector3 vfxPos, Vector3 vfxRot)
	{
		if (!base.isOwned)
		{
			ExecuteNotDigableVFX(vfxPos, vfxRot);
		}
	}

	protected static void InvokeUserCode_RunNotDigableVFX__Vector3__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RunNotDigableVFX called on server.");
		}
		else
		{
			((T_Equipments)obj).UserCode_RunNotDigableVFX__Vector3__Vector3(reader.ReadVector3(), reader.ReadVector3());
		}
	}

	protected void UserCode_CmdSpawnBuildingPreviewFromSO__Int32__Vector3__Quaternion(int soIndex, Vector3 spawnPosition, Quaternion spawnRotation)
	{
		ServerSpawnBuildingPreviewFromSO(soIndex, spawnPosition, spawnRotation);
	}

	protected static void InvokeUserCode_CmdSpawnBuildingPreviewFromSO__Int32__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawnBuildingPreviewFromSO called on client.");
		}
		else
		{
			((T_Equipments)obj).UserCode_CmdSpawnBuildingPreviewFromSO__Int32__Vector3__Quaternion(reader.ReadVarInt(), reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_CmdSpawnBuildingPreview__UInt32__Vector3__Quaternion(uint pickupItemNetId, Vector3 spawnPosition, Quaternion spawnRotation)
	{
		ServerSpawnBuildingPreview(pickupItemNetId, spawnPosition, spawnRotation);
	}

	protected static void InvokeUserCode_CmdSpawnBuildingPreview__UInt32__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawnBuildingPreview called on client.");
		}
		else
		{
			((T_Equipments)obj).UserCode_CmdSpawnBuildingPreview__UInt32__Vector3__Quaternion(reader.ReadVarUInt(), reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_RpcSetBuildingObject__GameObject__BuildingModeSource(GameObject buildingInstance, BuildingModeSource buildingSource)
	{
		Debug.Log(string.Format("[Building] RpcSetBuildingObject() çağrıldı. isOwned: {0}, buildingInstance: {1}, source: {2}", base.isOwned, (buildingInstance != null) ? buildingInstance.name : "null", buildingSource));
		if (buildingInstance == null)
		{
			Debug.LogError("[Building] RpcSetBuildingObject: buildingInstance null!");
			return;
		}
		BuildingObject component = buildingInstance.GetComponent<BuildingObject>();
		if (component == null)
		{
			Debug.LogError("[Building] RpcSetBuildingObject: BuildingObject component bulunamadı!");
		}
		else if (base.isOwned)
		{
			if (buildingInteractionManager == null)
			{
				Debug.LogError("[Building] RpcSetBuildingObject: buildingInteractionManager null!");
				return;
			}
			if (currentBuildingSource == BuildingModeSource.None && !buildingInteractionManager.InputActive)
			{
				Debug.LogWarning("[Building] RpcSetBuildingObject: Building mode zaten kapatılmış - gelen preview cancel ediliyor. BuildingObject: " + component.name);
				component.CancelBuilding();
				return;
			}
			Debug.Log($"[Building] BuildingObject BuildingInteractionManager'a set ediliyor... Source: {buildingSource}");
			GameObject gameObject = component.buildingPrefab;
			if (gameObject == null && component.buildingItemSO != null)
			{
				gameObject = component.buildingItemSO.Prefab;
				if (gameObject != null)
				{
					Debug.Log("[Building] RpcSetBuildingObject (CLIENT): buildingPrefab null, SO'dan alındı - SO: " + component.buildingItemSO.Name + ", Prefab: " + gameObject.name);
					component.buildingPrefab = gameObject;
				}
			}
			if (gameObject == null)
			{
				Debug.LogWarning("[Building] RpcSetBuildingObject (CLIENT): buildingPrefab ve buildingItemSO.Prefab null! BuildingObject: " + component.name + ", buildingItemSO: " + ((component.buildingItemSO != null) ? component.buildingItemSO.Name : "null"));
			}
			T_BuildingItemSO buildingItemSO = component.buildingItemSO;
			buildingInteractionManager.SetBuildingObject(component, gameObject, buildingItemSO, buildingSource);
		}
		else if (component.previewGameObject != null)
		{
			component.previewGameObject.SetActive(value: true);
		}
	}

	protected static void InvokeUserCode_RpcSetBuildingObject__GameObject__BuildingModeSource(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSetBuildingObject called on server.");
		}
		else
		{
			((T_Equipments)obj).UserCode_RpcSetBuildingObject__GameObject__BuildingModeSource(reader.ReadGameObject(), GeneratedNetworkCode._Read_BuildingModeSource(reader));
		}
	}

	protected void UserCode_CmdResaleBuilding__UInt32__NetworkConnectionToClient(uint buildingNetId, NetworkConnectionToClient sender)
	{
		if (buildingNetId == 0)
		{
			Debug.LogError("[T_Equipments] CmdResaleBuilding: buildingNetId 0!");
			return;
		}
		NetworkConnectionToClient networkConnectionToClient = sender;
		if (networkConnectionToClient == null)
		{
			Debug.LogWarning("[T_Equipments] CmdResaleBuilding: sender null, connectionToClient kullanılıyor");
			networkConnectionToClient = base.connectionToClient;
		}
		Debug.Log(string.Format("[T_Equipments] CmdResaleBuilding çağrıldı - buildingNetId: {0}, senderId: {1}", buildingNetId, (networkConnectionToClient != null) ? networkConnectionToClient.connectionId.ToString() : "null"));
		if (NetworkServer.spawned.TryGetValue(buildingNetId, out var value))
		{
			BuildingObject component = value.GetComponent<BuildingObject>();
			if (component != null)
			{
				component.ServerResaleBuilding(networkConnectionToClient);
			}
			else
			{
				Debug.LogError($"[T_Equipments] CmdResaleBuilding: BuildingObject component bulunamadı! NetId: {buildingNetId}");
			}
		}
		else
		{
			Debug.LogError($"[T_Equipments] CmdResaleBuilding: Building NetworkIdentity bulunamadı! NetId: {buildingNetId}");
		}
	}

	protected static void InvokeUserCode_CmdResaleBuilding__UInt32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdResaleBuilding called on client.");
		}
		else
		{
			((T_Equipments)obj).UserCode_CmdResaleBuilding__UInt32__NetworkConnectionToClient(reader.ReadVarUInt(), senderConnection);
		}
	}

	protected void UserCode_CmdRelocateBuilding__UInt32__NetworkConnectionToClient(uint buildingNetId, NetworkConnectionToClient sender)
	{
		if (buildingNetId == 0)
		{
			Debug.LogError("[T_Equipments] CmdRelocateBuilding: buildingNetId 0!");
			return;
		}
		NetworkConnectionToClient networkConnectionToClient = sender;
		if (networkConnectionToClient == null)
		{
			Debug.LogWarning("[T_Equipments] CmdRelocateBuilding: sender null, connectionToClient kullanılıyor");
			networkConnectionToClient = base.connectionToClient;
		}
		if (networkConnectionToClient == null)
		{
			Debug.LogError("[T_Equipments] CmdRelocateBuilding: Hiçbir connection bulunamadı!");
			return;
		}
		Debug.Log($"[T_Equipments] CmdRelocateBuilding çağrıldı - buildingNetId: {buildingNetId}, senderId: {networkConnectionToClient.connectionId}");
		if (NetworkServer.spawned.TryGetValue(buildingNetId, out var value))
		{
			BuildingObject component = value.GetComponent<BuildingObject>();
			if (component != null)
			{
				component.ServerRelocateBuilding(networkConnectionToClient);
			}
			else
			{
				Debug.LogError($"[T_Equipments] CmdRelocateBuilding: BuildingObject component bulunamadı! NetId: {buildingNetId}");
			}
		}
		else
		{
			Debug.LogError($"[T_Equipments] CmdRelocateBuilding: Building NetworkIdentity bulunamadı! NetId: {buildingNetId}");
		}
	}

	protected static void InvokeUserCode_CmdRelocateBuilding__UInt32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRelocateBuilding called on client.");
		}
		else
		{
			((T_Equipments)obj).UserCode_CmdRelocateBuilding__UInt32__NetworkConnectionToClient(reader.ReadVarUInt(), senderConnection);
		}
	}

	static T_Equipments()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(T_Equipments), "System.Void T_Equipments::CmdEquip(System.Int32)", InvokeUserCode_CmdEquip__Int32, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Equipments), "System.Void T_Equipments::CMDNotDigableVFX(UnityEngine.Vector3,UnityEngine.Vector3)", InvokeUserCode_CMDNotDigableVFX__Vector3__Vector3, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Equipments), "System.Void T_Equipments::CmdSpawnBuildingPreviewFromSO(System.Int32,UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_CmdSpawnBuildingPreviewFromSO__Int32__Vector3__Quaternion, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Equipments), "System.Void T_Equipments::CmdSpawnBuildingPreview(System.UInt32,UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_CmdSpawnBuildingPreview__UInt32__Vector3__Quaternion, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Equipments), "System.Void T_Equipments::CmdResaleBuilding(System.UInt32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdResaleBuilding__UInt32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Equipments), "System.Void T_Equipments::CmdRelocateBuilding(System.UInt32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRelocateBuilding__UInt32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Equipments), "System.Void T_Equipments::RunNotDigableVFX(UnityEngine.Vector3,UnityEngine.Vector3)", InvokeUserCode_RunNotDigableVFX__Vector3__Vector3);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Equipments), "System.Void T_Equipments::RpcSetBuildingObject(UnityEngine.GameObject,BuildingModeSource)", InvokeUserCode_RpcSetBuildingObject__GameObject__BuildingModeSource);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarInt(equippedIndex);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(equippedIndex);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref equippedIndex, _Mirror_SyncVarHookDelegate_equippedIndex, reader.ReadVarInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref equippedIndex, _Mirror_SyncVarHookDelegate_equippedIndex, reader.ReadVarInt());
		}
	}
}
