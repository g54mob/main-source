using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundCoop : BackgroundManager
	{
		public int zoneNum;

		private Timer _gaeaEventTimer;

		private bool _activated;

		private bool _hasSpeedUpClock;

		private BgmType _saveBgm;

		private BgmModType _saveBgmMod;

		private List<PhaserSprite> _barriers;

		private List<PhaserSprite> _brokenBarriers;

		private bool _firstEnemyKilled;

		private Bounds _pickupSafeAreaBounds;

		private PhaserSprite _AGaeaSprite;

		private PhaserSprite _eyeSpriteL;

		private PhaserSprite _eyeSpriteR;

		private MultiTargetTween faceTween;

		private MultiTargetTween fadeOutTween;

		private float _colorValue;

		private PhaserSprite _backgroundTile;

		private bool _changeBGColor;

		private bool _gaeaEventStarted;

		public override bool SpawnEnemiesOnStart => false;

		public override void Create()
		{
		}

		private void OnEnemyRemovedFromStage(GameplaySignals.RemoveEnemyFromStageSignal obj)
		{
		}

		public void SetFirstEnmemyKilled()
		{
		}

		private void CreateBarriers()
		{
		}

		public override void OnInitCompleted()
		{
		}

		public override bool HasExtraSafeXYLogic()
		{
			return false;
		}

		public override float2 ExtraSafeXY(float2 position, float2 playerPosition)
		{
			return default(float2);
		}

		public override void CheckMinute(int minute)
		{
		}

		public void ChangeZone(int zone)
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Cleanup()
		{
		}

		private void Activate()
		{
		}

		private void ChangeBGMRate(float value)
		{
		}

		protected override void OnDestroy()
		{
		}

		private void InitBackground()
		{
		}

		private void GaeaEventUpdate()
		{
		}

		private void CheckForGaeaEvent()
		{
		}

		public void StartGaeaEvent()
		{
		}

		private void StartFinalSequence()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
