using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("GallowsComponentInstance", "")]
	public class GallowsComponentInstance : BaseComponentInstance
	{
		[NonSerialized]
		private GallowsComponentBlueprint blueprint;

		[field: NonSerialized]
		public HashSet<Vec3Int> WorkplacePositions { get; } = new HashSet<Vec3Int>();

		[field: NonSerialized]
		public HashSet<Vector3> AnimationPositions { get; } = new HashSet<Vector3>();

		public GallowsComponentBlueprint Blueprint => blueprint;

		public GallowsComponentInstance(BaseBuildingInstance ownerBuilding, GallowsComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Dispose();
				blueprint = null;
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public GallowsComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<GallowsComponentRepository, GallowsComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(64, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Gallows\\GallowsComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in GallowsComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
		}
	}
}
