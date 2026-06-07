using System;
using System.Runtime.CompilerServices;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects
{
	public class WestwoodsTrisectionManager : StageEventTrisectionManager
	{
		private PhaserSprite _wheelOfFortune;

		private PhaserSprite _needleArrow;

		private MultiTargetTween _tweenWheelOfFortune;

		private MultiTargetTween _tweenShowNeedle;

		private const string UITextureName = "UI";

		public bool _isSpinning;

		public bool _isIdle;

		private float _wheelAngleAtLastTickAudio;

		private float _minTimeBetweenTicks;

		private float _tickTimer;

		private const float AnglePerTick = 30f;

		private const float TickVolume = 2f;

		private const float FanfareVolume = 0.5f;

		private readonly SoundManager.SoundConfig _fanfareSoundConfig;

		public int queuedSpins;

		public event Action OnUnlockZoneEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public override void Init(Stage stage)
		{
		}

		protected override void CreateUI()
		{
		}

		protected override void PopulateEvents()
		{
		}

		protected override void ChooseEvent()
		{
		}

		private (float, float) GetEventAngles(TrisectionEvent trisectionEvent)
		{
			return default((float, float));
		}

		private float EventAngleRange((float, float) eventAngles)
		{
			return 0f;
		}

		public bool CheckForUnlockZoneEvent()
		{
			return false;
		}

		protected override void ShowCircles()
		{
		}

		protected override void HideCircles()
		{
		}

		public void UpdateTrisectionAudio()
		{
		}

		public override void Spinnn(float duration = 5000f, TrisectionEvent forcedEvent = null, Action onEventSelected = null)
		{
		}
	}
}
