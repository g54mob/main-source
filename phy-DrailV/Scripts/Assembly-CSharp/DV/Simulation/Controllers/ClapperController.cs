using System;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class ClapperController : ASimInitializedController
	{
		private const float IDLE_FREQUENCY = 3f;

		private const float MAX_FREQUENCY = 5f;

		private const float SMOOTH_TIME_ENG_RPM_MIN = 0.1f;

		private const float SMOOTH_TIME_ENG_RPM_MAX = 0.05f;

		private const float MAX_ANGLE_MAX = -90f;

		private const float MAX_ANGLE_MIN = -20f;

		private const float MIN_ANGLE_MAX = -85f;

		private const float MIN_ANGLE_MIN = 0f;

		public Transform clapperTransform;

		[PortId(PortValueType.RPM, true)]
		public string engineRpmNormalizedPortId;

		[PortId(PortValueType.STATE, true)]
		public string engineOnPortId;

		public float highestMaxAngleAtPercentage = 0.33f;

		public float highestMinAngleAtPercentage = 0.66f;

		private Port engineRpmNormalizedPort;

		private Port engineOnPort;

		private float clapperRefVelo;

		public override bool ExternalTick => true;

		public override void Init(TrainCar car, SimulationFlow simFlow)
		{
			if (clapperTransform == null)
			{
				Debug.LogError("Unexpected state: clapperTransform is null. Destroying self.", base.gameObject);
				UnityEngine.Object.Destroy(this);
			}
			else if (!simFlow.TryGetPort(engineRpmNormalizedPortId, out engineRpmNormalizedPort) || !simFlow.TryGetPort(engineOnPortId, out engineOnPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: ClapperController isn't initialized properly! Destroying self");
				UnityEngine.Object.Destroy(this);
			}
		}

		public override void Tick(float deltaTime)
		{
			if (!base.enabled)
			{
				return;
			}
			bool num = engineOnPort.Value > 0f;
			float z = clapperTransform.localRotation.eulerAngles.z;
			if (!num)
			{
				if (z > 0.0001f)
				{
					clapperTransform.localRotation = Quaternion.Euler(0f, 0f, Mathf.SmoothDampAngle(z, 0f, ref clapperRefVelo, 0.1f, float.PositiveInfinity, deltaTime));
				}
				return;
			}
			float value = engineRpmNormalizedPort.Value;
			float num2 = Mathf.Lerp(3f, 5f, value);
			float t = (Mathf.Sin(Time.time * num2 * 2f * (float)Math.PI) + 1f) / 2f;
			float smoothTime = Mathf.Lerp(0.1f, 0.05f, value);
			float a = Mathf.Lerp(0f, -85f, value / highestMinAngleAtPercentage);
			float b = Mathf.Lerp(-20f, -90f, value / highestMaxAngleAtPercentage);
			clapperTransform.localRotation = Quaternion.Euler(0f, 0f, Mathf.SmoothDampAngle(z, Mathf.Lerp(a, b, t), ref clapperRefVelo, smoothTime, float.PositiveInfinity, deltaTime));
		}
	}
}
