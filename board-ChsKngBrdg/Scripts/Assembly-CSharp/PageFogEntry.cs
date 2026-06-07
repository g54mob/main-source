using System;

[Serializable]
public class PageFogEntry
{
	public string pageID = "";

	public bool isFog;

	public int turnsToClearFog;

	public int screenIndex;

	public PageFogEntry(string pageID, bool isFog, int turnsToClearFog, int screenIndex)
	{
		this.pageID = pageID;
		this.isFog = isFog;
		this.turnsToClearFog = turnsToClearFog;
		this.screenIndex = screenIndex;
	}
}
