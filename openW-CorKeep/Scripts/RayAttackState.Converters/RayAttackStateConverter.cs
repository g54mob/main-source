using Pug.Conversion;
using RayAttackState;
using Unity.Mathematics;

public class RayAttackStateConverter : SingleAuthoringComponentConverter<RayAttackStateAuthoring>
{
	protected override void Convert(RayAttackStateAuthoring authoring)
	{
		int damage = authoring.damage;
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component))
		{
			damage = MeleeAttackStateAuthoring.LevelToDamage(component.level, authoring.damageMultiplier);
		}
		if (TryGetActiveComponent<WeaponDamageAuthoring>(authoring, out var component2))
		{
			damage = component2.damage;
		}
		SetProperty("RayAttack/isStatic", authoring.isStatic);
		((Converter)this).AddComponentData<RayAttackStateCD>(new RayAttackStateCD
		{
			randomInitialAngle = authoring.randomInitialAngle,
			rotateRadiansPerSecond = math.radians(authoring.rotateDegreesPerSecond),
			rayLength = authoring.rayLength,
			rayRadius = authoring.rayRadius,
			expandTime = authoring.expandTime,
			shrinkTime = authoring.shrinkTime,
			offsetFromCenter = authoring.offsetFromCenter,
			damage = damage,
			introTimeSeconds = authoring.introTimeSeconds,
			attackTimeSeconds = authoring.attackTimeSeconds,
			activeTimeSeconds = authoring.activeTimeSeconds,
			endingTimeSeconds = authoring.endingTimeSeconds,
			isRanged = authoring.isRanged,
			isMagic = authoring.isMagic
		});
		((Converter)this).AddComponentData<RayAttackStateVisualCD>(default(RayAttackStateVisualCD));
		((Converter)this).EnsureHasComponent<AttackCooldownTimerCD>();
	}
}
