using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "HardenObstacleAOE", menuName = "Upgrade/Harden/ObstacleAOE")]
public class UpgradeObstacleAOE : EnhancementUpgrade
{
	[SerializeField]
	private List<float> DamageAtRegularMaxSpeed;

	public override void ApplyUpgrade()
	{
		Train.Instance.ObstacleHit += OnTrainHitObstacle;
	}

	private void OnTrainHitObstacle()
	{
		float num = DamageAtRegularMaxSpeed[ZoneManager.Instance.CurrentZoneIndex - 1] * Train.Instance.CurrentSpeedIndex() * GlobalFields.Instance.ObstacleAoeDamageModifier;
		EnemyBase[] array = EnemyManager.Instance.Enemies.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			Health healthComponent = array[i].HealthComponent;
			healthComponent.ChangeHealthWithInfo(new HealthChangeInfo(null, healthComponent, 0f - num, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE));
		}
	}

	public override void OnRemove()
	{
		base.OnRemove();
		Train.Instance.ObstacleHit -= OnTrainHitObstacle;
	}
}
