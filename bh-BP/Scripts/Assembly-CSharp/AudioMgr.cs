using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_FadeOutEventInst_003Ed__65 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float len;

		public EventInstance evInst;

		private float _003CstartTime_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_FadeOutEventInst_003Ed__65(int _003C_003E1__state)
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
	private sealed class _003C_FadeOutEventInstCoroutine_003Ed__67 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float len;

		public EventInstance evInst;

		private float _003CstartTime_003E5__2;

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
		public _003C_FadeOutEventInstCoroutine_003Ed__67(int _003C_003E1__state)
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
	private sealed class _003C_FadeOutMusic_003Ed__77 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float secs;

		public AudioMgr _003C_003E4__this;

		private float _003CstartTime_003E5__2;

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
		public _003C_FadeOutMusic_003Ed__77(int _003C_003E1__state)
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
	private sealed class _003C_WaitAndInitFMOD_003Ed__39 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public AudioMgr _003C_003E4__this;

		private FMOD.Studio.System _003Csys_003E5__2;

		private Bank[] _003Cbanks_003E5__3;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_WaitAndInitFMOD_003Ed__39(int _003C_003E1__state)
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

	public static AudioMgr I;

	public CoolButtonAud DefaultBtnAud;

	public EventReference[] _sfxEvents;

	public EventReference SFXBuildingPlaceCommon;

	public EventReference SFXBuildingPlaceScaffold;

	public EventReference SFXBuildingPickupCommon;

	public EventReference SFXBuildingPickupScaffold;

	public EventReference SFXBuildingDismantleCommon;

	public BuildingSFXPalette SFXPaletteResourceDepleted;

	public int NumWallBouncesThisFrame;

	public int NumHitsThisFrame;

	public float LastEnemyHitTime;

	public Bus[] MainBuses;

	private static readonly string[] kMainBusNames;

	public Bus[][] SFXBuses;

	private static readonly string[][] kSFXBusNames;

	public VCA[] VCAs;

	private static readonly string[] kVCANames;

	private static readonly string[] kSnapshotNames;

	private EventInstance[] _snapshots;

	public EventInstance MusicEvInst;

	private GUID _curMusicGuid;

	public EventInstance AmbMusicEvInst;

	private GUID _curAmbMusicGuid;

	public EventInstance AmbEvInst;

	private GUID _curAmbGuid;

	public TimelineInfo MusicTimeline;

	private GCHandle _musicTimelineHandle;

	private EVENT_CALLBACK _musicBeatCallback;

	private EventDescription _musicDescCallback;

	public DelegateUtl.NoArgsEvent OnMusicBeat;

	private bool _isBeatCallbackDirty;

	private Coroutine _curMusicFade;

	private float _nextSpatializeShiftTime;

	private Vector2[] _recentMinSpatializedPos;

	private Vector2[] _recentMaxSpatializedPos;

	private Vector2 _minSpatializedPos;

	private Vector2 _maxSpatializedPos;

	private void Awake()
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitAndInitFMOD_003Ed__39))]
	private IEnumerator<float> _WaitAndInitFMOD()
	{
		return null;
	}

	private void InitFMOD()
	{
	}

	private void OnApplicationFocus(bool hasFocus)
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	private void OnDestroy()
	{
	}

	public void PlayEvent(SFXType t, Transform tgtXfm = null, float volume = 1f)
	{
	}

	public void PlayEvent(string evName, Transform tgtXfm = null, float volume = 1f)
	{
	}

	public void FakeSpatialize(EventInstance evInst, Transform tgtXfm)
	{
	}

	public void FakeSpatialize(EventInstance evInst, Vector3 pos)
	{
	}

	public void PlayEvent(EventReference ev, Transform tgtXfm = null, float volume = 1f)
	{
	}

	public void PlayEvent(string evName, Vector3 pos)
	{
	}

	public void PlayEvent(EventReference ev, Vector3 pos)
	{
	}

	public void PlayEnemyHitEvent(EventReference ev, Vector3 pos)
	{
	}

	public void PlayBallBounceEvent(EventReference ev, float lastHitTime, Transform tgtXfm, bool isBaby)
	{
	}

	public void PlayEventPanned(EventReference ev, float panAmt)
	{
	}

	public void PlayBuildingPlacementEvent(string ev, float buildingSize)
	{
	}

	public void PlayBuildingPlacementEvent(EventReference ev, float buildingSize)
	{
	}

	public void PlayEventAtPitch(string evName, float pitch)
	{
	}

	public void PlayEventAtPitch(EventReference ev, float pitch)
	{
	}

	public EventInstance PlayEventCustomStop(string evName)
	{
		return default(EventInstance);
	}

	public EventInstance PlayEventCustomStop(EventReference ev)
	{
		return default(EventInstance);
	}

	public void SetSFXVolume(float vol)
	{
	}

	public void StopEventInst(EventInstance evInst)
	{
	}

	public void FadeOutEventInst(EventInstance evInst, float len)
	{
	}

	[IteratorStateMachine(typeof(_003C_FadeOutEventInst_003Ed__65))]
	private IEnumerator<float> _FadeOutEventInst(EventInstance evInst, float len)
	{
		return null;
	}

	public void FadeOutEventInstCoroutine(EventInstance evInst, float len, float delay)
	{
	}

	[IteratorStateMachine(typeof(_003C_FadeOutEventInstCoroutine_003Ed__67))]
	private IEnumerator _FadeOutEventInstCoroutine(EventInstance evInst, float len, float delay)
	{
		return null;
	}

	public void SetSFXBusVolume(SFXBusType bus, float vol)
	{
	}

	public void SetMusicVolume(float vol)
	{
	}

	public void PlayMusic(string evName)
	{
	}

	public void PlayMusic(EventReference mus)
	{
	}

	public void PlayAmbientMusic(string evName)
	{
	}

	public void PlayAmbientMusic(EventReference mus)
	{
	}

	public void StopAmbientMusic()
	{
	}

	public void StopMusic()
	{
	}

	public void FadeOutMusic(float secs)
	{
	}

	[IteratorStateMachine(typeof(_003C_FadeOutMusic_003Ed__77))]
	private IEnumerator _FadeOutMusic(float secs)
	{
		return null;
	}

	[MonoPInvokeCallback(typeof(EVENT_CALLBACK))]
	private static RESULT BeatEventCallback(EVENT_CALLBACK_TYPE type, IntPtr instancePtr, IntPtr parameterPtr)
	{
		return default(RESULT);
	}

	public void PlayAmbience(string ambName)
	{
	}

	public void PlayAmbience(EventReference amb)
	{
	}

	public void StopAmbience()
	{
	}

	private void OnGameSpeedChanged()
	{
	}

	public void PlaySnapshot(AudioSnapshotType t)
	{
	}

	public void StopSnapshot(AudioSnapshotType t)
	{
	}

	public void StopAllSnapshots()
	{
	}
}
