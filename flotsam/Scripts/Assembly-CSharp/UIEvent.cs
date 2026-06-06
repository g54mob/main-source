public class UIEvent : GameEvent
{
	public enum Type
	{
		None = 0,
		CenterTownheart = 1,
		ResetCamera = 2,
		StorageFilter = 3,
		EjectItem = 4,
		CheatTools = 5,
		ProducerOutput = 6,
		DrifterNameTab = 7,
		MarkerPanel = 8,
		GameSpeedZero = 9,
		GameSpeedOne = 10,
		GameSpeedTwo = 11,
		GameSpeedThree = 12,
		OpenMap = 13,
		ResearchPanel = 14,
		SurvivalGuide = 15,
		AgentRenamedOriginal = 16,
		DiscordLink = 17,
		TwitterLink = 18,
		YoutubeLink = 19,
		RedditLink = 20,
		MantisLink = 21,
		DailyReports = 22,
		Logs = 23,
		LocalizorLink = 24,
		BuildingSnapping = 25,
		BuildingGrid = 26,
		GameSpeedFour = 27,
		ToggleResearch = 128,
		ToggleEnergyOverlay = 129,
		ToggleProductionLimits = 130,
		ToggleAgentPanelMoraleTab = 131
	}

	public Type CallType;

	private static UIEvent _instance;

	private UIEvent(Type callType)
		: base(GameEventType.UIClick)
	{
		CallType = callType;
	}

	public static void Dispatch(Type callType)
	{
		if (callType != Type.None)
		{
			if (_instance == null)
			{
				_instance = new UIEvent(callType);
			}
			else
			{
				_instance.CallType = callType;
			}
			_instance.Dispatch();
		}
	}
}
