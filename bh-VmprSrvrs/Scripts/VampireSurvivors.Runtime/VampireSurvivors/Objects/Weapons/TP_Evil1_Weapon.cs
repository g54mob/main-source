using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Evil1_Weapon : Weapon
	{
		private bool _initialisedParticles;

		private PhaserSprite _cursor;

		private bool _lockCursor;

		private EnemyController _lockOnTarget;

		[SerializeField]
		private Projectile _skullPrefab;

		private BulletPool _skullPool;

		[NonSerialized]
		public static float staticTotalTime;

		protected WeaponType _counterWeaponType;

		protected Weapon _counterWeapon;

		protected SantaJavelinCounterWeapon _counterSet;

		protected bool _hasCounterSet;

		public virtual bool IsPrimaryWeapon => false;

		public bool CanFireNormally { get; set; }

		public override float PPower()
		{
			return 0f;
		}

		protected override void Awake()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void OnMirrorData(Vector2 position)
		{
		}

		protected float CalcRadAngle(float x1, float y1, float x2, float y2)
		{
			return 0f;
		}

		public override void ResetFiringTimer()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void FireSkull(Vector2 pos)
		{
		}

		public void FireProjectiles(Vector2 pos, float direction)
		{
		}

		protected void Fire_FireCounter(bool skipTriggers = false)
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}

		protected bool OnSkullOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
