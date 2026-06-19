namespace TH20
{
	public class GameModeSandbox : GameMode
	{
		public override string GetMetagameSceneName()
		{
			return base.App.Config.SandboxSceneName;
		}

		public override State CreateStateMachine(MetagameMap metagameMap)
		{
			return new SandboxStateBase(base.App, metagameMap);
		}

		public override bool OnlineFeaturesEnabled()
		{
			return false;
		}

		public override bool LoadMetagame(bool ignoreSave, int saveSlotIndex)
		{
			bool result = base.LoadMetagame(ignoreSave, saveSlotIndex);
			if (base.Metagame != null)
			{
				base.Metagame.ClearUnsavedChangesFlags();
			}
			return result;
		}

		public override void Restart()
		{
			LoadMetagame(ignoreSave: true, 0);
			base.App.SaveSystem.DeleteAllLevelSaves(0);
		}

		public override bool AllowGameToBeSaved()
		{
			return SandboxSaveManager.CurrentSettings != null;
		}

		public override void RestartLevel()
		{
			LoadMetagame(ignoreSave: true, 0);
			base.RestartLevel();
		}
	}
}
