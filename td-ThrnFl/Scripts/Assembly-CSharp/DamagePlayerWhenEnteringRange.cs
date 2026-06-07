using UnityEngine;

public class DamagePlayerWhenEnteringRange : MonoBehaviour
{
	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float damageWhenEntering;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float addedDamageWhenEnteringWhileMoving;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float addedDamageWhenEnteringWhileSprinting;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float range;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float slowPlayerFor;

	[SerializeField]
	private TaggedObject myTaggedObject;

	private TaggedObject playerTaggedObj;

	private Transform transformPlayer;

	private Hp playerHp;

	private bool playerWasLastOutsideRange = true;

	private PlayerMovement playerMovement;

	private Vector3 previousPlayerPosition;

	private void Start()
	{
		playerTaggedObj = TagManager.instance.Players[0];
		transformPlayer = playerTaggedObj.transform;
		playerHp = playerTaggedObj.Hp;
		playerMovement = transformPlayer.GetComponent<PlayerMovement>();
		PerkManager instance = PerkManager.instance;
		if (instance.CurrentlyEquipped.Contains(instance.tigerGodPerk))
		{
			damageWhenEntering *= instance.tauntTheTiger_damageMultiplyer;
			addedDamageWhenEnteringWhileMoving *= instance.tauntTheTiger_damageMultiplyer;
			addedDamageWhenEnteringWhileSprinting *= instance.tauntTheTiger_damageMultiplyer;
		}
		if (instance.PrayToWarGodsActive)
		{
			damageWhenEntering *= instance.prayWarGods_dmgMulti;
			addedDamageWhenEnteringWhileMoving *= instance.prayWarGods_dmgMulti;
			addedDamageWhenEnteringWhileSprinting *= instance.prayWarGods_dmgMulti;
		}
	}

	private void Update()
	{
		if (Vector3.Distance(base.transform.position, transformPlayer.position) <= range)
		{
			Vector3 velocity = playerMovement.Velocity;
			Vector3 normalized = (transformPlayer.position - base.transform.position).normalized;
			if (Vector3.Dot(velocity, normalized) < 0f && playerWasLastOutsideRange)
			{
				ApplyDamage();
			}
			playerWasLastOutsideRange = false;
		}
		else
		{
			playerWasLastOutsideRange = true;
		}
	}

	private void ApplyDamage()
	{
		float num = damageWhenEntering;
		if (playerMovement.Moving)
		{
			playerMovement.Slow(slowPlayerFor);
			num += addedDamageWhenEnteringWhileMoving;
		}
		if (playerMovement.Sprinting)
		{
			playerMovement.Slow(slowPlayerFor);
			num += addedDamageWhenEnteringWhileSprinting;
		}
		playerHp.TakeDamage(num, myTaggedObject);
	}
}
