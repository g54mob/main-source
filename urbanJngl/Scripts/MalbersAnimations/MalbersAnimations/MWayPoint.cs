using System.Collections.Generic;
using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/AI/Waypoint")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/ai/mwaypoint")]
	public class MWayPoint : MonoBehaviour, IWayPoint, IAITarget, IObjectCore
	{
		public static List<MWayPoint> WayPoints;

		public WayPointType pointType;

		[Tooltip("Distance for AI driven animals to stop when arriving to this gameobject. When is set as the AI Target.")]
		[Min(0f)]
		public float stoppingDistance = 1f;

		[Tooltip("Distance for AI driven animals to start slowing its speed when arriving to this gameobject. If its set to zero or lesser than the Stopping distance, the Slowing Movement Logic will be ignored")]
		[Min(0f)]
		public float slowingDistance;

		[Tooltip(" When the AI animal arrives to the target, do we Rotate the Animal so it looks at the center of the waypoint?")]
		[SerializeField]
		private bool m_arriveLookAt;

		[Tooltip("Default Height for the Waypoints")]
		[Min(0f)]
		[SerializeField]
		private float m_height = 0.5f;

		[MinMaxRange(0f, 60f)]
		[Tooltip("Waytime range to go to the next destination")]
		public RangedFloat m_WaitTime = new RangedFloat(1f, 5f);

		public Color DebugColor = Color.red;

		[SerializeField]
		protected List<Transform> nextWayPoints;

		[Space]
		public GameObjectEvent OnTargetArrived = new GameObjectEvent();

		public float Height => m_height;

		public float WaitTime => m_WaitTime.RandomValue;

		public WayPointType TargetType => pointType;

		public Transform WPTransform => base.transform;

		public List<Transform> NextTargets
		{
			get
			{
				return nextWayPoints;
			}
			set
			{
				nextWayPoints = value;
			}
		}

		public bool ArriveLookAt => m_arriveLookAt;

		public int CurrentTargetLimit { get; set; }

		Transform IAITarget.transform => base.transform;

		Transform IObjectCore.transform => base.transform;

		public virtual Vector3 GetCenterPosition(int Index)
		{
			return base.transform.position;
		}

		public virtual Vector3 GetCenterPosition()
		{
			return base.transform.position;
		}

		public Vector3 GetCenterY()
		{
			return base.transform.position + base.transform.up * Height;
		}

		public virtual float StopDistance()
		{
			return stoppingDistance * base.transform.localScale.y;
		}

		public virtual float SlowDistance()
		{
			return slowingDistance * base.transform.localScale.y;
		}

		protected virtual void OnEnable()
		{
			if (WayPoints == null)
			{
				WayPoints = new List<MWayPoint>();
			}
			WayPoints.Add(this);
		}

		protected virtual void OnDisable()
		{
			WayPoints.Remove(this);
		}

		public virtual void TargetArrived(GameObject target)
		{
			OnTargetArrived.Invoke(target);
		}

		public virtual Transform NextTarget()
		{
			Transform transform = ((NextTargets.Count > 0) ? NextTargets[Random.Range(0, NextTargets.Count)] : null);
			if (transform != null && !transform.gameObject.activeInHierarchy)
			{
				transform = null;
			}
			return transform;
		}

		public static Transform GetWaypoint()
		{
			if (WayPoints == null || WayPoints.Count <= 1)
			{
				return null;
			}
			return WayPoints[Random.Range(0, WayPoints.Count)].WPTransform;
		}

		public static Transform GetWaypoint(WayPointType pointType)
		{
			if (WayPoints != null && WayPoints.Count > 1)
			{
				MWayPoint mWayPoint = WayPoints.Find((MWayPoint item) => item.pointType == pointType);
				if (!mWayPoint)
				{
					return null;
				}
				return mWayPoint.WPTransform;
			}
			return null;
		}

		public float GetRadiusTargeter(int index)
		{
			return StopDistance();
		}
	}
}
