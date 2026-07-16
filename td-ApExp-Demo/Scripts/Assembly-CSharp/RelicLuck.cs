using UnityEngine;

[CreateAssetMenu(fileName = "RelicLuck", menuName = "Upgrade/Relic/Luck")]
public class RelicLuck : EnhancementUpgrade
{
	[SerializeField]
	private float baseLuckPct;

	public override void ApplyUpgrade()
	{
		GlobalFields.Instance.LuckPct += baseLuckPct;
	}
}
