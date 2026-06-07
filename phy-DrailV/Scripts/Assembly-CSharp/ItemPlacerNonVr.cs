using System.Linq;
using DV;
using DV.CabControls;
using DV.Interaction;
using DV.Interaction.Inputs;
using DV.InventorySystem;
using DV.Items;
using DV.Utils;
using UnityEngine;

public class ItemPlacerNonVr : MonoBehaviour, IItemPlacerHandler
{
	public enum PlacementValidity
	{
		Valid = 0,
		Invalid = 1,
		Questionable = 2
	}

	private struct HelperData
	{
		public Transform boundsTransform;

		public Transform previewTransform;

		public Vector3 halfExtents;

		public ItemPlacerOffset.ItemPlacerOffsetData offsetData;

		public Vector3 previewOffset;

		private Renderer[] previewRenderers;

		private Renderer boxRenderer;

		private Material validMat;

		private Material invalidMat;

		private Material questionableMat;

		public bool surfaceHitAcceptable;

		public HelperData(Transform boundsTransform, Transform previewTransform, Vector3 previewOffset, Vector3 boxSize, Vector3 halfExtents, ItemPlacerOffset.ItemPlacerOffsetData offsetData, Material validMat, Material invalidMat, Material questionableMat)
		{
			this.boundsTransform = boundsTransform;
			this.previewTransform = previewTransform;
			this.previewOffset = previewOffset;
			this.halfExtents = halfExtents;
			this.offsetData = offsetData;
			this.halfExtents.y += offsetData.thicknessOffset;
			this.validMat = validMat;
			this.invalidMat = invalidMat;
			this.questionableMat = questionableMat;
			surfaceHitAcceptable = false;
			previewRenderers = previewTransform.GetComponentsInChildren<Renderer>();
			boxRenderer = boundsTransform.GetChild(0).GetComponent<Renderer>();
			ToggleColor(PlacementValidity.Valid);
		}

		public void UpdateTarget(Vector3 desiredPosition, Transform targetTransform, bool fixPosition = true)
		{
			boundsTransform.position = desiredPosition;
			previewTransform.position = (fixPosition ? boundsTransform.TransformPoint(previewOffset) : desiredPosition);
		}

		public void UpdateRotation(Quaternion desiredRotation, bool fixRotations = true)
		{
			if (fixRotations)
			{
				Vector3 eulerAngles = PlayerManager.PlayerCamera.transform.rotation.eulerAngles;
				eulerAngles.y = 0f;
				Quaternion quaternion = Quaternion.Inverse(Quaternion.Euler(eulerAngles));
				Quaternion quaternion2 = offsetData.rotationOffset * desiredRotation;
				Quaternion quaternion3 = quaternion * quaternion2;
				Transform transform = boundsTransform;
				Quaternion localRotation = (previewTransform.localRotation = quaternion3);
				transform.localRotation = localRotation;
			}
			else
			{
				Transform transform2 = boundsTransform;
				Quaternion localRotation = (previewTransform.rotation = desiredRotation);
				transform2.rotation = localRotation;
			}
		}

		public Vector3 GetPlacementPosition()
		{
			Vector3 result = boundsTransform.TransformPoint(previewOffset);
			result.y += previewTransform.GetChild(0).localPosition.y + offsetData.heightOffset + offsetData.thicknessOffset * 0.5f;
			return result;
		}

		public void ToggleColor(PlacementValidity validity, bool isVisible = true)
		{
			Material sharedMaterial;
			switch (validity)
			{
			case PlacementValidity.Valid:
				sharedMaterial = validMat;
				break;
			case PlacementValidity.Invalid:
				sharedMaterial = invalidMat;
				break;
			case PlacementValidity.Questionable:
				sharedMaterial = questionableMat;
				break;
			default:
				Debug.LogError("Unexpected placement validity, assuming invalid.");
				sharedMaterial = invalidMat;
				break;
			}
			Renderer[] array = previewRenderers;
			foreach (Renderer obj in array)
			{
				obj.sharedMaterial = sharedMaterial;
				obj.enabled = isVisible;
			}
			boxRenderer.sharedMaterial = sharedMaterial;
		}

