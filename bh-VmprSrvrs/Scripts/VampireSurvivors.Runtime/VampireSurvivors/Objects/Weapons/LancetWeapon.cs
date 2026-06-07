using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class LancetWeapon : Weapon
	{
		[SerializeField]
		private GameObject _LancetPierceEffectPrefab;

		private PhaserSprite _image;

		private SpriteAnimation _imageAnim;

		private MultiTargetTween _imageTween;

		private int _ticks;

		private readonly List<Vector2> _targets;

		private readonly List<float> _angles;

		private const string AnimPierce = "pierce";

		public override float PAmount()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Cleanup()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void FireOneLancet(int index, float angle, Vector2 targetPos)
		{
		}

		private void SetupLancetEffect()
		{
		}
	}
}
