using Pug.Conversion;
using UnityEngine;

public class TouchAttackConverter : SingleAuthoringComponentConverter<TouchAttackAuthoring>
{
	protected override void Convert(TouchAttackAuthoring authoring)
	{
		AddComponentData(new TouchAttackCD
		{
			ignoreDamageReduction = authoring.ignoreDamageReduction,
			pushback = authoring.pushback,
			cooldown = authoring.cooldownAfterHit,
			hitRadius = authoring.hitRadius,
			triggerAnimation = Animator.StringToHash(authoring.triggerAnimationOnHit)
		});
	}
}
