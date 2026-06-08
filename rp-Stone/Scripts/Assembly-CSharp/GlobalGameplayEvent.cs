public class GlobalGameplayEvent
{
	public enum Type
	{
		DisablePause = 0,
		EndQuest = 1,
		SetProgressFlag = 2,
		EnablePause = 3,
		ShowHud = 4,
		HideHud = 5,
		ScheduleXpDialog = 6,
		PauseAI = 7
	}

	public static void Execute(Type eventType, string param = null)
	{
		switch (eventType)
		{
		case Type.DisablePause:
			GameStates.Singleton.userCanLeaveQuest = false;
			break;
		case Type.EnablePause:
			GameStates.Singleton.userCanLeaveQuest = true;
			break;
		case Type.EndQuest:
			GameStates.Singleton.level.LevelComplete = true;
			break;
		case Type.SetProgressFlag:
			ProgressFlags.SetFlag(param);
			break;
		case Type.ShowHud:
			GameStates.Singleton.level.QuestData.hideHUD = false;
			break;
		case Type.HideHud:
			GameStates.Singleton.level.QuestData.hideHUD = true;
			break;
		case Type.ScheduleXpDialog:
			GameStates.Singleton.ScheduleXpDialog();
			break;
		case Type.PauseAI:
		{
			float time = Utils.ParseFloat(param);
			GameStates.Singleton.hero.PauseAI(time);
			break;
		}
		}
	}
}
