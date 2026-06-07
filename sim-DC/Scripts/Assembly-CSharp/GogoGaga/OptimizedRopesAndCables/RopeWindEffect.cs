using UnityEngine;

namespace GogoGaga.OptimizedRopesAndCables
{
	[RequireComponent(typeof(Rope))]
	public class RopeWindEffect : MonoBehaviour
	{
		[Header("Wind Settings")]
		[Tooltip("Set wind direction perpendicular to the rope based on the start and end points")]
		public bool perpendicularWind;

		[Tooltip("Flip the direction of the wind")]
		public bool flipWindDirection;

		[Tooltip("Direction of the wind force in degrees")]
		[Range(-360f, 360f)]
		public float windDirectionDegrees;

		private Vector3 windDirection;

		[Tooltip("Magnitude of the wind force")]
		[Range(0f, 500f)]
		public float windForce;

		private float appliedWindForce;

		private float windSeed;

		private Rope rope;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		private void GenerateWind()
		{
		}

		private void SimulatePhysics()
		{
		}
	}
}
