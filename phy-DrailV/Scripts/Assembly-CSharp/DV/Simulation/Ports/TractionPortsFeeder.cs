using System;
using DV.Wheels;
using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Ports
{
	public class TractionPortsFeeder : MonoBehaviour
	{
		[PortId(null, null, true)]
		public string forwardSpeedPortId;

		[PortId(null, null, true)]
		public string wheelRpmPortId;

		[PortId(null, null, true)]
		public string wheelSpeedKmhPortId;

		private Port wheelSpeedKmhPort;

		private Port wheelRpmPort;

		private Port forwardSpeedPort;

		private TrainCar car;

		[NonSerialized]
		public float wheelRpm;

		private float wheelRpmRefVel;

		private float speedMsToWheelRpmConst;

		private float wheelRpmToSpeedKmhConst;

		public void Init(TrainCar car, SimulationFlow simFlow)
		{
			this.car = car;
			float num = 2f * car.carLivery.parentType.wheelRadius * (float)Math.PI;
			speedMsToWheelRpmConst = 60f / num;
			wheelRpmToSpeedKmhConst = 1f / speedMsToWheelRpmConst * 3.6f;
			if (!simFlow.TryGetPort(forwardSpeedPortId, out forwardSpeedPort) || !simFlow.TryGetPort(wheelRpmPortId, out wheelRpmPort) || !simFlow.TryGetPort(wheelSpeedKmhPortId, out wheelSpeedKmhPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: TractionPortsFeeder isn't initialized properly! Destroying self", this);
				UnityEngine.Object.Destroy(this);
			}
		}

		public void Tick(float deltaTime)
		{
			float num = car.GetForwardSpeed();
			if (Mathf.Abs(num) < 0.001f)
			{
				num = 0f;
			}
			float num2 = num * speedMsToWheelRpmConst;
			AdhesionController adhesionController = car.adhesionController;
			if (adhesionController != null)
			{
				WheelslipController value;
				if (adhesionController.wheelSlide > 0f)
				{
					num2 = Mathf.Lerp(num2, 0f, adhesionController.wheelSlide);
				}
				else if (adhesionController.wheelslipController.IsSome(out value) && value.wheelslip > 0f)
				{
					num2 = Mathf.Lerp(num2, value.OrientedMaxWheelslipRpm, value.wheelslip);
				}
			}
			wheelRpm = Mathf.SmoothDamp(wheelRpm, num2, ref wheelRpmRefVel, 0.2f, float.PositiveInfinity, deltaTime);
			float num3 = Mathf.Abs(wheelRpm);
			if (num3 < 0.01f && num3 > 0f && num2 == 0f)
			{
				wheelRpm = 0f;
				wheelRpmRefVel = 0f;
			}
			forwardSpeedPort?.ExternalValueUpdate(num);
			wheelRpmPort?.ExternalValueUpdate(wheelRpm);
			wheelSpeedKmhPort?.ExternalValueUpdate(wheelRpm * wheelRpmToSpeedKmhConst);
		}
	}
}
