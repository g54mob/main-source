using System;
using System.Collections.Generic;

[Serializable]
public class SessionQuestsData
{
	public List<SessionQuestData> sessionQuests;

	public SessionQuestsData()
	{
		sessionQuests = new List<SessionQuestData>();
	}
}
