using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUISpaceshipController : GPUIInputHandler
	{
		public float engineTorque = 1500f;

		public float enginePower = 4500f;

		private Rigidbody shipRigidbody;

		private float rollInput;

		private float thrustInput;

		private float pitchInput;

		private float yawInput;

		private ParticleSystem.EmissionModule engineThrusterEmission;

		private ParticleSystem.EmissionModule engineGlowEmission;

		private Light engineGlowLight;

		private float originalThrusterEmissionRate;

		private float originalGlowEmissionRate;

		private void Awake()
		{
			shipRigidbody = GetComponent<Rigidbody>();
			engineThrusterEmission = base.transform.GetChild(0).GetComponent<ParticleSystem>().emission;
			originalThrusterEmissionRate = engineThrusterEmission.rateOverTime.constant;
			engineGlowEmission = base.transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>()
				.emission;
			originalGlowEmissionRate = engineGlowEmission.rateOverTime.constant;
			Transform transform = base.transform.Find("EngineGlowLight");
			if ((bool)transform)
			{
				engineGlowLight = transform.GetComponent<Light>();
			}
		}

		private void FixedUpdate()
		{
			GetInputs();
			Move();
			AdjustThrusterEffects();
		}

		private void GetInputs()
		{
			yawInput = GetAxis("Horizontal");
			thrustInput = GetAxis("Jump");
			pitchInput = GetAxis("Vertical");
			rollInput = (GetKey(KeyCode.Q) ? 1f : (GetKey(KeyCode.E) ? (-1f) : 0f));
		}

		private void Move()
		{
			shipRigidbody.AddRelativeTorque(Vector3.up * yawInput * engineTorque * Time.deltaTime);
			shipRigidbody.AddRelativeTorque(Vector3.right * pitchInput * engineTorque * Time.deltaTime);
			shipRigidbody.AddRelativeTorque(Vector3.forward * rollInput * engineTorque * Time.deltaTime);
			shipRigidbody.AddRelativeForce(Vector3.forward * thrustInput * enginePower * Time.deltaTime);
		}

		private void AdjustThrusterEffects()
		{
			engineThrusterEmission.rateOverTime = originalThrusterEmissionRate * thrustInput;
			engineGlowEmission.rateOverTime = Mathf.Lerp(0.5f * originalGlowEmissionRate, originalGlowEmissionRate, thrustInput);
			if ((bool)engineGlowLight)
			{
				engineGlowLight.intensity = Mathf.Clamp01(0.5f + thrustInput);
			}
		}
	}
}
