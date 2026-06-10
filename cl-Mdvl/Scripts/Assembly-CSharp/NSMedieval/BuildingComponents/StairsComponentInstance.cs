using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Serialization;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("StairsComponentInstance", "")]
	public class StairsComponentInstance : BaseComponentInstance
	{
		[NonSerialized]
		private Vec3Int frontPosition;

		[NonSerialized]
		private StairsComponentBlueprint blueprint;

		public StairsComponentBlueprint Blueprint => blueprint;

		public Vec3Int FrontPosition => frontPosition;

		public StairsComponentInstance(BaseBuildingInstance ownerBuilding, StairsComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			CalculateFrontPosition();
			base.Map.LadderComponentManager.StairsConstructed(this);
		}

		public override void SetupAfterLoading(BaseBuildingInstance baseBuildingInstance)
		{
			base.SetupAfterLoading(baseBuildingInstance);
			CalculateFrontPosition();
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Map.StairsComponentManager.RemoveFromCache(this);
				base.Dispose();
			}
		}

		private void CalculateFrontPosition()
		{
			float angle = base.Angle;
			float angle2 = base.Angle;
			if (angle2 <= 90f)
			{
				if (angle2 == 0f)
				{
					frontPosition = base.GridDataPosition + Vec3Int.left;
					return;
				}
				if (angle2 == 90f)
				{
					frontPosition = base.GridDataPosition + Vec3Int.forward;
					return;
				}
			}
			else
			{
				if (angle2 == 180f)
				{
					frontPosition = base.GridDataPosition + Vec3Int.right;
					return;
				}
				if (angle2 == 270f)
				{
					frontPosition = base.GridDataPosition + Vec3Int.back;
					return;
				}
			}
			bool isEnabled;
			FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(23, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Stairs\\StairsComponentInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Weird angle for stairs ");
				messageBuilder.AppendFormatted(angle);
			}
			Log.Warning(messageBuilder);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public StairsComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<StairsComponentRepository, StairsComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(63, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Stairs\\StairsComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in StairsComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
		}
	}
}
