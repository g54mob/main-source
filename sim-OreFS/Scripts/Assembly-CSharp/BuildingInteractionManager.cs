using Enviro;
using I2.Loc;
using Mirror;
using UnityEngine;

[AddComponentMenu("Interaction/Building Interaction Manager")]
public class BuildingInteractionManager : MonoBehaviour
{
	private const bool ENABLE_DEBUG_LOGS = true;

	[Header("Input")]
	public bool InputActive;

	[Header("Ray Settings")]
	public Camera rayCamera;

	public Transform interactor;

	public float maxDistance = 10f;

	[Tooltip("Oyuncunun bina yerleştirebileceği maksimum mesafe. Bu mesafeden uzaktaki preview geçersiz olur.")]
	public float maxPlaceDistance = 5f;

	public LayerMask surfaceLayer;

	[Tooltip("Socket layer - Inspector'da seçin. SocketOnly building'ler için kullanılır")]
	public LayerMask socketLayer;

	[Tooltip("Raycast için kullanılacak layer mask - Sadece Surface, Terrain ve Socket layer'ları kontrol edilir")]
	public LayerMask raycastLayerMask;

	[Tooltip("Terrain layer - Inspector'da seçin. Surface üzerine yerleştirme yaparken terrain ile çarpışmayı ignore etmek için kullanılır")]
	public LayerMask terrainLayer;

	public QueryTriggerInteraction triggerQuery = QueryTriggerInteraction.Ignore;

	[Header("Positioning")]
	public bool useGridSnap = true;

	public float gridSize = 0.5f;

	public bool alignToSurfaceNormal = true;

	public float rotationStep = 90f;

	[Header("Socket Settings")]
	[Tooltip("Socket arama yarıçapı - Raycast hit point'e bu mesafe içinde socket aranır (metre)")]
	public float socketSearchRadius = 2f;

	[Tooltip("Socket cache geçerliliği için tolerans mesafesi (metre)")]
	public float socketCacheTolerance = 0.5f;

	[Tooltip("RestoreChildSockets'da socket pozisyonunda building ararken kullanılan yarıçap (metre)")]
	public float restoreChildSocketsRadius = 0.5f;

	[Header("Audio")]
	public AudioSource audioSource;

	public AudioClip placeBuildingClip;

	[Header("References")]
	public BuildingObject currentBuildingObject;

	private float currentRotation;

	private GameManager gameManager;

	private T_Socket currentSocket;

	private T_Socket reservedSocket;

	private GameObject currentBuildingPrefab;

	private BuildingModeSource currentBuildingSource;

	private T_BuildingItemSO currentBuildingSO;

	private LayerMask effectiveRaycastLayerMask;

	private RaycastHit lastRaycastHit;

	private bool lastRaycastValid;

	private Vector3 cachedSocketPosition;

	private float cachedSocketDistance;

	private T_Socket cachedSocket;

	private bool socketCacheValid;

	public static BuildingInteractionManager Instance { get; private set; }

	private uint RelocatingNetId
	{
		get
		{
			if (currentBuildingObject != null && currentBuildingObject.GetBuildingModeSource() == BuildingModeSource.Relocate)
			{
				NetworkIdentity component = currentBuildingObject.GetComponent<NetworkIdentity>();
				if (component != null)
				{
					return component.netId;
				}
			}
			return 0u;
		}
	}

	private uint CurrentBuildingNetId
	{
		get
		{
			if (!(currentBuildingObject != null))
			{
				return 0u;
			}
			return currentBuildingObject.netId;
		}
	}

	public BuildingModeSource CurrentBuildingSource => currentBuildingSource;

	public T_BuildingItemSO CurrentBuildingSO => currentBuildingSO;

