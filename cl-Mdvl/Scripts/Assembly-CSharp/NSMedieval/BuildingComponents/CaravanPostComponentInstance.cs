using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Serialization;
using NSMedieval.Water;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("CaravanPostComponentInstance", "")]
	public class CaravanPostComponentInstance : BaseComponentInstance
	{
		[NonSerialized]
		private CaravanPostComponentBlueprint blueprint;

		public CaravanPostComponentBlueprint Blueprint => blueprint;

		public CaravanPostComponentInstance(BaseBuildingInstance ownerBuilding, CaravanPostComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Map.CaravanPostComponentManager.RemoveFromCache(this);
				blueprint = null;
				base.Dispose();
			}
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

		public CaravanPostComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<CaravanPostComponentRepository, CaravanPostComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(68, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\CaravanPost\\CaravanPostComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in CaravanPostComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
		}
	}
}
