using UnityEngine;

[CreateAssetMenu(fileName = "ClawResources", menuName = "Upgrade/Claw/Resources")]
public class UpgradeClawResources : EnhancementUpgrade
{
	[SerializeField]
	private float resourceGainMult = 0.5f;

	public override void ApplyUpgrade()
	{
		LootManager.Instance.CacheMult += resourceGainMult;
	}

	public override void OnRemove()
	{
		base.OnRemove();
		LootManager.Instance.CacheMult -= resourceGainMult;
	}
}
