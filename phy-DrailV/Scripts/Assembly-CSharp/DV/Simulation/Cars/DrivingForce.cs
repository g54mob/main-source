using System;
using DV.Utils;
using DV.Wheels;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public class DrivingForce : MonoBehaviour
	{
		[PortId(PortValueType.TORQUE, true)]
		public string torqueGeneratedPortId;

		[NonSerialized]
		public float generatedForce;

		private Port torqueGeneratedPort;

		private TrainCar train;

		private float wheelRadius;

		public void Init(TrainCar train, SimulationFlow simFlow)
		{
			this.train = train;
			wheelRadius = train.carLivery.parentType.wheelRadius;
			if (!simFlow.TryGetPort(torqueGeneratedPortId, out torqueGeneratedPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: DrivingForce Sim won't apply any force.", this);
				base.enabled = false;
			}
		}

		private void FixedUpdate()
		{
			if (SingletonBehaviour<PausePhysicsHandler>.Instance.PhysicsHandlingInProcess)
			{
				return;
			}
			generatedForce = torqueGeneratedPort.Value / wheelRadius;
			float num = generatedForce;
			AdhesionController adhesionController = train.adhesionController;
			bool flag = false;
			if (adhesionController != null)
			{
				WheelslipController value;
				if (adhesionController.wheelSlide > 0f)
				{
					num = 0f;
				}
				else if (adhesionController.wheelslipController.IsSome(out value) && value.wheelslip > 0f)
				{
					flag = true;
					float num2 = ((!train.derailed) ? (train.RearBogie.brakingForce * (float)train.Bogies.Length) : (train.brakeSystem.brakingFactor * train.RearBogie.maxBrakingForcePerKg * train.massController.TotalBogiesMass));
					num = Mathf.Sign(num) * Mathf.Clamp(Mathf.Abs(num) - num2, 0f, float.PositiveInfinity);
				}
				WheelslipController value2;
				float num3 = (adhesionController.wheelslipController.IsSome(out value2) ? value2.TotalForceLimit : float.MaxValue);
				num = Mathf.Clamp(num, 0f - num3, num3);
			}
			if (num == 0f)
			{
				return;
			}
			if (!train.derailed)
			{
				if (train.isEligibleForSleep)
				{
					train.ForceOptimizationState(sleep: false);
				}
				float num4 = num / (float)train.Bogies.Length;
				Bogie[] bogies = train.Bogies;
				foreach (Bogie bogie in bogies)
				{
					if (bogie.enabled)
					{
						bogie.rb.AddForce(bogie.transform.forward * num4);
					}
				}
			}
			else if (train.groundFriction.IsGrounded)
			{
				if (train.isEligibleForSleep)
				{
					train.ForceOptimizationState(sleep: false);
				}
				float num5 = 0f;
				if (!flag)
				{
					num5 = train.brakeSystem.brakingFactor * train.RearBogie.maxBrakingForcePerKg * train.massController.TotalBogiesMass;
				}
				num = Mathf.Sign(num) * Mathf.Clamp(Mathf.Abs(num) - num5, 0f, float.PositiveInfinity);
				train.rb.AddForce(train.transform.forward * num);
			}
		}
	}
}
