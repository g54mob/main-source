using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class GattiWeapon : Weapon
	{
		[FormerlySerializedAs("_explosionPrefab")]
		[SerializeField]
		private Projectile _ExplosionPrefab;

		[FormerlySerializedAs("_gattiScratchPrefab")]
		[SerializeField]
		private Projectile _GattiScratchPrefab;

		[FormerlySerializedAs("_gattiScufflePrefab")]
		[SerializeField]
		private Projectile _GattiScufflePrefab;

		public List<string> _CatBaseFrames;

		private List<float> _randoms;

		private int _randomIndex;

		private BulletPool _explosionPool;

		public BulletPool _scratchPool;

		private BulletPool _scufflePool;

		private int _plusMinusIndex;

		protected List<float> _plusMinus;

		private SfxType[] _sfxArray;

		private int _sfxIndex;

		private float _full;

		private int _chickens;

		private WeaponType _counterWeaponType;

		private Weapon _counterWeapon;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public float GetRandom()
		{
			return 0f;
		}

		public float GetPlusMinus()
		{
			return 0f;
		}

		public SfxType GetSfx()
		{
			return default(SfxType);
		}

		protected override void OnStart()
		{
		}

		private void ChickenUpgradesOnLevelUp()
		{
		}

		private void ApplyChickenUpgrade(int chickens)
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}

		public override bool ApplyLimitBreak(WeightedLimitBreak weightedLimitBreak)
		{
			return false;
		}

		protected override void MakeLevelOne()
		{
		}

		public override void Cleanup()
		{
		}

		public virtual void ChangeBmRate(int value)
		{
		}

		private bool OnCatOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private bool OnCatOverlapsPlayer(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private bool OnBulletOverlapsBullet(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private bool OnBulletOverlapsPickup(CallbackContext context, ArcadeColliderType left, ArcadeColliderType right)
		{
			return false;
		}

		private void DespawnPickup(Pickup pickup)
		{
		}

		private void OnNftPicked(Vector2 position)
		{
		}

		private void OnRoastPicked()
		{
		}

		private bool OnBulletOverlapsEnemyNoKB(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
