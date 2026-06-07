using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundAstral : BackgroundManager
	{
		private StageEventTrisectionManager _trisection;

		private TileSprite _stars2;

		private PhaserSprite _carpet;

		private PhaserSprite _hand;

		private PhaserSprite _pizzaASprite;

		private Circle _pizzaA;

		private float _yMul;

		private float _startingX;

		private float _startingY;

		private float _distanceFromStartingY;

		private float _red;

		private float _blue;

		private int[] _cachedPlayerCharm;

		private bool _stopPlayerMovement;

		private bool _isPlayingIntroSequence;

		private bool _isEventTrisectionEnabled;

		private bool _isOnBeatComplete;

		private bool _canPizza;

		private BgmType _saveBgm;

		private BgmModType _saveBgmMod;

		private Timer _initialTimeout;

		private Timer _flipInterval;

		private Timer _flipClearTimeout;

		private Timer _mainInterval;

		private float _speedFactor;

		private List<PhaserSprite> _portraits;

		private List<MultiTargetTween> _portraitsTweens;

		private List<string> _portraitFrames;

		private PickupTeleporter secretDoor;

		private BgmType _secretEventSaveBgm;

		private PickupCoffin secretCoffin;

		private const float BGMDuration = 83650f;

		private const float InitialTimeoutDuration = 34000f;

		private const float FlipIntervalDuration = 800f;

		private const float FlipClearTimeoutDuration = 75000f;

		private void OnDrawGizmos()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void Create()
		{
		}

		private void OnRemoteItemInstantiated(Pickup obj)
		{
		}

		public override void OnInitCompleted()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void CheckHalfMinute()
		{
		}

		public override void CheckMinute(int minute)
		{
		}

		public override void Cleanup()
		{
		}

		private void FirstTimeSetup()
		{
		}

		private void MakeSpinningPortraits()
		{
		}

		private void StartIntroSequence()
		{
		}

		private void EnterHand()
		{
		}

		private void FadeInTileset()
		{
		}

		private bool IsIntroSequence()
		{
			return false;
		}

		private void StartFlipBeats()
		{
		}

		private void StartBeatsLoop()
		{
		}

		private void OnBeat()
		{
		}

		private void StopBeat()
		{
		}

		private Color GetColor(float alpha)
		{
			return default(Color);
		}

		public float2 MakeDoor46Event(float2 previousDestination, PickupTeleporter sourceTeleporter)
		{
			return default(float2);
		}

		public override void CustomPreload(Action onComplete)
		{
		}

		public void OnSecretFinished()
		{
		}

		public void OnReturnStarted(VampireSurvivors.Objects.Characters.CharacterController playerTeleported)
		{
		}

		private void MakePizza()
		{
		}

		private void CheckPizzas()
		{
		}

		private void AnimPizza()
		{
		}

		private void RestorePlayersCharmStat()
		{
		}

		public override void EnableMovingBackground()
		{
		}

		public override void DisableMovingBackground()
		{
		}
	}
}
