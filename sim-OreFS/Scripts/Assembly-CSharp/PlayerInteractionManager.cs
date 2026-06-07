using System;
using I2.Loc;
using Mirror;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("Interaction/Player Interaction Manager")]
public class PlayerInteractionManager : MonoBehaviour
{
	[Serializable]
	public class InteractableEvent : UnityEvent<Interactable>
	{
	}

	[Header("Input")]
	public bool InputActive;

	[Header("Ray Settings")]
	public Camera rayCamera;

	public Transform interactor;

	public float maxDistance = 3f;

	public float interactionDistance = 3f;

	public LayerMask hitMask = -1;

	public QueryTriggerInteraction triggerQuery = QueryTriggerInteraction.Ignore;

	[Header("Selection")]
	public bool keepFocusIfOccluded;

	public float lostFocusGrace = 0.15f;

	public InteractableEvent onTargetChanged;

	private float _lastSeenTime;

	private GameManager gameManager;

	private T_Item currentNodeItem;

	private int currentPieceIndex = -1;

	private RaycastHit lastNodeHit;

	private T_Item _cachedCurrentItem;

	private bool isLocalPlayer;

	private GamePlayer localGamePlayer;

	public Interactable Current { get; private set; }

	private void Awake()
	{
		gameManager = GameManager.Instance;
	}

	public void SetIsLocalPlayer(bool value)
	{
		isLocalPlayer = value;
	}

	private void Reset()
	{
		rayCamera = Camera.main;
		interactor = base.transform;
	}

	public void SetInputActive(bool input)
	{
		InputActive = input;
	}

