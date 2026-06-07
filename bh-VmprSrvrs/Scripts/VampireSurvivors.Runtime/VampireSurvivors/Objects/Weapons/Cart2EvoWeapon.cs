using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class Cart2EvoWeapon : Weapon
	{
		private const float CartWidth = 3.1f;

		private const float LightWidth = 2.6f;

		private Camera _mainCamera;

		private Transform _topTrackContainer;

		private Transform _bottomTrackContainer;

		private List<PhaserSprite> _topTracks;

		private List<PhaserSprite> _bottomTracks;

		private int _fireCounter;

		private bool _hasImage;

		private bool _hasCharacterImage;

		private PhaserSprite _backSprite;

		private Cart2Weapon _cartWeapon;

		private bool _totalDamageCalculated;

		public float ScaleMultiplier { get; }

		public override float PPower()
		{
			return 0f;
		}

		public override float PArea()
		{
			return 0f;
		}

		public override float PSpeed()
		{
			return 0f;
		}

		protected override void Awake()
		{
		}

		protected override void OnStart()
		{
		}

		private void CreateDetachedCartWeapon()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void PlaySfx(int amount)
		{
		}

		private void GenerateTrainTracks(Vector2 startPos)
		{
		}

		private void UpdateTrainTrack(bool flipped, float yOffset)
		{
		}

		public void ShowTrainTrack(bool show, bool flipped)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Fire()
		{
		}

		private void UpdateFiringInterval()
		{
		}

		private void UpdateCartWeapon()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override float CalculateTotalDamage()
		{
			return 0f;
		}

		protected override void OnUpdate()
		{
		}

		private void InitImage()
		{
		}

		private void UpdateImage()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		public override void Cleanup()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
