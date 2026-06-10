using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Terrain
{
	public class GroundManager : MonoSingleton<GroundManager>, IObserver
	{
		[SerializeField]
		private MapGenerationTextures mapGenerationTextures;

		[NonSerialized]
		private Dictionary<int, VoxelType> voxelTypesByIntID = new Dictionary<int, VoxelType>();

		[NonSerialized]
		private Dictionary<Vec3Int, Dictionary<ObjectSide, BaseBuildingInstance>> voxelSockets = new Dictionary<Vec3Int, Dictionary<ObjectSide, BaseBuildingInstance>>();

		[NonSerialized]
		private LocalizationController localizationController;

		[NonSerialized]
		private MapNode mapNode;

		[NonSerialized]
		private List<string> infoCursorLines = new List<string>();

		[NonSerialized]
		private List<Vec3Int> voxelsToRemove = new List<Vec3Int>();

		[NonSerialized]
		private VillageMap villageMap;

		public bool InstantDig { get; set; }

		public List<string> InfoCursorLines => infoCursorLines;

		public MapGenerationTextures MapGenerationTextures => mapGenerationTextures;

		private VillageMap VillageMap => villageMap ?? (villageMap = VillageManager.ActiveVillage.Map);

		public event Action<Vec3Int> DigActionCycleEnd;

		public void OnTick(float time)
		{
			using (ProfilerSampleJanitor.Begin("GroundManager.Tick"))
			{
				DoUpdateVoxelsRemoved();
			}
		}

		public bool IsTopLayerWorldSpace(List<Vec3Int> positions)
		{
			int sizeY = MonoSingleton<World>.Instance.SizeY;
			int mapBlockHeight = World.MapBlockHeight;
			foreach (Vec3Int position in positions)
			{
				if (position.y / mapBlockHeight >= sizeY)
				{
					return true;
				}
			}
			return false;
		}

		public bool VoxelSocketOccupied(Vec3Int voxelPosition, ObjectSide voxelSide)
		{
			if (!voxelSockets.ContainsKey(voxelPosition))
			{
				return false;
			}
			return voxelSockets[voxelPosition].ContainsKey(voxelSide);
		}

		public bool CanPlaceOnSocket(ObjectSide voxelSide, Vec3Int voxelPosition)
		{
			if (!GroundExists(voxelPosition))
			{
				return false;
			}
			if (!voxelSockets.ContainsKey(voxelPosition))
			{
				return true;
			}
			return !voxelSockets[voxelPosition].ContainsKey(voxelSide);
		}

		public void AttachToVoxelSocket(BaseBuildingInstance item, ObjectSide voxelSide, Vec3Int voxelPosition)
		{
			if (!voxelSockets.ContainsKey(voxelPosition))
			{
				voxelSockets.Add(voxelPosition, new Dictionary<ObjectSide, BaseBuildingInstance>());
				voxelSockets[voxelPosition].Add(voxelSide, item);
				item.SetupVoxelHolderData(voxelPosition, voxelSide);
				item.HasStabilityToBuild = true;
			}
			else if (!voxelSockets[voxelPosition].ContainsKey(voxelSide))
			{
				voxelSockets[voxelPosition].Add(voxelSide, item);
				item.SetupVoxelHolderData(voxelPosition, voxelSide);
				item.HasStabilityToBuild = true;
			}
		}

		public void RemoveFromVoxelSocket(Vec3Int voxelPosition, ObjectSide voxelSide)
		{
			voxelPosition = new Vec3Int(voxelPosition.x, voxelPosition.y, voxelPosition.z);
			if (voxelSockets.ContainsKey(voxelPosition) && voxelSockets[voxelPosition].ContainsKey(voxelSide))
			{
				voxelSockets[voxelPosition].Remove(voxelSide);
			}
		}

		private void GroundRemovedUpdateStability(Vec3Int pos)
		{
			VillageMap.StabilityManager.GroundRemoved(pos.x, pos.y, pos.z);
			MonoSingleton<GroundController>.Instance.PlayStabilityZeroGroundParticles(pos);
			DestroyVoxelStabilityZero(pos.x, pos.y, pos.z);
		}

		private void OnFinishedStabilityUpdated(Vec3Int gridPosition, int stability)
		{
			if (stability <= 0)
			{
				VillageMap.StabilityManager.ClearGroundVoxel(gridPosition);
				MonoSingleton<GroundController>.Instance.PlayStabilityZeroGroundParticles(gridPosition);
				DestroyVoxelStabilityZero(gridPosition.x, gridPosition.y, gridPosition.z);
			}
		}

		public bool GroundExists(Vec3Int v)
		{
			int num = GridDataIndexTools.FastTo1DIndex(v);
			if (num == -1)
			{
				return false;
			}
			return IsGround(VillageMap.GridSpaceData[num]?.VoxelType);
		}

		public void ShowBlackBarTextCantBuildTopLayer()
		{
			MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("cannot_build_on_top_layer"));
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= OnTick;
			}
			if (VillageMap.BeamComponentManager != null)
			{
				VillageMap.BeamComponentManager.BeamDestroyedEvent -= OnBeamDestroyed;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.InfoCursorToggleEvent -= OnInfoCursorToggle;
			}
			if (MonoSingleton<GroundController>.IsInstantiated())
			{
				MonoSingleton<GroundController>.Instance.VoxelAddedEvent -= VoxelAdded;
				MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent -= OnGroundDestroyedSingle;
				MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent -= OnGroundDestroyed;
			}
			villageMap = null;
			this.DigActionCycleEnd = null;
			base.OnDestroy();
		}

		public bool ShowDigInfoCursor(Vec3Int gridPosition)
		{
			if (!GridDataIndexTools.InRange(gridPosition))
			{
				return false;
			}
			if (!GroundExists(gridPosition))
			{
				infoCursorLines.Clear();
				MonoSingleton<UIController>.Instance.UpdateInfoCursorContent(infoCursorLines, "dig_info", 1);
				return false;
			}
			infoCursorLines.Clear();
			mapNode = VillageMap.GetNode(gridPosition);
			SlopeInstance slopeAtPosition = MonoSingleton<SlopeManager>.Instance.GetSlopeAtPosition(gridPosition);
			VoxelType voxelType = ((slopeAtPosition != null) ? slopeAtPosition.GetVoxelType() : mapNode.VoxelType);
			if (voxelType == null)
			{
				return false;
			}
			bool num = slopeAtPosition != null;
			int digAmount = (num ? slopeAtPosition.DigAmount : mapNode.DigAmount);
			int digAmountMax = (num ? slopeAtPosition.DigAmountMax : mapNode.VoxelType.DigAmount);
			float health = (num ? slopeAtPosition.Health : ((float)mapNode.Health));
			float healthMax = (num ? slopeAtPosition.HealthMax : mapNode.VoxelType.Health);
			AddDigToInfoCursorLines(voxelType, digAmount, digAmountMax, health, healthMax);
			MonoSingleton<UIController>.Instance.UpdateInfoCursorContent(infoCursorLines, "dig_info", 1);
			return true;
		}

		internal bool OnDigActionCompleted(Vec3Int pos)
		{
			SlopeInstance slopeAtPosition = MonoSingleton<SlopeManager>.Instance.GetSlopeAtPosition(pos);
			if (slopeAtPosition != null)
			{
				bool result = MonoSingleton<SlopeManager>.Instance.OnDigActionCompleted(slopeAtPosition);
				slopeAtPosition.UpdateDigPercentInEffectMask();
				return result;
			}
			if (!GridDataIndexTools.InRange(pos.x, pos.y, pos.z))
			{
				return false;
			}
			MapNode node = VillageMap.GetNode(pos);
			if (node.IsVoxelAir())
			{
				return false;
			}
			bool num = node.DecreaseDigAmount();
			if (num)
			{
				voxelsToRemove.Add(pos);
				return num;
			}
			Action<Vec3Int> action = this.DigActionCycleEnd;
			if (action != null)
			{
				action(pos);
				return num;
			}
			return num;
		}

		internal void DamageVoxel(Vector3 worldPosition, short healthDamage, float radius, float falloff)
		{
			worldPosition += Vector3.down * World.MapBlockHeight;
			Vec3Int gridPosition = GridUtils.GetGridPosition(worldPosition);
			if (radius <= 0f)
			{
				return;
			}
			if (radius <= 1f)
			{
				DamageVoxel(gridPosition, healthDamage);
				return;
			}
			int num = (int)(radius / (float)World.MapBlockHeight);
			int num2 = Mathf.CeilToInt(radius);
			Vec3Int zero = Vec3Int.zero;
			for (int i = -num2; i <= num2; i++)
			{
				zero.x = i + gridPosition.x;
				for (int j = -num2; j <= num2; j++)
				{
					zero.z = j + gridPosition.z;
					for (int k = -num; k <= num; k++)
					{
						zero.y = k + gridPosition.y;
						float num3 = Vector3.Distance(GridUtils.GetWorldPosition(zero), worldPosition);
						if (!(num3 > radius))
						{
							float num4 = Mathf.Clamp01(falloff * num3 / radius);
							float num5 = (float)healthDamage * (1f - num4);
							DamageVoxel(zero, (short)num5);
						}
					}
				}
			}
		}

		internal void DamageVoxel(Vec3Int gridPosition, short healthDamage)
		{
			int num = GridDataIndexTools.FastTo1DIndex(gridPosition);
			if (num == -1)
			{
				return;
			}
			MapNode mapNode = VillageMap.GridSpaceData[num];
			if (!mapNode.IsVoxelAir())
			{
				if (healthDamage < 0)
				{
					healthDamage = short.MaxValue;
				}
				if (mapNode.DamageVoxel(healthDamage))
				{
					voxelsToRemove.Add(gridPosition);
				}
				else
				{
					mapGenerationTextures.WriteVoxelHealthToEffectMap(gridPosition);
				}
			}
		}

		internal void OrderDigVoxel(Vec3Int startPoint, Vec3Int endPoint)
		{
			Vec3Int vec3Int = startPoint.Min(endPoint);
			Vec3Int vec3Int2 = startPoint.Max(endPoint);
			int num = startPoint.y / World.MapBlockHeight - 1;
			bool flag = num == 0;
			bool flag2 = false;
			bool flag3 = false;
			HashSet<SlopeInstance> hashSet = new HashSet<SlopeInstance>();
			if (num > 0)
			{
				for (int i = vec3Int.x; i <= vec3Int2.x; i++)
				{
					for (int j = vec3Int.z; j <= vec3Int2.z; j++)
					{
						if (!InstantDig && GridDataIndexTools.IsForbiddenEdge(i, j))
						{
							flag3 = true;
						}
						else
						{
							if ((InstantDig && (i >= GridDataIndexTools.SizeX || j >= GridDataIndexTools.SizeZ)) || !GridDataIndexTools.InRange(i, num, j))
							{
								continue;
							}
							Vec3Int a = new Vec3Int(i, num, j);
							SlopeInstance slopeAtPosition = MonoSingleton<SlopeManager>.Instance.GetSlopeAtPosition(a);
							if (slopeAtPosition != null)
							{
								if (!hashSet.Contains(slopeAtPosition) && !slopeAtPosition.IsForbiddenEdge())
								{
									hashSet.Add(slopeAtPosition);
									if (InstantDig)
									{
										MonoSingleton<SlopeManager>.Instance.ForceRemoveSlope(slopeAtPosition);
									}
									else
									{
										MonoSingleton<SlopeManager>.Instance.DigSlope(slopeAtPosition);
									}
								}
								continue;
							}
							MapNode node = VillageMap.GetNode(i, num, j);
							if (node.VoxelType == null)
							{
								continue;
							}
							if (!node.VoxelType.IsDiggable)
							{
								flag2 = true;
							}
							else
							{
								if (!CanPlaceDigMarkerAt(a + Vec3Int.up))
								{
									continue;
								}
								string digMarker = VillageMap.GetNode(a).VoxelType.DigMarker;
								if (!string.IsNullOrEmpty(digMarker))
								{
									if (InstantDig)
									{
										node.RemoveGround();
										voxelsToRemove.Add(node.Position);
									}
									else
									{
										MapPropType byID = Repository<MapPropTypeRepository, MapPropType>.Instance.GetByID(digMarker);
										MonoSingleton<ResourceSpawner>.Instance.PlaceProp3d(byID, new Vec3Int(a.x, a.y + 1, a.z), 0);
									}
								}
							}
						}
					}
				}
			}
			if (flag)
			{
				string text = MonoSingleton<LocalizationController>.Instance.GetText("cannot_dig_bedrock");
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text);
			}
			else if (flag2)
			{
				string text2 = MonoSingleton<LocalizationController>.Instance.GetText("cannot_dig_ground");
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text2);
			}
			else if (flag3)
			{
				string text3 = MonoSingleton<LocalizationController>.Instance.GetText("cannot_dig_edge");
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text3);
			}
		}

		internal void OrderDigVoxelRange(Vec3Int startPoint, Vec3Int endPoint)
		{
			Vec3Int vec3Int = startPoint.Min(endPoint);
			Vec3Int vec3Int2 = startPoint.Max(endPoint);
			bool flag = vec3Int.y == 0;
			bool flag2 = false;
			bool flag3 = false;
			HashSet<SlopeInstance> hashSet = new HashSet<SlopeInstance>();
			if (vec3Int.y > 0)
			{
				for (int i = vec3Int.x; i <= vec3Int2.x; i++)
				{
					for (int j = vec3Int.y; j <= vec3Int2.y; j++)
					{
						for (int k = vec3Int.z; k <= vec3Int2.z; k++)
						{
							if (!InstantDig && GridDataIndexTools.IsForbiddenEdge(i, k))
							{
								flag3 = true;
							}
							else
							{
								if ((InstantDig && (i >= GridDataIndexTools.SizeX || k >= GridDataIndexTools.SizeZ)) || !GridDataIndexTools.InRange(i, j, k))
								{
									continue;
								}
								Vec3Int a = new Vec3Int(i, j, k);
								SlopeInstance slopeAtPosition = MonoSingleton<SlopeManager>.Instance.GetSlopeAtPosition(a);
								if (slopeAtPosition != null)
								{
									if (!hashSet.Contains(slopeAtPosition) && !slopeAtPosition.IsForbiddenEdge())
									{
										hashSet.Add(slopeAtPosition);
										if (InstantDig)
										{
											MonoSingleton<SlopeManager>.Instance.ForceRemoveSlope(slopeAtPosition);
										}
										else
										{
											MonoSingleton<SlopeManager>.Instance.DigSlope(slopeAtPosition);
										}
									}
									continue;
								}
								MapNode node = VillageMap.GetNode(i, j, k);
								if (node.VoxelType == null)
								{
									continue;
								}
								if (!node.VoxelType.IsDiggable)
								{
									flag2 = true;
								}
								else
								{
									if (!CanPlaceDigMarkerAt(a + Vec3Int.up))
									{
										continue;
									}
									string digMarker = VillageMap.GetNode(a).VoxelType.DigMarker;
									if (!string.IsNullOrEmpty(digMarker))
									{
										if (InstantDig)
										{
											node.RemoveGround();
											voxelsToRemove.Add(node.Position);
										}
										else
										{
											MapPropType byID = Repository<MapPropTypeRepository, MapPropType>.Instance.GetByID(digMarker);
											MonoSingleton<ResourceSpawner>.Instance.PlaceProp3d(byID, new Vec3Int(a.x, a.y + 1, a.z), 0);
										}
									}
								}
							}
						}
					}
				}
			}
			if (flag)
			{
				string text = MonoSingleton<LocalizationController>.Instance.GetText("cannot_dig_bedrock");
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text);
			}
			else if (flag2)
			{
				string text2 = MonoSingleton<LocalizationController>.Instance.GetText("cannot_dig_ground");
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text2);
			}
			else if (flag3)
			{
				string text3 = MonoSingleton<LocalizationController>.Instance.GetText("cannot_dig_edge");
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text3);
			}
		}

		internal string GetPossibleVoxelTypeNames(int flags)
		{
			string text = string.Empty;
			foreach (VoxelType allItem in Repository<VoxelTypeRepository, VoxelType>.Instance.GetAllItems())
			{
				if ((allItem.MaskValue & flags) > 0)
				{
					text = text + allItem.GetID() + ", ";
				}
			}
			if (text.Length == 0)
			{
				return string.Empty;
			}
			return text.Substring(0, text.Length - 2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsGround(VoxelType voxelType)
		{
			if (voxelType != null)
			{
				return voxelType.MaskValue != 0;
			}
			return false;
		}

		private static bool IsGround(MapNode mapNode)
		{
			if (mapNode?.VoxelType != null)
			{
				return mapNode.VoxelType.MaskValue != 0;
			}
			return false;
		}

		private bool AddDigToInfoCursorLines(VoxelType voxelType, int digAmount, int digAmountMax, float health, float healthMax)
		{
			MapPropType byID = Repository<MapPropTypeRepository, MapPropType>.Instance.GetByID(voxelType.DigMarker);
			if (byID == null)
			{
				return false;
			}
			DigMarkerResource byID2 = Repository<DigMarkerResourceRepository, DigMarkerResource>.Instance.GetByID(byID.Model);
			if (byID2 == null)
			{
				return false;
			}
			string text = localizationController.GetText(LocKeyUtils.GetName(byID2.LocKeys));
			if (!voxelType.IsDiggable)
			{
				infoCursorLines.Add(text);
				infoCursorLines.Add(MonoSingleton<LocalizationController>.Instance.GetText("voxel_not_diggable"));
			}
			else
			{
				float num = (float)digAmount / (float)digAmountMax;
				infoCursorLines.Add($"{text} ({(int)(100f * num)}%)");
				infoCursorLines.Add(string.Format("{0} {1} / {2}", localizationController.GetText("dig_resource_health"), Mathf.RoundToInt(health), healthMax));
				float mineYieldMultiplier = GlobalSaveController.CurrentVillageData.GameParametersCurrent.MineYieldMultiplier;
				foreach (ResourceInstance storedResource in byID2.StoredResources)
				{
					string localizedResourceName = ResourceUtils.GetLocalizedResourceName(storedResource.Blueprint);
					string textIcon = ResourceUtils.GetTextIcon(storedResource.Blueprint);
					string item = $"{textIcon} {localizedResourceName} {(int)((float)(storedResource.Amount * digAmount) * mineYieldMultiplier)} / {(int)((float)(storedResource.Amount * digAmountMax) * mineYieldMultiplier)}";
					infoCursorLines.Add(item);
				}
			}
			return true;
		}

		private bool CanPlaceDigMarkerAt(Vec3Int pos)
		{
			MapNode node = VillageMap.GetNode(pos);
			if (node != null && (node.DataType & (GridDataType.DigMarkerResource | GridDataType.DigMarkerResourceToMine)) != GridDataType.None)
			{
				return false;
			}
			if (!InstantDig)
			{
				return !GridDataIndexTools.IsForbiddenEdge(pos.x, pos.z);
			}
			return true;
		}

		private void DoUpdateVoxelsRemoved()
		{
			if (voxelsToRemove.Count == 0)
			{
				return;
			}
			ChunkGenerator chunkGenerator = MonoSingleton<World>.Instance.ChunkGenerator;
			using (PooledList<Vec3Int> pooledList = ListPool<Vec3Int>.GetJanitor())
			{
				using PooledHashSet<MapChunk> pooledHashSet = HashSetPool<MapChunk>.GetJanitor();
				PooledDictionary<MapChunk, int> janitor = DictionaryPool<MapChunk, int>.GetJanitor();
				try
				{
					foreach (Vec3Int item in voxelsToRemove)
					{
						Vec3Int a = item;
						MonoSingleton<World>.Instance.SetData(a.x, a.y, a.z, 0);
						GroundRemovedUpdateStability(a);
						MapChunk mapChunkAt = chunkGenerator.GetMapChunkAt(a.x, a.z);
						if ((object)mapChunkAt != null)
						{
							pooledHashSet.Add(mapChunkAt);
						}
						if (janitor.ContainsKey(mapChunkAt))
						{
							janitor[mapChunkAt] = Math.Min(a.y, janitor[mapChunkAt]);
						}
						else
						{
							janitor.Add(mapChunkAt, a.y);
						}
						pooledList.Add(a - Vec3Int.up);
					}
					foreach (MapChunk item2 in pooledHashSet)
					{
						item2.UpdateMesh(janitor[item2]);
					}
					MonoSingleton<GroundController>.Instance.GroundDestroyed(voxelsToRemove);
					foreach (Vec3Int item3 in voxelsToRemove)
					{
						Vec3Int a2 = item3;
						MapNode node = villageMap.GetNode(a2 + ILSpyHelper_AsRefReadOnly(Vector3.down));
						if (node != null && node.IsWater)
						{
							villageMap.WaterManager.ForceUpdateMesh();
							break;
						}
					}
					mapGenerationTextures.UpdateFog(pooledList);
					voxelsToRemove.Clear();
				}
				finally
				{
					((IDisposable)janitor/*cast due to .constrained prefix*/).Dispose();
				}
			}
			static ref readonly T ILSpyHelper_AsRefReadOnly<T>(in T temp)
			{
				//ILSpy generated this function to help ensure overload resolution can pick the overload using 'in'
				return ref temp;
			}
		}

		public void RefreshChunkMeshes(int x, int z, int meshLevelUpdate)
		{
			using PooledHashSet<MapChunk> pooledHashSet = HashSetPool<MapChunk>.GetJanitor();
			ChunkGenerator chunkGenerator = MonoSingleton<World>.Instance.ChunkGenerator;
			MapChunk mapChunkAt = chunkGenerator.GetMapChunkAt(x, z);
			pooledHashSet.Add(mapChunkAt);
			int i = 0;
			for (int num = MapNodeUtils.NeighborsHorizontalX.Length; i < num; i++)
			{
				int x2 = x + MapNodeUtils.NeighborsHorizontalX[i];
				int z2 = z + MapNodeUtils.NeighborsHorizontalZ[i];
				MapChunk mapChunkAt2 = chunkGenerator.GetMapChunkAt(x2, z2);
				if (mapChunkAt2 != null)
				{
					pooledHashSet.Add(mapChunkAt2);
				}
			}
			foreach (MapChunk item in pooledHashSet)
			{
				item?.UpdateMesh(meshLevelUpdate);
			}
		}

		private void DestroyVoxelStabilityZero(int i, int y, int j)
		{
			using PooledList<Vec3Int> pooledList = ListPool<Vec3Int>.GetJanitor();
			MapNode node = VillageMap.GetNode(i, y, j);
			node.RemoveGround();
			MonoSingleton<World>.Instance.SetData(i, y, j, 0);
			pooledList.Add(new Vec3Int(i, y - 1, j));
			RefreshChunkMeshes(i, j, y);
			mapGenerationTextures.UpdateFog(pooledList);
			MonoSingleton<GroundController>.Instance.GroundDestroyed(new Vec3Int(i, y, j));
			MonoSingleton<ConstructionController>.Instance.ObjectDestroyedCheckFallDown(new Vec3Int(i, y, j));
			MapNode nodeBelow = node.GetNodeBelow();
			if (nodeBelow != null && nodeBelow.IsWater)
			{
				villageMap.WaterManager.ForceUpdateMesh();
			}
		}

		private void Start()
		{
			localizationController = MonoSingleton<LocalizationController>.Instance;
			MonoSingleton<GroundController>.Instance.VoxelAddedEvent += VoxelAdded;
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent += OnGroundDestroyedSingle;
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent += OnGroundDestroyed;
			MonoSingleton<SceneController>.Instance.Tick += OnTick;
			MonoSingleton<UIController>.Instance.InfoCursorToggleEvent += OnInfoCursorToggle;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
		}

		private void OnMapLoaded(bool fromSave)
		{
			villageMap = VillageManager.ActiveVillage.Map;
			VillageMap.BeamComponentManager.BeamDestroyedEvent += OnBeamDestroyed;
			VillageMap.StabilityManager.FinishedStabilityUpdatedEvent += OnFinishedStabilityUpdated;
			VillageMap.StabilityManager.FinishedStabilityUpdatedEvent += OnUpdateStability;
		}

		private void OnInfoCursorToggle(bool active, string tag)
		{
			if (!active && tag != "dig_info")
			{
				MonoSingleton<UIController>.Instance.ToggleInfoCursor(active: false, "dig_info");
			}
		}

		private void OnGroundDestroyed(List<Vec3Int> positions)
		{
			foreach (Vec3Int position in positions)
			{
				if (!voxelSockets.TryGetValue(position, out var value))
				{
					break;
				}
				BaseBuildingInstance[] array = value.Values.ToArray();
				foreach (BaseBuildingInstance baseBuildingInstance in array)
				{
					baseBuildingInstance.Map.BuildingsManagerMain.DestroyBuilding(baseBuildingInstance);
				}
				value.Clear();
			}
		}

		private void OnGroundDestroyedSingle(Vec3Int position)
		{
			if (voxelSockets.TryGetValue(position, out var value))
			{
				BaseBuildingInstance[] array = value.Values.ToArray();
				foreach (BaseBuildingInstance baseBuildingInstance in array)
				{
					baseBuildingInstance?.Map.BuildingsManagerMain.DestroyBuilding(baseBuildingInstance);
				}
				value.Clear();
			}
		}

		private void OnBeamDestroyed(BeamComponentInstance beamComponentInstance)
		{
			foreach (Vec3Int position in beamComponentInstance.Positions)
			{
				if (GroundExists(position + Vec3Int.up))
				{
					VillageMap.StabilityManager.BeamDestroyed(beamComponentInstance);
				}
			}
		}

		private void OnUpdateStability(Vec3Int position, int stability)
		{
			if (voxelSockets.ContainsKey(position))
			{
				Dictionary<ObjectSide, BaseBuildingInstance> dictionary = voxelSockets[position];
				ObjectSide[] array = dictionary.Keys.ToArray();
				foreach (ObjectSide key in array)
				{
					VillageMap.BeamComponentManager.GetComponentInstance(dictionary[key])?.BeamCarriedStabilityChanged(stability);
				}
			}
		}

		private void VoxelAdded(BaseBuildingInstance buildingInstance)
		{
			if (buildingInstance == null)
			{
				return;
			}
			FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(45, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Managers\\GroundManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("VoxelAdded function called at grid position ");
				messageBuilder.AppendFormatted(buildingInstance.GridDataPosition);
				messageBuilder.AppendLiteral(".");
			}
			Log.Warning(messageBuilder);
			Vec3Int gridDataPosition = buildingInstance.GridDataPosition;
			MapChunk mapChunkAt = MonoSingleton<World>.Instance.ChunkGenerator.GetMapChunkAt(gridDataPosition.x, gridDataPosition.z);
			if (mapChunkAt == null)
			{
				messageBuilder = new FVLogWarningInterpolationHandler(33, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Managers\\GroundManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Chunk not found at position (");
					messageBuilder.AppendFormatted(gridDataPosition.x);
					messageBuilder.AppendLiteral(", ");
					messageBuilder.AppendFormatted(gridDataPosition.z);
					messageBuilder.AppendLiteral(")!");
				}
				Log.Warning(messageBuilder);
				return;
			}
			MapNode node = VillageMap.GetNode(gridDataPosition.x, gridDataPosition.y, gridDataPosition.z);
			if (node == null)
			{
				messageBuilder = new FVLogWarningInterpolationHandler(34, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Managers\\GroundManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Node not found at position (");
					messageBuilder.AppendFormatted(gridDataPosition.x);
					messageBuilder.AppendLiteral(", ");
					messageBuilder.AppendFormatted(gridDataPosition.y);
					messageBuilder.AppendLiteral(", ");
					messageBuilder.AppendFormatted(gridDataPosition.z);
					messageBuilder.AppendLiteral(")!");
				}
				Log.Warning(messageBuilder);
				return;
			}
			VoxelBuildingComponentBlueprint byID = Repository<VoxelBuildingComponentRepository, VoxelBuildingComponentBlueprint>.Instance.GetByID(buildingInstance.Blueprint.VoxelComponentID);
			if (byID == null)
			{
				messageBuilder = new FVLogWarningInterpolationHandler(71, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Managers\\GroundManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Can't add voxel building at position (");
					messageBuilder.AppendFormatted(gridDataPosition.x);
					messageBuilder.AppendLiteral(", ");
					messageBuilder.AppendFormatted(gridDataPosition.y);
					messageBuilder.AppendLiteral(", ");
					messageBuilder.AppendFormatted(gridDataPosition.z);
					messageBuilder.AppendLiteral(")! Voxel blueprint not found!");
				}
				Log.Warning(messageBuilder);
				return;
			}
			string voxelTypeID = byID.VoxelTypeID;
			VoxelType byID2 = Repository<VoxelTypeRepository, VoxelType>.Instance.GetByID(voxelTypeID);
			if (byID2 == null)
			{
				messageBuilder = new FVLogWarningInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Managers\\GroundManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(voxelTypeID);
					messageBuilder.AppendLiteral(" not found in voxel type repository.");
				}
				Log.Warning(messageBuilder);
			}
			else
			{
				node.UpdateVoxelType(byID2);
				mapChunkAt.UpdateMesh(gridDataPosition.y);
				mapGenerationTextures.OnVoxelAdded(gridDataPosition, byID2);
				MonoSingleton<GroundController>.Instance.NewVoxelSaved(buildingInstance);
			}
		}
	}
}
