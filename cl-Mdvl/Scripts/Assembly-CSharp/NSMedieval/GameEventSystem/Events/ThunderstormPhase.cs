using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.EnvironmentEffects;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.Sound;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Terrain;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("ThunderstormPhase", "")]
	public class ThunderstormPhase : AlterWeatherPhase
	{
		[SerializeField]
		private List<long> strikesTime;

		[SerializeField]
		private List<bool> strikeDone;

		[SerializeField]
		private int instanceStrikesCount;

		[SerializeField]
		private int strikesDoneCount;

		[SerializeField]
		private float totalStrikeChance;

		private int raycastMask;

		private List<KeyValuePair<LightningStrikeTargetType, float>> lightningStrikeChance;

		private const string fvs_strikesTime = "strikesTime";

		private const string fvs_strikeDone = "strikeDone";

		private const string fvs_instanceStrikesCount = "instanceStrikesCount";

		private const string fvs_strikesDoneCount = "strikesDoneCount";

		private const string fvs_totalStrikeChance = "totalStrikeChance";

		private List<KeyValuePair<LightningStrikeTargetType, float>> LightningStrikeChance
		{
			get
			{
				if (lightningStrikeChance == null)
				{
					totalStrikeChance = 0f;
					lightningStrikeChance = new List<KeyValuePair<LightningStrikeTargetType, float>>();
					foreach (SerializablePair<string, float> item in base.Blueprint.LightningStrikeChance)
					{
						if (Enum.TryParse<LightningStrikeTargetType>(item.Key, ignoreCase: true, out var result))
						{
							lightningStrikeChance.Add(new KeyValuePair<LightningStrikeTargetType, float>(result, item.Value));
							totalStrikeChance += item.Value;
						}
					}
				}
				return lightningStrikeChance;
			}
		}

		public int RaycastMask
		{
			get
			{
				if (raycastMask == 0)
				{
					raycastMask = (1 << LayerMask.NameToLayer("VoxelMap")) | (1 << LayerMask.NameToLayer("VoxelMapPathfinding")) | (1 << LayerMask.NameToLayer("Obstacle")) | (1 << LayerMask.NameToLayer("BuildableSurface")) | (1 << LayerMask.NameToLayer("CombatCover"));
				}
				return raycastMask;
			}
		}

		public ThunderstormPhase()
		{
		}

		public override void Dispose()
		{
			base.Dispose();
			lightningStrikeChance = null;
		}

		public override bool OnStart()
		{
			if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || GlobalSaveController.CurrentVillageData == null)
			{
				return false;
			}
			base.OnStart();
			strikesDoneCount = 0;
			InitializeStrikes();
			return true;
		}

		protected override bool TickShouldEnd()
		{
			bool result = base.TickShouldEnd();
			UpdateRainEffectWeight();
			for (int i = 0; i < strikeDone.Count; i++)
			{
				if (!strikeDone[i] && GameEventPhaseBase.CurrentTimeMinutes >= strikesTime[i])
				{
					strikeDone[i] = true;
					Strike(GetStrikePosition());
				}
			}
			return result;
		}

		private void UpdateRainEffectWeight()
		{
			float b = CalculateAnimationLayerWeight(0.85f);
			float rainEffectWeight = Mathf.Max(MonoSingleton<WeatherManager>.Instance.GetBaseRainEffectWeight(), b);
			MonoSingleton<WeatherManager>.Instance.Overrides.SetRainEffectWeight(rainEffectWeight);
		}

		private LightningStrikeTargetType GetTargetTypeForValue(float value)
		{
			float num = value * totalStrikeChance;
			foreach (KeyValuePair<LightningStrikeTargetType, float> item in LightningStrikeChance)
			{
				if (num <= item.Value && GetStrikeTargetCount(item.Key) > 0)
				{
					return item.Key;
				}
				num -= item.Value;
			}
			return LightningStrikeTargetType.RandomPosition;
		}

		private void InitializeStrikes()
		{
			instanceStrikesCount = base.Blueprint.Count.Random();
			FVLogger logger = GameEventPhaseBase.Logger;
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Thunderstorm\\ThunderstormPhase.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Lightning will strike ");
				messageBuilder.AppendFormatted(instanceStrikesCount);
				messageBuilder.AppendLiteral(" times");
			}
			logger.Info(in messageBuilder);
			strikeDone = new List<bool>();
			strikesTime = new List<long>();
			for (int i = 0; i < instanceStrikesCount; i++)
			{
				strikeDone.Add(item: false);
				strikesTime.Add(GetTimeForStrike());
				FVLogger logger2 = GameEventPhaseBase.Logger;
				FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(20, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Thunderstorm\\ThunderstormPhase.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Strike[");
					messageBuilder2.AppendFormatted(i);
					messageBuilder2.AppendLiteral("] at ");
					List<long> list = strikesTime;
					messageBuilder2.AppendFormatted(list[list.Count - 1]);
					messageBuilder2.AppendLiteral(" minutes");
				}
				logger2.Debug(in messageBuilder2);
			}
		}

		private long GetTimeForStrike()
		{
			return timeInterval.TimeStart + (long)(UnityEngine.Random.Range(0.05f, 0.95f) * (float)timeInterval.DurationMinutes);
		}

		public void Strike(Vector3 strikePosition)
		{
			if (base.Blueprint.Prefab == null || base.Blueprint.Prefab.Equals(string.Empty))
			{
				OnStrikeCallback(strikePosition);
				return;
			}
			VillageManager.ActiveVillage.Map.IdlePointManager.StartJobRelocateClosestAnimalIdlePoints(null, strikePosition, delegate
			{
				MonoSingleton<AnimalManager>.Instance.ScareOffAnimals(GridUtils.GetGridPosition(strikePosition), 22f, null);
			});
			GameObject gameObject = UnityEngine.Object.Instantiate(MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(base.Blueprint.Prefab));
			gameObject.transform.position = strikePosition;
			MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(strikePosition, CameraShakeStrength.Strong);
			gameObject.GetComponent<LightningStrikeView>().Setup(this);
		}

		public void OnStrikeCallback(Vector3 worldPosition)
		{
			if (!MonoSingleton<GroundManager>.IsInstantiated() || !MonoSingleton<World>.IsInstantiated())
			{
				return;
			}
			MonoSingleton<AudioManager>.Instance.PlaySoundAtPosition("Thunder", worldPosition);
			VillageMap map = VillageManager.ActiveVillage.Map;
			MapNode node = map.GetNode(GridUtils.GetGridPosition(worldPosition));
			if (node != null)
			{
				foreach (MapNode item in FloodFillUtil.IterateFloodFillConnections(node, 2f, (MapNode mapNode) => !mapNode.IsWalkable && (mapNode.DataType & GridDataType.Roof) == 0))
				{
					map.FireSimLogic.SetFireData(item.Index, 0.75f);
					map.FireSimLogic.SetFlammabilityOverride(item.Index, 3f);
				}
			}
			float num = base.Blueprint.DamageRange.Random();
			float lightningRangePow2 = num * num;
			float num2 = base.Blueprint.GroundDamageHitPoints.Random();
			if (num2 > 0.001f)
			{
				MonoSingleton<GroundManager>.Instance.DamageVoxel(worldPosition, (short)num2, num, 0.7f);
			}
			foreach (IDamageTakingAgent item2 in CombatUtils.GetTargetsInRange(worldPosition, num * 3f, (IDamageTakingAgent agent) => SiegeWeaponComponentInstance.SelectObjectsInRadius(agent, worldPosition, lightningRangePow2)))
			{
				if (item2 == null)
				{
					continue;
				}
				if (item2 is CreatureBase)
				{
					CombatHitManager.DealLightningDamage(item2, base.Blueprint.OnHitEffectors, base.Blueprint.CreatureDamageHitPoints.Random());
					continue;
				}
				CombatHitManager.DealDamage(item2, base.Blueprint.DamageHitPoints.Random());
				if (item2 is PlantMapResourceInstance)
				{
					PlantMapResourceInstance plantMapResourceInstance = item2 as PlantMapResourceInstance;
					if (!plantMapResourceInstance.HasDisposed && plantMapResourceInstance.HasDied && plantMapResourceInstance.GetStat(StatType.Health).Current <= 0f)
					{
						plantMapResourceInstance.SetLastPhase();
					}
				}
			}
			strikesDoneCount++;
			FVLogger logger = GameEventPhaseBase.Logger;
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(34, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Thunderstorm\\ThunderstormPhase.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Lightning strike: ");
				messageBuilder.AppendFormatted(strikesDoneCount);
				messageBuilder.AppendLiteral(" / ");
				messageBuilder.AppendFormatted(instanceStrikesCount);
				messageBuilder.AppendLiteral(" at position ");
				messageBuilder.AppendFormatted(worldPosition);
			}
			logger.Info(in messageBuilder);
		}

		private int GetStrikeTargetCount(LightningStrikeTargetType type)
		{
			return type switch
			{
				LightningStrikeTargetType.Plant => VillageManager.ActiveVillage.Map.GetObjectCount(GridDataType.PlantMapResource), 
				LightningStrikeTargetType.Animal => GlobalSaveController.CurrentVillageData.AnimalsCount, 
				LightningStrikeTargetType.Worker => GlobalSaveController.CurrentVillageData.Workers.Count, 
				LightningStrikeTargetType.Enemy => GlobalSaveController.CurrentVillageData.NPCs.Count, 
				LightningStrikeTargetType.Trebuchet => GlobalSaveController.CurrentVillageData.SiegeWeapons.Count, 
				LightningStrikeTargetType.ResourcePile => VillageManager.ActiveVillage.Map.GetObjectCount(GridDataType.ResourcePile), 
				LightningStrikeTargetType.Building => VillageManager.ActiveVillage.Map.GetObjectCount(GridDataType.BuildingFinished) + VillageManager.ActiveVillage.Map.GetObjectCount(GridDataType.BuildingUnfinished) + VillageManager.ActiveVillage.Map.GetObjectCount(GridDataType.ProductionBuilding) + VillageManager.ActiveVillage.Map.GetObjectCount(GridDataType.Furniture), 
				_ => 1, 
			};
		}

		private Vector3 GetRandomObjectPosition(LightningStrikeTargetType type)
		{
			switch (type)
			{
			case LightningStrikeTargetType.Plant:
				return VillageManager.ActiveVillage.Map.GetWorldObjectsList<PlantMapResourceInstance>(GridDataType.PlantMapResource).PickRandom().GetPosition();
			case LightningStrikeTargetType.Animal:
				return GlobalSaveController.CurrentVillageData.Animals.PickRandom().GetPosition();
			case LightningStrikeTargetType.Worker:
				return GlobalSaveController.CurrentVillageData.Workers.PickRandom().GetPosition();
			case LightningStrikeTargetType.Enemy:
				return GlobalSaveController.CurrentVillageData.NPCs.PickRandom().GetPosition();
			case LightningStrikeTargetType.Trebuchet:
				return GlobalSaveController.CurrentVillageData.SiegeWeapons.PickRandom().GetPosition();
			case LightningStrikeTargetType.ResourcePile:
			{
				UnityEngine.Random.Range(0, GetStrikeTargetCount(type));
				int objectCount2 = VillageManager.ActiveVillage.Map.GetObjectCount(GridDataType.ResourcePile);
				return VillageManager.ActiveVillage.Map.GetWorldObjectsList<WorldObject>(GridDataType.ResourcePile).PickRandom().GetPosition();
			}
			case LightningStrikeTargetType.Building:
			{
				int num = UnityEngine.Random.Range(0, GetStrikeTargetCount(type));
				int objectCount = VillageManager.ActiveVillage.Map.GetObjectCount(GridDataType.BuildingFinished);
				if (num < objectCount)
				{
					return VillageManager.ActiveVillage.Map.GetWorldObjectsList<WorldObject>(GridDataType.BuildingFinished).PickRandom().GetPosition();
				}
				num -= objectCount;
				objectCount = VillageManager.ActiveVillage.Map.GetObjectCount(GridDataType.BuildingUnfinished);
				if (num < objectCount)
				{
					return VillageManager.ActiveVillage.Map.GetWorldObjectsList<WorldObject>(GridDataType.BuildingUnfinished).PickRandom().GetPosition();
				}
				num -= objectCount;
				objectCount = VillageManager.ActiveVillage.Map.GetObjectCount(GridDataType.ProductionBuilding);
				if (num < objectCount)
				{
					return VillageManager.ActiveVillage.Map.GetWorldObjectsList<WorldObject>(GridDataType.ProductionBuilding).PickRandom().GetPosition();
				}
				num -= objectCount;
				objectCount = VillageManager.ActiveVillage.Map.GetObjectCount(GridDataType.Furniture);
				if (num < objectCount)
				{
					return VillageManager.ActiveVillage.Map.GetWorldObjectsList<WorldObject>(GridDataType.Furniture).PickRandom().GetPosition();
				}
				break;
			}
			}
			Vec3Int mapSize = GlobalSaveController.CurrentVillageData.MapSize;
			int mapBlockHeight = World.MapBlockHeight;
			Vector2 vector = new Vector2(UnityEngine.Random.Range(0, mapSize.x), UnityEngine.Random.Range(0, mapSize.z));
			return new Vector3(vector.x, MonoSingleton<Heightmap>.Instance.GetHeightAt((int)vector.x, (int)vector.y) * mapBlockHeight, vector.y);
		}

		private Vector3 GetStrikePosition()
		{
			float value = UnityEngine.Random.Range(0f, 1f);
			LightningStrikeTargetType targetTypeForValue = GetTargetTypeForValue(value);
			Vector3 randomObjectPosition = GetRandomObjectPosition(targetTypeForValue);
			float num = 20f;
			if (Physics.Raycast(randomObjectPosition + Vector3.up * num, Vector3.down, out var hitInfo, num * 2f, RaycastMask))
			{
				return hitInfo.point;
			}
			return randomObjectPosition;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("strikesTime", strikesTime);
			serializer.Write("strikeDone", strikeDone);
			serializer.Write("instanceStrikesCount", instanceStrikesCount);
			serializer.Write("strikesDoneCount", strikesDoneCount);
			serializer.Write("totalStrikeChance", totalStrikeChance);
		}

		public ThunderstormPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			strikesTime = deserializer.ReadLongList("strikesTime");
			strikeDone = deserializer.ReadBoolList("strikeDone");
			instanceStrikesCount = deserializer.ReadInt("instanceStrikesCount");
			strikesDoneCount = deserializer.ReadInt("strikesDoneCount");
			totalStrikeChance = deserializer.ReadFloat("totalStrikeChance");
		}
	}
}
