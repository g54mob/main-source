using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Shanoa_Character : TP_Character
	{
		private int meleeIndex;

		[SerializeField]
		private Image _ChargeBar;

		[SerializeField]
		private Image _ChargeBarFill;

		private bool _isCharging;

		private float _chargeTime;

		private float _maxChargeTimeMS;

		private List<WeaponType> spells;

		private PhaserSprite _cursor1;

		private PhaserSprite _cursor2;

		private MultiTargetTween _angle1Tween;

		private MultiTargetTween _angle2Tween;

		private MultiTargetTween _scaleTween;

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

		public override void OnAttackAnim(Weapon.FiringAnimation firingAnimation)
		{
		}

		public override void ClearFromSpecialAnims()
		{
		}

		public override void OnMeleeAttackAnim()
		{
		}
	}
}
