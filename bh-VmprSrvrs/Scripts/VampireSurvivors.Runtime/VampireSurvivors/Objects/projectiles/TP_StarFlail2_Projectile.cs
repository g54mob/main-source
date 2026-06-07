using Unity.Mathematics;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_StarFlail2_Projectile : Projectile
	{
		private float _angleTime;

		private Timer _swingTimer;

		private MultiTargetTween _alphaTween;

		private MultiTargetTween _scaleTween;

		private float _multiplier;

		private Projectile _swipeBody;

		private float2 _playerOffset;

		private int _flipNum;

		private bool _isFlipped;

		private bool _isMoving;

		private float _attackDistance;

		private Timer _starCreationTimer;

		private float _swingTime;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void updateAttackAngle(float attackAngle)
		{
		}

		private void LandHit()
		{
		}

		private void CreateStar()
		{
		}

		public override void Despawn()
		{
		}
	}
}
