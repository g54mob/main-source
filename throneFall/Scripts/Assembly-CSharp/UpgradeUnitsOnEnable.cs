using UnityEngine;

public class UpgradeUnitsOnEnable : MonoBehaviour
{
	[SerializeField]
	private Hp[] units;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float healthMulti;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float attackMulti;

	private void OnEnable()
	{
		Hp[] array = units;
		foreach (Hp obj in array)
		{
			obj.maxHp *= healthMulti;
			obj.Heal(100000000f);
			AutoAttack[] components = obj.GetComponents<AutoAttack>();
			for (int j = 0; j < components.Length; j++)
			{
				components[j].DamageMultiplyer *= attackMulti;
			}
		}
	}
}
