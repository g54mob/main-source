using System.Collections;
using System.Collections.Generic;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace MalbersAnimations.Controller.AI
{
	[AddComponentMenu("Malbers/Animal Controller/AI/AI Control")]
	public class MAnimalAIControl : MonoBehaviour, IAIControl, IAnimatorListener
	{
		[SerializeField]
		private NavMeshAgent agent;

		[RequiredField]
		public MAnimal animal;

		[Tooltip("On AI Enable. Disable the Input Source. Input source conflict with the AI source (Both will try to control the Animal Controller and it may cause unwanted issues ")]
		public bool DisableInputAIOn = true;

		[Tooltip("On AI Disable. Enable the Input Source. Input source conflict with the AI source (Both will try to control the Animal Controller and it may cause unwanted issues ")]
		public bool EnableInputAIOff = true;

		protected Vector3 TargetLastPosition;

		private IEnumerator I_WaitToNextTarget;

		private IEnumerator IFreeMoveOffMesh;

		private IEnumerator IMoveOffMeshLink;

		private IEnumerator IClimbOffMesh;

		[Tooltip("When the animal is on any of these States, The AI agent will be disable to improve performance.")]
		[ContextMenuItem("Set Default", "SetDefaulStopAgent")]
		public List<StateID> StopAgentOn;

		[Tooltip("Multiplier used for Waypoints Wait time. Set it to zero if you want to ignore waiting on waypoints")]
		[Min(0f)]
		[SerializeField]
		private float waitTimeMult = 1f;

		[Min(0f)]
		public float UpdateAI = 0.2f;

		private float CurrentTime;

		[Tooltip("Default Stopping Distance used by the AI Control. This value will be ignored if the Target has the [AI Target] component attached")]
		[Min(0f)]
		[SerializeField]
		protected float stoppingDistance = 0.6f;

		[Min(0f)]
		[SerializeField]
		protected float PointStoppingDistance = 0.6f;

		[Tooltip("Local Additive Stopping distance added to the current Stop Distance")]
		[Min(0f)]
		[SerializeField]
		protected float additiveStopDistance;

		[SerializeField]
		[Tooltip("Default Slowing Distance used by the AI Control. Once the Animal arrive to this destination it will start slowing its current speed.")]
		[Min(0f)]
		protected float slowingDistance = 1f;

		[Tooltip("If the AI Animal is scaled, use the scale factor to find the Target")]
		public bool UseScale = true;

		[Tooltip("If the AI Animal was assigned a new target, the current playing mode will be interrupted")]
		public bool InterruptModeOnTarget = true;

		[Tooltip("It will clear the Target if the component is disabled")]
		public bool ClearTargetOnDisable = true;

		[Tooltip("How high a target can be from the terrain so the Animal can follow  it")]
		[SerializeField]
		[Min(0f)]
		private float targetHeight = 5f;

		[Tooltip("The Animal will stop if the target is too high to reach")]
		public bool StopOnTargetTooHigh = true;

		[Tooltip("Distance from the Animals Root to apply LookAt Target Logic when the Animal arrives to a target.")]
		[Min(0f)]
		public float LookAtOffset = 1f;

		[Tooltip("Limit for the Slowing Multiplier to be applied to the Speed Modifier")]
		[Range(0f, 1f)]
		[SerializeField]
		private float slowingLimit = 0.3f;

		[SerializeField]
		private Transform target;

		[SerializeField]
		private Transform nextTarget;

		public bool debug;

		public bool debugGizmos = true;

		public bool debugStatus = true;

		[Space]
		public Vector3Event OnTargetPositionArrived = new Vector3Event();

		public TransformEvent OnTargetArrived = new TransformEvent();

		public TransformEvent OnTargetSet = new TransformEvent();

		public UnityEvent OnEnabled = new UnityEvent();

		public UnityEvent OnDisabled = new UnityEvent();

		[Tooltip("What State to play when the next WayPoint is a FreeMovement (Air Waypoint)")]
		public StateID AirDestinationState;

		private bool isWaitingOnTarget;

		private bool hasArrived;

		protected float currentStoppingDistance;

		private float currentSlowingDistance;

		public Transform AgentTransform;

		protected Vector3 AgentPosition;

		public IInteractor Interactor { get; internal set; }

		public bool AIReady { get; internal set; }

		public bool ArriveLookAt => false;

		public virtual bool Active
		{
			get
			{
				if (base.enabled)
				{
					return base.gameObject.activeInHierarchy;
				}
				return false;
			}
		}

		public virtual float RemainingDistance { get; set; }

		public virtual bool IsMoving { get; set; }

		public virtual float AgentRemainingDistance => Agent.remainingDistance;

		public virtual float MinRemainingDistance { get; set; }

		public float SlowMultiplier
		{
			get
			{
				float result = 1f;
				if (CurrentSlowingDistance > CurrentStoppingDistance && RemainingDistance < CurrentSlowingDistance)
				{
					result = Mathf.Max(RemainingDistance / CurrentSlowingDistance, slowingLimit);
				}
				return result;
			}
		}

		public Transform Transform { get; internal set; }

		public Vector3 AIDirection { get; set; }

		public bool InOffMeshLink { get; set; }

		public virtual bool AgentInOffMeshLink => Agent.isOnOffMeshLink;

		public virtual Vector3 AgentNextCorner => agent.path.corners[0];

		public bool StateIsBlockingAgent { get; set; }

		public virtual bool ActiveAgent
		{
			get
			{
				if (agent.enabled)
				{
					return agent.isOnNavMesh;
				}
				return false;
			}
			set
			{
				agent.enabled = value;
				if (agent.isOnNavMesh)
				{
					agent.isStopped = !value;
				}
			}
		}

		public virtual bool CanFly { get; private set; }

		public virtual bool UpdateDestinationPosition { get; set; }

		public virtual Vector3 DestinationPosition { get; set; }

		public bool AutoNextTarget { get; set; }

		public bool LookAtTargetOnArrival { get; set; }

		public TransformEvent TargetSet => OnTargetSet;

		public TransformEvent OnArrived => OnTargetArrived;

		public bool FreeMove { get; set; }

		public int Index { get; set; }

		public virtual float Height => targetHeight * animal.ScaleFactor;

		public virtual bool TargetTooHigh { get; set; }

		public virtual float StoppingDistance
		{
			get
			{
				return stoppingDistance;
			}
			set
			{
				stoppingDistance = value;
			}
		}

		public virtual float AdditiveStopDistance
		{
			get
			{
				return additiveStopDistance;
			}
			set
			{
				additiveStopDistance = value;
			}
		}

		public virtual Vector3 AgentDesiredVelocity => Agent.desiredVelocity;

		public bool IsWaitingOnTarget
		{
			get
			{
				return isWaitingOnTarget;
			}
			set
			{
				isWaitingOnTarget = value;
			}
		}

		public bool HasArrived
		{
			get
			{
				return hasArrived;
			}
			set
			{
				hasArrived = value;
			}
		}

		public virtual float CurrentStoppingDistance
		{
			get
			{
				return currentStoppingDistance * (UseScale ? animal.ScaleFactor : 1f) + additiveStopDistance;
			}
			set
			{
				Agent.stoppingDistance = (currentStoppingDistance = value);
			}
		}

		public virtual float SlowingDistance => slowingDistance;

		public virtual float CurrentSlowingDistance
		{
			get
			{
				return currentSlowingDistance + additiveStopDistance;
			}
			set
			{
				currentSlowingDistance = value;
			}
		}

		public bool IsOnMode => animal.IsPlayingMode;

		private bool IsOnNonMovingMode
		{
			get
			{
				if (IsOnMode)
				{
					return !animal.ActiveMode.AllowMovement;
				}
				return false;
			}
		}

		public IWayPoint IsWayPoint { get; set; }

		public IAITarget IsAITarget { get; set; }

		public IAITargeterTarget ITargeter { get; set; }

		public IInteractable IsTargetInteractable { get; protected set; }

		internal bool IsAirDestination
		{
			get
			{
				if (IsAITarget != null)
				{
					return IsAITarget.TargetType == WayPointType.Air;
				}
				return false;
			}
		}

		internal bool IsGroundDestination
		{
			get
			{
				if (IsAITarget != null)
				{
					return IsAITarget.TargetType == WayPointType.Ground;
				}
				return false;
			}
		}

		public virtual NavMeshAgent Agent => agent;

		public Transform Owner => animal.transform;

		public virtual WayPointType TargetType
		{
			get
			{
				if (!animal.FreeMovement)
				{
					return WayPointType.Ground;
				}
				return WayPointType.Air;
			}
		}

		public virtual bool TargetIsMoving { get; internal set; }

		public virtual bool IsWaiting { get; internal set; }

		public virtual Vector3 LastOffMeshDestination { get; set; }

		public virtual Vector3 EndOffMeshPos { get; set; }

		public Vector3 NullVector { get; set; }

		public virtual Transform NextTarget
		{
			get
			{
				return nextTarget;
			}
			set
			{
				nextTarget = value;
			}
		}

		public virtual Transform Target
		{
			get
			{
				return target;
			}
			set
			{
				target = value;
			}
		}

		public float WaitTimeMult
		{
			get
			{
				return waitTimeMult;
			}
			set
			{
				waitTimeMult = value;
			}
		}

		public bool TargeterOn
		{
			get
			{
				if (ITargeter != null)
				{
					return ITargeter.Targeters > 0;
				}
				return false;
			}
		}

		Transform IAnimatorListener.transform => base.transform;

		public virtual Vector3 GetCenterPosition()
		{
			return AgentTransform.position;
		}

		public Vector3 GetCenterY()
		{
			return animal.Center;
		}

		public virtual void SetActive(bool value)
		{
			if (base.gameObject.activeInHierarchy)
			{
				base.enabled = value;
			}
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			return this.InvokeWithParams(message, value);
		}

		protected virtual void Awake()
		{
			if (animal == null)
			{
				animal = base.gameObject.FindComponent<MAnimal>();
			}
			ValidateAgent();
			Transform = base.transform;
			Interactor = animal.FindInterface<IInteractor>();
			animal.UseSmoothVertical = true;
			LookAtTargetOnArrival = true;
			AutoNextTarget = true;
			UpdateDestinationPosition = true;
			NullVector = new Vector3(-998.9999f, -998.9999f, -998.9999f);
			DestinationPosition = NullVector;
			CanFly = animal.HasState(StateEnum.Fly);
			SetAgent();
		}

		protected virtual void SetAgent()
		{
			if (agent == null)
			{
				AgentTransform.GetComponent<NavMeshAgent>();
			}
			if ((bool)agent)
			{
				AgentPosition = Agent.transform.localPosition;
				Agent.angularSpeed = 0f;
				Agent.speed = 1f;
				Agent.acceleration = 0f;
				Agent.autoBraking = false;
				Agent.updateRotation = false;
				Agent.updatePosition = false;
				Agent.autoTraverseOffMeshLink = false;
				Agent.stoppingDistance = StoppingDistance;
			}
		}

		protected virtual void OnEnable()
		{
			animal.OnStateActivate.AddListener(OnState);
			animal.OnModeStart.AddListener(OnModeStart);
			animal.OnModeEnd.AddListener(OnModeEnd);
			animal.OnTeleport.AddListener(OnTeleport);
			IsWaiting = true;
			FreeMove = false;
			AIReady = false;
			if ((bool)animal.ActiveState)
			{
				FreeMove = animal.ActiveState.General.FreeMovement;
			}
			if (FreeMove)
			{
				ActiveAgent = false;
			}
			if ((bool)Agent && !Agent.isOnNavMesh)
			{
				ActiveAgent = false;
			}
			HasArrived = false;
			TargetIsMoving = false;
			IsWaitingOnTarget = false;
			this.Delay_Action(StartAI);
			if (animal.InputSource != null && DisableInputAIOn)
			{
				animal.InputSource.Enable(val: false);
				Debuging("Input Move Disabled");
			}
			OnEnabled.Invoke();
		}

		protected virtual void OnDisable()
		{
			animal.OnStateActivate.RemoveListener(OnState);
			animal.OnModeStart.RemoveListener(OnModeStart);
			animal.OnModeEnd.RemoveListener(OnModeEnd);
			animal.OnTeleport.RemoveListener(OnTeleport);
			Stop();
			StopAllCoroutines();
			OnDisabled.Invoke();
			animal.Rotate_at_Direction = false;
			AIReady = false;
			if (animal.InputSource != null && EnableInputAIOff)
			{
				animal.InputSource.Enable(val: true);
				animal.Reset_Movement();
				Debuging("Input Move Enabled");
			}
			if (ClearTargetOnDisable)
			{
				ClearTarget();
			}
		}

		private void OnTeleport(Vector3 arg0)
		{
			ActiveAgent = false;
			ActiveAgent = true;
			CalculatePath();
			Move();
			CompleteOffMeshLink();
			CheckAirTarget();
		}

		private void OnDestroy()
		{
			ITargeter?.TargetersRefresh.RemoveListener(Destination_RefreshTarget);
		}

		protected virtual void Update()
		{
			Updating();
		}

		public virtual void OnModeStart(int ModeID, int ability)
		{
			Debuging("has started a Mode: <B>[" + animal.ActiveMode.ID.name + "]</B>. Ability: <B>[" + animal.ActiveMode.ActiveAbility.Name + "]</B>");
			if (!animal.ActiveMode.AllowMovement)
			{
				animal.InertiaPositionSpeed = Vector3.zero;
				animal.StopMoving();
				animal.MovementAxisSmoothed = Vector3.zero;
				Vector3 destinationPosition = DestinationPosition;
				Stop();
				DestinationPosition = destinationPosition;
			}
		}

		public virtual void OnModeEnd(int ModeID, int ability)
		{
			if (!StateIsBlockingAgent)
			{
				Debuging($"Mode End: <B>[{ModeID}]</B>. Ability: <B>[{ability}]</B>");
				if (!ActiveAgent)
				{
					CalculatePath();
					Move();
				}
				CompleteOffMeshLink();
				CheckAirTarget();
			}
		}

		public virtual void OnState(int stateID)
		{
			if (IsWaiting)
			{
				return;
			}
			FreeMove = animal.ActiveState.General.FreeMovement;
			if (CheckAirTarget())
			{
				return;
			}
			StateIsBlockingAgent = StopAgentOn != null && StopAgentOn.Contains(animal.ActiveStateID);
			if (HasArrived)
			{
				return;
			}
			if (StateIsBlockingAgent)
			{
				if ((bool)Agent && Agent.isOnNavMesh)
				{
					Agent.ResetPath();
				}
				ActiveAgent = false;
				return;
			}
			if (!IsOnNonMovingMode && !ActiveAgent)
			{
				CalculatePath();
				Move();
			}
			CompleteOffMeshLink();
		}

		public virtual void StartAI()
		{
			Transform transform = target;
			target = null;
			SetTarget(transform);
			if (AgentTransform == animal.transform)
			{
				Debug.LogWarning("The Nav Mesh Agent needs to be attached to a child Gameobject, not in the same gameObject as the Animal Component");
			}
			AIReady = true;
		}

		public virtual void Updating()
		{
			ResetAgentPosition();
			if (IsWaiting || InOffMeshLink)
			{
				return;
			}
			CheckMovingTarget();
			if (FreeMove)
			{
				if (IsAirDestination && animal.ActiveStateID.ID != StateEnum.Fly)
				{
					animal.State_Activate(StateEnum.Fly);
					Debuging("Force! Flying!");
				}
				FreeMovement();
			}
			else
			{
				UpdateAgent();
			}
		}

		protected virtual void ResetAgentPosition()
		{
			AgentTransform.localPosition = AgentPosition;
			Agent.nextPosition = Agent.transform.position;
		}

		public virtual bool PathPending()
		{
			if (ActiveAgent && Agent.isOnNavMesh)
			{
				return Agent.pathPending;
			}
			return false;
		}

		public virtual void UpdateAgent()
		{
			if (HasArrived)
			{
				LookTargetOnArrival();
			}
			else
			{
				if (!ActiveAgent)
				{
					return;
				}
				if (PathPending())
				{
					animal.StopMoving();
					return;
				}
				SetRemainingDistance(AgentRemainingDistance);
				if (!Arrive_Destination() && !CheckOffMeshLinks())
				{
					if (IsPathIncomplete())
					{
						AIDirection = Vector3.zero;
						CalculatePath();
					}
					else
					{
						NormalizeDirection();
						Move();
					}
				}
			}
		}

		private void LookTargetOnArrival()
		{
			if (LookAtTargetOnArrival && LookAtOffset > 0f)
			{
				if (DestinationPosition == NullVector)
				{
					DestinationPosition = ((target != null) ? target.position : (base.transform.position + base.transform.forward));
				}
				Vector3 vector = animal.Position - animal.ScaleFactor * LookAtOffset * animal.Forward;
				Vector3 vector2 = ((target != null) ? target.position : DestinationPosition) - vector;
				if (debugGizmos)
				{
					MDebug.Draw_Arrow(vector, vector2, Color.magenta);
					MDebug.DrawWireSphere(vector, Color.magenta, 0.1f);
				}
				if (Vector3.Angle(vector2, animal.Forward) > 2f)
				{
					animal.RotateAtDirection(vector2);
				}
				else
				{
					animal.StopMoving();
				}
			}
		}

		protected virtual bool IsPathIncomplete()
		{
			if (ActiveAgent && !FreeMove)
			{
				return Agent.pathStatus == NavMeshPathStatus.PathInvalid;
			}
			return false;
		}

		protected virtual bool DestinationTooHigh()
		{
			TargetTooHigh = false;
			if (FreeMove)
			{
				return true;
			}
			if (targetHeight == 0f)
			{
				return true;
			}
			if (NavMesh.SamplePosition(DestinationPosition, out var hit, Height, -1))
			{
				if (debugGizmos)
				{
					MDebug.DrawWireSphere(hit.position, Color.cyan, 0.1f, UpdateAI);
					Debug.DrawRay(hit.position, animal.UpVector * Height, Color.cyan, UpdateAI);
				}
				DestinationPosition = hit.position;
				return true;
			}
			TargetTooHigh = true;
			Debuging($"<color=orange>Target too High!: <B>{DestinationPosition}</B>.  Stopping</color>");
			return TargetTooHigh;
		}

		public virtual void CheckMovingTarget()
		{
			if (UpdateAI != 0f && !MTools.ElapsedTime(CurrentTime, UpdateAI))
			{
				return;
			}
			if ((bool)Target && IsWayPoint == null)
			{
				TargetIsMoving = (Target.position - TargetLastPosition).sqrMagnitude > 0.0001f;
				TargetLastPosition = Target.position;
				if (TargetIsMoving)
				{
					Update_DestinationPosition();
				}
			}
			CurrentTime = Time.time;
		}

		public virtual void CalculatePath()
		{
			if (FreeMove)
			{
				return;
			}
			if (!ActiveAgent)
			{
				ActiveAgent = true;
				ResetFreeMoveOffMesh();
			}
			if (Agent.isOnNavMesh)
			{
				Agent.SetDestination(DestinationPosition);
				if (IsWayPoint != null)
				{
					DestinationPosition = Agent.destination;
				}
				NormalizeDirection();
				HasArrived = false;
			}
			Debuging($"<color=green>Calculate Path to: <B>{DestinationPosition}</B></color>");
		}

		private void NormalizeDirection()
		{
			if (AgentDesiredVelocity != Vector3.zero)
			{
				AIDirection = AgentDesiredVelocity.normalized;
			}
		}

		public virtual void Move()
		{
			IsMoving = AIDirection != Vector3.zero;
			animal.Move(AIDirection * SlowMultiplier);
		}

		public virtual void Stop()
		{
			ActiveAgent = false;
			AIDirection = Vector3.zero;
			DestinationPosition = NullVector;
			animal.StopMoving();
			InOffMeshLink = false;
			Debuging("[Stopped]. Agent Disabled");
			IsMoving = false;
		}

		protected virtual void Update_DestinationPosition()
		{
			if (!UpdateDestinationPosition)
			{
				return;
			}
			DestinationPosition = GetTargetPosition();
			DestinationTooHigh();
			if (TargetTooHigh && StopOnTargetTooHigh)
			{
				Stop();
				return;
			}
			float num = Vector3.Distance(DestinationPosition, AgentTransform.position);
			if (IsWaitingOnTarget)
			{
				if (num >= ITargeter.WaitTargeterDistance)
				{
					UpdateStoppingDistanceMultipleTargets();
					HasArrived = false;
					CalculatePath();
					Move();
				}
				else
				{
					Stop();
				}
			}
			else if (num >= CurrentStoppingDistance)
			{
				HasArrived = false;
				CalculatePath();
				Move();
			}
			else
			{
				HasArrived = true;
			}
		}

		protected void Destination_RefreshTarget()
		{
			DestinationPosition = ((IsAITarget != null) ? IsAITarget.GetCenterPosition(Index) : target.position);
			UpdateStoppingDistanceMultipleTargets();
			Update_DestinationPosition();
		}

		private void UpdateStoppingDistanceMultipleTargets()
		{
			CurrentStoppingDistance = (TargeterOn ? ITargeter.GetTargeterStoppingDistance(Index) : CurrentStoppingDistance);
		}

		protected virtual void SetRemainingDistance(float current)
		{
			RemainingDistance = current;
		}

		public virtual bool Arrive_Destination()
		{
			if (InOffMeshLink)
			{
				return false;
			}
			if (TargeterOn)
			{
				if (IsWaitingOnTarget)
				{
					_ = ITargeter.WaitTargeterDistance;
					_ = RemainingDistance;
					return false;
				}
				if (ITargeter.TargeterStopDistance >= RemainingDistance)
				{
					RestoreDefaultAITargetValues();
				}
			}
			if (CurrentStoppingDistance >= RemainingDistance)
			{
				HasArrived = true;
				RemainingDistance = 0f;
				AIDirection = Vector3.zero;
				if (IsPathIncomplete())
				{
					Debuging($"[<color=orange>Agent Path Status: {Agent.pathStatus}]. Force Stop. <B>Checking Next Target </B></color>");
					if (AutoNextTarget)
					{
						MovetoNextTarget();
					}
					else
					{
						Stop();
					}
					return true;
				}
				Move();
				if ((bool)target)
				{
					Debuging($"<color=green>has arrived to: <B>{target.name}</B> → {DestinationPosition} </color>");
					CheckInteractions();
					if (IsAITarget != null)
					{
						IsAITarget.TargetArrived(animal.gameObject);
						LookAtTargetOnArrival = IsAITarget.ArriveLookAt;
						if (IsAITarget.TargetType == WayPointType.Ground)
						{
							FreeMove = false;
						}
						if (AutoNextTarget)
						{
							MovetoNextTarget();
						}
						else
						{
							Stop();
						}
					}
					OnTargetArrived.Invoke(target);
					OnTargetPositionArrived.Invoke(DestinationPosition);
				}
				else
				{
					OnTargetPositionArrived.Invoke(DestinationPosition);
					Debuging($"<color=green>has arrived to: <B>{DestinationPosition}</B>.  Stop</color>");
					Stop();
				}
				return true;
			}
			return false;
		}

		private void RestoreDefaultAITargetValues()
		{
			CurrentStoppingDistance = ITargeter.StopDistance();
			DestinationPosition = ITargeter.GetCenterPosition();
		}

		public virtual void SetTarget(Transform newTarget, bool move)
		{
			if (ITargeter != null && newTarget != target)
			{
				ITargeter.RemoveTargeter(this);
				ITargeter.TargetersRefresh.RemoveListener(Destination_RefreshTarget);
				Index = -1;
				ITargeter = null;
			}
			target = newTarget;
			OnTargetSet.Invoke(newTarget);
			if (target != null)
			{
				TargetLastPosition = newTarget.position;
				DestinationPosition = newTarget.position;
				IAITarget[] targets = newTarget.FindInterfaces<IAITarget>();
				IsAITarget = ClosestTarget(targets);
				if (IsAITarget != null && IsAITarget is IAITargeterTarget iTargeter)
				{
					ITargeter = iTargeter;
					ITargeter.AddTargeter(this);
					ITargeter.TargetersRefresh.AddListener(Destination_RefreshTarget);
				}
				IsTargetInteractable = newTarget.FindInterface<IInteractable>();
				IsWayPoint = newTarget.FindInterface<IWayPoint>();
				NextTarget = null;
				if (IsWayPoint != null)
				{
					NextTarget = IsWayPoint.NextTarget();
				}
				Debuging($"<color=yellow>New Target <B>[{newTarget.name}]</B> → [{DestinationPosition}]. Move = [{move}] IsAiTarget {IsAITarget != null}</color>");
				CheckAirTarget();
				if (move)
				{
					ResetAIValues();
					CurrentStoppingDistance = GetTargetStoppingDistance();
					CurrentSlowingDistance = GetTargetSlowingDistance();
					UpdateStoppingDistanceMultipleTargets();
					DestinationPosition = GetTargetPosition();
					CalculatePath();
					if (InterruptModeOnTarget && animal.IsPlayingMode)
					{
						animal.Mode_Interrupt();
					}
					Move();
					Debuging($"<color=yellow>is travelling to <B>Target: [{newTarget.name}]</B> → [{DestinationPosition}]  Index [{Index}]</color>");
				}
			}
			else
			{
				IsAITarget = null;
				IsTargetInteractable = null;
				IsWayPoint = null;
				Debuging("<color=yellow>Clear Target()</color>");
				if (move)
				{
					Stop();
				}
			}
		}

		public virtual void SetTarget(GameObject target)
		{
			SetTarget(target, move: true);
		}

		public virtual void SetTarget(GameObject target, bool move)
		{
			SetTarget((target != null) ? target.transform : null, move);
		}

		public virtual void ClearTarget()
		{
			SetTarget((Transform)null, false);
		}

		public virtual void NullTarget()
		{
			target = null;
		}

		public virtual void SetTargetOnly(Transform target)
		{
			SetTarget(target, move: false);
		}

		public virtual void SetTargetOnly(GameObject target)
		{
			SetTarget(target, move: false);
		}

		public virtual void SetTarget(Transform target)
		{
			SetTarget(target, move: true);
		}

		public virtual Vector3 GetTargetPosition()
		{
			Vector3 vector = ((IsAITarget != null) ? IsAITarget.GetCenterPosition(Index) : target.position);
			if (vector == Vector3.zero)
			{
				vector = target.position;
			}
			return vector;
		}

		public virtual float GetTargetStoppingDistance()
		{
			if (IsAITarget == null)
			{
				return stoppingDistance * animal.ScaleFactor;
			}
			return IsAITarget.StopDistance();
		}

		public virtual float GetTargetSlowingDistance()
		{
			if (IsAITarget == null)
			{
				return slowingDistance * animal.ScaleFactor;
			}
			return IsAITarget.SlowDistance();
		}

		public virtual void SetNextTarget(GameObject next)
		{
			NextTarget = next.transform;
			IsWayPoint = next.GetComponent<IWayPoint>();
		}

		public virtual void ResetAIValues()
		{
			StopWait();
			RemainingDistance = float.PositiveInfinity;
			MinRemainingDistance = float.PositiveInfinity;
			HasArrived = false;
		}

		private IAITarget ClosestTarget(IAITarget[] targets)
		{
			IAITarget result = null;
			if (targets != null)
			{
				float num = float.PositiveInfinity;
				foreach (IAITarget iAITarget in targets)
				{
					float sqrMagnitude = (base.transform.position - iAITarget.GetCenterPosition()).sqrMagnitude;
					if (num > sqrMagnitude)
					{
						result = iAITarget;
						num = sqrMagnitude;
					}
				}
			}
			return result;
		}

		public virtual void MovetoNextTarget()
		{
			if (NextTarget == null)
			{
				Debuging("There's no Next Target");
				Stop();
			}
			else if (IsWayPoint != null)
			{
				StopWait();
				if (WaitTimeMult > 0f)
				{
					I_WaitToNextTarget = C_WaitToNextTarget(IsWayPoint.WaitTime * WaitTimeMult, NextTarget);
					StartCoroutine(I_WaitToNextTarget);
				}
			}
			else
			{
				SetTarget(NextTarget);
			}
		}

		public void StopWait()
		{
			IsWaiting = false;
			if (I_WaitToNextTarget != null)
			{
				StopCoroutine(I_WaitToNextTarget);
			}
		}

		internal virtual bool CheckAirTarget()
		{
			if (!CanFly)
			{
				return false;
			}
			if (IsAirDestination && !FreeMove)
			{
				if ((bool)Target)
				{
					Debuging($"Target {Target} is in the Air.  Activating Air Destination State State", Target.gameObject);
				}
				animal.State_Activate((AirDestinationState != null) ? ((int)AirDestinationState) : StateEnum.Fly);
				FreeMove = true;
				ActiveAgent = false;
			}
			return IsAirDestination;
		}

		public virtual void SetDestination(Vector3 PositionTarget)
		{
			SetDestination(PositionTarget, move: true);
		}

		public virtual void SetDestination(Vector3 newDestination, bool move)
		{
			LookAtTargetOnArrival = false;
			if (!(newDestination == DestinationPosition) && !(Vector3.Distance(newDestination, DestinationPosition) < stoppingDistance))
			{
				CurrentStoppingDistance = PointStoppingDistance;
				ResetAIValues();
				if (IsOnNonMovingMode)
				{
					animal.Mode_Interrupt();
				}
				IsWayPoint = null;
				if (I_WaitToNextTarget != null)
				{
					StopCoroutine(I_WaitToNextTarget);
				}
				DestinationPosition = newDestination;
				if (move)
				{
					CalculatePath();
					Move();
					Debuging($"<color=yellow>is travelling to: {DestinationPosition} </color>");
				}
			}
		}

		public virtual void SetDestination(Vector3Var newDestination)
		{
			SetDestination(newDestination.Value);
		}

		public virtual void SetDestinationClearTarget(Vector3 PositionTarget)
		{
			target = null;
			SetDestination(PositionTarget, move: true);
		}

		protected virtual void CheckInteractions()
		{
			if (IsTargetInteractable != null && IsTargetInteractable.Auto)
			{
				if (Interactor != null)
				{
					Interactor.Interact(IsTargetInteractable);
					Debuging("Interact with : <b><" + IsTargetInteractable.Owner.name + "></b>. Interactor [" + Interactor.Owner.name + "]");
				}
				else
				{
					IsTargetInteractable.Interact(0, animal.gameObject);
					Debuging("Interact with : <b><" + IsTargetInteractable.Owner.name + "></b>.  Interactor:Null");
				}
			}
		}

		protected virtual void FreeMovement()
		{
			if (!HasArrived)
			{
				AIDirection = DestinationPosition - animal.transform.position;
				SetRemainingDistance(AIDirection.magnitude);
				AIDirection = AIDirection.normalized * SlowMultiplier;
				animal.Move(AIDirection);
				Arrive_Destination();
			}
		}

		protected virtual bool CheckOffMeshLinks()
		{
			if (AgentInOffMeshLink && !InOffMeshLink)
			{
				InOffMeshLink = true;
				LastOffMeshDestination = DestinationPosition;
				Debug.DrawRay(DestinationPosition, Vector3.up * 3f, Color.white, 2f);
				OffMeshLinkData currentOffMeshLinkData = Agent.currentOffMeshLinkData;
				Vector3 startPos = currentOffMeshLinkData.startPos;
				Vector3 endPos = currentOffMeshLinkData.endPos;
				EndOffMeshPos = currentOffMeshLinkData.endPos;
				if (debugGizmos)
				{
					float num = 3f;
					MDebug.DrawLine(startPos, endPos, Color.yellow, num);
					MDebug.DrawRay(startPos, Vector3.up * 2f, Color.yellow, num);
					MDebug.DrawWireSphere(startPos, Color.yellow, 0.3f, num);
					MDebug.DrawRay(endPos, Vector3.up * 2f, Color.yellow, num);
					MDebug.DrawWireSphere(endPos, Color.yellow, 0.3f, num);
				}
				if (currentOffMeshLinkData.linkType == OffMeshLinkType.LinkTypeManual)
				{
					OffMeshLink offMeshLink = currentOffMeshLinkData.offMeshLink;
					if ((bool)offMeshLink)
					{
						MAIAnimalLink component = offMeshLink.GetComponent<MAIAnimalLink>();
						if ((bool)component)
						{
							component.Execute(this, animal, startPos, endPos);
							return true;
						}
						IZone zone = offMeshLink.FindInterface<IZone>();
						if (zone != null)
						{
							if (debug)
							{
								Debuging("<color=white>is on a <b>[OffmeshLink Zone]</b> -> [" + zone.transform.name + "]</color>");
							}
							zone.ActivateZone(animal);
							return true;
						}
						AIDirection = startPos.DirectionTo(endPos);
						animal.Move(AIDirection);
						if (offMeshLink.CompareTag("Fly"))
						{
							Debuging("<color=white>is On a <b>[OffmeshLink]</b> -> [Fly]</color>");
							FlyOffMesh(endPos);
						}
						else if (offMeshLink.CompareTag("Climb"))
						{
							Debuging("<color=white>is On a <b>[OffmeshLink]</b> -> [Climb] -> " + offMeshLink.transform.name + "</color>");
							ClimbOffMesh();
						}
						else if (offMeshLink.area == 2)
						{
							animal.State_Activate(StateEnum.Jump);
							Debuging("<color=white>is On a <b>[OffmeshLink]</b> -> [Jump]</color>");
						}
					}
					else
					{
						Debuging("<color=white>is On a <b>[Undefined or NavMeshLink]</b></color>");
						if (IMoveOffMeshLink != null)
						{
							StopCoroutine(IMoveOffMeshLink);
						}
						IMoveOffMeshLink = C_OffMeshNotFound(currentOffMeshLinkData);
						StartCoroutine(IMoveOffMeshLink);
						CompleteAgentOffMesh();
					}
				}
				else if (currentOffMeshLinkData.linkType == OffMeshLinkType.LinkTypeJumpAcross)
				{
					AIDirection = base.transform.position.DirectionTo(EndOffMeshPos);
					animal.Move(AIDirection);
					Debuging("<color=white>is On a <b>[OffmeshLink]</b> -> [LinkTypeJumpAcross]</color>");
					animal.State_Activate(StateEnum.Jump);
				}
				else if (currentOffMeshLinkData.linkType == OffMeshLinkType.LinkTypeDropDown)
				{
					Debug.DrawRay(currentOffMeshLinkData.endPos, Vector3.up, Color.yellow, 2f);
					CompleteOffMeshLink();
				}
				return true;
			}
			return false;
		}

		protected virtual IEnumerator C_OffMeshNotFound(OffMeshLinkData OMLData)
		{
			yield return null;
			EndOffMeshPos = OMLData.endPos;
			float Dist = Vector3.Distance(base.transform.position, EndOffMeshPos);
			while (Dist > stoppingDistance)
			{
				AIDirection = MTools.DirectionTarget(base.transform.position, EndOffMeshPos).normalized;
				animal.Move(AIDirection);
				Dist = Vector3.Distance(base.transform.position, EndOffMeshPos);
				yield return null;
			}
			ActiveAgent = true;
			Debuging("Exit Undefined OffMeshLink");
			CompleteOffMeshLink();
			yield return null;
		}

		public virtual void CompleteOffMeshLink()
		{
			if (InOffMeshLink)
			{
				CompleteAgentOffMesh();
				InOffMeshLink = false;
				DestinationPosition = LastOffMeshDestination;
				CalculatePath();
				Move();
				Debuging("<color=white>Complete <b>[OffmeshLink]</b></color>");
			}
		}

		protected virtual void CompleteAgentOffMesh()
		{
			if ((bool)Agent && Agent.isOnOffMeshLink)
			{
				Agent.CompleteOffMeshLink();
			}
		}

		protected virtual void FlyOffMesh(Vector3 target)
		{
			ResetFreeMoveOffMesh();
			IFreeMoveOffMesh = C_FlyMoveOffMesh(target);
			StartCoroutine(IFreeMoveOffMesh);
		}

		protected virtual void ClimbOffMesh()
		{
			if (IClimbOffMesh != null)
			{
				StopCoroutine(IClimbOffMesh);
			}
			IClimbOffMesh = C_Climb_OffMesh();
			StartCoroutine(IClimbOffMesh);
		}

		protected virtual void ResetFreeMoveOffMesh()
		{
			if (IFreeMoveOffMesh != null)
			{
				InOffMeshLink = false;
				StopCoroutine(IFreeMoveOffMesh);
				IFreeMoveOffMesh = null;
			}
		}

		protected virtual IEnumerator C_WaitToNextTarget(float time, Transform NextTarget)
		{
			IsWaiting = true;
			if (time > 0f)
			{
				yield return null;
				Debuging($"<color=white> is waiting <B>{time:F2}</B> seconds to go to <B>[{NextTarget.name}]</B> → {DestinationPosition} </color>");
				MAnimal mAnimal = animal;
				Vector3 direction = (AIDirection = Vector3.zero);
				mAnimal.Move(direction);
				yield return new WaitForSeconds(time);
			}
			SetTarget(NextTarget);
		}

		protected virtual IEnumerator C_FlyMoveOffMesh(Vector3 target)
		{
			animal.State_Activate(AirDestinationState);
			InOffMeshLink = true;
			float distance = float.MaxValue;
			EndOffMeshPos = target;
			while (distance > StoppingDistance)
			{
				animal.Move((target - animal.transform.position).normalized * SlowMultiplier);
				distance = Vector3.Distance(animal.transform.position, target);
				yield return null;
			}
			animal.ActiveState.AllowExit();
			Debuging("Exit Fly State Off Mesh");
			InOffMeshLink = false;
		}

		protected virtual IEnumerator C_Climb_OffMesh()
		{
			animal.State_Activate(StateEnum.Climb);
			InOffMeshLink = true;
			yield return null;
			ActiveAgent = false;
			EndOffMeshPos = target.position;
			while ((int)animal.ActiveState.ID == StateEnum.Climb)
			{
				animal.SetInputAxis(Vector3.forward);
				yield return null;
			}
			Debuging("Exit Climb State Off Mesh");
			InOffMeshLink = false;
			IClimbOffMesh = null;
		}

		public void ResetStoppingDistance()
		{
			CurrentStoppingDistance = StoppingDistance;
		}

		public void ResetSlowingDistance()
		{
			CurrentSlowingDistance = SlowingDistance;
		}

		public float StopDistance()
		{
			return StoppingDistance;
		}

		public float SlowDistance()
		{
			return SlowingDistance;
		}

		public virtual void ValidateAgent()
		{
			if (agent == null)
			{
				agent = base.gameObject.FindComponent<NavMeshAgent>();
			}
			AgentTransform = ((agent != null) ? agent.transform : base.transform);
		}

		protected virtual void Debuging(string Log)
		{
			if (debug)
			{
				Debug.Log("<B>[" + animal.name + " AI]</B> " + Log, this);
			}
		}

		protected virtual void Debuging(string Log, GameObject obj)
		{
			if (debug)
			{
				Debug.Log("<B>[" + animal.name + " AI]</B> " + Log, obj);
			}
		}
	}
}
