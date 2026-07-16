using UnityEngine;

[CreateAssetMenu(fileName = "RelicBurnStackChance", menuName = "Upgrade/Relic/BurnStackChance")]
public class RelicBurnStackChance : EnhancementUpgrade
{
	[SerializeField]
	private float newBurnStackLooseChance = 0.2f;

	public override void ApplyUpgrade()
	{
		GlobalFields.Instance.PlayerBurnStackLooseChance = newBurnStackLooseChance;
	}
}
