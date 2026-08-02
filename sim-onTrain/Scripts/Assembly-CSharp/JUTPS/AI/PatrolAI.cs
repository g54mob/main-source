using JUTPS.CharacterBrain;
using UnityEngine;
using UnityEngine.Events;

namespace JUTPS.AI
{
	[AddComponentMenu("JU TPS/AI/Patrol AI")]
	public class PatrolAI : JUCharacterArtificialInteligenceBrain
	{
		private JUCharacterBrain targetJuCharacter;

		private Transform currentTarget;

		private float distanceFromDestination;

		private Vector3 fieldViewPosition;

		private Vector3 smoothedTargetPosition;

		private Vector3 closestWalkablePosition;

		private Vector3 lastVisiblePosition;

		[Header("Follow Settings")]
		public string[] TargetTags = new string[1] { "Player" };

		public FieldView FieldOfView = new FieldView(10f, 60f);

		public LayerMask SensorLayerMask;

		public float StartRunningAtDistance = 5f;

		public float StopDistance = 3f;

		[Header("Attack Settings")]
		public float AttackAtDistance = 15f;

		public float AimUpOffset = 1f;

		public float LookTargetSpeed = 5f;

		public float AttackDuration = 1.5f;

		public float MinTimeToAttack = 1f;

		public float MaxTimeToAttack = 2f;

		private float currentTimeToAttack;

		private float currentMaxTimeToAttack;

		private float currentAttackDuration;

		private bool isAttacking;

		private bool isCurrentTargetAttackable;

		private bool currentTargetIsVisible;

		private bool isRunning;

		private float currentTimeToDisableFireMode;

		[Space(10f)]
		public UnityEvent _OnFollowWaypoint;

		private bool FollowingWaypoint;

		public UnityEvent _OnFollowAIPath;

		private bool FollowingAIPath;

		public UnityEvent _OnSeeTarget;

		private bool SawATarget;

		public UnityEvent _OnStopSeeingTarget;

		private bool StoppedSeeingTarget;

		private void Start()
		{
			InvokeRepeating("CheckTargets", 0.5f, 0.5f);
		}

		protected virtual void Update()
		{
			if (character.IsDead)
			{
				base.enabled = false;
				return;
			}
			CheckEndEvents();
			isRunning = distanceFromDestination > StartRunningAtDistance;
			if (currentTarget != null)
			{
				Debug.DrawLine(fieldViewPosition, smoothedTargetPosition, Color.green);
				HuntTheTargetState();
				if (distanceFromDestination < AttackAtDistance && currentTargetIsVisible && isCurrentTargetAttackable)
				{
					EnterAttackModeState();
				}
				else
				{
					ExitAttackModeState();
				}
			}
			else
			{
				Debug.DrawLine(fieldViewPosition, smoothedTargetPosition, Color.red);
				if (WaypointPath != null)
				{
					if (character.FiringMode)
					{
						if (distanceFromDestination > StopDistance)
						{
							FollowAIPathState(closestWalkablePosition, isRunning);
						}
						else if (distanceFromDestination < StopDistance / 2f)
						{
							FollowAIPathState(base.transform.position - base.transform.forward * 5f, Run: true);
						}
						else
						{
							IdleState();
						}
						currentTimeToDisableFireMode += Time.deltaTime;
						if (currentTimeToDisableFireMode > 2f && character.FiringMode)
						{
							ExitAttackModeState();
						}
						character.LookAtPosition = smoothedTargetPosition + Vector3.up * AimUpOffset;
					}
					else if (Vector3.Distance(base.transform.position, WaypointPath.GetWaypointCenter()) < 15f)
					{
						FollowWaypointPathState(isRunning);
					}
					else
					{
						FollowAIPathState(WaypointPath.WaypointPathPositions[0], isRunning);
					}
				}
				else if (Destination == Vector3.zero)
				{
					IdleState();
				}
				else if (distanceFromDestination < StopDistance / 2f || PathToDestination.Length == 0)
				{
					IdleState();
				}
				else
				{
					FollowAIPathState(closestWalkablePosition, isRunning);
				}
			}
			UpdateCurrentTarget();
		}

		public void CheckTargets()
		{
			Vector3 vector = base.transform.position + base.transform.up * (AimUpOffset + 0.2f);
			Collider[] array = FieldOfView.CheckViewCollider(vector, base.transform.forward, SensorLayerMask, base.gameObject);
			if (array.Length != 0)
			{
				currentTarget = JUCharacterArtificialInteligenceBrain.SelectTargetOnList(array, TargetTags);
				if (currentTarget == null)
				{
					targetJuCharacter = null;
				}
				else if (targetJuCharacter != null)
				{
					isCurrentTargetAttackable = !targetJuCharacter.IsDead;
					if (currentTarget != targetJuCharacter.transform && currentTarget.TryGetComponent<JUCharacterBrain>(out var component))
					{
						targetJuCharacter = component;
					}
				}
				else
				{
					isCurrentTargetAttackable = false;
					if (currentTarget.TryGetComponent<JUCharacterBrain>(out var component2))
					{
						targetJuCharacter = component2;
					}
				}
			}
			currentTargetIsVisible = ((targetJuCharacter == null) ? FieldOfView.IsVisibleToThisFieldOfView(currentTarget, vector, base.transform.forward, SensorLayerMask, 0.6f, TargetTags) : FieldOfView.IsVisibleToThisFieldOfView(targetJuCharacter.HumanoidSpine, vector, base.transform.forward, SensorLayerMask, 0.6f, TargetTags));
		}

