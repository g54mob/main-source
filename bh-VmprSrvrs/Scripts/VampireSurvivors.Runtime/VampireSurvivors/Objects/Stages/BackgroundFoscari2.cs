using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Props;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundFoscari2 : BackgroundManager
	{
		private TileSprite _water;

		private float _beats;

		private float _tilingOffset;

		private PhaserSprite _sDarkness;

		private PhaserSprite _sFader;

		private PhaserSprite _pizzaAsprite;

		private Circle _pizzaA;

		private bool _canPizza;

		private BgmType _saveBGM;

		private BgmModType _saveBGMMod;

		private Timer beatTimer;

		private bool _isSealed;

		private bool _isPathBlocked;

		private float _waterOffset;

		private EnemyJeneviv _jeneviv;

		private PhaserSprite _sBlackWall;

		private ParticleEmitterManager _shadowParticlesManager;

		private ParticleSystem _shadowEmitter;

		private PropFoscariSeal2 _seal;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _glitchEmitter;

		private ParticleSystem _glitchEmitter2;

		private PropFoscariSeal3 _sealBlue;

		private bool _checkForLuminaire;

		private Timer _luminairePathEvent;

		private static List<WeaponType> s_foscariEventWeapons;

		public static bool s_hasFallenFromFoscari1;

		private float Delay01_Wave;

		private float Delay02_Wave;

		private float Delay03_Wave;

		private float Delay04_Wave;

		private float Delay05_Break;

		private float Delay06_Move;

		private float Delay07_Color;

		private float Delay08_Charge;

		private float Delay09_WorldEater;

		private float Delay10_Start;

		private float Delay11_Light;

		private List<Weapon> _playerWeapons;

		public static List<WeaponType> FoscariEventWeapons
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void OnDestroy()
		{
		}

		public override void Awake()
		{
		}

		public override void Create()
		{
		}

		private void OnRemoteEnemySpawned(EnemyController enemy)
		{
		}

		private void OnRemoteDestructibleSpawned(Destructible destructible)
		{
		}

		public override void OnInitCompleted()
		{
		}

		public void OnJenevivActivation()
		{
		}

		public override void CheckMinute(int minute)
		{
		}

		public override void Cleanup()
		{
		}

		protected override void OnUpdate()
		{
		}

		public void StopBeat()
		{
		}

		public void ForceSpoopyMusic()
		{
		}

		public void onBeat()
		{
		}

		public void ResumeEnemiesMovement()
		{
		}

		public void MakePizza()
		{
		}

		public void CheckPizzas(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public void AnimPizza()
		{
		}

		public void CreateSeal2()
		{
		}

		public void CreateSeal3()
		{
		}

		public void CreateBadge()
		{
		}

		private void CreateShadowServant()
		{
		}

		private void CreateWeapons()
		{
		}

		public void OnSeal2DestructionComplete()
		{
		}

		public void SetBoundsBeforeSeal2()
		{
		}

		public void OpenBounds()
		{
		}

		private void SpawnJeneviv()
		{
		}

		private void SealJeneviv()
		{
		}

		public void FreeJeneviv()
		{
		}

		private void SummonSnakes()
		{
		}

		public void DevourEggs()
		{
		}

		private void StartSpawningPrismaticMissile()
		{
		}

		private void OnWorldEater()
		{
		}

		private void GimmeAbeat(float interval, Action callback)
		{
		}

		private void ClearBeat()
		{
		}
	}
}
