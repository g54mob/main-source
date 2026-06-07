using System;
using System.Collections;
using System.Collections.Generic;
using Enviro;
using I2.Loc;
using Mirror;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
	[Header("Identity")]
	public string interactableName = "Interactable";

	public InteractableItemType itemType;

	public PickupItemType pickupType;

	[Header("Target Obj")]
	public GameObject targetObj;

	[Header("Input Actions")]
	public InputActionReference primaryAction;

	public InputActionReference secondaryAction;

	public bool enableSecondary;

	[Header("Primary Interaction")]
	public InteractionMode primaryMode;

	public float primaryDefaultHold = 1f;

	public List<PrimaryDuration> primaryDurations = new List<PrimaryDuration>();

	public PrimaryState currentPrimaryState;

	[Header("Secondary Interaction")]
	public InteractionMode secondaryMode;

	public float secondaryDefaultHold = 1f;

	public List<SecondaryDuration> secondaryDurations = new List<SecondaryDuration>();

	public SecondaryState currentSecondaryState;

	[Header("Outline Settings")]
	public List<MeshRenderer> renderers = new List<MeshRenderer>();

	public List<SkinnedMeshRenderer> skinnedRenderers = new List<SkinnedMeshRenderer>();

	[Header("Building")]
	public bool canHammerInteract;

	[Header("Common")]
	public bool endlessHold;

	public float interactDelay = 0.25f;

	public float interactDistance;

	public bool lockInteractions;

	public string lockCustomText = "";

	public bool lockDuringTutorial;

	public bool hostOnlyDuringTutorial;

	[Header("Unity Events")]
	public UnityEvent onFocusGained;

	public UnityEvent onFocusLost;

	public UnityEvent onHoldStart;

	public UnityEvent onHoldStop;

	public UnityEvent onPrimaryInteract;

	public UnityEvent onSecondaryInteract;

	private readonly List<Func<string>> _resaleConditions = new List<Func<string>>();

	private readonly List<Func<string>> _relocateConditions = new List<Func<string>>();

	private InteractableBase _impl;

	private T_Item _cachedItem;

	private bool _focused;

	private bool _delayActive;

	private bool _primaryHolding;

	private bool _secondaryHolding;

	private float _holdTimer;

	private float _activeHoldTarget;

	private Transform _currentInteractor;

	public float HoldProgress
	{
		get
		{
			if ((!_primaryHolding && !_secondaryHolding) || !(_activeHoldTarget > 0f))
			{
				return 0f;
			}
			return Mathf.Clamp01(_holdTimer / _activeHoldTarget);
		}
	}

	public bool IsHolding
	{
		get
		{
			if (!_primaryHolding)
			{
				return _secondaryHolding;
			}
			return true;
		}
	}

	public event Func<bool> OnShouldAllowPrimary;

	public event Func<bool> OnShouldAllowSecondary;

	public void RegisterResaleCondition(Func<string> condition)
	{
		_resaleConditions.Add(condition);
	}

	public void UnregisterResaleCondition(Func<string> condition)
	{
		_resaleConditions.Remove(condition);
	}

	public void RegisterRelocateCondition(Func<string> condition)
	{
		_relocateConditions.Add(condition);
	}

	public void UnregisterRelocateCondition(Func<string> condition)
	{
		_relocateConditions.Remove(condition);
	}

	public string CheckResaleConditions()
	{
		for (int i = 0; i < _resaleConditions.Count; i++)
		{
			string text = _resaleConditions[i]?.Invoke();
			if (text != null)
			{
				return text;
			}
		}
		return null;
	}

	public string CheckRelocateConditions()
	{
		for (int i = 0; i < _relocateConditions.Count; i++)
		{
			string text = _relocateConditions[i]?.Invoke();
			if (text != null)
			{
				return text;
			}
		}
		return null;
	}

	private void Awake()
	{
		_impl = GetComponent<InteractableBase>();
		_cachedItem = GetComponent<T_Item>();
	}

	private void OnEnable()
	{
		if (primaryAction != null)
		{
			primaryAction.action.performed += OnPrimaryPerformed;
			primaryAction.action.canceled += OnPrimaryCanceled;
			primaryAction.action.Enable();
		}
		if (secondaryAction != null)
		{
			secondaryAction.action.performed += OnSecondaryPerformed;
			secondaryAction.action.canceled += OnSecondaryCanceled;
			secondaryAction.action.Enable();
		}
	}

	private void OnDisable()
	{
		if (primaryAction != null)
		{
			primaryAction.action.performed -= OnPrimaryPerformed;
			primaryAction.action.canceled -= OnPrimaryCanceled;
		}
		if (secondaryAction != null)
		{
			secondaryAction.action.performed -= OnSecondaryPerformed;
			secondaryAction.action.canceled -= OnSecondaryCanceled;
		}
	}

	private void Update()
	{
		if (_focused && interactDistance > 0f && _currentInteractor != null && Vector3.Distance(_currentInteractor.position, base.transform.position) > interactDistance)
		{
			CancelAllHolds();
			SetFocused(value: false);
			return;
		}
		if (_primaryHolding)
		{
			_holdTimer += Time.deltaTime;
			if (_holdTimer >= _activeHoldTarget)
			{
				FirePrimary();
				if (endlessHold && CanInteractPrimary())
				{
					_holdTimer = 0f;
				}
				else
				{
					_primaryHolding = false;
				}
			}
		}
		if (!_secondaryHolding)
		{
			return;
		}
		_holdTimer += Time.deltaTime;
		if (_holdTimer >= _activeHoldTarget)
		{
			FireSecondary();
			if (endlessHold && CanInteractSecondary())
			{
				_holdTimer = 0f;
			}
			else
			{
				_secondaryHolding = false;
			}
		}
	}

	public void SetPrimaryState(PrimaryState state)
	{
		currentPrimaryState = state;
	}

	public void SetSecondaryState(SecondaryState state)
	{
		currentSecondaryState = state;
	}

	public void LockInteraction()
	{
		lockInteractions = true;
	}

	public void UnlockInteraction()
	{
		lockInteractions = false;
	}

	public void SetFocused(bool value, Transform interactor = null)
	{
		if (_focused == value)
		{
			return;
		}
		_focused = value;
		_currentInteractor = interactor;
		bool flag = _cachedItem != null && _cachedItem.isNode;
		if (value)
		{
			if (primaryAction != null)
			{
				primaryAction.action.Enable();
			}
			if (enableSecondary && secondaryAction != null)
			{
				secondaryAction.action.Enable();
			}
			onFocusGained?.Invoke();
			if (!flag)
			{
				OpenInteractionOutline();
			}
			return;
		}
		if (primaryAction != null)
		{
			primaryAction.action.Disable();
		}
		if (secondaryAction != null)
		{
			secondaryAction.action.Disable();
		}
		CancelAllHolds();
		onFocusLost?.Invoke();
		if (!flag)
		{
			CloseInteractionOutline();
		}
	}

	public bool IsNode()
	{
		if (_cachedItem != null)
		{
			return _cachedItem.isNode;
		}
		return false;
	}

	public void CompleteHoldExternally()
	{
		if (_primaryHolding && CanInteractPrimary())
		{
			FirePrimary();
		}
		else if (_secondaryHolding && CanInteractSecondary())
		{
			FireSecondary();
		}
	}

	public void ResetHold()
	{
		_holdTimer = 0f;
		_primaryHolding = false;
		_secondaryHolding = false;
		onHoldStop?.Invoke();
		_impl?.OnHoldCanceled();
	}

	public void SubtractActiveHoldTarget(float value)
	{
		_activeHoldTarget = Mathf.Max(0f, _activeHoldTarget - Mathf.Abs(value));
	}

	private bool CanInteractPrimary()
	{
		if (lockInteractions || _delayActive || !_focused)
		{
			return false;
		}
		if (this.OnShouldAllowPrimary != null && !this.OnShouldAllowPrimary())
		{
			return false;
		}
		if (_impl != null && !_impl.CanInteractPrimary())
		{
			return false;
		}
		return true;
	}

	private bool CanInteractSecondary()
	{
		if (!enableSecondary)
		{
			return false;
		}
		if (lockInteractions || _delayActive || !_focused)
		{
			return false;
		}
		if (this.OnShouldAllowSecondary != null && !this.OnShouldAllowSecondary())
		{
			return false;
		}
		if (_impl != null && !_impl.CanInteractSecondary())
		{
			return false;
		}
		return true;
	}

	private float ResolvePrimaryDuration(PrimaryState state)
	{
		for (int i = 0; i < primaryDurations.Count; i++)
		{
			if (primaryDurations[i].state == state)
			{
				return Mathf.Max(0f, primaryDurations[i].duration);
			}
		}
		return Mathf.Max(0f, primaryDefaultHold);
	}

	private float ResolveSecondaryDuration(SecondaryState state)
	{
		for (int i = 0; i < secondaryDurations.Count; i++)
		{
			if (secondaryDurations[i].state == state)
			{
				return Mathf.Max(0f, secondaryDurations[i].duration);
			}
		}
		return Mathf.Max(0f, secondaryDefaultHold);
	}

	private void OnPrimaryPerformed(InputAction.CallbackContext ctx)
	{
		if (CanInteractPrimary())
		{
			switch (primaryMode)
			{
			case InteractionMode.Press:
				FirePrimary();
				break;
			case InteractionMode.Hold:
				_activeHoldTarget = ResolvePrimaryDuration(currentPrimaryState);
				_holdTimer = 0f;
				_primaryHolding = true;
				onHoldStart?.Invoke();
				_impl?.OnHoldStarted();
				break;
			}
		}
	}

	private void OnPrimaryCanceled(InputAction.CallbackContext ctx)
	{
		if (_primaryHolding)
		{
			_primaryHolding = false;
			onHoldStop?.Invoke();
			_impl?.OnHoldCanceled();
		}
	}

	private void OnSecondaryPerformed(InputAction.CallbackContext ctx)
	{
		if (CanInteractSecondary())
		{
			switch (secondaryMode)
			{
			case InteractionMode.Press:
				FireSecondary();
				break;
			case InteractionMode.Hold:
				_activeHoldTarget = ResolveSecondaryDuration(currentSecondaryState);
				_holdTimer = 0f;
				_secondaryHolding = true;
				onHoldStart?.Invoke();
				_impl?.OnHoldStarted();
				break;
			}
		}
	}

	private void OnSecondaryCanceled(InputAction.CallbackContext ctx)
	{
		if (_secondaryHolding)
		{
			_secondaryHolding = false;
			onHoldStop?.Invoke();
			_impl?.OnHoldCanceled();
		}
	}

	private bool IsBlockedByTutorial()
	{
		if (!lockDuringTutorial)
		{
			return false;
		}
		bool num = DayNightManager.Instance != null && DayNightManager.Instance.CurrentGameDay == 1;
		bool flag = TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning;
		if (!num && !flag)
		{
			return false;
		}
		if (NotificationManager.Instance != null)
		{
			NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_NotAvailableDuringTutorial"));
		}
		return true;
	}

	private bool IsBlockedByHostOnly()
	{
		if (!hostOnlyDuringTutorial)
		{
			return false;
		}
		if (TutorialManager.Instance == null)
		{
			return false;
		}
		if (!TutorialManager.Instance.IsTutorialRunning)
		{
			return false;
		}
		if (NetworkServer.active)
		{
			return false;
		}
		if (NotificationManager.Instance != null)
		{
			NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"));
		}
		return true;
	}

	private void FirePrimary()
	{
		if (IsBlockedByTutorial())
		{
			StartDelay();
			return;
		}
		if (IsBlockedByHostOnly())
		{
			StartDelay();
			return;
		}
		if (canHammerInteract && currentPrimaryState == PrimaryState.Resale)
		{
			ExecuteResale();
		}
		else
		{
			onPrimaryInteract?.Invoke();
			_impl?.OnPrimaryInteracted();
		}
		StartDelay();
	}

	private void FireSecondary()
	{
		if (IsBlockedByTutorial())
		{
			StartDelay();
			return;
		}
		if (IsBlockedByHostOnly())
		{
			StartDelay();
			return;
		}
		if (canHammerInteract && currentSecondaryState == SecondaryState.Relocate)
		{
			ExecuteRelocate();
		}
		else
		{
			onSecondaryInteract?.Invoke();
			_impl?.OnSecondaryInteracted();
		}
		StartDelay();
	}

	private void ExecuteResale()
	{
		bool num = TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning;
		bool flag = DayNightManager.Instance != null && DayNightManager.Instance.CurrentGameDay == 1;
		if (num || flag)
		{
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_NotAvailableDuringTutorial"));
			}
			return;
		}
		BuildingObject buildingObject = GetComponent<BuildingObject>();
		if (buildingObject == null && targetObj != null)
		{
			buildingObject = targetObj.GetComponent<BuildingObject>();
		}
		if (buildingObject == null)
		{
			buildingObject = GetComponentInParent<BuildingObject>();
		}
		if (buildingObject == null)
		{
			return;
		}
		T_Equipments t_Equipments = ((GameManager.Instance != null) ? GameManager.Instance.localEquipments : null);
		if (t_Equipments == null)
		{
			return;
		}
		uint netId = buildingObject.netId;
		if (netId != 0)
		{
			t_Equipments.CmdResaleBuilding(netId);
			if (GameManager.Instance.UImanager != null && GameManager.Instance.UImanager.playerInteractionUI != null)
			{
				GameManager.Instance.UImanager.playerInteractionUI.SetTarget(null);
			}
		}
	}

	private void ExecuteRelocate()
	{
		bool num = TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning;
		bool flag = DayNightManager.Instance != null && DayNightManager.Instance.CurrentGameDay == 1;
		if (num || flag)
		{
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_NotAvailableDuringTutorial"));
			}
			return;
		}
		BuildingObject buildingObject = GetComponent<BuildingObject>();
		if (buildingObject == null && targetObj != null)
		{
			buildingObject = targetObj.GetComponent<BuildingObject>();
		}
		if (buildingObject == null)
		{
			buildingObject = GetComponentInParent<BuildingObject>();
		}
		if (buildingObject == null)
		{
			return;
		}
		T_Equipments t_Equipments = ((GameManager.Instance != null) ? GameManager.Instance.localEquipments : null);
		if (!(t_Equipments == null))
		{
			uint netId = buildingObject.netId;
			if (netId != 0)
			{
				t_Equipments.CmdRelocateBuilding(netId);
			}
		}
	}

	private void StartDelay()
	{
		if (!(interactDelay <= 0f) && base.gameObject.activeInHierarchy)
		{
			StartCoroutine(DelayRoutine());
		}
	}

	private IEnumerator DelayRoutine()
	{
		_delayActive = true;
		yield return new WaitForSeconds(interactDelay);
		_delayActive = false;
		if (!endlessHold)
		{
			ResetHold();
		}
	}

	private void CancelAllHolds()
	{
		if (_primaryHolding || _secondaryHolding)
		{
			_primaryHolding = false;
			_secondaryHolding = false;
			onHoldStop?.Invoke();
			_impl?.OnHoldCanceled();
		}
		_holdTimer = 0f;
	}

	public void OpenInteractionOutline()
	{
		uint num = 2u;
		for (int i = 0; i < renderers.Count; i++)
		{
			MeshRenderer meshRenderer = renderers[i];
			if (meshRenderer != null && meshRenderer.gameObject.activeSelf)
			{
				meshRenderer.renderingLayerMask |= num;
			}
		}
		for (int j = 0; j < skinnedRenderers.Count; j++)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = skinnedRenderers[j];
			if (skinnedMeshRenderer != null && skinnedMeshRenderer.gameObject.activeSelf)
			{
				skinnedMeshRenderer.renderingLayerMask |= num;
			}
		}
	}

	public void CloseInteractionOutline()
	{
		uint num = 2u;
		for (int i = 0; i < renderers.Count; i++)
		{
			MeshRenderer meshRenderer = renderers[i];
			if (meshRenderer != null)
			{
				meshRenderer.renderingLayerMask &= ~num;
			}
		}
		for (int j = 0; j < skinnedRenderers.Count; j++)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = skinnedRenderers[j];
			if (skinnedMeshRenderer != null)
			{
				skinnedMeshRenderer.renderingLayerMask &= ~num;
			}
		}
	}
}
