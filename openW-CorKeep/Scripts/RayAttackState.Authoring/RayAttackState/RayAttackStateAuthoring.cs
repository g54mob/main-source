using UnityEngine;

namespace RayAttackState
{
	[RequireComponent(typeof(NearbyEntitiesTrackerAuthoring))]
	public class RayAttackStateAuthoring : MonoBehaviour
	{
		[Header("Attack Settings")]
		public bool randomInitialAngle;

		public float rotateDegreesPerSecond;

		public float rayLength;

		public float expandTime;

		public float shrinkTime;

		public float offsetFromCenter;

		public float rayRadius;

		public int damage;

		public float damageMultiplier = 1f;

		public bool isStatic;

		public bool isRanged;

		public bool isMagic;

		[Header("Timings")]
		public float attackTimeSeconds;

		public float introTimeSeconds;

		public float activeTimeSeconds;

		public float endingTimeSeconds;

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
					damage = MeleeAttackStateAuthoring.LevelToDamage(num, damageMultiplier);
				}
				if (TryGetComponent<WeaponDamageAuthoring>(out var component))
				{
					damage = component.damage;
				}
			}
		}
	}
}
