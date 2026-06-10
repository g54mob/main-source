using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Serialization;
using NSMedieval.Water;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("TradingPostComponentInstance", "")]
	public class TradingPostComponentInstance : BaseComponentInstance
	{
		[NonSerialized]
		private TradingPostComponentBlueprint blueprint;

		public TradingPostComponentBlueprint Blueprint => blueprint;

		[field: NonSerialized]
		public List<Vec3Int> WorkplacePositions { get; } = new List<Vec3Int>();

		public TradingPostComponentInstance(BaseBuildingInstance ownerBuilding, TradingPostComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Map.TradingPostComponentManager.RemoveFromCache(this);
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

		public TradingPostComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<TradingPostComponentRepository, TradingPostComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(68, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\TradingPost\\TradingPostComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in TradingPostComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
		}
	}
}
