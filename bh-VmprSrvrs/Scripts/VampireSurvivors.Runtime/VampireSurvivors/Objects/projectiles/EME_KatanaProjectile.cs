using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_KatanaProjectile : Projectile
	{
		[SerializeField]
		private ParticleSystem _SlashVFX;

		private const float XOffset = 0.24f;

		private const float XRepeatOffset = 0.08f;

		private const float YOffset = 0.16f;

		private const float VFXScale = 0.4f;

		private const float VFXDuration = 640f;

		private const float BodyDuration = 420f;

		private float2 _bodySize;

		private float2 _bodyOffset;

		private float2 _offsetFromPlayer;

		private bool _cachedFlipX;

		private Timer _bodyTimer;

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

		private void UpdatePosition()
		{
		}

		private void InitBody()
		{
		}

		private void UpdateBody()
		{
		}

		public override void Despawn()
		{
		}
	}
}
