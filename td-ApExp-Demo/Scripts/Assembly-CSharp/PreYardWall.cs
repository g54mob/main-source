using UnityEngine;

public class PreYardWall : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.GetComponent<EnemyBase>() != null)
		{
			EnemyBase component = other.gameObject.GetComponent<EnemyBase>();
			component.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(this, component.HealthComponent, -100f, isPercent: true, null, canRes: false, ignoreArmor: true, ignoreImmunity: true, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
		}
	}
}
