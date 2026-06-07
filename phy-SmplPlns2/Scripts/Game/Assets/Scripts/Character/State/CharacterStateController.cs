using System;
using System.Collections.Generic;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.CharacterControllerPro.Implementation;
using Lightbug.Utilities;
using UnityEngine;

namespace Assets.Scripts.Character.State
{
	public class CharacterStateController : MonoBehaviour
	{
		private readonly Dictionary<string, CharacterState> _states = new Dictionary<string, CharacterState>();

		[Tooltip("The state used to start the state machine. It is necessary for the state to be not-null, active and enabled. Otherwise, the state machine will not run.")]
		[SerializeField]
		private CharacterState _initialState;

		private bool _machineStarted;

		[CustomClassDrawer]
		[SerializeField]
		private MovementReferenceParameters _movementReferenceParameters = new MovementReferenceParameters();

		private Queue<CharacterState> _transitionsQueue = new Queue<CharacterState>();

		public Animator Animator => CharacterActor.Animator;

		public bool CanCurrentStateOverrideAnimatorController
		{
			get
			{
				if (CurrentState.OverrideAnimatorController && Animator != null)
				{
					return CurrentState.RuntimeAnimatorController != null;
				}
				return false;
			}
		}

		public CharacterActor CharacterActor { get; private set; }

		public CharacterBrain CharacterBrain { get; private set; }

		public CharacterState CurrentState { get; protected set; }

		public Transform ExternalReference
		{
			get
			{
				return _movementReferenceParameters.externalReference;
			}
			set
			{
				_movementReferenceParameters.externalReference = value;
			}
		}

		public Vector3 InputMovementReference => _movementReferenceParameters.InputMovementReference;

		public Vector3 MovementReferenceForward => _movementReferenceParameters.MovementReferenceForward;

		public MovementReferenceParameters.MovementReferenceMode MovementReferenceMode
		{
			get
			{
				return _movementReferenceParameters.movementReferenceMode;
			}
			set
			{
				_movementReferenceParameters.movementReferenceMode = value;
			}
		}

		public MovementReferenceParameters MovementReferenceParameters => _movementReferenceParameters;

		public Vector3 MovementReferenceRight => _movementReferenceParameters.MovementReferenceRight;

		public CharacterState PreviousState { get; protected set; }

		public bool UpdateRootPosition
		{
			get
			{
				return CharacterActor.UpdateRootPosition;
			}
			set
			{
				CharacterActor.UpdateRootPosition = value;
			}
		}

		public bool UpdateRootRotation
		{
			get
			{
				return CharacterActor.UpdateRootRotation;
			}
			set
			{
				CharacterActor.UpdateRootRotation = value;
			}
		}

		public bool UseRootMotion
		{
			get
			{
				return CharacterActor.UseRootMotion;
			}
			set
			{
				CharacterActor.UseRootMotion = value;
			}
		}

		public event Action<CharacterState, CharacterState> OnStateChange;

		public void EnqueueTransition<T>() where T : CharacterState
		{
			CharacterState state = GetState<T>();
			if (!(state == null))
			{
				_transitionsQueue.Enqueue(state);
			}
		}

		public void EnqueueTransition(CharacterState state)
		{
			if (!(state == null))
			{
				_transitionsQueue.Enqueue(state);
			}
		}

		public void EnqueueTransitionToPreviousState()
		{
			EnqueueTransition(PreviousState);
		}

		public void ForceState(CharacterState state)
		{
			if (!(state == null))
			{
				PreviousState = CurrentState;
				CurrentState = state;
				PreviousState.ExitBehaviour(Time.deltaTime, CurrentState);
				if (CanCurrentStateOverrideAnimatorController)
				{
					Animator.runtimeAnimatorController = CurrentState.RuntimeAnimatorController;
				}
				CurrentState.EnterBehaviour(Time.deltaTime, PreviousState);
			}
		}

		public void ForceState<T>() where T : CharacterState
		{
			CharacterState state = GetState<T>();
			if (!(state == null))
			{
				ForceState(state);
			}
		}

		public CharacterState GetState(string stateName)
		{
			_states.TryGetValue(stateName, out var value);
			return value;
		}

