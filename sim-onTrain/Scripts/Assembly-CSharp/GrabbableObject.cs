using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using GPUInstancerPro.PrefabModule;
using UnityEngine;

public class GrabbableObject : PropBase, IGrabbable
{
	public GrabbableType grabbableType;

	public RotationConstraint rotationConstraint;

	public bool isRamp;

	public bool isNotCollideWithOtherProps;

	public bool isBedOrCarpet;

	[Tooltip("Bu prop bir başka stackable prop'un üstüne (Minecraft tarzı) konulabilir mi? Sadece Prop tipi için geçerli.")]
	public bool isStackable;

	[Tooltip("Üst üste konulduğunda alttaki prop ile arasında bırakılacak dikey boşluk (metre).")]
	public float stackGap = 0.3f;

	public float grabDistance = 10f;

	[Tooltip("Boya fırçası ile boyanabilir mi?")]
	public bool isPaintable;

	[SerializeField]
	private LayerMask layerMask;

	[SerializeField]
	private LayerMask ignoreLayer;

	public bool itHasGPUIInstance;

	public GridSnapSystem gridSnapSystem;

	public GameObject originalPrefab;

	public GameObject creatingParticle;

	public bool useExternalColliders;

	public Collider orijinalCollider;

	public List<Collider> externalColliders = new List<Collider>();

	[Tooltip("Drop edildiğinde aktif olacak objeler (örn: fire particle)")]
	public List<GameObject> droppedObjects = new List<GameObject>();

	[Tooltip("Wagon bulmak için raycast atılacak layer")]
	public LayerMask wagonFindLayer;

	[Tooltip("Raycast mesafesi (Y ekseni)")]
	public float wagonFindDistance = 250f;

	[SerializeField]
	private bool showGizmos;

	[HideInInspector]
	public CollectableItemData buildObjectData;

	[HideInInspector]
	public Grabber grabber;

	private List<Material> originalMats = new List<Material>();

	private List<Material> grabMats = new List<Material>();

	private Renderer[] originalRenderers;

	private List<Collider> childColliders = new List<Collider>();

	private readonly Dictionary<Transform, int> originalChildLayers = new Dictionary<Transform, int>();

	private bool isDismantling;

	private Vector3 originalLocalPosition;

	private Quaternion originalLocalRotation;

	private Transform originalParent;

	private int originalWagonID;

	private float originalHealth;

	private bool isRotating;

	private bool dropRequestedWhileRotating;

	private Grabber pendingDropGrabber;

	private TSPlayerController pendingDropPlayer;

	private GPUIPrefab gpuiPrefab;

	private static readonly int Color1Id = Shader.PropertyToID("_Color1");

	private static readonly int Color2Id = Shader.PropertyToID("_Color2");

	private static readonly int Color3Id = Shader.PropertyToID("_Color3");

	private bool dynamicRenderersHidden;

	public bool IsGrabbed { get; private set; }

	public LayerMask DefaultLayerMask { get; private set; }

	public bool IsPlaceAreaEmpty { get; set; }

	public bool ItCanPlace { get; set; }

	public bool IsDropped { get; set; }

	public bool IsBeingRemoved { get; private set; }

	public SnapPointPositionData SnappedObject { get; set; }

	public int SnappedCountWall { get; set; }

	public LayerMask IgnoreLayer => ignoreLayer;

	public bool IsDismantling => isDismantling;

	private void Awake()
	{
		CaptureOriginalLayers();
		originalRenderers = GetComponentsInChildren<Renderer>();
		gridSnapSystem = GetComponent<GridSnapSystem>();
		StartCoroutine(WaitForFrame());
		Renderer[] array = originalRenderers;
		for (int i = 0; i < array.Length; i++)
		{
			Material[] materials = array[i].materials;
			foreach (Material material in materials)
			{
				originalMats.Add(material);
				Material material2 = new Material(material);
				SetMaterialTransparent(material2);
				grabMats.Add(material2);
			}
		}
		base.gameObject.name += UnityEngine.Random.Range(0, 9999999);
		SetDroppedObjectsActive(active: false);
	}

	private void SetMaterialTransparent(Material mat)
	{
		mat.SetFloat("_Surface", 1f);
		mat.SetFloat("_Blend", 0f);
		mat.SetInt("_SrcBlend", 5);
		mat.SetInt("_DstBlend", 10);
		mat.SetInt("_ZWrite", 0);
		mat.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
		mat.renderQueue = 3000;
	}

