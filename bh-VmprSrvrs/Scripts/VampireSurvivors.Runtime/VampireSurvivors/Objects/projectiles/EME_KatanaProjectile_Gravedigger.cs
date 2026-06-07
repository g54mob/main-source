using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_KatanaProjectile_Gravedigger : Projectile
	{
		[SerializeField]
		private ParticleSystem _ParticleVFX;

		private const float VFXScale = 1f;

		private const float VFXDuration = 1700f;

		private const float MaxAreaLimit = 2.5f;

		private float2 _bodySize;

		private float2 _bodyOffset;

		private bool _cachedFlipX;

		private Timer _bodyTimer;

		private Timer _rockTimer;

		private Timer _expireTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateBody()
		{
		}

		public void FireRocks()
		{
		}

		private void PlaySfx()
		{
		}

		public override void Despawn()
		{
		}
	}
}
