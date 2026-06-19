using Pug.Conversion;
using UnityEngine;

namespace ECS.Conversion
{
	public class BeamWeaponConverter : SingleAuthoringComponentConverter<BeamWeaponAuthoring>
	{
		protected override void Convert(BeamWeaponAuthoring authoring)
		{
			AddComponentData(new BeamWeaponCD
			{
				attackDistance = authoring.attackDistance,
				collideFilterPvPOn = authoring.collideFilterPVPOn.Value,
				collideFilterPvPOff = (authoring.collideFilterPVPOn.Value & 0xFFFFFFFDu),
				attackFilterPvPOn = authoring.attackFilterPVPOn.Value,
				attackFilterPvPOff = (authoring.attackFilterPVPOn.Value & 0xFFFFFFFDu),
				isStickyBeam = authoring.isStickyBeam,
				onlyDamageAtEndOfBeam = authoring.onlyDamageAtEndOfBeam,
				overrideAnimation = ((!string.IsNullOrEmpty(authoring.overrideAnimation)) ? Animator.StringToHash(authoring.overrideAnimation) : 0),
				secondaryOverrideAnimation = ((!string.IsNullOrEmpty(authoring.secondaryOverrideAnimation)) ? Animator.StringToHash(authoring.secondaryOverrideAnimation) : 0),
				useRangedLoopAnimation = authoring.useRangedLoopAnimation,
				expandWhenHeld = authoring.expandWhenHeld,
				expandTimeSeconds = authoring.expandTimeSeconds,
				expandMinDistance = authoring.expandMinDistance,
				windupProjectileID = authoring.secondaryProjectileVariationID,
				extraProjectiles = authoring.extraProjectiles,
				spreadAngle = authoring.spreadAngle,
				spawnOffsetDistance = authoring.spawnOffsetDistance,
				beamVisualFromCenter = authoring.beamVisualFromCenter
			});
			if (authoring.manaCostCondition != ConditionID.None)
			{
				SetProperty("Weapon/ManaCostCondition", authoring.manaCostCondition);
			}
			if (authoring.damageIncreaseCondition != ConditionID.None)
			{
				SetProperty("Weapon/DamageIncreaseCondition", authoring.manaCostCondition);
			}
		}
	}
}
