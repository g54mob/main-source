using UnityEngine;

public class UpgradePlayerDmg : MonoBehaviour
{
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float damageMultiplyer;

	private void OnEnable()
	{
		PlayerUpgradeManager.instance.PlayerDamageMultiplyer *= damageMultiplyer;
	}
}
