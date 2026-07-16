using UnityEngine;

[CreateAssetMenu(fileName = "RelicUnlimitedScrapCap", menuName = "Upgrade/Relic/UnlimitedScrapCap")]
public class RelicScrapCap : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		ResourceManager.Instance.Scrap.MaxValue = 9999f;
	}
}
