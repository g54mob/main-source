using Unity.Mathematics;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Chauve1_Projectile : Projectile
	{
		protected const float Radius = 16f;

		protected const float Angle = 15f;

		protected float _cachedAngle;

		protected float _bodyOffsetX;

		protected float _bodyOffsetY;

		protected bool _flipX;

		protected int _flipSign;

		protected bool _isCrit;

		protected float2 _spawnPos;

		protected float2 _tipTargetPos;

		protected PhaserSprite _displaySprite;

		protected MultiTargetTween _alphaTween;

		protected MultiTargetTween _posTween;

		protected virtual bool IsEvo => false;

		protected float BodyOffsetX => 0f;

		protected float BodyOffsetY { get; set; }

		protected virtual string SpriteName => null;

		protected virtual string SpriteObjectName => null;

		protected virtual uint Tint => 0u;

		public virtual bool IsCrit => false;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void SetOrigin()
		{
		}

		protected virtual void MakeCritProjectile()
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}
	}
}
