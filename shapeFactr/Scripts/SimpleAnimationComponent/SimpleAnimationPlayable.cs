using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class SimpleAnimationPlayable : PlayableBehaviour
{
	private class StateEnumerable : IEnumerable<IState>, IEnumerable
	{
		private class StateEnumerator : IEnumerator<IState>, IEnumerator, IDisposable
		{
			private int m_Index;

			private int m_Version;

			private SimpleAnimationPlayable m_Owner;

			object IEnumerator.Current => null;

			IState IEnumerator<IState>.Current => null;

			public StateEnumerator(SimpleAnimationPlayable owner)
			{
			}

			private bool IsValid()
			{
				return false;
			}

			private IState GetCurrentHandle(int index)
			{
				return null;
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Reset()
			{
			}
		}

		private SimpleAnimationPlayable m_Owner;

		public StateEnumerable(SimpleAnimationPlayable owner)
		{
		}

		public IEnumerator<IState> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	public interface IState
	{
		bool enabled { get; set; }

		float time { get; set; }

		float normalizedTime { get; set; }

		float speed { get; set; }

		string name { get; set; }

		float weight { get; set; }

		float length { get; }

		AnimationClip clip { get; }

		WrapMode wrapMode { get; }

		bool IsValid();
	}

	public class StateHandle : IState
	{
		private SimpleAnimationPlayable m_Parent;

		private int m_Index;

		private Playable m_Target;

		public bool enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float time
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float normalizedTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float speed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public string name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float weight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float length => 0f;

		public AnimationClip clip => null;

		public WrapMode wrapMode => default(WrapMode);

		public int index => 0;

		public StateHandle(SimpleAnimationPlayable s, int index, Playable target)
		{
		}

		public bool IsValid()
		{
			return false;
		}
	}

	private class StateInfo
	{
		private bool m_Enabled;

		private int m_Index;

		private string m_StateName;

		private bool m_Fading;

		private float m_Time;

		private float m_TargetWeight;

		private float m_Weight;

		private float m_FadeSpeed;

		private AnimationClip m_Clip;

		private Playable m_Playable;

		private WrapMode m_WrapMode;

		private bool m_IsClone;

		private bool m_ReadyForCleanup;

		public StateHandle m_ParentState;

		private bool m_WeightDirty;

		private bool m_EnabledDirty;

		private bool m_TimeIsUpToDate;

		public bool enabled => false;

		public int index
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string stateName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool fading => false;

		public float targetWeight => 0f;

		public float weight => 0f;

		public float fadeSpeed => 0f;

		public float speed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float playableDuration => 0f;

		public AnimationClip clip => null;

		public bool isDone => false;

		public Playable playable => default(Playable);

		public WrapMode wrapMode => default(WrapMode);

		public bool isClone => false;

		public bool isReadyForCleanup => false;

		public StateHandle parentState => null;

		public bool enabledDirty => false;

		public bool weightDirty => false;

		public void Initialize(string name, AnimationClip clip, WrapMode wrapMode)
		{
		}

		public float GetTime()
		{
			return 0f;
		}

		public void SetTime(float newTime)
		{
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public void Pause()
		{
		}

		public void Play()
		{
		}

		public void Stop()
		{
		}

		public void ForceWeight(float weight)
		{
		}

		public void SetWeight(float weight)
		{
		}

		public void FadeTo(float weight, float speed)
		{
		}

		public void DestroyPlayable()
		{
		}

		public void SetAsCloneOf(StateHandle handle)
		{
		}

		public void SetPlayable(Playable playable)
		{
		}

		public void ResetDirtyFlags()
		{
		}

		public void InvalidateTime()
		{
		}
	}

	private class StateManagement
	{
		private List<StateInfo> m_States;

		private int m_Count;

		public int Count => 0;

		public StateInfo this[int i] => null;

		public StateInfo InsertState()
		{
			return null;
		}

		public bool AnyStatePlaying()
		{
			return false;
		}

		public void RemoveState(int index)
		{
		}

		public bool RemoveClip(AnimationClip clip)
		{
			return false;
		}

		public StateInfo FindState(string name)
		{
			return null;
		}

		public void EnableState(int index)
		{
		}

		public void DisableState(int index)
		{
		}

		public void SetInputWeight(int index, float weight)
		{
		}

		public void SetStateTime(int index, float time)
		{
		}

		public float GetStateTime(int index)
		{
			return 0f;
		}

		public bool IsCloneOf(int potentialCloneIndex, int originalIndex)
		{
			return false;
		}

		public float GetStateSpeed(int index)
		{
			return 0f;
		}

		public void SetStateSpeed(int index, float value)
		{
		}

		public float GetInputWeight(int index)
		{
			return 0f;
		}

		public float GetStateLength(int index)
		{
			return 0f;
		}

		public float GetClipLength(int index)
		{
			return 0f;
		}

		public float GetStatePlayableDuration(int index)
		{
			return 0f;
		}

		public AnimationClip GetStateClip(int index)
		{
			return null;
		}

		public WrapMode GetStateWrapMode(int index)
		{
			return default(WrapMode);
		}

		public string GetStateName(int index)
		{
			return null;
		}

		public void SetStateName(int index, string name)
		{
		}

		public void StopState(int index, bool cleanup)
		{
		}
	}

	private struct QueuedState
	{
		public StateHandle state;

		public float fadeTime;

		public QueuedState(StateHandle s, float t)
		{
			state = null;
			fadeTime = 0f;
		}
	}

	private LinkedList<QueuedState> m_StateQueue;

	private StateManagement m_States;

	private bool m_Initialized;

	private bool m_KeepStoppedPlayablesConnected;

	protected Playable m_ActualPlayable;

	private AnimationMixerPlayable m_Mixer;

	public Action onDone;

	private int m_StatesVersion;

	public bool keepStoppedPlayablesConnected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	protected Playable self => default(Playable);

	public Playable playable => default(Playable);

	protected PlayableGraph graph => default(PlayableGraph);

	private void UpdateStoppedPlayablesConnections()
	{
	}

	public Playable GetInput(int index)
	{
		return default(Playable);
	}

	public override void OnPlayableCreate(Playable playable)
	{
	}

	public IEnumerable<IState> GetStates()
	{
		return null;
	}

	public IState GetState(string name)
	{
		return null;
	}

	private StateInfo DoAddClip(string name, AnimationClip clip)
	{
		return null;
	}

	public bool AddClip(AnimationClip clip, string name)
	{
		return false;
	}

	public bool RemoveClip(string name)
	{
		return false;
	}

	public bool RemoveClip(AnimationClip clip)
	{
		return false;
	}

	public bool Play(string name)
	{
		return false;
	}

	private bool Play(int index)
	{
		return false;
	}

	public bool PlayQueued(string name, QueueMode queueMode)
	{
		return false;
	}

	private bool PlayQueued(int index, QueueMode queueMode)
	{
		return false;
	}

	public void Rewind(string name)
	{
	}

	private void Rewind(int index)
	{
	}

	public void Rewind()
	{
	}

	private void RemoveClones(StateInfo state)
	{
	}

	public bool Stop(string name)
	{
		return false;
	}

	private void DoStop(int index)
	{
	}

	public bool StopAll()
	{
		return false;
	}

	public bool IsPlaying()
	{
		return false;
	}

	public bool IsPlaying(string stateName)
	{
		return false;
	}

	private bool IsClonePlaying(StateInfo state)
	{
		return false;
	}

	public int GetClipCount()
	{
		return 0;
	}

	private void SetupLerp(StateInfo state, float targetWeight, float time)
	{
	}

	private bool Crossfade(int index, float time)
	{
		return false;
	}

	private StateInfo CloneState(int index)
	{
		return null;
	}

	public bool Crossfade(string name, float time)
	{
		return false;
	}

	public bool CrossfadeQueued(string name, float time, QueueMode queueMode)
	{
		return false;
	}

	private bool CrossfadeQueued(int index, float time, QueueMode queueMode)
	{
		return false;
	}

	private bool Blend(int index, float targetWeight, float time)
	{
		return false;
	}

	public bool Blend(string name, float targetWeight, float time)
	{
		return false;
	}

	public override void OnGraphStop(Playable playable)
	{
	}

	private void UpdateDoneStatus()
	{
	}

	private void CleanClonedStates()
	{
	}

	private void DisconnectInput(int index)
	{
	}

	private void ConnectInput(int index)
	{
	}

	private void UpdateStates(float deltaTime)
	{
	}

	private float CalculateQueueTimes()
	{
		return 0f;
	}

	private void ClearQueuedStates()
	{
	}

	private void UpdateQueuedStates()
	{
	}

	private void InvalidateStateTimes()
	{
	}

	public override void PrepareFrame(Playable owner, FrameData data)
	{
	}

	public bool ValidateInput(int index, Playable input)
	{
		return false;
	}

	public bool ValidateIndex(int index)
	{
		return false;
	}

	private void InvalidateStates()
	{
	}

	private StateHandle StateInfoToHandle(StateInfo info)
	{
		return null;
	}
}
