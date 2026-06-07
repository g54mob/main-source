using System;
using System.Collections.Generic;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Lightbug.CharacterControllerPro.Implementation
{
	[AddComponentMenu("Character Controller Pro/Implementation/Character/Character State Controller")]
	public class CharacterStateController : MonoBehaviour
	{
		[Tooltip("The state used to start the state machine. It is necessary for the state to be not-null, active and enabled. Otherwise, the state machine will not run.")]
		[FormerlySerializedAs("currentState")]
		public CharacterState initialState;

		[CustomClassDrawer]
		[SerializeField]
		private MovementReferenceParameters movementReferenceParameters = new MovementReferenceParameters();

		private readonly Dictionary<string, CharacterState> states = new Dictionary<string, CharacterState>();

		private Queue<CharacterState> transitionsQueue = new Queue<CharacterState>();

		private bool machineStarted;

		public MovementReferenceParameters MovementReferenceParameters => movementReferenceParameters;

		public Animator Animator { get; private set; }

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

		public CharacterActor CharacterActor { get; private set; }

		public CharacterBrain CharacterBrain { get; private set; }

		public CharacterState CurrentState { get; protected set; }

		public CharacterState PreviousState { get; protected set; }

		public Vector3 InputMovementReference => movementReferenceParameters.InputMovementReference;

		public Transform ExternalReference
		{
			get
			{
				return movementReferenceParameters.externalReference;
			}
			set
			{
				movementReferenceParameters.externalReference = value;
			}
		}

		public MovementReferenceParameters.MovementReferenceMode MovementReferenceMode
		{
			get
			{
				return movementReferenceParameters.movementReferenceMode;
			}
			set
			{
				movementReferenceParameters.movementReferenceMode = value;
			}
		}

		public Vector3 MovementReferenceForward => movementReferenceParameters.MovementReferenceForward;

		public Vector3 MovementReferenceRight => movementReferenceParameters.MovementReferenceRight;

		private bool CanCurrentStateOverrideAnimatorController
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

		public event Action<CharacterState, CharacterState> OnStateChange;

		public CharacterState GetState(string stateName)
		{
			states.TryGetValue(stateName, out var value);
			return value;
		}

		public CharacterState GetState<T>() where T : CharacterState
		{
			string stateName = typeof(T).Name;
			return GetState(stateName);
		}

		public void EnqueueTransition<T>() where T : CharacterState
		{
			CharacterState state = GetState<T>();
			if (!(state == null))
			{
				transitionsQueue.Enqueue(state);
			}
		}

		public void EnqueueTransition(CharacterState state)
		{
			if (!(state == null))
			{
				transitionsQueue.Enqueue(state);
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
					states.Add(text, characterState);
				}
			}
		}

		public void ResetIKWeights()
		{
			CharacterActor.ResetIKWeights();
		}

		private void PreCharacterSimulation(float dt)
		{
			CurrentState.PreCharacterSimulation(dt);
		}

		private void PostCharacterSimulation(float dt)
		{
			CurrentState.PostCharacterSimulation(dt);
		}

		private bool CheckForTransitions()
		{
			CurrentState.CheckExitTransition();
			CharacterState characterState = null;
			while (transitionsQueue.Count != 0)
			{
				CharacterState characterState2 = transitionsQueue.Dequeue();
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

		private void Awake()
		{
			CharacterActor = this.GetComponentInBranch<CharacterActor>();
			Animator = CharacterActor.GetComponentInChildren<Animator>();
			CharacterBrain = this.GetComponentInBranch<CharacterActor, CharacterBrain>();
			AddStates();
		}

		private void OnEnable()
		{
			CharacterActor.OnPreSimulation += PreCharacterSimulation;
			CharacterActor.OnPostSimulation += PostCharacterSimulation;
			if (Animator != null)
			{
				CharacterActor.OnAnimatorIKEvent += OnAnimatorIK;
			}
		}

		private void OnDisable()
		{
			CharacterActor.OnPreSimulation -= PreCharacterSimulation;
			CharacterActor.OnPostSimulation -= PostCharacterSimulation;
			if (Animator != null)
			{
				CharacterActor.OnAnimatorIKEvent -= OnAnimatorIK;
			}
		}

		private void Start()
		{
			movementReferenceParameters.Initialize(CharacterActor);
		}

		private void FixedUpdate()
		{
			if (!machineStarted)
			{
				if (initialState == null)
				{
					base.enabled = false;
					return;
				}
				CurrentState = initialState;
				if (CharacterActor == null || CurrentState == null || !CurrentState.isActiveAndEnabled)
				{
					return;
				}
				machineStarted = true;
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
			movementReferenceParameters.UpdateData(CharacterBrain.CharacterActions.movement.value);
			if (!machineStarted)
			{
				CurrentState.EnterBehaviour(0f, CurrentState);
				machineStarted = true;
			}
			bool num = CheckForTransitions();
			transitionsQueue.Clear();
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

		private void OnAnimatorIK(int layerIndex)
		{
			if (!(CurrentState == null))
			{
				CurrentState.UpdateIK(layerIndex);
			}
		}
	}
}
