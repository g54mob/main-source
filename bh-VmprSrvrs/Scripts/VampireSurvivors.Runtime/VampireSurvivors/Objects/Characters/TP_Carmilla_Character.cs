using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Carmilla_Character : TP_Character
	{
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

		public override bool DrainWeaponsImmunity => false;

		public override void AfterFullInitialization()
		{
		}

		private void FireAllSpells()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void HideCharge()
		{
		}

		private void ShowCharge()
		{
		}

		protected override void OnStop()
		{
		}

		public override bool ShouldCollideWithWalls()
		{
			return false;
		}
	}
}
