using System;
using FMODUnity;
using PajamaLlama.Flotsam.Narrative;
using PajamaLlama.Utilities;
using UnityEngine;
using UnityEngine.PajamaLlama;

[CreateAssetMenu(menuName = "Flotsam/Settings/Gameplay Settings")]
public class GameplaySettings : ScriptableObject
{
	private enum EelsPerUnitMode
	{
		Function = 0,
		Tiers = 1
	}

	[Serializable]
	public struct WeightTier
	{
		public float Threshold;

		[Min(0.1f)]
		public float EelsPerUnit;
	}

	[Serializable]
	private class WeightTiers : InspectorHidableArrayBase<WeightTier>
	{
		[SerializeField]
		[NamedArrayElement(new string[] { "Threshold" })]
		private WeightTier[] _weightTiers;

		public override WeightTier[] Array => _weightTiers;
	}

	[Serializable]
	public class GameSpeedSettings
	{
		public GameSpeed[] GameSpeeds;

		public float GameplayTimeScale;

		public float WaterTimeScale;

		public Sprite Icon;

		public EventReference SelectedEvent;
	}

	[Header("World")]
	[Tooltip("The radius in which constructions can be build.")]
	public int ConstructionRadius = 150;

	[Tooltip("The radius in which the player can reach items.")]
	public int MapRadius = 1000;

	[Tooltip("The radius in which the player can interact with items.")]
	public int InteractionRadius = 300;

	[Tooltip("Objects with a selection link that go outside of this radius are destroyed.")]
	public int DestructionRadius = 500;

	[Tooltip("The radius where in drifters can salvage items by swimming.")]
	public int SwimmingRadius = 150;

	[Tooltip("Margin between the two radii at their closest point.")]
	public int RadiaMargin = 20;

	[Tooltip("The amount of Unity units between two of the nodes/dots displayed on the path when navigating on the map.")]
	public float UnitsPerNode = 100f;

	[Tooltip("The length of the spawning arc in DEGREES.\nThis is the arc, laying on the destruction radius, that generates spawning positions.\nE.g. a spawning arc of length 100 will generate spawning positions on the destruction radius that deviate at max 50 degrees from the current angle the townheart is headed towards.")]
	public float SpawningArcLength = 100f;

	[Tooltip("The maximum distance between the spawning circle and a spawned object.")]
	public float SpawnRadiusDeviation = 30f;

	[Header("World Map")]
	[Tooltip("The margin of Fog Of War (FOW) that is cleared outside of a region that is scouted in units. WorldMapFogOfWar setting 'Region Clear Rect Margin' should reflect any changes made tot this value")]
	public float FogOfWarRegionMargin = 100f;

	[Header("Physics")]
	[Tooltip("Properties of the physics in the world.")]
	public WorldPhysicsProperties WorldPhysics;

	[Header("Buoyancy")]
	[Tooltip("Threshold at which flotsam starts being slowed down.")]
	public float SlowdownThreshold = 100f;

	[Tooltip("Lowest multiplier to place on flotsam move force when by townheart.")]
	public float SlowedDownMultiplier = 0.25f;

	[Header("Terrain")]
	public TerrainProperties TerrainProperties;

	[Header("Research")]
	public float ResearchTimePerItem = 10f;

	public ItemProperties StudyItem;

	public float StudyTimePerItem = 500f;

	public float StudyExperiencePerItem = 500f;

	[Header("Town Movement")]
	[SerializeField]
	private EelsPerUnitMode _eelsPerUnitMode;

	[Tooltip("The scalar value used in: OFFSET + weight * scalar + base ^ (weight - 1). [weight = town weight / 1000]. Because the minimum value of the exponential function is 1 the minimum value is: offset + 1")]
	[SerializeField]
	[ConditionalEnumHide("_eelsPerUnitMode", 0, false, HideInInspector = true)]
	private float _eelsPerUnitFunctionOffset;

	[Tooltip("The scalar value used in: offset + weight * SCALAR + base ^ (weight - 1). [weight = town weight / 1000] ")]
	[SerializeField]
	[ConditionalEnumHide("_eelsPerUnitMode", 0, false, HideInInspector = true)]
	private float _eelsPerUnitFunctionScalar = 0.33f;

	[Tooltip("The base value used in: offset + weight * scalar + BASE ^ (weight - 1). [weight = town weight / 1000]")]
	[SerializeField]
	[ConditionalEnumHide("_eelsPerUnitMode", 0, false, HideInInspector = true)]
	[Min(1f)]
	private float _eelsPerUnitFunctionBase = 1.05f;

	[SerializeField]
	[ConditionalEnumHide("_eelsPerUnitMode", 1, false, HideInInspector = true)]
	private WeightTiers _weightTiers;

	public float NextBiomeEnergyCost = 10000f;

	[Space]
	[SerializeField]
	private GameSpeedSettings[] _gameSpeedSettings;

	[Space]
	[Header("Radio Messages")]
	[SerializeField]
	private QuestProperties _radioQuest;

	[SerializeField]
	private float _radioQuestCompletedDelay = 5f;

	[SerializeField]
	private BuildableProperties[] _radioStations;

	[SerializeField]
	private AgentProfile _radioTechnician;

	[SerializeField]
	private RadioMessageProperties[] _radioMessages;

	[SerializeField]
	private int _radioMessageDayInterval = 3;

	[SerializeField]
	private int _radioMessageFailDistance = 3000;

	[Header("Radio Message Receiving Dialogue")]
	[SerializeField]
	private DialogueBranchReference _radioMesssageReceivingDialogue;

	[SerializeField]
	private PlaceableAlertProperties _radioReceivingAlert;

	[SerializeField]
	private PlaceableAlertProperties _radioMoveEastAlert;

