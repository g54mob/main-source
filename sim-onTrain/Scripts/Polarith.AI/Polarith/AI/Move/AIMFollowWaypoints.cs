using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Follow Waypoints")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-followwaypoints.html")]
	public sealed class AIMFollowWaypoints : AIMFollowPath
	{
		[Tooltip("Determines how close the agent has to move towards to the current target before it is marked as reached.")]
		public float TargetRadius = 1f;

		[Tooltip("Determines the step size for iterating through the path points.")]
		public int StepSize = 1;

		[Tooltip("Determines how a path is traversed after the agent has reached the end respectively the start of the path.")]
		public PatrolType Patrol;

		private CircleGizmo circleGizmo = new CircleGizmo();

		private Vector3 projectedPosition;

		[SerializeField]
		[FollowPathTargetIndex]
		private int targetIndex;

		public override bool ThreadSafe => true;

		public int TargetIndex
		{
			get
			{
				return targetIndex;
			}
			set
			{
				targetIndex = Mathf.Clamp(value, 0, points.Count);
			}
		}

		protected override Vector3 GetTarget()
		{
			projectedPosition = base.transform.position;
			if (Follow.VectorProjection == VectorProjectionType.PlaneXY)
			{
				projectedPosition.z = target.z;
			}
			else if (Follow.VectorProjection == VectorProjectionType.PlaneXZ)
			{
				projectedPosition.y = target.y;
			}
			if (Vector3.Distance(target, projectedPosition) < TargetRadius)
			{
				targetIndex += StepSize;
				if (targetIndex <= 0 || targetIndex >= points.Count)
				{
					switch (Patrol)
					{
					case PatrolType.None:
						targetIndex = Mathf.Clamp(targetIndex, 0, points.Count - 1);
						break;
					case PatrolType.Circular:
						targetIndex %= points.Count;
						if (targetIndex < 0)
						{
							targetIndex = points.Count + targetIndex;
						}
						break;
					case PatrolType.BackForth:
					{
						int value = targetIndex % (points.Count - 1);
						value = Mathf.Abs(value);
						StepSize = -StepSize;
						if (IsOdd(targetIndex / points.Count))
						{
							targetIndex = points.Count - 1 - value;
						}
						else
						{
							targetIndex = value;
						}
						break;
					}
					}
				}
			}
			targetIndex = Mathf.Clamp(targetIndex, 0, points.Count - 1);
			return points[targetIndex];
		}

		protected override void OnDrawGizmos()
		{
			base.OnDrawGizmos();
			if (enableVisualization && pathConnector != null && points != null && targetIndex < points.Count && targetIndex >= 0)
			{
				circleGizmo.Color = targetColor;
				if ((Follow.UseSensorProjection && aimContext.Sensor.Sensor.ProjectionMode == VectorProjectionType.PlaneXZ) || Follow.VectorProjection == VectorProjectionType.PlaneXZ)
				{
					circleGizmo.Draw(points[targetIndex], Quaternion.Euler(90f, 0f, 0f), TargetRadius);
				}
				else
				{
					circleGizmo.Draw(points[targetIndex], Quaternion.Euler(0f, 0f, 0f), TargetRadius);
				}
			}
		}

		protected override void OnPathChange()
		{
			if (!(PathConnector != null))
			{
				return;
			}
			points = PathConnector.GetPoints();
			if (points.Count > 0)
			{
				projectedPosition = base.transform.position;
				if (Follow.VectorProjection == VectorProjectionType.PlaneXY)
				{
					projectedPosition.z = points[0].z;
				}
				else if (Follow.VectorProjection == VectorProjectionType.PlaneXZ)
				{
					projectedPosition.y = points[0].y;
				}
				if (Vector3.Distance(points[0], projectedPosition) < TargetRadius)
				{
					targetIndex = 1;
				}
			}
		}

		private bool IsOdd(int value)
		{
			return value % 2 != 0;
		}
	}
}
