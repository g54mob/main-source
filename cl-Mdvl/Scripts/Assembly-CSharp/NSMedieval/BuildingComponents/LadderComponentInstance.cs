using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Serialization;
using NSMedieval.Village;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("LadderComponentInstance", "")]
	public class LadderComponentInstance : BaseComponentInstance
	{
		[NonSerialized]
		private LadderComponentBlueprint blueprint;

		private bool showFloor;

		private bool showTop;

		private bool showSupport;

		[field: NonSerialized]
		public Vec3Int Front { get; private set; }

		[field: NonSerialized]
		public Vec3Int Back { get; private set; }

		public bool FloorActive => showFloor;

		public bool TopActive => showTop;

		public bool SupportActive => showSupport;

		public LadderComponentBlueprint Blueprint => blueprint;

		public event Action<bool> ShowFloorEvent;

		public event Action<bool> ShowTopEvent;

		public event Action<bool> ShowSupportEvent;

		public LadderComponentInstance(BaseBuildingInstance ownerBuilding, LadderComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			CalculateFrontAndBackLadderPositions();
			MapNode selfNode = GetNode();
			MapNodeUtils.ForEachNeighbour(selfNode, delegate(MapNode node)
			{
				if (node == selfNode || !node.HasWorldObjects())
				{
					return true;
				}
				foreach (WorldObject worldObject in node.WorldObjects)
				{
					worldObject.UpdateReachability();
				}
				return true;
			});
			base.Map.RoofComponentManager.LadderBuilt(base.OwnerBuilding);
			MonoSingleton<TaskController>.Instance.WaitFor(1f).Then(delegate
			{
				MonoSingleton<ConstructionController>.Instance.LadderConstructed(base.OwnerBuilding);
			});
		}

		public void ShowFloor(bool showFloor)
		{
			this.showFloor = showFloor;
			this.ShowFloorEvent?.Invoke(this.showFloor);
			MonoSingleton<ConstructionController>.Instance.RefreshLadderFloor(base.OwnerBuilding);
		}

		public void ShowTop(bool showTop)
		{
			this.showTop = showTop;
			this.ShowTopEvent?.Invoke(this.showTop);
		}

		public void ShowSupport(bool showSupport)
		{
			this.showSupport = showSupport;
			this.ShowSupportEvent?.Invoke(this.showSupport);
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Map.LadderComponentManager.RemoveFromCache(this);
				base.Dispose();
				this.ShowFloorEvent = null;
				this.ShowTopEvent = null;
				this.ShowSupportEvent = null;
			}
		}

		private void CalculateFrontAndBackLadderPositions()
		{
			float angle = base.Angle;
			if (angle <= 90f)
			{
				if (angle == 0f)
				{
					Front = base.GridDataPosition + Vec3Int.forward;
					Back = base.GridDataPosition + Vec3Int.back;
					return;
				}
				if (angle == 90f)
				{
					Front = base.GridDataPosition + Vec3Int.right;
					Back = base.GridDataPosition + Vec3Int.left;
					return;
				}
			}
			else
			{
				if (angle == 180f)
				{
					Front = base.GridDataPosition + Vec3Int.back;
					Back = base.GridDataPosition + Vec3Int.forward;
					return;
				}
				if (angle == 270f)
				{
					Front = base.GridDataPosition + Vec3Int.left;
					Back = base.GridDataPosition + Vec3Int.right;
					return;
				}
			}
			bool isEnabled;
			FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(23, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Ladders\\LadderComponentInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Weird angle for stairs ");
				messageBuilder.AppendFormatted(base.Angle);
			}
			Log.Warning(messageBuilder);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("showTop", showTop);
			serializer.Write("showFloor", showFloor);
			serializer.Write("showSupport", showSupport);
		}

		public LadderComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<LadderComponentRepository, LadderComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(63, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Ladders\\LadderComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in LadderComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				showTop = deserializer.ReadBool("showTop");
				showFloor = deserializer.ReadBool("showFloor");
				showSupport = deserializer.ReadBool("showSupport");
			}
		}
	}
}
