using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Serialization;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("RugComponentInstance", "")]
	public class RugComponentInstance : BaseComponentInstance
	{
		[NonSerialized]
		private readonly RugComponentBlueprint blueprint;

		[field: NonSerialized]
		public HashSet<Vec3Int> WorkplacePositions { get; } = new HashSet<Vec3Int>();

		public RugComponentBlueprint Blueprint => blueprint;

		public RugComponentInstance(BaseBuildingInstance ownerBuilding, RugComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Map.RugComponentManager.RemoveFromCache(this);
				base.Dispose();
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public RugComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<RugComponentRepository, RugComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(60, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Rugs\\RugComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in RugComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
		}
	}
}
