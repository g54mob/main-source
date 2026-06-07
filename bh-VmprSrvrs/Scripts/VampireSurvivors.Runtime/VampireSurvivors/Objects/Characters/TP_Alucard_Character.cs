using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Alucard_Character : TP_Character
	{
		[SerializeField]
		private Image _HealthBar;

		[SerializeField]
		private Image _HealthBarFill;

		private bool _isCharging;

		private float _chargeTime;

		private float _maxChargeTimeMS;

		private List<WeaponType> spells;

		private PhaserSprite _cursor1;

		private PhaserSprite _cursor2;

		private MultiTargetTween _angle1Tween;

		private MultiTargetTween _angle2Tween;

		private MultiTargetTween _scaleTween;

		private float OverhealDelay;

		private float OverhealTriggerValue;

		private int _currentOverheal;

		private int _maxOverheal;

		private Timer _overHealTimer;

		private TP_SoulSteal_Weapon soulStealWeapon;

		private TP_Dominus1_Weapon hellFireWeapon;

		private TP_SummonSpirit_Weapon summonSpiritWeapon;

		private TP_SwordBrothers_Weapon swordBrothersWeapon;

		private bool _fullyInitialized;

		public override bool DrainWeaponsImmunity => false;

		public override void AfterFullInitialization()
		{
		}

		private void HideCharge()
		{
		}

		private void ShowCharge()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void FireAllSpells()
		{
		}

		private void SummonSpirit(float value, float rawValue)
		{
		}

		public override void LevelUp()
		{
		}

		private void SwordBrothers()
		{
		}

		public override void OnMeleeAttackAnim()
		{
		}
	}
}
