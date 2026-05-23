using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "SimpleSiege/Equippable Mutation", order = 1)]
public class EquippableMutation : Equippable
{
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float scoreMultiplyerOnWin = 1.2f;
}
