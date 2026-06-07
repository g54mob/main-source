using System;
using System.Runtime.CompilerServices;
using Brewery.Minigames;
using UnityEngine;

namespace Brewery.Controls3D
{
	public class ControlPanel3D : MonoBehaviour
	{
		[Header("Runner Configuration")]
		[SerializeField]
		private MinigameConfig config;

		[SerializeField]
		private int stepIndex;

		[Header("Testing")]
		[Tooltip("Auto-start a round on Start() for quick iteration")]
		[SerializeField]
		private bool autoStart;

		[SerializeField]
		private int testSeed;

		[SerializeField]
		private bool testOverclock;

		[Header("Control Bindings")]
		[SerializeField]
		private ControlBinding3D[] controlBindings;

		[Header("Meter Displays")]
		[SerializeField]
		private MeterBinding3D[] meterBindings;

		private ControlPanelRunner runner;

		private Action<float>[] sliderDelegates;

		private Action<bool>[] toggleDelegates;

		private Action[] buttonDelegates;

		private Action<float>[] dialDelegates;

		public ControlPanelRunner Runner => null;

		public bool IsRunning => false;

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

		private void Start()
		{
		}

		public void StartRound(int seed, bool overclock, MinigameConfig cfg, int step)
		{
		}

		public MinigameSubmission StopRound()
		{
			return default(MinigameSubmission);
		}

		private void Update()
		{
		}

		private void WireControlBindings()
		{
		}

		private void UnwireControlBindings()
		{
		}

		private void SyncControlsFromRunner()
		{
		}

		private void SyncStateFromRunner()
		{
		}

		private void UpdateMeterDisplays()
		{
		}

		private void HandleMeterChanged(int meterIndex, float newValue)
		{
		}

		private void HandleRoundComplete(MinigameSubmission submission)
		{
		}

		private void HandleScoreChanged(int delta, int total)
		{
		}

		private void HandleComboChanged(int combo, int multiplier)
		{
		}

		private void HandleEventTriggered(string eventName)
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
