using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using NSEipix.Base;
using NSMedieval.Fire;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Map;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace NSMedieval.Water.DebugUI
{
	public class WaterDebugUI : MonoBehaviour
	{
		private enum DrawMode
		{
			Water = 0,
			Obstacle = 1,
			FillWater = 2,
			RefreshObstacle = 3,
			WaterFlowIn = 4,
			WaterFlowOut = 5,
			FireDraw = 6,
			GreekFireDraw = 7,
			OilBlobDraw = 8,
			GreekFireOilBlobDraw = 9
		}

		private static GameObject gameObjectInstance;

		[SerializeField]
		private Toggle enableDrawWater;

		[SerializeField]
		private Toggle toggleFlowInOutDebug;

		[SerializeField]
		private Toggle toggleFlowInOutCameraJump;

		[SerializeField]
		private Toggle toggleRiverDebugNodes;

		[SerializeField]
		private Button drawWaterButton;

		[SerializeField]
		private Button fillWaterButton;

		[SerializeField]
		private Button waterFlowInButton;

		[SerializeField]
		private Button waterFlowOutButton;

		[SerializeField]
		private Button drawObstacleButton;

		[SerializeField]
		private Button tickWaterSimButton;

		[SerializeField]
		private Button refreshAllObstaclesButton;

		[SerializeField]
		private Button clearAllWaterButton;

		[SerializeField]
		private Button clearFlowInButton;

		[SerializeField]
		private Button clearFireButton;

		[SerializeField]
		private Toggle toggleFireSim;

		[SerializeField]
		private Toggle toggleRenderFire;

		[SerializeField]
		private Button visualizeDebugObstaclesButton;

		[SerializeField]
		private Button hideDebugObstaclesButton;

		[SerializeField]
		private Button drawFireButton;

		[SerializeField]
		private Button drawGreekFireButton;

		[SerializeField]
		private Button drawOilBlobButton;

		[SerializeField]
		private Button drawGreekFireOilBlobButton;

		[SerializeField]
		private GameObject selectedVoxel;

		[SerializeField]
		private Slider layerOffsetSlider;

		[SerializeField]
		private GameObject obstaclesDebugGameObject;

		[SerializeField]
		private TMP_Text generalInfo;

		[SerializeField]
		private TMP_Text waterInfo;

		[SerializeField]
		private TMP_Text fireInfo;

		[SerializeField]
		private TMP_InputField waterLevelInputField;

		[SerializeField]
		private Toggle toggleWaterSim;

		[SerializeField]
		private Toggle toggleWaterClamp;

		[SerializeField]
		private Button backupWaterStateButton;

		[SerializeField]
		private Button restoreWaterStateButton;

		[SerializeField]
		private Toggle toggleShowWaterMesh;

		[SerializeField]
		private TMP_Dropdown fireDebugDropdown;

		private StringBuilder generalInfoStringBuilder;

		private StringBuilder waterInfoStringBuilder;

		private StringBuilder fireInfoStringBuilder;

		private WaterManager waterManager;

		private FireSimLogic fireSimLogic;

		private FireMeshLogic fireMeshLogic;

		[NonSerialized]
		private VillageMap map;

		private int yAdd;

		private float setWaterLevel = 1f;

		private DrawMode drawMode;

		private List<int> trianglesObstacle;

		private List<Vector3> verticesObstacle;

		private Mesh obstacleMesh;

		private bool drawEnabled;

		private bool isMouseDown;

		private float[] waterBackupData;

		private float[] flowInBackupData;

		private HashSet<int> flowInIndicesBackupData;

		private Vec3Int oldPos = Vec3Int.zero;

		public static bool IsDebugUIEnabled { get; private set; }

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			gameObjectInstance = null;
			IsDebugUIEnabled = false;
		}

		public static void ToggleActive()
		{
			if (!(gameObjectInstance == null))
			{
				IsDebugUIEnabled = !IsDebugUIEnabled;
				gameObjectInstance.SetActive(IsDebugUIEnabled);
			}
		}

		private void Start()
		{
			generalInfoStringBuilder = new StringBuilder();
			waterInfoStringBuilder = new StringBuilder();
			fireInfoStringBuilder = new StringBuilder();
			trianglesObstacle = new List<int>();
			verticesObstacle = new List<Vector3>();
			obstacleMesh = new Mesh();
			obstacleMesh.indexFormat = IndexFormat.UInt32;
			MonoSingleton<UIController>.Instance.HideUIToggleEvent += OnHideUIToggle;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
			gameObjectInstance = base.gameObject.transform.parent.gameObject;
			gameObjectInstance.SetActive(IsDebugUIEnabled);
		}

		private void OnEnable()
		{
			enableDrawWater.onValueChanged.RemoveAllListeners();
			enableDrawWater.onValueChanged.AddListener(OnEnableDrawWaterChanged);
			enableDrawWater.SetIsOnWithoutNotify(drawEnabled);
			OnEnableDrawWaterChanged(drawEnabled);
			toggleFlowInOutDebug.onValueChanged.RemoveAllListeners();
			toggleFlowInOutDebug.onValueChanged.AddListener(OnToggleFlowInOutDebug);
			toggleFlowInOutCameraJump.onValueChanged.RemoveAllListeners();
			toggleFlowInOutCameraJump.onValueChanged.AddListener(OnToggleFlowInOutCameraJump);
			toggleRiverDebugNodes.onValueChanged.RemoveAllListeners();
			toggleRiverDebugNodes.onValueChanged.AddListener(OnToggleRiverDebugNodes);
			drawWaterButton.onClick.RemoveAllListeners();
			drawWaterButton.onClick.AddListener(OnDrawWaterButtonClick);
			drawObstacleButton.onClick.RemoveAllListeners();
			drawObstacleButton.onClick.AddListener(OnDrawObstacleButtonClick);
			fillWaterButton.onClick.RemoveAllListeners();
			fillWaterButton.onClick.AddListener(OnFillWaterButtonClick);
			waterFlowInButton.onClick.RemoveAllListeners();
			waterFlowInButton.onClick.AddListener(OnWaterFlowInButtonClick);
			waterFlowOutButton.onClick.RemoveAllListeners();
			waterFlowOutButton.onClick.AddListener(OnWaterFlowOutButtonClick);
			tickWaterSimButton.onClick.RemoveAllListeners();
			tickWaterSimButton.onClick.AddListener(OnTickWaterSimButtonClick);
			refreshAllObstaclesButton.onClick.RemoveAllListeners();
			refreshAllObstaclesButton.onClick.AddListener(OnRefreshAllObstaclesButtonClick);
			layerOffsetSlider.onValueChanged.RemoveAllListeners();
			layerOffsetSlider.onValueChanged.AddListener(OnLayerOffsetChanged);
			clearAllWaterButton.onClick.RemoveAllListeners();
			clearAllWaterButton.onClick.AddListener(OnClearAllWaterButtonClick);
			clearFlowInButton.onClick.RemoveAllListeners();
			clearFlowInButton.onClick.AddListener(OnClearFlowInButtonClick);
			clearFireButton.onClick.RemoveAllListeners();
			clearFireButton.onClick.AddListener(OnClearFireButtonClick);
			visualizeDebugObstaclesButton.onClick.RemoveAllListeners();
			visualizeDebugObstaclesButton.onClick.AddListener(OnVisualizeObstaclesButtonClick);
			hideDebugObstaclesButton.onClick.RemoveAllListeners();
			hideDebugObstaclesButton.onClick.AddListener(OnHideObstaclesButtonClick);
			drawFireButton.onClick.RemoveAllListeners();
			drawFireButton.onClick.AddListener(OnDrawFireButtonClick);
			drawGreekFireButton.onClick.RemoveAllListeners();
			drawGreekFireButton.onClick.AddListener(OnDrawGreekFireButtonClick);
			drawOilBlobButton.onClick.RemoveAllListeners();
			drawOilBlobButton.onClick.AddListener(OnDrawOilBlobButtonClick);
			drawGreekFireOilBlobButton.onClick.RemoveAllListeners();
			drawGreekFireOilBlobButton.onClick.AddListener(OnDrawGreekFireOilBlobButtonClick);
			backupWaterStateButton.onClick.RemoveAllListeners();
			backupWaterStateButton.onClick.AddListener(OnBackupWaterStateButtonClick);
			restoreWaterStateButton.onClick.RemoveAllListeners();
			restoreWaterStateButton.onClick.AddListener(OnRestoreWaterStateButtonClick);
			waterLevelInputField.onValueChanged.RemoveAllListeners();
			waterLevelInputField.onValueChanged.AddListener(OnSetWaterLevelSliderChanged);
			waterLevelInputField.SetTextWithoutNotify(setWaterLevel.ToString(CultureInfo.InvariantCulture));
			toggleWaterSim.onValueChanged.RemoveAllListeners();
			toggleWaterSim.onValueChanged.AddListener(OnToggleWaterSimChanged);
			toggleWaterClamp.onValueChanged.RemoveAllListeners();
			toggleWaterClamp.onValueChanged.AddListener(OnToggleClampChanged);
			toggleShowWaterMesh.onValueChanged.RemoveAllListeners();
			toggleShowWaterMesh.onValueChanged.AddListener(OnToggleShowWaterMeshChanged);
			toggleFireSim.onValueChanged.RemoveAllListeners();
			toggleFireSim.onValueChanged.AddListener(OnToggleFireSimChanged);
			toggleRenderFire.onValueChanged.RemoveAllListeners();
			toggleRenderFire.onValueChanged.AddListener(OnToggleRenderFireChanged);
			fireDebugDropdown.onValueChanged.RemoveAllListeners();
			List<string> list = new List<string>();
			foreach (object value in Enum.GetValues(typeof(FireMeshLogic.DebugDrawMode)))
			{
				list.Add(value.ToString());
			}
			fireDebugDropdown.ClearOptions();
			fireDebugDropdown.AddOptions(list);
			fireDebugDropdown.value = 0;
			fireDebugDropdown.onValueChanged.AddListener(OnFireDebugDropDownChanged);
		}

		private void OnDestroy()
		{
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.HideUIToggleEvent -= OnHideUIToggle;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			generalInfoStringBuilder.Clear();
			waterInfoStringBuilder.Clear();
			fireInfoStringBuilder.Clear();
			trianglesObstacle.Clear();
			verticesObstacle.Clear();
			waterManager = null;
			fireSimLogic = null;
			fireMeshLogic = null;
			map = null;
		}

		private void OnEnableDrawWaterChanged(bool value)
		{
			drawObstacleButton.interactable = value;
			drawWaterButton.interactable = value;
			fillWaterButton.interactable = value;
			waterFlowInButton.interactable = value;
			waterFlowOutButton.interactable = value;
			drawEnabled = value;
		}

		private void OnToggleFlowInOutDebug(bool value)
		{
			WaterDebugDrawLogic.FlowInFlowOutDebugRenderEnabled = value;
		}

		private void OnToggleFlowInOutCameraJump(bool value)
		{
			WaterDebugDrawLogic.SnapCameraToFlowChangePosition = value;
		}

		private void OnToggleRiverDebugNodes(bool value)
		{
			WaterDebugDrawLogic.DebugRenderRiverOriginalPositions = value;
		}

		private void OnToggleWaterSimChanged(bool enabled)
		{
			waterManager.WaterSimEnabled = enabled;
		}

		private void OnToggleFireSimChanged(bool enabled)
		{
			fireSimLogic.FireSimEnabled = enabled;
		}

		private void OnToggleRenderFireChanged(bool enabled)
		{
			fireMeshLogic.RenderEnabled = enabled;
		}

		private void OnToggleClampChanged(bool enabled)
		{
			waterManager.DebugClampWaterLevel = enabled;
		}

		private void OnToggleShowWaterMeshChanged(bool enabled)
		{
			waterManager.DebugToggleShowWaterMesh = enabled;
		}

		private void OnFireDebugDropDownChanged(int index)
		{
			fireMeshLogic.DebugDraw = (FireMeshLogic.DebugDrawMode)index;
		}

		private void OnSetWaterLevelSliderChanged(string inputText)
		{
			if (float.TryParse(inputText, out var result))
			{
				setWaterLevel = result;
			}
		}

		private void OnHideObstaclesButtonClick()
		{
			obstaclesDebugGameObject.SetActive(value: false);
		}

		private void OnHideUIToggle(bool isHidden)
		{
			if (!(gameObjectInstance == null))
			{
				gameObjectInstance.SetActive(IsDebugUIEnabled && !isHidden);
			}
		}

		private void OnMapLoaded(bool wasloadedfromsave)
		{
			VillageMap villageMap = VillageManager.ActiveVillage.Map;
			map = villageMap;
			waterManager = map.WaterManager;
			fireSimLogic = map.FireSimLogic;
			fireMeshLogic = map.FireMeshLogic;
			toggleWaterSim.SetIsOnWithoutNotify(waterManager.WaterSimEnabled);
			toggleWaterClamp.SetIsOnWithoutNotify(waterManager.DebugClampWaterLevel);
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			toggleFlowInOutDebug.SetIsOnWithoutNotify(WaterDebugDrawLogic.FlowInFlowOutDebugRenderEnabled);
			toggleFlowInOutCameraJump.SetIsOnWithoutNotify(WaterDebugDrawLogic.SnapCameraToFlowChangePosition);
			toggleRiverDebugNodes.SetIsOnWithoutNotify(WaterDebugDrawLogic.DebugRenderRiverOriginalPositions);
		}

		private void OnBackupWaterStateButtonClick()
		{
			if (waterBackupData == null)
			{
				waterBackupData = new float[waterManager.WaterSimLogic.DataLength];
			}
			if (flowInBackupData == null)
			{
				flowInBackupData = new float[waterManager.WaterSimLogic.DataLength];
			}
			if (flowInIndicesBackupData == null)
			{
				flowInIndicesBackupData = new HashSet<int>();
			}
			Array.Copy(waterManager.WaterSimLogic.WaterData, waterBackupData, waterBackupData.Length);
			Array.Copy(waterManager.WaterSimLogic.FlowInData, flowInBackupData, flowInBackupData.Length);
			flowInIndicesBackupData.Clear();
			flowInIndicesBackupData.UnionWith(waterManager.WaterSimLogic.WaterFlowIn);
		}

		private void OnRestoreWaterStateButtonClick()
		{
			if (flowInIndicesBackupData != null && flowInIndicesBackupData.Count != 0)
			{
				if (waterBackupData != null)
				{
					Array.Copy(waterBackupData, waterManager.WaterSimLogic.WaterData, waterBackupData.Length);
				}
				if (flowInBackupData != null)
				{
					Array.Copy(flowInBackupData, waterManager.WaterSimLogic.FlowInData, flowInBackupData.Length);
				}
				waterManager.WaterSimLogic.WaterFlowIn.Clear();
				waterManager.WaterSimLogic.WaterFlowIn.UnionWith(flowInIndicesBackupData);
				waterManager.TickWater(tickWater: false, createMesh: true, prepareWaterDisplayData: true);
			}
		}

		private void OnVisualizeObstaclesButtonClick()
		{
			obstaclesDebugGameObject.SetActive(value: true);
			float[] heightPerValue = new float[4] { 0f, 1f, 0.5f, 0.1f };
			WaterMeshLogic.GenerateDebugMeshDataInt(waterManager.WaterSimLogic.ObstacleData, heightPerValue, verticesObstacle, trianglesObstacle);
			obstacleMesh.Clear();
			obstacleMesh.SetVertices(verticesObstacle);
			obstacleMesh.SetTriangles(trianglesObstacle, 0);
			obstacleMesh.RecalculateNormals();
			obstacleMesh.RecalculateTangents();
			obstaclesDebugGameObject.GetComponent<MeshFilter>().sharedMesh = obstacleMesh;
		}

		private void OnClearAllWaterButtonClick()
		{
			int dataLength = waterManager.WaterSimLogic.DataLength;
			for (int i = 0; i < dataLength; i++)
			{
				waterManager.WaterSimLogic.SetWaterAt(i, 0f);
			}
			waterManager.TickWater(tickWater: true, createMesh: true, prepareWaterDisplayData: true);
		}

		private void OnClearFlowInButtonClick()
		{
			int dataLength = waterManager.WaterSimLogic.DataLength;
			for (int i = 0; i < dataLength; i++)
			{
				waterManager.WaterSimLogic.SetFlowInAt(i, flowIn: false);
			}
			waterManager.TickWater(tickWater: true, createMesh: true, prepareWaterDisplayData: true);
		}

		private void OnClearFireButtonClick()
		{
			fireSimLogic.DebugClearAllFire();
		}

		private void OnLayerOffsetChanged(float value)
		{
			yAdd = (int)value;
		}

		private void OnTickWaterSimButtonClick()
		{
			waterManager.TickWater(tickWater: true, createMesh: true, prepareWaterDisplayData: true);
		}

		private void OnRefreshAllObstaclesButtonClick()
		{
			waterManager.SetObstacleFromMap();
			waterManager.TickWater(tickWater: false, createMesh: true, prepareWaterDisplayData: true);
		}

		private void OnDrawFireButtonClick()
		{
			drawMode = DrawMode.FireDraw;
		}

		private void OnDrawGreekFireButtonClick()
		{
			drawMode = DrawMode.GreekFireDraw;
		}

		private void OnDrawWaterButtonClick()
		{
			drawMode = DrawMode.Water;
		}

		private void OnDrawOilBlobButtonClick()
		{
			drawMode = DrawMode.OilBlobDraw;
		}

		private void OnDrawGreekFireOilBlobButtonClick()
		{
			drawMode = DrawMode.GreekFireOilBlobDraw;
		}

		private void OnDrawObstacleButtonClick()
		{
			drawMode = DrawMode.Obstacle;
		}

		private void OnFillWaterButtonClick()
		{
			drawMode = DrawMode.FillWater;
		}

		private void OnWaterFlowInButtonClick()
		{
			drawMode = DrawMode.WaterFlowIn;
		}

		private void OnWaterFlowOutButtonClick()
		{
			drawMode = DrawMode.WaterFlowOut;
		}

		private void OperationOnConnections(int startNodeIndex, Action<MapNode> operation)
		{
			MapNode mapNode = map.GridSpaceData[startNodeIndex];
			if (mapNode == null)
			{
				return;
			}
			using PooledQueue<MapNode> pooledQueue = QueuePool<MapNode>.GetJanitor();
			using PooledHashSet<MapNode> pooledHashSet = HashSetPool<MapNode>.GetJanitor();
			pooledQueue.Enqueue(mapNode);
			pooledHashSet.Add(mapNode);
			uint area = mapNode.Area;
			int y = GridDataIndexTools.GetY(startNodeIndex);
			while (pooledQueue.Count > 0)
			{
				MapNode mapNode2 = pooledQueue.Dequeue();
				if (mapNode2.VoxelType != null || mapNode2.Area != area)
				{
					continue;
				}
				operation?.Invoke(mapNode2);
				foreach (MapNode item in mapNode2.ConnectionsSafe)
				{
					if (item.Position.y == y && !pooledHashSet.Contains(item))
					{
						pooledHashSet.Add(item);
						pooledQueue.Enqueue(item);
					}
				}
			}
		}

		private void OperationOnWaterVolume(int startNodeIndex, Action<MapNode> operation)
		{
			MapNode mapNode = map.GridSpaceData[startNodeIndex];
			if (mapNode == null)
			{
				return;
			}
			using PooledQueue<MapNode> pooledQueue = QueuePool<MapNode>.GetJanitor();
			using PooledHashSet<MapNode> pooledHashSet = HashSetPool<MapNode>.GetJanitor();
			pooledQueue.Enqueue(mapNode);
			pooledHashSet.Add(mapNode);
			int y = GridDataIndexTools.GetY(startNodeIndex);
			while (pooledQueue.Count > 0)
			{
				MapNode mapNode2 = pooledQueue.Dequeue();
				if (!mapNode2.IsWater)
				{
					continue;
				}
				operation?.Invoke(mapNode2);
				foreach (MapNode item in mapNode2.ConnectionsSafe)
				{
					if (item.IsWater && item.Position.y == y && !pooledHashSet.Contains(item))
					{
						pooledHashSet.Add(item);
						pooledQueue.Enqueue(item);
					}
				}
			}
		}

		private void Update()
		{
			if (!MonoSingleton<PlayerVoxelInfo>.IsInstantiated() || !MonoSingleton<NSMedieval.WorldMap.WorldMap>.IsInstantiated() || !MonoSingleton<World>.Instance.IsLoaded || MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible || !MonoSingleton<InputManager>.IsInstantiated() || !MonoSingleton<InputManager>.Instance.InputEnabled || EventSystem.current.currentSelectedGameObject != null || waterManager == null)
			{
				return;
			}
			Vec3Int vec3Int = MonoSingleton<PlayerVoxelInfo>.Instance.HoverGridPosition + Vector3.up * yAdd;
			selectedVoxel.transform.position = GridUtils.GetWorldPosition(vec3Int);
			int num = GridDataIndexTools.FastTo1DIndex(vec3Int);
			if (num == -1)
			{
				return;
			}
			float y = 1f;
			if (drawMode == DrawMode.Water || drawMode == DrawMode.FireDraw || drawMode == DrawMode.FillWater || drawMode == DrawMode.GreekFireDraw)
			{
				y = setWaterLevel;
			}
			else if (drawMode == DrawMode.Obstacle)
			{
				y = 1f;
			}
			selectedVoxel.transform.localScale = new Vector3(1f, y, 1f);
			FillDebugWaterInfo(vec3Int);
			bool flag = Physics2D.Raycast(Input.mousePosition, Vector2.one, 0.01f);
			if (isMouseDown && !Input.GetMouseButton(0))
			{
				isMouseDown = false;
			}
			if (MonoSingleton<SelectionManager>.Instance.OrderType != OrderType.None || !MonoSingleton<InputManager>.Instance.InputEnabled || flag)
			{
				if (selectedVoxel.activeSelf)
				{
					selectedVoxel.SetActive(value: false);
				}
			}
			else if (Input.GetMouseButtonDown(0))
			{
				isMouseDown = true;
			}
			if (!Input.GetMouseButtonDown(0))
			{
				vec3Int.y = oldPos.y;
			}
			oldPos = vec3Int;
			if (!drawEnabled)
			{
				return;
			}
			if (!selectedVoxel.activeSelf)
			{
				selectedVoxel.SetActive(value: true);
			}
			if (isMouseDown)
			{
				if (drawMode == DrawMode.Water)
				{
					float waterLevel = setWaterLevel;
					if (Input.GetKey(KeyCode.LeftShift))
					{
						waterLevel = 0f;
					}
					if (Input.GetKey(KeyCode.LeftAlt))
					{
						OperationOnConnections(num, delegate(MapNode node)
						{
							waterManager.WaterSimLogic.SetWaterAt(node.Index, waterLevel);
						});
					}
					else
					{
						waterManager.WaterSimLogic.SetWaterAt(vec3Int.x, vec3Int.y, vec3Int.z, waterLevel);
					}
					waterManager.TickWater(tickWater: false, createMesh: true, prepareWaterDisplayData: true);
				}
				if (drawMode == DrawMode.WaterFlowIn)
				{
					bool flowIn = !Input.GetKey(KeyCode.LeftShift);
					if (Input.GetKey(KeyCode.RightAlt))
					{
						OperationOnWaterVolume(num, delegate(MapNode node)
						{
							if (node.IsEdge())
							{
								waterManager.WaterSimLogic.SetFlowInAt(node.Index, flowIn);
							}
						});
					}
					else if (Input.GetKey(KeyCode.LeftAlt))
					{
						OperationOnConnections(num, delegate(MapNode node)
						{
							if (node.IsEdge())
							{
								waterManager.WaterSimLogic.SetFlowInAt(node.Index, flowIn);
							}
						});
					}
					else
					{
						waterManager.WaterSimLogic.SetFlowInAt(num, flowIn);
					}
				}
				if (drawMode == DrawMode.WaterFlowOut)
				{
					bool flowIn2 = !Input.GetKey(KeyCode.LeftShift);
					if (Input.GetKey(KeyCode.RightAlt))
					{
						OperationOnWaterVolume(num, delegate(MapNode node)
						{
							if (node.IsEdge())
							{
								waterManager.WaterSimLogic.SetFlowOutAt(node.Index, flowIn2);
							}
						});
					}
					else if (Input.GetKey(KeyCode.LeftAlt))
					{
						OperationOnConnections(num, delegate(MapNode node)
						{
							if (node.IsEdge())
							{
								waterManager.WaterSimLogic.SetFlowOutAt(node.Index, flowIn2);
							}
						});
					}
					else
					{
						waterManager.WaterSimLogic.SetFlowOutAt(num, flowIn2);
					}
				}
				if (drawMode == DrawMode.FireDraw)
				{
					float value = setWaterLevel;
					if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl))
					{
						int num2 = map.GridSpaceData.Length;
						for (int num3 = 0; num3 < num2; num3++)
						{
							if ((map.GridSpaceData[num3].Tag & (MapNodeTags.WaterLevelLow | MapNodeTags.WaterLevelMedium | MapNodeTags.WaterDepthHigh)) == 0 && map.GridSpaceData[num3].IsWalkable)
							{
								fireSimLogic.SetFireData(num3, value);
							}
						}
					}
					else
					{
						if (Input.GetKey(KeyCode.LeftShift))
						{
							value = 0f;
						}
						fireSimLogic.SetFireData(num, value);
					}
				}
				if (drawMode == DrawMode.GreekFireDraw)
				{
					float value2 = setWaterLevel;
					if (Input.GetKey(KeyCode.LeftShift))
					{
						value2 = 0f;
					}
					fireSimLogic.SetFireData(num, value2);
					fireSimLogic.SetFlameType(num, 1);
					fireSimLogic.SetFlammabilityOverride(num, 10f);
				}
				if (drawMode == DrawMode.OilBlobDraw)
				{
					float health = setWaterLevel;
					if (Input.GetKey(KeyCode.LeftShift))
					{
						health = 0f;
					}
					fireSimLogic.SetOilBlobHealth(num, health, 0);
				}
				if (drawMode == DrawMode.GreekFireOilBlobDraw)
				{
					float health2 = setWaterLevel;
					if (Input.GetKey(KeyCode.LeftShift))
					{
						health2 = 0f;
					}
					fireSimLogic.SetOilBlobHealth(num, health2, 1);
				}
				if (drawMode == DrawMode.Obstacle)
				{
					int obstacleValue = 1;
					if (Input.GetKey(KeyCode.LeftShift))
					{
						obstacleValue = 0;
					}
					waterManager.WaterSimLogic.SetObstacleAt(vec3Int.x, vec3Int.y, vec3Int.z, obstacleValue);
					waterManager.TickWater(tickWater: false, createMesh: true, prepareWaterDisplayData: true);
				}
				if (drawMode == DrawMode.RefreshObstacle)
				{
					waterManager.RefreshObstacleAt(vec3Int.x, vec3Int.y, vec3Int.z);
				}
			}
			if (Input.GetMouseButtonDown(0) && !flag && drawMode == DrawMode.FillWater)
			{
				if (Input.GetKey(KeyCode.LeftShift))
				{
					FillWaterToPosition(vec3Int, 0f);
				}
				else
				{
					FillWaterToPosition(vec3Int, setWaterLevel);
				}
				waterManager.TickWater(tickWater: false, createMesh: true, prepareWaterDisplayData: true);
			}
		}

		private void FillDebugWaterInfo(Vec3Int pos)
		{
			if (map == null)
			{
				return;
			}
			if (!GridDataIndexTools.InRange(pos))
			{
				generalInfo.SetText(string.Empty);
				waterInfo.SetText(string.Empty);
				fireInfo.SetText(string.Empty);
				return;
			}
			int num = GridDataIndexTools.FastTo1DIndexNoCheck(pos);
			MapNode mapNode = map.GridSpaceData[num];
			Region region = mapNode?.Region;
			bool flag = region?.IsBridge ?? false;
			Area area = mapNode?.Region?.GetArea();
			generalInfoStringBuilder.Clear();
			generalInfoStringBuilder.AppendFormat("Position: {0}, Node: {1}\nArea: {2}, conn.: {3},\nRegion: {4}, conn.: {5}, bridge: {6}, fire:{7}\n", pos, num, mapNode?.Area, area?.ConnectionsCount, region?.UniqueId, region?.Connections?.Count, flag, region?.IsFire);
			generalInfo.SetText(generalInfoStringBuilder.ToString());
			waterInfoStringBuilder.Clear();
			fireInfoStringBuilder.Clear();
			if (GridDataIndexTools.InRange(pos))
			{
				waterManager.WaterSimLogic.GetDebugInfo(pos, waterInfoStringBuilder);
				fireSimLogic.GetDebugInfo(pos, fireInfoStringBuilder);
			}
			waterInfo.SetText(waterInfoStringBuilder.ToString());
			fireInfo.SetText(fireInfoStringBuilder.ToString());
		}

		private void FillWaterToPosition(Vec3Int pos, float topWaterLevel)
		{
			Debug.Log($"FillWaterToPosition: {pos.x}, {pos.y}, {pos.z}, top water level: {topWaterLevel}");
			Queue<Vec3Int> queue = new Queue<Vec3Int>();
			queue.Enqueue(pos);
			HashSet<Vec3Int> hashSet = new HashSet<Vec3Int>();
			while (queue.Count > 0)
			{
				Vec3Int b = queue.Dequeue();
				if (b.y > pos.y)
				{
					continue;
				}
				if (topWaterLevel <= 0f)
				{
					waterManager.WaterSimLogic.SetWaterAt(b.x, b.y, b.z, 0f);
				}
				else
				{
					float waterLevel = ((b.y == pos.y) ? topWaterLevel : 1f);
					waterManager.WaterSimLogic.SetWaterAt(b.x, b.y, b.z, waterLevel);
				}
				Vec3Int[] neighbors3DNonDiagonal = MapNodeUtils.Neighbors3DNonDiagonal;
				for (int i = 0; i < neighbors3DNonDiagonal.Length; i++)
				{
					Vec3Int a = neighbors3DNonDiagonal[i];
					Vec3Int vec3Int = a + b;
					if (hashSet.Add(vec3Int) && GridDataIndexTools.InRange(vec3Int.x, vec3Int.y, vec3Int.z))
					{
						int nodeIndex = GridDataIndexTools.FastTo1DIndexNoCheck(vec3Int);
						if (waterManager.GetObstacle(nodeIndex) != 1)
						{
							queue.Enqueue(vec3Int);
						}
					}
				}
			}
		}
	}
}
