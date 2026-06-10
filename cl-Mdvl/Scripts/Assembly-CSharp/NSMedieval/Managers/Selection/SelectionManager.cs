using System;
using System.Collections.Generic;
using Managers.Selection.EventData;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.DebugEvents;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Stockpiles;
using NSMedieval.Terrain;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.Managers.Selection
{
	public class SelectionManager : MonoSingleton<SelectionManager>
	{
		public delegate void SelectionHandler();

		private enum SelectionMode
		{
			FloorSelect = 0,
			VoxelSelect = 1
		}

		public const int MaximumGridSize = 30;

		[SerializeField]
		private GameObject selectionGridPrefab;

		[SerializeField]
		private GameObject selectionVolumePrefab;

		private SelectionMode selectionMode = SelectionMode.VoxelSelect;

		private SelectionMode defaultSelectionMode;

		[NonSerialized]
		private GameObject selectionGrid;

		[NonSerialized]
		private GameObject selectionVolume;

		private Vec3Int startPoint;

		private Vec3Int endPoint;

		private bool selecting;

		private Ray ray;

		private RaycastHit hit;

		private int layerUI;

		private int voxelMapLayer;

		private int buildableSurfaceLayer;

		private int selectable;

		private int raycastPlaneHelperLayer;

		private int raycastMask;

		private string areaID;

		private Vector3 startNormal;

		private Vector3 endNormal;

		private ObjectSide hitSide;

		private BuildingType buildingTypesToDeconstruct = BuildingType.AllBuildings;

		private OrderAllowType orderAllowType = OrderAllowType.All;

		private PlantLifePhaseType plantLifePhaseType;

		private bool affectOnlyOneLayer;

		[NonSerialized]
		private LocalizationController localizationController;

		[NonSerialized]
		private UIController uiController;

		[NonSerialized]
		private List<string> localizedInfoCursorData = new List<string>();

		private Vector3 selectionGridOffset = new Vector3(0f, 0.04f, 0f);

		[SerializeField]
		private GameObject raycastHeplerPlane;

		[NonSerialized]
		private Dictionary<OrderType, Action> mouseUpActions = new Dictionary<OrderType, Action>();

		[NonSerialized]
		private Dictionary<OrderType, SelectionMode> orderSelectionMode = new Dictionary<OrderType, SelectionMode>();

		[NonSerialized]
		private List<Vec3Int> positionsInSelectedSlopes = new List<Vec3Int>();

		[NonSerialized]
		private List<SlopeInstance> selectedSlopes = new List<SlopeInstance>();

		[NonSerialized]
		private Cropfield cropfieldBlueprint;

		public OrderType OrderType { get; private set; }

		public AreaType AreaOrderType { get; private set; }

		public bool CanSelect { get; private set; }

		public bool Selecting => selecting;

		public BuildingType BuildingTypesToDeconstruct => buildingTypesToDeconstruct;

		public OrderAllowType OrderAllowType => orderAllowType;

		public PlantLifePhaseType PlantLifePhaseType => plantLifePhaseType;

		public bool ReadyToPlaceArea => !string.IsNullOrEmpty(areaID);

		private UIController UIController
		{
			get
			{
				if (uiController == null)
				{
					uiController = MonoSingleton<UIController>.Instance;
				}
				return uiController;
			}
		}

		public event SelectionHandler SelectionFinishedEvent;

		public event Action<OrderEventData> OrderResourceCollectionEvent;

		public event Action<PlantOrderEventData> OrderChopEvent;

		public event Action<BuildingOrderEventData> OrderDeconstructionEvent;

		public event Action<OrderEventData> AllowOrForbidEvent;

		public event Action<OrderEventData> UrgentHaulEvent;

		public event Action<OrderEventData> SelectionHighlightEvent;

		public event Action<PlantOrderEventData> SelectionChopEvent;

		public event Action<BuildingOrderEventData> SelectionDeconstructHighlightEvent;

		public event Action<float, float, float, float> SelectionDrag;

		public event Action<float, float, float, float> ZoneSelectionDrag;

		public event Action<float, float, float, float> ZoneSelectionPlace;

		public event Action SetFillColorEvent;

		public event Action ResetFillColorEvent;

		public event Action<Vec3Int> ForceOrderOnResourceEvent;

		public event Action<OrderType, AreaType> AssignOrderEvent;

		public event Action ResetOrderEvent;

		public event Action RightMouseUpResetOrderEvent;

		public void SetOrderDeconstructType(BuildingType buildingTypesToDeconstruct)
		{
			this.buildingTypesToDeconstruct = buildingTypesToDeconstruct;
		}

		public void SetOrderDeconstructLayers(OrderLayerSelectionType orderLayerSelectionType)
		{
			affectOnlyOneLayer = orderLayerSelectionType.Equals(OrderLayerSelectionType.SingleLayer);
		}

		public void SetChopPhaseType(PlantLifePhaseType phaseType)
		{
			plantLifePhaseType = phaseType;
		}

		public void SetOrderAllowType(OrderAllowType orderAllowType)
		{
			this.orderAllowType = orderAllowType;
		}

		public void SetupAllowAndForbid(OrderType orderType)
		{
			OrderType = orderType;
		}

		public void OnDrawGizmos()
		{
			Vec3Int vec3Int = Vec3Int.Scale(startPoint + endPoint, Vec3Int.one * 0.5f);
			Gizmos.DrawWireCube(size: (Vector3)(endPoint - startPoint), center: (Vector3)vec3Int);
		}

		public void OnClickAssignOrder(int orderType)
		{
			CanSelect = true;
			OrderType = (OrderType)orderType;
			ShowActionInfo();
			raycastMask = voxelMapLayer | buildableSurfaceLayer;
			if (selectionGrid == null)
			{
				selectionGrid = UnityEngine.Object.Instantiate(selectionGridPrefab);
			}
			selectionGrid.GetComponent<MeshRenderer>().material.SetFloat("_colorChange", OrderType.Equals(OrderType.ShrinkZone) ? 1 : 0);
			if (selectionVolume == null)
			{
				selectionVolume = UnityEngine.Object.Instantiate(selectionVolumePrefab);
			}
			bool active = OrderType == OrderType.Digging;
			bool active2 = OrderType != OrderType.Digging;
			if (OrderType == OrderType.Attack)
			{
				active = (active2 = false);
			}
			selectionVolume.SetActive(active);
			selectionGrid.SetActive(active2);
			this.AssignOrderEvent?.Invoke(OrderType, AreaOrderType);
			SetSelectionMode(OrderType);
			if (selectionMode == SelectionMode.FloorSelect)
			{
				this.SetFillColorEvent?.Invoke();
			}
		}

		public void OnSelectArea(AreaType areaType, string areaID)
		{
			this.areaID = areaID;
			AreaOrderType = areaType;
			OnClickAssignOrder(0);
			cropfieldBlueprint = ((areaType == AreaType.Crops) ? Repository<CropfieldRepository, Cropfield>.Instance.GetByID(this.areaID) : null);
			UpdateInfoCursor();
		}

		public void OnClickAssignInfoCursor(string tooltipType)
		{
			UIController.UpdateInfoCursorContent(tooltipType, background: false, 2f);
			uiController.ToggleInfoCursor(active: true);
		}

		public static bool IsWithinSelectionBounds(Vector3 position, float minX, float maxX, float minZ, float maxZ, bool isTolerantSingleSelection = false)
		{
			float x = position.x;
			float z = position.z;
			if (isTolerantSingleSelection && Math.Abs(minX - maxX) < 0.001f && Math.Abs(minZ - maxZ) < 0.001f)
			{
				float num = minX - 0.75f;
				float num2 = maxX + 0.75f;
				float num3 = minZ - 0.75f;
				float num4 = maxZ + 0.75f;
				if (num <= x && x <= num2 && num3 <= z)
				{
					return z <= num4;
				}
				return false;
			}
			if (minX <= x && x <= maxX && minZ <= z)
			{
				return z <= maxZ;
			}
			return false;
		}

		public void ResetSelectionTool(bool fireEvent = true)
		{
			if (fireEvent)
			{
				this.ResetOrderEvent?.Invoke();
			}
			if (selecting || CanSelect)
			{
				this.SelectionHighlightEvent?.Invoke(OrderEventData.MinusOne(OrderType, affectOnlyOneLayer));
				this.SelectionDeconstructHighlightEvent?.Invoke(BuildingOrderEventData.Zeros(OrderType, buildingTypesToDeconstruct, affectOnlyOneLayer));
				this.ResetFillColorEvent?.Invoke();
				ClearSelectedSlopes();
				selecting = false;
				CanSelect = false;
				areaID = string.Empty;
				UIController.ToggleInfoCursor(active: false);
				UIController.HideActionInfo();
				if (selectionGrid != null)
				{
					selectionGrid.SetActive(value: false);
				}
				if (selectionVolume != null)
				{
					selectionVolume.SetActive(value: false);
				}
				if (OrderType.Equals(OrderType.ExpandZone) || OrderType.Equals(OrderType.ShrinkZone) || AreaOrderType.Equals(AreaType.Stockpile) || AreaOrderType.Equals(AreaType.Crops))
				{
					MonoSingleton<UIController>.Instance.DismissModifyZoneButton();
					cropfieldBlueprint = null;
					startPoint = GetMouseWorldPosition(out startNormal);
					endPoint = startPoint;
				}
				OrderType = OrderType.None;
				AreaOrderType = AreaType.None;
				Vector3 position = raycastHeplerPlane.transform.position;
				position = new Vector3(position.x, 0f, position.z);
				raycastHeplerPlane.transform.position = position;
			}
		}

		public void Setup(Vector3 scale, Vector3 position)
		{
			raycastHeplerPlane.GetComponent<BoxCollider>().size = scale * 3f;
			raycastHeplerPlane.transform.position = position;
		}

		public bool IsPositionInSelectedSlopes(Vec3Int pos)
		{
			foreach (Vec3Int positionsInSelectedSlope in positionsInSelectedSlopes)
			{
				if (positionsInSelectedSlope.Equals(pos))
				{
					return true;
				}
			}
			return false;
		}

		public void ForceOrderOnResource(Vec3Int position)
		{
			this.ForceOrderOnResourceEvent?.Invoke(position);
		}

		public void OnMouseDown()
		{
			if (!CanSelect)
			{
				return;
			}
			UIController.ToggleInfoCursor(active: false);
			raycastMask = voxelMapLayer | buildableSurfaceLayer | raycastPlaneHelperLayer;
			raycastHeplerPlane.SetActive(value: true);
			startPoint = GetMouseWorldPosition(out startNormal);
			endPoint = startPoint;
			if (hit.transform == null || hit.transform.gameObject.layer == layerUI)
			{
				UIController.ToggleInfoCursor(active: true);
				return;
			}
			if (selectionMode == SelectionMode.FloorSelect)
			{
				Vector3 position = raycastHeplerPlane.transform.position;
				position = new Vector3(position.x, startPoint.y, position.z);
				raycastHeplerPlane.transform.position = position;
				this.SetFillColorEvent?.Invoke();
			}
			selecting = true;
			if (AreaOrderType == AreaType.Stockpile || AreaOrderType == AreaType.Crops)
			{
				DrawSelection();
			}
		}

		public void OnMouseTick(float deltaTime)
		{
			if (!selecting)
			{
				return;
			}
			endPoint = GetMouseWorldPosition(out endNormal);
			if (AreaOrderType == AreaType.Stockpile || AreaOrderType == AreaType.Crops || OrderType.Equals(OrderType.ExpandZone))
			{
				int max;
				int min;
				if (startPoint.x <= endPoint.x)
				{
					max = Mathf.Clamp(startPoint.x + 30 - 1, startPoint.x, MonoSingleton<World>.Instance.SizeX - 1);
					min = startPoint.x;
				}
				else
				{
					max = startPoint.x;
					min = Mathf.Clamp(startPoint.x - 30 + 1, 0, startPoint.x);
				}
				int max2;
				int min2;
				if (startPoint.z <= endPoint.z)
				{
					max2 = Mathf.Clamp(startPoint.z + 30 - 1, startPoint.z, MonoSingleton<World>.Instance.SizeZ - 1);
					min2 = startPoint.z;
				}
				else
				{
					max2 = startPoint.z;
					min2 = Mathf.Clamp(startPoint.z - 30 + 1, 0, startPoint.z);
				}
				endPoint.x = Mathf.Clamp(endPoint.x, min, max);
				endPoint.z = Mathf.Clamp(endPoint.z, min2, max2);
			}
			else
			{
				endPoint.x = Mathf.Clamp(endPoint.x, 0, MonoSingleton<World>.Instance.SizeX - 1);
				endPoint.z = Mathf.Clamp(endPoint.z, 0, MonoSingleton<World>.Instance.SizeZ - 1);
			}
			if (selectionMode == SelectionMode.VoxelSelect)
			{
				endPoint.y = startPoint.y;
			}
			if (Mathf.Abs(Vec3Int.Distance(in startPoint, hit.point)) < 0.5f)
			{
				return;
			}
			DrawSelection();
			if (selecting)
			{
				Vec3Int input = startPoint.Min(endPoint);
				Vec3Int input2 = startPoint.Max(endPoint);
				if (AreaOrderType == AreaType.Stockpile || AreaOrderType == AreaType.Crops)
				{
					this.ZoneSelectionDrag?.Invoke(input.x, input2.x, input.z, input2.z);
					this.SelectionDrag?.Invoke(input.x, input2.x, input.z, input2.z);
				}
				else if (!startPoint.Equals(endPoint))
				{
					this.ZoneSelectionDrag?.Invoke(input.x, input2.x, input.z, input2.z);
					OrderEventData orderEventData = new OrderEventData(startPoint.y, input.ToVector2XZ(), input2.ToVector2XZ(), OrderType, affectOnlyOneLayer);
					PlantOrderEventData obj = new PlantOrderEventData(orderEventData, plantLifePhaseType, orderAllowType);
					BuildingOrderEventData obj2 = new BuildingOrderEventData(orderEventData, buildingTypesToDeconstruct, orderAllowType);
					this.SelectionHighlightEvent?.Invoke(orderEventData);
					this.SelectionChopEvent?.Invoke(obj);
					this.SelectionDeconstructHighlightEvent?.Invoke(obj2);
				}
			}
		}

		public void OnMouseUp()
		{
			if (selecting)
			{
				ClearSelectedSlopes();
				if (!startPoint.Equals(endPoint))
				{
					this.SelectionHighlightEvent?.Invoke(OrderEventData.MinusOne(OrderType, affectOnlyOneLayer));
					this.SelectionChopEvent?.Invoke(PlantOrderEventData.Zeros(OrderType, plantLifePhaseType, affectOnlyOneLayer));
				}
				this.SelectionDeconstructHighlightEvent?.Invoke(BuildingOrderEventData.Zeros(OrderType, buildingTypesToDeconstruct, affectOnlyOneLayer));
				selecting = false;
				raycastHeplerPlane.SetActive(value: false);
				raycastMask = voxelMapLayer | buildableSurfaceLayer;
				CheckForNonDragSelection();
				if (mouseUpActions.ContainsKey(OrderType))
				{
					DebugEventLog.Write(new OrderIssued(startPoint, endPoint, OrderType));
					mouseUpActions[OrderType]?.Invoke();
				}
				if (selectionMode == SelectionMode.FloorSelect)
				{
					this.SetFillColorEvent?.Invoke();
				}
				SelectionFinished();
				ZoneSelectionFinished();
				if (AreaOrderType == AreaType.Stockpile || AreaOrderType == AreaType.Crops)
				{
					startPoint = GetMouseWorldPosition(out startNormal);
					endPoint = startPoint;
					UpdateInfoCursor();
				}
				else if (OrderType.Equals(OrderType.ExpandZone) || OrderType.Equals(OrderType.ShrinkZone))
				{
					UpdateInfoCursorZoneModification();
				}
				else if (!OrderType.Equals(OrderType.None))
				{
					UIController.ToggleInfoCursor(active: true);
					UIController.UpdateInfoCursorContent("order_" + OrderType.ToString().ToLower(), background: false, 2f);
				}
				Vector3 position = raycastHeplerPlane.transform.position;
				position = new Vector3(position.x, 0f, position.z);
				raycastHeplerPlane.transform.position = position;
			}
		}

		private void ZoneSelectionFinished()
		{
			Vec3Int vec3Int = startPoint.Min(endPoint);
			Vec3Int vec3Int2 = startPoint.Max(endPoint);
			this.ZoneSelectionPlace?.Invoke(vec3Int.x, vec3Int2.x, vec3Int.z, vec3Int2.z);
		}

		public void ExpandZone(string areaID)
		{
			this.areaID = areaID;
			OnClickAssignOrder(4194304);
			UpdateInfoCursorZoneModification();
		}

		public void ShrinkZone(string areaID)
		{
			this.areaID = areaID;
			OnClickAssignOrder(8388608);
			UpdateInfoCursorZoneModification();
		}

		public void OnRightMouseUp()
		{
			DeselectTool();
		}

		public void DeselectTool()
		{
			ResetSelectionTool();
			this.RightMouseUpResetOrderEvent?.Invoke();
		}

		private void Start()
		{
			MonoSingleton<SceneController>.Instance.Tick += OnTick;
			SetupMouseUpActions();
			layerUI = LayerMask.NameToLayer("UI");
			voxelMapLayer = 1 << LayerMask.NameToLayer("VoxelMap");
			buildableSurfaceLayer = 1 << LayerMask.NameToLayer("BuildableSurface");
			raycastPlaneHelperLayer = 1 << LayerMask.NameToLayer("RaycastPlaneHelper");
			selectable = 1 << LayerMask.NameToLayer("Selectable");
			MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent += OnChangeBuildingTypeToPlace;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= OnTick;
			}
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent -= OnChangeBuildingTypeToPlace;
			}
			base.OnDestroy();
			this.SelectionFinishedEvent = null;
			this.OrderResourceCollectionEvent = null;
			this.OrderDeconstructionEvent = null;
			this.OrderChopEvent = null;
			this.AllowOrForbidEvent = null;
			this.UrgentHaulEvent = null;
			this.SelectionHighlightEvent = null;
			this.SelectionChopEvent = null;
			this.SelectionDeconstructHighlightEvent = null;
			this.SelectionDrag = null;
			this.ZoneSelectionDrag = null;
			this.ZoneSelectionPlace = null;
			this.SetFillColorEvent = null;
			this.ResetFillColorEvent = null;
			this.ForceOrderOnResourceEvent = null;
			this.AssignOrderEvent = null;
			this.ResetOrderEvent = null;
			this.RightMouseUpResetOrderEvent = null;
		}

		private void SelectionFinished()
		{
			this.SelectionFinishedEvent?.Invoke();
		}

		private static void ClampPositionMapEdge(ref Vec3Int position)
		{
			if (!World.AllowEdgePlacement)
			{
				int max = GridDataIndexTools.SizeX - 16 - 1;
				int max2 = GridDataIndexTools.SizeZ - 16 - 1;
				position.x = Mathf.Clamp(position.x, 16, max);
				position.z = Mathf.Clamp(position.z, 16, max2);
			}
		}

		private void SetSelectionMode(OrderType orderType)
		{
			if (orderSelectionMode.ContainsKey(orderType))
			{
				selectionMode = orderSelectionMode[orderType];
			}
			else
			{
				selectionMode = defaultSelectionMode;
			}
		}

		private void OnChangeBuildingTypeToPlace()
		{
			ResetSelectionTool(fireEvent: false);
		}

		private void OnTick(float deltaTime)
		{
			using (ProfilerSampleJanitor.Begin("SelectionManager.Tick"))
			{
				if (!CanSelect || selecting)
				{
					return;
				}
				bool flag = false;
				if (OrderType == OrderType.Digging)
				{
					flag = ShowSelectedSlopes(startPoint, startPoint);
				}
				startPoint = GetMouseWorldPosition(out var _);
				endPoint = startPoint;
				if (!flag)
				{
					GameObject selectionObject = ((selectionMode == SelectionMode.VoxelSelect) ? selectionVolume : selectionGrid);
					SetupSelectionObject(startPoint, endPoint, selectionObject, selectionMode == SelectionMode.FloorSelect);
					if ((OrderType & OrderType.Digging) != OrderType.None)
					{
						Vec3Int gridPosition = new Vec3Int(startPoint.x, startPoint.y / World.MapBlockHeight - 1, startPoint.z);
						if (!MonoSingleton<GroundManager>.Instance.ShowDigInfoCursor(gridPosition))
						{
							selectionVolume.SetActive(value: false);
							selectionGrid.SetActive(value: false);
						}
					}
				}
				else
				{
					selectionVolume.SetActive(value: false);
					selectionGrid.SetActive(value: false);
				}
			}
		}

		private void CheckForNonDragSelection()
		{
			if (!(startPoint != endPoint) && selectionMode != SelectionMode.VoxelSelect && Physics.Raycast(layerMask: (AreaOrderType != AreaType.Stockpile && AreaOrderType != AreaType.Crops) ? (1 << LayerMask.NameToLayer("Selectable")) : raycastMask, ray: ray, hitInfo: out hit, maxDistance: float.PositiveInfinity) && !(hit.transform == null))
			{
				Vec3Int vec3Int = hit.point.ToGridVec3Int(0.01f);
				vec3Int.y = (int)raycastHeplerPlane.transform.position.y;
				startPoint = vec3Int;
				endPoint = vec3Int;
			}
		}

		private Vec3Int GetClickedGameObjectPosition()
		{
			Vec3Int result = Vec3Int.down;
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			raycastMask = voxelMapLayer | buildableSurfaceLayer | raycastPlaneHelperLayer | selectable;
			if (Physics.Raycast(ray, out hit, float.PositiveInfinity, raycastMask))
			{
				result = hit.transform.position.SnapToGridVec3Int(0.01f);
			}
			return result;
		}

		private Vec3Int GetMouseWorldPosition(out Vector3 normalOut)
		{
			normalOut = Vector3.one;
			if (!MonoSingleton<CameraManager>.IsInstantiated() || MonoSingleton<CameraManager>.Instance.GameplayCamera == null)
			{
				return Vec3Int.down;
			}
			ray = MonoSingleton<CameraManager>.Instance.GameplayCamera.ScreenPointToRay(Input.mousePosition);
			raycastMask = voxelMapLayer | buildableSurfaceLayer | raycastPlaneHelperLayer;
			if (!Physics.Raycast(ray, out hit, float.PositiveInfinity, raycastMask))
			{
				return Vec3Int.down;
			}
			normalOut = hit.normal;
			Vec3Int result = Vec3Int.down;
			if (selectionMode == SelectionMode.FloorSelect)
			{
				hitSide = CalculateSide(hit);
				result = hit.point.SnapToGridVec3Int(0.01f);
				if (hitSide == ObjectSide.Left)
				{
					return result + new Vec3Int(-1, 0, 0);
				}
				if (hitSide == ObjectSide.Right)
				{
					return result;
				}
				if (hitSide == ObjectSide.Front)
				{
					return result;
				}
				if (hitSide == ObjectSide.Back)
				{
					return result + new Vec3Int(0, 0, -1);
				}
				_ = hitSide;
				_ = 2;
				return result;
			}
			if (selectionMode == SelectionMode.VoxelSelect)
			{
				float num = (int)(hit.point.y / (float)World.MapBlockHeight - hit.normal.y / 2f + 0.999f);
				float num2 = (int)(hit.point.x + 0.5f - hit.normal.x / 2f);
				float num3 = (int)(hit.point.z + 0.5f - hit.normal.z / 2f);
				result = new Vec3Int((int)num2, (int)(num * (float)World.MapBlockHeight), (int)num3);
			}
			return result;
		}

		private ObjectSide CalculateSide(RaycastHit hit)
		{
			float num = Vector3.Dot(hit.normal, hit.transform.up);
			float num2 = Vector3.Dot(hit.normal, hit.transform.forward);
			float num3 = Vector3.Dot(hit.normal, hit.transform.right);
			if (num2 < -0.99f)
			{
				return ObjectSide.Back;
			}
			if (num2 > 0.99f)
			{
				return ObjectSide.Front;
			}
			if (num3 < -0.99f)
			{
				return ObjectSide.Left;
			}
			if (num3 > 0.99f)
			{
				return ObjectSide.Right;
			}
			if (num > 0.99f)
			{
				return ObjectSide.Top;
			}
			return ObjectSide.Bottom;
		}

		private void DrawSelection()
		{
			Transform obj = base.transform;
			obj.position = Vector3.zero;
			obj.localScale = Vector3.one;
			selectionGrid.transform.position = (Vector3)startPoint + new Vector3(-0.5f, 0.04f, -0.5f);
			bool num = OrderType == OrderType.Digging || OrderType == OrderType.Cancel;
			bool flag = false;
			if (num)
			{
				flag = ShowSelectedSlopes(startPoint, endPoint);
			}
			if (!startPoint.Equals(endPoint) || !flag)
			{
				GameObject selectionObject = ((selectionMode == SelectionMode.VoxelSelect) ? selectionVolume : selectionGrid);
				SetupSelectionObject(startPoint, endPoint, selectionObject, selectionMode == SelectionMode.FloorSelect);
			}
			if (AreaOrderType == AreaType.Stockpile || AreaOrderType == AreaType.Crops)
			{
				UpdateInfoCursor();
			}
		}

		private void ClearSelectedSlopes()
		{
			foreach (SlopeInstance selectedSlope in selectedSlopes)
			{
				selectedSlope.SetHovering(isHovering: false);
			}
			selectedSlopes.Clear();
		}

		private bool ShowSelectedSlopes(Vec3Int start, Vec3Int end)
		{
			ClearSelectedSlopes();
			Vec3Int vec3Int = start.Min(end);
			Vec3Int vec3Int2 = start.Max(end);
			int num = start.y / World.MapBlockHeight - 1;
			if (num > 0)
			{
				MonoSingleton<SlopeManager>.Instance.GetSlopesInRange(num, vec3Int.x, vec3Int2.x, vec3Int.z, vec3Int2.z, ref selectedSlopes);
				foreach (SlopeInstance selectedSlope in selectedSlopes)
				{
					selectedSlope.SetHovering(isHovering: true);
				}
			}
			return selectedSlopes.Count > 0;
		}

		private float Floor(float val)
		{
			return val - val % 1f;
		}

		private float Ceil(float val)
		{
			return Floor(val) + 1f;
		}

		private void SetupSelectionObject(Vec3Int startPoint, Vec3Int endPoint, GameObject selectionObject, bool useStartSelectionY)
		{
			float num = 0.01f;
			Vector3 vector = new Vector3(Floor(Mathf.Min(startPoint.x, endPoint.x)) - num, Floor(Mathf.Min(startPoint.y, endPoint.y)) - num, Floor(Mathf.Min(startPoint.z, endPoint.z)) - num);
			Vector3 vector2 = new Vector3(Ceil(Mathf.Max(startPoint.x, endPoint.x)) + num, Ceil(Mathf.Max(startPoint.y, endPoint.y)), Ceil(Mathf.Max(startPoint.z, endPoint.z)) + num);
			if (useStartSelectionY)
			{
				vector.y = (vector2.y = (float)startPoint.y + 0.5f);
			}
			selectionObject.SetActive(value: true);
			selectionObject.transform.localPosition = (vector + vector2) / 2f - new Vector3(0.5f, (float)(World.MapBlockHeight / 2) - num - 0.5f, 0.5f);
			Vector3 localScale = vector2 - vector;
			localScale.y = Mathf.Max(1f, localScale.y);
			selectionObject.transform.localScale = localScale;
		}

		private void SetupMouseUpActions()
		{
			mouseUpActions.Add(OrderType.Cancel, OnOrderCancel);
			mouseUpActions.Add(OrderType.CutAllVegetation, OnGiveOrder);
			mouseUpActions.Add(OrderType.Deconstructing, OnOrderDeconstruction);
			mouseUpActions.Add(OrderType.Chopping, OnChopOrder);
			mouseUpActions.Add(OrderType.Harvesting, OnGiveOrder);
			mouseUpActions.Add(OrderType.Hunting, OnGiveOrder);
			mouseUpActions.Add(OrderType.Fishing, OnGiveOrder);
			mouseUpActions.Add(OrderType.Allow, OnOrderAllowForbid);
			mouseUpActions.Add(OrderType.Forbid, OnOrderAllowForbid);
			mouseUpActions.Add(OrderType.Digging, OnOrderDigVoxel);
			mouseUpActions.Add(OrderType.UrgentHaul, OnOrderUrgentHaul);
			mouseUpActions.Add(OrderType.ExpandZone, OnModifyZone);
			mouseUpActions.Add(OrderType.ShrinkZone, OnModifyZone);
			mouseUpActions.Add(OrderType.None, OnAreaOrderTempHack);
			orderSelectionMode.Add(OrderType.Digging, SelectionMode.VoxelSelect);
		}

		private void OnAreaOrderTempHack()
		{
			if (AreaOrderType != AreaType.None)
			{
				switch (AreaOrderType)
				{
				case AreaType.Stockpile:
					OnAssignStockpileArea();
					break;
				case AreaType.Crops:
					OnAssignCropsArea();
					break;
				}
			}
		}

		private void OnOrderDigVoxel()
		{
			MonoSingleton<GroundManager>.Instance.OrderDigVoxel(startPoint, endPoint);
			OnGiveOrder();
		}

		private void RefreshPositionsInSelectedSlopes()
		{
			positionsInSelectedSlopes.Clear();
			Vec3Int vec3Int = startPoint.Min(endPoint);
			Vec3Int vec3Int2 = startPoint.Max(endPoint);
			foreach (SlopeInstance item in MonoSingleton<SlopeManager>.Instance.EnumerateSlopesInRange(startPoint.y / World.MapBlockHeight - 1, vec3Int.x, vec3Int2.x, vec3Int.z, vec3Int2.z))
			{
				foreach (Vec3Int position in item.Positions)
				{
					if (!positionsInSelectedSlopes.Contains(position))
					{
						positionsInSelectedSlopes.Add(position);
					}
				}
			}
		}

		private void OnGiveOrder()
		{
			Vec3Int input = startPoint.Min(endPoint);
			Vec3Int input2 = startPoint.Max(endPoint);
			RefreshPositionsInSelectedSlopes();
			OrderEventData obj;
			if (startPoint.Equals(endPoint))
			{
				Vec3Int clickedGameObjectPosition = GetClickedGameObjectPosition();
				obj = new OrderEventData(clickedGameObjectPosition.y, clickedGameObjectPosition.ToVector2XZ(), clickedGameObjectPosition.ToVector2XZ(), OrderType, affectOnlyOneLayer: true, orderAllowType);
			}
			else
			{
				obj = new OrderEventData(startPoint.y, input.ToVector2XZ(), input2.ToVector2XZ(), OrderType, affectOnlyOneLayer);
			}
			this.OrderResourceCollectionEvent?.Invoke(obj);
		}

		private void OnChopOrder()
		{
			Vec3Int input = startPoint.Min(endPoint);
			Vec3Int input2 = startPoint.Max(endPoint);
			RefreshPositionsInSelectedSlopes();
			PlantOrderEventData obj;
			if (startPoint.Equals(endPoint))
			{
				Vec3Int clickedGameObjectPosition = GetClickedGameObjectPosition();
				obj = new PlantOrderEventData(clickedGameObjectPosition.y, clickedGameObjectPosition.ToVector2XZ(), clickedGameObjectPosition.ToVector2XZ(), OrderType, affectOnlyOneLayer: true, plantLifePhaseType, orderAllowType);
			}
			else
			{
				obj = new PlantOrderEventData(startPoint.y, input.ToVector2XZ(), input2.ToVector2XZ(), OrderType, affectOnlyOneLayer, plantLifePhaseType, orderAllowType);
			}
			this.OrderChopEvent?.Invoke(obj);
		}

		private void OnOrderCancel()
		{
			Vec3Int input = startPoint.Min(endPoint);
			Vec3Int input2 = startPoint.Max(endPoint);
			RefreshPositionsInSelectedSlopes();
			OrderEventData orderEventData;
			BuildingOrderEventData obj;
			OrderEventData obj2;
			if (startPoint.Equals(endPoint))
			{
				Vec3Int clickedGameObjectPosition = GetClickedGameObjectPosition();
				orderEventData = new OrderEventData(clickedGameObjectPosition.y, clickedGameObjectPosition.ToVector2XZ(), clickedGameObjectPosition.ToVector2XZ(), OrderType.Cancel, affectOnlyOneLayer: true, orderAllowType);
				obj = new BuildingOrderEventData(orderEventData, buildingTypesToDeconstruct, orderAllowType);
				obj2 = new OrderEventData(clickedGameObjectPosition.y, clickedGameObjectPosition.ToVector2XZ(), clickedGameObjectPosition.ToVector2XZ(), OrderType.Cancel, affectOnlyOneLayer: true);
			}
			else
			{
				orderEventData = new OrderEventData(startPoint.y, input.ToVector2XZ(), input2.ToVector2XZ(), OrderType.Cancel, affectOnlyOneLayer);
				obj = new BuildingOrderEventData(orderEventData, buildingTypesToDeconstruct, orderAllowType);
				obj2 = new OrderEventData(startPoint.y, input.ToVector2XZ(), input2.ToVector2XZ(), OrderType.Cancel, affectOnlyOneLayer);
			}
			this.OrderResourceCollectionEvent?.Invoke(orderEventData);
			this.OrderDeconstructionEvent?.Invoke(obj);
			this.UrgentHaulEvent?.Invoke(obj2);
		}

		private void OnOrderDeconstruction()
		{
			Vec3Int input = startPoint.Min(endPoint);
			Vec3Int input2 = startPoint.Max(endPoint);
			RefreshPositionsInSelectedSlopes();
			BuildingOrderEventData obj;
			if (startPoint.Equals(endPoint))
			{
				Vec3Int clickedGameObjectPosition = GetClickedGameObjectPosition();
				obj = new BuildingOrderEventData(clickedGameObjectPosition.y, clickedGameObjectPosition.ToVector2XZ(), clickedGameObjectPosition.ToVector2XZ(), OrderType, affectOnlyOneLayer: true, buildingTypesToDeconstruct, orderAllowType);
			}
			else
			{
				obj = new BuildingOrderEventData(startPoint.y, input.ToVector2XZ(), input2.ToVector2XZ(), OrderType, affectOnlyOneLayer, buildingTypesToDeconstruct, orderAllowType);
			}
			this.OrderDeconstructionEvent?.Invoke(obj);
		}

		private void OnOrderAllowForbid()
		{
			Vec3Int input = startPoint.Min(endPoint);
			Vec3Int input2 = startPoint.Max(endPoint);
			RefreshPositionsInSelectedSlopes();
			OrderEventData obj = new OrderEventData(startPoint.y, input.ToVector2XZ(), input2.ToVector2XZ(), OrderType, affectOnlyOneLayer, orderAllowType);
			this.AllowOrForbidEvent?.Invoke(obj);
		}

		private void OnOrderUrgentHaul()
		{
			Vec3Int input = startPoint.Min(endPoint);
			Vec3Int input2 = startPoint.Max(endPoint);
			RefreshPositionsInSelectedSlopes();
			OrderEventData obj = new OrderEventData(startPoint.y, input.ToVector2XZ(), input2.ToVector2XZ(), OrderType, affectOnlyOneLayer);
			this.UrgentHaulEvent?.Invoke(obj);
		}

		private void OnAssignCropsArea()
		{
			Vec3Int position = startPoint;
			Vec3Int position2 = endPoint;
			if (GridDataIndexTools.IsForbiddenEdge(position) && GridDataIndexTools.IsForbiddenEdge(position2))
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("cannot_plant_on_edge"));
				return;
			}
			ClampPositionMapEdge(ref position);
			ClampPositionMapEdge(ref position2);
			if (!position.Equals(startPoint) || !position2.Equals(endPoint))
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("cannot_plant_on_edge"));
			}
			if (GridDataIndexTools.IsTopLayer(position.y / World.MapBlockHeight) || GridDataIndexTools.IsTopLayer(position2.y / World.MapBlockHeight))
			{
				MonoSingleton<GroundManager>.Instance.ShowBlackBarTextCantBuildTopLayer();
			}
			MonoSingleton<CropsController>.Instance.CreateCropfield(position, position2, areaID);
		}

		private void ShowActionInfo()
		{
			if (OrderType == OrderType.None)
			{
				AreaType areaOrderType = AreaOrderType;
				if (areaOrderType == AreaType.Stockpile || areaOrderType == AreaType.Crops)
				{
					UIController.ShowActionInfo(new List<string>
					{
						ActionInfoUtils.PlaceRow,
						ActionInfoUtils.Dismiss
					});
					return;
				}
			}
			UIController.ShowActionInfo(ActionInfoUtils.GetOrderInfos(OrderType));
		}

		private void OnAssignStockpileArea()
		{
			Vec3Int position = startPoint;
			Vec3Int position2 = endPoint;
			if (GridDataIndexTools.IsForbiddenEdge(position) && GridDataIndexTools.IsForbiddenEdge(position2))
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("cannot_place_stockpile_on_edge"));
				return;
			}
			ClampPositionMapEdge(ref position);
			ClampPositionMapEdge(ref position2);
			if (!position.Equals(startPoint) || !position2.Equals(endPoint))
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("cannot_place_stockpile_on_edge"));
			}
			if (GridDataIndexTools.IsTopLayer(position.y / World.MapBlockHeight) || GridDataIndexTools.IsTopLayer(position2.y / World.MapBlockHeight))
			{
				MonoSingleton<GroundManager>.Instance.ShowBlackBarTextCantBuildTopLayer();
			}
			else
			{
				MonoSingleton<StockpileManager>.Instance.SpawnStockpile(Repository<StockpileRepository, Stockpile>.Instance.GetByID(UIController.StockpileBlueprint), position, position2);
			}
		}

		private void OnModifyZone()
		{
			Vec3Int position = startPoint;
			Vec3Int position2 = endPoint;
			ClampPositionMapEdge(ref position);
			ClampPositionMapEdge(ref position2);
			if (!position.Equals(startPoint) || !position2.Equals(endPoint))
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("cannot_place_stockpile_on_edge"));
			}
			if (GridDataIndexTools.IsTopLayer(position.y / World.MapBlockHeight) || GridDataIndexTools.IsTopLayer(position2.y / World.MapBlockHeight))
			{
				MonoSingleton<GroundManager>.Instance.ShowBlackBarTextCantBuildTopLayer();
				return;
			}
			MonoSingleton<StockpileManager>.Instance.ModifyStockpile(position, position2, OrderType);
			MonoSingleton<CropsManager>.Instance.ModifyCropfield(position, position2, OrderType);
		}

		private void UpdateInfoCursor()
		{
			Vec3Int position = startPoint;
			Vec3Int position2 = endPoint;
			ClampPositionMapEdge(ref position);
			ClampPositionMapEdge(ref position2);
			localizedInfoCursorData.Clear();
			string localizedName = BuildingUtils.GetLocalizedName(areaID);
			localizedInfoCursorData.Add(localizedName);
			int num = Mathf.Abs(position.x - position2.x) + 1;
			int num2 = Mathf.Abs(position.z - position2.z) + 1;
			localizedInfoCursorData.Add($"{num} x {num2}");
			if (AreaOrderType.Equals(AreaType.Crops) && cropfieldBlueprint != null && CropsManager.UseSeeds)
			{
				int num3 = num * num2;
				Resource seedBlueprint = cropfieldBlueprint.SeedBlueprint;
				string text = num3.ToString();
				string text2 = string.Empty;
				if (MonoSingleton<ResourcePileTracker>.Instance.GetCount(seedBlueprint).AllowedCount < num3)
				{
					text = $"<style=DefaultRed>{num3}</style>";
					text2 = MonoSingleton<LocalizationController>.Instance.GetText("cropfield_error_no_seeds") ?? "";
				}
				localizedInfoCursorData.Add(ResourceUtils.GetTextIcon(seedBlueprint) + " " + text + " " + ResourceUtils.GetLocalizedResourceName(seedBlueprint.GetID()));
				if (!text2.Equals(string.Empty))
				{
					localizedInfoCursorData.Add(ColorUtils.ColorText(text2, "red") ?? "");
				}
			}
			UIController.ToggleInfoCursor(active: true);
			UIController.UpdateInfoCursorContent(localizedInfoCursorData);
		}

		private void UpdateInfoCursorZoneModification()
		{
			localizedInfoCursorData.Clear();
			string localizedName = BuildingUtils.GetLocalizedName(areaID);
			string item = ((!OrderType.Equals(OrderType.ExpandZone)) ? MonoSingleton<LocalizationController>.Instance.GetText("shrink_zone").Replace("{zone}", localizedName) : MonoSingleton<LocalizationController>.Instance.GetText("expand_zone").Replace("{zone}", localizedName));
			localizedInfoCursorData.Add(item);
			UIController.ToggleInfoCursor(active: true);
			UIController.UpdateInfoCursorContent(localizedInfoCursorData);
		}
	}
}
