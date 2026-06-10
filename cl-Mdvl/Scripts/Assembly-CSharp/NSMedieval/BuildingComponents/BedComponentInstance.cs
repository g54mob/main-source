using System;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.Types;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	[FVSerializableKey("BedComponentInstance", "")]
	public class BedComponentInstance : BaseComponentInstance
	{
		private const int ClearOwnerUnderWaterHourCount = 4;

		[NonSerialized]
		private BedComponentBlueprint blueprint;

		[SerializeField]
		private bool isUnavailable;

		[SerializeField]
		private int hoursUnderWater;

		private bool isUnavailableOutsideRain;

		private bool isUnavailableOutsideSnow;

		private bool isUnavailableTemperature;

		private StringBuilder sbUnavailable;

		public BedComponentBlueprint Blueprint => blueprint;

		public bool IsUnavailable => isUnavailable;

		public event Action<bool> BedAvailabilityChangedEvent;

		public BedComponentInstance(BaseBuildingInstance ownerBuilding, BedComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			MonoSingleton<FixedCountTicker<BedComponentInstance>>.Instance.Attach(this, UpdateBedAvailability);
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				this.BedAvailabilityChangedEvent = null;
				base.Map.BedComponentManager.RemoveFromCache(this);
				if (MonoSingleton<FixedCountTicker<BedComponentInstance>>.IsInstantiated())
				{
					MonoSingleton<FixedCountTicker<BedComponentInstance>>.Instance.Detach(this);
				}
				blueprint = null;
				sbUnavailable = null;
				base.Dispose();
			}
		}

		public override void SetupAfterInstantiation()
		{
			CheckIfInPrisonCell();
			base.SetupAfterInstantiation();
		}

		protected override void CheckIfInPrisonCell()
		{
			base.CheckIfInPrisonCell();
			if (base.IsUnavailablePrisonCell)
			{
				base.OwnerBuilding?.BuildingOwnershipInfo?.CheckIfObjectIsInPrisonCell();
			}
		}

		protected override void OnWaterLevelChanged(WaterDepthLevel waterDepthLevel)
		{
			bool flag = waterDepthLevel != WaterDepthLevel.None;
			if (base.Underwater != flag)
			{
				if (flag)
				{
					MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
					base.OwnerBuilding.SetUnderWater(underWater: true);
				}
				else
				{
					base.OwnerBuilding.SetUnderWater(underWater: false);
					hoursUnderWater = 0;
					MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourUpdate;
				}
			}
		}

		protected override void OnRefreshRoomChanged()
		{
			base.OnRefreshRoomChanged();
			CheckIfInPrisonCell();
		}

		private void OnHourUpdate()
		{
			if (!base.HasDisposed && base.OwnerBuilding != null && !base.OwnerBuilding.HasDisposed)
			{
				hoursUnderWater++;
				if (hoursUnderWater >= 4)
				{
					base.OwnerBuilding.BuildingOwnershipInfo?.ClearOwner();
				}
			}
		}

		private void UpdateBedAvailability()
		{
			if (base.HasDisposed)
			{
				return;
			}
			bool flag = false;
			isUnavailableOutsideRain = MonoSingleton<WeatherManager>.Instance.IsEventRunning("rain") || MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.IsEventRunning("game_event_hailstorm") || MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.IsEventRunning("game_event_thunderstorm");
			isUnavailableOutsideSnow = MonoSingleton<WeatherManager>.Instance.IsEventRunning("snow");
			isUnavailableTemperature = false;
			foreach (Vec3Int position in base.Positions)
			{
				MapNode node = base.Map.GetNode(position);
				if (node != null)
				{
					if (node.Coverage != CoverageType.Roofed && (isUnavailableOutsideSnow || isUnavailableOutsideRain))
					{
						flag = true;
						break;
					}
					float temperature = base.Map.TemperatureManager.GetTemperature(position);
					if (base.Map.TemperatureManager.IsTemperatureOutOfRange(temperature))
					{
						isUnavailableTemperature = true;
						flag = true;
						break;
					}
				}
			}
			bool num = flag != isUnavailable;
			isUnavailable = flag;
			if (num)
			{
				this.BedAvailabilityChangedEvent?.Invoke(isUnavailable);
			}
		}

		public string GetUnavailableReasons()
		{
			if (sbUnavailable == null)
			{
				sbUnavailable = new StringBuilder();
			}
			sbUnavailable.Clear();
			LocalizationController instance = MonoSingleton<LocalizationController>.Instance;
			if (isUnavailableOutsideRain)
			{
				sbUnavailable.Append(instance.GetText("weather_rain"));
			}
			if (isUnavailableOutsideSnow)
			{
				if (isUnavailableOutsideRain)
				{
					sbUnavailable.Append(", ");
				}
				sbUnavailable.Append(instance.GetText("weather_snow"));
			}
			if (isUnavailableTemperature)
			{
				if (isUnavailableOutsideRain || isUnavailableOutsideSnow)
				{
					sbUnavailable.Append(", ");
				}
				sbUnavailable.Append(instance.GetText("temperature_out_of_range"));
			}
			return sbUnavailable.ToString();
		}

		public override void SetupAfterLoading(BaseBuildingInstance ownerBuilding)
		{
			MonoSingleton<FixedCountTicker<BedComponentInstance>>.Instance.Attach(this, UpdateBedAvailability);
			base.SetupAfterLoading(ownerBuilding);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("isUnavailable", isUnavailable);
			serializer.Write("hoursUnderWater", hoursUnderWater);
		}

		public BedComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<BedComponentRepository, BedComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(60, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Beds\\BedComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in BedComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				isUnavailable = deserializer.ReadBool("isUnavailable");
				hoursUnderWater = deserializer.ReadInt("hoursUnderWater");
			}
		}
	}
}
