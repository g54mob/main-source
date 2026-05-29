using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviourPunCallbacks
{
	[SerializeField]
	private LayerMask m_InteractableLayer;

	[SerializeField]
	private float m_InteractionDistance;

	[SerializeField]
	private float m_InteractionRange;

	[SerializeField]
	private float m_HoldingInteractionTime;

	[SerializeField]
	private float m_MaxHoldingTimeForInstantInteraction;

	private Camera m_MainCamera;

	private RaycastHit m_Hit;

	private Ray m_Ray;

	private bool m_Use;

	private bool m_Holding;

	private float m_HoldingPercentage;

	private float m_HoldingTime;

	private bool m_IsInteractionInputConsumed;

	private bool m_InInteraction;

	private IInteractable m_CurrentInteractable;

	private IInteractable m_InteractableOnUseStarted;

	private Interaction[] m_Interactions;

	private bool m_Paused;

	private bool m_InGameMenu;

	private bool m_IsInteractionStoped;

	private ScannerDevice m_ScannerDevice;

	public bool InSkateboard;

	public Action<bool> onUse;

	public Action<bool> onTake;

	public Action onApproveCheckout;

	public Action onFinishDay;

	public Action<bool> onDrop;

	public Action onCancel;

	public Action onBack;

	public Action<bool> onThrow;

	public Action onClose;

	public Action onOpenClose;

	public Action<bool> onSell;

	public Action<bool> onRotate;

	public Action<bool> onHoldingStateChanged;

	public Action<float> onHolding;

	public Action onDisable;

	public Action<Display> onDisplayMoved;

	public Action<bool> onStartedMovingFurniture;

	public Action<bool> onCheckoutTake;

	public Action<IInteractable> OnDetechInteractable;

	public Action onScannerUse;

	public Action<bool> onGamepadMultiple;

	public Action<bool> onSwap;

	public Action onWholesaleOffer;

	public Action onMap;

	public Action onOnlineOrder;

	public Action onSpecterExitVehicle;

	public List<Delegate> CancelInvocationList;

	public List<Delegate> BackInvocationList;

	private ScannerInteraction m_ScannerInteraction;

	private PlayerInstance m_PlayerInstance;

	public Action<InteractactableType> onInteract;

	private float HoldDuration => 0f;

	public ScannerDevice ScannerDevice => null;

	public bool IsInteractionStoped
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool Use => false;

	public bool InInteraction
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool InGameMenu
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool Pause
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public IInteractable CurrentInteractable
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private bool Holding
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float MaxHoldingTimeForInstantInteraction => 0f;

	public PlayerInstance PlayerInstance => null;

	public event Action<Interaction> onCurrentInteractionChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	public override void OnDisable()
	{
	}

	private void Update()
	{
	}

	public void SetFreeInInteraction()
	{
	}

	public void ClickSimulate()
	{
	}

	public void HoldClickSimulate()
	{
	}

	public void OnUse(InputAction.CallbackContext context)
	{
	}

	public void ConsumeInteractionInput()
	{
	}

	public void OnOpenClose(InputAction.CallbackContext context)
	{
	}

	public void OnTake(InputAction.CallbackContext context)
	{
	}

	public void OnCheckoutTake(InputAction.CallbackContext context)
	{
	}

	public void OnDrop(InputAction.CallbackContext context)
	{
	}

	public void OnScroll(InputAction.CallbackContext context)
	{
	}

	public void OnMap(InputAction.CallbackContext context)
	{
	}

	public void OnCancel(InputAction.CallbackContext context)
	{
	}

	public void OnBack(InputAction.CallbackContext context)
	{
	}

	public void OnThrow(InputAction.CallbackContext context)
	{
	}

	public void OnClose(InputAction.CallbackContext context)
	{
	}

	public void OnSell(InputAction.CallbackContext context)
	{
	}

	public void OnApproveCheckout(InputAction.CallbackContext context)
	{
	}

	public void OnFinishDay(InputAction.CallbackContext context)
	{
	}

	public void OnWholesaleOffer(InputAction.CallbackContext context)
	{
	}

	public void OnOnlineOrder(InputAction.CallbackContext context)
	{
	}

	public void OnSwap(InputAction.CallbackContext context)
	{
	}

	public void OnExitVehicle(InputAction.CallbackContext context)
	{
	}

	public void SwitchScanner(bool willOpen)
	{
	}

	public void SwitchScannerNetwork(bool willOpen)
	{
	}

	public void SetCurrentInteraction(InteractactableType type)
	{
	}

	public void InteractionEnd(Interaction interaction)
	{
	}

	public void SetFreeCurrentInteractable()
	{
	}

	public List<Interaction> GetActiveInteracts()
	{
		return null;
	}

	public void CacheEscapeEvents(bool isBack, Action action)
	{
	}

	public void RollbackEscapeEvents(bool isBack)
	{
	}

	public T GetInteraction<T>() where T : Interaction
	{
		return null;
	}

	private void Raycast()
	{
	}

	public void SetCurrentInteractable(IInteractable interactable)
	{
	}

	public void Interact(bool holdInteraction = false, bool customInteraction = false)
	{
	}

	private void CheckForHoldingInteraction()
	{
	}

	private void CheckForInstantInteractionAfterHold()
	{
	}

	public void RemoteInteract(string userId)
	{
	}
}
