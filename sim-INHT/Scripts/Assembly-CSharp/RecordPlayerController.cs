using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
[AddComponentMenu("Gameplay/Record Player Controller")]
public class RecordPlayerController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CButtonActivationRoutine_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RecordPlayerController _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CButtonActivationRoutine_003Ed__51(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCrossfadeRoutine_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RecordPlayerController _003C_003E4__this;

		public AudioSource incoming;

		public AudioClip incomingClip;

		public AudioSource outgoing;

		private float _003Celapsed_003E5__2;

		private float _003Cduration_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCrossfadeRoutine_003Ed__58(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CStartDelayRoutine_003Ed__52 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RecordPlayerController _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CStartDelayRoutine_003Ed__52(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CStopDelayRoutine_003Ed__53 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RecordPlayerController _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CStopDelayRoutine_003Ed__53(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("References (Required)")]
	[Tooltip("The ItemSlot that accepts record DraggableItems.\n\nThis controller subscribes to onSlotFilled and onSlotCleared on this slot.\nRequired — controller will log an error and disable itself if missing.")]
	[SerializeField]
	private ItemSlot slot;

	[Tooltip("Primary AudioSource (Source A).\n\nAlternates with Source B during crossfade transitions.\nRequired settings:\n- PlayOnAwake: false\n- Loop:        false")]
	[SerializeField]
	private AudioSource audioSourceA;

	[Tooltip("Secondary AudioSource (Source B).\n\nUsed as the incoming source during crossfade transitions.\nRequired settings:\n- PlayOnAwake: false\n- Loop:        false\n\nCan live on the same GameObject as Source A.")]
	[SerializeField]
	private AudioSource audioSourceB;

	[Tooltip("The LookAtTarget used as the play/stop toggle button.\n\n- SetActive(false) on Awake and whenever the slot is empty.\n- SetActive(true)  after buttonActivationDelaySeconds once a record is placed.\n- onClickDown is wired to TogglePlayStop automatically.")]
	[SerializeField]
	private LookAtTarget playButton;

	[Header("Button Activation Delay")]
	[Tooltip("Seconds (realtime) after a record is placed into the slot before the play\nbutton becomes pressable.\n\nUseful for diegetic 'record settling on platter' animations.\nIf the record is removed before this delay completes it is cancelled and\nthe button remains inactive.\n\nUses realtime seconds — not affected by Time.timeScale or game pause.\n\nSet to 0 for instant activation.\n\nSafe default: 0.")]
	[SerializeField]
	[Min(0f)]
	private float buttonActivationDelaySeconds;

	[Header("Playback Delays")]
	[Tooltip("Seconds (realtime) between the player pressing Play and audio starting.\n\nOnPlaybackStarted fires immediately on button press so animations can begin.\nAudio is held for this duration. Update() track-advance logic is fully\nsuppressed during this window.\n\nUses realtime seconds — not affected by Time.timeScale or game pause.\n\nSet to 0 for no delay.\n\nSafe default: 0.")]
	[SerializeField]
	[Min(0f)]
	private float playbackStartDelaySeconds;

	[Tooltip("Seconds (realtime) between the player pressing Stop and audio halting.\n\nOnPlaybackStopped fires immediately on button press so animations can begin.\nAudio continues for this duration before being silenced.\n\nDoes NOT apply when:\n- A record is physically removed (always immediate ForceStop).\n- A non-looping record reaches its natural end.\n\nUses realtime seconds — not affected by Time.timeScale or game pause.\n\nSet to 0 for no delay.\n\nSafe default: 0.")]
	[SerializeField]
	[Min(0f)]
	private float playbackStopDelaySeconds;

	[Header("Crossfade Settings")]
	[Tooltip("Seconds before the active track's natural end at which the next track\nbegins playing and starts fading in.\n\nShould be >= fadeDuration for a clean overlap.\nIf remaining track time is shorter than this value when evaluated,\nthe crossfade is skipped and a hard cut is used.\n\nSafe default: 3.0")]
	[SerializeField]
	[Min(0f)]
	private float overlapSeconds;

	[Tooltip("Duration in seconds of the simultaneous fade-out (outgoing) and\nfade-in (incoming) during a crossfade transition.\n\nShould be <= overlapSeconds.\n\nSafe default: 2.0")]
	[SerializeField]
	[Min(0f)]
	private float fadeDuration;

	[Header("Volume")]
	[Tooltip("Master volume multiplier applied to both AudioSources at all times.\nRange: 0 (silent) to 1 (full volume).\n\nThis value is the authoritative volume state used by all internal\nplayback and crossfade code. It can be driven at runtime via\nSetMasterVolume(float), e.g. from a RecordPlayerVolumeDialBridge.\n\nSafe default: 1.")]
	[SerializeField]
	[Range(0f, 1f)]
	private float masterVolume;

	[Header("Events")]
	[Tooltip("Fired immediately when the player presses Play, BEFORE the start delay.\nUse to trigger spin-up / needle-drop animations.\nAudio begins after playbackStartDelaySeconds.")]
	public UnityEvent OnPlaybackStarted;

	[Tooltip("Fired immediately when playback stops. Two cases:\n1. Player presses Stop (before stop delay; audio trails off).\n2. Final track ends on a non-looping record (no stop delay).\n\nNOT fired when a record is physically removed — use OnRecordRemoved.")]
	public UnityEvent OnPlaybackStopped;

	[Tooltip("Fired when a record is pulled out of the slot while audio is playing.\nUse to trigger scratch SFX or abort animations.\n\nOnPlaybackStopped is NOT fired in this case.\nAll pending delays are cancelled immediately.")]
	public UnityEvent OnRecordRemoved;

	[Tooltip("Fired each time the track index advances, including the wrap to 0.\nArgument: new zero-based track index.\n\nUse to update diegetic track-name displays, trigger lighting cues, etc.")]
	public UnityEvent<int> OnTrackChanged;

	[Header("Debug")]
	[Tooltip("Logs slot changes, state transitions, delays, track advances, and crossfade\nevents to the Console.\n\nSafe default: false.")]
	[SerializeField]
	private bool debugLogs;

	private RecordItem _currentRecord;

	private bool _isPlaying;

	private int _trackIndex;

	private bool _isLastTrack;

	private bool _useAAsActive;

	private float _activeWeight;

	private float _inactiveWeight;

	private Coroutine _crossfadeRoutine;

	private bool _crossfadePending;

	private Coroutine _buttonActivationRoutine;

	private Coroutine _startDelayRoutine;

	private Coroutine _stopDelayRoutine;

	private float _savedActiveTime;

	private float _savedInactiveTime;

	private bool _wasPausedByTimeScale;

	public float MasterVolume => 0f;

	private AudioSource ActiveSource => null;

	private AudioSource InactiveSource => null;

	public void SetMasterVolume(float volume)
	{
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void SavePlaybackPositions()
	{
	}

	private void RestorePlaybackPositions()
	{
	}

	private void OnApplicationPause(bool pauseStatus)
	{
	}

	private void HandleSlotFilled()
	{
	}

	private void HandleSlotCleared()
	{
	}

	public void TogglePlayStop()
	{
	}

	private void StartPlayback()
	{
	}

	private void StopPlayback()
	{
	}

	private void ForceStop()
	{
	}

	private void HaltAudioImmediate()
	{
	}

	[IteratorStateMachine(typeof(_003CButtonActivationRoutine_003Ed__51))]
	private IEnumerator ButtonActivationRoutine()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CStartDelayRoutine_003Ed__52))]
	private IEnumerator StartDelayRoutine()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CStopDelayRoutine_003Ed__53))]
	private IEnumerator StopDelayRoutine()
	{
		return null;
	}

	private void CancelButtonActivation()
	{
	}

	private void CancelStartDelay()
	{
	}

	private void CancelStopDelay()
	{
	}

	private void AdvanceTrack(bool crossfade)
	{
	}

	[IteratorStateMachine(typeof(_003CCrossfadeRoutine_003Ed__58))]
	private IEnumerator CrossfadeRoutine(AudioClip incomingClip, AudioSource outgoing, AudioSource incoming)
	{
		return null;
	}

	private void StopCrossfadeRoutine()
	{
	}

	private void ApplyMasterVolumeToSources()
	{
	}

	private void UpdateIsLastTrack()
	{
	}

	private void PlayClipOnSource(AudioSource source, AudioClip clip, float weight)
	{
	}

	private void StopSourceImmediate(AudioSource source, bool isActive)
	{
	}

	private void SetButtonActive(bool active)
	{
	}

	private static float SmoothStep01(float t)
	{
		return 0f;
	}
}
