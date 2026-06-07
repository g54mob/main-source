using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class LEM_Planets1_Weapon : LEM_BaseWeapon
	{
		public struct PlanetData
		{
			public string Name;

			public SpriteTextureData SpriteTexture;

			public SpriteTextureData SpriteNegative;

			public SpriteTextureData SpriteCard;

			public float SpriteScale;

			public float BodyRadius;

			public bool FullyRotate;

			public bool CardShown;

			public PlanetData(string name, SpriteTextureData spriteTexture, SpriteTextureData spriteNegative, SpriteTextureData spriteCard, float spriteScale, float bodyRadius, bool fullyRotate = false, bool cardShown = false)
			{
				Name = null;
				SpriteTexture = default(SpriteTextureData);
				SpriteNegative = default(SpriteTextureData);
				SpriteCard = default(SpriteTextureData);
				SpriteScale = 0f;
				BodyRadius = 0f;
				FullyRotate = false;
				CardShown = false;
			}
		}

		[SerializeField]
		private Transform _PlanetContainer;

		[Tooltip("Set to -1 to disable")]
		[SerializeField]
		private float _TiltSpeedDebug;

		private const float _playerCentreYOffset = 0.16f;

		private const float TiltSpeed = 40f;

		private bool _updatePlanets;

		private List<PhaserSprite> _cards;

		protected Timer _negativeTimer;

		private Timer _updatePlanetsTimer;

		protected Tween _tiltTween;

		public List<PlanetData> PlanetList { get; protected set; }

		public Transform PlanetContainer => null;

		protected virtual bool ShowBasePlanetCards => false;

		public bool IsNegative { get; protected set; }

		public float TiltAngle { get; protected set; }

		public float MaxTiltAngle => 0f;

		private Vector2 PlayerCentre => default(Vector2);

		private float NegativeDurationMillis => 0f;

		private float NegativeIntervalMillis => 0f;

		public override float PPower()
		{
			return 0f;
		}

		public override float PAmount()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void DelayInitialPlanets()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateProjectileAmount()
		{
		}

		protected void ShowPlanetCard(int index)
		{
		}

		private void UpdateCards(PhaserSprite card, bool add)
		{
		}

		private void UpdateTilt()
		{
		}

		protected void StartNegativeTimer()
		{
		}

		private void ToggleNegative(bool forceNegative = false)
		{
		}

		private void PlayCardSfx()
		{
		}

		private void PlayNegativeSfx()
		{
		}

		public void ForceNegative()
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
