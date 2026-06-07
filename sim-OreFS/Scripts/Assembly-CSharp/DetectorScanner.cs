using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DetectorScanner : MonoBehaviour
{
	[Header("References")]
	[Tooltip("Detector'ın ucu - SphereCast buradan başlar")]
	[SerializeField]
	private Transform scanOrigin;

	[Tooltip("T_Tool referansı - distance ve radius buradan alınır")]
	[SerializeField]
	private T_Tool tool;

	[SerializeField]
	private GamePlayer localPlayer;

	[Header("Scan Settings")]
	[Tooltip("Node'ların olduğu layer (Layer 18)")]
	[SerializeField]
	private LayerMask nodeLayer = 262144;

	[Tooltip("Tarama yönü (local space)")]
	[SerializeField]
	private Vector3 scanDirection = Vector3.down;

	[Tooltip("Engel layer'ı - bu layer'daki objeler arkasındaki node'ları gizler")]
	[SerializeField]
	private LayerMask obstacleLayer;

	[Tooltip("Tarama aralığı (saniye) - her frame yerine belirli aralıklarla tarar")]
	[SerializeField]
	private float scanInterval = 0.15f;

	[Header("UI Intensity Settings (Node Sayısına Göre)")]
	[Tooltip("Minimum yoğunluk için gereken T_NodePiece sayısı")]
	[SerializeField]
	private int minIntensityCount = 1;

	[Tooltip("Maximum yoğunluk için gereken T_NodePiece sayısı")]
	[SerializeField]
	private int maxIntensityCount = 10;

	[Header("Detector Canvas UI")]
	[Tooltip("Detector üzerindeki Canvas - hedef item ikonu")]
	[SerializeField]
	private Image targetItemIcon;

	[Tooltip("Detector üzerindeki Canvas - hedef item adı")]
	[SerializeField]
	private TextMeshProUGUI targetItemNameText;

	[Tooltip("Detector üzerindeki Canvas - yoğunluk göstergesi (Image.fillAmount)")]
	[SerializeField]
	private Image intensityFillImage;

	[Tooltip("Detector üzerindeki Canvas - node mesafesi göstergesi (metre)")]
	[SerializeField]
	private TextMeshProUGUI distanceText;

	[Header("Input")]
	[Tooltip("Mouse scroll input action reference")]
	[SerializeField]
	private InputActionReference scrollInputAction;

	[Header("Debug")]
	[SerializeField]
	private bool showDebugGizmos = true;

	[SerializeField]
	private Color gizmoColor = Color.green;

	[SerializeField]
	private Color hitColor = Color.red;

	private T_ItemSO currentScanTarget;

	private float uiIntensity;

	private float audioIntensity;

	private float closestNodeDistance = float.MaxValue;

	private List<T_NodePiece> detectedPieces = new List<T_NodePiece>();

	private RaycastHit[] hitBuffer = new RaycastHit[50];

	private List<T_ItemSO> cachedTargetItems = new List<T_ItemSO>();

	private int currentTargetIndex = -1;

	private string lastKnownPropertyListingId;

	private float cachedScanDistance;

	private float cachedScanRadius;

	private float scanTimer;

	private Camera _cachedCamera;

	private Dictionary<int, T_NodePiece> _colliderNodeCache = new Dictionary<int, T_NodePiece>();

	private float _lastDisplayedDistance = -1f;

	private void Start()
	{
		if (tool == null)
		{
			tool = GetComponent<T_Tool>();
			if (tool == null)
			{
				tool = GetComponentInParent<T_Tool>();
			}
		}
		if (scanOrigin == null)
		{
			scanOrigin = base.transform;
		}
		_cachedCamera = Camera.main;
		if (DetectorTargetSelectionPanel.Instance != null)
		{
			DetectorTargetSelectionPanel.Instance.OnScanTargetChanged += OnScanTargetChanged;
			currentScanTarget = DetectorTargetSelectionPanel.Instance.CurrentScanTarget;
		}
		UpdateCanvasUI();
		CacheToolStats();
	}

	private void OnActivePropertyCleared()
	{
		lastKnownPropertyListingId = null;
		if (DetectorTargetSelectionPanel.Instance != null)
		{
			DetectorTargetSelectionPanel.Instance.ClearScanTarget();
			return;
		}
		currentScanTarget = null;
		currentTargetIndex = -1;
		UpdateCanvasUI();
	}

	private void OnEnable()
	{
		if (scrollInputAction != null && scrollInputAction.action != null)
		{
			scrollInputAction.action.Enable();
			scrollInputAction.action.performed += OnScrollPerformed;
		}
		if (ComputerPropertyManager.Instance != null)
		{
			ComputerPropertyManager.Instance.onActivePropertyCleared.AddListener(OnActivePropertyCleared);
			if (currentScanTarget != null && (ComputerPropertyManager.Instance.HasActiveProperty ? ComputerPropertyManager.Instance.ActiveProperty.listingId : null) != lastKnownPropertyListingId)
			{
				OnActivePropertyCleared();
			}
		}
	}

	private void OnDisable()
	{
		if (scrollInputAction != null && scrollInputAction.action != null)
		{
			scrollInputAction.action.performed -= OnScrollPerformed;
		}
		if (ComputerPropertyManager.Instance != null)
		{
			ComputerPropertyManager.Instance.onActivePropertyCleared.RemoveListener(OnActivePropertyCleared);
		}
	}

	private void OnDestroy()
	{
		if (DetectorTargetSelectionPanel.Instance != null)
		{
			DetectorTargetSelectionPanel.Instance.OnScanTargetChanged -= OnScanTargetChanged;
		}
	}

	private void Update()
	{
		if (localPlayer.isLocalPlayer)
		{
			CacheToolStats();
			scanTimer -= Time.deltaTime;
			if (scanTimer <= 0f)
			{
				scanTimer = scanInterval;
				PerformScan();
			}
			UpdateIntensityUI();
		}
	}

	private void OnScrollPerformed(InputAction.CallbackContext context)
	{
		if (!localPlayer.isLocalPlayer)
		{
			return;
		}
		float y = context.ReadValue<Vector2>().y;
		if (Mathf.Approximately(y, 0f))
		{
			return;
		}
		RefreshCachedTargetItems();
		if (cachedTargetItems.Count == 0)
		{
			return;
		}
		if (currentScanTarget != null)
		{
			currentTargetIndex = cachedTargetItems.FindIndex((T_ItemSO item) => item.GetItemID() == currentScanTarget.GetItemID());
		}
		if (y > 0f)
		{
			currentTargetIndex--;
			if (currentTargetIndex < 0)
			{
				currentTargetIndex = cachedTargetItems.Count - 1;
			}
		}
		else
		{
			currentTargetIndex++;
			if (currentTargetIndex >= cachedTargetItems.Count)
			{
				currentTargetIndex = 0;
			}
		}
		T_ItemSO scanTarget = cachedTargetItems[currentTargetIndex];
		if (DetectorTargetSelectionPanel.Instance != null)
		{
			DetectorTargetSelectionPanel.Instance.SetScanTarget(scanTarget);
		}
		else
		{
			SetScanTarget(scanTarget);
		}
	}

	private void RefreshCachedTargetItems()
	{
		cachedTargetItems.Clear();
		if (ComputerPropertyManager.Instance == null)
		{
			return;
		}
		List<T_ItemSO> activePropertyItems = ComputerPropertyManager.Instance.GetActivePropertyItems();
		if (activePropertyItems == null)
		{
			return;
		}
		HashSet<string> hashSet = new HashSet<string>();
		List<T_ItemSO> list = new List<T_ItemSO>();
		List<T_ItemSO> list2 = new List<T_ItemSO>();
		foreach (T_ItemSO item in activePropertyItems)
		{
			if (item == null)
			{
				continue;
			}
			string itemID = item.GetItemID();
			if (!hashSet.Contains(itemID))
			{
				hashSet.Add(itemID);
				if (item.FilterTypes != null && item.FilterTypes.Contains(FilterType.Ores))
				{
					list.Add(item);
				}
				else
				{
					list2.Add(item);
				}
			}
		}
		cachedTargetItems.AddRange(list);
		cachedTargetItems.AddRange(list2);
	}

	private void CacheToolStats()
	{
		if (tool != null)
		{
			cachedScanDistance = tool.scanDistance;
			cachedScanRadius = tool.scanRadius;
		}
		else
		{
			cachedScanDistance = 5f;
			cachedScanRadius = 1f;
		}
	}

	private void OnScanTargetChanged(T_ItemSO newTarget)
	{
		currentScanTarget = newTarget;
		if (newTarget != null && ComputerPropertyManager.Instance != null && ComputerPropertyManager.Instance.HasActiveProperty)
		{
			lastKnownPropertyListingId = ComputerPropertyManager.Instance.ActiveProperty.listingId;
		}
		else
		{
			lastKnownPropertyListingId = null;
		}
		UpdateCanvasUI();
		Debug.Log("[DetectorScanner] Scan target değişti: " + (newTarget?.Name ?? "None"));
	}

	private void PerformScan()
	{
		detectedPieces.Clear();
		closestNodeDistance = float.MaxValue;
		if (currentScanTarget == null)
		{
			uiIntensity = 0f;
			audioIntensity = 0f;
		}
		else
		{
			if (scanOrigin == null)
			{
				return;
			}
			if (_cachedCamera == null)
			{
				_cachedCamera = Camera.main;
			}
			if (_cachedCamera == null)
			{
				return;
			}
			Ray ray = _cachedCamera.ScreenPointToRay(new Vector3((float)Screen.width / 2f, (float)Screen.height / 2f, 0f));
			Vector3 origin = ray.origin;
			Vector3 direction = ray.direction;
			Vector3 vector = origin + direction * cachedScanDistance;
			if (showDebugGizmos)
			{
				Debug.DrawLine(origin, vector, gizmoColor);
				DrawDebugCircle(origin, direction, cachedScanRadius, gizmoColor);
				DrawDebugCircle(vector, direction, cachedScanRadius, gizmoColor);
			}
			int num = Physics.SphereCastNonAlloc(origin, cachedScanRadius, direction, hitBuffer, cachedScanDistance, nodeLayer);
			for (int i = 0; i < num; i++)
			{
				RaycastHit nodeHit = hitBuffer[i];
				if (nodeHit.collider == null)
				{
					continue;
				}
				if (showDebugGizmos)
				{
					Debug.DrawLine(origin, nodeHit.point, hitColor);
					Debug.DrawRay(nodeHit.point, Vector3.up * 0.5f, hitColor);
				}
				int instanceID = nodeHit.collider.GetInstanceID();
				if (!_colliderNodeCache.TryGetValue(instanceID, out var value))
				{
					value = nodeHit.collider.GetComponent<T_NodePiece>();
					if (value == null)
					{
						value = nodeHit.collider.GetComponentInParent<T_NodePiece>();
					}
					_colliderNodeCache[instanceID] = value;
				}
				if (!(value == null) && !value.IsBroken() && IsTargetMatch(value) && !IsBlockedByObstacle(origin, nodeHit) && !detectedPieces.Contains(value))
				{
					detectedPieces.Add(value);
					if (nodeHit.distance < closestNodeDistance)
					{
						closestNodeDistance = nodeHit.distance;
					}
				}
			}
			CalculateIntensity();
		}
	}

	private void DrawDebugCircle(Vector3 center, Vector3 normal, float radius, Color color)
	{
		Vector3 normalized = Vector3.Cross(normal, Vector3.up).normalized;
		if (normalized == Vector3.zero)
		{
			normalized = Vector3.Cross(normal, Vector3.right).normalized;
		}
		Vector3 normalized2 = Vector3.Cross(normalized, normal).normalized;
		int num = 16;
		float num2 = 360f / (float)num;
		for (int i = 0; i < num; i++)
		{
			float f = (float)i * num2 * (MathF.PI / 180f);
			float f2 = (float)(i + 1) * num2 * (MathF.PI / 180f);
			Vector3 start = center + (normalized * Mathf.Cos(f) + normalized2 * Mathf.Sin(f)) * radius;
			Vector3 end = center + (normalized * Mathf.Cos(f2) + normalized2 * Mathf.Sin(f2)) * radius;
			Debug.DrawLine(start, end, color);
		}
	}

	private bool IsBlockedByObstacle(Vector3 origin, RaycastHit nodeHit)
	{
		if ((int)obstacleLayer == 0)
		{
			return false;
		}
		Vector3 vector = nodeHit.point - origin;
		float magnitude = vector.magnitude;
		if (magnitude < 0.01f)
		{
			return false;
		}
		return Physics.Raycast(origin, vector.normalized, magnitude, obstacleLayer);
	}

	private bool IsTargetMatch(T_NodePiece nodePiece)
	{
		if (currentScanTarget == null)
		{
			return true;
		}
		T_Item parentItem = nodePiece.GetParentItem();
		if (parentItem == null)
		{
			return false;
		}
		T_ItemSO so = parentItem.so;
		if (so == null)
		{
			return false;
		}
		return so.GetItemID() == currentScanTarget.GetItemID();
	}

	private void CalculateIntensity()
	{
		int count = detectedPieces.Count;
		if (count <= minIntensityCount)
		{
			uiIntensity = 0f;
		}
		else if (count >= maxIntensityCount)
		{
			uiIntensity = 1f;
		}
		else
		{
			float num = maxIntensityCount - minIntensityCount;
			uiIntensity = (float)(count - minIntensityCount) / num;
		}
		if (count == 0 || closestNodeDistance >= cachedScanDistance)
		{
			audioIntensity = 0f;
			return;
		}
		audioIntensity = 1f - closestNodeDistance / cachedScanDistance;
		audioIntensity = Mathf.Clamp01(audioIntensity);
	}

	private void UpdateCanvasUI()
	{
		if (targetItemIcon != null)
		{
			if (currentScanTarget != null && currentScanTarget.Icon != null)
			{
				targetItemIcon.sprite = currentScanTarget.Icon;
				targetItemIcon.enabled = true;
			}
			else
			{
				targetItemIcon.enabled = false;
			}
		}
		if (targetItemNameText != null)
		{
			if (currentScanTarget != null)
			{
				string translation = LocalizationManager.GetTranslation(currentScanTarget.Name);
				targetItemNameText.text = ((!string.IsNullOrEmpty(translation)) ? translation : currentScanTarget.Name);
			}
			else
			{
				targetItemNameText.text = "";
			}
		}
	}

	private void UpdateIntensityUI()
	{
		if (intensityFillImage != null)
		{
			intensityFillImage.fillAmount = uiIntensity;
		}
		if (!(distanceText != null))
		{
			return;
		}
		if (detectedPieces.Count > 0 && closestNodeDistance < float.MaxValue)
		{
			float num = Mathf.Round(closestNodeDistance * 10f) / 10f;
			if (!Mathf.Approximately(num, _lastDisplayedDistance))
			{
				_lastDisplayedDistance = num;
				distanceText.text = $"{num:F1}m";
			}
		}
		else if (_lastDisplayedDistance >= 0f)
		{
			_lastDisplayedDistance = -1f;
			distanceText.text = "";
		}
	}

	public float GetCurrentIntensity()
	{
		return audioIntensity;
	}

	public float GetUIIntensity()
	{
		return uiIntensity;
	}

	public int GetDetectedPieceCount()
	{
		return detectedPieces.Count;
	}

	public T_ItemSO GetCurrentScanTarget()
	{
		return currentScanTarget;
	}

	public void SetScanTarget(T_ItemSO target)
	{
		currentScanTarget = target;
		UpdateCanvasUI();
	}

	public float GetClosestNodeDistance()
	{
		if (!(closestNodeDistance < float.MaxValue))
		{
			return -1f;
		}
		return closestNodeDistance;
	}
}
