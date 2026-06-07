using System.Collections.Generic;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class CorridorWeapon : Weapon
	{
		[SerializeField]
		private GameObject _CorridorProjectilePrefab;

		[SerializeField]
		private GameObject _LancetPierceEffectPrefab;

		private ObjectPool _effectPool;

		private BulletPool _corridorPool;

		private int _ticks;

		private readonly List<Vector2> _targets;

		private readonly List<float> _angles;

		public override float PAmount()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Cleanup()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void FireOneLancet(int index, float angle, Vector2 targetPos)
		{
		}

		private void FireCorridor()
		{
		}

		private ObjectPool GeneratePool(GameObject prefab, int defaultSize = 1, int maxSize = -1)
		{
			return null;
		}

		private void CleanupPool(ObjectPool pool)
		{
		}

		private bool OnCorridorOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