		public void UpdateCurrentTarget()
		{
			if (currentTarget != null && !SawATarget)
			{
				_OnSeeTarget.Invoke();
				SawATarget = true;
				StoppedSeeingTarget = false;
			}
			if (currentTarget == null && !StoppedSeeingTarget && SawATarget)
			{
				_OnStopSeeingTarget.Invoke();
				StoppedSeeingTarget = true;
				SawATarget = false;
			}
			if (CurrentWayPointToFollow > PathToDestination.Length)
			{
				distanceFromDestination = ((currentTarget != null) ? Vector3.Distance(base.transform.position, currentTarget.position) : Vector3.Distance(base.transform.position, Destination));
			}
			else
			{
				distanceFromDestination = ((currentTarget != null) ? Vector3.Distance(base.transform.position, currentTarget.position) : Vector3.Distance(base.transform.position, PathToDestination[CurrentWayPointToFollow]));
			}
			smoothedTargetPosition = ((currentTarget != null && targetJuCharacter == null) ? Vector3.Lerp(smoothedTargetPosition, currentTarget.position, LookTargetSpeed * Time.deltaTime) : smoothedTargetPosition);
			if (currentTarget == null)
			{
				currentTargetIsVisible = false;
			}
			if (targetJuCharacter != null)
			{
				smoothedTargetPosition = Vector3.Lerp(smoothedTargetPosition, targetJuCharacter.HumanoidSpine.position - targetJuCharacter.transform.up * AimUpOffset, LookTargetSpeed * Time.deltaTime);
			}
			closestWalkablePosition = JUPathFinder.GetClosestWalkablePoint((currentTarget != null) ? currentTarget.position : closestWalkablePosition);
			if (currentTargetIsVisible)
			{
				lastVisiblePosition = closestWalkablePosition;
			}
			if (currentTarget != null && distanceFromDestination > 2f * FieldOfView.Radious)
			{
				currentTarget = null;
			}
		}

		public void HuntTheTargetState()
		{
			if (StoppedSeeingTarget && !currentTargetIsVisible)
			{
				FollowAIPathState(lastVisiblePosition, isRunning);
			}
			else if (currentTargetIsVisible && SawATarget)
			{
				FollowAIPathState(closestWalkablePosition, isRunning);
			}
			else
			{
				FollowWaypointPathState(isRunning);
			}
		}

		public void FollowAIPathState(Vector3 Position, bool Run)
		{
			GoToPosition(Position, DistanceToFinishOnePoint, Run);
			JUPathFinder.VisualizePath(PathToDestination);
			OnEndPath = WaypointPath.OnEndPathAction.Stop;
			if (!FollowingAIPath)
			{
				_OnFollowAIPath.Invoke();
				FollowingAIPath = true;
			}
			FollowingWaypoint = false;
		}

		public void FollowWaypointPathState(bool Run)
		{
			if (!(WaypointPath == null))
			{
				FollowCurrentWaypoint(Run);
				OnEndPath = WaypointPath.OnEndPathAction.ReversePath;
				if (!FollowingWaypoint)
				{
					_OnFollowWaypoint.Invoke();
					FollowingWaypoint = true;
				}
				FollowingAIPath = false;
			}
		}

		public void EnterAttackModeState()
		{
			currentTimeToDisableFireMode = 0f;
			if (!isCurrentTargetAttackable)
			{
				isAttacking = false;
				currentMaxTimeToAttack = 0f;
				currentAttackDuration = 0f;
			}
			character.LookAtPosition = smoothedTargetPosition + Vector3.up * AimUpOffset;
			character.FiringMode = true;
			character.FiringModeIK = true;
			if (!isAttacking)
			{
				if (currentMaxTimeToAttack == 0f)
				{
					currentMaxTimeToAttack = Random.Range(MinTimeToAttack, MaxTimeToAttack);
				}
				currentTimeToAttack += Time.deltaTime;
				if (currentTimeToAttack >= currentMaxTimeToAttack)
				{
					currentTimeToAttack = 0f;
					isAttacking = true;
				}
				character.DefaultUseOfAllItems(ShotInput: false);
			}
			if (isAttacking && currentAttackDuration < AttackDuration)
			{
				if (Vector3.Dot(smoothedTargetPosition - base.transform.position, currentTarget.position - base.transform.position) > 0.8f)
				{
					character.DefaultUseOfAllItems(ShotInput: true, ShotInputDown: true, ReloadInput: false, AimInput: false, AimInputDown: false, MeleeAttackInput: true);
				}
				currentAttackDuration += Time.deltaTime;
				if (currentAttackDuration >= AttackDuration)
				{
					isAttacking = false;
					currentMaxTimeToAttack = 0f;
					currentAttackDuration = 0f;
				}
			}
		}

		public void ExitAttackModeState()
		{
			character.FiringMode = false;
			character.FiringModeIK = false;
			isAttacking = false;
			currentMaxTimeToAttack = 0f;
			currentAttackDuration = 0f;
		}
	}
}
