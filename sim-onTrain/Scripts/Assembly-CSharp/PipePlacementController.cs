using System.Collections.Generic;
using UnityEngine;

public class PipePlacementController : MonoBehaviour
{
	[Header("Pipe Prefabs - Sirayla: Standard, Folded, Triple, Quadriple")]
	[SerializeField]
	private GameObject[] pipePrefabs;

	[Header("Settings")]
	[SerializeField]
	private float raycastDistance = 10f;

	[SerializeField]
	private LayerMask raycastMask;

	[SerializeField]
	private Camera rayCamera;

	[SerializeField]
	private float snapDetectionRadius = 0.5f;

	[SerializeField]
	private float freeFollowDistance = 3f;

	private bool isActive;

	private int currentPipeIndex;

	private int currentStep;

	private GameObject previewObject;

	private Pipe previewPipe;

	private bool isSnapped;

	private Transform targetConnectionPoint;

	private Pipe targetPipe;

	private int targetConnectionIndex = -1;

	private PipeConnector targetConnector;

	private CollectableItemData activeBuildItemData;

	private List<Material> previewMats = new List<Material>();

	private Renderer[] previewRenderers;

	private BuildObjectSpawner buildObjectSpawner;

	private PlayerInventory playerInventory;

	public static bool IsPipeModeActive { get; private set; }

	private int ConnectingIndex
	{
		get
		{
			if (previewPipe == null || previewPipe.connectionPoints == null || previewPipe.connectionPoints.Length == 0)
			{
				return 0;
			}
			if (previewPipe.pipeType == PipeType.TriplePipe && previewPipe.connectionPoints.Length >= 3)
			{
				if (currentStep < 4)
				{
					return 0;
				}
				return 2;
			}
			return 0;
		}
	}

	private int RotationStep
	{
		get
		{
			if (previewPipe != null && previewPipe.pipeType == PipeType.TriplePipe)
			{
				if (currentStep < 4)
				{
					return currentStep;
				}
				return currentStep - 4;
			}
			return currentStep % 4;
		}
	}

	private int TotalSteps
	{
		get
		{
			if (previewPipe != null && previewPipe.pipeType == PipeType.TriplePipe && previewPipe.connectionPoints != null && previewPipe.connectionPoints.Length >= 3)
			{
				return 6;
			}
			return 4;
		}
	}

	public bool IsActive => isActive;

	private void Start()
	{
		Singleton<TSNetworkObjetManager>.Instance?.OnServerInitialize.AddListener(OnServerInit);
	}

	private void OnServerInit(TSPlayerController player)
	{
		if (player.isLocalPlayer)
		{
			buildObjectSpawner = player.GetComponent<BuildObjectSpawner>();
			playerInventory = player.GetComponent<PlayerInventory>();
			if (rayCamera == null)
			{
				rayCamera = Camera.main;
			}
		}
	}

	private void Update()
	{
		if (isActive)
		{
			HandlePipeSwitch();
			HandleRotation();
			UpdatePreview();
			HandlePlacement();
			HandleCancel();
		}
	}

	public void ActivateFromBuildUI(CollectableItemData itemData)
	{
		if (isActive)
		{
			Deactivate();
		}
		activeBuildItemData = itemData;
		isActive = true;
		IsPipeModeActive = true;
		currentStep = 0;
		isSnapped = false;
		currentPipeIndex = FindPipeIndex(itemData);
		ClearTarget();
		CreatePreview();
		ActivateBuildSystem(active: true);
	}

	private int FindPipeIndex(CollectableItemData itemData)
	{
		if (itemData == null || itemData.itemPrefab == null || pipePrefabs == null)
		{
			return 0;
		}
		Pipe component = itemData.itemPrefab.GetComponent<Pipe>();
		if (component == null)
		{
			return 0;
		}
		for (int i = 0; i < pipePrefabs.Length; i++)
		{
			if (!(pipePrefabs[i] == null))
			{
				Pipe component2 = pipePrefabs[i].GetComponent<Pipe>();
				if (component2 != null && component2.pipeType == component.pipeType)
				{
					return i;
				}
			}
		}
		return 0;
	}

