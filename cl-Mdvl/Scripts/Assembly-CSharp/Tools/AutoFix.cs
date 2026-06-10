using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.State;
using NSMedieval.Village;

namespace Tools
{
	public class AutoFix
	{
		public void FixBorkedPilesData(VillageSaveData data)
		{
			ConcurrentHashSet<WorldObject> worldObjects = data.PlayerVillage.WorldObjectStorage.WorldObjects;
			int count = worldObjects.Count;
			worldObjects.RemoveWhere(delegate(WorldObject item)
			{
				if (!(item is ResourcePileInstance resourcePileInstance))
				{
					return false;
				}
				return (resourcePileInstance.HasDisposed || resourcePileInstance.Stats == null || resourcePileInstance.Stats.HasDisposed || resourcePileInstance.GetStoredResource() == null || resourcePileInstance.GetStoredResource().HasDisposed || resourcePileInstance.GetStoredResource().Amount <= 0) ? true : false;
			});
			if (count != worldObjects.Count)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\AutoFix.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Removed ");
					messageBuilder.AppendFormatted(count);
					messageBuilder.AppendLiteral(" corrupted piles");
				}
				Log.Info(messageBuilder);
			}
		}
	}
}
