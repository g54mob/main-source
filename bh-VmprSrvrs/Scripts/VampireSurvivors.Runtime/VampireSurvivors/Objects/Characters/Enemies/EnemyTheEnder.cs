using System;
using System.Collections.Generic;
using Coherence.Toolkit;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using Zenject;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyTheEnder : EnemyController
	{
		private SpriteRenderer _ringSprite;

		private float _totalTime;

		private float _scytheTime;

		private float _shieldDamage;

		private int _deathScreamTimerLoopCount;

		private bool _hasShield;

		private bool _hasRunDeathLogic;

		private Timer _shieldTimer;

		private Timer _aiTimer;

		private Timer _deathScreamTimer;

		private ObjectPool _explosionPool;

		private DiContainer _diContainer;

		protected float _attacksDurationMultiplier;

		private readonly List<string> _defaultBag1;

		private readonly List<string> _defaultBag2;

		private readonly List<string> _defaultBag3;

		private readonly List<string> _defaultBag4;

		private readonly List<string> _defaultBag5;

		private readonly List<string> _defaultBag6;

		private readonly List<string> _defaultBag7;

		private readonly List<string> _defaultBag8;

		public Action OnDefeat { get; set; }

		public virtual bool DropGospel { get; set; }

		public virtual float ShieldTime { get; set; }

		protected override void FakeConstruct()
		{
		}

		protected override void Awake()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void OnUpdate()
		{
		}

		private void StartVerySmartAI()
		{
		}

		private void ThrowScythe()
		{
		}

		private void TriggerExplosion()
		{
		}

		private void SpawnDamagingZonesOnline(string skinType)
		{
		}

		private void SpawnDamagingZonesLocally(string skinType)
		{
		}

		public override void Disappear()
		{
		}

		protected override void Die()
		{
		}

		private bool CanRunDeathLogic()
		{
			return false;
		}

		[Command]
		public void OnlineDeath(long startingSimFrame)
		{
		}

		private void FireCustomDeathLogic()
		{
		}

		private void CustomDeathLogic()
		{
		}

		protected void DeathScream()
		{
		}

		protected virtual void SpecialDeathAnimation()
		{
		}

		[Command]
		public void OnlineDamagingZone_Weapons(float xOffset, bool follow, float duration)
		{
		}

		private void DamagingZone_Weapons(float xOffset = 0f, bool follow = false, float duration = 10000f)
		{
		}

		[Command]
		public void OnlineDamagingZone_Coffins(float xOffset, bool follow, float duration)
		{
		}

		private void DamagingZone_Coffins(float xOffset = 0f, bool follow = false, float duration = 10000f)
		{
		}

		[Command]
		public void OnlineDamagingZone_Trainees(float yOffset, bool follow, float duration)
		{
		}

		private void DamagingZone_Trainees(float yOffset = 0f, bool follow = false, float duration = 5000f)
		{
		}

		[Command]
		public void OnlineDamagingZone_Explosions(float yOffset, bool follow, float duration)
		{
		}

		private void DamagingZone_Explosions(float yOffset = 0f, bool follow = false, float duration = 5000f)
		{
		}
	}
}
