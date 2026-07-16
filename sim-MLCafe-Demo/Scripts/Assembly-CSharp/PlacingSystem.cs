using UnityEngine;

public class PlacingSystem : MonoBehaviour
{
	[SerializeField]
	private Transform placedObjectsContainer;

	[SerializeField]
	private LayerMask stopPreviewMask;

	[SerializeField]
	private string soundPlacement;

	[SerializeField]
	private string soundTake;

	private GameObject castedObject;

	private static PlacingSystem instance;

	public static string GetDefaultSoundTake()
	{
		return instance.soundTake;
	}

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
	}

	private void FixedUpdate()
	{
		CharacterControllerComponent characterController = GlobalReferences.GetCharacterController();
		if (characterController == null)
		{
			return;
		}
		if (!characterController.socket.IsHoldingItem())
		{
			if (PreviewSystem.IsPreviewing() || PreviewSystem.HasPreviewObject())
			{
				PreviewSystem.ClearPreviewObject();
			}
		}
		else
		{
			PreviewSocketObject(characterController.GetSocket(), characterController.GetCastLength(), characterController.GetPlacementLength());
		}
	}

	public static Transform GetPlaceContainer()
	{
		return instance.placedObjectsContainer;
	}

	public static void PlaceHoldingObject()
	{
		if (!PreviewSystem.IsValidPosition())
		{
			return;
		}
		CharacterControllerComponent characterController = GlobalReferences.GetCharacterController();
		Transform parent = instance.placedObjectsContainer;
		if (characterController.socket.GetItemComponent().GetInfo().itemType != ItemInfo.ItemType.Furniture && instance.castedObject != null && instance.castedObject != characterController.socket.GetItemComponent().gameObject)
		{
			parent = instance.castedObject.transform;
		}
		if (PreviewSystem.IsWallMount())
		{
			parent = null;
		}
		GameObject gameObject = new GameObject("TMPPlacingSpot");
		gameObject.transform.position = PreviewSystem.GetPreviewTransform().position;
		gameObject.transform.rotation = PreviewSystem.GetPreviewTransform().rotation;
		gameObject.transform.localScale = PreviewSystem.GetPreviewTransform().localScale;
		Transform previewTransform = gameObject.transform;
		PlaceableRegisterComponent component = characterController.socket.GetItemComponent().GetComponent<PlaceableRegisterComponent>();
		if (component != null)
		{
			component.OnPlace();
		}
		if (characterController.socket.GetItemComponent().soundOnPlacement != "")
		{
			SoundManager.PlaySoundOnce(characterController.socket.GetItemComponent().soundOnPlacement);
		}
		else
		{
			SoundManager.PlaySoundOnce(instance.soundPlacement);
		}
		characterController.socket.GetItemComponent().OnPlaceEvent.Invoke();
		characterController.socket.PlaceItem(parent, previewTransform, delegate
		{
			if (previewTransform != null)
			{
				Object.Destroy(previewTransform.gameObject);
			}
		});
	}

	public void PreviewSocketObject(ItemSocket socket, float castLength, float placementLength)
	{
		if (!socket.IsHoldingItem())
		{
			if (PreviewSystem.IsPreviewing() || PreviewSystem.HasPreviewObject())
			{
				PreviewSystem.ClearPreviewObject();
			}
			return;
		}
		LayerMask dataLayer_ = socket.GetItemComponent().GetInfo().dataLayer_1;
		float length = castLength;
		if (socket.GetItemComponent().GetInfo().itemType == ItemInfo.ItemType.Furniture)
		{
			length = placementLength;
		}
		RaycastHitPointInfo hitInfo = RayCaster.GetHitInfo(length, (int)dataLayer_ | (int)stopPreviewMask);
		if (hitInfo == null)
		{
			if (PreviewSystem.IsPreviewing())
			{
				PreviewSystem.ClearPreviewObject();
			}
			castedObject = null;
		}
		else if (hitInfo.castedObject != null)
		{
			castedObject = hitInfo.castedObject;
			ItemSocket component = castedObject.GetComponent<ItemSocket>();
			if (component != null && component.useItemPreview)
			{
				if (component.IsUsingItemFilter() && socket.GetItemComponent().item.id != component.onlyItem.id)
				{
					PreviewSystem.ClearPreviewObject();
				}
				else if (component.IsUsingTypeFilter() && socket.GetItemComponent().GetInfo().itemType != component.filterItemType)
				{
					PreviewSystem.ClearPreviewObject();
				}
				else if (component.IsItemInExclusionList(socket.GetItemComponent().item.id))
				{
					PreviewSystem.ClearPreviewObject();
				}
				else if (PreviewSystem.IsPreviewing())
				{
					PreviewSystem.ClearPreviewObject();
					PreviewSystem.PreviewSocketSlot(socket.GetItemComponent().item.id, component);
				}
				else
				{
					PreviewSystem.PreviewSocketSlot(socket.GetItemComponent().item.id, component, update: true);
				}
			}
			else if (socket.GetItemComponent().GetInfo().behaviorType == ItemBehaviour.BehaviourType.GridPlaceable && ((bool)castedObject.GetComponent<ItemComponent>() || castedObject.layer == LayerMask.NameToLayer("PlaceableSurface")))
			{
				if (PreviewSystem.IsPreviewing())
				{
					PreviewSystem.ClearPreviewObject();
				}
			}
			else if (stopPreviewMask.ContainsLayer(hitInfo.castedObject.layer) && socket.GetItemComponent().GetInfo().behaviorType != ItemBehaviour.BehaviourType.GridPlaceable)
			{
				if (PreviewSystem.IsPreviewing())
				{
					PreviewSystem.ClearPreviewObject();
				}
			}
			else if (PreviewSystem.IsPreviewing() && PreviewSystem.CurrentlyPreviewingID() != socket.GetItemComponent().item.id)
			{
				PreviewSystem.InitPreviewObject(socket.GetItemComponent().item.id, hitInfo.hitPointPosition, socket.GetItemComponent().placeOffset);
			}
			else if (!PreviewSystem.HasPreviewObject())
			{
				PreviewSystem.InitPreviewObject(socket.GetItemComponent().item.id, hitInfo.hitPointPosition, socket.GetItemComponent().placeOffset);
			}
			else if (!PreviewSystem.IsPreviewingCorrectMesh())
			{
				PreviewSystem.InitPreviewObject(socket.GetItemComponent().item.id, hitInfo.hitPointPosition, socket.GetItemComponent().placeOffset);
			}
			else
			{
				ItemBehaviour.BehaviourType behaviorType = socket.GetItemComponent().GetInfo().behaviorType;
				PreviewSystem.UpdatePreview(hitInfo.castedObject, hitInfo.IsHitPointSurfaceUpwards(), hitInfo.hitPointPosition + socket.GetItemComponent().placeOffset, dataLayer_, behaviorType);
			}
		}
		else
		{
			if (PreviewSystem.IsPreviewing())
			{
				PreviewSystem.ClearPreviewObject();
			}
			castedObject = null;
		}
	}
}
