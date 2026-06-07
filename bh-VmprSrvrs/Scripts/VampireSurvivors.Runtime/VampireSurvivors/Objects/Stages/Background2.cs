using System;
using JetBrains.Annotations;
using SuperTiled2Unity;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Items;

namespace VampireSurvivors.Objects.Stages
{
	[UsedImplicitly]
	public class Background2 : BackgroundManager
	{
		private bool _triggerCheck;

		private bool _hasSpawnedTrickster;

		private bool _hasDefeatedTrickster;

		private bool _saveDmg;

		private bool _canInteractWithPiano;

		private BgmType? _saveBgm;

		private BgmModType? _saveBgmMod;

		private EnemyTrickster _enemyTrickster;

		private Timer _pianoInteractionTimer;

		private Timer _undeadsTimer;

		private int _undeadsTimerLoopCount;

		private PhaserSprite _sDarkness;

		private PhaserSprite _sDarknessExtraA;

		private PhaserSprite _sDarknessExtraB;

		private SuperObject _piano;

		private SuperObject _coffin;

		private Vector2 _pianoPos;

		private Vector2 _coffinPos;

		private float _pianoOffset;

		private float _displayHeight;

		private float _displayWidth;

		private bool _pianoDone;

		private PickupCoffinEmpty _rightCoffin;

		private readonly bool _quickDebug;

		protected override void OnUpdate()
		{
		}

		public override void Create()
		{
		}

		public void BigPianoIn(VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		public void BigPianoOut()
		{
		}

		public void BigSpoop()
		{
		}

		public override void Cleanup()
		{
		}

		public override void CustomPreload(Action onComplete)
		{
		}

		private void MakeCoffins()
		{
		}

		private void OnRightCoffinOpened()
		{
		}

		private void ProcessRightCoffinOpened()
		{
		}

		private void RevealTrickster()
		{
		}

		private void HandleTricksterDefeat()
		{
		}

		private void SetupDarkness()
		{
		}
	}
}
