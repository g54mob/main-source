using System.Collections.Generic;
using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterController_EX_Chulareh : CharacterController
	{
		private enum DiceResult
		{
			NoEffect = 0,
			UnluckyOne = 1,
			Two = 2,
			Three = 3,
			Four = 4,
			Five = 5,
			LuckySix = 6
		}

		private enum SpecialState
		{
			None = 0,
			Lucky = 1,
			Unlucky = 2
		}

		[SerializeField]
		private SpriteRenderer _DiceSprite;

		[SerializeField]
		private SpriteRenderer _ScreenFillRenderer;

		[SerializeField]
		private Transform _CameraTarget;

		private List<DiceResult> _nonLuckyDiceResults;

		private const float LuckyMoveBonus = 0.77f;

		private const float LuckyLuckBonus = 7.77f;

		private const float UnluckyLuckMalus = -7.77f;

		private const float UnluckyCurseBonus = 0.77f;

		private const float LuckyDiceRollBaseChance = 1f / 6f;

		private const float LuckyDiceEffectDuration = 30000f;

		private const float UnluckyDiceEffectDuration = 10000f;

		private const float DiceRollInterval = 30000f;

		private string _characterTexture;

		private SpriteAnimation _diceRollAnim;

		private DiceResult _diceResult;

		private SpecialState _specialState;

		private int _diceRollCounter;

		private int _queuedDiceRolls;

		private bool _diceRollInProgress;

		private bool _luckyCameraZoomTriggered;

		private bool _unluckyCameraZoomTriggered;

		private Timer _diceRollTimer;

		private Timer _diceEffectTimer;

		private Timer _cameraTimer;

		private Timer _eventTimer;

		private MultiTargetTween _diceTween;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _luckyPfx;

		private ParticleSystem _unluckyPfx;

		private List<Transform> _originalCameraTargets;

		private float _orthographicSize;

		private bool IsLucky => false;

		private bool IsUnlucky => false;

		public override float LootMult_Rerollo => 0f;

		public override float PLuck()
		{
			return 0f;
		}

		public override float PMoveSpeed()
		{
			return 0f;
		}

		public override float PCurse()
		{
			return 0f;
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		protected override void InternalUpdate()
		{
		}

		private void CheckForQueuedDiceRolls()
		{
		}

		public override void OnPickupCollected(Pickup pickup)
		{
		}

		private void WaitForNextDiceRoll(float delay)
		{
		}

		private void DoDiceRoll()
		{
		}

		[Command]
		public void SetDiceResult(int result)
		{
		}

		private void DoDiceRollAnim()
		{
		}

		private DiceResult GetDiceResult()
		{
			return default(DiceResult);
		}

		private bool IsDiceResult2345()
		{
			return false;
		}

		private void SetDiceSpriteForRoll()
		{
		}

		private void DoDiceRollOutcome()
		{
		}

		private void GetNormalOutcome()
		{
		}

		private void GetLucky()
		{
		}

		private void GetUnlucky()
		{
		}

		private void ActivateLuckyBonus()
		{
		}

		private void DeactivateLuckyBonus()
		{
		}

		private void ActivateUnluckyBonus()
		{
		}

		private void DeactivateUnluckyBonus(bool playSfx = true)
		{
		}

		private void DoShootingStars()
		{
		}

		private void AddPermanentLuckBonus(float bonus)
		{
		}

		private void DisplayOverheadIcon(string frameOverride = null, string textOverride = null, Vector2? offsetOverride = null)
		{
		}

		private void DoDiceFadeOutSequence()
		{
		}

		private void GenerateLuckyParticleSystem()
		{
		}

		private void GenerateUnluckyParticleSystem()
		{
		}

		private void UpdateParticles()
		{
		}

		private void PlayDiceShakeSfx(bool play = true)
		{
		}

		private void PlayNormalEffectSfx()
		{
		}

		private void PlayLuckySfx()
		{
		}

		private void PlayUnluckySfx()
		{
		}

		private void PlayLaughSfx()
		{
		}

		private void ZoomInOnDice()
		{
		}

		private void SetupScreenFill()
		{
		}

		public void ZoomOutFromDice()
		{
		}

		private void DoQuickScreenFill()
		{
		}

		public override bool OnTreasureCollected(TreasureChest treasure)
		{
			return false;
		}

		public override void Despawn()
		{
		}

		private void DebugDoDiceRoll()
		{
		}

		private void DebugGetLucky()
		{
		}

		private void DebugGetUnlucky()
		{
		}

		private void DebugGetNormalOutcome()
		{
		}

		private void DebugRemoveCurrentDiceEffect()
		{
		}
	}
}
