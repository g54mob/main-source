using System.Collections.Generic;
using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters
{
	public class EX_Boss_Colossus : EnemyControllerBoss_TerrainBreaker
	{
		private enum Colossus_Mode_Types
		{
			SETUP = 0,
			ASLEEP = 1,
			ROAMING = 2,
			ENRAGED = 3,
			POSITIONING = 4,
			WINDUP = 5,
			CHARGING = 6,
			LEAVING_MAP = 7
		}

		private const string AsleepAnimationName = "Asleep";

		private const string MovingAnimName = "Moving";

		private Vector2 _roamingTargetPosition;

		private int currentLocationOfInterest;

		[Header("HP Thresholds")]
		[SerializeField]
		private float awakenThresholdPercentage;

		[SerializeField]
		private float enragedThresholdPercentage;

		[Space]
		[Tooltip("If the Colossus hasn't been damaged for this long after being aggro'd, it will return to the roaming state")]
		[SerializeField]
		private float _aggroDuration;

		private float _aggroTimer;

		private float awakenThresholdHP;

		private float enragedThresholdHP;

		private Colossus_Mode_Types Colossus_Mode;

		private Vector2 _chargeStartingPosition;

		private Vector2 _chargeEndingLocation;

		private Camera _mainCamera;

		private float _cameraOrthographicSizeX;

		private float _cameraOrthographicSizeY;

		[Header("Charge Timer")]
		[SerializeField]
		private float chargeMechanicInterval;

		[SerializeField]
		private float chargeActivationDelay;

		[SerializeField]
		private float chargeActiveDuration;

		[Space]
		private Timer _chargerMechanicTimer;

		private Timer _chargeDelayTimer;

		private Timer _chargeFinishTimer;

		[Header("Charge Mechanics")]
		[SerializeField]
		private float chargeSpeedModifier;

		[Space]
		private Vector2 chargeDirection;

		[Header("Charge Visuals")]
		[SerializeField]
		private SpriteTrail trail;

		[Space]
		[Header("Charge Warning")]
		[SerializeField]
		private float flashRepeatingInterval;

		[Space]
		private Timer _warningFlashTimer;

		private bool _toggleWarningColour;

		private PhaserSprite _exclamationMark;

		private MultiTargetTween _warningTween;

		private List<Sprite> _asleepSprites;

		private List<Sprite> _mainSprites;

		private CoherenceSync _sync;

		public bool IsLeavingMap => false;

		protected override void Awake()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote = false)
		{
		}

		private void SetupLocationOfInterest()
		{
		}

		protected override void OnUpdate()
		{
		}

		[Command]
		public void SetRoaming()
		{
		}

		[Command]
		public void SetLeavingMap()
		{
		}

		public override void OnGetDamaged(HitVfxType showHitVfx, bool hasKb = true)
		{
		}

		protected override void UpdateTileDestructionList()
		{
		}

		private bool CheckHasReachedBottomOfMap()
		{
			return false;
		}

		private void ChargingMovementBehaviour()
		{
		}

		private void StandardMovementBehaviour(Vector2 targetPosition, float speedModification = 1f)
		{
		}

		private void PositioningBehaviour()
		{
		}

		private void WindUpBehaviour()
		{
		}

		private void ChargeAtPlayer()
		{
		}

		private void RestartMovement()
		{
		}

		private void ToggleWarningTint()
		{
		}

		private Vector2 AdjustedMarkPositionY(float x, float y)
		{
			return default(Vector2);
		}

		public override void Despawn()
		{
		}
	}
}
