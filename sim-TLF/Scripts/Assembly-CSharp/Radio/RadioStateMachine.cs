using System;
using UnityEngine;
using UnityHFSM;

namespace Radio
{
	[RequireComponent(typeof(RadioAudioPlayer))]
	[RequireComponent(typeof(RadioSignalChecker))]
	[RequireComponent(typeof(RadioChannelManager))]
	[RequireComponent(typeof(RadioConditionProcessor))]
	[RequireComponent(typeof(RadioPlaybackManager))]
	public class RadioStateMachine : MonoBehaviour
	{
		private StateMachine<RadioState> _fsm;

		private RadioAudioPlayer _player;

		private RadioSignalChecker _signal;

		private RadioChannelManager _channels;

		private RadioConditionProcessor _conditions;

		private RadioPlaybackManager _playback;

		private RadioAmbientSound[] _ambients;

		private bool _pendingOn;

		private bool _pendingOff;

		public RadioState ActiveState
		{
			get
			{
				if (_fsm == null)
				{
					return RadioState.Off;
				}
				return _fsm.ActiveState.name;
			}
		}

		public event Action<RadioState> OnStateChanged;

		private void Awake()
		{
			_player = GetComponent<RadioAudioPlayer>();
			_signal = GetComponent<RadioSignalChecker>();
			_channels = GetComponent<RadioChannelManager>();
			_conditions = GetComponent<RadioConditionProcessor>();
			_playback = GetComponent<RadioPlaybackManager>();
			_ambients = GetComponentsInChildren<RadioAmbientSound>(includeInactive: true);
			RadioAmbientSound[] ambients = _ambients;
			for (int i = 0; i < ambients.Length; i++)
			{
				ambients[i].Init(_conditions);
			}
			BuildFSM();
			_fsm.Init();
		}

		private void Update()
		{
			_fsm?.OnLogic();
		}

		private void BuildFSM()
		{
			_fsm = new StateMachine<RadioState>();
			_fsm.AddState(RadioState.Off, new State<RadioState>(delegate
			{
				_pendingOn = false;
				_pendingOff = false;
				_player.StopTrack();
				_player.StopStatic();
				NotifyStateChange(RadioState.Off);
			}));
			_fsm.AddState(RadioState.On, new State<RadioState>(delegate
			{
				_player.StopStatic();
				NotifyStateChange(RadioState.On);
				_playback.ResetAdCounter();
				_playback.StartPlayback();
			}, null, delegate
			{
				_playback.StopPlayback();
				_player.StopTrack();
			}));
			_fsm.AddState(RadioState.NoSignal, new State<RadioState>(delegate
			{
				_player.StopTrack();
				_player.PlayStatic();
				NotifyStateChange(RadioState.NoSignal);
			}, null, delegate
			{
				_player.StopStatic();
			}));
			_fsm.AddTransition(new Transition<RadioState>(RadioState.Off, RadioState.On, (Transition<RadioState> _) => _pendingOn && HasSignal()));
			_fsm.AddTransition(new Transition<RadioState>(RadioState.Off, RadioState.NoSignal, (Transition<RadioState> _) => _pendingOn && !HasSignal()));
			_fsm.AddTransition(new Transition<RadioState>(RadioState.On, RadioState.Off, (Transition<RadioState> _) => _pendingOff));
			_fsm.AddTransition(new Transition<RadioState>(RadioState.NoSignal, RadioState.Off, (Transition<RadioState> _) => _pendingOff));
			_fsm.AddTransition(new Transition<RadioState>(RadioState.On, RadioState.NoSignal, (Transition<RadioState> _) => !HasSignal()));
			_fsm.AddTransition(new Transition<RadioState>(RadioState.NoSignal, RadioState.On, (Transition<RadioState> _) => HasSignal()));
			_fsm.SetStartState(RadioState.Off);
		}

		public void RequestOn()
		{
			_pendingOff = false;
			_pendingOn = true;
		}

		public void RequestOff()
		{
			_pendingOn = false;
			_pendingOff = true;
		}

		private bool HasSignal()
		{
			return _signal.HasSignal(_channels.CurrentChannel);
		}

		private void NotifyStateChange(RadioState state)
		{
			this.OnStateChanged?.Invoke(state);
			RefreshAmbients(state);
		}

		private void RefreshAmbients(RadioState state)
		{
			RadioAmbientSound[] ambients = _ambients;
			for (int i = 0; i < ambients.Length; i++)
			{
				ambients[i].Evaluate(state, _conditions.ActiveConditions);
			}
		}

		private void OnEnable()
		{
			_conditions.OnConditionsChanged += OnConditionsChanged;
		}

		private void OnDisable()
		{
			_conditions.OnConditionsChanged -= OnConditionsChanged;
		}

		private void OnConditionsChanged(RadioCondition _)
		{
			RefreshAmbients(ActiveState);
		}
	}
}
