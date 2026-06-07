using System;
using System.Collections.Generic;
using Dhs5.Utility.Updates;
using UnityEngine;
using UnityEngine.AI;

namespace Simulator.GameWorld
{
	public abstract class AIBehaviour : MonoBehaviour, IStandUser
	{
		[Header("Controller")]
		[SerializeField]
		private AIController m_controller;

		[Header("Movement")]
		[SerializeField]
		protected NavMeshAgent m_navAgent;

		[Header("Character")]
		[SerializeField]
		[ReadOnly(false, false)]
		private AICharacter m_character;

		[Header("State")]
		[SerializeField]
		[ReadOnly(false, false)]
		private EAIBehaviourState m_state;

		[SerializeField]
		[ReadOnly(false, false)]
		private Stand m_currentStand;

		[SerializeField]
		[ReadOnly(false, false)]
		private AIStandSituation m_standSituation;

		private bool m_shouldWalk;

		private List<bool> m_shouldWalkSamples = new List<bool>();

		protected Vector3 m_destination;

		private bool m_destinationHasTargetRotation;

		private Vector3 m_destinationForward;

		private float m_destinationRadius;

		private DelayedCallHandle m_waitHandle;

		protected UpdateTimelineInstanceHandle m_activityHandle;

		public AIController Controller => m_controller;

		public AICharacter Character => m_character;

		public int GameID { get; private set; }

		public EAIBehaviourState State
		{
			get
			{
				return m_state;
			}
			protected set
			{
				if (m_state != value)
				{
					SetState(value);
				}
			}
		}

		public Stand CurrentStand
		{
			get
			{
				return m_currentStand;
			}
			private set
			{
				m_currentStand = value;
				if (value == null)
				{
					m_standSituation = new AIStandSituation(null);
				}
			}
		}

		public AIStandSituation StandSituation => m_standSituation;

		protected NavMeshAgent NavAgent => m_navAgent;

		public NavigationPoint Destination
		{
			set
			{
				SetDestination(value.Position, value.Forward, value.Radius, value.EnsureRotation);
			}
		}

		public bool HasEnteredDestination { get; private set; }

		public bool IsAtDestination { get; private set; }

		public event Action<IStandUser> ArrivedAtStand;

		public event Action<IStandUser, bool> QuittedStand;

		protected virtual void OnEnable()
		{
			Updater.RegisterChannelCallback(register: true, EUpdateChannel.MOVEMENT, OnMovementUpdate);
		}

		protected virtual void OnDisable()
		{
			Updater.RegisterChannelCallback(register: false, EUpdateChannel.MOVEMENT, OnMovementUpdate);
			KillWait();
			KillActivityTimeline();
		}

		public virtual void Init(int id)
		{
			GameID = id;
		}

		public virtual void Load(int phase, AISaveState state)
		{
			if (phase == 1)
			{
				GameID = state.gameID;
				NavAgent.velocity = state.agentVelocity;
				State = state.state;
				SetDestination(state.destination, state.destinationForward, state.destinationRadius, state.destinationHasTargetRotation);
				HasEnteredDestination = state.hasEnteredDestination;
				IsAtDestination = state.isAtDestination;
				if (state.waitTimerValue > 0f)
				{
					WaitFor(state.waitTimerValue, state.state);
				}
				if (state.activityTimelineTimeLeft > 0f)
				{
					DoActivityFor(state.activityTimelineTimeLeft, state.state);
				}
				m_standSituation = state.standSituation;
			}
			else if (m_standSituation.standID.x > 0)
			{
				if (World.Shop.TryGetStandByID(m_standSituation.standID, out var stand))
				{
					CurrentStand = stand;
					OnLoadCurrentStand(stand);
					CurrentStand.Activated += OnCurrentStandActivated;
					CurrentStand.AccessViaSituation(this, m_standSituation);
				}
				else
				{
					Vector2Int standID = m_standSituation.standID;
					Debug.LogError("Couldn't find current stand with id " + standID.ToString());
				}
			}
		}

		public virtual void InitPostLoad()
		{
		}

		protected virtual void OnLoadCurrentStand(Stand stand)
		{
		}

		public Vector3 GetNavAgentState()
		{
			if (!(NavAgent == null))
			{
				return NavAgent.velocity;
			}
			return Vector3.zero;
		}

		protected virtual void OnMovementUpdate(float deltaTime)
		{
			if (ShouldSynchronizeCharacterToAgent())
			{
				SynchronizeCharacterToAgent();
			}
			UpdateCharacterWalkAnimation();
			if (m_state != EAIBehaviourState.WALKING)
			{
				return;
			}
			if (!HasEnteredDestination)
			{
				if (IsInDestinationRange())
				{
					OnEntersDestination();
				}
			}
			else if (IsStoppedAtDestination())
			{
				if (HasAccessToDestination())
				{
					OnStopAtDestination();
				}
				else
				{
					OnBlockedFromDestination();
				}
			}
		}

