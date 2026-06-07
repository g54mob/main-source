using UnityEngine;

public class PerkRangeModifyer : MonoBehaviour
{
	public Equippable requiredPerk;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float rangeMultiplyer;

	public AutoAttack autoAttack;

	public PathfindMovementPlayerunit pathfindMovement;

	public bool IsActive => PerkManager.IsEquipped(requiredPerk);

	private void Start()
	{
		if (PerkManager.IsEquipped(requiredPerk))
		{
			foreach (TargetPriority targetPriority in autoAttack.targetPriorities)
			{
				targetPriority.range *= rangeMultiplyer;
			}
			if ((bool)pathfindMovement)
			{
				pathfindMovement.keepDistanceOf *= rangeMultiplyer;
			}
		}
		Object.Destroy(this);
	}
}
