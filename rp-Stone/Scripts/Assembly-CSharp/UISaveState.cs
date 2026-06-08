public class UISaveState
{
	public static void ClearProgress()
	{
		if (!(GameStates.Singleton.questScreen == null))
		{
			GameStates.Singleton.questScreen.scrollContainer.SetScrollY(0);
			GameStates.Singleton.workstationScreen.scrollContainer.SetScrollY(0);
			GameStates.Singleton.itemScreen.scrollContainer.SetScrollY(0);
			GameStates.Singleton.money.Clear();
		}
	}

	public static string Serialize()
	{
		SlimJson.BeginSerialization();
		GameStates.State screen = GameStates.Singleton.CurrentState;
		if (!IsValidScreen(screen))
		{
			screen = GameStates.Singleton.previousState;
		}
		if (!IsValidScreen(screen))
		{
			screen = GameStates.State.QuestScreen;
		}
		SlimJson.AddProperty("screen", screen.ToString());
		SlimJson.AddProperty("quest_scroll_y", GameStates.Singleton.questScreen.scrollContainer.ScrollY);
		if (ProgressFlags.GetFlag("show_workstation"))
		{
			SlimJson.AddProperty("workstation_scroll_y", GameStates.Singleton.workstationScreen.scrollContainer.ScrollY);
		}
		if (ProgressFlags.GetFlag("show_items"))
		{
			SlimJson.AddProperty("items_scroll_y", GameStates.Singleton.itemScreen.scrollContainer.ScrollY);
		}
		return SlimJson.EndSerialization();
	}

	public static void Parse(string sjson)
	{
		ClearProgress();
		GameStates.State state = SlimJson.ParseEnum<GameStates.State>(sjson, "screen");
		GameStates.Singleton.SetState(GameStates.State.QuestScreen);
		GameStates.Singleton.questScreen.Activate();
		int scheduledScrollY = SlimJson.ParseInt(sjson, "quest_scroll_y");
		GameStates.Singleton.questScreen.scrollContainer.SetScheduledScrollY(scheduledScrollY);
		if (ProgressFlags.GetFlag("show_workstation"))
		{
			GameStates.Singleton.SetState(GameStates.State.WorkstationScreen);
			GameStates.Singleton.workstationScreen.Activate();
			scheduledScrollY = SlimJson.ParseInt(sjson, "workstation_scroll_y");
			GameStates.Singleton.workstationScreen.scrollContainer.SetScheduledScrollY(scheduledScrollY);
		}
		if (ProgressFlags.GetFlag("show_items"))
		{
			GameStates.Singleton.SetState(GameStates.State.ItemScreen);
			GameStates.Singleton.itemScreen.Activate();
			scheduledScrollY = SlimJson.ParseInt(sjson, "items_scroll_y");
			GameStates.Singleton.itemScreen.scrollContainer.SetScheduledScrollY(scheduledScrollY);
		}
		GameStates.Singleton.customQuestsScreen.MarkDirty();
		GameStates.Singleton.SetState(state);
	}

	private static bool IsValidScreen(GameStates.State screen)
	{
		if (screen != GameStates.State.QuestScreen && screen != GameStates.State.WorkstationScreen && screen != GameStates.State.ItemScreen)
		{
			return screen == GameStates.State.CustomQuests;
		}
		return true;
	}
}
