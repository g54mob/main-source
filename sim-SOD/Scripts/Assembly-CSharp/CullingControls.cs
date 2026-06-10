using UnityEngine;

public class CullingControls : MonoBehaviour
{
	[Tooltip("The angle which you can see other buildings")]
	[Header("FoVs")]
	public float visibleBuildingFoV;

	[Tooltip("The angle which you can see other rooms from entrances")]
	public float visibleRoomFoV;

	[Header("Distances")]
	public float fromOutsideToInsideDistanceMax;

	public float fromInsideToInsideDistanceMax;

	[Space(7f)]
	public float outsideDistanceMax;

	[Tooltip("Boost the above by lerping the below by floor height (floor 16 max)")]
	public Vector2 outsideHeightDistanceBoost;

	[Tooltip("Distance within which rooms are drawn through windows")]
	[Space(7f)]
	public float windowCullingRange;

	[Tooltip("Distance within which rooms are drawn through open doors")]
	public float doorCullingRange;

	[Tooltip("Distance within which exterior air ducts are rendered")]
	public float exteriorDuctCullingRange;

	[Tooltip("Distance within which connected rooms are drawn when inside a duct")]
	public float ductRoomCullingRange;

	[Header("Air Ducts")]
	public float airDuctLODThreshold;

	private static CullingControls _instance;

	public static CullingControls Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}
}