		public Quaternion GetRotationIncrement(float angleIncrement)
		{
			Vector3 vector = (offsetData.invertScrolling ? Vector3.down : Vector3.up);
			Vector3 axis = Quaternion.Inverse(offsetData.rotationOffset) * vector;
			return Quaternion.AngleAxis(angleIncrement, axis);
		}
	}

	public delegate void ItemPlacementDelegate(ItemBase itemToPlace, bool success, GameObject targetContainer);

	private const string HELPER_OBJECT_NAME = "PlacementHelperBox";

	private const string HELPER_PREVIEW_NAME = "PlacementItemPreview";

	private const float HEIGHT_COLLISION_SAFETY = 0.01f;

	[SerializeField]
	private GameObject helperPrefab;

	private ItemBase itemToPlace;

	private GrabHandlerItem itemGrabHandler;

	private PluggableObject pluggableItem;

	[SerializeField]
	private float maxDistance = 3f;

	[SerializeField]
	private float angleIncrement = 15f;

	[SerializeField]
	private Material validMaterial;

	[SerializeField]
	private Material invalidMaterial;

	[SerializeField]
	private Material questionableMaterial;

	[SerializeField]
	private AudioClip placementAudio;

	private Collider[] overlaps = new Collider[16];

	private RaycastHit[] containerAccessHits = new RaycastHit[16];

	private Grabber grabber;

	private bool pluggableSnap;

	private PlugSocket pluggableSocket;

	private AItemContainer container;

	private ItemContainerAccessPoint lastAccessPoint;

	private int totalScrolls;

	private int worldOverlapMask;

	private int containerAccessOverlapMask;

	private int interactableOverlapMask;

	private PlacementValidity currentValidity = PlacementValidity.Invalid;

	private HelperData helper;

	private Transform itemPreviewBoundingBoxTransform;

	private Transform itemPreviewTransform;

	public bool Processing { get; private set; }

	public bool PlacementAllowed { get; private set; } = true;

	public event ItemPlacementDelegate ItemPlacementStarted;

	public event ItemPlacementDelegate ItemPlacementFinished;

