using Pug.Conversion;
using UnityEngine;

public class MeleeWeaponConverter : SingleAuthoringComponentConverter<MeleeWeaponAuthoring>
{
	protected override void Convert(MeleeWeaponAuthoring authoring)
	{
		if (!authoring.disable)
		{
			_ = authoring.arcAngle;
			bool flag = authoring.attackFXType == AttackFXType.Shockwave;
			bool colliderCenteredOnWindup = flag;
			AddComponentData(new MeleeWeaponCD
			{
				baseHitColliderSize = authoring.baseHitColliderSize,
				extraHitColliderReachSize = authoring.extraHitColliderReachSize,
				overrideAnimation = ((!string.IsNullOrEmpty(authoring.overrideAnimation)) ? Animator.StringToHash(authoring.overrideAnimation) : 0),
				quickHit = authoring.quickHit,
				isBigSpearWeapon = authoring.isBigSpearWeapon,
				isBigSwingWeapon = authoring.isBigSwingWeapon,
				skipAnticipationAnimation = authoring.skipAnticipationAnimation,
				lungeForce = authoring.lungeForce,
				tileDamageAOE = authoring.tileDamageAOE,
				attackFXType = authoring.attackFXType,
				arcAngle = authoring.arcAngle,
				colliderCenteredOnWindup = colliderCenteredOnWindup
			});
		}
	}
}
