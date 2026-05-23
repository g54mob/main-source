using UnityEngine;

public class UpgradePlayerHp : MonoBehaviour
{
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float healthMultiplyer;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float heatlhRegenMultiplyer;

	private void OnEnable()
	{
		PlayerMovement[] registeredPlayers = PlayerManager.Instance.RegisteredPlayers;
		for (int i = 0; i < registeredPlayers.Length; i++)
		{
			Hp component = registeredPlayers[i].GetComponent<Hp>();
			component.maxHp *= healthMultiplyer;
			component.Heal(float.MaxValue);
		}
		PlayerUpgradeManager.instance.PlayerHealthRegenerationMultiplyer *= heatlhRegenMultiplyer;
	}
}
