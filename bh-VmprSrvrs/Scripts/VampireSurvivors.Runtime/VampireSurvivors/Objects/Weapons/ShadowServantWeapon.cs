using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class ShadowServantWeapon : Weapon
	{
		private PhaserSprite _summonSprite;

		private MultiTargetTween _summonTween;

		private ParticleEmitterManager _particlesManager;

		private GravityWell _well;

		private WeaponType _counterWeaponType;

		private ShadowServantCounterWeapon _counterWeapon;

		[NonSerialized]
		public ParticleSystem PfxEmitter;

		[NonSerialized]
		public string BaseSpriteName;

		[NonSerialized]
		public string SnakeSpriteName;

		[NonSerialized]
		public string SnakeDieSpriteName;

		[NonSerialized]
		public string TrailSpriteName;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void CheckArcanas()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void SummonAnimation()
		{
		}
	}
}
