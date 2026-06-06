using UnityEngine;
using UnityEngine.UI;

public class DOTUpgradeCard : UpgradeCard
{
	[SerializeField]
	private int bleedAmount;

	[SerializeField]
	private int burnAmount;

	[SerializeField]
	private int poisonAmount;

	[SerializeField]
	private GameObject bleedUI;

	[SerializeField]
	private GameObject burnUI;

	[SerializeField]
	private GameObject poisonUI;

	[SerializeField]
	private GameObject stunDmgUI;

	[SerializeField]
	private Text bleedText;

	[SerializeField]
	private Text burnText;

	[SerializeField]
	private Text poisonText;

	[SerializeField]
	private Text stunDmgText;

	[SerializeField]
	private int bonusDamageOnBleed;

	[SerializeField]
	private int bonusDamageOnBurn;

	[SerializeField]
	private int bonusDamageOnPoison;

	[SerializeField]
	private int bonusDamageOnStun;

	[SerializeField]
	private float poisonSlowPercent;

	[SerializeField]
	private float burnSpeedDamagePercentBonus;

	[SerializeField]
	private float bleedingCritChance;

	[SerializeField]
	private float bleedPop;

	[SerializeField]
	private float burnPop;

	[SerializeField]
	private float poisonPop;

	public override void Upgrade()
	{
		base.Upgrade();
		GameManager.instance.dotTick += new Vector3(bleedAmount, burnAmount, poisonAmount);
		MonsterManager.instance.bonusDamageOnBleed += bonusDamageOnBleed;
		MonsterManager.instance.bonusDamageOnBurn += bonusDamageOnBurn;
		MonsterManager.instance.bonusDamageOnPoison += bonusDamageOnPoison;
		MonsterManager.instance.bonusDamageOnStun += bonusDamageOnStun;
		MonsterManager.instance.poisonSlowPercent += poisonSlowPercent;
		MonsterManager.instance.burnSpeedDamagePercentBonus += burnSpeedDamagePercentBonus;
		MonsterManager.instance.bleedingCritChance += bleedingCritChance;
		MonsterManager.instance.bleedPop += bleedPop;
		MonsterManager.instance.burnPop += burnPop;
		MonsterManager.instance.poisonPop += poisonPop;
		if (bleedAmount > 0 || bonusDamageOnBleed > 0 || bleedingCritChance > 0f || bleedPop > 0f)
		{
			bleedUI.SetActive(value: true);
			string text = GameManager.instance.dotTick.x + " \n (+" + (1 + MonsterManager.instance.bonusDamageOnBleed) + ")";
			if (MonsterManager.instance.bleedingCritChance > 0f)
			{
				text += "\nEv";
			}
			if (MonsterManager.instance.bleedPop > 0f)
			{
				text = text + "\n" + Mathf.RoundToInt(MonsterManager.instance.bleedPop * 100f) + "%!";
			}
			bleedText.text = text;
		}
		if (burnAmount > 0 || bonusDamageOnBurn > 0 || burnSpeedDamagePercentBonus > 0f || burnPop > 0f)
		{
			burnUI.SetActive(value: true);
			string text2 = GameManager.instance.dotTick.y + " \n (+" + (1 + MonsterManager.instance.bonusDamageOnBurn) + ")";
			if (MonsterManager.instance.burnSpeedDamagePercentBonus > 0f)
			{
				text2 = text2 + "\nSC " + Mathf.RoundToInt(MonsterManager.instance.burnSpeedDamagePercentBonus);
			}
			if (MonsterManager.instance.burnPop > 0f)
			{
				text2 = text2 + "\n" + Mathf.RoundToInt(MonsterManager.instance.burnPop * 100f) + "%!";
			}
			burnText.text = text2;
		}
		if (poisonAmount > 0 || bonusDamageOnPoison > 0 || poisonSlowPercent > 0f || poisonPop > 0f)
		{
			poisonUI.SetActive(value: true);
			string text3 = GameManager.instance.dotTick.z + " \n (+" + (1 + MonsterManager.instance.bonusDamageOnPoison) + ")";
			if (MonsterManager.instance.poisonSlowPercent > 0f)
			{
				text3 += "\nCC";
			}
			if (MonsterManager.instance.poisonPop > 0f)
			{
				text3 = text3 + "\n" + Mathf.RoundToInt(MonsterManager.instance.poisonPop * 100f) + "%!";
			}
			poisonText.text = text3;
		}
		if (bonusDamageOnStun > 0)
		{
			stunDmgUI.SetActive(value: true);
			stunDmgText.text = "+" + MonsterManager.instance.bonusDamageOnStun;
		}
	}
}
