using System;
using System.Collections.Generic;

namespace Dorfromantik
{
	[Serializable]
	public class ChallengeCollectionData_002 : ChallengeCollectionData
	{
		public List<ChallengeData_002> challenges;

		public ChallengeCollectionData_002()
		{
			version = 2;
			challenges = new List<ChallengeData_002>();
		}

		public ChallengeCollectionData_002(SessionQuestsData oldData)
		{
			version = 2;
			challenges = new List<ChallengeData_002>();
			foreach (SessionQuestData sessionQuest in oldData.sessionQuests)
			{
				challenges.Add(new ChallengeData_002(sessionQuest));
			}
		}
	}
}
