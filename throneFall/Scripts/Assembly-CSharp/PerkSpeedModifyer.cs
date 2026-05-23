using UnityEngine;

public class PerkSpeedModifyer : MonoBehaviour
{
	public Equippable requiredPerk;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float speedMultiplyer;

	public PathfindMovementPlayerunit pathfindMovement;

	private void Start()
	{
		if (PerkManager.IsEquipped(requiredPerk) && (bool)pathfindMovement)
		{
			pathfindMovement.movementSpeed *= speedMultiplyer;
		}
		Object.Destroy(this);
	}
}
