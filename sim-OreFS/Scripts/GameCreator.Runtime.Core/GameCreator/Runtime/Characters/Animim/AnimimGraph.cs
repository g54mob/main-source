using System;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace GameCreator.Runtime.Characters.Animim
{
	[Serializable]
	public class AnimimGraph
	{
		private const string NAME_GRAPH = "Animim Graph";

		private const string NAME_ANIM_OUTPUT = "Animation Output";

		internal const float SAFE_TIME_OFFSET = 0.01f;

		[NonSerialized]
		private Character m_Character;

		[NonSerialized]
		private Args m_Args;

		[NonSerialized]
		private AnimationPlayableOutput m_AnimationOutput;

		[NonSerialized]
		private AnimationLayerMixerPlayable m_IK;

		[NonSerialized]
		private ScriptPlayable<StatesOutput> m_States;

		[NonSerialized]
		private ScriptPlayable<GesturesOutput> m_Gestures;

		[NonSerialized]
		private RuntimeAnimatorController m_RuntimeController;

		[NonSerialized]
		private AnimatorControllerPlayable m_AnimatorController;

		[NonSerialized]
		protected Phases m_Phases = new Phases();

		internal Character Character => m_Character;

		public PlayableGraph Graph { get; private set; }

		public StatesOutput States
		{
			get
			{
				if (!m_States.IsValid())
				{
					return null;
				}
				return m_States.GetBehaviour();
			}
		}

		public GesturesOutput Gestures
		{
			get
			{
				if (!m_Gestures.IsValid())
				{
					return null;
				}
				return m_Gestures.GetBehaviour();
			}
		}

		internal float RootMotionPosition
		{
			get
			{
				if (!UseRootMotionPosition)
				{
					return 0f;
				}
				return Math.Max(Gestures.RootMotion, States.RootMotion);
			}
		}

		internal float RootMotionRotation
		{
			get
			{
				if (!UseRootMotionRotation)
				{
					return 0f;
				}
				return Math.Max(Gestures.RootMotion, States.RootMotion);
			}
		}

		[field: NonSerialized]
		internal bool UseRootMotionPosition { private get; set; } = true;

		[field: NonSerialized]
		internal bool UseRootMotionRotation { private get; set; } = true;

		public Phases Phases => m_Phases;

		internal void OnStartup(Character character)
		{
			m_Character = character;
			m_Args = new Args(character);
			CreateGraph(m_Character.Animim.Animator);
			m_Phases.Setup(m_Character.Animim.Animator);
			character.EventAfterChangeModel += OnModelChange;
		}

		internal void AfterStartup(Character character)
		{
		}

		internal void OnDispose(Character character)
		{
			character.EventAfterChangeModel -= OnModelChange;
			DestroyGraph();
		}

		internal void OnUpdate()
		{
		}

		private void CreateGraph(Animator animator)
		{
			if (animator == null)
			{
				Debug.LogError("Animator reference is null");
				return;
			}
			if (Graph.IsValid())
			{
				Graph.Destroy();
			}
			Graph = PlayableGraph.Create("Animim Graph");
			m_AnimationOutput = AnimationPlayableOutput.Create(Graph, "Animation Output", animator);
			SetIK();
			StatesOutput template = new StatesOutput(this);
			GesturesOutput template2 = new GesturesOutput(this);
			m_States = ScriptPlayable<StatesOutput>.Create(Graph, template, 1);
			m_Gestures = ScriptPlayable<GesturesOutput>.Create(Graph, template2, 1);
			m_States.SetInputWeight(0, 1f);
			m_Gestures.SetInputWeight(0, 1f);
			if (animator.runtimeAnimatorController != null)
			{
				m_RuntimeController = animator.runtimeAnimatorController;
			}
			if (m_RuntimeController != null)
			{
				m_AnimatorController = AnimatorControllerPlayable.Create(Graph, m_RuntimeController);
				Graph.Connect(m_AnimatorController, 0, m_States, 0);
			}
			Graph.Connect(m_States, 0, m_Gestures, 0);
			Graph.Connect(m_Gestures, 0, m_IK, 0);
			m_AnimationOutput.SetSourcePlayable(m_IK);
			Graph.SetTimeUpdateMode(m_Character.Time.UpdateTime switch
			{
				TimeMode.UpdateMode.GameTime => DirectorUpdateMode.GameTime, 
				TimeMode.UpdateMode.UnscaledTime => DirectorUpdateMode.UnscaledGameTime, 
				_ => throw new ArgumentOutOfRangeException(), 
			});
			Graph.Play();
		}

		private void DestroyGraph()
		{
			if (Graph.IsValid())
			{
				Graph.Destroy();
			}
		}

		private void SetIK()
		{
			AnimationClipPlayable sourcePlayable = AnimationClipPlayable.Create(Graph, null);
			sourcePlayable.SetApplyFootIK(value: true);
			sourcePlayable.SetApplyPlayableIK(value: true);
			m_IK = AnimationLayerMixerPlayable.Create(Graph, 2);
			m_IK.ConnectInput(1, sourcePlayable, 0);
			m_IK.SetLayerAdditive(0u, value: false);
			m_IK.SetLayerAdditive(1u, value: true);
			m_IK.SetInputWeight(0, 1f);
			m_IK.SetInputWeight(1, 1f);
		}

		private void OnModelChange()
		{
			CreateGraph(m_Character.Animim.Animator);
		}
	}
}
