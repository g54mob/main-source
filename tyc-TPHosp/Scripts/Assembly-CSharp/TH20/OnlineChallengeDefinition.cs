using System;
using System.Collections.Generic;
using FullInspector;

namespace TH20
{
	public class OnlineChallengeDefinition : ObjectiveDefinition
	{
		public enum ScoreGeneratorMode
		{
			VerySlow = 0,
			Slow = 1,
			Steady = 2,
			Strong = 3,
			VeryStrong = 4
		}

		public enum ScoreDisplayType
		{
			Number = 0,
			Currency = 1,
			Percentage = 2
		}

		public class RivalScoreData
		{
			public float MinStart;

			public float MaxStart;

			public float MinScore;

			public float MaxScore;

			public ScoreGeneratorMode StartMode;

			public ScoreGeneratorMode FinishMode;
		}

		[InspectorMargin(4)]
		[InspectorDivider]
		[InspectorHeader("Online Challenge")]
		public ScoreDisplayType ScoreDisplayMode;

		public string LeaderboardName;

		[InspectorName("AI Rivals")]
		public Dictionary<SharedInstance<RivalFoundationDefinition>, RivalScoreData> AIRivals;

		public bool ScoreOnlyIncrements;

		public bool ScoresAreErratic;

		public RivalScoreData GetRivalScoreData(RivalFoundationDefinition rivalDef)
		{
			foreach (KeyValuePair<SharedInstance<RivalFoundationDefinition>, RivalScoreData> aIRival in AIRivals)
			{
				if (aIRival.Key.Instance == rivalDef)
				{
					return aIRival.Value;
				}
			}
			return null;
		}

		public AIChallengeData GenerateChallengeData(RivalScoreData scoreData)
		{
			AIChallengeData aIChallengeData = new AIChallengeData();
			float num = RandomUtils.GlobalRandomInstance.NextFloat(scoreData.MinStart, scoreData.MaxStart);
			float num2 = RandomUtils.GlobalRandomInstance.NextFloat(scoreData.MinScore, scoreData.MaxScore);
			int num3 = 0;
			num3 = scoreData.StartMode switch
			{
				ScoreGeneratorMode.VerySlow => (int)((float)TimeLength * 0.45f), 
				ScoreGeneratorMode.Slow => (int)((float)TimeLength * 0.39f), 
				ScoreGeneratorMode.Steady => (int)((float)TimeLength * 0.33f), 
				ScoreGeneratorMode.Strong => (int)((float)TimeLength * 0.21f), 
				ScoreGeneratorMode.VeryStrong => (int)((float)TimeLength * 0.14f), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
			int num4 = TimeLength - 1;
			num4 = scoreData.FinishMode switch
			{
				ScoreGeneratorMode.VerySlow => (int)((float)TimeLength * 0.55f), 
				ScoreGeneratorMode.Slow => (int)((float)TimeLength * 0.61f), 
				ScoreGeneratorMode.Steady => (int)((float)TimeLength * 0.66f), 
				ScoreGeneratorMode.Strong => (int)((float)TimeLength * 0.78f), 
				ScoreGeneratorMode.VeryStrong => (int)((float)TimeLength * 0.86f), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
			float num5 = (num2 - num) * 0.33f / (float)num3;
			int num6 = int.MinValue;
			float num7 = num;
			int i;
			for (i = 0; i < num3; i++)
			{
				int num8 = (int)num7;
				if (num6 != num8)
				{
					aIChallengeData.Scores.Add(OnlineChallengeEventScore.Create(i, num8));
				}
				num6 = num8;
				num7 += num5;
			}
			num5 = (num2 - num) * 0.33f / (float)(num4 - num3);
			for (; i < num4; i++)
			{
				int num9 = (int)num7;
				if (num6 != num9)
				{
					aIChallengeData.Scores.Add(OnlineChallengeEventScore.Create(i, num9));
				}
				num6 = num9;
				num7 += num5;
			}
			num5 = (num2 - num) * 0.33f / (float)(TimeLength - num4);
			for (; i < TimeLength; i++)
			{
				int num10 = (int)num7;
				if (num6 != num10)
				{
					aIChallengeData.Scores.Add(OnlineChallengeEventScore.Create(i, num10));
				}
				num6 = num10;
				num7 += num5;
			}
			return aIChallengeData;
		}
	}
}
