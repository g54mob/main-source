using DG.Tweening;
using Dorfromantik;
using UnityEngine;

public class PreplacedTileHint : MonoBehaviour
{
	private SectionManager sectionManager;

	private int currentClosestDistance = int.MaxValue;

	[SerializeField]
	private int showDistance = 10;

	[SerializeField]
	private int showPreviewTileDistance = 3;

	[SerializeField]
	private QuestTileGenerator questTileGenerator;

	[SerializeField]
	private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private AudioClipOptions hintAppearSound;

	[SerializeField]
	private AudioClipOptions uncoveredSound;

	[SerializeField]
	private AudioClipOptions connectSound;

	private Vector2Int _003CGridPos_003Ek__BackingField;

	private TilePlacer tilePlacer;

	private TileSlotPreviewer tileSlotPreviewer;

	private QuestTile previewTilePrefab;

	private QuestTile previewTile;

	private int tileRotation;

	private SessionQuestReward reward;

	private int seed;

	private Section_PreplacedTile preplacedTileSection;

	private SessionQuest unlockChallenge;

	public Vector2Int GridPos
	{
		get
		{
			return _003CGridPos_003Ek__BackingField;
		}
		private set
		{
			_003CGridPos_003Ek__BackingField = value;
		}
	}

	public Vector2Int SectionGridPos => preplacedTileSection.GridPos;

	public void Setup(Section_PreplacedTile preplacedTileSection, int seed, Vector2Int gridPos)
	{
		this.seed = seed;
		this.preplacedTileSection = preplacedTileSection;
		GridPos = gridPos;
		base.transform.position = GridCalculator.GridToWorldPos(GridPos);
		tilePlacer = OverwritingSingleton<IngameUi>.Instance.tilePlacer;
		tileSlotPreviewer = OverwritingSingleton<IngameUi>.Instance.tileSlotPreviewer;
		tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed += UpdateState;
		base.gameObject.SetActive(value: false);
	}

	public void RevertToPreviewState()
	{
		if (base.gameObject.activeInHierarchy)
		{
			Debug.Log("not reverting to preview state because preplacedtilehint is already active", this);
			return;
		}
		base.gameObject.SetActive(value: true);
		if (previewTile == null)
		{
			QuestTileId predefinedPreplacedTile = preplacedTileSection.PreplacedTileSectionManager.GetPredefinedPreplacedTile(preplacedTileSection.GridPos);
			CreatePreviewTile(predefinedPreplacedTile);
			if (predefinedPreplacedTile == QuestTileId.Undefined)
			{
				preplacedTileSection.PreplacedTileSectionManager.DefinePreplacedTile(preplacedTileSection.GridPos, previewTile.id);
			}
		}
		previewTile.gameObject.SetActive(value: true);
		TweenSettingsExtensions.From(ShortcutExtensions.DOScale(previewTile.transform, Vector3.one, 2f), new Vector3(1f, 0f, 1f));
		currentClosestDistance = 2;
		AddPreviewTile();
		tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed += UpdateState;
	}

	private void UpdateState(Tile newTile, bool advanceStack)
	{
		int num = GridCalculator.Distance(newTile.GridPos, GridPos);
		if (num < currentClosestDistance)
		{
			currentClosestDistance = num;
		}
		if (currentClosestDistance <= showDistance && !base.gameObject.activeInHierarchy)
		{
			base.gameObject.SetActive(value: true);
			TweenSettingsExtensions.From(ShortcutExtensions.DOScale(base.gameObject.transform, 1f, 3f), 0f);
			if (advanceStack)
			{
				AudioManager.Instance.PlaySoundAtPosition(hintAppearSound, base.transform.position);
			}
		}
		if (currentClosestDistance <= showPreviewTileDistance && previewTile == null)
		{
			QuestTileId predefinedPreplacedTile = preplacedTileSection.PreplacedTileSectionManager.GetPredefinedPreplacedTile(preplacedTileSection.GridPos);
			CreatePreviewTile(predefinedPreplacedTile);
			if (predefinedPreplacedTile == QuestTileId.Undefined)
			{
				preplacedTileSection.PreplacedTileSectionManager.DefinePreplacedTile(preplacedTileSection.GridPos, previewTile.id);
			}
			previewTile.gameObject.SetActive(value: true);
			TweenSettingsExtensions.From(ShortcutExtensions.DOScale(previewTile.transform, Vector3.one, 2f), new Vector3(1f, 0f, 1f));
			if (advanceStack)
			{
				AudioManager.Instance.PlaySoundAtPosition(uncoveredSound, base.transform.position);
			}
		}
		if (currentClosestDistance == 1 && advanceStack)
		{
			RemovePreviewTile();
			QuestTile questTile = questTileGenerator.CreateQuestTile(previewTilePrefab, seed);
			questTile.Rotate(tileRotation, animate: false);
			if ((bool)reward && (bool)reward.sessionQuest)
			{
				questTile.QuestWatcher.SetSessionQuest(reward.sessionQuest);
			}
			tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed -= UpdateState;
			tilePlacer.PlaceTileDirectly(questTile, GridPos);
			tilePlacer.UpdateTileSlotValidity();
			rewardSystem.ConnectPreplacedTile(this);
			previewTile.gameObject.SetActive(value: false);
			base.gameObject.SetActive(value: false);
			AudioManager.Instance.PlaySoundAtPosition(connectSound, base.transform.position);
		}
		if (currentClosestDistance == 0)
		{
			if ((bool)previewTile)
			{
				previewTile.gameObject.SetActive(value: false);
			}
			RemovePreviewTile();
			base.gameObject.SetActive(value: false);
			tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed -= UpdateState;
		}
	}

	private void AddPreviewTile()
	{
		tileSlotPreviewer.AddPreviewTile(previewTile);
	}

	private void RemovePreviewTile()
	{
		tileSlotPreviewer.RemovePreviewTile(previewTile);
	}

	private void CreatePreviewTile(QuestTileId tileId = QuestTileId.Undefined)
	{
		Random.InitState(seed);
		if (tileId == QuestTileId.Undefined)
		{
			unlockChallenge = preplacedTileSection.PreplacedTileSectionManager.GetChallenge();
			previewTilePrefab = preplacedTileSection.QuestManager.Configuration.GetLockedQuestTile(out reward, unlockChallenge);
		}
		else
		{
			previewTilePrefab = preplacedTileSection.QuestManager.Configuration.GetQuestTile(tileId, out reward, out unlockChallenge);
		}
		previewTile = questTileGenerator.CreateQuestTile(previewTilePrefab, seed);
		Random.InitState(seed);
		tileRotation = Random.Range(0, 7);
		previewTile.transform.SetParent(base.transform);
		previewTile.transform.position = base.transform.position;
		previewTile.SetGridPos(GridPos);
		previewTile.Rotate(tileRotation);
		previewTile.TileVisual.ShowReplacedGround(showReplacedGround: true);
		previewTile.QuestWatcher.HideQuest();
		OverwritingSingleton<IngameUi>.Instance.biomeManager.ApplyBiome(previewTile);
		previewTile.SetMaterials(settingsRouter.GetPreviewTileMaterial());
		previewTile.gameObject.SetActive(value: false);
		AddPreviewTile();
		Randomizer.RandomizeSeed();
	}

	private void OnDestroy()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed -= UpdateState;
	}

	public void Clear()
	{
		RemovePreviewTile();
	}
}