	[SerializeField]
	private PlaceableAlertProperties _radioEndTileAlert;

	[SerializeField]
	private PlaceableAlertProperties _radioBlockedAlert;

	[Space]
	[SerializeField]
	private bool _debugRadio;

	[SerializeField]
	[ConditionalHide("_debugRadio", true)]
	private RadioMessageProperties[] _debugRadioMessages;

	[Space]
	[Header("Production")]
	private Producer.ContinuousMode _workshopContinuousMode = Producer.ContinuousMode.Multiple;

	public QuestProperties RadioQuest => _radioQuest;

	public float RadioQuestCompletedDelay => _radioQuestCompletedDelay;

	public BuildableProperties[] RadioStations => _radioStations;

	public AgentProfile RadioTechnician => _radioTechnician;

	public RadioMessageProperties[] RadioMessages => _radioMessages;

	public int RadioMessageDayInterval => _radioMessageDayInterval;

	public int RadioMessageFailDistance => _radioMessageFailDistance;

	public DialogueBranchReference RadioMessageReceivingDialogue => _radioMesssageReceivingDialogue;

	public PlaceableAlertProperties RadioReceivingAlert => _radioReceivingAlert;

	public PlaceableAlertProperties RadioMoveEastAlert => _radioMoveEastAlert;

	public PlaceableAlertProperties RadioEndTileAlert => _radioEndTileAlert;

	public PlaceableAlertProperties RadioBlockedAlert => _radioBlockedAlert;

	public bool DebugRadio => _debugRadio;

	public RadioMessageProperties[] DebugRadioMessages => _debugRadioMessages;

	public Producer.ContinuousMode ProducerContinuousMode => _workshopContinuousMode;

	public static float ReturnConstructionRadius()
	{
		if (GameManager.Settings == null)
		{
			return float.NaN;
		}
		return GameManager.Settings.GameplaySettings.ConstructionRadius;
	}

	public static float ReturnSwimmingRadius()
	{
		if (GameManager.Settings == null)
		{
			return float.NaN;
		}
		return GameManager.Settings.GameplaySettings.SwimmingRadius;
	}

	public static float ReturnInteractionRadius()
	{
		if (GameManager.Settings == null)
		{
			return float.NaN;
		}
		return GameManager.Settings.GameplaySettings.InteractionRadius;
	}

	public static float ReturnNextBiomeEnergyCost()
	{
		if (GameManager.Settings == null)
		{
			return 10000f;
		}
		return GameManager.Settings.GameplaySettings.NextBiomeEnergyCost;
	}

	public static int GetCurrentTownWeightTierIndex()
	{
		return GetWeightTierIndex(Engine.TownWeight);
	}

	public static int GetWeightTierIndex(float townWeight)
	{
		if (GameManager.Settings == null)
		{
			return -1;
		}
		WeightTier[] array = GameManager.Settings.GameplaySettings._weightTiers.Array;
		for (int num = array.Length - 1; num >= 0; num--)
		{
			if (townWeight >= array[num].Threshold)
			{
				return num;
			}
		}
		return -1;
	}

	public static bool TryGetWeightTierData(int index, out WeightTier tierData)
	{
		WeightTier[] array = GameManager.Settings.GameplaySettings._weightTiers.Array;
		if (index >= 0 && array.Length > index)
		{
			tierData = array[index];
			return true;
		}
		tierData = default(WeightTier);
		return false;
	}

	public static float ReturnEelsPerUnit(float weight)
	{
		if (GameManager.Settings == null)
		{
			return 1f;
		}
		return GameManager.Settings.GameplaySettings.ComputeEelsPerUnit(weight);
	}

	public RadioMessageProperties[] ReturnRadioMessages()
	{
		if (Application.isEditor && DebugRadio && !DebugRadioMessages.IsNullOrEmpty())
		{
			return DebugRadioMessages;
		}
		return RadioMessages;
	}

	public static GameSpeedSettings GetGameSpeedSettings(GameSpeed gameSpeed)
	{
		if (GameManager.Settings == null)
		{
			Debug.LogException(new Exception("GameplaySettings have not been initialized yet"));
			return null;
		}
		GameSpeedSettings[] gameSpeedSettings = GameManager.Settings.GameplaySettings._gameSpeedSettings;
		foreach (GameSpeedSettings gameSpeedSettings2 in gameSpeedSettings)
		{
			if (gameSpeedSettings2.GameSpeeds.Contains(gameSpeed))
			{
				return gameSpeedSettings2;
			}
		}
		Debug.LogException(new Exception($"No settings found for GameSpeed: {gameSpeed}."));
		return null;
	}

	private float ComputeEelsPerUnit(float weight)
	{
		switch (_eelsPerUnitMode)
		{
		case EelsPerUnitMode.Function:
		{
			float num = weight / 1000f;
			return _eelsPerUnitFunctionOffset + num * _eelsPerUnitFunctionScalar + Mathf.Pow(_eelsPerUnitFunctionBase, Mathf.Max(0f, num - 1f));
		}
		case EelsPerUnitMode.Tiers:
		{
			if (_weightTiers.IsEmpty())
			{
				Debug.LogException(new NotSupportedException("EelsPerUnitMode.Tiers is active, but the tier list is empty"));
				return 1f;
			}
			WeightTier weightTier = _weightTiers[0];
			for (int i = 1; i < _weightTiers.Length; i++)
			{
				WeightTier weightTier2 = _weightTiers[i];
				if (!(weightTier2.Threshold <= weight))
				{
					break;
				}
				weightTier = weightTier2;
			}
			return weightTier.EelsPerUnit;
		}
		default:
			Debug.LogException(new NotImplementedException());
			return 1f;
		}
	}
}
