using System.Collections.Generic;
using UnityEngine;

namespace Civil
{
	public class Waypoint : MonoBehaviour
	{
		[SerializeField]
		private Waypoint m_NextWaypoint;

		[SerializeField]
		private Waypoint m_PreviousWaypoint;

		[SerializeField]
		private List<Waypoint> m_IntersectionExits;

		[SerializeField]
		private BuildingEnterence m_NextBuildingEnterence;

		[SerializeField]
		private BuildingEnterence m_PreviousBuildingEnterence;

		[Range(0f, 5f)]
		[SerializeField]
		private float m_Width;

		[SerializeField]
		private bool m_IsIntersection;

		[SerializeField]
		private bool m_IsRestaurant;

		public Waypoint NextWaypoint
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Waypoint PreviousWaypoint
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<Waypoint> IntersectionExits => null;

		public float Width
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector3 GetPosition => default(Vector3);

		public BuildingEnterence NextBuildingEnterence
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BuildingEnterence PreviousBuildingEnterence
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsIntersection
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsRestaurant
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public List<Waypoint> IntersectionExitsBeside(Waypoint waypoint)
		{
			return null;
		}
	}
}
