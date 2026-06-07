using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class BloodAstronomiaWeapon : Weapon
	{
		[SerializeField]
		private SpriteRenderer _LineTop;

		[SerializeField]
		private SpriteRenderer _LineBottom;

		[SerializeField]
		private Transform DirectionalDamageCointainer;

		[SerializeField]
		private SpriteRenderer _Image;

		private MultiTargetTween _imageTween;

		private MultiTargetTween _imageTween2;

		private BulletPool _garlicPool;

		private BulletPool _songPool;

		private BulletPool _pentagramPool;

		private BulletPool _laurelPool;

		private BulletPool _lancetPool;

		private ObjectPool _moonExplosionPool;

		private BulletPool _streamPool;

		private BulletPool _rapidusPool;

		private bool _hasRapidus;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		private const float ImagePixelSize = 16f;

		public Weapon Garlic { get; set; }

		public Weapon Song { get; set; }

		public Weapon Pentagram { get; set; }

		public Weapon Laurel { get; set; }

		public Weapon Lancet { get; set; }

		public Weapon Stream { get; set; }

		public Weapon Rapidus { get; set; }

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void InternalUpdate()
		{
		}

		public void SpawnBloodExplosionVfxAt(float2 pos, float damage = 1f, float radius = 1f)
		{
		}

		public void SpawnBloodExplosionVfxAt(float xPos, float yPos, float damage = 1f, float radius = 1f)
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		public override float PPower()
		{
			return 0f;
		}

		public override float PAmount()
		{
			return 0f;
		}

		public override float PArea()
		{
			return 0f;
		}

		public void FireGarlic()
		{
		}

		public void FireSong()
		{
		}

		public void FirePentagram()
		{
		}

		public void FireLaurel()
		{
		}

		public void FireLancet()
		{
		}

		public void FireStream()
		{
		}

		public void FireTPRapidus()
		{
		}

		public override void Cleanup()
		{
		}

		protected override void OnStart()
		{
		}

		protected virtual bool OnGarlicOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected virtual bool OnSongOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected virtual bool OnPentagramOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected virtual bool OnLaurelOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected virtual bool OnLancetOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected virtual bool OnTPRapidusOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
