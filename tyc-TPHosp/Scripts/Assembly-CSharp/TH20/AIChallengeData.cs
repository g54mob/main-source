using System.Collections.Generic;
using MessagePack;

namespace TH20
{
	[MessagePackObject(false)]
	public class AIChallengeData : ChallengeData
	{
		[IgnoreMember]
		public List<OnlineChallengeEventScore> Scores = new List<OnlineChallengeEventScore>();

		[IgnoreMember]
		public override int ScoreCount => Scores.Count;

		[IgnoreMember]
		public override OnlineChallengeEventScore this[int i] => Scores[i];

		public override float GetScore(int day)
		{
			int num = Scores.FindLastIndex((OnlineChallengeEventScore data) => data.Day < day);
			if (num == -1)
			{
				num = 0;
			}
			if (num >= Scores.Count)
			{
				return 0f;
			}
			return Scores[num].Score;
		}
	}
}
