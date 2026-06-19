using Pug.Conversion;

public class BehaviourConverter : SingleAuthoringComponentConverter<BehaviourAuthoring>
{
	protected override void Convert(BehaviourAuthoring authoring)
	{
		switch (authoring.objectID)
		{
		case BehaviourObjectID.OrbitalTurret:
			AddComponentData(new OrbitalTurretBehaviourCD
			{
				shieldActivationCounter = -1
			});
			break;
		case BehaviourObjectID.RobotPatroller:
		{
			int oilMortarDamage = authoring.robotPatrollerBehaviourSettings.oilMortarDamage;
			int oilMortarTileDamage = authoring.robotPatrollerBehaviourSettings.oilMortarTileDamage;
			int fireMortarDamage = authoring.robotPatrollerBehaviourSettings.fireMortarDamage;
			int fireMortarTileDamage = authoring.robotPatrollerBehaviourSettings.fireMortarTileDamage;
			if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component))
			{
				oilMortarDamage = ShootMortarProjectileStateAuthoring.LevelToDamage(component.level, authoring.robotPatrollerBehaviourSettings.oilMortarDamageMultiplier);
				oilMortarTileDamage = MeleeAttackStateAuthoring.LevelToTileDamage(component.level, authoring.robotPatrollerBehaviourSettings.oilMortarTileDamageMultiplier, isEnemy: true);
				fireMortarDamage = ShootMortarProjectileStateAuthoring.LevelToDamage(component.level, authoring.robotPatrollerBehaviourSettings.fireMortarDamageMultiplier);
				fireMortarTileDamage = MeleeAttackStateAuthoring.LevelToTileDamage(component.level, authoring.robotPatrollerBehaviourSettings.fireMortarTileDamageMultiplier, isEnemy: true);
			}
			AddComponentData(new RobotPatrollerBehaviourCD
			{
				wasInShootMortarState = true,
				mortarStateCounter = -1,
				oilMortarDamage = oilMortarDamage,
				oilMortarTileDamage = oilMortarTileDamage,
				fireMortarDamage = fireMortarDamage,
				fireMortarTileDamage = fireMortarTileDamage
			});
			break;
		}
		}
	}
}
