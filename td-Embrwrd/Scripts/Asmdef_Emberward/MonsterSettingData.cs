using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/MonsterSettingData", order = 1)]
public class MonsterSettingData : ScriptableObject
{
	[SerializeField]
	[Header("怪物種類")]
	private eMonsterType type;

	[SerializeField]
	[Header("怪物尺寸")]
	private eMonsterSize size;

	[SerializeField]
	[Header("是否是可以持續存在的怪物 (不影響回合結束)")]
	private bool isPersistentMonster;

	[SerializeField]
	[Header("是否覆寫攻擊傷害")]
	private bool doOverrideAttackDamage;

	[Header("覆寫攻擊傷害")]
	[SerializeField]
	private int overrideAttackDamage;

	[HideInInspector]
	[Header("可以在哪些場景出現")]
	[SerializeField]
	private eWorldType avaliableWorldType;

	[SerializeField]
	private eWorldType mainWorldType;

	[SerializeField]
	private GameObject prefab;

	[SerializeField]
	private Sprite journalSprite;

	[SerializeField]
	private bool doShowInJournal;

	[SerializeField]
	private int baseHP;

	[SerializeField]
	private int effectiveHP;

	[SerializeField]
	private float moveSpeed_Min;

	[SerializeField]
	private float moveSpeed_Max;

	[SerializeField]
	private float extraRangeSize;

	[SerializeField]
	private int baseReward;

	[SerializeField]
	[Header("產生的時候, 數量的增減幅程度")]
	private float spawnCountModifier;

	[SerializeField]
	[Header("產生的時候, 出現頻率的增減幅程度")]
	private float spawnIntervalModifier;

	public eMonsterType Type => default(eMonsterType);

	public eMonsterSize Size => default(eMonsterSize);

	public eWorldType MainWorldType => default(eWorldType);

	public Sprite JournalSprite => null;

	public int EffectiveHP => 0;

	public eMonsterType GetMonsterType()
	{
		return default(eMonsterType);
	}

	public eMonsterSize GetMonsterSize()
	{
		return default(eMonsterSize);
	}

	public bool IsPersistentMonster()
	{
		return false;
	}

	public GameObject GetPrefab()
	{
		return null;
	}

	public int GetMaxHP(float multiplier = 1f)
	{
		return 0;
	}

	public float GetMinMoveSpeed()
	{
		return 0f;
	}

	public float GetAverageMoveSpeed()
	{
		return 0f;
	}

	public float GetExtraRangeSize()
	{
		return 0f;
	}

	public float GetMoveSpeed(float multiplier = 1f)
	{
		return 0f;
	}

	public int GetDamage()
	{
		return 0;
	}

	public int GetReward(float multiplier = 1f)
	{
		return 0;
	}

	public float GetSpawnCountModifier()
	{
		return 0f;
	}

	public float GetSpawnIntervalModifier()
	{
		return 0f;
	}

	public bool IsAvaliableInWorld(eWorldType world)
	{
		return false;
	}

	public string GetMonsterNameLoc()
	{
		return null;
	}

	public bool DoShowInJournal()
	{
		return false;
	}

	public string GetMonsterJournalStatsLoc(bool doShowActualHP = false)
	{
		return null;
	}

	public string GetMonsterJournalDescriptionLoc()
	{
		return null;
	}
}
