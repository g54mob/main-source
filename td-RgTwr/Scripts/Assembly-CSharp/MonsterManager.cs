using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
	public static MonsterManager instance;

	[SerializeField]
	private GameObject extraHealthObject;

	[SerializeField]
	private Text extraHealthText;

	[SerializeField]
	private GameObject extraArmorObject;

	[SerializeField]
	private Text extraArmorText;

	[SerializeField]
	private GameObject extraShieldObject;

	[SerializeField]
	private Text extraShieldText;

	[SerializeField]
	private GameObject fortBonusObject;

	[SerializeField]
	private Text fortBonusText;

	[SerializeField]
	private GameObject hasteBonusObject;

	[SerializeField]
	private Text hasteBonusText;

	[SerializeField]
	private GameObject slowBonusObject;

	[SerializeField]
	private Text slowBonusText;

	[SerializeField]
	private GameObject speedBonusObject;

	[SerializeField]
	private Text speedBonusText;

	[SerializeField]
	private GameObject damageBonusObject;

	[SerializeField]
	private Text damageBonusText;

	[SerializeField]
	private GameObject extraGoldObject;

	[SerializeField]
	private Text extraGoldText;

	public float extraHealthPercentage;

	public float extraArmorPercentage;

	public float extraShieldPercentage;

	public int fortificationBonus;

	public int extraTowerDamage;

	public int extraGoldDrop;

	public int goldDropPenalty;

	public float manaDropOnDeath;

	public float speedBonus;

	public int bonusDamageOnBleed;

	public int bonusDamageOnBurn;

	public int bonusDamageOnPoison;

	public int bonusDamageOnStun;

	public float poisonSlowPercent;

	public float burnSpeedDamagePercentBonus;

	public float bleedingCritChance;

	public float bleedPop;

	public float burnPop;

	public float poisonPop;

	public float slowCapModifier;

	public float hasteCapModifier;

	private void Awake()
	{
		instance = this;
	}

	public void UpdateMonsterUI()
	{
		if (extraHealthPercentage > 0f)
		{
			extraHealthObject.SetActive(value: true);
			extraHealthText.text = "+" + Mathf.RoundToInt(100f * extraHealthPercentage) + "% Health";
		}
		if (extraArmorPercentage > 0f)
		{
			extraArmorObject.SetActive(value: true);
			extraArmorText.text = "+" + Mathf.RoundToInt(100f * extraArmorPercentage) + "% Armor";
		}
		if (extraShieldPercentage > 0f)
		{
			extraShieldObject.SetActive(value: true);
			extraShieldText.text = "+" + Mathf.RoundToInt(100f * extraShieldPercentage) + "% Shield";
		}
		AchievementManager.instance.EnemyHealthScale(extraHealthPercentage);
		AchievementManager.instance.EnemyArmorScale(extraArmorPercentage);
		AchievementManager.instance.EnemyShieldScale(extraShieldPercentage);
		if (fortificationBonus > 0)
		{
			fortBonusObject.SetActive(value: true);
			fortBonusText.text = fortificationBonus + 5 + " (fortification)";
		}
		if (hasteCapModifier != 0f)
		{
			hasteBonusObject.SetActive(value: true);
			hasteBonusText.text = Mathf.RoundToInt(60f + 100f * hasteCapModifier) + "% Maximum Haste";
		}
		if (slowCapModifier != 0f)
		{
			slowBonusObject.SetActive(value: true);
			slowBonusText.text = Mathf.RoundToInt(60f + 100f * slowCapModifier) + "% Maximum Slow";
		}
		if (speedBonus != 0f)
		{
			speedBonusObject.SetActive(value: true);
			speedBonusText.text = "+" + speedBonus + " Move Speed";
		}
		if (extraTowerDamage > 0)
		{
			damageBonusObject.SetActive(value: true);
			damageBonusText.text = "+" + extraTowerDamage + " Damage";
		}
		if (extraGoldDrop + goldDropPenalty > 0)
		{
			extraGoldObject.SetActive(value: true);
			extraGoldText.text = "+" + (extraGoldDrop + goldDropPenalty) + "g";
		}
		else if (extraGoldDrop + goldDropPenalty < 0)
		{
			extraGoldObject.SetActive(value: true);
			extraGoldText.text = extraGoldDrop + goldDropPenalty + "g";
		}
	}

	public void EndlessBuff(int currentLevel)
	{
		int num = currentLevel - SpawnManager.instance.lastLevel;
		extraHealthPercentage += 0.05f * (float)num;
		extraArmorPercentage += 0.05f * (float)num;
		extraShieldPercentage += 0.05f * (float)num;
		speedBonus += 0.1f;
		goldDropPenalty -= 2;
		GameManager.instance.universityBonus -= 2;
		UpdateMonsterUI();
	}
}