	private void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}
		if (!InputActive)
		{
			if (Current != null)
			{
				ClearCurrent();
			}
			ClearNodeState();
			return;
		}
		if (!rayCamera)
		{
			rayCamera = Camera.main;
		}
		if (!interactor)
		{
			interactor = (rayCamera ? rayCamera.transform : base.transform);
		}
		Vector3 origin = (rayCamera ? rayCamera.transform.position : base.transform.position);
		Vector3 dir = (rayCamera ? rayCamera.transform.forward : base.transform.forward);
		Interactable best = null;
		if (TryPick(origin, dir, out best, out var bestHit))
		{
			_lastSeenTime = Time.unscaledTime;
			if (best != Current)
			{
				SetCurrent(best);
			}
			UpdateNodePieceDetection(origin, dir, bestHit);
		}
		else if (!keepFocusIfOccluded || !(Current != null) || !(Time.unscaledTime - _lastSeenTime <= lostFocusGrace))
		{
			if (Current != null)
			{
				ClearCurrent();
			}
			ClearNodeState();
		}
	}

	private bool TryPick(Vector3 origin, Vector3 dir, out Interactable best, out RaycastHit bestHit)
	{
		best = null;
		bestHit = default(RaycastHit);
		if (!InputActive)
		{
			return false;
		}
		if (Physics.Raycast(origin, dir, out var hitInfo, maxDistance, hitMask, triggerQuery))
		{
			float num = Vector3.Distance(origin, hitInfo.point);
			if (hitInfo.transform.gameObject.layer != 18 && num > interactionDistance)
			{
				return false;
			}
			Interactable interactable = GetInteractable(hitInfo.collider);
			if (!IsValidCandidate(interactable))
			{
				return false;
			}
			best = interactable;
			bestHit = hitInfo;
			return true;
		}
		return false;
	}

	private Interactable GetInteractable(Collider c)
	{
		if (!c)
		{
			return null;
		}
		if (c.TryGetComponent<Interactable>(out var component))
		{
			return component;
		}
		return c.GetComponentInParent<Interactable>();
	}

	private bool IsValidCandidate(Interactable it)
	{
		if (it == null || !it.isActiveAndEnabled)
		{
			return false;
		}
		return true;
	}

	private void SetCurrent(Interactable next)
	{
		if (Current != null)
		{
			Current.SetFocused(value: false);
		}
		Current = next;
		_cachedCurrentItem = ((Current != null) ? Current.GetComponent<T_Item>() : null);
		if (Current != null)
		{
			Transform transform = (interactor ? interactor : (rayCamera ? rayCamera.transform : base.transform));
			Current.SetFocused(value: true, transform);
			if (gameManager != null && gameManager.UImanager.playerInteractionUI != null)
			{
				gameManager.UImanager.playerInteractionUI.SetTarget(Current);
			}
		}
		onTargetChanged?.Invoke(Current);
	}

	private void ClearCurrent()
	{
		if (Current != null)
		{
			Current.SetFocused(value: false);
			Current = null;
			_cachedCurrentItem = null;
		}
		if (gameManager != null && gameManager.UImanager.playerInteractionUI != null)
		{
			gameManager.UImanager.playerInteractionUI.SetTarget(null);
		}
		onTargetChanged?.Invoke(null);
	}

	private void OnDisable()
	{
		ClearCurrent();
		ClearNodeState();
	}

	private void UpdateNodePieceDetection(Vector3 origin, Vector3 dir, RaycastHit hit)
	{
		if (Current == null)
		{
			return;
		}
		if (localGamePlayer == null)
		{
			localGamePlayer = NetworkClient.localPlayer.GetComponent<GamePlayer>();
		}
		T_Item cachedCurrentItem = _cachedCurrentItem;
		if (cachedCurrentItem == null)
		{
			ClearNodeState();
			return;
		}
		if (!cachedCurrentItem.isNode)
		{
			ClearNodeState();
			return;
		}
		currentNodeItem = cachedCurrentItem;
		lastNodeHit = hit;
		int pieceIndexFromHit = cachedCurrentItem.GetPieceIndexFromHit(hit);
		if (pieceIndexFromHit != currentPieceIndex)
		{
			currentPieceIndex = pieceIndexFromHit;
		}
		if (gameManager != null && gameManager.UImanager.playerInteractionUI != null && gameManager.UImanager.playerInteractionUI.nodeInteractionUI != null)
		{
			gameManager.UImanager.playerInteractionUI.nodeInteractionUI.SetTarget(cachedCurrentItem, currentPieceIndex);
		}
	}

	private void ClearNodeState()
	{
		currentNodeItem = null;
		currentPieceIndex = -1;
		if (gameManager != null && gameManager.UImanager != null && gameManager.UImanager.playerInteractionUI != null && gameManager.UImanager.playerInteractionUI.nodeInteractionUI != null)
		{
			gameManager.UImanager.playerInteractionUI.nodeInteractionUI.Hide();
		}
	}

	public void TryDamageCurrentNodePiece()
	{
		if (currentNodeItem == null || !currentNodeItem.isNode || currentPieceIndex < 0 || currentPieceIndex >= currentNodeItem.pieceHealthList.Count || currentNodeItem.pieceHealthList[currentPieceIndex] <= 0)
		{
			return;
		}
		if (TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning && !TutorialManager.Instance.CanDamageNodeDuringTutorial(currentNodeItem.itemId))
		{
			string tutorialLockedItemId = TutorialManager.Instance.TutorialLockedItemId;
			string text = "";
			if (!string.IsNullOrEmpty(tutorialLockedItemId) && ItemSOManager.Instance != null)
			{
				T_ItemSO itemSOById = ItemSOManager.Instance.GetItemSOById(tutorialLockedItemId);
				if (itemSOById != null)
				{
					text = LocalizationManager.GetTranslation(itemSOById.Name);
				}
			}
			string text2 = LocalizationManager.GetTranslation("Notification_TutorialOnlyLockedItem");
			if (!string.IsNullOrEmpty(text))
			{
				text2 = text2.Replace("{0}", text);
			}
			if (gameManager != null && gameManager.notificationManager != null)
			{
				gameManager.notificationManager.ShowNotification(text2);
			}
			return;
		}
		int damage = 1;
		if (gameManager != null && gameManager.localEquipments != null)
		{
			T_Equipments localEquipments = gameManager.localEquipments;
			if (localEquipments.equippedIndex >= 0 && localEquipments.equippedIndex < localEquipments.localTools.Count)
			{
				T_Tool t_Tool = localEquipments.localTools[localEquipments.equippedIndex];
				if (t_Tool != null)
				{
					damage = Mathf.Max(1, Mathf.RoundToInt(t_Tool.damage));
				}
			}
		}
		Vector3 piecePos = Vector3.zero;
		T_NodePiece pieceFromRaycastHit = currentNodeItem.GetPieceFromRaycastHit(lastNodeHit);
		if (pieceFromRaycastHit != null)
		{
			piecePos = pieceFromRaycastHit.GetVFXPosition();
			pieceFromRaycastHit.PlayHitVFXLocal();
		}
		int bagAvailableCapacity = 0;
		if (GameManager.Instance != null && GameManager.Instance.localBag != null)
		{
			T_Bag localBag = GameManager.Instance.localBag;
			bagAvailableCapacity = localBag.MaxCapacity - localBag.CurrentItemCount;
		}
		currentNodeItem.CmdDamagePiece(currentPieceIndex, piecePos, damage, bagAvailableCapacity);
	}

	public T_Item GetCurrentNodeItem()
	{
		return currentNodeItem;
	}

	public int GetCurrentPieceIndex()
	{
		return currentPieceIndex;
	}

	public bool IsLookingAtNode()
	{
		if (currentNodeItem != null)
		{
			return currentNodeItem.isNode;
		}
		return false;
	}
}
