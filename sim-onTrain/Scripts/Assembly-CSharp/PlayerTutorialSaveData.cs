using System;
using System.Collections.Generic;

[Serializable]
public struct PlayerTutorialSaveData
{
	public bool hasData;

	public int currentGroupIndex;

	public List<TutorialTaskEntry> taskEntries;
}
