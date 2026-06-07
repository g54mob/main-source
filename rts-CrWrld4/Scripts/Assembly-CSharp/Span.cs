using UnityEngine;

public class Span : MonoBehaviour
{
	public GameSpace.CATEGORY category;

	public Camera mainCamera;

	public Transform planetPlane;

	public GameObject unselectText;

	private Vector3 panMouseDown;

	private Vector3 panStartPos;

	public SpanNetworkPlanet[] planets;

	public SpanStar[] stars;

	public GalaxyMissionPanel gmp;

	public GameObject planetLockedPane;

	public GameObject startHere;

	private SpanNetworkPlanet selectedPlanet;

	private float moveX;

	private float moveZ;

	public void Start()
	{
	}

	private void UnselectAllPlanets()
	{
	}

	public SpanNetworkPlanet GetPlanet(string guid)
	{
		return null;
	}

	public SpanStar GetStar(string guid)
	{
		return null;
	}

	public void SelectPlanet(SpanNetworkPlanet planet)
	{
	}

	public void UnselectPlanet()
	{
	}

	public void OnCenterView()
	{
	}

	private bool RayCastUI()
	{
		return false;
	}

	private bool IsOverBlockingUI()
	{
		return false;
	}

	public void Update()
	{
	}

	private void PositionGMP()
	{
	}

	private void SetMission(SpanNetworkPlanet planet)
	{
	}

	private Vector3 GetBasePixelUnderMouse()
	{
		return default(Vector3);
	}
}
