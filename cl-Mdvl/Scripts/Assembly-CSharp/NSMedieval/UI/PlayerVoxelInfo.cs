using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.UI.PhotoMode;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using NSMedieval.View.Animals;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class PlayerVoxelInfo : MonoSingleton<PlayerVoxelInfo>, IObserver
	{
		[SerializeField]
		private GameObject voxelSelection;

		[SerializeField]
		private TMP_Text text;

		[NonSerialized]
		private Ray ray;

		[NonSerialized]
		private RaycastHit hit;

		[NonSerialized]
		private LayerMask layerMask;

		[NonSerialized]
		private LayerMask layerMaskSelectable;

		[NonSerialized]
		private Vec3Int hoverGridPosition = Vec3Int.zero;

		[NonSerialized]
		private Camera mainCamera;

		[NonSerialized]
		public Action<Vec3Int> OnHoverChange;

		[NonSerialized]
		private VillageMap map;

		[NonSerialized]
		private readonly StringBuilder stringBuilder = new StringBuilder(0, 4096);

		[NonSerialized]
		private LocalizationController localizationController;

		[NonSerialized]
		private bool photoModeActive;

		[NonSerialized]
		private bool worldMapActive;

		public static bool ShowInfo { get; set; } = true;

		public Vec3Int HoverGridPosition => hoverGridPosition;

		private void Start()
		{
			layerMask = (1 << LayerMask.NameToLayer("VoxelMap")) | (1 << LayerMask.NameToLayer("BuildableSurface")) | (1 << LayerMask.NameToLayer("RaycastPlaneHelper"));
			layerMaskSelectable = (int)layerMask | (1 << LayerMask.NameToLayer("Selectable"));
			mainCamera = MonoSingleton<CameraManager>.Instance.GameplayCamera;
			localizationController = MonoSingleton<LocalizationController>.Instance;
			MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent += OnMainSceneLoaded;
			MonoSingleton<WorldMapController>.Instance.WorldMapVisibilitySetEvent += OnWorldMapVisibilitySet;
			map = VillageManager.ActiveVillage.Map;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			map = null;
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent -= OnMainSceneLoaded;
			}
			if (MonoSingleton<PhotoModeController>.IsInstantiated())
			{
				MonoSingleton<PhotoModeController>.Instance.PhotoModeVisibleEvent -= OnPhotoModeVisible;
			}
			if (MonoSingleton<WorldMapController>.IsInstantiated())
			{
				MonoSingleton<WorldMapController>.Instance.WorldMapVisibilitySetEvent -= OnWorldMapVisibilitySet;
			}
			OnHoverChange = null;
			mainCamera = null;
		}

		private void OnMainSceneLoaded()
		{
			MonoSingleton<PhotoModeController>.Instance.PhotoModeVisibleEvent += OnPhotoModeVisible;
		}

		private void OnPhotoModeVisible(bool visible)
		{
			photoModeActive = visible;
			ShowInfo = !photoModeActive && !worldMapActive;
		}

		private void OnWorldMapVisibilitySet(bool visible)
		{
			worldMapActive = visible;
			ShowInfo = !photoModeActive && !worldMapActive;
		}

		private void Update()
		{
			if (!MonoSingleton<World>.IsInstantiated() || !MonoSingleton<InputManager>.IsInstantiated() || !MonoSingleton<Heightmap>.IsInstantiated() || localizationController == null || !MonoSingleton<InputManager>.Instance.InputEnabled || !MonoSingleton<World>.Instance.IsLoaded)
			{
				return;
			}
			if (!ShowInfo)
			{
				if (voxelSelection.gameObject.activeSelf)
				{
					voxelSelection.gameObject.SetActive(value: false);
					if (UpdateText())
					{
						text.text = string.Empty;
					}
				}
			}
			else if (!(mainCamera == null) && mainCamera.gameObject.activeSelf)
			{
				Vec3Int gridPositionForCursor = GetGridPositionForCursor();
				ProcessHoverPositionChange(gridPositionForCursor);
			}
		}

		private Vec3Int GetGridPositionForCursor()
		{
			if (!MonoSingleton<CameraManager>.IsInstantiated() || MonoSingleton<CameraManager>.Instance.GameplayCamera == null)
			{
				return Vec3Int.down;
			}
			ray = MonoSingleton<CameraManager>.Instance.GameplayCamera.ScreenPointToRay(Input.mousePosition);
			WorldObject worldObject = ((MonoSingleton<SelectableObjectManager>.Instance.MouseHoverObject != null) ? MonoSingleton<SelectableObjectManager>.Instance.MouseHoverObject.GetAsWorldObject() : null);
			Vector3 input = Vector3.zero;
			LayerMask layerMask = ((worldObject == null) ? this.layerMask : layerMaskSelectable);
			if (Physics.Raycast(ray, out hit, float.PositiveInfinity, layerMask))
			{
				Vector3 normal = hit.normal;
				normal.y = 0f;
				input = hit.point - normal * 0.1f;
			}
			Vec3Int result = input.ToGridRoundY(0.01f);
			if (worldObject == null)
			{
				return result;
			}
			if (worldObject is PlantMapResourceInstance)
			{
				return worldObject.GridDataPosition;
			}
			if (worldObject is BaseBuildingInstance baseBuildingInstance && baseBuildingInstance.Positions.Count <= 1)
			{
				return baseBuildingInstance.GridDataPosition;
			}
			return result;
		}

		private void ProcessHoverPositionChange(Vec3Int gridPosition)
		{
			if (hoverGridPosition == gridPosition)
			{
				return;
			}
			hoverGridPosition = gridPosition;
			OnHoverChange?.Invoke(gridPosition);
			bool flag = UpdateText();
			bool flag2 = OutlinePostProcess.Instance.IsObjectTypeSelected<AnimatedAgentView>();
			if (!(voxelSelection != null))
			{
				return;
			}
			if (flag && !flag2)
			{
				if (!voxelSelection.gameObject.activeSelf)
				{
					voxelSelection.gameObject.SetActive(value: true);
				}
				voxelSelection.transform.position = GridUtils.GetWorldPosition(gridPosition);
			}
			else if (voxelSelection.gameObject.activeSelf)
			{
				voxelSelection.gameObject.SetActive(value: false);
			}
		}

		private bool UpdateText()
		{
			Vec3Int vec3Int = hoverGridPosition - Vec3Int.up;
			stringBuilder.Clear();
			bool foundBuildableObject = false;
			bool foundVoxel = false;
			bool foundWater = false;
			if (GridDataIndexTools.InRange(vec3Int))
			{
				AddGroundData(vec3Int, out foundBuildableObject, out foundVoxel, out foundWater);
			}
			bool flag = foundVoxel || foundBuildableObject || foundWater;
			text.text = (flag ? stringBuilder.ToString() : string.Empty);
			return flag;
		}

		private void AddBuildingToText(BaseBuildingInstance building)
		{
			if (building != null && !(building.Blueprint == null))
			{
				string buildingPhase = building.GetBuildingPhase();
				stringBuilder.Append(BuildingUtils.GetLocalizedName(building.Blueprint.GetID()));
				if (buildingPhase.Length > 0)
				{
					stringBuilder.AppendFormat(" ({0})", buildingPhase);
				}
				stringBuilder.Append("\n");
			}
		}

		public static IPathfindingAgent GetAgentForTraversalSpeed()
		{
			if (!MonoSingleton<SelectableObjectManager>.IsInstantiated() || !MonoSingleton<WorkerManager>.IsInstantiated())
			{
				return null;
			}
			HashSet<SelectableObject> selectedObjects = MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects;
			if (selectedObjects == null)
			{
				return null;
			}
			foreach (SelectableObject item in selectedObjects)
			{
				if (!(item == null) && !item.IsBuilding)
				{
					if (item is WorkerView { HumanoidInstance: not null } workerView && !workerView.HumanoidInstance.HasDisposed && !workerView.HumanoidInstance.HasDied)
					{
						return workerView.HumanoidInstance;
					}
					if (item is NPCView { HumanoidInstance: not null } nPCView && !nPCView.HumanoidInstance.HasDisposed && !nPCView.HumanoidInstance.HasDied)
					{
						return nPCView.HumanoidInstance;
					}
					if (item is AnimalView { AnimalInstance: not null } animalView && !animalView.AnimalInstance.HasDisposed && !animalView.AnimalInstance.HasDied)
					{
						return animalView.AnimalInstance;
					}
				}
			}
			if (MonoSingleton<WorkerManager>.IsInstantiated())
			{
				return MonoSingleton<WorkerManager>.Instance.AllWorkers.FirstOrDefault().Key;
			}
			return null;
		}

		private void AddGroundData(Vec3Int voxelGridPos, out bool foundBuildableObject, out bool foundVoxel, out bool foundWater)
		{
			VillageMap villageMap = VillageManager.ActiveVillage.Map;
			Vec3Int vec3Int = voxelGridPos + Vec3Int.up;
			foundBuildableObject = false;
			foundVoxel = false;
			foundWater = false;
			if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || !MonoSingleton<World>.IsInstantiated() || GlobalSaveController.CurrentVillageData == null || stringBuilder == null)
			{
				return;
			}
			stringBuilder.AppendFormat("{0} {1} {2} {3}\n", localizationController.GetText("info_position"), voxelGridPos.x, voxelGridPos.y + 1, voxelGridPos.z);
			if (voxelGridPos.y >= MonoSingleton<World>.Instance.ElevationLevel - 1)
			{
				Vec3Int gridPosition = voxelGridPos + Vec3Int.up;
				if (villageMap.GetNode(gridPosition)?.VoxelType != null)
				{
					foundVoxel = true;
					return;
				}
			}
			if (!GridDataIndexTools.InRange(voxelGridPos))
			{
				return;
			}
			MapNode node = villageMap.GetNode(voxelGridPos);
			MapNode node2 = villageMap.GetNode(vec3Int);
			foundVoxel = node2?.VoxelType != null || node.VoxelType != null;
			foundBuildableObject = node.HasWorldObjects();
			if (node2 != null)
			{
				foundBuildableObject |= node2.HasWorldObjects();
			}
			if (node.VoxelType != null)
			{
				foundVoxel = true;
				float num = (float)node.Health / (float)node.VoxelType.Health;
				num = Mathf.Round(num * 100f);
				stringBuilder.AppendFormat("{0} {1}%\n", localizationController.GetText(node.VoxelType.TextKey), num);
			}
			IPathfindingAgent agentForTraversalSpeed = GetAgentForTraversalSpeed();
			if (node2 != null && agentForTraversalSpeed != null && (node2.VoxelType == null || map.BuildingsManagerMain.BuildingExists(vec3Int, (BaseBuildingInstance x) => x.BuildingType == BuildingType.Door && x.ConstructionPhase == ConstructionPhase.Finished)))
			{
				string text = string.Empty;
				if (typeof(HumanoidInstance) != agentForTraversalSpeed.GetType())
				{
					AnimatedAgentView animatedAgentView = agentForTraversalSpeed.GetGoapAgent()?.GetView();
					text = animatedAgentView?.GetSimpleName();
					if (string.IsNullOrEmpty(text) && animatedAgentView != null)
					{
						text = localizationController.GetText("general_" + animatedAgentView.GetMultiselectName());
					}
				}
				int num2 = (int)(WalkSpeedMultiplier.GetSpeedMultiplier(agentForTraversalSpeed.WalkableModel?.WalkSpeedMultiplierBlueprint, node2) * 100f);
				if (!string.IsNullOrEmpty(text))
				{
					stringBuilder.AppendFormat("{0} ({1}) {2}%\n", localizationController.GetText("info_walk_speed"), text, num2);
				}
				else
				{
					stringBuilder.AppendFormat("{0} {1}%\n", localizationController.GetText("info_walk_speed"), num2);
				}
			}
			string key = ((node2 == null) ? "outside" : node2.Coverage.ToString().ToLower());
			stringBuilder.AppendFormat("{0}", localizationController.GetText(key));
			if (villageMap.RoomDetection != null && villageMap.RoomDetection.GetRoom(vec3Int) != null)
			{
				stringBuilder.AppendFormat(", {0}", localizationController.GetText("info_room"));
			}
			stringBuilder.Append("\n");
			if (villageMap.WaterManager.IsWaterAt(node.Index) || (node2 != null && villageMap.WaterManager.IsWaterAt(node2.Index)))
			{
				WaterDepthLevel waterDepthLevel = ((node2 == null) ? WaterDepthLevel.None : villageMap.WaterManager.GetWaterDepthLevel(node2.Index));
				WaterDepthLevel waterDepthLevel2 = villageMap.WaterManager.GetWaterDepthLevel(node.Index);
				if (waterDepthLevel2 > waterDepthLevel)
				{
					waterDepthLevel = waterDepthLevel2;
				}
				foundWater = waterDepthLevel > WaterDepthLevel.None;
				if (foundWater)
				{
					stringBuilder.AppendFormat("{0}\n", localizationController.GetText(villageMap.WaterManager.GetTextKeyForWaterLevel(waterDepthLevel)));
				}
				if (node.GetWorldObject(GridDataType.FishMapResource) is FishMapResourceInstance fishMapResourceInstance && fishMapResourceInstance.Blueprint != null)
				{
					string arg = localizationController.GetText(LocKeyUtils.GetName(fishMapResourceInstance.GetBlueprint().LocKeys));
					stringBuilder.AppendFormat("{0}\n", arg);
				}
			}
			if (node2?.Map != null)
			{
				stringBuilder.AppendFormat("{0}: {1}\n", localizationController.GetText("menu_beauty_points"), node2.BeautyInput);
			}
			if (node.CheckIsDataType(GridDataType.Slope))
			{
				stringBuilder.AppendFormat("{0}\n", localizationController.GetText("info_natural_slope"));
			}
			if (node2?.GetWorldObject(GridDataType.PlantMapResource) is PlantMapResourceInstance plantMapResourceInstance && plantMapResourceInstance.Blueprint != null && plantMapResourceInstance.Blueprint.LifePhases != null && plantMapResourceInstance.CurrentPhase >= 0 && plantMapResourceInstance.CurrentPhase < plantMapResourceInstance.Blueprint.LifePhases.Count)
			{
				string arg2 = localizationController.GetText(LocKeyUtils.GetName(plantMapResourceInstance.Blueprint.LifePhases[plantMapResourceInstance.CurrentPhase].LocKeys));
				stringBuilder.AppendFormat("{0} ({1})\n", localizationController.GetText(LocKeyUtils.GetName(plantMapResourceInstance.Blueprint.LocKeys)), arg2);
			}
			bool flag = false;
			StockpileInstance stockpileInstance = (StockpileInstance)node.GetWorldObject(GridDataType.Stockpile);
			if (stockpileInstance != null && !stockpileInstance.HasDisposed)
			{
				ResourcePileInstance resourcePileGridPosition = stockpileInstance.GetResourcePileGridPosition(vec3Int);
				if (resourcePileGridPosition != null && !resourcePileGridPosition.HasDisposed)
				{
					stringBuilder.Append(localizationController.GetText("ctrl_Stockpile"));
					ResourceInstance resourceInstance = resourcePileGridPosition?.GetStoredResource();
					if (resourceInstance != null && !resourceInstance.HasDisposed)
					{
						flag = true;
						stringBuilder.AppendFormat(": {0} ({1})", ResourceUtils.GetLocalizedResourceName(resourcePileGridPosition.Blueprint), resourceInstance.Amount);
					}
					stringBuilder.Append("\n");
				}
			}
			if (!flag)
			{
				ResourcePileInstance worldObject = villageMap.GetWorldObject<ResourcePileInstance>(GridDataType.ResourcePile, vec3Int);
				ResourceInstance resourceInstance2 = worldObject?.GetStoredResource();
				if (resourceInstance2 != null)
				{
					stringBuilder.AppendFormat("{0} ({1})\n", ResourceUtils.GetLocalizedResourceName(worldObject.Blueprint), resourceInstance2.Amount);
				}
			}
			CropfieldInstance cropfieldInstance = (CropfieldInstance)node.GetWorldObject(GridDataType.Cropfield);
			if (cropfieldInstance != null && cropfieldInstance.Blueprint != null)
			{
				stringBuilder.AppendFormat("{0}\n", BuildingUtils.GetLocalizedName(cropfieldInstance.Blueprint.GetID()));
			}
			bool flag2 = false;
			if (node2 != null && (node.HasWorldObjects() || node2.HasWorldObjects()))
			{
				flag2 = true;
				List<WorldObject> list = new List<WorldObject>(node.GetWorldObjects(GridDataType.BuildingFinished | GridDataType.OthersBlueprint | GridDataType.OthersUnfinished | GridDataType.Furniture | GridDataType.ProductionBuilding | GridDataType.Stairs | GridDataType.BeamFinished | GridDataType.Roof | GridDataType.SocketableItem | GridDataType.Trap | GridDataType.Grave));
				list.AddRange(node2.GetWorldObjects(GridDataType.BuildingFinished | GridDataType.OthersBlueprint | GridDataType.OthersUnfinished | GridDataType.Furniture | GridDataType.ProductionBuilding | GridDataType.Stairs | GridDataType.BeamFinished | GridDataType.Roof | GridDataType.SocketableItem | GridDataType.Trap | GridDataType.Grave));
				foreach (WorldObject item in list)
				{
					if (!(item is BaseBuildingInstance baseBuildingInstance))
					{
						continue;
					}
					AddBuildingToText(baseBuildingInstance);
					SocketComponentInstance socketComponentInstance = baseBuildingInstance.Map.SocketComponentManager.GetSocketComponentInstance(baseBuildingInstance);
					if (socketComponentInstance == null)
					{
						continue;
					}
					foreach (BaseBuildingInstance socketedItem in socketComponentInstance.SocketedItems)
					{
						AddBuildingToText(socketedItem);
					}
				}
			}
			foundBuildableObject = flag2 || stockpileInstance != null || cropfieldInstance != null;
			bool num3 = GridDataIndexTools.InRange(vec3Int);
			bool flag3 = GridDataIndexTools.InRange(voxelGridPos);
			int a = (num3 ? node.Map.StabilityManager.GetFinishedStability(vec3Int) : (-1));
			int b = (flag3 ? node.Map.StabilityManager.GetFinishedStability(voxelGridPos) : (-1));
			float num4 = Mathf.Max(a, b);
			if ((!foundVoxel & foundBuildableObject) && num4 < 0.0001f)
			{
				num4 = (int)node.Map.StabilityManager.GetFinishedStability(voxelGridPos + Vec3Int.down);
			}
			stringBuilder.AppendFormat("{0} {1}\n", localizationController.GetText("info_stability"), num4);
			if (node2 != null && villageMap.SnowGrassWetnessManager != null)
			{
				SnowGrassWetnessManager snowGrassWetnessManager = villageMap.SnowGrassWetnessManager;
				float grassHealth = snowGrassWetnessManager.GetGrassHealth(node2.Index);
				float num5 = (float)(int)snowGrassWetnessManager.GetSnow(node2.Index) / 255f;
				float num6 = (float)(int)snowGrassWetnessManager.GetWetness(node2.Index) / 255f;
				if (grassHealth >= 0.01f || num5 >= 0.01f || num6 >= 0.01f)
				{
					bool flag4 = grassHealth >= 0.01f;
					bool flag5 = flag4 || num5 >= 0.01f;
					if (grassHealth >= 0.01f)
					{
						stringBuilder.AppendFormat("{0}: {1}%", localizationController.GetText("node_grass"), (int)(grassHealth * 100f));
					}
					if (num5 >= 0.01f)
					{
						if (flag4)
						{
							stringBuilder.Append(", ");
						}
						stringBuilder.AppendFormat("{0}: {1}%", localizationController.GetText("node_snow"), (int)(num5 * 100f));
					}
					if (num6 >= 0.01f)
					{
						if (flag5)
						{
							stringBuilder.Append(", ");
						}
						stringBuilder.AppendFormat("{0}: {1}%", localizationController.GetText("node_wet"), (int)(num6 * 100f));
					}
					stringBuilder.Append("\n");
				}
			}
			if (node2 != null)
			{
				TemperatureManager temperatureManager = villageMap.TemperatureManager;
				stringBuilder.AppendFormat("{0}: {1}%\n", localizationController.GetText("node_sunlight"), (int)(Mathf.Clamp01(temperatureManager.GetLightIntensity(node2.Position)) * 100f));
				float fireData = villageMap.FireSimLogic.GetFireData(node2.Index);
				if (fireData > 0f)
				{
					stringBuilder.AppendFormat("{0}: {1}%\n", localizationController.GetText("node_fire"), (int)(Mathf.Clamp01(fireData) * 100f));
				}
			}
		}
	}
}
