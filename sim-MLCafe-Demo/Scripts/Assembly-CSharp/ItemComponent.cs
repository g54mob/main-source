using System.Linq;
using MLCN_Localization;
using UnityEngine;
using UnityEngine.Events;

public class ItemComponent : MonoBehaviour
{
	public Item item;

	public bool useLimitedAmount;

	[Header("Item Instance")]
	public ItemSocket socket;

	public float minScale = 1f;

	public Vector3 alternativeSocketRotation;

	[SerializeField]
	private Transform offsetPivot;

	public Vector3 socketOffset;

	public Vector3 placeOffset;

	private Rigidbody rigidbody;

	[SerializeField]
	private bool SwappableItem = true;

	private bool canSwapAndPush = true;

	[SerializeField]
	private bool turnToWasteWhenConsumed;

	[SerializeField]
	private Color wasteColor;

	private bool isWaste;

	[Header("Animation")]
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private string toolAnimationState;

	[SerializeField]
	private bool usePointAtTarget;

	[SerializeField]
	private bool usePointToGround;

	[SerializeField]
	public ParticleSystem psMovingTrails;

	[Header("Product")]
	public ProductComponent productComponent;

	[Header("Custom Sounds")]
	public string soundOnInteract = "interaction_interact_generic";

	public string soundOnPlacement = "interaction_placement_generic";

	public string soundOnTake = "interaction_take_generic";

	public string soundOnConsume = "interaction_consume_generic";

	public string soundOnFill = "interaction_fill_generic";

	public string soundOnWasteCrumble = "interaction_consume_generic";

	[Header("Preview")]
	[SerializeField]
	private Mesh previewMesh;

	[SerializeField]
	private Material previewMaterial;

	[Header("Display FillAmount")]
	[SerializeField]
	private MeshRenderer renderer;

	[SerializeField]
	private Vector2 gradientMapping;

	[Header("Other")]
	[SerializeField]
	private SkinnedMeshRenderer skinnedRenderer;

	[SerializeField]
	private int wasteBlendShapeIndex;

	[SerializeField]
	private string hintTag = "Item_Interaction";

	public string localizationItemIsAlreadyFull = "ui_popup_invalid_msg_item_isfull";

	public string localizationItemIsEmpty = "ui_popup_invalid_msg_common_empty";

	[SerializeField]
	private BoxCollider collisionObject;

	private Collider collider;

	[SerializeField]
	public UnityEvent OnPlaceEvent = new UnityEvent();

	public UnityEvent OnRefill = new UnityEvent();

	public UnityEvent OnEmpty = new UnityEvent();

	private Vector3 defaultOffset = Vector3.zero;

	public Color GetWasteColor()
	{
		return wasteColor;
	}

	private void Start()
	{
		if (collisionObject == null)
		{
			collider = GetComponent<Collider>();
		}
		else
		{
			collider = collisionObject;
		}
		if (GetComponent<Rigidbody>() != null)
		{
			rigidbody = GetComponent<Rigidbody>();
		}
		if (offsetPivot != null)
		{
			defaultOffset = offsetPivot.localPosition;
			OnPlaceEvent.AddListener(delegate
			{
				offsetPivot.localPosition = defaultOffset;
			});
		}
		UpdateGradientFillAmount();
		UpdateSkinnedMeshAmount();
	}

