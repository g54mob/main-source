using UnityEngine;

public class BlacksmithUpgrades : MonoBehaviour
{
	public static BlacksmithUpgrades instance;

	public float meleeDamage = 1f;

	public float rangedDamage = 1f;

	public float meleeResistance = 1f;

	public float rangedResistance = 1f;

	public float unitRespawnSpeedMulti = 1f;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		if (PerkManager.instance.MeleeResistenceActive)
		{
			meleeResistance *= PerkManager.instance.meleeResistence_AmountMulti;
		}
		if (PerkManager.instance.RangedResistenceActive)
		{
			rangedResistance *= PerkManager.instance.rangedResistence_AmountMulti;
		}
		if (PerkManager.instance.RangedDamageActive)
		{
			rangedDamage *= PerkManager.instance.rangedDamage_multi;
		}
		if (PerkManager.instance.MeleeDamageActive)
		{
			meleeDamage *= PerkManager.instance.meleeDamage_multi;
		}
	}

	private void Update()
	{
	}
}
