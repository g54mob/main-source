using UnityEngine;
using UnityEngine.Serialization;

public class RewardSystemConfiguration : ScriptableObject
{
	public bool collectScore = true;

	public float globalDifficultyMultiplier = 1f;

	public bool rewardCompletedGroups;

	public float groupScoreMultiplier = 3f;

	public float groupCompletionScorePow = 1.2f;

	public bool rewardQuestsWithScore = true;

	[FormerlySerializedAs("scorePerQuestTileReward")]
	[FormerlySerializedAs("rewardPerTileReward")]
	public int questScoreReward = 100;

	public int closingQuestScoreReward = 50;

	public bool rewardTileFit;

	public int tileFitScoreModifier = 2;

	public bool rewardEmptyFittingEdges;

	public ScoreCalculationMethod tileFitScoreCalculationMethod;

	public int perfectPlacementScore = 60;

	public int perfectPlacementTileReward = 2;

	public bool rewardTileClosed;

	public bool rewardOnlyPerfectlyClosed;

	public bool hybridTilesCountAsFittingEdges;

	public int tileClosedScoreModifier;

	public ScoreCalculationMethod tileClosedCalculationMethod;

	public bool rewardNeighborFit;

	public float neighborFitPow = 2f;

	public bool gainQuestRewardTiles = true;

	public AnimationCurve questRewardByScore;
}
