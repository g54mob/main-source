using System;
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
			rope = GetComponent<Rope>();
		}

		private void Start()
		{
			windSeed = UnityEngine.Random.Range(-0.3f, 0.3f);
		}

		private void Update()
		{
			GenerateWind();
		}

		private void FixedUpdate()
		{
			SimulatePhysics();
		}

		private void GenerateWind()
		{
			if (perpendicularWind)
			{
				Vector3 lhs = rope.EndPoint.position - rope.StartPoint.position;
				windDirection = Vector3.Cross(lhs, Vector3.up).normalized;
				float num = Mathf.PerlinNoise(Time.time + windSeed, 0f) * 20f - 10f;
				float num2 = Vector3.SignedAngle(Vector3.forward, windDirection, Vector3.up);
				float f = (num2 + num) * (MathF.PI / 180f);
				windDirection = new Vector3(Mathf.Sin(f), 0f, Mathf.Cos(f)).normalized;
				windDirectionDegrees = num2;
			}
			else
			{
				float num3 = Mathf.PerlinNoise(Time.time + windSeed, 0f) * 20f - 10f;
				float f2 = (windDirectionDegrees + num3) * (MathF.PI / 180f);
				windDirection = new Vector3(Mathf.Sin(f2), 0f, Mathf.Cos(f2)).normalized;
			}
			float num4 = Mathf.PerlinNoise(Time.time + windSeed, 0f) * Mathf.PerlinNoise(0.5f * Time.time, 0f);
			if (flipWindDirection)
			{
				appliedWindForce = windForce * -1f * 5f * num4;
			}
			else
			{
				appliedWindForce = windForce * 5f * num4;
			}
		}

		private void SimulatePhysics()
		{
			Vector3 otherPhysicsFactors = windDirection.normalized * appliedWindForce * Time.fixedDeltaTime;
			rope.otherPhysicsFactors = otherPhysicsFactors;
		}
	}
}
