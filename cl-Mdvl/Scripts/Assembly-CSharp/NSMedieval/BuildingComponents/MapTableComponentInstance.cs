using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Serialization;
using NSMedieval.Water;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("MapTableComponentInstance", "")]
	public class MapTableComponentInstance : BaseComponentInstance
	{
		[NonSerialized]
		private readonly MapTableComponentBlueprint blueprint;

		public MapTableComponentBlueprint Blueprint => blueprint;

		public MapTableComponentInstance(BaseBuildingInstance ownerBuilding, MapTableComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			GlobalSaveController.CurrentVillageData.MapTableBuilt = true;
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Map.MapTableComponentManager.RemoveFromCache(this);
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

		public MapTableComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<MapTableComponentRepository, MapTableComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(65, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\MapTable\\MapTableComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in MapTableComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
		}
	}
}
