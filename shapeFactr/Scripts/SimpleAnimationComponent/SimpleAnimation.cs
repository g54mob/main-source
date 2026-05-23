using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Animator))]
public class SimpleAnimation : MonoBehaviour, IAnimationClipSource
{
	public interface State
	{
		bool enabled { get; set; }

		bool isValid { get; }

		float time { get; set; }

		float normalizedTime { get; set; }

		float speed { get; set; }

		string name { get; set; }

		float weight { get; set; }

		float length { get; }

		AnimationClip clip { get; }

		WrapMode wrapMode { get; set; }
	}

	private class StateEnumerable : IEnumerable<State>, IEnumerable
	{
		private class StateEnumerator : IEnumerator<State>, IEnumerator, IDisposable
		{
			private SimpleAnimation m_Owner;

			private IEnumerator<SimpleAnimationPlayable.IState> m_Impl;

			object IEnumerator.Current => null;

			State IEnumerator<State>.Current => null;

			public StateEnumerator(SimpleAnimation owner)
			{
			}

			private State GetCurrent()
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

		private SimpleAnimation m_Owner;

		public StateEnumerable(SimpleAnimation owner)
		{
		}

		public IEnumerator<State> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	private class StateImpl : State
	{
		private SimpleAnimationPlayable.IState m_StateHandle;

		private SimpleAnimation m_Component;

		bool State.enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		bool State.isValid => false;

		float State.time
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		float State.normalizedTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		float State.speed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		string State.name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		float State.weight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		float State.length => 0f;

		AnimationClip State.clip => null;

		WrapMode State.wrapMode
		{
			get
			{
				return default(WrapMode);
			}
			set
			{
			}
		}

		public StateImpl(SimpleAnimationPlayable.IState handle, SimpleAnimation component)
		{
		}
	}

	[Serializable]
	public class EditorState
	{
		public AnimationClip clip;

		public string name;

		public bool defaultState;
	}

	private const string kDefaultStateName = "Default";

	protected PlayableGraph m_Graph;

	protected PlayableHandle m_LayerMixer;

	protected PlayableHandle m_TransitionMixer;

	protected Animator m_Animator;

	protected bool m_Initialized;

	protected bool m_IsPlaying;

	protected SimpleAnimationPlayable m_Playable;

	[SerializeField]
	protected bool m_PlayAutomatically;

	[SerializeField]
	protected bool m_AnimatePhysics;

	[SerializeField]
	protected AnimatorCullingMode m_CullingMode;

	[SerializeField]
	protected WrapMode m_WrapMode;

	[SerializeField]
	protected AnimationClip m_Clip;

	[SerializeField]
	private EditorState[] m_States;

	public Animator animator => null;

	public bool animatePhysics
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public AnimatorCullingMode cullingMode
	{
		get
		{
			return default(AnimatorCullingMode);
		}
		set
		{
		}
	}

	public bool isPlaying => false;

	public bool playAutomatically
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public AnimationClip clip
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public WrapMode wrapMode
	{
		get
		{
			return default(WrapMode);
		}
		set
		{
		}
	}

	public State this[string name] => null;

	public void AddClip(AnimationClip clip, string newName)
	{
	}

	public void Blend(string stateName, float targetWeight, float fadeLength)
	{
	}

	public void CrossFade(string stateName, float fadeLength)
	{
	}

	public void CrossFadeQueued(string stateName, float fadeLength, QueueMode queueMode)
	{
	}

	public int GetClipCount()
	{
		return 0;
	}

	public bool IsPlaying(string stateName)
	{
		return false;
	}

	public void Stop()
	{
	}

	public void Stop(string stateName)
	{
	}

	public void Sample()
	{
	}

	public bool Play()
	{
		return false;
	}

	public void AddState(AnimationClip clip, string name)
	{
	}

	public void RemoveState(string name)
	{
	}

	public bool Play(string stateName)
	{
		return false;
	}

	public void PlayQueued(string stateName, QueueMode queueMode)
	{
	}

	public void RemoveClip(AnimationClip clip)
	{
	}

	public void Rewind()
	{
	}

	public void Rewind(string stateName)
	{
	}

	public State GetState(string stateName)
	{
		return null;
	}

	public IEnumerable<State> GetStates()
	{
		return null;
	}

	protected void Kick()
	{
	}

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnDisable()
	{
	}

	private void Reset()
	{
	}

	private void Initialize()
	{
	}

	private void EnsureDefaultStateExists()
	{
	}

	protected virtual void Awake()
	{
	}

	protected void OnDestroy()
	{
	}

	private void OnPlayableDone()
	{
	}

	private void RebuildStates()
	{
	}

	private EditorState CreateDefaultEditorState()
	{
		return null;
	}

	private static void LegacyClipCheck(AnimationClip clip)
	{
	}

	private void InvalidLegacyClipError(string clipName, string stateName)
	{
	}

	private void OnValidate()
	{
	}

	public void GetAnimationClips(List<AnimationClip> results)
	{
	}
}