		protected virtual bool ShouldSynchronizeCharacterToAgent()
		{
			if (NavAgent.transform.position != Character.Position)
			{
				return true;
			}
			if (m_destinationHasTargetRotation)
			{
				return Character.Forward != m_destinationForward;
			}
			return NavAgent.transform.rotation != Character.Rotation;
		}

		protected virtual void SynchronizeCharacterToAgent()
		{
			if (Controller.InputReceiver != null)
			{
				Controller.InputReceiver.OnAIInput_Move(NavAgent.transform.position);
				if (m_destinationHasTargetRotation && HasEnteredDestination)
				{
					Controller.InputReceiver.OnAIInput_Look(Vector3.Slerp(Character.Forward, m_destinationForward, 0.1f));
				}
				else
				{
					Controller.InputReceiver.OnAIInput_Look(NavAgent.transform.forward);
				}
			}
		}

		protected virtual void UpdateCharacterWalkAnimation()
		{
			m_shouldWalkSamples.Add(NavAgent.desiredVelocity.magnitude > AIModelSettings.MinimumWalkVelocity);
			if (m_shouldWalkSamples.Count > AIModelSettings.ShouldWalkSamplesCount)
			{
				m_shouldWalkSamples.RemoveAt(0);
			}
			for (int i = 0; i < m_shouldWalkSamples.Count && m_shouldWalkSamples[i] != m_shouldWalk; i++)
			{
				if (i == m_shouldWalkSamples.Count - 1)
				{
					m_shouldWalk = !m_shouldWalk;
				}
			}
			if (Controller.InputReceiver != null)
			{
				Controller.InputReceiver.OnAIInput_IsWalking(m_shouldWalk);
			}
		}

		protected void ForceWalk(bool walk)
		{
			m_shouldWalkSamples.Clear();
			m_shouldWalk = walk;
			if (Controller.InputReceiver != null)
			{
				Controller.InputReceiver.OnAIInput_IsWalking(m_shouldWalk);
			}
		}

		public (Vector3 destination, Vector3 forward, float radius, bool hasTargetRotation) GetDestination()
		{
			return (destination: m_destination, forward: m_destinationForward, radius: m_destinationRadius, hasTargetRotation: m_destinationHasTargetRotation);
		}

		private void SetDestination(Vector3 position, Vector3 forward, float radius, bool ensureRotation)
		{
			if (m_destination != position)
			{
				if (m_navAgent.SetDestination(position))
				{
					m_destination = position;
					m_destinationForward = forward;
					m_destinationRadius = radius;
					m_destinationHasTargetRotation = ensureRotation;
					m_navAgent.stoppingDistance = m_destinationRadius;
					HasEnteredDestination = false;
					IsAtDestination = false;
				}
			}
			else
			{
				HasEnteredDestination = false;
				IsAtDestination = false;
			}
		}

		protected virtual bool IsInDestinationRange()
		{
			if (!m_navAgent.pathPending)
			{
				return m_navAgent.remainingDistance < m_destinationRadius;
			}
			return false;
		}

		protected virtual void OnEntersDestination()
		{
			HasEnteredDestination = true;
		}

		protected virtual bool IsStoppedAtDestination()
		{
			if (m_navAgent.remainingDistance < m_destinationRadius)
			{
				return m_navAgent.desiredVelocity.sqrMagnitude < 0.1f;
			}
			return false;
		}

		protected virtual bool HasAccessToDestination()
		{
			if (m_navAgent.pathStatus == NavMeshPathStatus.PathComplete)
			{
				return Vector3.Distance(m_destination, m_navAgent.pathEndPosition) < 0.1f;
			}
			return false;
		}

		protected virtual void OnStopAtDestination()
		{
			IsAtDestination = true;
		}

		protected virtual void OnBlockedFromDestination()
		{
		}

		private void SetState(EAIBehaviourState state)
		{
			OnQuitState(m_state);
			m_state = state;
			OnEnterState(m_state);
		}

		protected virtual void OnQuitState(EAIBehaviourState state)
		{
			if (state == EAIBehaviourState.WALKING)
			{
				SynchronizeCharacterToAgent();
			}
		}

		protected virtual void OnEnterState(EAIBehaviourState state)
		{
			switch (state)
			{
			case EAIBehaviourState.WALKING:
				m_navAgent.isStopped = false;
				UpdateCharacterWalkAnimation();
				break;
			case EAIBehaviourState.WAITING:
				m_navAgent.isStopped = true;
				UpdateCharacterWalkAnimation();
				break;
			case EAIBehaviourState.ACTIVE:
				m_navAgent.isStopped = true;
				UpdateCharacterWalkAnimation();
				break;
			case EAIBehaviourState.WAITING_IN_LINE:
				m_navAgent.isStopped = true;
				UpdateCharacterWalkAnimation();
				break;
			}
		}