	public void ActivateFromConnector(PipeConnector connector)
	{
		if (isActive)
		{
			Deactivate();
		}
		isActive = true;
		IsPipeModeActive = true;
		currentPipeIndex = 0;
		currentStep = 0;
		SetTargetConnector(connector);
		CreatePreview();
		SnapPreviewToTarget();
	}

	public void ActivateFromPipe(Pipe pipe, int openConnectionIndex)
	{
		if (isActive)
		{
			Deactivate();
		}
		isActive = true;
		IsPipeModeActive = true;
		currentPipeIndex = 0;
		currentStep = 0;
		SetTargetPipe(pipe, openConnectionIndex);
		CreatePreview();
		SnapPreviewToTarget();
	}

	public void Deactivate()
	{
		isActive = false;
		IsPipeModeActive = false;
		activeBuildItemData = null;
		DestroyPreview();
		ClearTarget();
		ActivateBuildSystem(active: false);
	}

	private void ActivateBuildSystem(bool active)
	{
		if (TrainGameManager.Instance == null || TrainGameManager.Instance.mainPlayer == null)
		{
			return;
		}
		TSPlayerController component = TrainGameManager.Instance.mainPlayer.GetComponent<TSPlayerController>();
		if (component != null)
		{
			component.ActivateBuildSystem(active);
		}
		if (active)
		{
			Grabber component2 = TrainGameManager.Instance.mainPlayer.GetComponent<Grabber>();
			if (component2 != null)
			{
				component2.isBuildMenuPlacement = false;
			}
		}
		ObjectBuilderUIManager objectBuilderUIManager = Object.FindObjectOfType<ObjectBuilderUIManager>();
		if (objectBuilderUIManager != null)
		{
			if (active)
			{
				objectBuilderUIManager.OpenBuild();
			}
			else
			{
				objectBuilderUIManager.StopBuild();
			}
		}
	}

	private void ClearTarget()
	{
		targetConnectionPoint = null;
		targetPipe = null;
		targetConnector = null;
		targetConnectionIndex = -1;
		isSnapped = false;
	}

	private void SetTargetConnector(PipeConnector connector)
	{
		ClearTarget();
		targetConnector = connector;
		targetConnectionPoint = connector.connectionPoint;
		isSnapped = true;
	}

	private void SetTargetPipe(Pipe pipe, int connectionIndex)
	{
		ClearTarget();
		targetPipe = pipe;
		targetConnectionIndex = connectionIndex;
		targetConnectionPoint = pipe.connectionPoints[connectionIndex];
		isSnapped = true;
	}

