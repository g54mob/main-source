using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "GameMode_default", menuName = "Tower Factory/Game Mode")]
public class GameMode : ScriptableObject
{
	[SerializeField]
	private string id;

	[SerializeField]
	private Sprite icon;

	[SerializeField]
	private LocalizedString displayName;

	[SerializeField]
	private LocalizedString description;

	[Header("Player Controller")]
	[SerializeField]
	private bool allowPause = true;

	[SerializeField]
	private bool overrideBuildDuringPause;

	[SerializeField]
	private bool buildDuringPause = true;

	[Header("Enemies")]
	[SerializeField]
	private bool overrideMatchDifficulty;

	[SerializeField]
	private MatchSettings.EMatchDifficulty matchDifficulty;

	[SerializeField]
	private float firstRoundDelay;

	[SerializeField]
	private float defaultRoundDelay;

	[Header("Map Generation")]
	[SerializeField]
	[Tooltip("< 0: infinito")]
	private int maxCrystalFindersAmount = -1;

	[Header("Reward")]
	[SerializeField]
	private float goldenCoinMultiplierChests = 1f;

	[SerializeField]
	private float goldenCoinMultiplierCycles = 1f;

	[SerializeField]
	private float goldenCoinMultiplierVictory = 1f;

	public string Id => id;

	public Sprite Icon => icon;

	public LocalizedString DisplayName => displayName;

	public LocalizedString Description => description;

	public bool AllowPause => allowPause;

	public bool OverrideBuildDuringPause
	{
		get
		{
			return overrideBuildDuringPause;
		}
		set
		{
			overrideBuildDuringPause = value;
		}
	}

	public bool BuildDuringPause => buildDuringPause;

	public bool OverrideMatchDifficulty
	{
		get
		{
			return overrideMatchDifficulty;
		}
		set
		{
			overrideMatchDifficulty = value;
		}
	}

	public MatchSettings.EMatchDifficulty MatchDifficulty
	{
		get
		{
			return matchDifficulty;
		}
		set
		{
			matchDifficulty = value;
		}
	}

	public float FirstRoundDelay => firstRoundDelay;

	public float DefaultRoundDelay => defaultRoundDelay;

	public int MaxCrystalFindersAmount => maxCrystalFindersAmount;

	public float GoldenCoinMultiplierChests => goldenCoinMultiplierChests;

	public float GoldenCoinMultiplierCycles => goldenCoinMultiplierCycles;

	public float GoldenCoinMultiplierVictory => goldenCoinMultiplierVictory;
}