	private void Awake()
	{
		Instance = this;
		gameManager = GameManager.Instance;
		effectiveRaycastLayerMask = raycastLayerMask;
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

	public void SetBuildingObject(BuildingObject buildingObject, GameObject buildingPrefab = null, T_BuildingItemSO buildingSO = null, BuildingModeSource source = BuildingModeSource.BuildingBox)
	{
		Debug.Log(string.Format("[BuildingInteractionManager] SetBuildingObject() çağrıldı. buildingObject: {0}, source: {1}", (buildingObject != null) ? buildingObject.name : "null", source));
		if (buildingObject != null)
		{
			buildingObject.socketLayer = socketLayer;
		}
		if (currentBuildingObject != null && currentBuildingObject != buildingObject)
		{
			UpdateSocketReservation(null);
			currentBuildingObject.CancelBuilding();
		}
		currentBuildingObject = buildingObject;
		currentBuildingPrefab = buildingPrefab;
		currentBuildingSO = buildingSO;
		currentBuildingSource = source;
		currentSocket = null;
		reservedSocket = null;
		socketCacheValid = false;
		cachedSocket = null;
		lastRaycastValid = false;
		effectiveRaycastLayerMask = raycastLayerMask;
		if (buildingSO != null && buildingSO.additionalPlacementLayers.value != 0)
		{
			effectiveRaycastLayerMask = (int)effectiveRaycastLayerMask | (int)buildingSO.additionalPlacementLayers;
		}
		if (currentBuildingObject != null)
		{
			Debug.Log("[BuildingInteractionManager] Preview mode aktif ediliyor...");
			currentBuildingObject.EnablePreviewMode();
			currentRotation = 0f;
		}
		else
		{
			Debug.LogWarning("[BuildingInteractionManager] SetBuildingObject: buildingObject null!");
		}
	}

	public void ClearBuildingObject()
	{
		UpdateSocketReservation(null);
		if (currentBuildingObject != null)
		{
			currentBuildingObject.CancelBuilding();
			currentBuildingObject = null;
		}
		currentBuildingPrefab = null;
		currentBuildingSO = null;
		currentBuildingSource = BuildingModeSource.None;
		currentSocket = null;
		socketCacheValid = false;
		effectiveRaycastLayerMask = raycastLayerMask;
	}

	private void Update()
	{
		if (InputActive && !(currentBuildingObject == null) && currentBuildingObject.isOwned)
		{
			if (!rayCamera)
			{
				rayCamera = Camera.main;
			}
			if (!interactor)
			{
				interactor = (rayCamera ? rayCamera.transform : base.transform);
			}
			if (CheckRaycastChanged())
			{
				UpdatePreviewPosition();
			}
		}
	}

	private bool CheckRaycastChanged()
	{
		Vector3 origin = (rayCamera ? rayCamera.transform.position : base.transform.position);
		Vector3 direction = (rayCamera ? rayCamera.transform.forward : base.transform.forward);
		RaycastHit hitInfo;
		bool flag = Physics.Raycast(origin, direction, out hitInfo, maxDistance, effectiveRaycastLayerMask, triggerQuery);
		if (flag != lastRaycastValid)
		{
			lastRaycastHit = hitInfo;
			lastRaycastValid = flag;
			return true;
		}
		if (flag && lastRaycastValid)
		{
			float num = 0.1f;
			bool num2 = Vector3.Distance(hitInfo.point, lastRaycastHit.point) > num;
			bool flag2 = hitInfo.collider != lastRaycastHit.collider;
			if (num2 || flag2)
			{
				lastRaycastHit = hitInfo;
				return true;
			}
		}
		return false;
	}

	private void UpdatePreviewPosition()
	{
		if (currentBuildingObject == null)
		{
			return;
		}
		if (!rayCamera)
		{
			_ = base.transform.position;
		}
		else
		{
			_ = rayCamera.transform.position;
		}
		if (!rayCamera)
		{
			_ = base.transform.forward;
		}
		else
		{
			_ = rayCamera.transform.forward;
		}
		RaycastHit raycastHit = lastRaycastHit;
		if (!lastRaycastValid)
		{
			currentBuildingObject.UpdatePreviewValidity(isValid: false);
			currentSocket = null;
			socketCacheValid = false;
			return;
		}
		currentBuildingObject.ResetIgnoreLayers();
		int layer = raycastHit.collider.gameObject.layer;
		LayerMask layerMask = surfaceLayer;
		if (currentBuildingSO != null && currentBuildingSO.additionalPlacementLayers.value != 0)
		{
			layerMask = (int)layerMask | (int)currentBuildingSO.additionalPlacementLayers;
		}
		bool flag = (layerMask.value & (1 << layer)) != 0;
		bool flag2 = (socketLayer.value & (1 << layer)) != 0;
		Vector3 vector = raycastHit.point;
		Quaternion rotation = Quaternion.identity;
		bool flag3 = false;
		bool flag4 = currentBuildingObject.hybridMode && !currentBuildingObject.socketOnly;
		bool flag5 = false;
		if (flag4 && currentBuildingPrefab != null)
		{
			T_Socket t_Socket = null;
			if (socketCacheValid && cachedSocket != null && cachedSocket.CanPlaceBuilding(currentBuildingPrefab, RelocatingNetId, CurrentBuildingNetId))
			{
				float num = Vector3.Distance(raycastHit.point, cachedSocketPosition);
				if (num <= socketCacheTolerance)
				{
					if (cachedSocket.GetSocketPosition(currentBuildingPrefab, out var _, out var _))
					{
						t_Socket = cachedSocket;
						Debug.Log($"[BuildingInteractionManager] UpdatePreviewPosition (HYBRID): Cache'den socket kullanılıyor - Socket: {t_Socket.gameObject.name}, Distance: {num}");
					}
					else
					{
						socketCacheValid = false;
					}
				}
				else
				{
					socketCacheValid = false;
				}
			}
			if (t_Socket == null)
			{
				t_Socket = FindNearestSocketCached(raycastHit.point, currentBuildingPrefab);
			}
			if (t_Socket != null)
			{
				Debug.Log("[BuildingInteractionManager] UpdatePreviewPosition (HYBRID): Socket bulundu - Socket: " + t_Socket.gameObject.name + ", BuildingPrefab: " + currentBuildingPrefab.name);
				t_Socket.LogSocketState("UpdatePreviewPosition - Hybrid Socket found");
				if (t_Socket.GetSocketPosition(currentBuildingPrefab, out var position2, out var rotation3))
				{
					vector = position2;
					rotation = rotation3;
					Debug.Log($"[BuildingInteractionManager] UpdatePreviewPosition (HYBRID): Socket pozisyonu alındı - Socket: {t_Socket.gameObject.name}, Position: {position2}");
					if (currentBuildingObject.canRotate)
					{
						Quaternion quaternion = Quaternion.Euler(0f, currentRotation, 0f);
						rotation = rotation3 * quaternion;
					}
					currentBuildingObject.transform.position = vector;
					currentBuildingObject.transform.rotation = rotation;
					BuildingObject componentInParent = t_Socket.GetComponentInParent<BuildingObject>();
					if (socketLayer.value != 0)
					{
						BuildingObject buildingObject = currentBuildingObject;
						buildingObject.ignoreLayers = (int)buildingObject.ignoreLayers | (int)socketLayer;
						Debug.Log($"[BuildingInteractionManager] UpdatePreviewPosition (HYBRID): Socket layer ignore edildi - Layer: {socketLayer.value}, IgnoreLayers: {currentBuildingObject.ignoreLayers.value}");
					}
					if (Vector3.Distance(currentBuildingObject.transform.position, vector) > 0.01f)
					{
						Physics.SyncTransforms();
					}
					bool flag6 = currentBuildingObject.CheckCollision(t_Socket, componentInParent);
					Debug.Log($"[BuildingInteractionManager] UpdatePreviewPosition (HYBRID): Çarpışma kontrolü - HasCollision: {flag6}, Position: {currentBuildingObject.transform.position}, IgnoreLayers: {currentBuildingObject.ignoreLayers.value}");
					flag3 = !flag6;
					Debug.Log($"[BuildingInteractionManager] UpdatePreviewPosition (HYBRID): isValid set edildi - isValid: {flag3}, hasCollision: {flag6}");
					currentSocket = t_Socket;
					flag5 = true;
				}
				else
				{
					flag3 = false;
					currentSocket = null;
					socketCacheValid = false;
					flag5 = false;
				}
			}
			else if (TutorialManager.Instance != null && TutorialManager.Instance.GetActiveConfig() == TutorialConfigType.Production && TutorialManager.Instance.CurrentStep == TutorialStepType.PlacePallet)
			{
				Debug.Log("[BuildingInteractionManager] UpdatePreviewPosition (HYBRID): Tutorial esnasında socket bulunamadı - preview geçersiz ama gezdirilmeye devam edecek");
				currentSocket = null;
				socketCacheValid = false;
				flag5 = false;
			}
			else
			{
				Debug.Log($"[BuildingInteractionManager] UpdatePreviewPosition (HYBRID): Socket bulunamadı - HitPoint: {raycastHit.point}, SearchRadius: {socketSearchRadius}, Normal yerleştirmeye geçiliyor...");
				currentSocket = null;
				socketCacheValid = false;
				flag5 = false;
			}
		}
		if (!currentBuildingObject.socketOnly && (!flag4 || !flag5))
		{
			if (flag2)
			{
				flag3 = false;
				currentSocket = null;
			}
			else if (flag)
			{
				if (useGridSnap)
				{
					vector.x = Mathf.Round(vector.x / gridSize) * gridSize;
					vector.y = Mathf.Round(vector.y / gridSize) * gridSize;
					vector.z = Mathf.Round(vector.z / gridSize) * gridSize;
				}
				if (alignToSurfaceNormal)
				{
					Quaternion quaternion2 = Quaternion.Euler(0f, currentRotation, 0f);
					rotation = Quaternion.FromToRotation(Vector3.up, raycastHit.normal) * quaternion2;
				}
				else
				{
					rotation = Quaternion.Euler(0f, currentRotation, 0f);
				}
				LayerMask layerMask2 = surfaceLayer;
				if (terrainLayer.value != 0)
				{
					layerMask2 = (int)layerMask2 | (int)terrainLayer;
				}
				if (currentBuildingSO != null && currentBuildingSO.additionalPlacementLayers.value != 0)
				{
					layerMask2 = (int)layerMask2 | (int)currentBuildingSO.additionalPlacementLayers;
				}
				BuildingObject buildingObject2 = currentBuildingObject;
				buildingObject2.ignoreLayers = (int)buildingObject2.ignoreLayers | (int)layerMask2;
				flag3 = !currentBuildingObject.CheckCollision();
				currentSocket = null;
			}
			else
			{
				flag3 = false;
				currentSocket = null;
			}
		}
		else if (currentBuildingObject.socketOnly && currentBuildingPrefab != null)
		{
			T_Socket t_Socket2 = null;
			if (socketCacheValid && cachedSocket != null && cachedSocket.CanPlaceBuilding(currentBuildingPrefab, RelocatingNetId, CurrentBuildingNetId))
			{
				if (Vector3.Distance(raycastHit.point, cachedSocketPosition) <= socketCacheTolerance)
				{
					t_Socket2 = cachedSocket;
					Debug.Log("[BuildingInteractionManager] UpdatePreviewPosition (SOCKETONLY): Cache'den socket kullanılıyor - Socket: " + t_Socket2.gameObject.name);
				}
				else
				{
					socketCacheValid = false;
				}
			}
			if (t_Socket2 == null)
			{
				t_Socket2 = FindNearestSocketCached(raycastHit.point, currentBuildingPrefab);
			}
			if (t_Socket2 != null)
			{
				Debug.Log("[BuildingInteractionManager] UpdatePreviewPosition (CLIENT): Socket bulundu - Socket: " + t_Socket2.gameObject.name + ", BuildingPrefab: " + currentBuildingPrefab.name);
				t_Socket2.LogSocketState("UpdatePreviewPosition - Socket found");
				if (t_Socket2.GetSocketPosition(currentBuildingPrefab, out var position3, out var rotation4))
				{
					vector = position3;
					rotation = rotation4;
					Debug.Log($"[BuildingInteractionManager] UpdatePreviewPosition (CLIENT): Socket pozisyonu alındı - Socket: {t_Socket2.gameObject.name}, Position: {position3}");
					if (currentBuildingObject.canRotate)
					{
						Quaternion quaternion3 = Quaternion.Euler(0f, currentRotation, 0f);
						rotation = rotation4 * quaternion3;
					}
					BuildingObject componentInParent2 = t_Socket2.GetComponentInParent<BuildingObject>();
					if (socketLayer.value != 0)
					{
						BuildingObject buildingObject3 = currentBuildingObject;
						buildingObject3.ignoreLayers = (int)buildingObject3.ignoreLayers | (int)socketLayer;
					}
					flag3 = !currentBuildingObject.CheckCollision(t_Socket2, componentInParent2);
					currentSocket = t_Socket2;
				}
				else
				{
					flag3 = false;
					currentSocket = null;
					socketCacheValid = false;
				}
			}
			else
			{
				flag3 = false;
				currentSocket = null;
				socketCacheValid = false;
			}
		}
		else if (!(flag4 && flag5))
		{
			flag3 = false;
			currentSocket = null;
		}
		bool flag7 = true;
		if (!currentBuildingObject.socketOnly && !flag4 && flag2)
		{
			flag7 = false;
		}
		if (flag4 && flag5)
		{
			flag7 = false;
		}
		if (flag7)
		{
			currentBuildingObject.transform.position = vector;
			currentBuildingObject.transform.rotation = rotation;
		}
		if (flag3 && interactor != null && Vector3.Distance(interactor.position, raycastHit.point) > maxPlaceDistance)
		{
			flag3 = false;
		}
		Debug.Log($"[BuildingInteractionManager] UpdatePreviewPosition: UpdatePreviewValidity çağrılıyor - isValid: {flag3}, socketFoundInHybridMode: {flag5}, isHybridMode: {flag4}");
		currentBuildingObject.UpdatePreviewValidity(flag3);
		UpdateSocketReservation(currentSocket);
	}

	public bool TryGetInitialSpawnTransform(GameObject buildingPrefab, out Vector3 position, out Quaternion rotation)
	{
		position = base.transform.position;
		rotation = Quaternion.identity;
		if (!rayCamera)
		{
			rayCamera = Camera.main;
		}
		Vector3 vector = (rayCamera ? rayCamera.transform.position : base.transform.position);
		Vector3 vector2 = (rayCamera ? rayCamera.transform.forward : base.transform.forward);
		if (!Physics.Raycast(vector, vector2, out var hitInfo, maxDistance, raycastLayerMask, triggerQuery))
		{
			position = vector + vector2 * Mathf.Min(2f, maxDistance);
			rotation = Quaternion.identity;
			return false;
		}
		BuildingObject buildingObject = ((buildingPrefab != null) ? buildingPrefab.GetComponent<BuildingObject>() : null);
		bool flag = buildingObject != null && buildingObject.socketOnly;
		bool flag2 = buildingObject != null && buildingObject.hybridMode && !flag;
		bool flag3 = buildingObject == null || buildingObject.canRotate;
		if (buildingPrefab != null && (flag || flag2))
		{
			T_Socket t_Socket = FindNearestSocketCached(hitInfo.point, buildingPrefab);
			if (t_Socket != null && t_Socket.GetSocketPosition(buildingPrefab, out var position2, out var rotation2))
			{
				position = position2;
				rotation = rotation2;
				if (flag3)
				{
					rotation = rotation2 * Quaternion.Euler(0f, 0f, 0f);
				}
				return true;
			}
		}
		position = hitInfo.point;
		if (useGridSnap)
		{
			position.x = Mathf.Round(position.x / gridSize) * gridSize;
			position.y = Mathf.Round(position.y / gridSize) * gridSize;
			position.z = Mathf.Round(position.z / gridSize) * gridSize;
		}
		if (alignToSurfaceNormal)
		{
			Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
			rotation = quaternion * Quaternion.Euler(0f, 0f, 0f);
		}
		else
		{
			rotation = Quaternion.Euler(0f, 0f, 0f);
		}
		return true;
	}

	public void RotateBuilding(float direction)
	{
		if (!(currentBuildingObject == null))
		{
			if (!currentBuildingObject.canRotate)
			{
				Debug.Log($"[BuildingInteractionManager] RotateBuilding: Building rotate edilemez - canRotate: {currentBuildingObject.canRotate}");
				return;
			}
			currentRotation += direction * rotationStep;
			currentRotation %= 360f;
			lastRaycastValid = false;
			UpdatePreviewPosition();
		}
	}

	public void PlaceBuilding()
	{
		if (currentBuildingObject == null)
		{
			return;
		}
		if (!currentBuildingObject.IsPreviewValid)
		{
			Debug.LogWarning("[BuildingInteractionManager] PlaceBuilding: Preview geçersiz - yerleştirme yapılmayacak!");
			return;
		}
		BuildingModeSource buildingModeSource = currentBuildingObject.GetBuildingModeSource();
		if (buildingModeSource != BuildingModeSource.Relocate && currentBuildingObject.buildingItemSO != null && currentBuildingObject.buildingItemSO.isBelt)
		{
			bool num = TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning;
			bool flag = DayNightManager.Instance != null && DayNightManager.Instance.CurrentGameDay == 1;
			if (num || flag)
			{
				if (GameManager.Instance != null && GameManager.Instance.notificationManager != null)
				{
					GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_NotAvailableDuringTutorial"));
				}
				return;
			}
		}
		if (buildingModeSource != BuildingModeSource.Relocate && TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning && currentBuildingObject.buildingItemSO != null && currentBuildingObject.buildingItemSO.isPallet && (TutorialManager.Instance.GetActiveConfig() != TutorialConfigType.Production || TutorialManager.Instance.CurrentStep != TutorialStepType.PlacePallet))
		{
			if (GameManager.Instance != null && GameManager.Instance.notificationManager != null)
			{
				GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_NotAvailableDuringTutorial"));
			}
			return;
		}
		Vector3 origin = (rayCamera ? rayCamera.transform.position : base.transform.position);
		Vector3 direction = (rayCamera ? rayCamera.transform.forward : base.transform.forward);
		if (!Physics.Raycast(origin, direction, out var hitInfo, maxDistance, effectiveRaycastLayerMask, triggerQuery))
		{
			Debug.LogWarning("BuildingInteractionManager: Yerleştirme başarısız - raycast hit yok!");
			return;
		}
		int layer = hitInfo.collider.gameObject.layer;
		LayerMask layerMask = surfaceLayer;
		if (currentBuildingSO != null && currentBuildingSO.additionalPlacementLayers.value != 0)
		{
			layerMask = (int)layerMask | (int)currentBuildingSO.additionalPlacementLayers;
		}
		bool flag2 = (layerMask.value & (1 << layer)) != 0;
		_ = socketLayer.value;
		if (currentBuildingObject.hybridMode && !currentBuildingObject.socketOnly && currentBuildingPrefab != null)
		{
			if (currentSocket == null)
			{
				Debug.Log($"[BuildingInteractionManager] PlaceBuilding (HYBRID): currentSocket null, tekrar aranıyor... HitPoint: {hitInfo.point}");
				currentSocket = FindNearestSocketCached(hitInfo.point, currentBuildingPrefab);
			}
			if (currentSocket != null)
			{
				Debug.Log("[BuildingInteractionManager] PlaceBuilding (HYBRID): Socket bulundu - Socket: " + currentSocket.gameObject.name + ", BuildingPrefab: " + currentBuildingPrefab.name);
				currentSocket.LogSocketState("PlaceBuilding (HYBRID) - Before CanPlaceBuilding check");
				if (currentSocket.IsLockedInTutorial(currentBuildingPrefab))
				{
					GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_NotAvailableDuringTutorial"));
					return;
				}
				if (!currentSocket.CanPlaceBuilding(currentBuildingPrefab, RelocatingNetId, CurrentBuildingNetId))
				{
					Debug.LogWarning("[BuildingInteractionManager] PlaceBuilding (HYBRID): Socket yerleştirme başarısız - socket bu building'i kabul etmiyor veya dolu! Normal yerleştirmeye geçiliyor... Socket: " + currentSocket.gameObject.name + ", BuildingPrefab: " + currentBuildingPrefab.name);
					currentSocket.LogSocketState("PlaceBuilding (HYBRID) - CanPlaceBuilding returned false, falling back to normal placement");
					currentSocket = null;
					socketCacheValid = false;
				}
				else
				{
					Debug.Log("[BuildingInteractionManager] PlaceBuilding (HYBRID): Socket kontrolü başarılı - Socket: " + currentSocket.gameObject.name + ", BuildingPrefab: " + currentBuildingPrefab.name);
					BuildingObject componentInParent = currentSocket.GetComponentInParent<BuildingObject>();
					if (socketLayer.value != 0)
					{
						BuildingObject buildingObject = currentBuildingObject;
						buildingObject.ignoreLayers = (int)buildingObject.ignoreLayers | (int)socketLayer;
					}
					if (!currentBuildingObject.CheckCollision(currentSocket, componentInParent))
					{
						currentBuildingObject.SetTargetSocket(currentSocket);
						Debug.Log("[BuildingInteractionManager] PlaceBuilding (HYBRID): Socket yerleştirme başarılı - BuildingObject: " + currentBuildingObject.name + ", Socket: " + currentSocket.gameObject.name);
						BuildingModeSource buildingModeSource2 = currentBuildingObject.GetBuildingModeSource();
						T_BuildingItemSO placedBuilding = currentBuildingSO;
						PlayPlaceBuildingSound();
						currentBuildingObject.PlaceBuilding();
						currentBuildingObject = null;
						currentSocket = null;
						currentBuildingPrefab = null;
						socketCacheValid = false;
						if (buildingModeSource2 == BuildingModeSource.RadialMenu && RadialBuildingManager.Instance != null)
						{
							Debug.Log("[BuildingInteractionManager] PlaceBuilding (HYBRID): RadialMenu modu - aynı building ile devam");
							RadialBuildingManager.Instance.OnBuildingPlacedCallback(placedBuilding);
						}
						else if (buildingModeSource2 == BuildingModeSource.Relocate)
						{
							Debug.Log("[BuildingInteractionManager] PlaceBuilding (HYBRID): Relocate modu - building mode kapatılıyor");
							currentBuildingSO = null;
							currentBuildingSource = BuildingModeSource.None;
							if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
							{
								GameManager.Instance.localEquipments.StopBuildingMode();
							}
						}
						else
						{
							Debug.Log("[BuildingInteractionManager] PlaceBuilding (HYBRID): BuildingBox modu - temizlik yapılıyor");
							currentBuildingSO = null;
							currentBuildingSource = BuildingModeSource.None;
						}
						TutorialManager.Instance?.TryCompleteSubStep(TutorialConfigType.Production, TutorialStepType.PlaceMachine, TutorialSubStepType.PlaceBuilding);
						return;
					}
					Debug.LogWarning("BuildingInteractionManager (HYBRID): Socket yerleştirme başarısız - çarpışma tespit edildi! Normal yerleştirmeye geçiliyor...");
					currentSocket = null;
					socketCacheValid = false;
				}
			}
			if (currentSocket == null && TutorialManager.Instance != null && TutorialManager.Instance.GetActiveConfig() == TutorialConfigType.Production && (TutorialManager.Instance.CurrentStep == TutorialStepType.PlacePallet || TutorialManager.Instance.CurrentStep == TutorialStepType.PlaceMachine))
			{
				if (GameManager.Instance != null && GameManager.Instance.notificationManager != null)
				{
					string term = ((currentBuildingObject.buildingItemSO != null && currentBuildingObject.buildingItemSO.isPallet) ? "Notification_TutorialPlacePallet_OnlySocket" : "Notification_NotAvailableDuringTutorial");
					GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation(term));
				}
				return;
			}
		}
		if (currentBuildingObject.socketOnly)
		{
			if (currentBuildingPrefab == null)
			{
				Debug.LogWarning("[BuildingInteractionManager] PlaceBuilding (CLIENT): Yerleştirme başarısız - building prefab referansı null!");
				return;
			}
			if (currentSocket == null)
			{
				Debug.Log($"[BuildingInteractionManager] PlaceBuilding (CLIENT): currentSocket null, tekrar aranıyor... HitPoint: {hitInfo.point}");
				currentSocket = FindNearestSocketCached(hitInfo.point, currentBuildingPrefab);
			}
			if (currentSocket == null)
			{
				Debug.LogWarning($"[BuildingInteractionManager] PlaceBuilding (CLIENT): Yerleştirme başarısız - yakında uygun socket bulunamadı! HitPoint: {hitInfo.point}, BuildingPrefab: {currentBuildingPrefab.name}");
				return;
			}
			Debug.Log("[BuildingInteractionManager] PlaceBuilding (CLIENT): Socket bulundu - Socket: " + currentSocket.gameObject.name + ", BuildingPrefab: " + currentBuildingPrefab.name);
			currentSocket.LogSocketState("PlaceBuilding - Before CanPlaceBuilding check");
			if (currentSocket.IsLockedInTutorial(currentBuildingPrefab))
			{
				GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_NotAvailableDuringTutorial"));
				return;
			}
			if (!currentSocket.CanPlaceBuilding(currentBuildingPrefab, RelocatingNetId, CurrentBuildingNetId))
			{
				Debug.LogWarning("[BuildingInteractionManager] PlaceBuilding (CLIENT): Yerleştirme başarısız - socket bu building'i kabul etmiyor veya dolu! Socket: " + currentSocket.gameObject.name + ", BuildingPrefab: " + currentBuildingPrefab.name);
				currentSocket.LogSocketState("PlaceBuilding - CanPlaceBuilding returned false");
				return;
			}
			Debug.Log("[BuildingInteractionManager] PlaceBuilding (CLIENT): Socket kontrolü başarılı - Socket: " + currentSocket.gameObject.name + ", BuildingPrefab: " + currentBuildingPrefab.name);
			BuildingObject componentInParent2 = currentSocket.GetComponentInParent<BuildingObject>();
			if (socketLayer.value != 0)
			{
				BuildingObject buildingObject2 = currentBuildingObject;
				buildingObject2.ignoreLayers = (int)buildingObject2.ignoreLayers | (int)socketLayer;
			}
			if (currentBuildingObject.CheckCollision(currentSocket, componentInParent2))
			{
				Debug.LogWarning("BuildingInteractionManager: Yerleştirme başarısız - çarpışma tespit edildi!");
				return;
			}
			currentBuildingObject.SetTargetSocket(currentSocket);
		}
		else
		{
			if (!flag2)
			{
				Debug.LogWarning($"[BuildingInteractionManager] PlaceBuilding (CLIENT): Yerleştirme başarısız - surface layer değil! HitLayer: {layer}, SurfaceLayer: {surfaceLayer.value}");
				return;
			}
			if (currentBuildingObject.CheckCollision())
			{
				Debug.LogWarning("[BuildingInteractionManager] PlaceBuilding (CLIENT): Yerleştirme başarısız - çarpışma tespit edildi!");
				return;
			}
		}
		Debug.Log(string.Format("[BuildingInteractionManager] PlaceBuilding: Yerleştirme başarılı - BuildingObject: {0}, Source: {1}, SO: {2}", currentBuildingObject.name, currentBuildingSource, (currentBuildingSO != null) ? currentBuildingSO.Name : "null"));
		switch (currentBuildingObject.GetBuildingModeSource())
		{
		case BuildingModeSource.RadialMenu:
		{
			T_BuildingItemSO buildingItemSO = currentBuildingObject.buildingItemSO;
			if (!(buildingItemSO != null) || buildingItemSO.Price <= 0 || !(GameManager.Instance != null) || !(GameManager.Instance.factoryManager != null))
			{
				break;
			}
			if (!GameManager.Instance.factoryManager.TryPurchase(buildingItemSO.Price, EconomyType.EconomyType_Building))
			{
				Debug.LogWarning($"[BuildingInteractionManager] PlaceBuilding: Para yetersiz! Gerekli: {buildingItemSO.Price}");
				if (GameManager.Instance.notificationManager != null)
				{
					GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_InsufficientBalance"));
				}
				return;
			}
			Debug.Log($"[BuildingInteractionManager] PlaceBuilding: Para düşüldü - Fiyat: {buildingItemSO.Price}");
			break;
		}
		case BuildingModeSource.Relocate:
			Debug.Log("[BuildingInteractionManager] PlaceBuilding: Relocate modu - para kesilmedi (building zaten ödenmiş)");
			break;
		}
		BuildingModeSource buildingModeSource3 = currentBuildingSource;
		T_BuildingItemSO t_BuildingItemSO = currentBuildingSO;
		T_Socket t_Socket = currentSocket;
		GameObject gameObject = currentBuildingPrefab;
		Debug.Log(string.Format("[BuildingInteractionManager] PlaceBuilding: placedSource: {0}, placedSO: {1}, placedSocket: {2}, RadialBuildingManager.Instance: {3}", buildingModeSource3, (t_BuildingItemSO != null) ? t_BuildingItemSO.Name : "null", (t_Socket != null) ? t_Socket.name : "null", (RadialBuildingManager.Instance != null) ? "var" : "null"));
		if (t_Socket != null && gameObject != null)
		{
			t_Socket.OnBuildingPlaced(gameObject);
			Debug.Log("[BuildingInteractionManager] PlaceBuilding: Socket client tarafında hemen güncellendi - Socket: " + t_Socket.name + ", Prefab: " + gameObject.name);
		}
		PlayPlaceBuildingSound();
		reservedSocket = null;
		currentBuildingObject.PlaceBuilding();
		currentBuildingObject = null;
		currentSocket = null;
		currentBuildingPrefab = null;
		socketCacheValid = false;
		if (buildingModeSource3 == BuildingModeSource.RadialMenu && RadialBuildingManager.Instance != null)
		{
			Debug.Log("[BuildingInteractionManager] PlaceBuilding: Equipments callback çağrılıyor...");
			RadialBuildingManager.Instance.OnBuildingPlacedCallback(t_BuildingItemSO);
		}
		else if (buildingModeSource3 == BuildingModeSource.Relocate)
		{
			Debug.Log("[BuildingInteractionManager] PlaceBuilding: Relocate modu - building mode kapatılıyor");
			currentBuildingSO = null;
			currentBuildingSource = BuildingModeSource.None;
			if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
			{
				GameManager.Instance.localEquipments.StopBuildingMode();
			}
		}
		else
		{
			Debug.Log($"[BuildingInteractionManager] PlaceBuilding: BuildingBox modu veya RadialBuildingManager null - placedSource: {buildingModeSource3}");
			currentBuildingSO = null;
			currentBuildingSource = BuildingModeSource.None;
		}
		TutorialManager.Instance?.TryCompleteSubStep(TutorialConfigType.Production, TutorialStepType.PlaceMachine, TutorialSubStepType.PlaceBuilding);
	}

