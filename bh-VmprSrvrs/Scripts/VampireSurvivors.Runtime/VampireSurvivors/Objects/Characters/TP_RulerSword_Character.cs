using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_RulerSword_Character : TP_Character
	{
		public Transform displayContainer;

		private SpriteRenderer _faceSprite;

		private SpriteRenderer _aura1Sprite;

		private SpriteRenderer _aura2Sprite;

		private List<SpriteRenderer> _aura3Sprites;

		private List<float> overhealTresholds;

		private float OverhealAttackTreshold;

		private Timer _overHealTimer;

		private bool _canOverheal;

		private float OverhealDelay;

		private float carryOverOverheal;

		private TP_RulerSword_Weapon RulerSwordWeapon;

		private MultiTargetTween _tweenAlpha1;

		private MultiTargetTween _tweenAlpha2;

		private MultiTargetTween _auraTween;

		private int SwordCount;

		public override bool NeedsCart => false;

		public override bool ShouldCollideWithWalls()
		{
			return false;
		}

		public override void AfterFullInitialization()
		{
		}

		private void AuraVFX()
		{
		}

		private void CharacterHealed(float value, float rawValue)
		{
		}
	}
}
