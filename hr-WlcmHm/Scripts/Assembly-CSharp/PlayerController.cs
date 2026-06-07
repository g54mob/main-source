using System.Collections.Generic;
using Assets.BeneathThePetals.Scripts.Steam;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public delegate void ActivateQuestItems();

	[Header("General")]
	[SerializeField]
	private float interactionDistance;

	[Tooltip("Time it takes for the camera to look at NPC when interaction is started.")]
	[SerializeField]
	private float cameraLookAtTweenDuration;

	[Header("UI")]
	[SerializeField]
	public TMP_Text interactionText;

	[SerializeField]
	private GameObject dialogueBox;

	[SerializeField]
	private QuestManager questManager;

	[SerializeField]
	private Image progressImage;

	[SerializeField]
	private ScreenNoteManager screenNoteManager;

	[SerializeField]
	private CollectiblesSO m_StoryClues;

	[SerializeField]
	private CollectiblesSO m_NPC;

	private PlayerInputActions playerInput;

	private InputAction interact;

	public EventReference eventToPlayWhenBob;

	public EventReference eventToPlayWhenJump;

	private GameObject currentTarget;

	private bool canInteract = true;

	private Transform cameraTransform;

	public List<string> inventory = new List<string>();

	public ActivateQuestItems ActivateQuestItemsCallback;

	private Quest currentQuest;

	private GameObject currentlyCarriedItem1;

	private GameObject currentlyCarriedItem2;

	private bool carryingItem;

	private PauseMenu pauseMenu;

	public bool isCurrentlyChangingScenes;

	private int pickedUpItems;

	[Header("Quest related")]
	[SerializeField]
	private Transform carryParent1;

	[SerializeField]
	private Transform carryParent2;

	public GameObject DialogueBox => dialogueBox;

	public Image ProgressImage => progressImage;

	public ScreenNoteManager ScreenNoteManagerScript => screenNoteManager;

	public float CameraLookAtTweenDuration => cameraLookAtTweenDuration;

	private void Awake()
	{
		playerInput = new PlayerInputActions();
	}

	private void OnEnable()
	{
		interact = playerInput.Player.Interact;
		interact.Enable();
		interact.started += InteractMethod;
		interact.canceled += StopInteractionMethod;
	}

	private void OnDisable()
	{
		interact.Disable();
	}

	private void Start()
	{
		pauseMenu = Object.FindAnyObjectByType<PauseMenu>();
		screenNoteManager.NoteEndCallback = delegate
		{
			EnableInput();
			GetComponent<FirstPersonController>().EnableInput();
		};
		cameraTransform = GetCamera().transform;
		InitInventoryObject();
	}

	private void InitInventoryObject()
	{
		InventoryManager inventoryManager = Object.FindAnyObjectByType<InventoryManager>();
		if (inventoryManager != null)
		{
			inventory = inventoryManager.inventoryItems;
			MonoBehaviour.print("Inventory loaded successfully");
		}
		else
		{
			Debug.LogError("Inventory Manager not found! Could not load inventory!");
		}
	}

	private void Update()
	{
		if (!isCurrentlyChangingScenes)
		{
			if (!(pauseMenu != null) || !pauseMenu.isPaused)
			{
				CheckForInteractables();
			}
		}
		else
		{
			DisableInput();
			interactionText.SetText("");
		}
	}

	private void CheckForInteractables()
	{
		if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out var hitInfo, interactionDistance, ~LayerMask.GetMask("Player", "SoundTrigger", "UselessColliders")) && !isCurrentlyChangingScenes)
		{
			GameObject gameObject = hitInfo.collider.gameObject;
			if (gameObject.GetComponent<QuestDeliveryLocation>() != null)
			{
				if (currentQuest == null || currentQuest.Completed)
				{
					return;
				}
				TryDeactivateCurrentTarget();
				if (!carryingItem)
				{
					return;
				}
				currentTarget = gameObject;
				TryActivateCurrentTarget();
			}
			if ((gameObject.GetComponent<SceneChange>() != null && GetCarriedItemsCount() > 0) || (gameObject.GetComponent<QuestItemCarry>() != null && !CanPickUpItem()))
			{
				return;
			}
			if ((bool)currentTarget)
			{
				if (gameObject != currentTarget)
				{
					TryDeactivateCurrentTarget();
					currentTarget = gameObject;
					TryActivateCurrentTarget();
				}
			}
			else
			{
				currentTarget = gameObject;
				TryActivateCurrentTarget();
			}
		}
		else
		{
			TryDeactivateCurrentTarget();
			currentTarget = null;
		}
	}

	private void TryActivateCurrentTarget()
	{
		if (!(currentTarget == null) && canInteract)
		{
			IInteractable component = currentTarget.GetComponent<IInteractable>();
			if (component != null && component.IsInteractable())
			{
				component.Activate();
				ChangeText(component.GetActionType() + " E to " + component.GetActionName() + " \n" + component.GetName());
			}
		}
	}

	private void TryDeactivateCurrentTarget()
	{
		ChangeText("");
		if ((bool)currentTarget)
		{
			currentTarget.GetComponent<IInteractable>()?.Deactivate();
		}
	}

	public Transform GetCamera()
	{
		return base.transform.GetChild(0).GetChild(0);
	}

	private void InteractMethod(InputAction.CallbackContext context)
	{
		if (currentTarget == null || !canInteract)
		{
			return;
		}
		IInteractable component = currentTarget.GetComponent<IInteractable>();
		if (component is ITalkable)
		{
			m_NPC.collectibles.Add(component.GetName());
			if (m_NPC.collectibles.Count == m_NPC.goal)
			{
				m_NPC.CompleteAchievement();
			}
			Debug.Log(m_NPC.collectibles.Count);
		}
		if (component is StoryClueImage)
		{
			m_StoryClues.collectibles.Add(component.GetName());
			if (m_StoryClues.collectibles.Count == m_StoryClues.goal)
			{
				m_StoryClues.CompleteAchievement();
			}
			Debug.Log(m_StoryClues.collectibles.Count);
			Debug.Log(component.GetName());
		}
		if (component != null && component.IsInteractable())
		{
			component.Interact();
		}
	}

	private void StopInteractionMethod(InputAction.CallbackContext context)
	{
		if (!AimingAtDoor())
		{
			TryDeactivateCurrentTarget();
			TryActivateCurrentTarget();
		}
	}

	private bool AimingAtDoor()
	{
		if (currentTarget == null)
		{
			return true;
		}
		return currentTarget.GetComponent<DoorController>() != null;
	}

	public void DisableInput()
	{
		canInteract = false;
		TryDeactivateCurrentTarget();
	}

	public void EnableInput()
	{
		canInteract = true;
	}

	public void ResetInteractionTarget()
	{
		TryDeactivateCurrentTarget();
		currentTarget = null;
	}

	public void AddToInventory(string item)
	{
		inventory.Add(item);
		Debug.Log("Inventory: " + string.Join(", ", inventory));
		Debug.Log("Added " + item + " to inventory");
		Debug.Log("Inventory: " + string.Join(", ", inventory));
		InventoryManager.Instance.AddItem(item);
		Object.FindAnyObjectByType<InventoryUI>().UpdateInventoryUI();
	}

	public bool RemoveFromInventory(string item)
	{
		if (inventory.Contains(item))
		{
			inventory.Remove(item);
			Debug.Log("Inventory: " + string.Join(", ", inventory));
			return true;
		}
		return false;
	}

	public void AssignQuest(Quest q)
	{
		currentQuest = q;
		q.OnQuestAdvanced = questManager.UpdateLog;
		ActivateQuestItemsCallback();
		questManager.UpdateLog(currentQuest);
	}

	public void StartCarryingItem(GameObject itemToCarry)
	{
		ref GameObject freeItemGameObject = ref GetFreeItemGameObject();
		Transform freeSpotParent = GetFreeSpotParent();
		freeItemGameObject = itemToCarry;
		carryingItem = true;
		interactionText.text = "";
		freeItemGameObject.transform.SetParent(freeSpotParent);
		freeItemGameObject.transform.localPosition = Vector3.zero;
		freeItemGameObject.GetComponent<QuestItemBase>().DeactivateItem();
		freeItemGameObject.GetComponent<Collider>().enabled = false;
		pickedUpItems++;
	}

	public GameObject StopCarryingItem()
	{
		ref GameObject carriedItemGameObject = ref GetCarriedItemGameObject();
		carriedItemGameObject.transform.SetParent(null);
		GameObject result = carriedItemGameObject;
		carryingItem = GetCarriedItemsCount() != 1;
		carriedItemGameObject = null;
		interactionText.text = "";
		return result;
	}

	public bool HasFreeSpot()
	{
		if (!(currentlyCarriedItem1 == null))
		{
			return currentlyCarriedItem2 == null;
		}
		return true;
	}

	private Transform GetFreeSpotParent()
	{
		if (!(currentlyCarriedItem1 == null))
		{
			return carryParent2;
		}
		return carryParent1;
	}

	private ref GameObject GetFreeItemGameObject()
	{
		if (currentlyCarriedItem1 == null)
		{
			return ref currentlyCarriedItem1;
		}
		return ref currentlyCarriedItem2;
	}

	private ref GameObject GetCarriedItemGameObject()
	{
		if (currentlyCarriedItem1 != null)
		{
			return ref currentlyCarriedItem1;
		}
		return ref currentlyCarriedItem2;
	}

	private int GetCarriedItemsCount()
	{
		int num = 0;
		if (currentlyCarriedItem1 != null)
		{
			num++;
		}
		if (currentlyCarriedItem2 != null)
		{
			num++;
		}
		return num;
	}

	private void ChangeText(string text)
	{
		if (!isCurrentlyChangingScenes)
		{
			interactionText.text = text;
		}
	}

	public void LockedDoorText()
	{
		ChangeText("Locked.");
	}

	public Quest GetCurrentQuest()
	{
		return currentQuest;
	}

	private void OnDrawGizmos()
	{
		cameraTransform = GetCamera().transform;
		Gizmos.color = Color.red;
		Gizmos.DrawRay(cameraTransform.position, cameraTransform.forward * interactionDistance);
	}

	public bool CanPickUpItem()
	{
		return pickedUpItems < currentQuest.GoalAmount;
	}
}
