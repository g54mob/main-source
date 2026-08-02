using JUTPS.CharacterBrain;
using UnityEngine;
using UnityEngine.Events;

namespace JUTPS.AI
{
	[AddComponentMenu("JU TPS/AI/Zombie AI")]
	public class ZombieAI : JUCharacterArtificialInteligenceBrain
	{
		private JUCharacterBrain targetJuCharacter;

		private Transform currentTarget;

		private float distanceFromDestination;

		private Vector3 fieldViewPosition;

		private Vector3 smoothedTargetPosition;

		private Vector3 closestWalkablePosition;

		[Header("Follow Settings")]
		public string[] TargetTags = new string[1] { "Player" };

		public FieldView FieldOfView = new FieldView(10f, 60f);

		public LayerMask SensorLayerMask;

		public float StartRunningAtDistance = 5f;

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

		protected virtual void Update()
		{
			if (character.IsDead)
			{
				base.enabled = false;
				return;
			}
			CheckTargets();
			isRunning = distanceFromDestination > StartRunningAtDistance;
			if (currentTarget != null && currentTargetIsVisible)
			{
				Debug.DrawLine(fieldViewPosition, smoothedTargetPosition, Color.green);
				FollowAIPathState(closestWalkablePosition, isRunning);
				if (distanceFromDestination < 2f)
				{
					character.DoLookAt(currentTarget.position, LookTargetSpeed);
				}
				if (distanceFromDestination < AttackAtDistance && currentTargetIsVisible && isCurrentTargetAttackable)
				{
					EnterAttackModeState();
					return;
				}
				character.FiringMode = false;
				character.FiringModeIK = false;
				return;
			}
			Debug.DrawLine(fieldViewPosition, smoothedTargetPosition, Color.red);
			if (WaypointPath != null)
			{
				if (character.FiringMode)
				{
					FollowAIPathState(closestWalkablePosition, isRunning);
					currentTimeToDisableFireMode += Time.deltaTime;
					if (currentTimeToDisableFireMode > 10f)
					{
						ExitAttackModeState();
					}
					else
					{
						EnterAttackModeState();
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
			else
			{
				FollowAIPathState(closestWalkablePosition, isRunning);
			}
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
			else
			{
				currentTarget = null;
				targetJuCharacter = null;
				isCurrentTargetAttackable = false;
			}
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
			distanceFromDestination = ((currentTarget != null) ? Vector3.Distance(base.transform.position, currentTarget.position) : 0f);
			smoothedTargetPosition = ((currentTarget != null && targetJuCharacter == null) ? Vector3.Lerp(smoothedTargetPosition, currentTarget.position, LookTargetSpeed * Time.deltaTime) : smoothedTargetPosition);
			currentTargetIsVisible = ((targetJuCharacter == null) ? FieldOfView.IsVisibleToThisFieldOfView(currentTarget, vector, base.transform.forward, SensorLayerMask, 0.6f, TargetTags) : FieldOfView.IsVisibleToThisFieldOfView(targetJuCharacter.HumanoidSpine, vector, base.transform.forward, SensorLayerMask, 0.6f, TargetTags));
			if (targetJuCharacter != null)
			{
				smoothedTargetPosition = Vector3.Lerp(smoothedTargetPosition, targetJuCharacter.HumanoidSpine.position - targetJuCharacter.transform.up * AimUpOffset, LookTargetSpeed * Time.deltaTime);
			}
			closestWalkablePosition = JUPathFinder.GetClosestWalkablePoint((currentTarget != null) ? currentTarget.position : Destination);
			if (currentTarget != null && distanceFromDestination > 2f * FieldOfView.Radious)
			{
				currentTarget = null;
				Debug.Log("Current Target are null 4");
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
			if (!isCurrentTargetAttackable)
			{
				isAttacking = false;
				currentMaxTimeToAttack = 0f;
				currentAttackDuration = 0f;
			}
			character.LookAtPosition = smoothedTargetPosition + Vector3.up * AimUpOffset;
			character.DoLookAt(character.LookAtPosition, LookTargetSpeed);
			character.FiringMode = false;
			character.FiringModeIK = false;
			if (!isAttacking)
			{
				if (currentMaxTimeToAttack == 0f)
				{
					currentMaxTimeToAttack = Random.Range(MinTimeToAttack, MaxTimeToAttack);
				}
				currentTimeToAttack += Time.deltaTime;
				if (currentTimeToAttack >= currentMaxTimeToAttack)
				{
					isAttacking = true;
				}
				character.DefaultUseOfAllItems(ShotInput: false, ShotInputDown: false, ReloadInput: false, AimInput: false, AimInputDown: false, MeleeAttackInput: true);
			}
			if (isAttacking && currentAttackDuration <= AttackDuration + 0.1f)
			{
				character.DefaultUseOfAllItems(ShotInput: true, ShotInputDown: true, ReloadInput: false, AimInput: false, AimInputDown: false, MeleeAttackInput: true);
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
			isAttacking = false;
			currentMaxTimeToAttack = 0f;
			currentAttackDuration = 0f;
		}
	}
}
