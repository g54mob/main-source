using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class JubileeWeapon : Weapon
	{
		private List<ParticleSystem> _fwEmitters;

		private GravityWell _well;

		private List<SpriteRenderer> _rays;

		private List<MultiTargetTween> _raysTween;

		private int _raysLevel;

		private Timer _soundTimer;

		private SfxType[] _soundArray;

		private bool _makeRaysOnUpdate;

		private bool _canPlaySounds;

		private int _soundIndex;

		private ParticleEmitterManager _particles;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void MakeFireworks()
		{
		}

		private void MakeRays()
		{
		}

		public ParticleSystem GetFwEmitters(int index)
		{
			return null;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected override void OnUpdate()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		protected override bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}
	}
}