	private void Start()
	{
		if (!IsGrabbed)
		{
			HandleColliders();
			SetDroppedObjectsActive(active: true);
		}
		if (itHasGPUIInstance && !IsGrabbed)
		{
			RegisterWithGPUInstancer();
		}
		Debug.Log(health);
	}

	private void RegisterWithGPUInstancer()
	{
		gpuiPrefab = GetComponent<GPUIPrefab>();
		if (gpuiPrefab != null)
		{
			GPUIPrefabAPI.AddPrefabInstance(gpuiPrefab);
		}
	}

	private void UnregisterFromGPUInstancer()
	{
		if (gpuiPrefab != null)
		{
			GPUIPrefabAPI.RemovePrefabInstance(gpuiPrefab);
		}
	}

	private void SetDroppedObjectsActive(bool active)
	{
		foreach (GameObject droppedObject in droppedObjects)
		{
			if (droppedObject != null)
			{
				droppedObject.SetActive(active);
			}
		}
	}

	public void FindWagonByRaycast()
	{
		Vector3 vector = base.transform.position;
		BoxCollider component = GetComponent<BoxCollider>();
		if (component != null)
		{
			vector = component.bounds.center;
		}
		RaycastHit[] array = Physics.RaycastAll(vector, Vector3.down, wagonFindDistance, wagonFindLayer);
		if (array.Length == 0)
		{
			Debug.LogWarning("[GrabbableObject] " + base.name + " için wagon bulunamadı! Raycast sonuç vermedi.");
			return;
		}
		WagonFinderUtility wagonFinderUtility = null;
		float num = float.MaxValue;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			RaycastHit raycastHit = array2[i];
			WagonFinderUtility component2 = raycastHit.collider.GetComponent<WagonFinderUtility>();
			if (component2 != null && component2.wagonController != null)
			{
				float num2 = Vector3.Distance(vector, raycastHit.point);
				if (num2 < num)
				{
					num = num2;
					wagonFinderUtility = component2;
				}
			}
		}
		if (wagonFinderUtility != null)
		{
			assignedWagonID = wagonFinderUtility.wagonController.wagonID;
		}
		else
		{
			Debug.LogWarning("[GrabbableObject] " + base.name + " için WagonFinderUtility bulunamadı!");
		}
	}

	private void HandleColliders(bool isGrabbed = false)
	{
		if (!useExternalColliders)
		{
			return;
		}
		if (orijinalCollider != null)
		{
			orijinalCollider.isTrigger = true;
		}
		if (isGrabbed)
		{
			foreach (Collider externalCollider in externalColliders)
			{
				if (externalCollider != null)
				{
					externalCollider.gameObject.layer = LayerMask.NameToLayer(ConstantStrings.GRABBED_OBJECT_LAYER);
					externalCollider.isTrigger = true;
					externalCollider.enabled = true;
				}
			}
			return;
		}
		foreach (Collider externalCollider2 in externalColliders)
		{
			if (externalCollider2 != null)
			{
				externalCollider2.isTrigger = false;
				externalCollider2.enabled = true;
			}
		}
	}

	public void Drop(Grabber grabber, TSPlayerController player)
	{
		if (IsDropped)
		{
			return;
		}
		if (isRotating)
		{
			if (Input.GetMouseButtonDown(0))
			{
				dropRequestedWhileRotating = true;
				pendingDropGrabber = grabber;
				pendingDropPlayer = player;
			}
		}
		else
		{
			ExecuteDrop(grabber, player);
		}
	}

	public void ForcePlace(Grabber grabber, TSPlayerController player)
	{
		if (!IsDropped)
		{
			ExecuteDrop(grabber, player, fromRotation: true);
		}
	}

	[Obsolete]
	private void ExecuteDrop(Grabber grabber, TSPlayerController player, bool fromRotation = false)
	{
		PlayerInventory component = grabber.GetComponent<PlayerInventory>();
		bool num;
		if (!fromRotation)
		{
			if (IsGrabbed && Input.GetMouseButton(0) && ItCanPlace)
			{
				num = CheckPlaceArea();
				goto IL_0046;
			}
		}
		else if (IsGrabbed && ItCanPlace)
		{
			num = CheckPlaceArea();
			goto IL_0046;
		}
		goto IL_07c1;
		IL_07c1:
		dropRequestedWhileRotating = false;
		pendingDropGrabber = null;
		pendingDropPlayer = null;
		return;
		IL_0046:
		if (num)
		{
			if (NetworkSoundPlayer.Instance != null)
			{
				NetworkSoundPlayer.Instance.PlaySound(GameAudios.BuildDropSound, base.transform.position);
			}
			if (InteractionPanel.Instance != null)
			{
				InteractionPanel.Instance.HideInteraction();
			}
			IInteractable component2 = GetComponent<IInteractable>();
			if (component2 != null)
			{
				component2.IsActive = true;
			}
			IsGrabbed = false;
			ReturnTheOriginalMats();
			grabber.GetComponent<BuildObjectSpawner>().objectParent = base.transform.parent;
			if (grabbableType == GrabbableType.Prop || grabbableType == GrabbableType.WallProp)
			{
				if (grabbableType != GrabbableType.WallProp)
				{
					FindWagonByRaycast();
				}
				Debug.Log($"[Drop] {data.itemName} | LocalPos: {base.transform.localPosition} | WagonID: {assignedWagonID}");
				Debug.Log(string.Format("[ramp] Drop() | isRamp: {0} | worldPos: {1} | worldRot: {2} | localPos: {3} | localRot: {4} | parent: {5}", isRamp, base.transform.position, base.transform.rotation.eulerAngles, base.transform.localPosition, base.transform.localEulerAngles, (base.transform.parent != null) ? base.transform.parent.name : "null"));
				DoorBase doorBase = ((grabbableType == GrabbableType.WallProp) ? base.transform.GetComponentInParent<DoorBase>() : null);
				bool flag = false;
				Debug.Log(string.Format("[DOORPROP] Drop '{0}' | grabbableType={1} | parent={2} | mountedDoor={3}", data.itemName, grabbableType, (base.transform.parent != null) ? base.transform.parent.name : "null", (doorBase != null) ? doorBase.name : "NULL"));
				if (doorBase != null)
				{
					int closestLeafIndex = doorBase.GetClosestLeafIndex(base.transform.position);
					Transform movingPart = doorBase.GetMovingPart(closestLeafIndex);
					string stableDoorKey = DoorBase.GetStableDoorKey(doorBase);
					Debug.Log(string.Format("[DOORPROP] leafIndex={0} | leaf={1} | doorID='{2}'", closestLeafIndex, (movingPart != null) ? movingPart.name : "NULL", stableDoorKey));
					if (movingPart != null && !string.IsNullOrEmpty(stableDoorKey))
					{
						Vector3 leafLocalPos = movingPart.InverseTransformPoint(base.transform.position);
						Vector3 eulerAngles = (Quaternion.Inverse(movingPart.rotation) * base.transform.rotation).eulerAngles;
						grabber.GetComponent<BuildObjectSpawner>().SpawnObjectOnDoorServer(leafLocalPos, eulerAngles, data.itemName, assignedWagonID, stableDoorKey, closestLeafIndex);
						flag = true;
					}
				}
				if (!flag)
				{
					grabber.GetComponent<BuildObjectSpawner>().SpawnObjectOnServer(base.transform.position, base.transform.rotation, data.itemName, assignedWagonID);
				}
				Singleton<ObjectManager>.Instance.OnObjectPlaced.Invoke(this);
				TaskEventManager.OnPlaceObjectTaskCompleted.Invoke(data, 1);
				bool flag2 = true;
				if (TrainGameManager.Instance == null || TrainGameManager.Instance.currentGameMode != GameMode.Creative)
				{
					EastUpPlayerItemManager component3 = player.GetComponent<EastUpPlayerItemManager>();
					int num2 = ((component3 != null && component3.lastSelectedSlot != null) ? component3.lastSelectedSlot.inventoryID : (-1));
					component.AddItemInventory(data, -1, -1f, num2);
					flag2 = false;
					foreach (InventorySlotsData inventorySlotsDatum in component.inventorySlotsData)
					{
						if (inventorySlotsDatum.slotID == num2 && inventorySlotsDatum.item == data && inventorySlotsDatum.itemCountInSlot > 0)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (flag2 && !data.isNetworkObject)
				{
					GrabbableObject component4 = UnityEngine.Object.Instantiate(data.itemPrefab).GetComponent<GrabbableObject>();
					component4.IsDropped = true;
					component4.ItCanPlace = false;
					grabber.lastRotatedCount = grabber.rotatedCount;
					grabber.GrabObject(component4);
				}
				else
				{
					grabber.CancelBuild();
				}
			}
			else if (data.itemType == ItemType.BuildItem)
			{
				FindWagonByRaycast();
				Debug.Log($"[Drop] {buildObjectData.itemName} | LocalPos: {base.transform.localPosition} | WagonID: {assignedWagonID}");
				Debug.Log(string.Format("[ramp] Drop(BuildItem) | isRamp: {0} | worldPos: {1} | worldRot: {2} | localPos: {3} | localRot: {4} | parent: {5}", isRamp, base.transform.position, base.transform.rotation.eulerAngles, base.transform.localPosition, base.transform.localEulerAngles, (base.transform.parent != null) ? base.transform.parent.name : "null"));
				grabber.GetComponent<BuildObjectSpawner>().SpawnObjectOnServer(base.transform.position, base.transform.rotation, buildObjectData.itemName, assignedWagonID);
				bool flag3 = true;
				if (TrainGameManager.Instance == null || TrainGameManager.Instance.currentGameMode != GameMode.Creative)
				{
					foreach (CostData costDatum in buildObjectData.costData)
					{
						component.AddItemInventory(costDatum.item, -costDatum.cost);
					}
					flag3 = DuubyUtilities.ItNeededItemsExit(buildObjectData, component);
				}
				TaskEventManager.OnBuildTaskCompleted.Invoke(buildObjectData, 1);
				TaskEventManager.OnBuildObjectTaskCompleted.Invoke(buildObjectData, 1);
				if (flag3)
				{
					GrabbableObject component5 = UnityEngine.Object.Instantiate(buildObjectData.itemPrefab).GetComponent<GrabbableObject>();
					component5.IsDropped = true;
					component5.buildObjectData = buildObjectData;
					component5.transform.eulerAngles = base.transform.eulerAngles;
					component5.ItCanPlace = false;
					grabber.GrabObject(component5);
				}
				else
				{
					Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Not enough resources", buildObjectData);
					if (ObjectBuilderUIManager.Instance != null)
					{
						ObjectBuilderUIManager.Instance.StopBuild();
					}
					grabber.selectedGrabbleObject = null;
				}
			}
			else
			{
				grabber.selectedGrabbleObject = null;
			}
			if (NetworkSceneObjectSpawner.Instance != null)
			{
				NetworkSceneObjectSpawner.Instance.SpawnBuildPlaceParticle(base.transform.position);
			}
			HandleColliders();
			SetDroppedObjectsActive(active: true);
			IsDropped = true;
			UnregisterFromGPUInstancer();
			UnityEngine.Object.Destroy(base.gameObject);
			GridSnapSystem[] componentsInChildren = base.transform.GetComponentsInChildren<GridSnapSystem>();
			foreach (GridSnapSystem gridSnapSystem in componentsInChildren)
			{
				if (gridSnapSystem.gameObject != base.gameObject)
				{
					gridSnapSystem.gameObject.SetActive(value: true);
				}
			}
			if (player.GetComponent<EastUpPlayerItemManager>().IsSelectedSlotEmpty() && data.itemType != ItemType.BuildItem && ObjectBuilderUIManager.Instance != null)
			{
				ObjectBuilderUIManager.Instance.StopBuild();
			}
		}
		goto IL_07c1;
	}

	private IEnumerator WaitForFrame()
	{
		yield return new WaitForFixedUpdate();
		yield return new WaitForFixedUpdate();
		IsDropped = false;
	}

	private void OnTransformParentChanged()
	{
	}

	public void DestroyObject()
	{
		UnregisterFromGPUInstancer();
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public void Grab()
	{
		IsGrabbed = true;
		ItCanPlace = false;
		dropRequestedWhileRotating = false;
		if (isRamp)
		{
			grabber.rotatedCount = 0;
			Debug.Log(string.Format("[ramp] Grab() | isRamp=true | grabbableType: {0} | worldEuler: {1} | localEuler: {2} | parent: {3}", grabbableType, base.transform.eulerAngles, base.transform.localEulerAngles, (base.transform.parent != null) ? base.transform.parent.name : "null"));
		}
		else if (grabbableType == GrabbableType.WallProp)
		{
			grabber.rotatedCount = 0;
		}
		else if (grabbableType == GrabbableType.Roof)
		{
			if (grabber.rotatedCount > 5)
			{
				grabber.rotatedCount = 0;
			}
		}
		else if (grabbableType == GrabbableType.Prop)
		{
			int num = ((rotationConstraint != RotationConstraint.Both) ? 1 : 3);
			if (grabber.rotatedCount > num)
			{
				grabber.rotatedCount = 0;
			}
			if (rotationConstraint == RotationConstraint.VerticalOnly && grabber.rotatedCount == 0)
			{
				base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, base.transform.eulerAngles.y + 90f, base.transform.eulerAngles.z);
			}
		}
		pendingDropGrabber = null;
		pendingDropPlayer = null;
		IInteractable component = GetComponent<IInteractable>();
		if (component != null)
		{
			component.IsActive = false;
		}
		CaptureOriginalLayers();
		base.gameObject.layer = LayerMask.NameToLayer(ConstantStrings.GRABBED_OBJECT_LAYER);
		foreach (Transform item in base.transform)
		{
			item.gameObject.layer = LayerMask.NameToLayer(ConstantStrings.MAIN_CAMERA_OBJECTS);
		}
		DisableChildColliders();
		if (!CheckPlaceArea())
		{
			ItCanPlace = false;
		}
		GridSnapSystem[] componentsInChildren = base.transform.GetComponentsInChildren<GridSnapSystem>();
		foreach (GridSnapSystem gridSnapSystem in componentsInChildren)
		{
			if (gridSnapSystem.gameObject != base.gameObject)
			{
				gridSnapSystem.gameObject.SetActive(value: false);
			}
		}
		HandleColliders(isGrabbed: true);
		SetDroppedObjectsActive(active: false);
	}

	public bool CheckPlaceArea()
	{
		bool flag = true;
		float sizeExtend = 2f;
		BoxCollider component = GetComponent<BoxCollider>();
		if (component != null)
		{
			flag = CheckSingleColliderPlaceArea(component, sizeExtend);
		}
		if (flag && useExternalColliders && externalColliders != null)
		{
			foreach (Collider externalCollider in externalColliders)
			{
				if (externalCollider != null && !CheckSingleColliderPlaceArea(externalCollider, sizeExtend))
				{
					flag = false;
					break;
				}
			}
		}
		IsPlaceAreaEmpty = flag;
		return flag;
	}

	private bool CheckSingleColliderPlaceArea(Collider colliderToCheck, float sizeExtend)
	{
		Vector3 center = colliderToCheck.bounds.center;
		Vector3 halfExtents;
		if (grabbableType == GrabbableType.Wall || grabbableType == GrabbableType.Ground || grabbableType == GrabbableType.CenterWall || grabbableType == GrabbableType.Roof)
		{
			sizeExtend = 2.5f;
			halfExtents = new Vector3(colliderToCheck.bounds.size.x / 2.75f, colliderToCheck.bounds.size.y / sizeExtend, colliderToCheck.bounds.size.z / 2.75f);
			if (grabbableType == GrabbableType.Roof)
			{
				halfExtents.y = Mathf.Max(halfExtents.y, 0.3f);
			}
		}
		else
		{
			halfExtents = new Vector3(colliderToCheck.bounds.size.x / sizeExtend, colliderToCheck.bounds.size.y / 2.5f, colliderToCheck.bounds.size.z / sizeExtend);
		}
		Collider[] source = Physics.OverlapBox(center, halfExtents);
		source = source.Where((Collider c) => c.gameObject.layer != LayerMask.NameToLayer(ConstantStrings.GRABBED_OBJECT_LAYER) && c.gameObject.layer != LayerMask.NameToLayer("BuildingSnapCollider")).ToArray();
		if (grabbableType == GrabbableType.WallProp)
		{
			source = source.Where((Collider c) => c.gameObject.layer != LayerMask.NameToLayer(ConstantStrings.TRAIN_WALL_LAYER)).ToArray();
		}
		Collider[] array = source;
		foreach (Collider collider in array)
		{
			if (collider == colliderToCheck || (externalColliders != null && externalColliders.Contains(collider)) || collider.gameObject == base.gameObject)
			{
				continue;
			}
			if (collider.gameObject.TryGetComponent<GrabbableObject>(out var component) || collider.gameObject.TryGetComponent<ObjectPlacementBlocker>(out var _))
			{
				if (!(component != null) || component.grabbableType == GrabbableType.Wall || component.grabbableType == GrabbableType.CenterWall || (!isNotCollideWithOtherProps && !component.isNotCollideWithOtherProps) || (isNotCollideWithOtherProps && component.isNotCollideWithOtherProps))
				{
					return false;
				}
				continue;
			}
			GrabbableObject componentInParent = collider.GetComponentInParent<GrabbableObject>();
			if (componentInParent != null && componentInParent != this && (componentInParent.grabbableType == GrabbableType.Wall || componentInParent.grabbableType == GrabbableType.CenterWall || (!isNotCollideWithOtherProps && !componentInParent.isNotCollideWithOtherProps) || (isNotCollideWithOtherProps && componentInParent.isNotCollideWithOtherProps)))
			{
				return false;
			}
		}
		return true;
	}

	public void ChangeMaterialAccordingToPlaceable(bool replaceable, bool showItem = true)
	{
		ItCanPlace = replaceable;
		SetDynamicRenderersVisible(visible: false);
		Renderer[] array;
		if (showItem)
		{
			array = originalRenderers;
			foreach (Renderer renderer in array)
			{
				if (renderer != null)
				{
					renderer.enabled = true;
				}
			}
			Color placeableColor = Singleton<GameSettings>.Instance.placeableColor;
			Color unplaceableColor = Singleton<GameSettings>.Instance.unplaceableColor;
			float grabEmissionIntensity = Singleton<GameSettings>.Instance.grabEmissionIntensity;
			Color value = (replaceable ? placeableColor : unplaceableColor);
			Color value2 = new Color(value.r, value.g, value.b, 1f) * grabEmissionIntensity;
			int num = 0;
			array = originalRenderers;
			foreach (Renderer renderer2 in array)
			{
				if (renderer2 == null)
				{
					continue;
				}
				Material[] array2 = new Material[renderer2.materials.Length];
				for (int j = 0; j < renderer2.materials.Length; j++)
				{
					if (num < grabMats.Count)
					{
						grabMats[num].SetColor("_BaseColor", value);
						grabMats[num].EnableKeyword("_EMISSION");
						grabMats[num].SetColor("_EmissionColor", value2);
						grabMats[num].globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
						array2[j] = grabMats[num];
						num++;
					}
				}
				renderer2.materials = array2;
			}
			return;
		}
		array = originalRenderers;
		foreach (Renderer renderer3 in array)
		{
			if (renderer3 != null)
			{
				renderer3.enabled = false;
			}
		}
	}

	private void SetDynamicRenderersVisible(bool visible)
	{
		if (!visible && dynamicRenderersHidden)
		{
			return;
		}
		if (visible)
		{
			dynamicRenderersHidden = false;
		}
		else
		{
			dynamicRenderersHidden = true;
		}
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>(includeInactive: true);
		HashSet<Renderer> hashSet = new HashSet<Renderer>(originalRenderers);
		Renderer[] array = componentsInChildren;
		foreach (Renderer renderer in array)
		{
			if (!(renderer == null) && !hashSet.Contains(renderer))
			{
				renderer.enabled = visible;
			}
		}
	}

	public void Paint(Color color)
	{
		if (originalRenderers == null)
		{
			return;
		}
		Renderer[] array = originalRenderers;
		foreach (Renderer renderer in array)
		{
			if (renderer == null)
			{
				continue;
			}
			Material[] materials = renderer.materials;
			bool flag = false;
			foreach (Material material in materials)
			{
				if (!(material == null))
				{
					bool flag2 = false;
					if (material.HasProperty(Color1Id))
					{
						material.SetColor(Color1Id, color);
						flag2 = true;
					}
					if (material.HasProperty(Color2Id))
					{
						material.SetColor(Color2Id, color);
						flag2 = true;
					}
					if (material.HasProperty(Color3Id))
					{
						material.SetColor(Color3Id, color);
						flag2 = true;
					}
					if (flag2)
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				renderer.materials = materials;
			}
		}
	}

	public void ReturnTheOriginalMats()
	{
		int num = 0;
		for (int i = 0; i < originalRenderers.Length; i++)
		{
			if (originalRenderers[i] == null)
			{
				continue;
			}
			Material[] array = new Material[originalRenderers[i].materials.Length];
			for (int j = 0; j < originalRenderers[i].materials.Length; j++)
			{
				if (num < originalMats.Count)
				{
					array[j] = originalMats[num];
				}
				num++;
			}
			originalRenderers[i].materials = array;
		}
		SetDynamicRenderersVisible(visible: true);
		RestoreOriginalLayers();
		EnableChildColliders();
	}

	private void DisableChildColliders()
	{
		childColliders.Clear();
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>(includeInactive: true);
		Collider component = GetComponent<Collider>();
		Collider[] array = componentsInChildren;
		foreach (Collider collider in array)
		{
			if (collider != component && collider.enabled && (!useExternalColliders || externalColliders == null || !externalColliders.Contains(collider)))
			{
				childColliders.Add(collider);
				collider.enabled = false;
			}
		}
	}

	private void EnableChildColliders()
	{
		foreach (Collider childCollider in childColliders)
		{
			if (childCollider != null)
			{
				childCollider.enabled = true;
			}
		}
		childColliders.Clear();
	}

	public void Remove(PlayerInventory player)
	{
		Debug.Log(string.Format("[remove] GrabbableObject.Remove | name: {0} | IsBeingRemoved: {1} | data: {2} | assignedWagonID: {3} | localPos: {4} | parent: {5}", base.name, IsBeingRemoved, (data != null) ? data.itemName : "null", assignedWagonID, base.transform.localPosition, (base.transform.parent != null) ? base.transform.parent.name : "null"));
		if (IsBeingRemoved)
		{
			return;
		}
		IsBeingRemoved = true;
		if (NetworkSceneObjectSpawner.Instance != null)
		{
			NetworkSceneObjectSpawner.Instance.SpawnBuildRemoveParticle(base.transform.position);
		}
		BuildObjectSpawner component = player.GetComponent<BuildObjectSpawner>();
		Debug.Log("[remove] spawner: " + ((component != null) ? "OK" : "null") + " | data: " + ((data != null) ? data.itemName : "null"));
		if (component != null && data != null)
		{
			Vector3 localPosition = base.transform.localPosition;
			int num = assignedWagonID;
			Debug.Log($"[remove] DestroyObjectOnServer | localPos: {localPosition} | itemName: {data.itemName} | wagonID: {num} | uid: {uniqueID}");
			component.DestroyObjectByIdOnServer(uniqueID, localPosition, data.itemName, num);
		}
		else
		{
			Debug.Log("[remove] SKIPPED DestroyObjectOnServer - spawner or data is null!");
		}
		ChestController component2 = GetComponent<ChestController>();
		if (component2 != null && component2.inventorySlotsData.Count > 0)
		{
			foreach (InventorySlotsDataNetwork slot in component2.inventorySlotsData)
			{
				if (string.IsNullOrEmpty(slot.itemName) || slot.itemCountInSlot <= 0)
				{
					continue;
				}
				CollectableItemData collectableItemData = null;
				if (Singleton<DataManager>.Instance != null)
				{
					collectableItemData = Singleton<DataManager>.Instance.collectableDatas.Find((CollectableItemData x) => x.itemName == slot.itemName);
				}
				if (collectableItemData != null)
				{
					player.AddItemInventory(collectableItemData, slot.itemCountInSlot, slot.currentDurability);
					Debug.Log($"[remove] Chest item transferred: {slot.itemName} x{slot.itemCountInSlot}");
				}
			}
		}
		if (grabbableType == GrabbableType.Prop || grabbableType == GrabbableType.WallProp)
		{
			if (data != null)
			{
				player.AddItemInventory(data, 1);
				if (data.itemPrefab != null && !data.isNetworkObject)
				{
					GrabbableObject component3 = UnityEngine.Object.Instantiate(data.itemPrefab).GetComponent<GrabbableObject>();
					component3.IsDropped = true;
					component3.ItCanPlace = false;
					if (grabber != null)
					{
						grabber.GrabObject(component3);
					}
				}
			}
		}
		else if (data != null && data.costData != null)
		{
			float num2 = ((Singleton<GameSettings>.Instance != null) ? Singleton<GameSettings>.Instance.buildItemRemoveRefundPercentage : 0.5f);
			float healthPercentage = GetHealthPercentage();
			foreach (CostData costDatum in data.costData)
			{
				int num3 = Mathf.FloorToInt((float)costDatum.cost * num2 * healthPercentage);
				if (num3 > 0)
				{
					player.AddItemInventory(costDatum.item, num3);
				}
			}
		}
		UnregisterFromGPUInstancer();
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public bool IsInLayerMask(int layer, LayerMask layerMask)
	{
		return ((1 << layer) & (int)layerMask) != 0;
	}

	private void OnDrawGizmos()
	{
		if (showGizmos)
		{
			float num = 2f;
			if (grabbableType == GrabbableType.Wall || grabbableType == GrabbableType.Ground)
			{
				num = 2.5f;
			}
			ExtDebug.DrawBox(GetComponent<BoxCollider>().bounds.center, GetComponent<BoxCollider>().bounds.size / num, base.transform.rotation, Color.blue);
		}
	}

	public void Rotate()
	{
		if (isRamp || !Input.GetKeyUp(Singleton<UserPrefencesManager>.Instance.keyData.RotateKey) || !IsGrabbed || isRotating)
		{
			return;
		}
		dropRequestedWhileRotating = false;
		if (grabbableType == GrabbableType.WallProp)
		{
			return;
		}
		if (grabbableType == GrabbableType.Roof)
		{
			grabber.rotatedCount++;
			if (grabber.rotatedCount > 5)
			{
				grabber.rotatedCount = 0;
			}
		}
		else if (grabbableType == GrabbableType.Wall || grabbableType == GrabbableType.CenterWall)
		{
			grabber.rotatedCount++;
			if (grabber.rotatedCount > 1)
			{
				grabber.rotatedCount = 0;
			}
		}
		else
		{
			if (grabbableType != GrabbableType.Prop)
			{
				return;
			}
			isRotating = true;
			float num = 90f;
			int num2 = 3;
			switch (rotationConstraint)
			{
			case RotationConstraint.Both:
				num = 90f;
				num2 = 3;
				break;
			case RotationConstraint.HorizontalOnly:
				num = 180f;
				num2 = 1;
				break;
			case RotationConstraint.VerticalOnly:
				num = 180f;
				num2 = 1;
				break;
			}
			grabber.rotatedCount++;
			if (grabber.rotatedCount > num2)
			{
				grabber.rotatedCount = 0;
			}
			base.transform.DOComplete();
			base.transform.DORotate(new Vector3(base.transform.eulerAngles.x, base.transform.eulerAngles.y + num, base.transform.eulerAngles.z), 0.5f).OnComplete(delegate
			{
				isRotating = false;
				Debug.Log(dropRequestedWhileRotating + " drop request  ");
				if (dropRequestedWhileRotating && pendingDropGrabber != null && pendingDropPlayer != null)
				{
					ExecuteDrop(pendingDropGrabber, pendingDropPlayer, fromRotation: true);
				}
				dropRequestedWhileRotating = false;
				pendingDropGrabber = null;
				pendingDropPlayer = null;
			});
		}
	}

	public void Dismantle(Grabber grabberRef, TSPlayerController player)
	{
		if (!IsGrabbed && !isDismantling && !IsBeingRemoved)
		{
			originalLocalPosition = base.transform.localPosition;
			originalLocalRotation = base.transform.localRotation;
			originalParent = base.transform.parent;
			originalWagonID = assignedWagonID;
			originalHealth = health;
			isDismantling = true;
			if (InteractionPanel.Instance != null)
			{
				InteractionPanel.Instance.HideInteraction();
			}
			grabber = grabberRef;
			Grab();
			grabberRef.StartDismantleMode(this);
		}
	}

	public void CancelDismantle()
	{
		if (isDismantling)
		{
			isDismantling = false;
			IsGrabbed = false;
			base.transform.SetParent(originalParent);
			base.transform.localPosition = originalLocalPosition;
			base.transform.localRotation = originalLocalRotation;
			assignedWagonID = originalWagonID;
			health = originalHealth;
			ReturnTheOriginalMats();
			RestoreLayerBasedOnType();
			HandleColliders();
			SetDroppedObjectsActive(active: true);
			IInteractable component = GetComponent<IInteractable>();
			if (component != null)
			{
				component.IsActive = true;
			}
		}
	}

	public void ConfirmDismantle(Grabber grabberRef, TSPlayerController player)
	{
		if (isDismantling)
		{
			isDismantling = false;
			IsGrabbed = false;
			FindWagonByRaycast();
			ReturnTheOriginalMats();
			RestoreLayerBasedOnType();
			HandleColliders();
			SetDroppedObjectsActive(active: true);
			IInteractable component = GetComponent<IInteractable>();
			if (component != null)
			{
				component.IsActive = true;
			}
			BuildObjectSpawner component2 = player.GetComponent<BuildObjectSpawner>();
			if (component2 != null && data != null)
			{
				component2.MoveObjectOnServer(originalLocalPosition, data.itemName, originalWagonID, base.transform.position, base.transform.rotation.eulerAngles, assignedWagonID);
			}
		}
	}

	private void RestoreLayerBasedOnType()
	{
		RestoreOriginalLayers();
	}

	private void CaptureOriginalLayers()
	{
		DefaultLayerMask = base.gameObject.layer;
		originalChildLayers.Clear();
		foreach (Transform item in base.transform)
		{
			originalChildLayers[item] = item.gameObject.layer;
		}
		if (!useExternalColliders || externalColliders == null)
		{
			return;
		}
		foreach (Collider externalCollider in externalColliders)
		{
			if (externalCollider != null)
			{
				originalChildLayers[externalCollider.transform] = externalCollider.gameObject.layer;
			}
		}
	}

	private void RestoreOriginalLayers()
	{
		base.gameObject.layer = DefaultLayerMask;
		foreach (KeyValuePair<Transform, int> originalChildLayer in originalChildLayers)
		{
			if (originalChildLayer.Key != null)
			{
				originalChildLayer.Key.gameObject.layer = originalChildLayer.Value;
			}
		}
		foreach (Transform item in base.transform)
		{
			if (!originalChildLayers.ContainsKey(item))
			{
				item.gameObject.layer = DefaultLayerMask;
			}
		}
	}
}
