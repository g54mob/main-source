using System;
using System.Collections.Generic;
using Polarith.Utils;
using UnityEngine;
using UnityEngine.AI;

namespace Polarith.AI.Move
{
	[RequireComponent(typeof(NavMeshAgent))]
	[AddComponentMenu("Polarith AI » Move/Path/AIM Unity Pathfinding")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-unitypathfinding.html")]
	public sealed class AIMUnityPathfinding : AIMPathfinding
	{
		public Action<GameObject, OffMeshLinkData> OffMeshLinkReached;

		private readonly List<Vector3> copiedPoints = new List<Vector3>();

		[Tooltip("This validator verifies the current path status. For example, the path is stale after changing the area mask and this might cause a re-calculation. ")]
		[SerializeField]
		private NavMeshAgentValidator navMeshAgentValidator = new NavMeshAgentValidator();

		private NavMeshAgent navMeshAgent;

		private bool pathInProgress;

		public NavMeshAgentValidator NavMeshAgentValidator => navMeshAgentValidator;

		public NavMeshAgent NavMeshAgent => navMeshAgent;

		public bool PathInProgress => pathInProgress;

		protected override IList<Vector3> points => copiedPoints;

		public override void CalculatePath(Vector3 destination)
		{
			if (!pathInProgress)
			{
				navMeshAgent.ResetPath();
				navMeshAgent.destination = destination;
				pathInProgress = true;
			}
		}

		protected override void UpdateValidators()
		{
			base.UpdateValidators();
			navMeshAgentValidator.Agent = navMeshAgent;
		}

		protected override void Start()
		{
			base.Start();
			distanceValidator.PathPoints = copiedPoints;
			validators.Add(navMeshAgentValidator);
		}

		protected override void Update()
		{
			base.Update();
			if (pathInProgress && !navMeshAgent.pathPending)
			{
				pathInProgress = false;
				Collections.CopyList(navMeshAgent.path.corners, copiedPoints);
				if (PathChanged != null)
				{
					PathChanged();
				}
			}
			if (navMeshAgent.isOnOffMeshLink)
			{
				navMeshAgent.CompleteOffMeshLink();
				if (OffMeshLinkReached != null)
				{
					OffMeshLinkReached(base.gameObject, navMeshAgent.currentOffMeshLinkData);
				}
			}
			navMeshAgent.nextPosition = base.transform.position;
		}

		private void Awake()
		{
			navMeshAgent = GetComponent<NavMeshAgent>();
			if (navMeshAgent == null)
			{
				navMeshAgent = base.gameObject.AddComponent<NavMeshAgent>();
			}
			navMeshAgent.speed = 0f;
			navMeshAgent.acceleration = 0f;
			navMeshAgent.angularSpeed = 0f;
			navMeshAgent.updatePosition = false;
			navMeshAgent.updateRotation = false;
			navMeshAgent.updateUpAxis = false;
			navMeshAgent.autoBraking = false;
			navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
			navMeshAgent.autoTraverseOffMeshLink = false;
			navMeshAgent.autoRepath = false;
		}
	}
}
