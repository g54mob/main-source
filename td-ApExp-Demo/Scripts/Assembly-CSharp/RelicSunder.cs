using UnityEngine;

[CreateAssetMenu(fileName = "RelicSunder", menuName = "Upgrade/Relic/Sunder")]
public class RelicSunder : EnhancementUpgrade
{
	[SerializeField]
	private float newSunderMult = 2f;

	public override void ApplyUpgrade()
	{
		GlobalFields.Instance.SunderDmgMult = newSunderMult;
	}
}
