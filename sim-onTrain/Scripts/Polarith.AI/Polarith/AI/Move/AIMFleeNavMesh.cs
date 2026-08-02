using Polarith.UnityUtils;
using Polarith.Utils;
using UnityEngine;
using UnityEngine.AI;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Flee Nav Mesh")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-seekfleenavmesh.html")]
	public sealed class AIMFleeNavMesh : AIMRadiusSteeringBehaviour
	{
		[Tooltip("Specifies the area for the 'NavMesh.FindClosestEdge(Vector3, out NavMeshHit, int)' and 'NavMesh.GetAreaCost(int)' methods. AreaMask is a bitfield representing the navmesh areas to be considered \n\nNote: the area can be -1 to specify 'NavMesh.AllAreas'. However, with this value, the area cost is set to a default value of 1.")]
		[NavMeshAreaMask]
		public int AreaMask = -1;

		[Tooltip("Allows to specify the settings of this behaviour.")]
		public FleeNavMesh FleeNavMesh = new FleeNavMesh();

		private static GameObject fleeNavMeshTarget;

		[Tooltip("Defines how rays that try to find a navmesh edge are placed around the agent. Either as an evenly distributed circle or as a fan pointing in front of the agent. Changing this value leads to a recalculation of all feelers.")]
		[SerializeField]
		private NavMeshFeelerType feelerType;

		[Tooltip("The number of raycast that are processed. The distribution is dependent on the specified'Feeler Type'. Setting this value is a trade-off between accuracy and cost. A high value features high accuracy as well as high cost and vice versa. Changing this value leads to a recalculation of all feelers.")]
		[OpenRangeMin(0f)]
		[SerializeField]
		private int feelerCount = 4;

		private NavMeshFeeler feeler = new NavMeshFeeler(NavMeshFeelerType.Circle, 4);

		[SerializeField]
		private RaycastGizmo feelerGizmo = new RaycastGizmo();

		public override RadiusSteeringBehaviour RadiusSteeringBehaviour => FleeNavMesh;

		public override bool ThreadSafe => true;

		public NavMeshFeelerType FeelerType
		{
			get
			{
				return feelerType;
			}
			set
			{
				feelerType = value;
				feeler.SetType(feelerType);
			}
		}

		public int FeelerCount
		{
			get
			{
				return feelerCount;
			}
			set
			{
				feelerCount = value;
				feeler.SetCount(feelerCount);
			}
		}

		public override void PrepareEvaluation()
		{
			if (FilteredEnvironments.Count != 0)
			{
				FilteredEnvironments.Clear();
			}
			if (GameObjects.Count == 1)
			{
				GameObjects[0] = fleeNavMeshTarget;
			}
			else
			{
				GameObjects.Clear();
				GameObjects.Add(fleeNavMeshTarget);
			}
			base.PrepareEvaluation();
			if (feeler.Count != FleeNavMesh.NavMeshHits.Count)
			{
				Collections.ResizeList(FleeNavMesh.NavMeshHits, feelerCount);
			}
			for (int i = 0; i < feeler.Count; i++)
			{
				NavMeshHit hit = FleeNavMesh.NavMeshHits[i];
				NavMesh.Raycast(base.transform.position, base.transform.position + base.transform.rotation * feeler[i] * FleeNavMesh.OuterRadius, out hit, AreaMask);
				FleeNavMesh.NavMeshHits[i] = hit;
			}
			FleeNavMesh.ResultMagnitude = ((AreaMask >= 0) ? NavMesh.GetAreaCost(AreaMask) : 1f);
		}

		protected override void Awake()
		{
			base.Awake();
			if (fleeNavMeshTarget == null)
			{
				fleeNavMeshTarget = new GameObject("FleeNavMeshTarget");
				fleeNavMeshTarget.hideFlags = HideFlags.HideInHierarchy;
			}
			feeler = new NavMeshFeeler(feelerType, feelerCount);
		}

		protected override void OnDrawGizmos()
		{
			base.OnDrawGizmos();
			if (feeler == null || FleeNavMesh.NavMeshHits.Count != feeler.Count)
			{
				return;
			}
			for (int i = 0; i < feeler.Count; i++)
			{
				if (FleeNavMesh.NavMeshHits[i].hit)
				{
					feelerGizmo.DrawRayHit(FleeNavMesh.NavMeshHits[i].position);
				}
				feelerGizmo.DrawRay(base.transform.position, feeler[i] * FleeNavMesh.OuterRadius, base.transform.rotation);
			}
		}
	}
}
