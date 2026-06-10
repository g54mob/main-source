using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Serialization;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("DecorationComponentInstance", "")]
	public class DecorationComponentInstance : BaseComponentInstance
	{
		[NonSerialized]
		private readonly DecorationComponentBlueprint blueprint;

		[field: NonSerialized]
		public HashSet<Vec3Int> WorkplacePositions { get; } = new HashSet<Vec3Int>();

		public DecorationComponentBlueprint Blueprint => blueprint;

		public DecorationComponentInstance(BaseBuildingInstance ownerBuilding, DecorationComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Map.DecorationComponentManager.RemoveFromCache(this);
				base.Dispose();
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public DecorationComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<DecorationComponentRepository, DecorationComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(67, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Decorations\\DecorationComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in DecorationComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
		}
	}
}
