using Civil;
using UnityEngine;

[RequireComponent(typeof(NPC))]
public class WaypointNavigator : MonoBehaviour
{
	private Waypoint m_CurrentWaypoint;

	private NPC m_Npc;

	private bool m_TravelForward;

	private bool m_FinishTravel;

	private int m_TripLength;

	private int m_CurrentTripLength;

	private float m_MaxVisibilityDistance;

	private Transform m_PlayerTransform;

	public NPC M_Npc => null;

	private bool m_EndOfRoute => false;

	private void Awake()
	{
	}

	public void ManualUpdate()
	{
	}

	public void SetupTravel(Waypoint waypoint, bool forward, int waypointTravelCount, float speed, Transform playerTransform, float maxVisibilityDistance)
	{
	}

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
	}

	private void OnLocalPlayerUpdated(PlayerInstance _instance)
	{
	}

	public void ReachedWaypoint(bool VisitRestaurant = true)
	{
	}

	private bool CheckToFinishTravel()
	{
		return false;
	}

	private void FinishTravel(Vector3 buildingEnterence)
	{
	}

	private void SelectNextWaypoint()
	{
	}
}
