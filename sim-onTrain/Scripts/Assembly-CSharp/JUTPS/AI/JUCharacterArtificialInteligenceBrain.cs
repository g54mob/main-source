using System;
using System.Collections.Generic;
using JUTPS.CharacterBrain;
using UnityEngine;
using UnityEngine.Events;

namespace JUTPS.AI
{
	public class JUCharacterArtificialInteligenceBrain : MonoBehaviour
	{
		public enum FollowState
		{
			None = 0,
			FollowingPath = 1,
			FollowingWaypointPath = 2
		}

		[HideInInspector]
		public JUCharacterBrain character;

		private Vector3 oldPosition;

		[HideInInspector]
		public int CurrentWayPointToFollow;

		[HideInInspector]
		public Vector3[] PathToDestination;

		[Header("Destination Settings")]
		public Vector3 Destination;

		public WaypointPath WaypointPath;

		private float RecalculatePathRefreshRate = 1f;

		[Header("Character Path Locomotion Settings")]
		public float DistanceToFinishOnePoint = 1f;

		public bool CheckNearestPointOnPath;

		public WaypointPath.OnEndPathAction OnEndPath;

		[Header("Events")]
		public UnityEvent OnStartPath;

		public UnityEvent OnFollowing;

		public UnityEvent OnEnded;

		private bool Started;

		private bool Following;

		private bool Ended;

		protected FollowState followState;

		private Bounds pathBounds;

		protected virtual void Awake()
		{
			character = GetComponent<JUCharacterBrain>();
			if (character != null)
			{
				character.IsArtificialIntelligence = true;
				if (character is JUCharacterController)
				{
					(character as JUCharacterController).UseDefaultControllerInput = false;
				}
			}
			RecalculatePath();
			InvokeRepeating("RecalculatePath", RecalculatePathRefreshRate, RecalculatePathRefreshRate);
		}

		public void GoToPosition(Vector3 position, float StoppingDistance = 3f, bool running = false)
		{
			if (character.IsArtificialIntelligence && character.IsGrounded)
			{
				followState = FollowState.FollowingPath;
				FollowPath(ref PathToDestination, character, StoppingDistance, ref CurrentWayPointToFollow, running, OnEndPath, CheckNearestPointOnPath);
				SetDestination(position);
				CheckEndEvents();
			}
		}

		public virtual void IdleState()
		{
			character._Move(0f, 0f, Running: false);
		}

		public void FollowCurrentWaypoint(bool running)
		{
			if (character.IsArtificialIntelligence && character.IsGrounded && !(WaypointPath == null))
			{
				followState = FollowState.FollowingWaypointPath;
				PathToDestination = WaypointPath.WaypointPathPositions;
				FollowPath(ref PathToDestination, character, DistanceToFinishOnePoint, ref CurrentWayPointToFollow, running, OnEndPath, CheckNearestPointOnPath);
				CheckEndEvents();
			}
		}

		protected void CheckEndEvents()
		{
			if (GetCurrentFollowingState() == WaypointUtilities.FollowingState.Started && !Started)
			{
				OnStartPath.Invoke();
				Started = true;
				Ended = false;
			}
			if (GetCurrentFollowingState() == WaypointUtilities.FollowingState.Following)
			{
				OnFollowing.Invoke();
			}
			Following = GetCurrentFollowingState() == WaypointUtilities.FollowingState.Following;
			if (GetCurrentFollowingState() == WaypointUtilities.FollowingState.Ended && !Ended)
			{
				OnEnded.Invoke();
				Following = false;
				Started = false;
				Ended = true;
				followState = FollowState.None;
			}
		}

		public void RecalculatePath()
		{
			if (followState != FollowState.FollowingWaypointPath)
			{
				PathToDestination = JUPathFinder.CalculatePath(base.transform.position, Destination);
				WaypointUtilities.DividePath(ref PathToDestination, 2f);
				CurrentWayPointToFollow = 0;
			}
		}

		public void SetPathCalculationRefreshRate(float seconds = 1f)
		{
			RecalculatePathRefreshRate = seconds;
			if (IsInvoking("RecalculatePath"))
			{
				CancelInvoke("RecalculatePath");
				InvokeRepeating("RecalculatePath", RecalculatePathRefreshRate, RecalculatePathRefreshRate);
			}
		}

		public void SetDestination(Vector3 destination)
		{
			Destination = destination;
		}

