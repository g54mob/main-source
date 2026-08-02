using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grabber : MonoBehaviour
{
	public float grabDistance = 5f;

	public float trainMaxDistance = 2.1f;

	private InGameUIManager gameUIManager;

	private ObjectBuilderUIManager builderUIManager;

	public GrabbableObject selectedGrabbleObject;

	[HideInInspector]
	public int rotatedCount;

	[SerializeField]
	public Camera rayCamera;

	private TSPlayerController mainPlayer;

	private PlayerInventory playerInventory;

	private bool isRemovedFromGround;

	private bool isShowingGrabbedObjectInteraction;

	public BuildingHammerController buildingHammerController;

	[HideInInspector]
	public bool isBuildMenuPlacement;

	private CollectableItemData lastInstantiatedItem;

	public int lastRotatedCount;

	private bool isPlacePending;

	private int _grabbedLayerBit;

	private bool isDismantleMode;

	private GrabbableObject dismantlingObject;

	public bool IsDismantleMode => isDismantleMode;

	private void OnEnable()
	{
		Singleton<TSNetworkObjetManager>.Instance?.OnServerInitialize.AddListener(SetParameters);
	}

	private void Start()
	{
		builderUIManager = Object.FindObjectOfType<ObjectBuilderUIManager>();
		gameUIManager = Object.FindObjectOfType<InGameUIManager>();
		_grabbedLayerBit = 1 << LayerMask.NameToLayer(ConstantStrings.GRABBED_OBJECT_LAYER);
	}

	private void SetParameters(TSPlayerController tSPlayerController)
	{
		if (tSPlayerController.isLocalPlayer)
		{
			mainPlayer = tSPlayerController;
			playerInventory = GetComponent<PlayerInventory>();
			if (buildingHammerController == null)
			{
				buildingHammerController = GetComponentInChildren<BuildingHammerController>(includeInactive: true);
			}
		}
	}

	private int GetPlacementRaycastMask()
	{
		if (selectedGrabbleObject == null)
		{
			return ~_grabbedLayerBit;
		}
		return ~((int)selectedGrabbleObject.IgnoreLayer | _grabbedLayerBit);
	}

	private void Update()
	{
		Vector3 pos = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
		Ray ray = rayCamera.ScreenPointToRay(pos);
		CancelBuild();
		if (Physics.Raycast(ray, out var hitInfo, grabDistance, ~_grabbedLayerBit))
		{
			if (hitInfo.collider.TryGetComponent<GrabbableObject>(out var component) && selectedGrabbleObject == null)
			{
				gameUIManager.OpenUserInformative("Press X To Grab");
				if (Input.GetKey(KeyCode.X))
				{
					GrabObject(component, isRemoved: true);
				}
			}
			else
			{
				gameUIManager.CloseUserInformative();
			}
		}
		else
		{
			gameUIManager.CloseUserInformative();
		}
		if (selectedGrabbleObject != null)
		{
			bool flag = InteractionPanel.Instance == null || !InteractionPanel.Instance.IsBottomInfoShowing;
			if (!isShowingGrabbedObjectInteraction || flag)
			{
				ShowGrabbedObjectInteractionPanel();
			}
			RotateGrabbedObject();
			MoveGrabbedObject();
			DropGrabbedObject();
			if (!(selectedGrabbleObject == null) && buildingHammerController != null)
			{
				buildingHammerController.SetCanPlaceItem(selectedGrabbleObject.ItCanPlace);
			}
		}
		else
		{
			if (isShowingGrabbedObjectInteraction)
			{
				HideGrabbedObjectInteractionPanel();
			}
			if (buildingHammerController != null)
			{
				buildingHammerController.SetCanPlaceItem(canPlace: false);
			}
		}
	}

	public void CancelBuild(bool directlyDestroy = false, bool skipBuildModeChangeEvent = false)
	{
		if (selectedGrabbleObject == null)
		{
			return;
		}
		if (directlyDestroy)
		{
			if (isDismantleMode && dismantlingObject != null)
			{
				CancelDismantleMode();
				return;
			}
			DestroyGrabbable();
			builderUIManager.StopBuild(skipBuildModeChangeEvent);
			return;
		}
		if ((selectedGrabbleObject.grabbableType == GrabbableType.Ground || selectedGrabbleObject.grabbableType == GrabbableType.Wall) && !builderUIManager.canBuild)
		{
			DestroyGrabbable();
			builderUIManager.StopBuild(skipBuildModeChangeEvent);
			if (!skipBuildModeChangeEvent)
			{
				TrainGameManager.Instance.mainPlayer.GetComponent<TSPlayerController>().ActivateBuildSystem();
			}
		}
		if (!Input.GetKey(KeyCode.Escape) || TrainGameManager.isMouseLocked)
		{
			return;
		}
		if (isDismantleMode && dismantlingObject != null)
		{
			CancelDismantleMode();
			return;
		}
		GrabbableType grabbableType = selectedGrabbleObject.grabbableType;
		bool flag = grabbableType == GrabbableType.Prop || grabbableType == GrabbableType.WallProp;
		builderUIManager.StopBuild(flag || skipBuildModeChangeEvent);
		DestroyGrabbable();
		if (!flag)
		{
			TrainGameManager.Instance.mainPlayer.GetComponent<TSPlayerController>().ActivateBuildSystem();
		}
	}

	private void DestroyGrabbable()
	{
		HideGrabbedObjectInteractionPanel();
		Object.Destroy(selectedGrabbleObject.gameObject);
		selectedGrabbleObject = null;
	}

	public void GrabObject(GrabbableObject grabbable, bool isRemoved = false, bool skipBuildModeChangeEvent = false, bool fromBuildMenu = false)
	{
		isBuildMenuPlacement = fromBuildMenu;
		if (selectedGrabbleObject != null && selectedGrabbleObject != grabbable)
		{
			DestroyGrabbable();
		}
		if (!isRemoved && grabbable.data != null && lastInstantiatedItem != null && grabbable.data.itemName == lastInstantiatedItem.itemName)
		{
			rotatedCount = lastRotatedCount;
		}
		else
		{
			rotatedCount = 0;
		}
		isRemovedFromGround = isRemoved;
		builderUIManager.OpenBuild(skipBuildModeChangeEvent);
		if (isRemoved)
		{
			playerInventory.AddItemInventory(grabbable.data, 1);
			grabbable.DestroyObject();
			return;
		}
		selectedGrabbleObject = grabbable;
		grabbable.grabber = this;
		grabbable.Grab();
		if (mainPlayer != null)
		{
			mainPlayer.ActivateBuildSystem(active: true);
		}
		if ((grabbable.grabbableType == GrabbableType.Prop || grabbable.grabbableType == GrabbableType.WallProp) && rotatedCount > 0 && !grabbable.isRamp)
		{
			float y = grabbable.transform.eulerAngles.y + 90f * (float)rotatedCount;
			grabbable.transform.eulerAngles = new Vector3(grabbable.transform.eulerAngles.x, y, grabbable.transform.eulerAngles.z);
		}
		if (grabbable.isRamp)
		{
			Debug.Log(string.Format("[ramp] GrabObject | isRamp=true | worldEuler: {0} | localEuler: {1} | parent: {2} | rotatedCount: {3}", grabbable.transform.eulerAngles, grabbable.transform.localEulerAngles, (grabbable.transform.parent != null) ? grabbable.transform.parent.name : "null", rotatedCount));
		}
		lastInstantiatedItem = grabbable.data;
		lastRotatedCount = rotatedCount;
	}

	private void RotateGrabbedObject()
	{
		selectedGrabbleObject.Rotate();
	}

	private void DropGrabbedObject()
	{
		if (!TrainGameManager.isInputActive || TrainGameManager.isMouseLocked)
		{
			return;
		}
		if (isDismantleMode && selectedGrabbleObject != null && selectedGrabbleObject.IsDismantling)
		{
			if (selectedGrabbleObject.IsGrabbed && Input.GetMouseButton(0) && selectedGrabbleObject.ItCanPlace && selectedGrabbleObject.CheckPlaceArea())
			{
				selectedGrabbleObject.ConfirmDismantle(this, mainPlayer);
				isDismantleMode = false;
				dismantlingObject = null;
				selectedGrabbleObject = null;
				builderUIManager.StopBuild(skipBuildModeChangeEvent: true);
				HideGrabbedObjectInteractionPanel();
				if (mainPlayer != null)
				{
					mainPlayer.ActivateBuildSystem();
				}
			}
		}
		else if (buildingHammerController != null && buildingHammerController.placeCastDelay > 0f && !isPlacePending && Input.GetMouseButtonDown(0) && selectedGrabbleObject.IsGrabbed && selectedGrabbleObject.ItCanPlace && selectedGrabbleObject.CheckPlaceArea())
		{
			StartCoroutine(DelayedPlaceCoroutine(selectedGrabbleObject));
		}
		else if (!isPlacePending)
		{
			selectedGrabbleObject.Drop(this, mainPlayer);
		}
	}

	private IEnumerator DelayedPlaceCoroutine(GrabbableObject obj)
	{
		isPlacePending = true;
		yield return new WaitForSeconds(buildingHammerController.placeCastDelay);
		if (obj != null && obj.IsGrabbed && obj.ItCanPlace && obj.CheckPlaceArea())
		{
			obj.ForcePlace(this, mainPlayer);
		}
		isPlacePending = false;
	}

	private void UpdateObjectPosition(Vector3 targetPosition)
	{
		if (Vector3.Distance(selectedGrabbleObject.transform.position, targetPosition) > 1f)
		{
			selectedGrabbleObject.transform.position = targetPosition;
		}
		else
		{
			selectedGrabbleObject.transform.position = Vector3.Lerp(selectedGrabbleObject.transform.position, targetPosition, 15f * Time.deltaTime);
		}
	}

	private List<SnapPointPositionData> GetCompatibleSnapPoints(List<SnapPointPositionData> snapPoints, GrabbableType grabbableType)
	{
		return snapPoints.Where(delegate(SnapPointPositionData sp)
		{
			bool num = sp.suitableGrabbableType == GrabbableType.None;
			bool flag = (sp.suitableGrabbableType & grabbableType) != 0;
			return num || flag;
		}).ToList();
	}

	private bool IsWithinTrainDistance()
	{
		if (selectedGrabbleObject.transform.parent == null)
		{
			return false;
		}
		WagonController component = selectedGrabbleObject.transform.parent.GetComponent<WagonController>();
		if (component != null)
		{
			float num = Mathf.Abs(selectedGrabbleObject.transform.localPosition.x);
			if (selectedGrabbleObject.grabbableType == GrabbableType.Ground)
			{
				bool flag = true;
				if (component.snapPoints != null && component.snapPoints.Count > 0)
				{
					float z = selectedGrabbleObject.transform.localPosition.z;
					float num2 = float.MaxValue;
					float num3 = float.MinValue;
					foreach (Transform snapPoint in component.snapPoints)
					{
						if (!(snapPoint == null))
						{
							float z2 = component.transform.InverseTransformPoint(snapPoint.position).z;
							if (z2 < num2)
							{
								num2 = z2;
							}
							if (z2 > num3)
							{
								num3 = z2;
							}
						}
					}
					flag = z >= num2 && z <= num3;
				}
				return num <= trainMaxDistance && flag;
			}
			return num <= trainMaxDistance;
		}
		return true;
	}

	private bool IsFullyWithinTrainBounds()
	{
		if (selectedGrabbleObject.transform.parent == null)
		{
			return false;
		}
		WagonController component = selectedGrabbleObject.transform.parent.GetComponent<WagonController>();
		if (component == null)
		{
			return false;
		}
		BoxCollider component2 = selectedGrabbleObject.GetComponent<BoxCollider>();
		if (component2 == null)
		{
			return Mathf.Abs(selectedGrabbleObject.transform.localPosition.x) <= trainMaxDistance;
		}
		Vector3 center = component2.center;
		Vector3 vector = component2.size / 2f;
		Transform transform = selectedGrabbleObject.transform;
		Transform transform2 = component.transform;
		float num = 0f;
		for (int i = -1; i <= 1; i += 2)
		{
			for (int j = -1; j <= 1; j += 2)
			{
				Vector3 position = new Vector3(center.x + vector.x * (float)i, center.y, center.z + vector.z * (float)j);
				Vector3 position2 = transform.TransformPoint(position);
				float b = Mathf.Abs(transform2.InverseTransformPoint(position2).x);
				num = Mathf.Max(num, b);
			}
		}
		return num <= trainMaxDistance;
	}

	private bool IsRampOnWagonEdge(GrabbableObject ramp, out float targetY)
	{
		targetY = 0f;
		Transform parent = ramp.transform.parent;
		if (parent == null)
		{
			return false;
		}
		GroundController[] componentsInChildren = parent.GetComponentsInChildren<GroundController>();
		if (componentsInChildren.Length == 0)
		{
			return false;
		}
		Vector3 localPosition = ramp.transform.localPosition;
		List<Vector3> list = new List<Vector3>();
		GroundController[] array = componentsInChildren;
		foreach (GroundController groundController in array)
		{
			if (!(groundController.gameObject == ramp.gameObject))
			{
				list.Add(parent.InverseTransformPoint(groundController.transform.position));
			}
		}
		if (list.Count == 0)
		{
			return false;
		}
		float num = 0.5f;
		float num2 = 0.1f;
		float num3 = float.MinValue;
		float num4 = float.MaxValue;
		bool flag = false;
		foreach (Vector3 item in list)
		{
			if (Mathf.Abs(item.z - localPosition.z) < num)
			{
				flag = true;
				if (item.x > num3)
				{
					num3 = item.x;
				}
				if (item.x < num4)
				{
					num4 = item.x;
				}
			}
		}
		if (flag)
		{
			if (localPosition.x > num3 + num2)
			{
				targetY = 0f;
				return true;
			}
			if (localPosition.x < num4 - num2)
			{
				targetY = 180f;
				return true;
			}
		}
		float num5 = float.MinValue;
		float num6 = float.MaxValue;
		bool flag2 = false;
		foreach (Vector3 item2 in list)
		{
			if (Mathf.Abs(item2.x - localPosition.x) < num)
			{
				flag2 = true;
				if (item2.z > num5)
				{
					num5 = item2.z;
				}
				if (item2.z < num6)
				{
					num6 = item2.z;
				}
			}
		}
		if (flag2 && localPosition.z < num6 - num2)
		{
			targetY = 90f;
			return true;
		}
		return false;
	}

	private void MoveGrabbedObject()
	{
		if (selectedGrabbleObject == null || !selectedGrabbleObject.IsGrabbed)
		{
			return;
		}
		Vector3 pos = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
		Ray ray = rayCamera.ScreenPointToRay(pos);
		if (selectedGrabbleObject.grabbableType == GrabbableType.Prop)
		{
			HandlePropMovement(ray);
		}
		else if (selectedGrabbleObject.grabbableType == GrabbableType.WallProp)
		{
			HandleWallPropMovement(ray);
		}
		else if (selectedGrabbleObject.grabbableType == GrabbableType.Wall || selectedGrabbleObject.grabbableType == GrabbableType.CenterWall)
		{
			HandleWallMovement(ray);
		}
		else if (selectedGrabbleObject.grabbableType == GrabbableType.Ground)
		{
			HandleGroundMovement(ray);
		}
		else if (selectedGrabbleObject.grabbableType == GrabbableType.Roof)
		{
			HandleRoofMovement(ray);
		}
		if (selectedGrabbleObject != null && selectedGrabbleObject.isRamp && selectedGrabbleObject.transform.parent != null)
		{
			if (IsRampOnWagonEdge(selectedGrabbleObject, out var targetY))
			{
				selectedGrabbleObject.transform.localRotation = Quaternion.Euler(0f, targetY, 0f);
				return;
			}
			selectedGrabbleObject.ItCanPlace = false;
			selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false);
			selectedGrabbleObject.SnappedCountWall = 0;
		}
	}

	private void HandleRoofMovement(Ray ray)
	{
		if (Physics.Raycast(ray, out var hitInfo, selectedGrabbleObject.grabDistance, GetPlacementRaycastMask()))
		{
			if (hitInfo.transform.TryGetComponent<GridSnapSystem>(out var component) && hitInfo.transform.gameObject != selectedGrabbleObject.gameObject)
			{
				if (component.connectedSnapSystem != null)
				{
					component = component.connectedSnapSystem;
				}
				List<SnapPointPositionData> compatibleSnapPoints = GetCompatibleSnapPoints(component.snapPoints, selectedGrabbleObject.grabbableType);
				Debug.Log(compatibleSnapPoints.Count);
				if (compatibleSnapPoints.Count == 0)
				{
					selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false, showItem: false);
					UpdateObjectPosition(hitInfo.point);
					return;
				}
				SnapPointPositionData snapPointPositionData = DuubyUtilities.FindClosestSnapData(hitInfo.point, compatibleSnapPoints);
				if (selectedGrabbleObject.SnappedObject == null || selectedGrabbleObject.SnappedObject != snapPointPositionData)
				{
					selectedGrabbleObject.SnappedObject = snapPointPositionData;
					selectedGrabbleObject.SnappedCountWall = 0;
				}
				if (snapPointPositionData.transform == null)
				{
					return;
				}
				selectedGrabbleObject.transform.parent = snapPointPositionData.transform;
				float num = 0f;
				if (selectedGrabbleObject.gridSnapSystem != null && selectedGrabbleObject.gridSnapSystem.snapPoints.Count >= 2)
				{
					SnapPointPositionData snapPointPositionData2 = selectedGrabbleObject.gridSnapSystem.snapPoints.FirstOrDefault((SnapPointPositionData p) => p.rotationType == SnapperRotationType.Left && (p.suitableGrabbableType & selectedGrabbleObject.grabbableType) != 0);
					SnapPointPositionData snapPointPositionData3 = selectedGrabbleObject.gridSnapSystem.snapPoints.FirstOrDefault((SnapPointPositionData p) => p.rotationType == SnapperRotationType.Right && (p.suitableGrabbableType & selectedGrabbleObject.grabbableType) != 0);
					if (snapPointPositionData2 != null && snapPointPositionData3 != null)
					{
						num = Mathf.Abs(snapPointPositionData3.transform.localPosition.x - snapPointPositionData2.transform.localPosition.x) / 2f;
					}
				}
				switch (snapPointPositionData.rotationType)
				{
				case SnapperRotationType.Right:
					selectedGrabbleObject.transform.localPosition = Vector3.right * (num + 0.01f);
					break;
				case SnapperRotationType.Left:
					selectedGrabbleObject.transform.localPosition = Vector3.left * (num + 0.01f);
					break;
				case SnapperRotationType.Forward:
					selectedGrabbleObject.transform.localPosition = Vector3.forward * num;
					break;
				case SnapperRotationType.Backward:
					selectedGrabbleObject.transform.localPosition = Vector3.back * num;
					break;
				default:
					selectedGrabbleObject.transform.localPosition = Vector3.zero;
					break;
				}
				if (rotatedCount % 2 == 0)
				{
					selectedGrabbleObject.transform.localEulerAngles = Vector3.zero;
				}
				else
				{
					selectedGrabbleObject.transform.localEulerAngles = new Vector3(0f, -180f, 0f);
				}
				selectedGrabbleObject.SnappedCountWall++;
				Transform parent = component.transform;
				bool flag = false;
				while (parent != null && !flag)
				{
					WagonController component2 = parent.GetComponent<WagonController>();
					if (component2 != null)
					{
						selectedGrabbleObject.transform.parent = component2.transform;
						flag = true;
					}
					else
					{
						parent = parent.parent;
					}
				}
				if (selectedGrabbleObject.CheckPlaceArea() && IsFullyWithinTrainBounds())
				{
					selectedGrabbleObject.SnappedCountWall++;
					if (selectedGrabbleObject.SnappedCountWall >= 3)
					{
						selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: true);
					}
				}
				else
				{
					selectedGrabbleObject.SnappedCountWall = 0;
					selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false, showItem: false);
				}
			}
			else
			{
				selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false, showItem: false);
				UpdateObjectPosition(hitInfo.point);
			}
		}
		else
		{
			selectedGrabbleObject.SnappedCountWall = 0;
			selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false);
			selectedGrabbleObject.IsPlaceAreaEmpty = false;
			Debug.DrawLine(Camera.main.transform.position, ray.origin + ray.direction * 10f, Color.black);
			UpdateObjectPosition(ray.origin + ray.direction * 10f);
		}
	}

	private void HandlePropMovement(Ray ray)
	{
		if (Physics.Raycast(ray, out var hitInfo, selectedGrabbleObject.grabDistance, GetPlacementRaycastMask()))
		{
			if (hitInfo.collider.isTrigger)
			{
				RaycastHit[] array = Physics.RaycastAll(ray, selectedGrabbleObject.grabDistance, GetPlacementRaycastMask());
				hitInfo = default(RaycastHit);
				bool flag = false;
				RaycastHit[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					RaycastHit raycastHit = array2[i];
					if (!raycastHit.collider.isTrigger)
					{
						hitInfo = raycastHit;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					selectedGrabbleObject.transform.parent = null;
					selectedGrabbleObject.ItCanPlace = false;
					selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false);
					UpdateObjectPosition(ray.origin + ray.direction * 10f);
					return;
				}
			}
			ExtDebug.DrawBox(hitInfo.point, new Vector3(0.5f, 2f, 0.5f), Quaternion.identity, Color.yellow);
			Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
			Physics.SyncTransforms();
			bool flag2 = selectedGrabbleObject.CheckPlaceArea();
			if (flag2 && hitInfo.transform.gameObject.layer == LayerMask.NameToLayer(ConstantStrings.TRAIN_LAYER) && !hitInfo.collider.isTrigger)
			{
				if (hitInfo.collider.GetComponent<GroundController>() == null)
				{
					selectedGrabbleObject.transform.parent = null;
					selectedGrabbleObject.ItCanPlace = false;
					selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false);
					UpdateObjectPosition(hitInfo.point);
					return;
				}
				Transform parent = hitInfo.transform;
				bool flag3 = false;
				while (parent != null && !flag3)
				{
					WagonController component = parent.GetComponent<WagonController>();
					if (component != null)
					{
						selectedGrabbleObject.transform.parent = component.transform;
						flag3 = true;
					}
					else
					{
						parent = parent.parent;
					}
				}
				if (IsWithinTrainDistance())
				{
					selectedGrabbleObject.ItCanPlace = true;
					selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: true);
				}
				else
				{
					selectedGrabbleObject.ItCanPlace = false;
					selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false);
				}
				BoxCollider component2 = hitInfo.collider.GetComponent<BoxCollider>();
				BoxCollider component3 = selectedGrabbleObject.GetComponent<BoxCollider>();
				Vector3 targetPosition = hitInfo.point;
				if (component2 != null && component3 != null)
				{
					float y = component2.bounds.max.y;
					float y2 = component3.bounds.min.y;
					float num = selectedGrabbleObject.transform.position.y - y2;
					targetPosition = new Vector3(hitInfo.point.x, y + num, hitInfo.point.z);
				}
				UpdateObjectPosition(targetPosition);
			}
			else if (!flag2 || hitInfo.collider.isTrigger || !selectedGrabbleObject.isStackable || !(hitInfo.normal.y > 0.5f) || !TryStackOnProp(hitInfo))
			{
				selectedGrabbleObject.transform.parent = null;
				selectedGrabbleObject.ItCanPlace = false;
				selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false);
				UpdateObjectPosition(hitInfo.point);
			}
		}
		else
		{
			selectedGrabbleObject.SnappedCountWall = 0;
			selectedGrabbleObject.ItCanPlace = false;
			selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false);
			selectedGrabbleObject.IsPlaceAreaEmpty = false;
			Debug.DrawLine(Camera.main.transform.position, ray.origin + ray.direction * 10f, Color.black);
			UpdateObjectPosition(ray.origin + ray.direction * 10f);
		}
	}

	private bool TryStackOnProp(RaycastHit hit)
	{
		GrabbableObject componentInParent = hit.collider.GetComponentInParent<GrabbableObject>();
		if (componentInParent == null || componentInParent == selectedGrabbleObject || !componentInParent.isStackable || componentInParent.transform.parent == null)
		{
			return false;
		}
		selectedGrabbleObject.transform.parent = componentInParent.transform.parent;
		if (IsWithinTrainDistance())
		{
			selectedGrabbleObject.ItCanPlace = true;
			selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: true);
		}
		else
		{
			selectedGrabbleObject.ItCanPlace = false;
			selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false);
		}
		BoxCollider component = componentInParent.GetComponent<BoxCollider>();
		BoxCollider component2 = selectedGrabbleObject.GetComponent<BoxCollider>();
		Vector3 targetPosition = componentInParent.transform.position;
		if (component != null && component2 != null)
		{
			float y = component.bounds.max.y;
			float num = selectedGrabbleObject.transform.position.y - component2.bounds.min.y;
			targetPosition = new Vector3(componentInParent.transform.position.x, y + selectedGrabbleObject.stackGap + num, componentInParent.transform.position.z);
		}
		UpdateObjectPosition(targetPosition);
		return true;
	}

	private void HandleWallPropMovement(Ray ray)
	{
		int layerMask = 1 << LayerMask.NameToLayer(ConstantStrings.TRAIN_WALL_LAYER);
		if (Physics.Raycast(ray, out var hitInfo, selectedGrabbleObject.grabDistance, layerMask))
		{
			if (hitInfo.collider.isTrigger)
			{
				RaycastHit[] array = Physics.RaycastAll(ray, selectedGrabbleObject.grabDistance, layerMask);
				hitInfo = default(RaycastHit);
				bool flag = false;
				RaycastHit[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					RaycastHit raycastHit = array2[i];
					if (!raycastHit.collider.isTrigger)
					{
						hitInfo = raycastHit;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					selectedGrabbleObject.transform.parent = null;
					selectedGrabbleObject.ItCanPlace = false;
					selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false);
					UpdateObjectPosition(ray.origin + ray.direction * 10f);
					return;
				}
			}
			Transform parent = hitInfo.transform;
			while (parent != null)
			{
				WagonController component = parent.GetComponent<WagonController>();
				if (component != null)
				{
					selectedGrabbleObject.assignedWagonID = component.wagonID;
					break;
				}
				parent = parent.parent;
			}
			selectedGrabbleObject.transform.rotation = Quaternion.LookRotation(-hitInfo.normal);
			float num = 0f;
			BoxCollider component2 = selectedGrabbleObject.GetComponent<BoxCollider>();
			if (component2 != null)
			{
				num = (component2.center.z + component2.size.z / 2f) * selectedGrabbleObject.transform.lossyScale.z;
			}
			Vector3 targetPosition = hitInfo.point + hitInfo.normal * num;
			selectedGrabbleObject.transform.parent = hitInfo.transform;
			if (selectedGrabbleObject.CheckPlaceArea() && IsWithinTrainDistance())
			{
				selectedGrabbleObject.ItCanPlace = true;
				selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: true);
			}
			else
			{
				selectedGrabbleObject.ItCanPlace = false;
				selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false);
			}
			UpdateObjectPosition(targetPosition);
		}
		else
		{
			selectedGrabbleObject.transform.parent = null;
			selectedGrabbleObject.ItCanPlace = false;
			selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false);
			selectedGrabbleObject.IsPlaceAreaEmpty = false;
			Debug.DrawLine(Camera.main.transform.position, ray.origin + ray.direction * 10f, Color.red);
			UpdateObjectPosition(ray.origin + ray.direction * 10f);
		}
	}

	private void HandleWallMovement(Ray ray)
	{
		if (Physics.Raycast(ray, out var hitInfo, selectedGrabbleObject.grabDistance, GetPlacementRaycastMask()))
		{
			if (hitInfo.transform.TryGetComponent<GridSnapSystem>(out var component) && hitInfo.transform.gameObject != selectedGrabbleObject.gameObject)
			{
				if (component.connectedSnapSystem != null)
				{
					component = component.connectedSnapSystem;
				}
				List<SnapPointPositionData> compatibleSnapPoints = GetCompatibleSnapPoints(component.snapPoints, selectedGrabbleObject.grabbableType);
				if (compatibleSnapPoints.Count == 0)
				{
					selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false, showItem: false);
					UpdateObjectPosition(hitInfo.point);
					return;
				}
				SnapPointPositionData snapPointPositionData = DuubyUtilities.FindClosestSnapData(hitInfo.point, compatibleSnapPoints);
				if (selectedGrabbleObject.SnappedObject == null || selectedGrabbleObject.SnappedObject != snapPointPositionData)
				{
					selectedGrabbleObject.SnappedObject = snapPointPositionData;
					selectedGrabbleObject.SnappedCountWall = 0;
				}
				if (Mathf.Abs(snapPointPositionData.transform.position.y - hitInfo.point.y) > 0.5f)
				{
					selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false, showItem: false);
				}
				else
				{
					if (snapPointPositionData.transform == null)
					{
						return;
					}
					selectedGrabbleObject.transform.parent = snapPointPositionData.transform;
					selectedGrabbleObject.gridSnapSystem.SetSnapPointsType(snapPointPositionData.rotationType);
					selectedGrabbleObject.transform.localPosition = Vector3.zero;
					selectedGrabbleObject.SnappedCountWall++;
					if (component.isVertical)
					{
						selectedGrabbleObject.transform.eulerAngles = component.transform.eulerAngles;
						selectedGrabbleObject.transform.localScale = Vector3.one;
					}
					else
					{
						selectedGrabbleObject.transform.localScale = Vector3.one;
						switch (snapPointPositionData.rotationType)
						{
						case SnapperRotationType.Forward:
						case SnapperRotationType.Backward:
							selectedGrabbleObject.transform.localEulerAngles = new Vector3(0f, 90 + 180 * rotatedCount, 0f);
							break;
						case SnapperRotationType.Right:
						case SnapperRotationType.Left:
							selectedGrabbleObject.transform.localEulerAngles = new Vector3(0f, 180 * rotatedCount, 0f);
							break;
						case SnapperRotationType.Cross:
							selectedGrabbleObject.transform.localScale = new Vector3(Mathf.Sqrt(2f), 1f, 1f);
							selectedGrabbleObject.transform.localEulerAngles = new Vector3(0f, 45 + 90 * rotatedCount, 0f);
							break;
						case SnapperRotationType.Center:
							selectedGrabbleObject.transform.localEulerAngles = new Vector3(0f, 90 * rotatedCount, 0f);
							break;
						}
					}
					Transform parent = component.transform;
					while (parent != null)
					{
						WagonController component2 = parent.GetComponent<WagonController>();
						if (component2 != null)
						{
							selectedGrabbleObject.transform.parent = component2.transform;
							break;
						}
						parent = parent.parent;
					}
					if (selectedGrabbleObject.CheckPlaceArea() && IsWithinTrainDistance())
					{
						selectedGrabbleObject.SnappedCountWall++;
						if (selectedGrabbleObject.SnappedCountWall >= 3)
						{
							selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: true);
						}
					}
					else
					{
						selectedGrabbleObject.SnappedCountWall = 0;
						selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false, showItem: false);
					}
				}
			}
			else
			{
				selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false, showItem: false);
				UpdateObjectPosition(hitInfo.point);
			}
		}
		else
		{
			selectedGrabbleObject.SnappedCountWall = 0;
			selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false);
			selectedGrabbleObject.IsPlaceAreaEmpty = false;
			Debug.DrawLine(Camera.main.transform.position, ray.origin + ray.direction * 10f, Color.black);
			UpdateObjectPosition(ray.origin + ray.direction * 10f);
		}
	}

	private void HandleGroundMovement(Ray ray)
	{
		if (Physics.Raycast(ray, out var hitInfo, selectedGrabbleObject.grabDistance, GetPlacementRaycastMask()))
		{
			if (hitInfo.transform.TryGetComponent<GridSnapSystem>(out var component) && hitInfo.transform.gameObject != selectedGrabbleObject.gameObject)
			{
				if (component.connectedSnapSystem != null)
				{
					component = component.connectedSnapSystem;
				}
				List<SnapPointPositionData> snapPoints = component.snapPoints.Where((SnapPointPositionData x) => x.rotationType != SnapperRotationType.Cross).ToList();
				List<SnapPointPositionData> compatibleSnapPoints = GetCompatibleSnapPoints(snapPoints, selectedGrabbleObject.grabbableType);
				if (compatibleSnapPoints.Count == 0)
				{
					selectedGrabbleObject.transform.parent = null;
					selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false, showItem: false);
					UpdateObjectPosition(hitInfo.point);
					return;
				}
				SnapPointPositionData snapPointPositionData = DuubyUtilities.FindClosestSnapData(hitInfo.point, compatibleSnapPoints);
				Transform parent = component.transform;
				bool flag = false;
				while (parent != null && !flag)
				{
					WagonController component2 = parent.GetComponent<WagonController>();
					if (component2 != null)
					{
						selectedGrabbleObject.transform.parent = component2.transform;
						flag = true;
					}
					else
					{
						parent = parent.parent;
					}
				}
				selectedGrabbleObject.transform.localScale = Vector3.one;
				selectedGrabbleObject.transform.localEulerAngles = Vector3.zero;
				if (selectedGrabbleObject.SnappedObject == null || selectedGrabbleObject.SnappedObject != snapPointPositionData)
				{
					selectedGrabbleObject.SnappedObject = snapPointPositionData;
					selectedGrabbleObject.SnappedCountWall = 0;
				}
				_ = snapPointPositionData.transform.position;
				Vector3 size = selectedGrabbleObject.GetComponent<Collider>().bounds.size;
				switch (snapPointPositionData.rotationType)
				{
				case SnapperRotationType.Forward:
					selectedGrabbleObject.transform.position = snapPointPositionData.transform.position + size.z / 2f * component.transform.forward;
					break;
				case SnapperRotationType.Backward:
					selectedGrabbleObject.transform.position = snapPointPositionData.transform.position - size.z / 2f * component.transform.forward;
					break;
				case SnapperRotationType.Right:
					selectedGrabbleObject.transform.position = snapPointPositionData.transform.position + size.x / 2f * component.transform.right;
					break;
				case SnapperRotationType.Left:
					selectedGrabbleObject.transform.position = snapPointPositionData.transform.position - size.x / 2f * component.transform.right;
					break;
				case SnapperRotationType.Cross:
					selectedGrabbleObject.transform.localScale = new Vector3(Mathf.Sqrt(2f), 1f, 1f);
					break;
				case SnapperRotationType.Center:
					selectedGrabbleObject.transform.position = snapPointPositionData.transform.position;
					break;
				default:
					Debug.Log($"Bilinmeyen rotation type: {snapPointPositionData.rotationType}");
					break;
				}
				bool flag2 = selectedGrabbleObject.CheckPlaceArea();
				bool flag3 = IsWithinTrainDistance();
				Debug.Log(string.Format("[Ground] snapType: {0} | checkPlaceArea: {1} | withinBounds: {2} | localPos: {3} | worldPos: {4} | parent: {5} | snappedCount: {6}", snapPointPositionData.rotationType, flag2, flag3, selectedGrabbleObject.transform.localPosition, selectedGrabbleObject.transform.position, (selectedGrabbleObject.transform.parent != null) ? selectedGrabbleObject.transform.parent.name : "null", selectedGrabbleObject.SnappedCountWall));
				if (flag2 && flag3)
				{
					selectedGrabbleObject.SnappedCountWall++;
					if (selectedGrabbleObject.SnappedCountWall >= 3)
					{
						selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: true);
					}
				}
				else
				{
					selectedGrabbleObject.SnappedCountWall = 0;
					selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false, showItem: false);
				}
			}
			else
			{
				selectedGrabbleObject.transform.parent = null;
				selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false, showItem: false);
				UpdateObjectPosition(hitInfo.point);
			}
		}
		else
		{
			selectedGrabbleObject.SnappedCountWall = 0;
			selectedGrabbleObject.ChangeMaterialAccordingToPlaceable(replaceable: false);
			selectedGrabbleObject.IsPlaceAreaEmpty = false;
			Debug.DrawLine(Camera.main.transform.position, ray.origin + ray.direction * 10f, Color.black);
			UpdateObjectPosition(ray.origin + ray.direction * 10f);
		}
	}

	private void ShowGrabbedObjectInteractionPanel()
	{
		if (selectedGrabbleObject == null || InteractionPanel.Instance == null)
		{
			return;
		}
		List<InteractionData> list = new List<InteractionData>();
		if (selectedGrabbleObject.grabbableType == GrabbableType.Ground || selectedGrabbleObject.grabbableType == GrabbableType.WallProp || selectedGrabbleObject.isRamp)
		{
			list.Add(new InteractionData(KeyCode.Mouse0, "Drop"));
		}
		else
		{
			KeyCode keyCode = KeyCode.R;
			if (Singleton<UserPrefencesManager>.Instance != null && Singleton<UserPrefencesManager>.Instance.keyData != null)
			{
				keyCode = Singleton<UserPrefencesManager>.Instance.keyData.RotateKey;
			}
			list.Add(new InteractionData(keyCode, "Rotate"));
			list.Add(new InteractionData(KeyCode.Mouse0, "Drop"));
		}
		if (InteractionPanel.Instance.IsBottomInfoLocked)
		{
			InteractionPanel.Instance.UnlockAndHideBottomInfo();
		}
		if (InteractionPanel.Instance.ShowBottomInfoInteractionsOverlay(list))
		{
			isShowingGrabbedObjectInteraction = true;
		}
	}

	private void HideGrabbedObjectInteractionPanel()
	{
		if (InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HideInteraction();
		}
		isShowingGrabbedObjectInteraction = false;
	}

	public void StartDismantleMode(GrabbableObject grabbable)
	{
		isDismantleMode = true;
		dismantlingObject = grabbable;
		selectedGrabbleObject = grabbable;
		builderUIManager.OpenBuild(skipBuildModeChangeEvent: true);
		if (mainPlayer != null)
		{
			mainPlayer.ActivateBuildSystem(active: true);
		}
	}

	private void CancelDismantleMode()
	{
		if (isDismantleMode && !(dismantlingObject == null))
		{
			dismantlingObject.CancelDismantle();
			isDismantleMode = false;
			dismantlingObject = null;
			selectedGrabbleObject = null;
			builderUIManager.StopBuild(skipBuildModeChangeEvent: true);
			if (mainPlayer != null)
			{
				mainPlayer.ActivateBuildSystem();
			}
			HideGrabbedObjectInteractionPanel();
		}
	}

	public void OnDismantleObjectDestroyed()
	{
		if (isDismantleMode)
		{
			isDismantleMode = false;
			dismantlingObject = null;
			selectedGrabbleObject = null;
			builderUIManager.StopBuild(skipBuildModeChangeEvent: true);
			HideGrabbedObjectInteractionPanel();
			if (mainPlayer != null)
			{
				mainPlayer.ActivateBuildSystem();
			}
		}
	}
}
