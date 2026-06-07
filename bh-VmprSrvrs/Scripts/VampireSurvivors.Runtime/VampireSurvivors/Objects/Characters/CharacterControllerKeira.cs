using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerKeira : CharacterController
	{
		[SerializeField]
		private Image _HealthBar;

		[SerializeField]
		private Image _HealthBarFill;

		private bool _isCharging;

		private float _chargeTime;

		private float _maxChargeTimeMS;

		private float _defaultChargeTimeMS;

		private Color ChargeColor;

		private Color ReadyColor;

		private List<WeaponType> spells;

		private Timer nextTriggeredSkillTimer;

		public override void AfterFullInitialization()
		{
		}

		private void HideCharge()
		{
		}

		private void ShowCharge()
		{
		}

		private void HighlightCharge()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void TriggerChargeSkill()
		{
		}

		public override void LevelUp()
		{
		}
	}
}
