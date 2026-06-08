using System;
using Dorfromantik;

[Serializable]
public class ActiveSessionQuestData_002 : ActiveSessionQuestData
{
	public ChallengeId id;

	public bool effectWasWatched;

	public ActiveSessionQuestData_002(SessionQuest sessionQuest, bool effectWasWatched)
	{
		version = 2;
		id = sessionQuest.id;
		this.effectWasWatched = effectWasWatched;
	}

	public ActiveSessionQuestData_002(ActiveSessionQuestData_001 oldData)
	{
		version = 2;
		id = SessionQuestData.ChallengeIdByName[oldData.sessionQuestId];
		effectWasWatched = oldData.effectWasWatched;
	}
}
