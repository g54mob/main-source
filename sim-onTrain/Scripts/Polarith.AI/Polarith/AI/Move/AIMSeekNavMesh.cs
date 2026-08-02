using Polarith.UnityUtils;
using Polarith.Utils;
using UnityEngine;
using UnityEngine.AI;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Seek Nav Mesh")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-seekfleenavmesh.html")]
	public sealed class AIMSeekNavMesh : AIMRadiusSteeringBehaviour
	{
		[Tooltip("Specifies the area for the 'NavMesh.FindClosestEdge(Vector3, out NavMeshHit, int)' and 'NavMesh.GetAreaCost(int)' methods. AreaMask is a bitfield representing the navmesh areas to be considered \n\nNote: the area can be -1 to specify 'NavMesh.AllAreas'. However, with this value, the area cost is set to a default value of 1.")]
		[NavMeshAreaMask]
		public int AreaMask = -1;

		[Tooltip("Allows to specify the settings of this behaviour.")]
		public SeekNavMesh SeekNavMesh = new SeekNavMesh();

		private static GameObject seekNavMeshTarget;

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

		public override RadiusSteeringBehaviour RadiusSteeringBehaviour => SeekNavMesh;

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
				GameObjects[0] = seekNavMeshTarget;
			}
			else
			{
				GameObjects.Clear();
				GameObjects.Add(seekNavMeshTarget);
			}
			base.PrepareEvaluation();
			if (feeler.Count != SeekNavMesh.NavMeshHits.Count)
			{
				Collections.ResizeList(SeekNavMesh.NavMeshHits, feelerCount);
			}
			for (int i = 0; i < feeler.Count; i++)
			{
				NavMeshHit hit = SeekNavMesh.NavMeshHits[i];
				NavMesh.Raycast(base.transform.position, base.transform.position + base.transform.rotation * feeler[i] * SeekNavMesh.OuterRadius, out hit, AreaMask);
				SeekNavMesh.NavMeshHits[i] = hit;
			}
			SeekNavMesh.ResultMagnitude = ((AreaMask >= 0) ? NavMesh.GetAreaCost(AreaMask) : 1f);
		}

		protected override void Awake()
		{
			base.Awake();
			if (seekNavMeshTarget == null)
			{
				seekNavMeshTarget = new GameObject("SeekNavMeshTarget");
				seekNavMeshTarget.hideFlags = HideFlags.HideInHierarchy;
			}
			feeler = new NavMeshFeeler(feelerType, feelerCount);
		}

		protected override void OnDrawGizmos()
		{
			base.OnDrawGizmos();
			if (feeler == null || SeekNavMesh.NavMeshHits.Count != feeler.Count)
			{
				return;
			}
			for (int i = 0; i < feeler.Count; i++)
			{
				if (SeekNavMesh.NavMeshHits[i].hit)
				{
					feelerGizmo.DrawRayHit(SeekNavMesh.NavMeshHits[i].position);
				}
				feelerGizmo.DrawRay(base.transform.position, feeler[i] * SeekNavMesh.OuterRadius, base.transform.rotation);
			}
		}
	}
}
