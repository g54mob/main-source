using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class EME_CharacterControllerDiva : EME_CharacterControllerShowstopper
	{
		private float _glPower;

		private float _glArea;

		private float _glSpeed;

		private float _glDuration;

		private float _glCooldown;

		private float _glRecovery;

		private float _timeSinceLastAltWalk;

		private float _timeUntilNextAltWalk;

		private float _minTimeBetweenAltWalk;

		private float _maxTimeBetweenAltWalk;

		private SpriteAnimation _scatteredPetalsSlashUp;

		private SpriteAnimation _scatteredPetalsMidAir;

		private SpriteAnimation _scatteredPetalsSlashDown;

		private SpriteAnimation _scatteredPetalsLand;

		private SpriteAnimation _scatteredPetalsGroundedSlash;

		private bool _isUsingDivaKatanaSkin;

		private const string WalkAnimName = "walk";

		private const string AltWalk1AnimName = "EME_divano5_hop";

		private const string AltWalk2AnimName = "EME_divano5_splits";

		private const string UpSlashAnimName = "EME_divano5_scatteredpetals_upwardslash";

		private const string MidAirAnimName = "EME_divano5_scatteredpetals_midairpose";

		private const string DownSlashName = "EME_divano5_scatteredpetals_downwardslash";

		private const string LandAnimName = "EME_divano5_scatteredpetals_land";

		private const string GroundSlashAnimName = "EME_divano5_sword";

		private bool HasHiddenRave;

		private bool HasTechniqueBonuses;

		private bool HasBallisticMissile;

		private bool HasBigMissile;

		private List<WeaponType> missiles;

		private Weapon _HiddenWeapon;

		[SerializeField]
		private int _scatteredPetalsFps;

		private int _walkFps;

		private int _altWalkFps;

		private float RingLevelUpEveyXLevels;

		[SerializeField]
		private Image _ChargeBar;

		[SerializeField]
		private Image _ChargeBarFill;

		private bool _isCharging;

		private float _chargeTime;

		private float _maxChargeTimeMS;

		private float _defaultChargeTimeMS;

		private Color ChargeColor;

		private Color ReadyColor;

		private Timer nextTriggeredSkillTimer;

		public override float PPower()
		{
			return 0f;
		}

		public override float PArea()
		{
			return 0f;
		}

		public override float PSpeed()
		{
			return 0f;
		}

		public override float PDuration()
		{
			return 0f;
		}

		public override float PCooldown()
		{
			return 0f;
		}

		public override float PRegen()
		{
			return 0f;
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		private void SetAsFlying()
		{
		}

		private void LateUpdate()
		{
		}

		public override void LevelUp()
		{
		}

		public void EnterScatteredPetalsStage(ScatteredPetalsStage stage)
		{
		}

		private void AddScatteredPetalsAnimStage(string animName, string textureName, int frameCount)
		{
		}

		private void AddCustomWalkAnim(string animName, string textureName, List<int> frameOrder, int fps)
		{
		}

		private List<string> SpecifyOrderAnimFrameList(string animName, List<int> frameOrder)
		{
			return null;
		}

		private void AltWalkUpdate()
		{
		}

		private void DoAltWalk1()
		{
		}

		private void DoAltWalk2()
		{
		}

		public void ReturnToNormalWalkAnim()
		{
		}

		private List<string> MakeAnimFrameList(string animName, int frameCount)
		{
			return null;
		}

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

		public void SetMechaDamageEmitter()
		{
		}
	}
}
