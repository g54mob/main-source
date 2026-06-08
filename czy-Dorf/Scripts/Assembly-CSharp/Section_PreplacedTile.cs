using UnityEngine;

public class Section_PreplacedTile : Section
{
	[SerializeField]
	private AnimationCurve tileSpawnProbabilityCurve;

	[SerializeField]
	private PreplacedTileHint preplacedTileHintPrefab;

	[SerializeField]
	private QuestManager questManager;

	private QuestTile preplacedTile;

	private PreplacedTileHint preplacedTileHint;

	private SessionQuestReward reward;

	private PreplacedTileSectionManager _003CPreplacedTileSectionManager_003Ek__BackingField;

	public QuestManager QuestManager => questManager;

	public PreplacedTileHint PreplacedTileHint => preplacedTileHint;

	public PreplacedTileSectionManager PreplacedTileSectionManager
	{
		get
		{
			return _003CPreplacedTileSectionManager_003Ek__BackingField;
		}
		private set
		{
			_003CPreplacedTileSectionManager_003Ek__BackingField = value;
		}
	}

	protected override void SpecificSetup()
	{
		PreplacedTileSectionManager = (PreplacedTileSectionManager)base.SectionManager;
		Random.InitState(seed);
		float value = Random.value;
		Randomizer.RandomizeSeed();
		float num = tileSpawnProbabilityCurve.Evaluate(PreplacedTileSectionManager.pendingLockedChallenges.Count);
		if (value <= num && base.GridPos != Vector2Int.zero)
		{
			preplacedTileHint = Object.Instantiate(preplacedTileHintPrefab, base.transform);
			preplacedTileHint.Setup(this, seed, GridCalculator.WorldToGridPos(base.Center));
		}
	}

	public override void Clear()
	{
		base.Clear();
		if ((bool)preplacedTileHint)
		{
			preplacedTileHint.Clear();
		}
		preplacedTileHint = null;
		preplacedTile = null;
	}
}
