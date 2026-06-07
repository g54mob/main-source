using System;
using System.Runtime.CompilerServices;

namespace Brewery.Minigames
{
	public class ControlPanelRunner : IMinigameRunner
	{
		private int seed;

		private bool overclock;

		private MinigameConfig config;

		private ControlPanelTuning tuning;

		private int cachedStepIndex;

		private ControlPanelPreset preset;

		private Random rng;

		private float[] meterValues;

		private float[] meterIdealMin;

		private float[] meterIdealMax;

		private float[] driftNoise;

		private const int DRIFT_NOISE_LENGTH = 300;

		private ControlState[] controlStates;

		private float scoringTickAccumulator;

		private int consecutiveGoodTicks;

		private float sustainedPerfectTime;

		private ChaosEvent[] chaosEvents;

		private int nextEventIndex;

		private int activeEventIndex;

		private float activeEventEndTime;

		private int currentFusePatternIndex;

		public bool IsRunning { get; private set; }

		public MinigameInputMode InputMode => default(MinigameInputMode);

		public float ElapsedTime { get; private set; }

		public float RoundDuration { get; private set; }

		public int CurrentScore { get; private set; }

		public int CurrentCombo { get; private set; }

		public int MaxCombo { get; private set; }

		public int EventSuccesses { get; private set; }

		public int CurrentBPM => 0;

		public int ComboMultiplier => 0;

		public ControlPanelPreset Preset => null;

		public float[] MeterValues => null;

		public float[] MeterIdealMin => null;

		public float[] MeterIdealMax => null;

		public ControlState[] ControlStates => null;

		public int ActiveEventIndex => 0;

		public ControlPanelEventDef ActiveEventDef => default(ControlPanelEventDef);

		public float ActiveEventTimeRemaining => 0f;

		public bool[] CurrentFuseTarget => null;

		public event Action<MinigameSubmission> OnRoundComplete
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

		public event Action<int, int> OnScoreChanged
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

		public event Action<int, int> OnComboChanged
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

		public event Action<string> OnEventTriggered
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

		public event Action<int, float> OnMeterValueChanged
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

		public event Action<int> OnControlStateChanged
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

		public event Action OnEventEnded
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

		public event Action<bool[]> OnFuseTargetChanged
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

		public void Start(int seed, bool overclock, MinigameConfig config, int stepIndex)
		{
		}

		public MinigameSubmission Stop()
		{
			return default(MinigameSubmission);
		}

		public void ProcessInput(float inputTimeSeconds)
		{
		}

		public void ProcessInputRelease(float inputTimeSeconds)
		{
		}

		public void Tick(float deltaTime)
		{
		}

		public void SetControlValue(int controlIndex, float normalizedValue)
		{
		}

		public void ToggleControl(int controlIndex)
		{
		}

		public void PressButton(int controlIndex)
		{
		}

		public void SetFusePattern(int controlIndex, bool[] pattern)
		{
		}

		public void ToggleFuse(int controlIndex, int fuseIndex)
		{
		}

		public void SetPatchConnection(int controlIndex, int fromSocket, int toSocket)
		{
		}

		private void InitializeMeters()
		{
		}

		private void InitializeControls()
		{
		}

		private void GenerateDriftNoise()
		{
		}

		private void GenerateEventSchedule()
		{
		}

		private void UpdateControlTimers(float deltaTime)
		{
		}

		private void ApplyMeterDrift(float deltaTime)
		{
		}

		private float GetRegulatorModifier(int meterIndex)
		{
			return 0f;
		}

		private void ApplyControlEffects(float deltaTime)
		{
		}

		private void ApplyCrossInteractions(float deltaTime)
		{
		}

		private void ClampMeters()
		{
		}

		private void ProcessEvents()
		{
		}

		private void UpdateFuseTarget()
		{
		}

		private void ProcessScoringTick(float deltaTime)
		{
		}

		private void AddScore(int delta)
		{
		}

		private void IncrementCombo()
		{
		}

		private void ResetCombo()
		{
		}

		private MinigameTier ComputeTier()
		{
			return default(MinigameTier);
		}

		private MinigameSubmission BuildSubmission()
		{
			return default(MinigameSubmission);
		}

		private void FinishRound()
		{
		}

		private float SnapToDetent(float value, int detents)
		{
			return 0f;
		}

		private bool IsFusePatternCorrect(int controlIndex)
		{
			return false;
		}

		private int CountActiveConnections(int controlIndex)
		{
			return 0;
		}
	}
}
