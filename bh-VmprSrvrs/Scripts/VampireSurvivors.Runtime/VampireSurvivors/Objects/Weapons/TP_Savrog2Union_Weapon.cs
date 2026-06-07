using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Savrog2Union_Weapon : Weapon
	{
		[SerializeField]
		private Projectile _SpinningProjectilePrefab;

		public Color[] _UnionSpriteColours;

		public Color[] _UnionTrailColours;

		private Vector2 radiusOffset90;

		private PhaserSprite clone1;

		private PhaserSprite clone2;

		public uint[] _cloneTint;

		private float _timeStopped;

		private Vector2 _previousVector;

		public Vector2 RadiusOffset;

		private BulletPool _spinningPool;

		private const float Mul = 16.666666f;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		public bool IsUnion { get; set; }

		protected override void OnStart()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private Vector2 Rotate45(Vector2 v)
		{
			return default(Vector2);
		}

		private Vector2 Rotate90(Vector2 v)
		{
			return default(Vector2);
		}

		public override void InternalUpdate()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}

		protected override bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private void MakeOwnerClones()
		{
		}

		private void GenerateParticleSystem()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
