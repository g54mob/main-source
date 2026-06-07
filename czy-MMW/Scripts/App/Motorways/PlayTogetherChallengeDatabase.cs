using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motorways
{
	[CreateAssetMenu(fileName = "New PlayTogetherChallengeDatabase", menuName = "Motorways/Play Together/Play Together Challenge Database", order = 3)]
	public class PlayTogetherChallengeDatabase : ScriptableObject, IEnumerable<PlayTogetherChallengeDatabase.Challenge>, IEnumerable
	{
		[Serializable]
		public class Challenge
		{
			[SerializeField]
			private string challengeId;

			[SerializeField]
			private string mapName;

			[SerializeField]
			private GameMode gameMode;

			public string MapName => mapName;

			public string ChallengeId => challengeId;

			public GameMode GameMode => gameMode;
		}

		[SerializeField]
		private List<Challenge> challenges;

		private Dictionary<string, Challenge> challengeLookup;

		public int Count => challenges.Count;

		public bool TryGetChallenge(string activityName, out Challenge challenge)
		{
			if (challengeLookup == null)
			{
				challengeLookup = new Dictionary<string, Challenge>();
				foreach (Challenge challenge2 in challenges)
				{
					challengeLookup.Add(challenge2.ChallengeId, challenge2);
				}
			}
			return challengeLookup.TryGetValue(activityName, out challenge);
		}

		public IEnumerator<Challenge> GetEnumerator()
		{
			return challenges.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return challenges.GetEnumerator();
		}
	}
}
