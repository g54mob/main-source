using UnityEngine;

namespace Brewery.Minigames
{
	[CreateAssetMenu(fileName = "MinigameConfig", menuName = "Brewery/Minigame Config", order = 100)]
	public class MinigameConfig : ScriptableObject
	{
		[Header("Rate Limiting")]
		[Tooltip("Minimum seconds between submissions from the same player")]
		public float submissionCooldownSeconds;

		[Header("Diminishing Returns")]
		[Tooltip("Per-player diminishing factor: grant *= 1 / (1 + factor * playerSubmissionCount)")]
		public float perPlayerDiminishingFactor;

		[Tooltip("Maximum fraction of step cap a single player can earn")]
		public float perPlayerCapFraction;

		[Header("Co-op Scaling")]
		[Tooltip("Global scaler for multiple contributors: 1 / (1 + factor * (contributors - 1))")]
		public float coopDiminishingFactor;

		[Header("Rush Meter")]
		[Tooltip("Rush meter thresholds for tier upgrades")]
		public int rushBronzeThreshold;

		public int rushSilverThreshold;

		public int rushGoldThreshold;

		public int rushMeterMax;

		[Header("Rush Tier Bonuses")]
		[Tooltip("Bronze: percentage bonus to progress credit effectiveness")]
		public float rushBronzeCreditBonus;

		[Tooltip("Silver: instant bonus seconds on tier-up")]
		public float rushSilverInstantBonus;

		[Header("BoilBeats Tuning")]
		public BoilBeatsTuning boilBeats;

		[Header("FoamFrenzy Tuning")]
		public FoamFrenzyTuning foamFrenzy;

		[Header("CoolingCircuit Tuning")]
		public CoolingCircuitTuning coolingCircuit;

		[Header("OxygenEdge Tuning")]
		public OxygenEdgeTuning oxygenEdge;

		[Header("ControlPanel Tuning")]
		public ControlPanelTuning controlPanel;

		[Header("Score Bounds (anti-cheat)")]
		[Tooltip("Maximum possible score per minigame round (loose bound)")]
		public int maxScoreBoilBeats;

		public int maxScoreFoamFrenzy;

		public int maxScoreCoolingCircuit;

		public int maxScoreOxygenEdge;

		public int maxScoreControlPanel;

		[Header("Score-to-Seconds Multipliers")]
		[Tooltip("Base seconds granted per score point for each minigame")]
		public float boilBeatsSecondsPerScore;

		public float foamFrenzySecondsPerScore;

		public float coolingCircuitSecondsPerScore;

		public float oxygenEdgeSecondsPerScore;

		public float controlPanelSecondsPerScore;

		[Header("Overclock")]
		[Tooltip("Score multiplier when overclock is active")]
		public float overclockScoreMultiplier;

		[Header("Debug")]
		public bool enableDebugLogs;

		[Tooltip("Force a specific minigame for all steps (None = normal mapping)")]
		public MinigameId forceMinigameId;

		private void Reset()
		{
		}

		private void OnValidate()
		{
		}

		private void OnEnable()
		{
		}

		public void EnsureDefaults()
		{
		}

		public int GetMaxScore(MinigameId id)
		{
			return 0;
		}

		public float GetSecondsPerScore(MinigameId id)
		{
			return 0f;
		}
	}
}
