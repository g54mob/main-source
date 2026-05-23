using UnityEngine;

public class UpgradeAssassinsTraining : MonoBehaviour
{
	public static UpgradeAssassinsTraining instance;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float autoAttackCooldownDurationMulti = 2f;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float manualAttackCooldownDurationMulti = 2f;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public float activationWindow = 0.5f;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float cooldownMultiForPerfectlyTimedAttacks = 0.5f;

	private void OnEnable()
	{
		instance = this;
		PlayerUpgradeManager.instance.assassinsTraining = true;
		ManualAttack[] componentsInChildren = PlayerMovement.instance.gameObject.GetComponentsInChildren<ManualAttack>(includeInactive: true);
		foreach (ManualAttack manualAttack in componentsInChildren)
		{
			if (manualAttack.autoAttack)
			{
				manualAttack.cooldownTime *= autoAttackCooldownDurationMulti;
			}
			else
			{
				manualAttack.cooldownTime *= manualAttackCooldownDurationMulti;
			}
		}
	}
}
