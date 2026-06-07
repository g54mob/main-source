using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class GlassFandango2Weapon : GlassFandangoWeapon
	{
		[SerializeField]
		private Transform _Sky;

		[SerializeField]
		private MeshRenderer _SkyMesh;

		[SerializeField]
		private float StaggerA;

		[SerializeField]
		private float StaggerB;

		[SerializeField]
		private float StaggerC;

		[SerializeField]
		private SfxType HitSound;

		private ParticleEmitterManager _zodiacBlurEmitterManager;

		private ParticleSystem _zodiacBlurEmitter;

		private bool _initialisedZodiacParticles;

		private static readonly int _ScrollSpeedX;

		private static readonly int _ScrollSpeedY;

		private static readonly int _AlphaMul;

		private List<PhaserSprite> _doilies;

		private bool _isStarryHeavenRunning;

		private bool _isStarryHeavenStopping;

		private float _StarryExecutionDelta;

		private readonly float _StarryExecutionTime;

		private Timer _restartTimer;

		private PhaserSprite _sprZodiac;

		private MultiTargetTween _tween2;

		private Circle _pfxCircle;

		private bool _playSoundsDuringUpdate;

		private ParticleSystem _zodiacBlurEmitterLarge;

		private ParticleSystem _zodiacBlurEmitterBack;

		private float _detuneValue;

		private float _defaultSkyScale;

		private PhaserSprite _darkBackground;

		private MultiTargetTween _tween1;

		private BulletPool _tvExplosionPool;

		private bool _generatedPools;

		private float _StarryFiringDelta;

		private float _StarryFiringDelay;

		public BulletPool TVExplosionPool => null;

		public override float PSpeed()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		protected override void OnStart()
		{
		}

		public void MakeEmitters()
		{
		}

		public void MakeProjectiles()
		{
		}

		public void ButtonStartStarryHeavens()
		{
		}

		public void FireSpecialProjectiles()
		{
		}

		public void StartStarryHeavens()
		{
		}

		private void exe_CameraZoom()
		{
		}

		private void exe_FadeInSky()
		{
		}

		private void exe_SlowDownSky()
		{
		}

		private void exe_BringInBlurryZodiac()
		{
		}

		private void exe_BringInZodiac()
		{
		}

		private void exe_StartParticles()
		{
		}

		public void StopStarryHeaven()
		{
		}

		public void ClearFlags()
		{
		}

		public override void InternalUpdate()
		{
		}

		protected override void OnPause()
		{
		}

		protected override void OnResume()
		{
		}

		private void MakeSprites()
		{
		}

		public override void Cleanup()
		{
		}
	}
}
