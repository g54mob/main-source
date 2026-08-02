using System.Collections.Generic;
using Polarith.UnityUtils;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[ExecuteInEditMode]
	[AddComponentMenu("Polarith AI » Move/Path/AIM Linear Path")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-linearpath.html")]
	public class AIMLinearPath : AIMPathConnector
	{
		protected readonly List<Vector3> waypoints = new List<Vector3>();

		[Tooltip("Local Points of the path.")]
		[SerializeField]
		protected List<Vector3> localWaypoints = new List<Vector3>();

		[Tooltip("Determines the selection color for the vertices.")]
		[SerializeField]
		protected Color selectionColor = Colors.Orange;

		private Vector3 oldPosition;

		private Vector3 oldEulerAngles;

		private Vector3 oldScale;

		protected override IList<Vector3> points => waypoints;

		public override IList<Vector3> GetLocalPoints()
		{
			return new List<Vector3>(localWaypoints);
		}

		public override void GetLocalPointsNonAlloc(IList<Vector3> points)
		{
			Collections.CopyList(localWaypoints, points);
		}

		public void Reverse()
		{
			localWaypoints.Reverse();
			waypoints.Reverse();
		}

		public void SetPoints(List<Vector3> points)
		{
			Collections.ResizeList(waypoints, points.Count);
			for (int i = 0; i < waypoints.Count; i++)
			{
				Vector3 point = points[i];
				Mathv.RoundZeroElements(ref point);
				waypoints[i] = point;
			}
			Collections.ResizeList(localWaypoints, waypoints.Count);
			for (int j = 0; j < localWaypoints.Count; j++)
			{
				Vector3 point = base.transform.worldToLocalMatrix.MultiplyPoint(waypoints[j]);
				Mathv.RoundZeroElements(ref point);
				localWaypoints[j] = point;
			}
		}

		public void SetLocalPoints(List<Vector3> points)
		{
			Collections.ResizeList(localWaypoints, points.Count);
			for (int i = 0; i < localWaypoints.Count; i++)
			{
				Vector3 point = points[i];
				Mathv.RoundZeroElements(ref point);
				localWaypoints[i] = point;
			}
			Collections.ResizeList(waypoints, localWaypoints.Count);
			for (int j = 0; j < waypoints.Count; j++)
			{
				Vector3 point = base.transform.localToWorldMatrix.MultiplyPoint(localWaypoints[j]);
				Mathv.RoundZeroElements(ref point);
				waypoints[j] = point;
			}
		}

		private void Awake()
		{
			Collections.ResizeList(waypoints, localWaypoints.Count);
			for (int i = 0; i < localWaypoints.Count; i++)
			{
				waypoints[i] = base.transform.localToWorldMatrix.MultiplyPoint(localWaypoints[i]);
			}
			oldPosition = base.transform.position;
			oldEulerAngles = base.transform.rotation.eulerAngles;
			oldScale = base.transform.lossyScale;
		}

		private void Update()
		{
			if ((base.transform.position - oldPosition).sqrMagnitude > 1E-06f || (base.transform.rotation.eulerAngles - oldEulerAngles).sqrMagnitude > 1E-06f || (base.transform.lossyScale - oldScale).sqrMagnitude > 1E-06f)
			{
				SetLocalPoints(localWaypoints);
				if (PathChanged != null)
				{
					PathChanged();
				}
			}
			oldPosition = base.transform.position;
			oldEulerAngles = base.transform.rotation.eulerAngles;
			oldScale = base.transform.lossyScale;
		}
	}
}
