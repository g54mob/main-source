using UnityEngine;
using UnityEngine.Events;

public class CharacterControllerComponent : MonoBehaviour, IInteraction
{
	[SerializeField]
	private CharacterController characterController;

	[SerializeField]
	private float movementSpeed = 5f;

	[SerializeField]
	private float runningSpeed = 7.5f;

	[SerializeField]
	private float rotationSpeed = 5f;

	[SerializeField]
	private float castLength = 2f;

	[SerializeField]
	private float placeLength = 4f;

	[SerializeField]
	private SpriteRenderer spriteItemInHand;

	[SerializeField]
	private CharacterItemSocket characterItemSocket;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private GameObject characterVisuals;

	[SerializeField]
	private float stepInterval = 0.5f;

	[SerializeField]
	private string soundSteps;

	private float intervalTimer;

	private Vector3 movementDirection;

	private Vector3 finalDir;

	private bool isRunning;

	public UnityEvent OnToolbarSelectionChanged = new UnityEvent();

	private string currentTrigger;

	private bool isPlayingActionAnimation;

	private bool quedAction;

	private bool canInteract;

	private GameObject currentInteractable;

	private GameObject lastInteractable;

	public ItemSocket socket;

	public ItemSocket GetSocket()
	{
		return socket;
	}

	public float GetCastLength()
	{
		return castLength;
	}

	public float GetPlacementLength()
	{
		return placeLength;
	}

	public void SetPosition(Vector3 position)
	{
		characterController.enabled = false;
		base.transform.SetPositionAndRotation(position, Quaternion.identity);
		characterController.enabled = true;
	}

	private void Start()
	{
		ActivateCharacterInteraction();
	}

	private void Update()
	{
		Gravity();
		if (!GameStateManager.ValidateCharacterState(GameStateManager.CharacterState.CharacterMode) && !GameStateManager.ValidateCharacterState(GameStateManager.CharacterState.NPCDialogSequence) && !GameStateManager.ValidateCharacterState(GameStateManager.CharacterState.CharacterRemoveMode))
		{
			StopMovement();
			return;
		}
		if (animator != null)
		{
			isPlayingActionAnimation = animator.GetBool(currentTrigger);
			if (isPlayingActionAnimation || quedAction)
			{
				return;
			}
		}
		Move();
	}

	public Vector3 GetXZPosition(float height)
	{
		return new Vector3(base.transform.position.x, height, base.transform.position.z);
	}

	public void ActivateCharacterInteraction()
	{
		canInteract = true;
	}

	public void DeactivateCharacterInteraction()
	{
		canInteract = false;
	}

	public void HideCharacterVisuals()
	{
		characterVisuals.SetActive(value: false);
	}

	public void ShowCharacterVisuals()
	{
		characterVisuals.SetActive(value: true);
	}

	public void Gravity()
	{
		characterController.SimpleMove(Physics.gravity);
	}

	public void StopMovement()
	{
		isPlayingActionAnimation = false;
		quedAction = false;
		finalDir = Vector3.zero;
		movementDirection = Vector3.zero;
		if (!(animator == null))
		{
			animator.SetBool("Move", value: false);
		}
	}

	public void SetInputAxis(Vector3 inputDirection)
	{
		movementDirection = inputDirection;
	}

	public void EnableRunning()
	{
		isRunning = true;
	}

	public void DisableRunning()
	{
		isRunning = false;
	}

	public void Move()
	{
		Vector3 vector = movementDirection.z * GlobalReferences.GetCameraController().pivot.forward;
		Vector3 vector2 = movementDirection.x * GlobalReferences.GetCameraController().pivot.right;
		finalDir = vector + vector2;
		float num = (isRunning ? runningSpeed : movementSpeed);
		characterController.Move(finalDir * num * Time.deltaTime);
		if (animator != null)
		{
			animator.SetBool("Move", movementDirection != Vector3.zero);
		}
		if (finalDir == Vector3.zero)
		{
			intervalTimer = 0f;
		}
		else if (intervalTimer > stepInterval)
		{
			SoundManager.PlaySoundOnce(soundSteps);
			intervalTimer = 0f;
		}
		else
		{
			intervalTimer += Time.deltaTime * (isRunning ? (runningSpeed - movementSpeed) : 1f);
		}
	}

	public void OnInteract()
	{
		if (GameStateManager.ValidateCharacterState(GameStateManager.CharacterState.CharacterMode) && canInteract)
		{
			GameObject hitObject = RayCaster.GetHitObject(castLength, RayCaster.GetDefaultMask());
			if (!(hitObject == null) && hitObject.GetComponent<IInteraction>() != null)
			{
				hitObject.GetComponent<IInteraction>().OnPlayerInteraction(this);
			}
		}
	}

	public void OnAction()
	{
		if (GameStateManager.ValidateCharacterState(GameStateManager.CharacterState.CharacterMode) && canInteract)
		{
			GameObject hitObject = RayCaster.GetHitObject(castLength, RayCaster.GetDefaultMask());
			if (!(hitObject == null) && hitObject.GetComponent<IInteraction>() != null)
			{
				hitObject.GetComponent<IInteraction>().OnPlayerAction(this);
			}
		}
	}

	public void OnHoldInteract()
	{
		if (!GameStateManager.ValidateCharacterState(GameStateManager.CharacterState.CharacterMode) || !canInteract)
		{
			return;
		}
		GameObject hitObject = RayCaster.GetHitObject(castLength, RayCaster.GetDefaultMask());
		if (!(hitObject == null) && hitObject.GetComponent<IInteraction>() != null)
		{
			hitObject.GetComponent<IInteraction>().OnPlayerHoldInteraction(this);
			lastInteractable = hitObject;
			if (socket.IsHoldingItem() && socket.GetItemComponent().IsToolType())
			{
				socket.GetItemComponent().PlayToolAnimation();
			}
		}
	}

	public void OnHoldInteractStopped()
	{
		if (socket.IsHoldingItem() && socket.GetItemComponent().IsToolType())
		{
			socket.GetItemComponent().StopToolAnimation();
		}
		if (!(lastInteractable == null) && lastInteractable.GetComponent<IInteraction>() != null)
		{
			lastInteractable.GetComponent<IInteraction>().OnPlayerHoldInteractionStopped(this);
			lastInteractable = null;
		}
	}

	private void UpdateItemSocket()
	{
		int id = InventorySystem.GetInventory(0).items[InventorySystem.GetInventory(0).selectedSlot].id;
		if (id == -1)
		{
			ClearItemSocket();
			return;
		}
		ItemInfo itemInfo = InventorySystem.GetItemLibrary().itemInfos[id];
		if (itemInfo.itemType == ItemInfo.ItemType.Tool)
		{
			characterItemSocket.UpdateSocket(itemInfo);
			currentTrigger = itemInfo.animationTrigger;
		}
		else
		{
			ClearItemSocket();
		}
	}

	private void ClearItemSocket()
	{
		spriteItemInHand.sprite = null;
		spriteItemInHand.enabled = false;
		characterItemSocket.ClearSocket();
	}

	private void TriggerOnActionAnimation(string trigger)
	{
		animator.SetTrigger(trigger);
	}

	public void AnimEventTriggerAction()
	{
		if (!(currentInteractable == null))
		{
			currentInteractable.GetComponent<IInteraction>().OnPlayerAction(this);
			quedAction = false;
			currentInteractable = null;
			characterItemSocket.TriggerHitParticlesInstant();
		}
	}

	public void AnimEventToolSwing()
	{
		SoundManager.PlaySoundOnceDelayed("tool_swing", base.transform);
	}
}
