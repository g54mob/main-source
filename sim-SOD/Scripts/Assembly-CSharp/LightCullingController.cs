using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class LightCullingController : MonoBehaviour
{
	private struct LightRaycastData
	{
		public enum RayType
		{
			lightToCam = 0,
			lightToFeet = 1,
			lightToRadiusPoint = 2,
			radiusPointToCam = 3
		}

		public RayType rayType;

		public LightController lightRef;

		public Vector3 originPoint;

		public Vector3 direction;

		public float range;

		public LightRaycastData(LightController newLightRef, RayType newRayType, Vector3 newOriginPoint, Vector3 newDir, float newRange)
		{
			rayType = default(RayType);
			lightRef = null;
			originPoint = default(Vector3);
			direction = default(Vector3);
			range = 0f;
		}
	}

	[BurstCompile]
	private struct SetupCommandJob : IJobParallelFor
	{
		public NativeArray<RaycastCommand> commands;

		[ReadOnly]
		public NativeArray<Vector3> directions;

		[ReadOnly]
		public NativeArray<Vector3> origins;

		[ReadOnly]
		public NativeArray<float> ranges;

		public int mask;

		public void Execute(int index)
		{
		}
	}

	[Header("Settings")]
	public int lightsToCheckPerFrame;

	[Tooltip("This is lerped depending on the range of the light. A range of 20 represents the maximum value")]
	public Vector2 radiusChecksPerLight;

	[Tooltip("When NOT culled, lights are active for a minimum time to avoid a flickering effect due to frequent checking. This value is in GAMETIME")]
	public float minimumLightUnculledTime;

	public List<LightController> lightsToCheck;

	public int checkingCursor;

	private List<LightController> lightsCheckedThisFrame;

	public List<LightController> culledLights;

	private JobHandle handlePrimary;

	private NativeArray<RaycastHit> resultsPrimary;

	private NativeArray<RaycastCommand> commandsPrimary;

	private NativeArray<Vector3> originsPrimary;

	private NativeArray<Vector3> directionsPrimary;

	private NativeArray<float> rangePrimary;

	private bool primaryJobsActive;

	private bool primaryJobsCompleted;

	private JobHandle handleSecondary;

	private NativeArray<RaycastHit> resultsSecondary;

	private NativeArray<RaycastCommand> commandsSecondary;

	private NativeArray<Vector3> originsSecondary;

	private NativeArray<Vector3> directionsSecondary;

	private NativeArray<float> rangeSecondary;

	private bool secondaryJobsActive;

	private bool secondaryJobsCompleted;

	private List<LightController> notCulled;

	private List<LightRaycastData> lightRaycastDataCollectionFromRadius;

	private List<LightRaycastData> lightRaycastDataCollection;

	private static LightCullingController _instance;

	public static LightCullingController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}
}
