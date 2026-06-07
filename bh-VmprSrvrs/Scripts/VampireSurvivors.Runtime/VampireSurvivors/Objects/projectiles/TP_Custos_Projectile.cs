using Unity.Mathematics;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Custos_Projectile : Projectile
	{
		private MultiTargetTween _alphaTween;

		private MultiTargetTween _posTween;

		private SpriteAnimation _anim;

		private const int AnimFPS = 24;

		protected int _startFrame;

		protected float _posX;

		protected float _posY;

		protected Timer[] _trailTimers;

		protected const float TweenInDuration = 200f;

		protected const float TweenOutDuration = 200f;

		protected const float TweenOutDelay = 300f;

		protected TP_Custos_Weapon _custosWeapon;

		protected TP_Custos4_Weapon _evoWeapon;

		private int _biteCounter;

		private float2 _startingPoint;

		protected float2 ExplosionPoint => default(float2);

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitAnimation(int startFrame)
		{
		}

		public virtual void Bite()
		{
		}

		protected virtual void OnBiteAnimComplete()
		{
		}

		private protected void InitFireTrails()
		{
		}

		private protected void InitIceTrails()
		{
		}

		private protected void InitLightningTrails()
		{
		}

		private void FadeOut()
		{
		}

		public override void Despawn()
		{
		}
	}
}
