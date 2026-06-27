using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Animator))]
public class SimpleAnimation : MonoBehaviour
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

			object IEnumerator.Current => GetCurrent();

			State IEnumerator<State>.Current => GetCurrent();

			public StateEnumerator(SimpleAnimation owner)
			{
				m_Owner = owner;
				m_Impl = m_Owner.m_Playable.GetStates().GetEnumerator();
				Reset();
			}

			private State GetCurrent()
			{
				return new StateImpl(m_Impl.Current, m_Owner);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				return m_Impl.MoveNext();
			}

			public void Reset()
			{
				m_Impl.Reset();
			}
		}

		private SimpleAnimation m_Owner;

		public StateEnumerable(SimpleAnimation owner)
		{
			m_Owner = owner;
		}

		public IEnumerator<State> GetEnumerator()
		{
			return new StateEnumerator(m_Owner);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new StateEnumerator(m_Owner);
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
				return m_StateHandle.enabled;
			}
			set
			{
				m_StateHandle.enabled = value;
				if (value)
				{
					m_Component.Kick();
				}
			}
		}

		bool State.isValid => m_StateHandle.IsValid();

		float State.time
		{
			get
			{
				return m_StateHandle.time;
			}
			set
			{
				m_StateHandle.time = value;
				m_Component.Kick();
			}
		}

		float State.normalizedTime
		{
			get
			{
				return m_StateHandle.normalizedTime;
			}
			set
			{
				m_StateHandle.normalizedTime = value;
				m_Component.Kick();
			}
		}

		float State.speed
		{
			get
			{
				return m_StateHandle.speed;
			}
			set
			{
				m_StateHandle.speed = value;
				m_Component.Kick();
			}
		}

		string State.name
		{
			get
			{
				return m_StateHandle.name;
			}
			set
			{
				m_StateHandle.name = value;
			}
		}

		float State.weight
		{
			get
			{
				return m_StateHandle.weight;
			}
			set
			{
				m_StateHandle.weight = value;
				m_Component.Kick();
			}
		}

		float State.length => m_StateHandle.length;

		AnimationClip State.clip => m_StateHandle.clip;

		WrapMode State.wrapMode
		{
			get
			{
				return m_StateHandle.wrapMode;
			}
			set
			{
				Debug.LogError("Not Implemented");
			}
		}

		public StateImpl(SimpleAnimationPlayable.IState handle, SimpleAnimation component)
		{
			m_StateHandle = handle;
			m_Component = component;
		}
	}

	[Serializable]
	public class EditorState
	{
		public AnimationClip clip;

		public string name;

		public bool defaultState;
	}

	protected PlayableGraph m_Graph;

	protected PlayableHandle m_LayerMixer;

	protected PlayableHandle m_TransitionMixer;

	protected Animator m_Animator;

	protected bool m_Initialized;

	protected bool m_IsPlaying;

	protected SimpleAnimationPlayable m_Playable;

	[SerializeField]
	protected bool m_PlayAutomatically = true;

	[SerializeField]
	protected bool m_AnimatePhysics;

	[SerializeField]
	protected AnimatorCullingMode m_CullingMode = AnimatorCullingMode.CullUpdateTransforms;

	[SerializeField]
	protected WrapMode m_WrapMode;

	[SerializeField]
	protected AnimationClip m_Clip;

	[SerializeField]
	public EditorState[] m_States;

	public Animator animator
	{
		get
		{
			if (m_Animator == null)
			{
				m_Animator = GetComponent<Animator>();
			}
			return m_Animator;
		}
	}

	public bool animatePhysics
	{
		get
		{
			return m_AnimatePhysics;
		}
		set
		{
			m_AnimatePhysics = value;
			animator.updateMode = (m_AnimatePhysics ? AnimatorUpdateMode.Fixed : AnimatorUpdateMode.Normal);
		}
	}

	public AnimatorCullingMode cullingMode
	{
		get
		{
			return animator.cullingMode;
		}
		set
		{
			m_CullingMode = value;
			animator.cullingMode = m_CullingMode;
		}
	}

	public bool isPlaying => m_Playable.IsPlaying();

	public bool playAutomatically
	{
		get
		{
			return m_PlayAutomatically;
		}
		set
		{
			m_PlayAutomatically = value;
		}
	}

	public AnimationClip clip
	{
		get
		{
			return m_Clip;
		}
		set
		{
			LegacyClipCheck(value);
			m_Clip = value;
		}
	}

	public WrapMode wrapMode
	{
		get
		{
			return m_WrapMode;
		}
		set
		{
			m_WrapMode = value;
		}
	}

	public State this[string name] => GetState(name);

	public void AddClip(AnimationClip clip, string newName)
	{
		LegacyClipCheck(clip);
		AddState(clip, newName);
	}

	public void Blend(string stateName, float targetWeight, float fadeLength)
	{
		m_Animator.enabled = true;
		Kick();
		m_Playable.Blend(stateName, targetWeight, fadeLength);
	}

	public void CrossFade(string stateName, float fadeLength)
	{
		m_Animator.enabled = true;
		Kick();
		m_Playable.Crossfade(stateName, fadeLength);
	}

	public void CrossFadeQueued(string stateName, float fadeLength, QueueMode queueMode)
	{
		m_Animator.enabled = true;
		Kick();
		m_Playable.CrossfadeQueued(stateName, fadeLength, queueMode);
	}

	public int GetClipCount()
	{
		return m_Playable.GetClipCount();
	}

	public bool IsPlaying(string stateName)
	{
		return m_Playable.IsPlaying(stateName);
	}

	public void Stop()
	{
		m_Playable.StopAll();
	}

	public void Stop(string stateName)
	{
		m_Playable.Stop(stateName);
	}

	public void Sample()
	{
		m_Graph.Evaluate();
	}

	public bool Play()
	{
		m_Animator.enabled = true;
		Kick();
		if (m_Clip != null)
		{
			m_Playable.Play(m_Clip.name);
		}
		return false;
	}

	public void AddState(AnimationClip clip, string name)
	{
		LegacyClipCheck(clip);
		Kick();
		if (m_Playable.AddClip(clip, name))
		{
			RebuildStates();
		}
	}

	public void RemoveState(string name)
	{
		if (m_Playable.RemoveClip(name))
		{
			RebuildStates();
		}
	}

	public bool Play(string stateName)
	{
		if (m_Animator == null)
		{
			Initialize();
		}
		m_Animator.enabled = true;
		Kick();
		if (m_Playable.GetClipCount() == 0)
		{
			return false;
		}
		return m_Playable.Play(stateName);
	}

	public void PlayQueued(string stateName, QueueMode queueMode)
	{
		m_Animator.enabled = true;
		Kick();
		m_Playable.PlayQueued(stateName, queueMode);
	}

	public void RemoveClip(AnimationClip clip)
	{
		if (clip == null)
		{
			throw new NullReferenceException("clip");
		}
		if (m_Playable.RemoveClip(clip))
		{
			RebuildStates();
		}
	}

	public void Rewind()
	{
		Kick();
		m_Playable.Rewind();
	}

	public void Rewind(string stateName)
	{
		Kick();
		m_Playable.Rewind(stateName);
	}

	public State GetState(string stateName)
	{
		if (m_Playable == null)
		{
			return null;
		}
		SimpleAnimationPlayable.IState state = m_Playable.GetState(stateName);
		if (state == null)
		{
			return null;
		}
		return new StateImpl(state, this);
	}

	public IEnumerable<State> GetStates()
	{
		return new StateEnumerable(this);
	}

	protected void Kick()
	{
		if (!m_IsPlaying)
		{
			m_Graph.Play();
			m_IsPlaying = true;
		}
	}

	protected virtual void OnEnable()
	{
		Initialize();
		m_Graph.Play();
		if (m_PlayAutomatically)
		{
			Stop();
			Play();
		}
	}

	protected virtual void OnDisable()
	{
		if (m_Initialized)
		{
			Stop();
			m_Graph.Stop();
		}
	}

	private void Reset()
	{
		if (m_Graph.IsValid())
		{
			m_Graph.Destroy();
		}
		m_Initialized = false;
	}

	private void Initialize()
	{
		if (m_Initialized)
		{
			return;
		}
		m_Animator = GetComponent<Animator>();
		m_Animator.updateMode = (m_AnimatePhysics ? AnimatorUpdateMode.Fixed : AnimatorUpdateMode.Normal);
		m_Animator.cullingMode = m_CullingMode;
		m_Graph = PlayableGraph.Create();
		m_Graph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);
		SimpleAnimationPlayable template = new SimpleAnimationPlayable();
		m_Playable = ScriptPlayable<SimpleAnimationPlayable>.Create(m_Graph, template, 1).GetBehaviour();
		SimpleAnimationPlayable playable = m_Playable;
		playable.onDone = (Action)Delegate.Combine(playable.onDone, new Action(OnPlayableDone));
		if (m_States == null)
		{
			m_States = new EditorState[1];
			m_States[0] = new EditorState();
			m_States[0].defaultState = true;
			m_States[0].name = "Default";
		}
		if (m_States != null)
		{
			EditorState[] states = m_States;
			foreach (EditorState editorState in states)
			{
				if ((bool)editorState.clip)
				{
					m_Playable.AddClip(editorState.clip, editorState.name);
				}
			}
		}
		EnsureDefaultStateExists();
		AnimationPlayableUtilities.Play(m_Animator, m_Playable.playable, m_Graph);
		Play();
		Kick();
		m_Initialized = true;
	}

	private void EnsureDefaultStateExists()
	{
		if (m_Playable != null && m_Clip != null && m_Playable.GetState(m_Clip.name) == null)
		{
			m_Playable.AddClip(m_Clip, m_Clip.name);
			Kick();
		}
	}

	protected virtual void Awake()
	{
		Initialize();
	}

	protected void OnDestroy()
	{
		if (m_Graph.IsValid())
		{
			m_Graph.Destroy();
		}
	}

	private void OnPlayableDone()
	{
		m_Graph.Stop();
		m_IsPlaying = false;
	}

	private void RebuildStates()
	{
		IEnumerable<State> states = GetStates();
		List<EditorState> list = new List<EditorState>();
		foreach (State item in states)
		{
			EditorState editorState = new EditorState();
			editorState.clip = item.clip;
			editorState.name = item.name;
			list.Add(editorState);
		}
		m_States = list.ToArray();
	}

	private EditorState CreateDefaultEditorState()
	{
		return new EditorState
		{
			name = "Default",
			clip = m_Clip,
			defaultState = true
		};
	}

	private static void LegacyClipCheck(AnimationClip clip)
	{
		if ((bool)clip && clip.legacy)
		{
			throw new ArgumentException($"Legacy clip {clip} cannot be used in this component. Set .legacy property to false before using this clip");
		}
	}

	private void InvalidLegacyClipError(string clipName, string stateName)
	{
		Debug.LogErrorFormat(base.gameObject, "Animation clip {0} in state {1} is Legacy. Set clip.legacy to false, or reimport as Generic to use it with SimpleAnimationComponent", clipName, stateName);
	}

	private void OnValidate()
	{
		if (Application.isPlaying)
		{
			return;
		}
		if ((bool)m_Clip && m_Clip.legacy)
		{
			Debug.LogErrorFormat(base.gameObject, "Animation clip {0} is Legacy. Set clip.legacy to false, or reimport as Generic to use it with SimpleAnimationComponent", m_Clip.name);
			m_Clip = null;
		}
		if (m_States == null || m_States.Length == 0)
		{
			m_States = new EditorState[1];
		}
		if (m_States[0] == null)
		{
			m_States[0] = CreateDefaultEditorState();
		}
		if (!m_States[0].defaultState || m_States[0].name != "Default")
		{
			EditorState[] states = m_States;
			m_States = new EditorState[states.Length + 1];
			m_States[0] = CreateDefaultEditorState();
			states.CopyTo(m_States, 1);
		}
		if (m_States[0].clip != m_Clip)
		{
			m_States[0].clip = m_Clip;
		}
		for (int i = 1; i < m_States.Length; i++)
		{
			if (m_States[i] == null)
			{
				m_States[i] = new EditorState();
			}
			m_States[i].defaultState = false;
		}
		int num = m_States.Length;
		string[] array = new string[num];
		for (int j = 0; j < num; j++)
		{
			EditorState editorState = m_States[j];
			if (editorState.name == "" && (bool)editorState.clip)
			{
				editorState.name = editorState.clip.name;
			}
			array[j] = editorState.name;
			if ((bool)editorState.clip && editorState.clip.legacy)
			{
				InvalidLegacyClipError(editorState.clip.name, editorState.name);
				editorState.clip = null;
			}
		}
		m_Animator = GetComponent<Animator>();
		m_Animator.updateMode = (m_AnimatePhysics ? AnimatorUpdateMode.Fixed : AnimatorUpdateMode.Normal);
		m_Animator.cullingMode = m_CullingMode;
	}
}
