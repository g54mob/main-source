using UnityEngine;

[RequireComponent(typeof(Hp))]
public class PlayerHpRegen : MonoBehaviour
{
	[SerializeField]
	private PlayerUpgradeManager playerUpgradeManager;

	private Hp hp;

	public float delayTillRegenerationStarts;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public float standardHealingPerSecond;

	private float timeSinceLastTakenDamage;

	private float hpRemember;

	private bool heavyArmorEquipped;

	private bool godsLotionEquipped;

	[SerializeField]
	private Equippable heavyArmorPerk;

	[SerializeField]
	private Equippable godsLotionPerk;

	public float HealingPerSecond => standardHealingPerSecond * playerUpgradeManager.PlayerHealthRegenerationMultiplyer;

	private void Start()
	{
		hp = GetComponent<Hp>();
		hpRemember = hp.HpValue;
		heavyArmorEquipped = PerkManager.IsEquipped(heavyArmorPerk);
		godsLotionEquipped = PerkManager.IsEquipped(godsLotionPerk);
		if (heavyArmorEquipped)
		{
			hp.maxHp *= PerkManager.instance.heavyArmor_HpMultiplyer;
			playerUpgradeManager.PlayerHealthRegenerationMultiplyer *= PerkManager.instance.heavyArmor_SelfHealMultiplyer;
			hp.Heal(float.MaxValue);
		}
		if (godsLotionEquipped)
		{
			delayTillRegenerationStarts *= PerkManager.instance.godsLotion_RegenDelayMultiplyer;
			playerUpgradeManager.PlayerHealthRegenerationMultiplyer *= PerkManager.instance.godsLotion_RegenRateMultiplyer;
		}
	}

	private void Update()
	{
		timeSinceLastTakenDamage += Time.deltaTime;
		if (hp.HpValue < hpRemember)
		{
			timeSinceLastTakenDamage = 0f;
		}
		hpRemember = hp.HpValue;
		if (timeSinceLastTakenDamage >= delayTillRegenerationStarts)
		{
			hp.Heal(HealingPerSecond * Time.deltaTime);
		}
	}
}
