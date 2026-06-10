using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("HailstormPhase", "")]
	public class HailstormPhase : AlterWeatherPhase
	{
		private static readonly int HealthUpdateMinutes = 5;

		[SerializeField]
		private float percentageToDestroy;

		private List<PlantMapResourceInstance> plants;

		private const string fvs_percentageToDestroy = "percentageToDestroy";

		private List<PlantMapResourceInstance> Plants
		{
			get
			{
				if (plants == null)
				{
					plants = GeneratePlantsList();
				}
				return plants;
			}
		}

		public HailstormPhase()
		{
		}

		public override void Dispose()
		{
			base.Dispose();
			plants = null;
		}

		public override bool OnStart()
		{
			if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || GlobalSaveController.CurrentVillageData == null)
			{
				return false;
			}
			percentageToDestroy = base.Blueprint.Percentage.Random();
			FVLogger logger = GameEventPhaseBase.Logger;
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(47, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\HailstormEvent\\HailstormPhase.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Hailstorm starting with percentage to destroy: ");
				messageBuilder.AppendFormatted(percentageToDestroy);
			}
			logger.Info(in messageBuilder);
			base.OnStart();
			return true;
		}

		protected override bool TickShouldEnd()
		{
			bool result = base.TickShouldEnd();
			if (GameEventPhaseBase.CurrentTimeMinutes % HealthUpdateMinutes == 0L)
			{
				DamageAllPlants();
			}
			return result;
		}

		private void DamageAllPlants()
		{
			foreach (PlantMapResourceInstance plant in Plants)
			{
				if (plant != null && !plant.HasDisposed && plant.CurrentPhase != -1)
				{
					float damageAmount = GetDamageAmount();
					float num = plant.GetStatValue(StatType.Health) - damageAmount;
					plant.GetStat(StatType.Health).SetCurrent(num);
					if (num <= 0f)
					{
						plant.SetLastPhase();
					}
					FVLogger logger = GameEventPhaseBase.Logger;
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(36, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\HailstormEvent\\HailstormPhase.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Damaging plant ");
						messageBuilder.AppendFormatted(plant.Blueprint.GetID());
						messageBuilder.AppendLiteral(" at ");
						messageBuilder.AppendFormatted(plant.GridDataPosition);
						messageBuilder.AppendLiteral(" with ");
						messageBuilder.AppendFormatted(damageAmount);
						messageBuilder.AppendLiteral(" hit points");
					}
					logger.Trace(in messageBuilder);
				}
			}
		}

		private float GetDamageAmount()
		{
			return base.Blueprint.DamageHitPoints.Random() / base.DurationHours / (float)GameEventPhaseBase.MinutesInHour * (float)HealthUpdateMinutes;
		}

		private List<PlantMapResourceInstance> GeneratePlantsList()
		{
			List<PlantMapResourceInstance> list = new List<PlantMapResourceInstance>();
			list.AddRange(from plant in VillageManager.ActiveVillage.Map.GetWorldObjectsList<PlantMapResourceInstance>(GridDataType.PlantMapResource)
				where plant.Blueprint.PlantType.Equals(PlantType.Others)
				select plant);
			Heightmap instance = MonoSingleton<Heightmap>.Instance;
			foreach (var (plantMapResourceInstance, index) in list.IterateInReverseDynamicWithIndex())
			{
				if (instance.GetHeightAt(plantMapResourceInstance.GridDataPosition.x, plantMapResourceInstance.GridDataPosition.z) > plantMapResourceInstance.GridDataPosition.y)
				{
					list.RemoveAt(index);
				}
			}
			int num = (int)((float)list.Count * percentageToDestroy / 100f);
			while (list.Count > num)
			{
				list.Remove(list.PickRandom());
			}
			FVLogger logger = GameEventPhaseBase.Logger;
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(27, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\HailstormEvent\\HailstormPhase.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("GeneratePlantsList.Count = ");
				messageBuilder.AppendFormatted(list.Count);
			}
			logger.Info(in messageBuilder);
			return list;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("percentageToDestroy", percentageToDestroy);
		}

		public HailstormPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			percentageToDestroy = deserializer.ReadFloat("percentageToDestroy");
		}
	}
}