	private void CreatePreview()
	{
		DestroyPreview();
		if (pipePrefabs != null && pipePrefabs.Length != 0 && !(pipePrefabs[currentPipeIndex] == null))
		{
			previewObject = Object.Instantiate(pipePrefabs[currentPipeIndex]);
			previewPipe = previewObject.GetComponent<Pipe>();
			Collider[] componentsInChildren = previewObject.GetComponentsInChildren<Collider>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].isTrigger = true;
			}
			SetupPreviewMaterials();
			SetLayerRecursive(previewObject, LayerMask.NameToLayer("Ignore Raycast"));
		}
	}

	private void DestroyPreview()
	{
		if (previewObject != null)
		{
			Object.Destroy(previewObject);
			previewObject = null;
			previewPipe = null;
		}
		previewMats.Clear();
		previewRenderers = null;
	}

	private void SetupPreviewMaterials()
	{
		previewMats.Clear();
		previewRenderers = previewObject.GetComponentsInChildren<Renderer>();
		Renderer[] array = previewRenderers;
		foreach (Renderer renderer in array)
		{
			Material[] array2 = new Material[renderer.materials.Length];
			for (int j = 0; j < renderer.materials.Length; j++)
			{
				Material material = new Material(renderer.materials[j]);
				SetMaterialTransparent(material);
				previewMats.Add(material);
				array2[j] = material;
			}
			renderer.materials = array2;
		}
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

	private void SetPreviewColor(bool valid)
	{
		Color color = new Color(0f, 1f, 0f, 0.5f);
		Color color2 = new Color(1f, 0f, 0f, 0.5f);
		float num = 1.5f;
		if (Singleton<GameSettings>.Instance != null)
		{
			color = Singleton<GameSettings>.Instance.placeableColor;
			color2 = Singleton<GameSettings>.Instance.unplaceableColor;
			num = Singleton<GameSettings>.Instance.grabEmissionIntensity;
		}
		Color color3 = (valid ? color : color2);
		Color value = color3 * num;
		foreach (Material previewMat in previewMats)
		{
			previewMat.SetColor("_BaseColor", color3);
			previewMat.EnableKeyword("_EMISSION");
			previewMat.SetColor("_EmissionColor", value);
			previewMat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
		}
	}

	private void SetLayerRecursive(GameObject obj, int layer)
	{
		obj.layer = layer;
		foreach (Transform item in obj.transform)
		{
			SetLayerRecursive(item.gameObject, layer);
		}
	}

	private void HandlePipeSwitch()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			currentPipeIndex = (currentPipeIndex + 1) % pipePrefabs.Length;
			currentStep = 0;
			CreatePreview();
			if (isSnapped && targetConnectionPoint != null)
			{
				SnapPreviewToTarget();
			}
		}
	}

	private void HandleRotation()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			currentStep = (currentStep + 1) % TotalSteps;
			if (isSnapped && targetConnectionPoint != null)
			{
				SnapPreviewToTarget();
			}
		}
	}

	private void UpdatePreview()
	{
		if (previewObject == null)
		{
			return;
		}
		if (rayCamera == null)
		{
			rayCamera = Camera.main;
		}
		if (!(rayCamera == null))
		{
			Vector3 pos = new Vector3((float)Screen.width / 2f, (float)Screen.height / 2f, 0f);
			Ray ray = rayCamera.ScreenPointToRay(pos);
			SearchForTarget(ray);
			if (isSnapped && targetConnectionPoint != null)
			{
				SnapPreviewToTarget();
				SetPreviewColor(CanPlace());
			}
			else
			{
				FollowRay(ray);
				SetPreviewColor(valid: false);
			}
		}
	}

	private void SearchForTarget(Ray ray)
	{
		if (!Physics.Raycast(ray, out var hitInfo, raycastDistance, raycastMask))
		{
			ClearTarget();
			return;
		}
		PipeConnector pipeConnector = hitInfo.collider.GetComponent<PipeConnector>();
		if (pipeConnector == null)
		{
			pipeConnector = hitInfo.collider.GetComponentInParent<PipeConnector>();
		}
		if (pipeConnector != null && !pipeConnector.isOccupied && pipeConnector.connectionPoint != null)
		{
			if (!(targetConnector == pipeConnector))
			{
				SetTargetConnector(pipeConnector);
				currentStep = 0;
			}
			return;
		}
		Pipe pipe = hitInfo.collider.GetComponent<Pipe>();
		if (pipe == null)
		{
			pipe = hitInfo.collider.GetComponentInParent<Pipe>();
		}
		if (pipe != null && pipe.connectionPoints != null)
		{
			int closestOpenConnectionIndex = pipe.GetClosestOpenConnectionIndex(hitInfo.point);
			if (closestOpenConnectionIndex >= 0)
			{
				if (!(targetPipe == pipe) || targetConnectionIndex != closestOpenConnectionIndex)
				{
					SetTargetPipe(pipe, closestOpenConnectionIndex);
					currentStep = 0;
				}
				return;
			}
		}
		ClearTarget();
	}

	private void FollowRay(Ray ray)
	{
		if (!(previewObject == null))
		{
			RaycastHit hitInfo;
			Vector3 b = ((!Physics.Raycast(ray, out hitInfo, raycastDistance, raycastMask)) ? (ray.origin + ray.direction * freeFollowDistance) : hitInfo.point);
			previewObject.transform.position = Vector3.Lerp(previewObject.transform.position, b, 15f * Time.deltaTime);
			previewObject.transform.rotation = Quaternion.Euler(0f, (float)RotationStep * 90f, 0f);
		}
	}

	private void SnapPreviewToTarget()
	{
		if (previewObject == null || previewPipe == null || targetConnectionPoint == null || previewPipe.connectionPoints == null || previewPipe.connectionPoints.Length == 0)
		{
			return;
		}
		int num = ConnectingIndex;
		if (num >= previewPipe.connectionPoints.Length)
		{
			num = 0;
		}
		Transform transform = previewPipe.connectionPoints[num];
		if (!(transform == null))
		{
			Vector3 forward = targetConnectionPoint.forward;
			Vector3 up = targetConnectionPoint.up;
			Quaternion quaternion = Quaternion.LookRotation(-forward, up);
			Quaternion rotation = Quaternion.Inverse(previewObject.transform.rotation) * transform.rotation;
			Quaternion rotation2 = quaternion * Quaternion.Inverse(rotation);
			previewObject.transform.rotation = rotation2;
			int rotationStep = RotationStep;
			if (rotationStep > 0)
			{
				Quaternion quaternion2 = Quaternion.AngleAxis((float)rotationStep * 90f, -forward);
				previewObject.transform.rotation = quaternion2 * previewObject.transform.rotation;
			}
			Vector3 vector = previewObject.transform.position - transform.position;
			previewObject.transform.position = targetConnectionPoint.position + vector;
		}
	}

	private void HandlePlacement()
	{
		if (Input.GetMouseButtonDown(0) && !(previewObject == null) && CanPlace())
		{
			PlacePipe();
		}
	}

	private bool CanPlace()
	{
		if (previewObject == null || !isSnapped || targetConnectionPoint == null)
		{
			return false;
		}
		if (targetConnector != null && targetConnector.isOccupied)
		{
			return false;
		}
		if (targetPipe != null && targetConnectionIndex >= 0 && targetPipe.IsOccupied(targetConnectionIndex))
		{
			return false;
		}
		if (!CheckPlaceAreaClear())
		{
			return false;
		}
		return true;
	}

	private bool CheckPlaceAreaClear()
	{
		if (previewObject == null)
		{
			return true;
		}
		BoxCollider[] componentsInChildren = previewObject.GetComponentsInChildren<BoxCollider>();
		if (componentsInChildren.Length == 0)
		{
			return true;
		}
		int num = LayerMask.NameToLayer("Ignore Raycast");
		int num2 = LayerMask.NameToLayer(ConstantStrings.GRABBED_OBJECT_LAYER);
		BoxCollider[] array = componentsInChildren;
		foreach (BoxCollider boxCollider in array)
		{
			Vector3 center = boxCollider.transform.TransformPoint(boxCollider.center);
			Vector3 halfExtents = new Vector3(boxCollider.size.x * boxCollider.transform.lossyScale.x / 4f, boxCollider.size.y * boxCollider.transform.lossyScale.y / 5f, boxCollider.size.z * boxCollider.transform.lossyScale.z / 4f);
			Collider[] array2 = Physics.OverlapBox(center, halfExtents, boxCollider.transform.rotation);
			foreach (Collider collider in array2)
			{
				if (!collider.transform.IsChildOf(previewObject.transform) && collider.gameObject.layer != num && collider.gameObject.layer != num2 && !collider.isTrigger && (!(targetPipe != null) || !collider.transform.IsChildOf(targetPipe.transform)) && (!(targetConnector != null) || !collider.transform.IsChildOf(targetConnector.transform)))
				{
					GrabbableObject componentInParent = collider.GetComponentInParent<GrabbableObject>();
					Pipe componentInParent2 = collider.GetComponentInParent<Pipe>();
					if (componentInParent != null || componentInParent2 != null)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	private void PlacePipe()
	{
		if (targetConnector != null)
		{
			targetConnector.isOccupied = true;
		}
		if (targetPipe != null && targetConnectionIndex >= 0)
		{
			targetPipe.OccupyConnection(targetConnectionIndex);
		}
		if (previewPipe != null)
		{
			previewPipe.OccupyConnection(ConnectingIndex);
		}
		int targetWagonID = FindWagonID(previewObject.transform.position);
		if (buildObjectSpawner != null)
		{
			PropBase component = pipePrefabs[currentPipeIndex].GetComponent<PropBase>();
			string text = ((component != null && component.data != null) ? component.data.itemName : "");
			if (!string.IsNullOrEmpty(text))
			{
				buildObjectSpawner.SpawnObjectOnServer(previewObject.transform.position, previewObject.transform.rotation, text, targetWagonID);
			}
		}
		Vector3 position = previewObject.transform.position;
		Quaternion rotation = previewObject.transform.rotation;
		int pipeIndex = currentPipeIndex;
		int connectingIndex = ConnectingIndex;
		DestroyPreview();
		ContinuePlacement(position, rotation, pipeIndex, connectingIndex);
	}

	private void ContinuePlacement(Vector3 placedPos, Quaternion placedRot, int pipeIndex, int usedConnectionIndex)
	{
		GameObject gameObject = Object.Instantiate(pipePrefabs[pipeIndex]);
		gameObject.transform.position = placedPos;
		gameObject.transform.rotation = placedRot;
		Pipe component = gameObject.GetComponent<Pipe>();
		if (component == null || component.connectionPoints == null)
		{
			Object.Destroy(gameObject);
			CreatePreview();
			return;
		}
		for (int i = 0; i < component.connectionPoints.Length; i++)
		{
			if (i == usedConnectionIndex || component.connectionPoints[i] == null)
			{
				continue;
			}
			Collider[] array = Physics.OverlapSphere(placedPos, snapDetectionRadius);
			for (int j = 0; j < array.Length; j++)
			{
				Pipe componentInParent = array[j].GetComponentInParent<Pipe>();
				if (componentInParent != null && componentInParent.gameObject != gameObject)
				{
					int closestOpenConnectionIndex = componentInParent.GetClosestOpenConnectionIndex(component.connectionPoints[i].position);
					if (closestOpenConnectionIndex >= 0)
					{
						Object.Destroy(gameObject);
						SetTargetPipe(componentInParent, closestOpenConnectionIndex);
						currentStep = 0;
						CreatePreview();
						SnapPreviewToTarget();
						return;
					}
				}
			}
			break;
		}
		Object.Destroy(gameObject);
		ClearTarget();
		CreatePreview();
	}

	private int FindWagonID(Vector3 worldPos)
	{
		if (Physics.Raycast(worldPos, Vector3.down, out var hitInfo, 50f))
		{
			Transform parent = hitInfo.transform;
			while (parent != null)
			{
				WagonController component = parent.GetComponent<WagonController>();
				if (component != null)
				{
					return component.wagonID;
				}
				parent = parent.parent;
			}
		}
		return 0;
	}

	private void HandleCancel()
	{
		KeyCode key = KeyCode.Escape;
		if (Singleton<UserPrefencesManager>.Instance != null)
		{
			key = Singleton<UserPrefencesManager>.Instance.keyData.ExitKey;
		}
		if (Input.GetKeyDown(key))
		{
			Deactivate();
		}
	}
}
