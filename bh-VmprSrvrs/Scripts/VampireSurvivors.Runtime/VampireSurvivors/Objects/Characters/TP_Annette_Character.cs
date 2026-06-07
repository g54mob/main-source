using System.Collections.Generic;
using Coherence.Toolkit;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Annette_Character : TP_Character
	{
		private const string CarmillaTextureName = "character_tp_carmilla";

		private bool _firstUpdateDone;

		private bool _hasDominus2;

		private Weapon _dominus2Weapon;

		private bool _isMorphed;

		private MorphVFX _morphVFX;

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

		private bool _hasSecondAnim;

		public override bool DrainWeaponsImmunity => false;

		protected override void OnUpdate()
		{
		}

		public override void AfterFullInitialization()
		{
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override void OnWeaponMadeLevelOne(WeaponType type)
		{
		}

		private void OnUpdate_Annette()
		{
		}

		private void SpawnWorldSpaceWeapon(float x, float y, WeaponType weaponPrize, float delay)
		{
		}

		private void SyncedMorph()
		{
		}

		[Command]
		public void SendAnnetteMorph()
		{
		}

		private void AnnetteMorph()
		{
		}

		public void MakeMorphVFX()
		{
		}

		public void AfterFullInitialization_Carmilla()
		{
		}

		private void FireAllSpells()
		{
		}

		protected void OnUpdate_Carmilla()
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
	}
}
