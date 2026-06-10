using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Serialization;
using NSMedieval.Water;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("EntertainmentComponentInstance", "")]
	public class EntertainmentComponentInstance : BaseComponentInstance
	{
		[NonSerialized]
		private ReservablePositionsComponentInstance reservablePositionsComponentInstance;

		[NonSerialized]
		private readonly EntertainmentComponentBlueprint blueprint;

		public EntertainmentComponentBlueprint Blueprint => blueprint;

		public ReservablePositionsComponentInstance ReservablePositionsComponentInstance => reservablePositionsComponentInstance;

		public EntertainmentComponentInstance(BaseBuildingInstance ownerBuilding, EntertainmentComponentBlueprint blueprint, ReservablePositionsComponentInstance reservablePositionsComponentInstance)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			this.reservablePositionsComponentInstance = reservablePositionsComponentInstance;
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Map.EntertainmentComponentManager.RemoveFromCache(this);
				reservablePositionsComponentInstance = null;
				base.Dispose();
			}
		}

		public override void SetupAfterInstantiation()
		{
			CheckIfInPrisonCell();
			base.SetupAfterInstantiation();
		}

		public void CacheReservablePositionsComponentInstance(ReservablePositionsComponentInstance reservablePositionsComponentInstance)
		{
			this.reservablePositionsComponentInstance = reservablePositionsComponentInstance;
		}

		protected override void OnRefreshRoomChanged()
		{
			base.OnRefreshRoomChanged();
			CheckIfInPrisonCell();
		}

		protected override void OnWaterLevelChanged(WaterDepthLevel waterDepthLevel)
		{
			bool underWater = waterDepthLevel == WaterDepthLevel.Medium || waterDepthLevel == WaterDepthLevel.High;
			base.OwnerBuilding.SetUnderWater(underWater);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public EntertainmentComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<EntertainmentComponentRepository, EntertainmentComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(70, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Entertainment\\EntertainmentComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in EntertainmentComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
		}
	}
}
