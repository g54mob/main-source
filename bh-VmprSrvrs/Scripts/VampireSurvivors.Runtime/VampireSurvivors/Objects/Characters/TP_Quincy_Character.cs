using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Quincy_Character : TP_Character
	{
		private TP_Neutron_Weapon neutronWeapon;

		[SerializeField]
		private Image _HealthBar;

		[SerializeField]
		private Image _HealthBarFill;

		private bool _isCharging;

		private float _chargeTime;

		private float _maxChargeTimeMS;

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

		public override void LevelUp()
		{
		}
	}
}