	private void UpdateSocketReservation(T_Socket newSocket)
	{
		if (!(reservedSocket == newSocket))
		{
			if (reservedSocket != null && currentBuildingObject != null)
			{
				currentBuildingObject.RequestUnreserveSocket(reservedSocket);
				Debug.Log("[BuildingInteractionManager] UpdateSocketReservation: Eski socket unreserve edildi - Socket: " + reservedSocket.gameObject.name);
			}
			if (newSocket != null && currentBuildingObject != null)
			{
				currentBuildingObject.RequestReserveSocket(newSocket);
				Debug.Log("[BuildingInteractionManager] UpdateSocketReservation: Yeni socket reserve edildi - Socket: " + newSocket.gameObject.name);
			}
			reservedSocket = newSocket;
		}
	}

	public void CancelBuilding()
	{
		UpdateSocketReservation(null);
		if (currentBuildingObject != null)
		{
			currentBuildingObject.CancelBuilding();
			currentBuildingObject = null;
		}
	}

	private T_Socket FindNearestSocketCached(Vector3 hitPoint, GameObject buildingPrefab)
	{
		if (buildingPrefab == null)
		{
			Debug.LogWarning("[BuildingInteractionManager] FindNearestSocketCached: buildingPrefab null!");
			return null;
		}
		Collider[] array = Physics.OverlapSphere(hitPoint, socketSearchRadius, socketLayer, triggerQuery);
		Debug.Log($"[BuildingInteractionManager] FindNearestSocketCached: Socket layer'ında bulunan collider sayısı: {array.Length}");
		if (array.Length == 0)
		{
			Debug.LogWarning("[BuildingInteractionManager] FindNearestSocketCached: Socket layer'ında hiç collider bulunamadı!");
			socketCacheValid = false;
			return null;
		}
		T_Socket t_Socket = null;
		float num = float.MaxValue;
		if (GetBuildingItemSOFromPrefab(buildingPrefab) == null)
		{
			Debug.LogWarning("[BuildingInteractionManager] FindNearestSocketCached: SO bulunamadı! BuildingPrefab: " + buildingPrefab.name);
			socketCacheValid = false;
			return null;
		}
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (collider == null)
			{
				continue;
			}
			T_Socket component = collider.GetComponent<T_Socket>();
			if (component == null)
			{
				continue;
			}
			BuildingObject componentInParent = collider.GetComponentInParent<BuildingObject>();
			if ((!(componentInParent != null) || componentInParent.IsPlaced) && component.CanPlaceBuilding(buildingPrefab, RelocatingNetId, CurrentBuildingNetId))
			{
				float num2 = Vector3.Distance(hitPoint, component.transform.position);
				if (num2 < num)
				{
					num = num2;
					t_Socket = component;
				}
			}
		}
		if (t_Socket != null)
		{
			cachedSocket = t_Socket;
			cachedSocketPosition = t_Socket.transform.position;
			cachedSocketDistance = num;
			socketCacheValid = true;
			Debug.Log($"[BuildingInteractionManager] FindNearestSocketCached: Socket bulundu ve cache'lendi - Socket: {t_Socket.name}, Distance: {num:F2}m");
		}
		else
		{
			socketCacheValid = false;
		}
		return t_Socket;
	}

	private T_Socket FindNearestSocket(Vector3 hitPoint, GameObject buildingPrefab)
	{
		return FindNearestSocketCached(hitPoint, buildingPrefab);
	}

	private T_BuildingItemSO GetBuildingItemSOFromPrefab(GameObject buildingPrefab)
	{
		if (currentBuildingObject != null && currentBuildingObject.buildingItemSO != null)
		{
			Debug.Log("[BuildingInteractionManager] GetBuildingItemSOFromPrefab: SO currentBuildingObject'dan alındı - " + currentBuildingObject.buildingItemSO.Name);
			return currentBuildingObject.buildingItemSO;
		}
		if (buildingPrefab != null)
		{
			BuildingObject component = buildingPrefab.GetComponent<BuildingObject>();
			if (component != null && component.buildingItemSO != null)
			{
				Debug.Log("[BuildingInteractionManager] GetBuildingItemSOFromPrefab: SO buildingPrefab'dan alındı - " + component.buildingItemSO.Name);
				return component.buildingItemSO;
			}
		}
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			GameObject pickupItem = GameManager.Instance.localEquipments.pickupItem;
			if (pickupItem != null)
			{
				T_Building component2 = pickupItem.GetComponent<T_Building>();
				if (component2 != null && component2.BuildingItemSO != null)
				{
					Debug.Log("[BuildingInteractionManager] GetBuildingItemSOFromPrefab: SO pickupItem'dan alındı - " + component2.BuildingItemSO.Name);
					return component2.BuildingItemSO;
				}
			}
		}
		Debug.LogWarning("[BuildingInteractionManager] GetBuildingItemSOFromPrefab: SO bulunamadı!");
		return null;
	}

	private int LayerMaskToLayer(LayerMask mask)
	{
		if (mask.value == 0)
		{
			return -1;
		}
		for (int i = 0; i < 32; i++)
		{
			if ((mask.value & (1 << i)) != 0)
			{
				return i;
			}
		}
		return -1;
	}

	private void PlayPlaceBuildingSound()
	{
		if (audioSource != null && placeBuildingClip != null)
		{
			audioSource.PlayOneShot(placeBuildingClip);
		}
	}

	private void OnDisable()
	{
		ClearBuildingObject();
	}
}
