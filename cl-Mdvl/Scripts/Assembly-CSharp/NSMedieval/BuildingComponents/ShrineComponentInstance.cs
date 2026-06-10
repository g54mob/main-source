using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Serialization;
using NSMedieval.Water;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("ShrineComponentInstance", "")]
	public class ShrineComponentInstance : BaseComponentInstance
	{
		[NonSerialized]
		private readonly ShrineComponentBlueprint blueprint;

		[NonSerialized]
		private ReservablePositionsComponentInstance reservablePositionsComponentInstance;

		public ShrineComponentBlueprint Blueprint => blueprint;

		public ReservablePositionsComponentInstance ReservablePositionsComponentInstance => reservablePositionsComponentInstance;

		public ShrineComponentInstance(BaseBuildingInstance ownerBuilding, ShrineComponentBlueprint blueprint, ReservablePositionsComponentInstance reservablePositionsComponentInstance)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			this.reservablePositionsComponentInstance = reservablePositionsComponentInstance;
			CheckIfInPrisonCell();
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Map.ShrineComponentManager.RemoveFromCache(this);
				reservablePositionsComponentInstance = null;
				base.Dispose();
			}
		}

		protected override void OnRefreshRoomChanged()
		{
			base.OnRefreshRoomChanged();
			CheckIfInPrisonCell();
		}

		public void CacheReservablePositionsComponentInstance(ReservablePositionsComponentInstance reservablePositionsComponentInstance)
		{
			this.reservablePositionsComponentInstance = reservablePositionsComponentInstance;
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

		public ShrineComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<ShrineComponentRepository, ShrineComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(63, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Shrines\\ShrineComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in ShrineComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
		}
	}
}
