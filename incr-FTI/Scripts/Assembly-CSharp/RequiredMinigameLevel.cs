public class RequiredMinigameLevel : Requirement
{
	public MenuPanelType minigamePanelType;

	public int requiredLevel;

	private LevelStat cachedStat;

	public string headerKey;

	public RequiredMinigameLevel(MenuPanelType panelType, int level)
	{
		minigamePanelType = panelType;
		requiredLevel = level;
	}

	public override Requirement GetCopy()
	{
		return new RequiredMinigameLevel(minigamePanelType, requiredLevel);
	}

	public override bool IsMet()
	{
		return CurrentCount() >= requiredLevel;
	}

	public string GetHeaderKey()
	{
		if (headerKey == null && MenuManager.Instance.menuPanels.TryGetValue(minigamePanelType, out var value) && value is MinigamePanelParent minigamePanelParent)
		{
			headerKey = minigamePanelParent.headerLocalizationKey;
		}
		return headerKey;
	}

	public int CurrentCount()
	{
		if (cachedStat == null && MenuManager.Instance.menuPanels.TryGetValue(minigamePanelType, out var value) && value is MinigamePanelParent minigamePanelParent)
		{
			cachedStat = minigamePanelParent.levelStat;
		}
		if (cachedStat != null)
		{
			return cachedStat.level;
		}
		return 0;
	}
}
