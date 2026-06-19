using Pug.Conversion;

public class WeaponDamageConverter : SingleAuthoringComponentConverter<WeaponDamageAuthoring>
{
	protected override void Convert(WeaponDamageAuthoring authoring)
	{
		_ = authoring.damage;
		if (authoring.gameObject.TryGetComponent<AreaLevelAuthoring>(out var component))
		{
			uint seed = 1u;
			ObjectAuthoring component3;
			if (TryGetActiveComponent<EntityMonoBehaviourData>(authoring, out var component2))
			{
				seed = (uint)(component2.objectInfo.objectID + 1);
			}
			else if (TryGetActiveComponent<ObjectAuthoring>(authoring, out component3))
			{
				seed = (uint)component3.objectName.GetHashCode();
			}
			float cooldown = authoring.ComputeCooldown();
			authoring.LevelToDamage(component.level, seed, cooldown);
		}
		AddComponentData(new HasWeaponDamageCD
		{
			isRange = authoring.isRange,
			isMagic = authoring.isMagic
		});
	}
}
