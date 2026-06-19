using System;
using NaughtyAttributes;
using UnityEngine;

[DisallowMultipleComponent]
public class BehaviourAuthoring : MonoBehaviour
{
	[Serializable]
	public struct RobotPatrollerBehaviourSettings
	{
		public int oilMortarDamage;

		public float oilMortarDamageMultiplier;

		public int oilMortarTileDamage;

		public float oilMortarTileDamageMultiplier;

		public int fireMortarDamage;

		public float fireMortarDamageMultiplier;

		public int fireMortarTileDamage;

		public float fireMortarTileDamageMultiplier;
	}

	public BehaviourObjectID objectID;

	[ShowIf("objectID", BehaviourObjectID.RobotPatroller)]
	public RobotPatrollerBehaviourSettings robotPatrollerBehaviourSettings;

	[HideInInspector]
	public AreaLevelAuthoring level;

	private void OnValidate()
	{
		if (!Application.isPlaying)
		{
			if (level == null || level.gameObject != base.gameObject)
			{
				level = GetComponent<AreaLevelAuthoring>();
			}
			if (level != null)
			{
				int num = level.CalculateLevel();
				robotPatrollerBehaviourSettings.oilMortarDamage = ShootMortarProjectileStateAuthoring.LevelToDamage(num, robotPatrollerBehaviourSettings.oilMortarDamageMultiplier);
				robotPatrollerBehaviourSettings.oilMortarTileDamage = MeleeAttackStateAuthoring.LevelToTileDamage(num, robotPatrollerBehaviourSettings.oilMortarTileDamageMultiplier, isEnemy: true);
				robotPatrollerBehaviourSettings.fireMortarDamage = ShootMortarProjectileStateAuthoring.LevelToDamage(num, robotPatrollerBehaviourSettings.fireMortarDamageMultiplier);
				robotPatrollerBehaviourSettings.fireMortarTileDamage = MeleeAttackStateAuthoring.LevelToTileDamage(num, robotPatrollerBehaviourSettings.fireMortarTileDamageMultiplier, isEnemy: true);
			}
		}
	}
}
