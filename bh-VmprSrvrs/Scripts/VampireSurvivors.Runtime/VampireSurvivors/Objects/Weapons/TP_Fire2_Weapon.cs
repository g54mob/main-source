using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Fire2_Weapon : Weapon
	{
		private bool _initialisedParticles;

		private PhaserSprite _cursor;

		private string _cursorTexture;

		private string _cursorSprite;

		private bool _lockCursor;

		private EnemyController _lockOnTarget;

		private BulletPool _tailPool;

		private bool _hasGemini;

		private TP_Fire1_Weapon _fire1Weapon;

		private float2 RotationDurationRange;

		private float2 ForwardDurationRange;

		public virtual bool IsPrimaryWeapon => false;

		public int TailAmount { get; set; }

		public PhaserSprite Cursor => null;

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

		public void FireProjectiles(Vector2 pos)
		{
		}

		public override void CheckArcanas()
		{
		}

		public Projectile SpawnTailProjectile(float2 pos, int index)
		{
			return null;
		}

		private void DisplayCursorVFX(int _times, float _duration)
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		public override void Cleanup()
		{
		}
	}
}