		public CharacterState GetState<T>() where T : CharacterState
		{
			string stateName = typeof(T).Name;
			return GetState(stateName);
		}

		public void ResetIKWeights()
		{
			CharacterActor.ResetIKWeights();
		}

		protected void Awake()
		{
			CharacterActor = this.GetComponentInBranch<CharacterActor>();
			CharacterBrain = this.GetComponentInBranch<CharacterActor, CharacterBrain>();
			AddStates();
		}

		protected void OnAnimatorIK(int layerIndex)
		{
			if (!(CurrentState == null))
			{
				CurrentState.UpdateIK(layerIndex);
			}
		}

		protected void OnDisable()
		{
			CharacterActor.OnPreSimulation -= PreCharacterSimulation;
			CharacterActor.OnPostSimulation -= PostCharacterSimulation;
			if (Animator != null)
			{
				CharacterActor.OnAnimatorIKEvent -= OnAnimatorIK;
			}
		}

		protected void OnEnable()
		{
			CharacterActor.OnPreSimulation += PreCharacterSimulation;
			CharacterActor.OnPostSimulation += PostCharacterSimulation;
			if (Animator != null)
			{
				CharacterActor.OnAnimatorIKEvent += OnAnimatorIK;
			}
		}

		protected void Start()
		{
			_movementReferenceParameters.Initialize(CharacterActor);
		}

		protected void Update()
		{
			if (!_machineStarted)
			{
				if (_initialState == null)
				{
					base.enabled = false;
					return;
				}
				CurrentState = _initialState;
				if (CharacterActor == null || CurrentState == null || !CurrentState.isActiveAndEnabled)
				{
					return;
				}
				_machineStarted = true;
				CurrentState.EnterBehaviour(0f, CurrentState);
				if (CanCurrentStateOverrideAnimatorController)
				{
					Animator.runtimeAnimatorController = CurrentState.RuntimeAnimatorController;
				}
			}
			if (CharacterActor == null || CurrentState == null || !CurrentState.isActiveAndEnabled)
			{
				return;
			}
			_movementReferenceParameters.UpdateData(CharacterBrain.Actions.Movement.value);
			if (!_machineStarted)
			{
				CurrentState.EnterBehaviour(0f, CurrentState);
				_machineStarted = true;
			}
			bool num = CheckForTransitions();
			_transitionsQueue.Clear();
			float deltaTime = Time.deltaTime;
			if (num)
			{
				PreviousState.ExitBehaviour(deltaTime, CurrentState);
				if (CanCurrentStateOverrideAnimatorController)
				{
					Animator.runtimeAnimatorController = CurrentState.RuntimeAnimatorController;
				}
				CurrentState.EnterBehaviour(deltaTime, PreviousState);
			}
			CurrentState.PreUpdateBehaviour(deltaTime);
			CurrentState.UpdateBehaviour(deltaTime);
			CurrentState.PostUpdateBehaviour(deltaTime);
		}

		private void AddStates()
		{
			CharacterState[] componentsInChildren = CharacterActor.GetComponentsInChildren<CharacterState>();
			foreach (CharacterState characterState in componentsInChildren)
			{
				string text = characterState.GetType().Name;
				if (GetState(text) != null)
				{
					Debug.Log("Warning: GameObject " + characterState.gameObject.name + " has the state " + text + " repeated in the hierarchy.");
				}
				else
				{
					_states.Add(text, characterState);
				}
			}
		}

		private bool CheckForTransitions()
		{
			CurrentState.CheckExitTransition();
			CharacterState characterState = null;
			while (_transitionsQueue.Count != 0)
			{
				CharacterState characterState2 = _transitionsQueue.Dequeue();
				if (!(characterState2 == null) && characterState2.enabled && characterState2.CheckEnterTransition(CurrentState))
				{
					characterState = characterState2;
					this.OnStateChange?.Invoke(CurrentState, characterState);
					PreviousState = CurrentState;
					CurrentState = characterState;
					return true;
				}
			}
			return false;
		}

		private void PostCharacterSimulation(float dt)
		{
			CurrentState?.PostCharacterSimulation(dt);
		}

		private void PreCharacterSimulation(float dt)
		{
			CurrentState?.PreCharacterSimulation(dt);
		}
	}
}
