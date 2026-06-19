#define LOG_LEVEL_VERBOSE
namespace TH20
{
	public class GameModeCareer : GameMode
	{
		public override string GetMetagameSceneName()
		{
			return base.App.Config.MetagameSceneName;
		}

		public override State CreateStateMachine(MetagameMap metagameMap)
		{
			return new MetagameStateBase(metagameMap);
		}

		public override bool OnlineFeaturesEnabled()
		{
			return true;
		}

		public override bool LoadMetagame(bool ignoreSave, int saveSlotIndex)
		{
			if (base.LoadMetagame(ignoreSave, saveSlotIndex))
			{
				return true;
			}
			if (ignoreSave)
			{
				base.App.SaveMetagameInstantly();
			}
			return false;
		}

		protected override void PostLoad()
		{
			base.PostLoad();
			LevelConfig debugLevelOverride = base.App.GetDebugLevelOverride();
			if (debugLevelOverride != null)
			{
				Logging.Info(LogChannels.GameFlow, "Closing metagame map immediately to load into scene {0}", debugLevelOverride.UniqueId);
				base.MetagameMap.Close(debugLevelOverride);
			}
		}
	}
}
