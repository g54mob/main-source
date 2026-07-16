using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
public class LevelConfig : ScriptableObject
{
	[SerializeField]
	[Tooltip("A margin for each level wherein track events can't spawn. Measured in track sections. This gives the player time to breathe and the track manager some space to load after a yard before knowing the level layout.")]
	private int MarginsValue;

	[SerializeField]
	[Tooltip("The amount of nodes ahead the player can see.")]
	private int discoveryDst = 3;

	[field: Header("Map Icons")]
	[field: SerializeField]
	public Sprite BossIcon { get; private set; }

	[field: SerializeField]
	public Sprite HubIcon { get; private set; }

	[field: SerializeField]
	public Sprite NodeDot { get; private set; }

	[field: Header("Map Prefabs")]
	[field: SerializeField]
	public GameObject MapNodePrefab { get; private set; }

	[field: SerializeField]
	public GameObject MapLinePrefab { get; private set; }

	[field: SerializeField]
	public GameObject TrainIconPrefab { get; private set; }

	[field: SerializeField]
	public GameObject markerIconPrefab { get; private set; }

	[field: Header("Materials")]
	[field: SerializeField]
	public Material DotsMat { get; private set; }

	[field: SerializeField]
	public Material DotsMovingMat { get; private set; }

	[field: Header("Sounds")]
	[field: SerializeField]
	public AudioClip MapSound { get; private set; }

	[field: Header("Level Settings")]
	[field: SerializeField]
	public LevelDifficulty[] LevelDifficulties { get; set; }

	[field: SerializeField]
	[field: Tooltip("Random range added/subtracted to normalized map progress when deciding level difficulties. E.g. at 0.5 (50% map progress) 0.1 variance would result in a potential normalized difficulty range of 0.4-0.6. It just blurs the difficulty cutoffs.")]
	public float DifficultyVariance { get; set; } = 0.1f;

	public int Margins => (int)((float)MarginsValue * GameManager.Instance.GameSpeedModifier);

	[field: SerializeField]
	[field: Tooltip("Animation curve to control how often turns occur along the tracks. X axis is level index from (1-10+). Y axis is how many tracks between turns (min inclusive max exclusive).")]
	public ParticleSystem.MinMaxCurve EventCadenceTurn { get; private set; }

	[field: SerializeField]
	[field: Tooltip("Animation curve to control how often resources occur along the tracks. X axis is level index from (1-10+). Y axis is how many tracks between turns (min inclusive max exclusive).")]
	public ParticleSystem.MinMaxCurve EventCadenceResource { get; private set; }

	[field: SerializeField]
	[field: Range(0f, 1f)]
	[field: Tooltip("How much should resource appearance increase in W4")]
	public float ResourceSpawnIncrease { get; private set; }

	[field: SerializeField]
	[field: Tooltip("The weight likelihood of ammo resources to spawn compared to scrap.")]
	public float ResourceWeightAmmo { get; private set; }

	[field: SerializeField]
	[field: Tooltip("The weight likelihood of scrap resources to spawn compared to ammo.")]
	public float ResourceWeightScrap { get; private set; }

	[field: SerializeField]
	[field: Tooltip("Percent chance of a resource track event spawning a resource on both sides of the main line.")]
	public float DoubleResourcePercentChance { get; private set; }

	public int DiscoveryDst
	{
		get
		{
			return discoveryDst;
		}
		set
		{
			discoveryDst = value;
			if (GameManager.Instance.IsJourneyStarted)
			{
				LevelManager.Instance.Map.UndiscoverAllNodes();
				LevelManager.Instance.Map.DiscoverNodes();
			}
		}
	}

	public int EventNoticeUnits { get; set; } = 30;

	[field: SerializeField]
	public float MissedAlpha { get; private set; } = 0.1f;

	[field: SerializeField]
	public Color DotColor { get; private set; }

	[field: SerializeField]
	[field: Tooltip("Keep each zones Time from 1-10 (Level Column), value is a multipler that is added to level length")]
	public List<AnimationCurve> ZonesLevelLengthCurve { get; private set; }
}
