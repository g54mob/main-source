using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Cart2EvoProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _CartSprite;

		[SerializeField]
		private SpriteRenderer _LightSprite;

		private const float Radius = 75f;

		private Cart2EvoWeapon _trueWeapon;

		private Bounds _camBounds;

		private ParticleSystem _pfxEmitter;

		private float _cachedSpeed;

		private float _cachedArea;

		private bool _isOnScreen;

		private bool _canDespawn;

		private bool _isFlipped;

		private int _flipSwitch;

		public bool IsLastCart { get; set; }

		public bool IsFlipped => false;

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

		private void CheckForDespawn()
		{
		}

		public void SetFlipped(bool flipped)
		{
		}

		private void InitSprites()
		{
		}

		private void SetBody()
		{
		}

		private void SetDepths()
		{
		}

		private void GeneratePfx()
		{
		}

		private void UpdatePfx()
		{
		}

		public override void Despawn()
		{
		}

		private void CheckForTrainTrackFadeOut()
		{
		}
	}
}
