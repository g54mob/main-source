using UnityEngine;
using UnityEngine.UI;

public class MonsterUpgradeCard : UpgradeCard
{
	[SerializeField]
	private GameObject banditObject;

	[SerializeField]
	private Text banditText;

	[SerializeField]
	private float extraHealth;

	[SerializeField]
	private float extraArmor;

	[SerializeField]
	private float extraShield;

	[SerializeField]
	private int fortificationBonus;

	[SerializeField]
	private int extraTowerDamage;

	[SerializeField]
	private int extraGoldDrop;

	[SerializeField]
	private int goldDropPenalty;

	[SerializeField]
	private float manaDropOnDeath;

	[SerializeField]
	private float speedBonus;

	[SerializeField]
	private float slowCapMod;

	[SerializeField]
	private float hasteCapMod;

	public override void Upgrade()
	{
		base.Upgrade();
		MonsterManager.instance.extraTowerDamage += extraTowerDamage;
		MonsterManager.instance.extraGoldDrop += extraGoldDrop;
		MonsterManager.instance.goldDropPenalty += goldDropPenalty;
		MonsterManager.instance.manaDropOnDeath += manaDropOnDeath;
		MonsterManager.instance.speedBonus += speedBonus;
		MonsterManager.instance.slowCapModifier += slowCapMod;
		MonsterManager.instance.hasteCapModifier += hasteCapMod;
		MonsterManager.instance.extraHealthPercentage += extraHealth;
		MonsterManager.instance.extraArmorPercentage += extraArmor;
		MonsterManager.instance.extraShieldPercentage += extraShield;
		MonsterManager.instance.fortificationBonus += fortificationBonus;
		MonsterManager.instance.UpdateMonsterUI();
		if (manaDropOnDeath > 0f)
		{
			ResourceManager.instance.UpdateManaHUD();
		}
		if ((double)MonsterManager.instance.slowCapModifier >= 0.3)
		{
			AchievementManager.instance.UnlockAchievement("MaxSlow");
		}
		if (MonsterManager.instance.hasteCapModifier <= -0.6f)
		{
			AchievementManager.instance.UnlockAchievement("MaxHaste");
		}
	}
}
