using UnityEngine;

[CreateAssetMenu(fileName = "MortarSecondaryShells", menuName = "Upgrade/Mortar/SecondaryShells")]
public class UpgradeMortarSecondaryShells : EnhancementUpgrade
{
	[SerializeField]
	private int secondaryCountLB = 3;

	[SerializeField]
	private int secondaryCountUB = 6;

	[SerializeField]
	public float secondaryMult = 0.5f;

	public override void ApplyUpgrade()
	{
		ModuleMortar moduleByType = Train.Instance.GetModuleByType<ModuleMortar>();
		if ((object)moduleByType != null)
		{
			moduleByType.secondaryCount = (int)ProbUtils.GetRandomWithUpperBias(secondaryCountLB, secondaryCountUB);
			moduleByType.secondaryMult = secondaryMult;
		}
	}
}