	private void Start()
	{
		worldOverlapMask = LayerMask.GetMask("Default", "Terrain", "World_Item", "Train_Interior", "Interactable");
		containerAccessOverlapMask = LayerMask.GetMask("Inventory");
		interactableOverlapMask = LayerMask.GetMask("Interactable", "World_Item");
		grabber = PlayerManager.PlayerTransform.GetComponentInChildren<Grabber>();
		SetupListeners(on: true);
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SetupListeners(on: false);
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			grabber.GrabStarted += OnGrabStarted;
			grabber.GrabStopped += OnGrabReleased;
			SingletonBehaviour<AppUtil>.Instance.GamePauseRequested += OnPauseRequested;
			SingletonBehaviour<AppUtil>.Instance.GameUnpaused += OnUnpaused;
		}
		else
		{
			grabber.GrabStarted -= OnGrabStarted;
			grabber.GrabStopped -= OnGrabReleased;
			SingletonBehaviour<AppUtil>.Instance.GamePauseRequested -= OnPauseRequested;
			SingletonBehaviour<AppUtil>.Instance.GameUnpaused -= OnUnpaused;
		}
	}

	private void OnPauseRequested()
	{
		PlacementAllowed = false;
	}

	private void OnUnpaused()
	{
		PlacementAllowed = true;
	}

	private void OnGrabStarted(AGrabHandler grabbedObject)
	{
		if (grabbedObject.IsItem)
		{
			itemGrabHandler = (GrabHandlerItem)grabbedObject;
			itemToPlace = grabbedObject.GetComponent<ItemBase>();
			pluggableItem = grabbedObject.GetComponent<PluggableObject>();
		}
	}

	private void OnGrabReleased(AGrabHandler grabHandler)
	{
		if (grabHandler.IsItem)
		{
			if (Processing)
			{
				CancelPlacement();
			}
			itemGrabHandler = null;
			itemToPlace = null;
			pluggableItem = null;
			pluggableSnap = false;
			pluggableSocket = null;
			container = null;
			UpdateAccessPoint(null, isValid: false);
		}
	}

	private void UpdateAccessPoint(ItemContainerAccessPoint accessPoint, bool isValid)
	{
		if (!(lastAccessPoint == accessPoint))
		{
			if (lastAccessPoint != null)
			{
				lastAccessPoint.ForceHighlight(ItemContainerAccessPoint.AccessPointHighlightType.None);
			}
			if (accessPoint != null)
			{
				accessPoint.ForceHighlight(isValid ? ItemContainerAccessPoint.AccessPointHighlightType.Good : ItemContainerAccessPoint.AccessPointHighlightType.Bad);
			}
			lastAccessPoint = accessPoint;
		}
	}

	private void CheckOverlaps()
	{
		if (helper.boundsTransform == null || container != null)
		{
			return;
		}
		if (pluggableItem != null && pluggableSnap)
		{
			UpdateAccessPoint(null, isValid: false);
			currentValidity = PlacementValidity.Valid;
			helper.ToggleColor(currentValidity);
			return;
		}
		currentValidity = PlacementValidity.Invalid;
		if (!helper.surfaceHitAcceptable)
		{
			Vector3 halfExtents = helper.halfExtents;
			halfExtents.y -= helper.offsetData.thicknessOffset;
			helper.ToggleColor(currentValidity);
			return;
		}
		Vector3 halfExtents2 = helper.halfExtents;
		halfExtents2.y -= helper.offsetData.thicknessOffset;
		Transform boundsTransform = helper.boundsTransform;
		int num = Physics.OverlapBoxNonAlloc(boundsTransform.position, halfExtents2, overlaps, boundsTransform.rotation, worldOverlapMask, QueryTriggerInteraction.Ignore);
		if (num == 0)
		{
			currentValidity = PlacementValidity.Valid;
		}
		else
		{
			bool flag = true;
			for (int i = 0; i < num; i++)
			{
				if (overlaps[i].GetComponentInParent<ItemBase>() == null)
				{
					flag = false;
					break;
				}
			}
			currentValidity = ((!flag) ? PlacementValidity.Invalid : PlacementValidity.Valid);
		}
		if (currentValidity == PlacementValidity.Valid)
		{
			int num2 = Physics.OverlapBoxNonAlloc(boundsTransform.position, helper.halfExtents, overlaps, boundsTransform.rotation, interactableOverlapMask, QueryTriggerInteraction.Ignore);
			for (int j = 0; j < num2; j++)
			{
				if (itemToPlace != overlaps[j].GetComponentInParent<ItemBase>())
				{
					currentValidity = PlacementValidity.Questionable;
					break;
				}
			}
		}
		helper.ToggleColor(currentValidity);
	}

	private void UpdateHelperRotation()
	{
		if (pluggableItem != null && pluggableSnap)
		{
			helper.UpdateRotation(pluggableItem.GetSnappedWorldRotationFor(pluggableSocket), fixRotations: false);
		}
		else if (!(helper.boundsTransform == null))
		{
			totalScrolls += InputManager.GetScrollValue();
			helper.UpdateRotation(helper.GetRotationIncrement(angleIncrement * (float)totalScrolls));
		}
	}

	private void UpdateHelperPosition()
	{
		if (helper.boundsTransform == null)
		{
			return;
		}
		Transform transform = PlayerManager.PlayerCamera.transform;
		Vector3 position = transform.position;
		Vector3 forward = transform.forward;
		ItemContainerAccessPoint accessPoint = null;
		float num = float.MaxValue;
		int num2 = Physics.RaycastNonAlloc(position, forward, containerAccessHits, maxDistance, containerAccessOverlapMask, QueryTriggerInteraction.Collide);
		if (num2 > 0)
		{
			containerAccessHits.SortByDistance(num2);
			for (int i = 0; i < num2; i++)
			{
				accessPoint = containerAccessHits[i].collider.GetComponentInParent<ItemContainerAccessPoint>();
				if (!(accessPoint == null))
				{
					num = containerAccessHits[i].distance;
					container = accessPoint.Container;
					break;
				}
			}
		}
		else
		{
			UpdateAccessPoint(null, isValid: false);
		}
		Vector3 desiredPosition;
		if (Physics.Raycast(position, forward, out var hitInfo, maxDistance, worldOverlapMask, QueryTriggerInteraction.Ignore))
		{
			if (accessPoint != null && num <= hitInfo.distance)
			{
				HandleValidAccessPointHit();
				return;
			}
			UpdateAccessPoint(null, isValid: false);
			container = null;
			if (pluggableItem != null && hitInfo.collider.CompareTag("PlugSocket"))
			{
				PlugSocket componentInParent = hitInfo.collider.GetComponentInParent<PlugSocket>();
				if (componentInParent != null && componentInParent.CanAccept(pluggableItem))
				{
					pluggableSnap = true;
					pluggableSocket = componentInParent;
				}
				else
				{
					pluggableSnap = false;
					pluggableSocket = null;
				}
			}
			else
			{
				pluggableSnap = false;
			}
			if (pluggableSnap)
			{
				desiredPosition = pluggableItem.GetSnappedWorldPositionFor(pluggableSocket);
				helper.surfaceHitAcceptable = true;
			}
			else
			{
				bool flag = Vector3.Dot(hitInfo.normal, Vector3.up) > 0.707f;
				Vector3 point = hitInfo.point;
				Vector3 vector2;
				if (flag)
				{
					Vector3 vector = helper.boundsTransform.rotation * helper.halfExtents;
					vector2 = Vector3.up * (Mathf.Abs(vector.y) + 0.01f);
					vector2 -= Vector3.up * helper.offsetData.thicknessOffset;
				}
				else
				{
					vector2 = Vector3.zero;
				}
				helper.surfaceHitAcceptable = flag;
				Vector3 vector3 = hitInfo.point + vector2;
				desiredPosition = hitInfo.point + vector2;
				if (Physics.BoxCast(vector3 + Vector3.up * 0.1f, helper.halfExtents, Vector3.down, out hitInfo, helper.boundsTransform.rotation, 1f, worldOverlapMask, QueryTriggerInteraction.Ignore) && hitInfo.point.y > point.y)
				{
					point.y = hitInfo.point.y;
					desiredPosition = point + vector2;
				}
			}
		}
		else
		{
			if (accessPoint != null)
			{
				HandleValidAccessPointHit();
				return;
			}
			if (pluggableSnap)
			{
				pluggableSnap = false;
				pluggableSocket = null;
			}
			helper.surfaceHitAcceptable = false;
			desiredPosition = transform.position + transform.forward * maxDistance;
		}
		helper.UpdateTarget(desiredPosition, hitInfo.transform, !pluggableSnap);
		void HandleValidAccessPointHit()
		{
			bool flag2 = container.ValidItem(itemToPlace.gameObject) && container.ItemCount < container.Capacity;
			UpdateAccessPoint(accessPoint, flag2);
			currentValidity = ((!flag2) ? PlacementValidity.Invalid : PlacementValidity.Valid);
			helper.ToggleColor(currentValidity, isVisible: false);
			pluggableSnap = false;
			pluggableSocket = null;
		}
	}

	private void InitializePreview()
	{
		SetupVisuals(itemToPlace.GetComponent<InventoryItemSpec>().PreviewPrefab.transform);
		Bounds bounds = BoundsUtil.Merged((from r in itemPreviewTransform.GetComponentsInChildren<Renderer>()
			where r.enabled
			select r.bounds).ToList());
		ItemPlacerOffset.ItemPlacerOffsetData offsetData = GetOffsetData(itemToPlace);
		bool num = !Mathf.Approximately(offsetData.thicknessOffset, 0f);
		if (num)
		{
			Vector3 size = bounds.size;
			size.y += offsetData.thicknessOffset;
			bounds.size = size;
		}
		if (!Mathf.Approximately(offsetData.scaleOffset.sqrMagnitude, 0f))
		{
			Vector3 size2 = bounds.size;
			size2.x *= offsetData.scaleOffset.x;
			size2.y *= offsetData.scaleOffset.y;
			size2.z *= offsetData.scaleOffset.z;
			bounds.size = size2;
			itemPreviewTransform.GetChild(0).localScale = offsetData.scaleOffset;
		}
		itemPreviewBoundingBoxTransform.localScale = bounds.size;
		Vector3 previewOffset = itemPreviewBoundingBoxTransform.InverseTransformPoint(itemPreviewTransform.position - bounds.center);
		Transform parent = PlayerManager.PlayerCamera.transform;
		itemPreviewBoundingBoxTransform.SetParent(parent);
		itemPreviewTransform.SetParent(parent);
		if (num)
		{
			itemPreviewBoundingBoxTransform.GetChild(0).gameObject.SetActive(value: true);
			itemPreviewTransform.GetChild(0).gameObject.SetActive(value: false);
		}
		else
		{
			itemPreviewBoundingBoxTransform.GetChild(0).gameObject.SetActive(value: false);
			itemPreviewTransform.GetChild(0).gameObject.SetActive(value: true);
		}
		helper = new HelperData(itemPreviewBoundingBoxTransform, itemPreviewTransform, previewOffset, bounds.size, bounds.extents, offsetData, validMaterial, invalidMaterial, questionableMaterial);
	}

	private ItemPlacerOffset.ItemPlacerOffsetData GetOffsetData(ItemBase item)
	{
		ItemPlacerOffset component = item.GetComponent<ItemPlacerOffset>();
		if (component != null)
		{
			return component.OffsetData;
		}
		if (item.GetComponent<InventoryItemSpec>() != null)
		{
			return new ItemPlacerOffset.ItemPlacerOffsetData(item.gameObject);
		}
		Debug.LogError("Given item " + item.name + " doesn't have InventoryItemSpec component. Returning default value of ItemPlacerOffsetData.", item);
		return default(ItemPlacerOffset.ItemPlacerOffsetData);
	}

	private void SetupVisuals(Transform itemPrefabTransform)
	{
		if (itemPreviewBoundingBoxTransform == null)
		{
			itemPreviewBoundingBoxTransform = Object.Instantiate(helperPrefab).transform;
			itemPreviewBoundingBoxTransform.name = "PlacementHelperBox";
		}
		if (itemPreviewTransform == null)
		{
			itemPreviewTransform = new GameObject("PlacementItemPreview").transform;
		}
		itemPreviewBoundingBoxTransform.SetParent(null);
		itemPreviewTransform.SetParent(null);
		itemPreviewBoundingBoxTransform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
		itemPreviewTransform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
		LODGroup component = itemPrefabTransform.GetComponent<LODGroup>();
		MeshFilter[] array = ((!(component != null)) ? itemPrefabTransform.GetComponentsInChildren<MeshFilter>() : (from r in component.GetLODs()[0].renderers
			where r != null
			select r.GetComponent<MeshFilter>()).ToArray());
		int num = array.Length;
		int num2 = array.Length - itemPreviewTransform.childCount;
		for (int num3 = 0; num3 < num2; num3++)
		{
			Transform obj = new GameObject("Model").transform;
			obj.gameObject.AddComponent<MeshFilter>();
			obj.gameObject.AddComponent<MeshRenderer>();
			obj.SetParent(itemPreviewTransform);
		}
		for (int num4 = 0; num4 < itemPreviewTransform.childCount; num4++)
		{
			Transform child = itemPreviewTransform.GetChild(num4);
			if (num4 < num)
			{
				MeshFilter meshFilter = array[num4];
				Transform transform = meshFilter.transform;
				child.GetComponent<MeshFilter>().sharedMesh = meshFilter.sharedMesh;
				child.localPosition = itemPrefabTransform.InverseTransformPoint(transform.position);
				child.localRotation = Quaternion.Inverse(itemPrefabTransform.rotation) * transform.rotation;
				child.localScale = transform.lossyScale;
				child.gameObject.SetActive(value: true);
			}
			else
			{
				child.gameObject.SetActive(value: false);
			}
		}
		itemPreviewBoundingBoxTransform.gameObject.SetActive(value: true);
		itemPreviewTransform.gameObject.SetActive(value: true);
	}

	private bool ResolvePlacement()
	{
		if (currentValidity == PlacementValidity.Invalid)
		{
			return false;
		}
		if (!PlacementAllowed)
		{
			currentValidity = PlacementValidity.Invalid;
			return false;
		}
		itemToPlace.transform.position = helper.GetPlacementPosition();
		itemToPlace.transform.rotation = helper.boundsTransform.rotation;
		if (placementAudio != null)
		{
			placementAudio.Play(itemToPlace.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, itemToPlace.transform);
		}
		itemToPlace = null;
		currentValidity = PlacementValidity.Invalid;
		return true;
	}

	private void RemoveHelper()
	{
		if (helper.boundsTransform != null)
		{
			helper.boundsTransform.SetParent(null);
			helper.boundsTransform.gameObject.SetActive(value: false);
		}
		if (helper.previewTransform != null)
		{
			helper.previewTransform.SetParent(null);
			helper.previewTransform.gameObject.SetActive(value: false);
		}
		helper = default(HelperData);
	}

	public void InitializePlacement()
	{
		Processing = true;
		InitializePreview();
		UpdateHelperRotation();
		UpdateHelperPosition();
		ToggleItemScrolling(on: false);
		this.ItemPlacementStarted?.Invoke(itemToPlace, success: true, (container != null) ? container.gameObject : null);
	}

	private void ToggleItemScrolling(bool on)
	{
		ItemScrolling component = itemToPlace.GetComponent<ItemScrolling>();
		if (component != null)
		{
			component.ToggleScrolling(on);
		}
	}

	public void UpdatePlacement()
	{
		if (Processing)
		{
			UpdateHelperRotation();
			UpdateHelperPosition();
			CheckOverlaps();
		}
	}

	public (bool success, GameObject placedItem, GameObject targetContainer) FinalizePlacement()
	{
		if (!Processing)
		{
			return (success: false, placedItem: null, targetContainer: null);
		}
		ItemBase itemBase = itemToPlace;
		GameObject gameObject = ((container != null) ? container.gameObject : null);
		ToggleItemScrolling(on: true);
		bool flag = ResolvePlacement();
		UpdateAccessPoint(null, isValid: false);
		RemoveHelper();
		totalScrolls = 0;
		Processing = false;
		this.ItemPlacementFinished?.Invoke(itemBase, flag, gameObject);
		return (success: flag, placedItem: itemBase.gameObject, targetContainer: gameObject);
	}

	public void CancelPlacement()
	{
		if (Processing)
		{
			ToggleItemScrolling(on: true);
			currentValidity = PlacementValidity.Invalid;
			RemoveHelper();
			totalScrolls = 0;
			Processing = false;
		}
	}
}