	public void OnInteraction(CharacterControllerComponent character)
	{
		if (!GetComponent<InteractableComponent>().InRange(character.transform.position))
		{
			return;
		}
		if (GetComponent<SocketPackage>() == null && GetComponent<DeliveryPackage>() == null)
		{
			HintBox hintBoxByTag = PopupMessageManager.GetPopHint().GetHintBoxByTag(hintTag);
			if (PopupMessageManager.GetPopHint().TryShow(hintBoxByTag))
			{
				return;
			}
		}
		if (!canSwapAndPush)
		{
			return;
		}
		if (!character.socket.IsHoldingItem())
		{
			DeactivateRigidbody();
			DeactivateCollision();
			character.socket.PushItem(this, alternativeSocketRotation);
			if (offsetPivot != null)
			{
				offsetPivot.localPosition = socketOffset;
			}
			SoundManager.PlaySoundOnce(soundOnTake);
			return;
		}
		if (character.socket.IsHoldingItem() && socket == null)
		{
			if (CheckForSocketPackage(character))
			{
				return;
			}
			if (!SwappableItem)
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds("ui_popup_invalid_msg_common_swapitem");
				return;
			}
			ItemComponent itemComponent = character.socket.GetItemComponent();
			DeactivateCollision();
			itemComponent.DelayedAtivateCollision(0.2f);
			character.socket.SwapItems(this, PlacingSystem.GetPlaceContainer(), base.transform, minScale, alternativeSocketRotation);
			OnPlaceEvent.Invoke();
			SoundManager.PlaySoundOnce(soundOnTake);
		}
		else
		{
			if (CheckForSocketPackage(character))
			{
				return;
			}
			if (socket != null)
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds("ui_popup_invalid_msg_common_swapitem");
				return;
			}
			if (!SwappableItem)
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds("ui_popup_invalid_msg_common_swapitem");
				return;
			}
			character.socket.GetItemComponent().DelayedAtivateCollision(0.2f);
			DelayedDetivateCollision(0.2f);
			character.socket.SwapItems(socket);
			SoundManager.PlaySoundOnce(soundOnTake);
		}
		PopupMessageManager.HideInfoPopups();
	}

	public bool CheckForSocketPackage(CharacterControllerComponent character)
	{
		SocketPackage component = character.socket.GetItemComponent().GetComponent<SocketPackage>();
		if (component == null)
		{
			return false;
		}
		component.TryPushToPackage(character, this);
		return true;
	}

	public void ActivateSwapAndPush()
	{
		canSwapAndPush = true;
		ActivateCollision();
		ActivateRigidbody();
	}

	public void DeactivateSwapAndPush()
	{
		canSwapAndPush = false;
		DeactivateCollision();
		DeactivateRigidbody();
	}

	public void DelayedAtivateCollision(float delay = 0.5f)
	{
		if (!(collider == null))
		{
			TweenerManager.TweenTimeAction("Delayed Collisions Activation", 0.5f, delegate
			{
				collider.enabled = true;
			});
		}
	}

	public void DelayedDetivateCollision(float delay = 0.5f)
	{
		if (!(collider == null))
		{
			TweenerManager.TweenTimeAction("Delayed Collisions Activation", 0.5f, delegate
			{
				collider.enabled = false;
			});
		}
	}

	public void ActivateCollision()
	{
		if (!(collider == null))
		{
			collider.enabled = true;
		}
	}

	public void DeactivateCollision()
	{
		if (!(collider == null))
		{
			collider.enabled = false;
		}
	}

	public void ActivateRigidbody()
	{
		if (!(rigidbody == null))
		{
			rigidbody.isKinematic = false;
		}
	}

	public void DeactivateRigidbody()
	{
		if (!(rigidbody == null))
		{
			rigidbody.isKinematic = true;
		}
	}

	public Collider GetCollider()
	{
		if (!(collider != null))
		{
			return GetComponent<Collider>();
		}
		return collider;
	}

	public ItemInfo GetInfo()
	{
		if (!InventorySystem.IsValidated())
		{
			return null;
		}
		return InventorySystem.GetItemLibrary().itemInfos[item.id];
	}

	public bool CanBeWaste()
	{
		return turnToWasteWhenConsumed;
	}

	public bool IsWaste()
	{
		return isWaste;
	}

	public bool IsToolType()
	{
		return GetInfo().itemType == ItemInfo.ItemType.Tool;
	}

	public Mesh GetPreviewMesh()
	{
		return previewMesh;
	}

	public Material GetPreviewMaterial()
	{
		return previewMaterial;
	}

	public void PointToolToTarget(Vector3 point)
	{
		if (usePointAtTarget)
		{
			Quaternion b = Quaternion.LookRotation(point - base.transform.position, Vector3.up);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, 10f * Time.deltaTime);
		}
	}

	public void PointToolToGround()
	{
		if (usePointToGround)
		{
			Quaternion b = Quaternion.LookRotation(GlobalReferences.GetCharacterController().transform.forward, Vector3.up);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, 10f * Time.deltaTime);
		}
	}

	public void PlayToolAnimation()
	{
		if (!(animator == null))
		{
			animator.SetBool(toolAnimationState, value: true);
		}
	}

	public void StopToolAnimation()
	{
		if (!(animator == null))
		{
			animator.SetBool(toolAnimationState, value: false);
			TweenerManager.Tween("ReturnToIdleRotation", base.transform, base.transform, socket.transform, TweenerManager.GetDefaultDuration(), TweenerManager.GetDefaultLinearCurve());
		}
	}

	public bool Consume(int amount = 1)
	{
		if (item.amount >= amount)
		{
			item.amount -= amount;
			SoundManager.PlaySoundOnce(soundOnConsume);
		}
		UpdateGradientFillAmount();
		if (item.amount <= 0)
		{
			if (turnToWasteWhenConsumed)
			{
				isWaste = true;
				SoundManager.PlaySoundOnce(soundOnWasteCrumble);
				if (skinnedRenderer != null)
				{
					TweenerManager.TweenBlendShape("WasteBlendShape", skinnedRenderer, wasteBlendShapeIndex, 0f, 100f, 0.5f, TweenerManager.GetDefaultEaseCurve(), null);
				}
			}
			OnEmpty.Invoke();
			return false;
		}
		return true;
	}

	public bool Fill(int amount = 1)
	{
		if (item.amount >= item.maxAmount)
		{
			string localizedMessage = PopupMessageManager.GetHighlightBegin() + LocalizationManager.GetLocalizedString(GetInfo().localizationKey, LocalizationDataTable.Tables.Items) + PopupMessageManager.GetHighlightEnd() + " " + LocalizationManager.GetLocalizedString(localizationItemIsAlreadyFull, LocalizationDataTable.Tables.UI);
			PopupMessageManager.GetInValidOrMissingPopUp().ShowPreLocalizedMessageForSeconds(localizedMessage);
			UpdateGradientFillAmount();
			return false;
		}
		if (item.amount < item.maxAmount)
		{
			item.amount += amount;
		}
		SoundManager.PlaySoundOnce(soundOnFill);
		UpdateGradientFillAmount();
		return true;
	}

	public void RefillItem()
	{
		item.amount = item.maxAmount;
		OnRefill.Invoke();
		UpdateGradientFillAmount();
	}

	public void EmptyItem()
	{
		item.amount = 0;
	}

	public bool IsEmpty()
	{
		return item.amount <= 0;
	}

	public bool HasItem()
	{
		return socket.IsHoldingItem();
	}

	public void DestoryItem()
	{
		Object.Destroy(base.gameObject);
	}

	private void UpdateGradientFillAmount()
	{
		if (!(renderer == null))
		{
			float t = Mathf.InverseLerp(0f, item.maxAmount, item.amount);
			float mapping = Mathf.Lerp(gradientMapping.x, gradientMapping.y, t);
			renderer.materials.ToList().ForEach(delegate(Material m)
			{
				m.SetFloat("_Mask_Position", mapping);
			});
		}
	}

	private void UpdateSkinnedMeshAmount()
	{
		if (item.amount <= 0 && turnToWasteWhenConsumed)
		{
			isWaste = true;
			if (skinnedRenderer != null)
			{
				TweenerManager.TweenBlendShape("WasteBlendShape", skinnedRenderer, wasteBlendShapeIndex, 0f, 100f, 0.5f, TweenerManager.GetDefaultEaseCurve(), null);
			}
		}
	}
}
