using Civil;
using UnityEngine;

public class BuildingEnterence : MonoBehaviour
{
	[SerializeField]
	private Waypoint m_NextWaypoint;

	[SerializeField]
	private Waypoint m_PreviousWaypoint;

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

	public Waypoint GetWaypoint(bool forward)
	{
		return null;
	}
}
