using UnityEngine;

public class PukeLogic : MonoBehaviour
{
	[SerializeField]
	private Hp hpToDamage;

	[SerializeField]
	private float tickCooldown;

	[SerializeField]
	private float percentageDamage;

	[SerializeField]
	private float realDamage;

	[SerializeField]
	private Hp hpOwn;

	[SerializeField]
	private float ownDps;

	private float cooldown;

	private void Update()
	{
		cooldown -= Time.deltaTime;
		if (cooldown < 0f)
		{
			cooldown += tickCooldown;
			Attack();
		}
	}

	private void Attack()
	{
		hpToDamage.TakeDamage((hpToDamage.HpValue * percentageDamage + realDamage) / BlacksmithUpgrades.instance.rangedResistance);
		hpOwn.TakeDamage(ownDps, null, causedByPlayer: false, invokeFeedbackEvents: false);
	}
}
