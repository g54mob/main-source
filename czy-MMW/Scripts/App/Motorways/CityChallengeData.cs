using UnityEngine;

namespace Motorways
{
	[CreateAssetMenu(fileName = "New Challenge", menuName = "Motorways/Challenges/CityChallenge", order = 3)]
	public class CityChallengeData : ScriptableObject
	{
		public ChallengeData[] challenges;

		[EnumSearch(typeof(StringId), true)]
		public string titleStringId;

		[EnumSearch(typeof(StringId), true)]
		public string descriptionStringId;

		public int targetScore;
	}
}
