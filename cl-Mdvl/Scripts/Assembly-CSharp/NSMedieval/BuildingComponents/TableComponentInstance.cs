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
	[FVSerializableKey("TableComponentInstance", "")]
	public class TableComponentInstance : BaseComponentInstance
	{
		[NonSerialized]
		private TableComponentBlueprint blueprint;

		[NonSerialized]
		private HashSet<ChairComponentInstance> chairsNearby = new HashSet<ChairComponentInstance>();

		public TableComponentBlueprint Blueprint => blueprint;

		public HashSet<ChairComponentInstance> ChairsNearby => chairsNearby;

		public TableComponentInstance(BaseBuildingInstance ownerBuilding, TableComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			FindNearbyChairs();
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				RemoveTableFromChairs();
				base.Map.TableComponentManager.RemoveFromCache(this);
				base.Dispose();
				chairsNearby?.Clear();
				chairsNearby = null;
			}
		}

		public override void SetupAfterLoading(BaseBuildingInstance ownerBuilding)
		{
			base.SetupAfterLoading(ownerBuilding);
			FindNearbyChairs();
		}

		protected override void OnWaterLevelChanged(WaterDepthLevel waterDepthLevel)
		{
			bool underWater = waterDepthLevel == WaterDepthLevel.Medium || waterDepthLevel == WaterDepthLevel.High;
			base.OwnerBuilding.SetUnderWater(underWater);
		}

		public void FindNearbyChairs()
		{
			chairsNearby.Clear();
			HashSet<Vec3Int> surroundingPositions = base.OwnerBuilding.GetSurroundingPositions();
			foreach (Vec3Int item in surroundingPositions)
			{
				ChairComponentInstance componentInstance = base.Map.ChairComponentManager.GetComponentInstance(item);
				if (componentInstance != null && !componentInstance.HasDisposed)
				{
					chairsNearby.Add(componentInstance);
					componentInstance.TablesNearby.Add(this);
				}
			}
			HashSetPool<Vec3Int>.Return(surroundingPositions);
		}

		private void RemoveTableFromChairs()
		{
			if (chairsNearby == null || chairsNearby.Count == 0)
			{
				return;
			}
			foreach (ChairComponentInstance item in chairsNearby)
			{
				item.TablesNearby.Remove(this);
			}
			chairsNearby.Clear();
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public TableComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<TableComponentRepository, TableComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(62, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Tables\\TableComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in TableComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
		}
	}
}
