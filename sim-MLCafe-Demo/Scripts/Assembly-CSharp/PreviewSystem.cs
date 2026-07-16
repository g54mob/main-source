using UnityEngine;

public class PreviewSystem : MonoBehaviour
{
	[SerializeField]
	private GameObject previewObject;

	[SerializeField]
	private GameObject previewGrid;

	[SerializeField]
	private float drag = 5f;

	private int previewingItemId;

	private GameObject previewInstance;

	private Vector3 targetRot;

	private Vector3 targetOffset;

	private static PreviewSystem instance;

	private bool isPlaceable;

	private bool isPreviewing;

	private bool useGridPreview;

	private bool interactableOverlap;

	private bool maskOverlap;

	private bool canPlacedOnWall;

	private bool lookingAtWall;

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
		ClearPreviewObject();
	}

	public static bool IsPreviewing()
	{
		return instance.isPreviewing;
	}

	public static bool IsPreviewingWithGrid()
	{
		if (instance.isPreviewing)
		{
			return instance.useGridPreview;
		}
		return false;
	}

	public static bool IsWallMount()
	{
		if (!instance.canPlacedOnWall)
		{
			return instance.lookingAtWall;
		}
		return true;
	}

	public static bool IsValidPosition()
	{
		return instance.isPlaceable;
	}

	public static int CurrentlyPreviewingID()
	{
		return instance.previewingItemId;
	}

	public static bool HasPreviewObject()
	{
		if (!GlobalReferences.GetCharacterController().socket.IsHoldingItem())
		{
			ClearPreviewObject();
			return false;
		}
		return instance.previewInstance != null;
	}

	public static bool IsPreviewingCorrectMesh()
	{
		ItemInfo itemInfo = InventorySystem.GetItemLibrary().itemInfos[instance.previewingItemId];
		if (itemInfo == null || itemInfo.prefab == null)
		{
			return false;
		}
		return instance.previewInstance != itemInfo.previewPrefab;
	}

	public static Transform GetPreviewTransform()
	{
		return instance.previewObject.transform;
	}

	public static Transform GetPreviewInstanceTransform()
	{
		return instance.previewInstance.transform;
	}

	public static void RotatePreview(int direction)
	{
		_ = InventorySystem.GetItemLibrary().itemInfos[instance.previewingItemId];
		instance.targetRot += new Vector3(0f, 45 * direction, 0f);
	}

	public static void UpdatePreview(GameObject hitObject, bool isFlatSurface, Vector3 position, LayerMask triggerMask, ItemBehaviour.BehaviourType itemBehaviour)
	{
		instance.canPlacedOnWall = triggerMask.ContainsLayer(LayerMask.NameToLayer("WallSurface"));
		Debug.Log("WALL PLACEMENT: " + hitObject.name);
		if (instance.canPlacedOnWall)
		{
			isFlatSurface = true;
		}
		else if (hitObject.GetComponent<ItemComponent>() != null)
		{
			instance.isPlaceable = false;
			ClearPreviewObject();
			return;
		}
		instance.lookingAtWall = hitObject.GetComponentInParent<WallInstance>() != null;
		if (hitObject != null && isFlatSurface)
		{
			if (!instance.previewObject.activeInHierarchy)
			{
				instance.previewObject.transform.position = position;
			}
			instance.ShowPreview();
		}
		else if (itemBehaviour != ItemBehaviour.BehaviourType.GridPlaceable)
		{
			instance.HidePreview();
			return;
		}
		bool flag = false;
		if (itemBehaviour == ItemBehaviour.BehaviourType.GridPlaceable)
		{
			flag = true;
		}
		if (flag)
		{
			position = RayCaster.GetSnappedPosition(position);
			position = new Vector3(position.x, 0f, position.z);
			instance.previewGrid.transform.position = new Vector3(position.x, 0.1f, position.z);
			instance.previewObject.transform.position = Vector3.Lerp(instance.previewObject.transform.position, position, instance.drag * Time.deltaTime);
		}
		else
		{
			instance.previewObject.transform.position = Vector3.Lerp(instance.previewObject.transform.position, position, instance.drag * Time.deltaTime);
		}
		Quaternion quaternion = Quaternion.Inverse(GlobalReferences.GetCharacterController().transform.rotation);
		Quaternion b = Quaternion.Euler(0f, instance.canPlacedOnWall ? (Mathf.Round(quaternion.y / 90f) * 90f) : instance.targetRot.y, 0f);
		Quaternion rotation = Quaternion.Lerp(instance.previewObject.transform.rotation, b, instance.drag * Time.deltaTime);
		instance.previewObject.transform.rotation = rotation;
		instance.interactableOverlap = instance.previewObject.GetComponent<PreviewTrigger>().IsOverlapping(LayerMask.NameToLayer("Interactable"));
		instance.maskOverlap = instance.previewObject.GetComponent<PreviewTrigger>().IsOverlapping(triggerMask);
		bool flag2 = ((!flag) ? instance.maskOverlap : (instance.maskOverlap || instance.interactableOverlap));
		if (hitObject.layer == LayerMask.NameToLayer("WallSurface"))
		{
			flag2 = true;
		}
		instance.isPlaceable = !flag2;
		if (instance.isPlaceable)
		{
			MouseCursorInteraction.ShowPlaceControl();
		}
		else
		{
			MouseCursorInteraction.HidePlaceControl();
		}
		if (instance.previewObject.GetComponentsInChildren<MeshRenderer>().Length != 0)
		{
			MeshRenderer[] componentsInChildren = instance.previewObject.GetComponentsInChildren<MeshRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Material[] materials = componentsInChildren[i].materials;
				for (int j = 0; j < materials.Length; j++)
				{
					materials[j].SetFloat("_Overlap", flag2 ? 1 : 0);
				}
			}
		}
		if (instance.previewObject.GetComponentsInChildren<SkinnedMeshRenderer>().Length == 0)
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = instance.previewObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		for (int i = 0; i < componentsInChildren2.Length; i++)
		{
			Material[] materials = componentsInChildren2[i].materials;
			for (int j = 0; j < materials.Length; j++)
			{
				materials[j].SetFloat("_Overlap", flag2 ? 1 : 0);
			}
		}
	}

	public static void InitPreviewObject(int itemId, Vector3 initialPosition, Vector3 offset = default(Vector3))
	{
		instance.previewingItemId = itemId;
		ItemInfo itemInfo = InventorySystem.GetItemLibrary().itemInfos[itemId];
		if (itemInfo == null || itemInfo.prefab == null)
		{
			return;
		}
		instance.previewInstance = Object.Instantiate(itemInfo.previewPrefab, instance.previewObject.transform);
		ItemComponent component = itemInfo.prefab.GetComponent<ItemComponent>();
		if (component != null)
		{
			if ((bool)component.GetComponent<PreviewColliderComponent>())
			{
				PreviewColliderComponent component2 = component.GetComponent<PreviewColliderComponent>();
				instance.previewObject.GetComponent<BoxCollider>().center = component2.center;
				instance.previewObject.GetComponent<BoxCollider>().size = component2.size;
			}
			else if (component.GetCollider().GetType() == typeof(BoxCollider))
			{
				instance.previewObject.GetComponent<BoxCollider>().center = ((BoxCollider)component.GetCollider()).center;
				instance.previewObject.GetComponent<BoxCollider>().size = ((BoxCollider)component.GetCollider()).size;
			}
			if (component.GetCollider().GetType() == typeof(CapsuleCollider))
			{
				instance.previewObject.GetComponent<BoxCollider>().center = ((CapsuleCollider)component.GetCollider()).center;
				instance.previewObject.GetComponent<BoxCollider>().size = Vector3.one * ((CapsuleCollider)component.GetCollider()).radius;
			}
		}
		instance.useGridPreview = itemInfo.behaviorType == ItemBehaviour.BehaviourType.GridPlaceable;
		MouseCursorInteraction.ShowRotateObjectControl();
		instance.previewObject.transform.position = initialPosition + offset;
		instance.ShowPreview();
		instance.isPreviewing = true;
		if (instance.previewObject.GetComponentsInChildren<MeshRenderer>().Length != 0)
		{
			MeshRenderer[] componentsInChildren = instance.previewObject.GetComponentsInChildren<MeshRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Material[] materials = componentsInChildren[i].materials;
				for (int j = 0; j < materials.Length; j++)
				{
					materials[j].SetFloat("_Preview", 1f);
				}
			}
		}
		if (instance.previewObject.GetComponentsInChildren<SkinnedMeshRenderer>().Length == 0)
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = instance.previewObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		for (int i = 0; i < componentsInChildren2.Length; i++)
		{
			Material[] materials = componentsInChildren2[i].materials;
			for (int j = 0; j < materials.Length; j++)
			{
				materials[j].SetFloat("_Preview", 1f);
			}
		}
	}

	public static void ClearPreviewObject()
	{
		Object.Destroy(instance.previewInstance);
		instance.previewInstance = null;
		instance.previewObject.GetComponent<BoxCollider>().center = Vector3.zero;
		instance.previewObject.GetComponent<BoxCollider>().size = Vector3.zero;
		MouseCursorInteraction.HideRotateObjectControl();
		MouseCursorInteraction.HidePlaceControl();
		instance.useGridPreview = false;
		instance.previewObject.GetComponent<PreviewTrigger>().Clear();
		instance.HidePreview();
		instance.isPlaceable = false;
		instance.isPreviewing = false;
		if (instance.previewObject.transform.childCount > 0)
		{
			for (int i = 0; i < instance.previewObject.transform.childCount; i++)
			{
				Object.Destroy(instance.previewObject.transform.GetChild(i).gameObject);
			}
		}
	}

	public static void PreviewSocketSlot(int itemId, ItemSocket socket, bool update = false)
	{
		instance.previewingItemId = itemId;
		if (!socket.CheckReceivingItemId(itemId))
		{
			ClearPreviewObject();
			return;
		}
		if (!update)
		{
			ItemInfo itemInfo = InventorySystem.GetItemLibrary().itemInfos[itemId];
			if (itemInfo == null || itemInfo.prefab == null)
			{
				return;
			}
			instance.previewInstance = Object.Instantiate(itemInfo.previewPrefab, instance.previewObject.transform);
			instance.previewInstance.transform.localRotation = Quaternion.identity;
		}
		instance.previewObject.transform.position = socket.transform.position;
		instance.previewObject.transform.eulerAngles = socket.transform.eulerAngles + socket.GetPreferedRotation();
		instance.ShowPreview();
		instance.isPreviewing = true;
		bool flag = socket.IsHoldingItem();
		if (instance.previewObject.GetComponentsInChildren<MeshRenderer>().Length != 0)
		{
			MeshRenderer[] componentsInChildren = instance.previewObject.GetComponentsInChildren<MeshRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Material[] materials = componentsInChildren[i].materials;
				for (int j = 0; j < materials.Length; j++)
				{
					materials[j].SetFloat("_Overlap", flag ? 1 : 0);
				}
			}
		}
		if (instance.previewObject.GetComponentsInChildren<SkinnedMeshRenderer>().Length == 0)
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = instance.previewObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		for (int i = 0; i < componentsInChildren2.Length; i++)
		{
			Material[] materials = componentsInChildren2[i].materials;
			for (int j = 0; j < materials.Length; j++)
			{
				materials[j].SetFloat("_Overlap", flag ? 1 : 0);
			}
		}
	}

	private void ShowPreview()
	{
		previewObject.SetActive(value: true);
		if (useGridPreview)
		{
			previewGrid.SetActive(value: true);
		}
	}

	private void HidePreview()
	{
		previewObject.SetActive(value: false);
		previewGrid.SetActive(value: false);
		instance.previewObject.GetComponent<PreviewTrigger>().Clear();
	}
}
