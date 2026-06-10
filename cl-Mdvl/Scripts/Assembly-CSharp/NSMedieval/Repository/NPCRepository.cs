using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class NPCRepository : DynamicJsonRepository<NPCRepository, NPC>
	{
		protected override void Initialize()
		{
			base.Initialize();
			foreach (NPC allItem in GetAllItems())
			{
				if (allItem != null && allItem.DefaultHumanType.StatsModel == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(68, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Enemy\\NPCRepository.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Humanoid '");
						messageBuilder.AppendFormatted(allItem.GetID());
						messageBuilder.AppendLiteral("' has no valid statsModel. This might cause crashes later.");
					}
					Log.Error(messageBuilder);
				}
			}
		}

		protected override string JsonFile()
		{
			return "NPC/NPCs.json";
		}
	}
}
