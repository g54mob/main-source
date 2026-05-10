using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "MatchSettings_default", menuName = "Tower Factory/Match Settings")]
public class MatchSettings : ScriptableObject
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
	private bool buildDuringPause = true;

	[Header("Enemies")]
	[SerializeField]
	private float enemyLifeMultiplier = 1f;

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

	public bool BuildDuringPause => buildDuringPause;

	public float EnemyLifeMultiplier => enemyLifeMultiplier;

	public float FirstRoundDelay => firstRoundDelay;

	public float DefaultRoundDelay => defaultRoundDelay;

	public int MaxCrystalFindersAmount => maxCrystalFindersAmount;

	public float GoldenCoinMultiplierChests => goldenCoinMultiplierChests;

	public float GoldenCoinMultiplierCycles => goldenCoinMultiplierCycles;

	public float GoldenCoinMultiplierVictory => goldenCoinMultiplierVictory;
}
