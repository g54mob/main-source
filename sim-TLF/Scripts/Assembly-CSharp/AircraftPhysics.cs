using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AircraftPhysics : MonoBehaviour
{
	private const float PREDICTION_TIMESTEP_FRACTION = 0.5f;

	[Header("Legacy Thrust (використовується якщо Engine не призначений)")]
	[SerializeField]
	private float thrust;

	[Header("Aerodynamics")]
	[SerializeField]
	private List<AeroSurface> aerodynamicSurfaces;

	[Header("Engine Integration (опціонально)")]
	[SerializeField]
	private EngineComponent engine;

	[Tooltip("Максимальна тяга двигуна в Ньютонах при 100% RPM")]
	[SerializeField]
	private float maxEngineThrustN = 50000f;

	[Tooltip("Якщо true — тяга рахується через Power/velocity (реалістично).\nЯкщо false — thrust = maxEngineThrustN * NormalizedRPM (просто).")]
	[SerializeField]
	private bool usePhysicalThrustModel;

	[Tooltip("ККД гвинта (використовується тільки при usePhysicalThrustModel = true)")]
	[SerializeField]
	private float propellerEfficiency = 0.85f;

	[Tooltip("Мінімальна швидкість для знаменника при фізичній моделі (уникає div/0)")]
	[SerializeField]
	private float minAirspeedForThrust = 5f;

	private Rigidbody rb;

	private float thrustPercent;

	private BiVector3 currentForceAndTorque;

	public float CurrentThrustN { get; private set; }

	public bool UsingEngine
	{
		get
		{
			if (engine != null)
			{
				return engine.IsRunning;
			}
			return false;
		}
	}

	public void SetThrustPercent(float percent)
	{
		thrustPercent = percent;
	}

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		Vector3 vector = CalculateThrustForce();
		CurrentThrustN = vector.magnitude;
		BiVector3 biVector = CalculateAerodynamicForces(rb.linearVelocity, rb.angularVelocity, Vector3.zero, 1.2f, rb.worldCenterOfMass);
		Vector3 velocity = PredictVelocity(biVector.p + vector + Physics.gravity * rb.mass);
		Vector3 angularVelocity = PredictAngularVelocity(biVector.q);
		BiVector3 biVector2 = CalculateAerodynamicForces(velocity, angularVelocity, Vector3.zero, 1.2f, rb.worldCenterOfMass);
		currentForceAndTorque = (biVector + biVector2) * 0.5f;
		rb.AddForce(currentForceAndTorque.p);
		rb.AddTorque(currentForceAndTorque.q);
		rb.AddForce(vector);
	}

	private Vector3 CalculateThrustForce()
	{
		if (engine != null && engine.IsRunning)
		{
			float num = (usePhysicalThrustModel ? CalculatePhysicalThrust() : CalculateSimpleThrust());
			return base.transform.forward * num;
		}
		return base.transform.forward * thrust * thrustPercent;
	}

	private float CalculateSimpleThrust()
	{
		return maxEngineThrustN * engine.NormalizedRPM;
	}

	private float CalculatePhysicalThrust()
	{
		float num = engine.Power * 1000f;
		float num2 = Mathf.Max(rb.linearVelocity.magnitude, minAirspeedForThrust);
		return propellerEfficiency * num / num2;
	}

	private BiVector3 CalculateAerodynamicForces(Vector3 velocity, Vector3 angularVelocity, Vector3 wind, float airDensity, Vector3 centerOfMass)
	{
		BiVector3 result = default(BiVector3);
		foreach (AeroSurface aerodynamicSurface in aerodynamicSurfaces)
		{
			Vector3 vector = aerodynamicSurface.transform.position - centerOfMass;
			result += aerodynamicSurface.CalculateForces(-velocity + wind - Vector3.Cross(angularVelocity, vector), airDensity, vector);
		}
		return result;
	}

	private Vector3 PredictVelocity(Vector3 force)
	{
		return rb.linearVelocity + Time.fixedDeltaTime * 0.5f * force / rb.mass;
	}

	private Vector3 PredictAngularVelocity(Vector3 torque)
	{
		Quaternion quaternion = rb.rotation * rb.inertiaTensorRotation;
		Vector3 vector = Quaternion.Inverse(quaternion) * torque;
		Vector3 vector2 = default(Vector3);
		vector2.x = vector.x / rb.inertiaTensor.x;
		vector2.y = vector.y / rb.inertiaTensor.y;
		vector2.z = vector.z / rb.inertiaTensor.z;
		return rb.angularVelocity + Time.fixedDeltaTime * 0.5f * (quaternion * vector2);
	}
}
