using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters
{
	public class Enemy_Charger : EnemyController
	{
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
		private bool _isCharging;

		private bool _isMoving;

		private Vector2 _chargeDirection;

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

		private PhaserSprite _groundFx;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnUpdate()
		{
		}

		private void ToggleWarningTint()
		{
		}

		private void SetupChargeAtPlayer()
		{
		}

		private void ChargeAtPlayer()
		{
		}

		private void RestartMovement()
		{
		}

		private Vector2 AdjustedMarkPositionY(float x, float y)
		{
			return default(Vector2);
		}

		protected override void Die()
		{
		}

		public override void Disappear()
		{
		}

		public override void Despawn()
		{
		}
	}
}
