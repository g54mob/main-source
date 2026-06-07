using System;
using System.Collections.Generic;
using Coherence.Toolkit;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using Zenject;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyJeneviv : EnemyController
	{
		private DiContainer _diContainer;

		private float _totalTime;

		private float _scitheTime;

		private float _shieldDamage;

		private float _activationDistance;

		private bool _hasShield;

		private bool _isInvul;

		private bool _painInTheAss;

		private bool _isActivated;

		private bool _specialDeath;

		private Timer _shieldTimer;

		private Timer _summonSnakesEvent;

		private Timer _damagingZonesEvent;

		private DamagingZonePool_Ophion _damagingZonePool;

		private PhaserSprite _ringSprite;

		private PhaserSprite _breakFreeSprite;

		private PhaserSprite _worldEaterImage;

		private PhaserSprite _faderImage;

		private MultiTargetTween _worldEaterTween1;

		private MultiTargetTween _worldEaterTween2;

		private MultiTargetTween _worldEaterTween3;

		private List<EquipmentInfo> _playerEquipment;

		private List<PhaserSprite> _rays;

		private const float SHIELD_TIME = 45000f;

		public Action OnActivated { get; set; }

		public Action OnDefeat { get; set; }

		protected override void FakeConstruct()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public void RestoreShield()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		[Command]
		public void OnlineDeath()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Disappear()
		{
		}

		public void SealInStone()
		{
		}

		public void BreakFree1()
		{
		}

		public void StartMoving()
		{
		}

		public void BreakFree2()
		{
		}

		public void ChargeWorldEater()
		{
		}

		public void CastWorldEater()
		{
		}

		public void StartVerySmartAI()
		{
		}

		public void ScreenShake(int repeats = 6)
		{
		}

		private void TestSpecialDeath()
		{
		}

		private void ActivatedByDistance()
		{
		}

		protected override void Die()
		{
		}

		private void RemovePlayerWeapons()
		{
		}

		protected void DeathScream()
		{
		}

		private void SpecialDeathAnimation()
		{
		}

		private void PlayWorldEater()
		{
		}

		private void StealHearts()
		{
		}

		private void FakeRecover()
		{
		}

		private void DevourEleanor()
		{
		}

		private void SummonSnakes(int generic, int exploding)
		{
		}

		private void FireOphion(float delay, float radius, int times)
		{
		}

		[Command]
		public void SpawnDamagingPool(float x, float y)
		{
		}
	}
}