		public float GetWaitTimeLeft()
		{
			if (m_waitHandle.IsValid())
			{
				return m_waitHandle.GetTimeLeft();
			}
			return -1f;
		}

		protected void KillWait()
		{
			m_waitHandle.Kill();
		}

		protected void WaitFor(float seconds, EAIBehaviourState waitingState = EAIBehaviourState.WAITING)
		{
			State = waitingState;
			Updater.CallInXSeconds(seconds, OnFinishedWaiting, out m_waitHandle);
		}

		protected virtual void OnFinishedWaiting()
		{
		}

		protected void KillActivityTimeline()
		{
			Updater.KillTimelineInstance(m_activityHandle);
		}

		public float GetActivityTimelineTimeLeft()
		{
			if (m_activityHandle.IsActive)
			{
				return m_activityHandle.Duration - m_activityHandle.Time;
			}
			return -1f;
		}

		protected void DoActivityFor(float seconds, EAIBehaviourState activityState = EAIBehaviourState.ACTIVE)
		{
			State = activityState;
			if (Updater.CreateTimelineInstance(EUpdateChannel.AI, seconds, out m_activityHandle))
			{
				m_activityHandle.Updated += OnActivityTimelineUpdated;
				m_activityHandle.EventTriggered += OnActivityTimelineEvent;
				m_activityHandle.Play();
			}
		}

		protected virtual void OnActivityTimelineEvent(EUpdateTimelineEventType type, ushort uid)
		{
			if (!(this == null) && type == EUpdateTimelineEventType.END)
			{
				OnActivityCompleted();
			}
		}

		protected virtual void OnActivityTimelineUpdated(float deltaTime)
		{
		}

		protected virtual void OnActivityCompleted()
		{
		}

		public virtual void OnAccessStand(Stand stand, NavigationPoint destination, int placeIndex)
		{
			if (stand != CurrentStand)
			{
				Debug.LogError(base.gameObject.name + " tries to access wrong stand : " + CurrentStand?.ToString() + " > " + stand);
				CurrentStand.Activated -= OnCurrentStandActivated;
				CurrentStand = stand;
				CurrentStand.Activated += OnCurrentStandActivated;
			}
			m_standSituation = new AIStandSituation(stand, hasAccess: true, placeIndex);
		}

		public virtual void OnWaitInStandLine(Stand stand, NavigationPoint navigationPoint, int queueIndex)
		{
			m_standSituation = new AIStandSituation(stand, hasAccess: false, queueIndex);
		}

		public virtual void OnAskedToQuitStand(Stand stand, bool completed)
		{
			if (completed)
			{
				CompleteCurrentStand();
			}
			else
			{
				QuitCurrentStandWithoutComplete();
			}
		}

		protected void AccessStand(Stand stand)
		{
			if (!(CurrentStand == stand))
			{
				if (CurrentStand != null)
				{
					QuitCurrentStandWithoutCallback();
				}
				CurrentStand = stand;
				CurrentStand.Access(this);
				CurrentStand.Activated += OnCurrentStandActivated;
			}
		}

		protected void ArriveAtStand()
		{
			this.ArrivedAtStand?.Invoke(this);
			OnArriveAtStand(CurrentStand);
		}

		protected virtual void OnArriveAtStand(Stand stand)
		{
		}

		protected void CompleteCurrentStand()
		{
			CurrentStand.Activated -= OnCurrentStandActivated;
			this.QuittedStand?.Invoke(this, arg2: true);
			Stand currentStand = CurrentStand;
			CurrentStand = null;
			OnQuitStand(currentStand, completed: true);
		}

		protected virtual void OnCurrentStandActivated(bool active)
		{
		}

		protected void QuitCurrentStandWithoutComplete()
		{
			KillActivityTimeline();
			CurrentStand.Activated -= OnCurrentStandActivated;
			this.QuittedStand?.Invoke(this, arg2: false);
			Stand currentStand = CurrentStand;
			CurrentStand = null;
			OnQuitStand(currentStand, completed: false);
		}

		protected void QuitCurrentStandWithoutCallback()
		{
			KillActivityTimeline();
			CurrentStand.Activated -= OnCurrentStandActivated;
			this.QuittedStand?.Invoke(this, arg2: false);
			CurrentStand = null;
		}

		protected virtual void OnQuitStand(Stand stand, bool completed)
		{
		}

		public abstract bool TakeControlOfCharacter(AICharacter character);

		protected bool OnTakeControlOfCharacter(AICharacter character)
		{
			if (character == null)
			{
				return false;
			}
			m_character = character;
			return Controller.TakeControl(Character);
		}
	}
}
