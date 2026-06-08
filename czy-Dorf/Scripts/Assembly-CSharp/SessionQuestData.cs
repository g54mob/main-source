using System;
using System.Collections.Generic;
using Dorfromantik;

[Serializable]
public class SessionQuestData
{
	public string id;

	public int currentLevel;

	public int currentProgress;

	public int state;

	public static Dictionary<string, ChallengeId> ChallengeIdByName = new Dictionary<string, ChallengeId>
	{
		{
			"tutorial",
			ChallengeId.FirstSteps
		},
		{
			"totalGamesFinished",
			ChallengeId.TrueFan
		},
		{
			"score",
			ChallengeId.Champion
		},
		{
			"totalTilesPlaced",
			ChallengeId.Landscaper
		},
		{
			"formBigGroup_train",
			ChallengeId.Engineer
		},
		{
			"formBigGroup_water",
			ChallengeId.Ocean
		},
		{
			"formBigGroup_fields",
			ChallengeId.BigFarmer
		},
		{
			"totalPerfectPlacements",
			ChallengeId.Perfectionist
		},
		{
			"formBigGroup_village",
			ChallengeId.CityBuilder
		},
		{
			"consecutivePerfectFits",
			ChallengeId.Puzzler
		},
		{
			"formBigGroup_forest",
			ChallengeId.GreenLung
		},
		{
			"totalCloseManyGroups_fields",
			ChallengeId.SelfSufficiency
		},
		{
			"composite_000",
			ChallengeId.Composite_Windmill
		}
	};

	public static Dictionary<ChallengeId, string> ChallengeNameById = new Dictionary<ChallengeId, string>
	{
		{
			ChallengeId.FirstSteps,
			"tutorial"
		},
		{
			ChallengeId.TrueFan,
			"totalGamesFinished"
		},
		{
			ChallengeId.Champion,
			"score"
		},
		{
			ChallengeId.Landscaper,
			"totalTilesPlaced"
		},
		{
			ChallengeId.Engineer,
			"formBigGroup_train"
		},
		{
			ChallengeId.Ocean,
			"formBigGroup_water"
		},
		{
			ChallengeId.BigFarmer,
			"formBigGroup_fields"
		},
		{
			ChallengeId.Perfectionist,
			"totalPerfectPlacements"
		},
		{
			ChallengeId.CityBuilder,
			"formBigGroup_village"
		},
		{
			ChallengeId.Puzzler,
			"consecutivePerfectFits"
		},
		{
			ChallengeId.GreenLung,
			"formBigGroup_forest"
		},
		{
			ChallengeId.SelfSufficiency,
			"totalCloseManyGroups_fields"
		},
		{
			ChallengeId.Composite_Windmill,
			"composite_000"
		}
	};
}
