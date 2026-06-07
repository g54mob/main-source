using Ezereal;
using UnityEngine;

namespace Brewery.Vehicle
{
	public class VehicleSurfaceTraction : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private EzerealCarController carController;

		[Header("Stiffness Multipliers")]
		[Tooltip("Forward friction stiffness on road surfaces (Asphalt / terrain road layers)")]
		[Range(0.5f, 2f)]
		[SerializeField]
		private float roadForwardStiffness;

		[Tooltip("Sideways friction stiffness on road surfaces")]
		[Range(0.5f, 2f)]
		[SerializeField]
		private float roadSidewaysStiffness;

		[Tooltip("Forward friction stiffness on off-road surfaces")]
		[Range(0.2f, 1.5f)]
		[SerializeField]
		private float offRoadForwardStiffness;

		[Tooltip("Sideways friction stiffness on off-road surfaces. Raise toward 1 to stop the rear end sliding on grass/dirt.")]
		[Range(0.2f, 1.5f)]
		[SerializeField]
		private float offRoadSidewaysStiffness;

		[Header("Terrain Surface Detection")]
		[Tooltip("Terrain layer indices that count as road (matches VehicleSkidController's gravel layers)")]
		[SerializeField]
		private int[] terrainRoadLayers;

		[Header("Transition")]
		[Tooltip("How quickly stiffness transitions between surfaces (higher = snappier)")]
		[Range(1f, 20f)]
		[SerializeField]
		private float transitionSpeed;

		[Tooltip("Seconds between surface detection raycasts")]
		[Range(0.05f, 0.3f)]
		[SerializeField]
		private float checkInterval;

		private WheelCollider[] wheels;

		private float[] targetForwardStiffness;

		private float[] targetSidewaysStiffness;

		private float[] currentForwardStiffness;

		private float[] currentSidewaysStiffness;

		private float[] baseForwardStiffness;

		private float[] baseSidewaysStiffness;

		private float lastCheckTime;

		private bool initialized;

		private void Start()
		{
		}

		private void FixedUpdate()
		{
		}

		private void DetectSurfaces()
		{
		}

		private void ApplyStiffness(int wheelIndex)
		{
		}
	}
}
