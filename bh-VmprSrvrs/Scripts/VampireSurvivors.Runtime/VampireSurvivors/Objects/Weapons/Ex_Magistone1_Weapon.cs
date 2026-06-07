using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class Ex_Magistone1_Weapon : Weapon
	{
		[SerializeField]
		private Projectile _FragmentPrefab;

		[SerializeField]
		private bool _OverrideFragmentBounceY;

		[SerializeField]
		private float _FragmentBounceY;

		[SerializeField]
		private bool _OverrideFragmentSpeed;

		[SerializeField]
		private float _FragmentSpeed;

		private BulletPool _fragmentPool;

		private int _baseFragmentAmount;

		protected List<uint> _tints;

		private int _spawnCounter;

		public bool InverseAreaScalingForFragments => false;

		public bool SimulateZPlaneMovementForFragments => false;

		public bool EnableShadows => false;

		public bool EnableFragmentShadows => false;

		public bool UseSantaWaterTargeting => false;

		public bool FragmentsOnlyHitOnBounce => false;

		public bool OverrideFragmentBounceY => false;

		public float FragmentBounceY => 0f;

		public bool OverrideFragmentSpeed => false;

		public float FragmentSpeed => 0f;

		public BulletPool FragmentPool => null;

		public int FragmentAmount => 0;

		public float ProjectileScaleMultiplier => 0f;

		public List<uint> Tints => null;

		public int SpawnCounter => 0;

		public override float PPower()
		{
			return 0f;
		}

		protected override void OnStart()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		protected virtual void SetTints()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		private Vector2 GetSpawnPosition(int index, out float spawnOffsetY)
		{
			spawnOffsetY = default(float);
			return default(Vector2);
		}

		private bool OnFragmentOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private Color32 GetDamageColor(float value)
		{
			return default(Color32);
		}

		private void ShowDamage(float value, Vector3 position)
		{
		}

		public override void CheckArcanas()
		{
		}

		public override void ParadoxFire()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		public override void Cleanup()
		{
		}

		private void DespawnAllProjectiles()
		{
		}
	}
}
