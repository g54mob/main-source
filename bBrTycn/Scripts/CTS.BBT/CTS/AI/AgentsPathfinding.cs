using System;
using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace CTS.AI
{
	public class AgentsPathfinding : CTSSingleton<AgentsPathfinding>
	{
		public struct PathRequest
		{
			public Vector3 originPosition;

			public Vector3 destinationPosition;

			public Transform originTransform;

			public Transform destinationTransform;

			public NavMeshQueryFilter queryFilter;

			public AgentPath returnPath;

			public PathRequest(Vector3 p_start, Vector3 p_end, Transform p_startTransform, Transform p_endTransform, AgentPath.EDestinationType p_destinationType, NavMeshQueryFilter queryFilter)
			{
				originPosition = p_start;
				destinationPosition = p_end;
				originTransform = p_startTransform;
				destinationTransform = p_endTransform;
				this.queryFilter = queryFilter;
				returnPath = new AgentPath(p_destinationType)
				{
					Target = (p_endTransform ? p_endTransform.position : p_end)
				};
			}
		}

		[SerializeField]
		private NavigationArea[] _areaCosts;

		private static readonly Queue<PathRequest> PathRequestsToCalculate = new Queue<PathRequest>();

		private int countToCalculate;

		private const float MaxCalculationTimePerFrame = 0.05f;

		private static double pathCalculationThisFrame;

		private static Coroutine currentCalculationRoutine;

		private static float nextPathCalculation = 0f;

		private static NavMeshPath _dummyPath;

		private static NavMeshQueryFilter _baseQuery = default(NavMeshQueryFilter);

		public static NavMeshQueryFilter BaseQueryFilter => _baseQuery;

		public static NavMeshQueryFilter? GetFilterFromArea(int? area = null)
		{
			if (!area.HasValue)
			{
				return _baseQuery;
			}
			NavMeshQueryFilter baseQuery = _baseQuery;
			baseQuery.areaMask = area.Value;
			return baseQuery;
		}

		public static NavMeshPath GetDummyPath()
		{
			return _dummyPath ?? (_dummyPath = new NavMeshPath());
		}

		protected override void SingletonAwake()
		{
			pathCalculationThisFrame = 0.0;
			nextPathCalculation = 0f;
			PathRequestsToCalculate.Clear();
			currentCalculationRoutine = null;
			NavigationArea[] areaCosts = _areaCosts;
			foreach (NavigationArea navigationArea in areaCosts)
			{
				_baseQuery.SetAreaCost(navigationArea, NavMesh.GetAreaCost(navigationArea));
			}
			_baseQuery.areaMask = AgentsMover.AllAreas;
		}

		protected override void OnSingletonDestroy()
		{
		}

		private IEnumerator PathCalculationRoutine()
		{
			while (Time.time < nextPathCalculation)
			{
				yield return null;
			}
			while (PathRequestsToCalculate.Count > 0)
			{
				PathCalculation();
				yield return null;
			}
			currentCalculationRoutine = null;
		}

		private void PathCalculation()
		{
			pathCalculationThisFrame = 0.0;
			while (PathRequestsToCalculate.Count > 0 && (pathCalculationThisFrame < 0.05000000074505806 || PathRequestsToCalculate.Count > 50))
			{
				PathRequest pathRequest = PathRequestsToCalculate.Dequeue();
				try
				{
					CalculatePath(pathRequest);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
				pathCalculationThisFrame += Time.realtimeSinceStartupAsDouble;
			}
		}

		public void CalculatePath(PathRequest pathRequest)
		{
			NavMeshPath path = GetDummyPath();
			if ((bool)pathRequest.originTransform)
			{
				DoCalculatePath(pathRequest.originTransform.position, pathRequest.destinationTransform.position);
			}
			else
			{
				DoCalculatePath(pathRequest.originPosition, pathRequest.destinationPosition);
			}
			countToCalculate = PathRequestsToCalculate.Count;
			void DoCalculatePath(Vector3 start, Vector3 end)
			{
				end.y = FloorsManager.GetNearestFloorHeight(end.y);
				NavMeshHit hit;
				bool flag = ((pathRequest.returnPath.DestinationType != AgentPath.EDestinationType.LookAtDistance) ? NavMesh.SamplePosition(end, out hit, 0.5f, AgentsMover.AllAreas) : NavMesh.SamplePosition(end, out hit, Math.Min(pathRequest.returnPath.DistanceToLookAt, 2f), AgentsMover.AllAreas));
				NavMeshHit hit2;
				bool flag2 = NavMesh.SamplePosition(start, out hit2, 0.5f, AgentsMover.AllAreas);
				if (!flag2)
				{
					flag2 = NavMesh.SamplePosition(start, out hit2, 1f, AgentsMover.AllAreas);
				}
				if (!flag2)
				{
					pathRequest.returnPath.CalculationStatus = AgentPath.ECalculationStatus.Failed;
				}
				else if (!flag)
				{
					pathRequest.returnPath.CalculationStatus = AgentPath.ECalculationStatus.Failed;
				}
				else
				{
					int areaMask = (hit2.mask.ExistsInMask(pathRequest.queryFilter.areaMask) ? pathRequest.queryFilter.areaMask : AgentsMover.AllAreas);
					pathRequest.queryFilter.areaMask = areaMask;
					if (!NavMesh.CalculatePath(hit2.position, hit.position, pathRequest.queryFilter, path))
					{
						pathRequest.returnPath.CalculationStatus = AgentPath.ECalculationStatus.Failed;
					}
					else if (path.status == NavMeshPathStatus.PathPartial || Vector3.Distance(path.corners[^1], hit.position) > 0.25f)
					{
						pathRequest.returnPath.CalculationStatus = AgentPath.ECalculationStatus.Failed;
						Vector3[] corners = path.corners;
						for (int i = 0; i < corners.Length - 1; i++)
						{
							Debug.DrawLine(corners[i], corners[i + 1], Color.red, 5f);
						}
					}
					else
					{
						NavMeshPathToAgentPath(pathRequest.returnPath, path, pathRequest.destinationTransform);
						pathRequest.returnPath.CalculationStatus = AgentPath.ECalculationStatus.Completed;
					}
				}
			}
		}

		private static void NavMeshPathToAgentPath(AgentPath p_path, NavMeshPath p_navPath, Transform p_destinationTransform)
		{
			PathCorner[] array = new PathCorner[p_navPath.corners.Length];
			array[^1].IsLastCorner = true;
			int num = array.Length - 1;
			for (int i = 1; i < num; i++)
			{
				Vector3 vector = Vector3.Lerp(p_navPath.corners[i], p_navPath.corners[i - 1], 0.5f);
				if (!NavMesh.SamplePosition(vector, out var hit, 0.5f, AgentsMover.AllAreas))
				{
					array[i - 1].IsOffLinkEntry = true;
					Debug.DrawRay(vector, Vector3.up, array[i].IsOffLinkEntry ? Color.blue : Color.red, 5f);
					continue;
				}
				Vector2 vector2 = vector.ToHorizontal2D();
				Vector2 vector3 = hit.position.ToHorizontal2D();
				array[i - 1].IsOffLinkEntry = Vector2.SqrMagnitude(vector3 - vector2) > 0.00062500004f;
				Debug.DrawRay(vector, Vector3.up, array[i].IsOffLinkEntry ? Color.blue : Color.red, 5f);
			}
			array[0].Position = p_navPath.corners[0];
			array[^1].Position = p_navPath.corners[^1];
			for (int j = 1; j < num; j++)
			{
				Vector2 vector4 = array[j - 1].Position.ToHorizontal2D();
				array[j].Position = p_navPath.corners[j];
				Vector2 vector5 = array[j].Position.ToHorizontal2D();
				Vector2 vector6 = p_navPath.corners[j + 1].ToHorizontal2D();
				Vector2 normalized = (vector5 - vector4).normalized;
				Vector2 normalized2 = (vector4 - vector5).normalized;
				Vector2 normalized3 = (vector6 - vector5).normalized;
				bool flag = Vector2.SignedAngle(normalized, normalized3) > 0f;
				array[j].Normal = Vector2.Perpendicular(flag ? (normalized2 - normalized3) : (normalized3 - normalized2)).normalized;
			}
			float num2 = 0f;
			for (int num3 = num - 1; num3 > 0; num3--)
			{
				Vector3 position = array[num3].Position;
				float magnitude = (array[num3 + 1].Position - position).magnitude;
				num2 += magnitude;
				array[num3].DistanceToNext = magnitude;
				array[num3].RemainingDistance = num2;
			}
			for (int k = 1; k < num; k++)
			{
				Vector2 vector7 = array[k].Position.ToHorizontal2D();
				Vector2 normalized4 = (vector7 - array[k - 1].Position.ToHorizontal2D()).normalized;
				Vector2 normalized5 = (array[k + 1].Position.ToHorizontal2D() - vector7).normalized;
				array[k].TurnAngle = Vector2.Angle(normalized4, normalized5);
			}
			p_path.Corners = array;
			p_path.TrySetNextCorner();
			if (p_path.DestinationType == AgentPath.EDestinationType.Precise)
			{
				p_path.EndRotation = Quaternion.LookRotation(p_destinationTransform.forward.FlattenY());
			}
		}

		public static AgentPath AskForPath(Vector3 startPosition, Vector3 targetPosition, NavMeshQueryFilter filter)
		{
			PathRequest item = new PathRequest(startPosition, targetPosition, null, null, AgentPath.EDestinationType.Simple, filter);
			PathRequestsToCalculate.Enqueue(item);
			if (currentCalculationRoutine == null)
			{
				currentCalculationRoutine = CTSSingleton<AgentsPathfinding>.Instance.StartCoroutine(CTSSingleton<AgentsPathfinding>.Instance.PathCalculationRoutine());
			}
			return item.returnPath;
		}

		public static AgentPath AskForPath(Transform origin, MoveTarget target, NavMeshQueryFilter filter)
		{
			PathRequest item = new PathRequest(Vector3.zero, Vector3.zero, origin, target.transform, target.DestinationType, filter);
			PathRequestsToCalculate.Enqueue(item);
			item.returnPath.DistanceToLookAt = target.maxDistance;
			if (currentCalculationRoutine == null)
			{
				currentCalculationRoutine = CTSSingleton<AgentsPathfinding>.Instance.StartCoroutine(CTSSingleton<AgentsPathfinding>.Instance.PathCalculationRoutine());
			}
			return item.returnPath;
		}

		public static AgentPath AskForPath(Transform origin, Transform target, AgentPath.EDestinationType destinationType, float maxDistance, NavMeshQueryFilter filter)
		{
			PathRequest item = new PathRequest(Vector3.zero, Vector3.zero, origin, target, destinationType, filter);
			PathRequestsToCalculate.Enqueue(item);
			item.returnPath.DistanceToLookAt = maxDistance;
			if (currentCalculationRoutine == null)
			{
				currentCalculationRoutine = CTSSingleton<AgentsPathfinding>.Instance.StartCoroutine(CTSSingleton<AgentsPathfinding>.Instance.PathCalculationRoutine());
			}
			return item.returnPath;
		}
	}
}
