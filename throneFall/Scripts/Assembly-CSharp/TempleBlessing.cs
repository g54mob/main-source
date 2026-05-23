using UnityEngine;

public class TempleBlessing : TempleUpgrade
{
	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float healthMulit = 1.25f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float selfHealMulit = 1.25f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float damageMulit = 1.25f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float speedMulit = 0.75f;

	public override void EnableEffectAtDusk()
	{
		PlayerUpgradeManager.instance.PlayerHealthRegenerationMultiplyer *= selfHealMulit;
		PlayerMovement[] registeredPlayers = PlayerManager.Instance.RegisteredPlayers;
		for (int i = 0; i < registeredPlayers.Length; i++)
		{
			Hp component = registeredPlayers[i].GetComponent<Hp>();
			component.maxHp *= healthMulit;
			component.SetHpToMaxHp();
		}
		PlayerUpgradeManager.instance.PlayerDamageMultiplyer *= damageMulit;
		PlayerMovement.instance.speed *= speedMulit;
		PlayerMovement.instance.sprintSpeed *= speedMulit;
	}

	public override void DisableEffectAtDawn()
	{
		PlayerUpgradeManager.instance.PlayerHealthRegenerationMultiplyer /= selfHealMulit;
		PlayerMovement[] registeredPlayers = PlayerManager.Instance.RegisteredPlayers;
		for (int i = 0; i < registeredPlayers.Length; i++)
		{
			Hp component = registeredPlayers[i].GetComponent<Hp>();
			component.maxHp /= healthMulit;
			component.SetHpToMaxHp();
		}
		PlayerUpgradeManager.instance.PlayerDamageMultiplyer /= damageMulit;
		PlayerMovement.instance.speed /= speedMulit;
		PlayerMovement.instance.sprintSpeed /= speedMulit;
	}
}
