using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Serialization;
using NSMedieval.Utils.Pool;
using NSMedieval.Water;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("ChairComponentInstance", "")]
	public class ChairComponentInstance : BaseComponentInstance
	{
		[NonSerialized]
		private ChairComponentBlueprint blueprint;

		[NonSerialized]
		private HashSet<TableComponentInstance> tablesNearby = new HashSet<TableComponentInstance>();

		public ChairComponentBlueprint Blueprint => blueprint;

		public HashSet<TableComponentInstance> TablesNearby => tablesNearby;

		public ChairComponentInstance(BaseBuildingInstance ownerBuilding, ChairComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			FindNearbyTables();
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				RemoveChairFromTables();
				base.Map.ChairComponentManager.RemoveFromCache(this);
				base.Dispose();
				tablesNearby = null;
				blueprint = null;
			}
		}

		public override void SetupAfterLoading(BaseBuildingInstance ownerBuilding)
		{
			base.SetupAfterLoading(ownerBuilding);
			base.OwnerBuilding.AddNewComponent(blueprint.ComponentType);
			FindNearbyTables();
		}

		public void FindNearbyTables()
		{
			tablesNearby.Clear();
			HashSet<Vec3Int> surroundingPositions = base.OwnerBuilding.GetSurroundingPositions();
			foreach (Vec3Int item in surroundingPositions)
			{
				TableComponentInstance componentInstance = base.Map.TableComponentManager.GetComponentInstance(item);
				if (componentInstance != null && !componentInstance.HasDisposed)
				{
					tablesNearby.Add(componentInstance);
					componentInstance.ChairsNearby.Add(this);
				}
			}
			HashSetPool<Vec3Int>.Return(surroundingPositions);
		}

		private void RemoveChairFromTables()
		{
			if (tablesNearby == null || tablesNearby.Count == 0)
			{
				return;
			}
			foreach (TableComponentInstance item in tablesNearby)
			{
				item.ChairsNearby.Remove(this);
			}
			tablesNearby.Clear();
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

		public ChairComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<ChairComponentRepository, ChairComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(62, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Chairs\\ChairComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in ChairComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
		}
	}
}
