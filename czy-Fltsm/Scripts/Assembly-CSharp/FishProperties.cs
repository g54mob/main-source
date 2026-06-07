using System;
using I2.Loc;
using PajamaLlama.Generic;
using UnityEngine;
using UnityEngine.PajamaLlama;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Flotsam/Animal/Fish")]
public class FishProperties : PersistentProperties
{
	public enum Stage
	{
		Egg = 0,
		Fry = 1,
		Juvenile = 2,
		Adult = 3,
		Harvest = 4
	}

	[Serializable]
	public struct StageData
	{
		public Stage Stage;

		public Sprite Icon;

		public LocalizedString Name;

		public int FeedPortions;

		[MinMaxRangeInt(1, 10)]
		public RangedInt Duration;

		[Range(0.1f, 1f)]
		public float AdvanceChance;
	}

	[SerializeField]
	private Sprite _silhouette;

	[SerializeField]
	private ItemProperties _broodItemProperties;

	[SerializeField]
	private Sprite _hungryIcon;

	[SerializeField]
	private string _hungryTrigger;

	[SerializeField]
	private string _broodActiveTrigger;

	[SerializeField]
	[FormerlySerializedAs("_roeProperties")]
	private ItemProperties _eggProperties;

	[SerializeField]
	[FormerlySerializedAs("_itemProperties")]
	[FormerlySerializedAs("_adultProperties")]
	private ItemProperties _harvestProperties;

	[Header("Feed")]
	[SerializeField]
	private FeedProperties _feedProperties;

	[SerializeField]
	[Tooltip("The amount of food consumed during a single brood cycle")]
	private float _feedRequirementBrooding = 100f;

	[SerializeField]
	[Tooltip("The amount of feed units the fish consumes to be completed")]
	[FormerlySerializedAs("_feedRequirement")]
	private float _feedRequirementGrowing = 100f;

	[SerializeField]
	[Tooltip("The amount of feed units the fish consumes per day")]
	private float _feedConsumptionPerDay;

	[SerializeField]
	[NamedArrayElement(new string[] { "Stage" })]
	private StageData[] _stageData;

	[SerializeField]
	private Stage _spawnStage = Stage.Adult;

	[SerializeField]
	[Range(0.1f, 1f)]
	private float _spawnChance = 1f;

	[SerializeField]
	private int _offspringMaximum = 2;

	[SerializeField]
	private Sprite _offspringIcon;

	[Header("Fish farm panel")]
	[SerializeField]
	private Sprite _headerIcon;

	[SerializeField]
	private Sprite _hatcheryIcon;

	[SerializeField]
	private Sprite _nurseryIcon;

	[SerializeField]
	private Color _slotBackgroundColor = Color.white;

	public override Types Type => Types.FishProperties;

	public Sprite Silhouette => _silhouette;

	public Sprite HungryIcon => _hungryIcon;

	public string HungryTrigger => _hungryTrigger;

	public string ActiveTrigger => _broodActiveTrigger;

	public ItemProperties BroodItemProperties => _broodItemProperties;

	public ItemProperties EggProperties => _eggProperties;

	public ItemProperties HarvestProperties => _harvestProperties;

	public FeedProperties FeedItemProperties => _feedProperties;

	public float FeedRequirementBrooding => _feedRequirementBrooding;

	public float FeedRequirementGrowing => _feedRequirementGrowing;

	public float FeedConsumptionPerDay => _feedConsumptionPerDay;

	public Stage SpawnStage => _spawnStage;

	public float SpawnChance => _spawnChance;

	public int OffspringMaximum => _offspringMaximum;

	public Sprite OffspringIcon => _offspringIcon;

	public Sprite HeaderIcon => _headerIcon;

	public Sprite HatcheryIcon => _hatcheryIcon;

	public Sprite NurseryIcon => _nurseryIcon;

	public Color SlotBackgroundColor => _slotBackgroundColor;

	public StageData GetFirstStage()
	{
		return _stageData[0];
	}

	public bool TryGetStage(Stage stage, out StageData stageData)
	{
		for (int i = 0; i < _stageData.Length; i++)
		{
			stageData = _stageData[i];
			if (stageData.Stage == stage)
			{
				return true;
			}
		}
		stageData = default(StageData);
		return false;
	}

	public StageData TryGetNextStage(StageData currentStage)
	{
		for (int i = 0; i < _stageData.Length; i++)
		{
			if (_stageData[i].Stage == currentStage.Stage && ++i < _stageData.Length)
			{
				return _stageData[i];
			}
		}
		return currentStage;
	}
}
