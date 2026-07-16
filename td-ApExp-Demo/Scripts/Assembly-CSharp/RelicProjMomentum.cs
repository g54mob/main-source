using UnityEngine;

[CreateAssetMenu(fileName = "RelicProjMomentum", menuName = "Upgrade/Relic/ProjMomentum")]
public class RelicProjMomentum : EnhancementUpgrade
{
	[SerializeField]
	private StatusEffectProjMomentum seProjMomentum;

	public override void ApplyUpgrade()
	{
		for (int i = 0; i < base.StatsObjectsToUpgrade.Length; i++)
		{
			base.StatsObjectsToUpgrade[i].ApplyStatusEffect(seProjMomentum);
		}
	}
}