		public float GetDistanceFromCurrentWaypoint()
		{
			if (WaypointPath == null)
			{
				return 0f;
			}
			if (WaypointPath.WaypointPathPositions.Length != 0)
			{
				_ = pathBounds;
				Vector3[] waypointPathPositions = WaypointPath.WaypointPathPositions;
				foreach (Vector3 point in waypointPathPositions)
				{
					pathBounds.Encapsulate(point);
				}
				return Vector3.Distance(pathBounds.center, base.transform.position);
			}
			return 0f;
		}

		public float GetDistanceFromNextWaypoint()
		{
			return Vector3.Distance(WaypointPath.WaypointPathPositions[CurrentWayPointToFollow], base.transform.position);
		}

		public static void FollowPath(ref Vector3[] path, JUCharacterBrain juCharacter, float stoppingDistance, ref int currentPathCornerId, bool running = false, WaypointPath.OnEndPathAction onPathEnd = WaypointPath.OnEndPathAction.Stop, bool CheckClosestPoint = false)
		{
			if (!juCharacter.IsArtificialIntelligence || !juCharacter.IsGrounded || path.Length == 0)
			{
				return;
			}
			if (path.Length - 1 < currentPathCornerId)
			{
				currentPathCornerId = 0;
			}
			Vector3 vector = path[currentPathCornerId] - juCharacter.transform.position;
			_ = (WaypointUtilities.GetClosestPoint(juCharacter.transform.position, path, 1) - juCharacter.transform.position).normalized;
			float num = Vector3.Distance(juCharacter.transform.position, path[currentPathCornerId]);
			float horizontalInput = vector.x;
			float verticalInput = vector.z;
			bool running2 = running;
			if (num < stoppingDistance && currentPathCornerId < path.Length - 1)
			{
				currentPathCornerId++;
			}
			if (CheckClosestPoint)
			{
				Vector3 closestPoint = WaypointUtilities.GetClosestPoint(juCharacter.transform.position, path);
				int num2 = Array.IndexOf(path, closestPoint);
				if (Vector3.Distance(juCharacter.transform.position, closestPoint) < num && num2 > currentPathCornerId && num2 != path.Length - 1)
				{
					currentPathCornerId = num2;
				}
			}
			if (currentPathCornerId == path.Length - 1 && num < stoppingDistance)
			{
				switch (onPathEnd)
				{
				case WaypointPath.OnEndPathAction.Stop:
					verticalInput = 0f;
					horizontalInput = 0f;
					running2 = false;
					break;
				case WaypointPath.OnEndPathAction.ReversePath:
					Array.Reverse(path);
					currentPathCornerId = 0;
					break;
				case WaypointPath.OnEndPathAction.RestartPath:
					currentPathCornerId = 0;
					break;
				}
			}
			juCharacter._Move(horizontalInput, verticalInput, running2);
		}

		public WaypointUtilities.FollowingState GetCurrentFollowingState()
		{
			return WaypointUtilities.GetPathFollowingState(base.transform, ref oldPosition, PathToDestination, CurrentWayPointToFollow, DistanceToFinishOnePoint);
		}

		public static bool IsAttackable(GameObject target, string[] TargetTags)
		{
			if (target == null)
			{
				return false;
			}
			bool result = false;
			if (target.TryGetComponent<JUHealth>(out var component))
			{
				result = !component.IsDead;
			}
			return result;
		}

		public static Transform SelectTargetOnList(Collider[] targets, string[] allowedTags)
		{
			Transform result = null;
			List<Transform> list = new List<Transform>();
			foreach (Collider collider in targets)
			{
				if (!TagMatches(collider.tag, allowedTags))
				{
					continue;
				}
				if (collider.TryGetComponent<JUHealth>(out var component))
				{
					if (component.Health > 0f && !component.IsDead)
					{
						list.Add(component.transform);
					}
					else
					{
						list.Remove(component.transform);
					}
				}
				else
				{
					result = collider.transform;
				}
			}
			if (list.Count > 0)
			{
				result = list[0];
			}
			return result;
		}

		public static bool TagMatches(string targetTag, string[] allowedTags)
		{
			if (targetTag == null || allowedTags == null)
			{
				return false;
			}
			bool result = false;
			foreach (string text in allowedTags)
			{
				if (targetTag == text)
				{
					result = true;
				}
			}
			return result;
		}
	}
}
