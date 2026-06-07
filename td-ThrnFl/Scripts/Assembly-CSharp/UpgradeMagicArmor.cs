using UnityEngine;

public class UpgradeMagicArmor : MonoBehaviour
{
	public static UpgradeMagicArmor instance;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public float damageVersusMelee = 1f;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public float damageVersusRanged = 1f;

	private void Awake()
	{
		instance = this;
	}

	private void OnEnable()
	{
		PlayerUpgradeManager.instance.magicArmor = true;
	}
}
