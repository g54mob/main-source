namespace TH20
{
	public class MetagameStateData : StateMachineData
	{
		public bool CheckForCutscenes = true;

		public bool CheckForPostCutscene = true;

		public bool CheckForSuperBugMessages = true;

		public LevelConfig LoadLevel;

		public bool OnLoadRestartLevel;

		public bool OnLoadSaveOldLevel;
	}
}
