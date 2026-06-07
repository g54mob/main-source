using System;
using DV.ECS.Train;
using DV.Simulation.Cars;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Wheels
{
	public class WheelslipController : MonoBehaviour
	{
		public bool preventWheelslip;

		public AnimationCurve wheelslipToAdhesionDrop;

		public float maxWheelslipRpm = 600f;

		[PortId(PortValueType.GENERIC, false)]
		public string numberOfPoweredAxlesPortId;

		[PortId(PortValueType.STATE, false)]
		public string sandCoefPortId;

		[PortId(PortValueType.STATE, false)]
		public string engineBrakingActivePortId;

		private Port numberOfPoweredAxlesPort;

		private Port sandCoefPort;

		private Port engineBrakingActivePort;

		private TrainCar car;

		public bool IsEngineBraking
		{
			get
			{
				Port port = engineBrakingActivePort;
				if (port == null)
				{
					return false;
				}
				return port.Value > 0f;
			}
		}

		public float SandCoef => sandCoefPort?.Value ?? 1f;

		public float wheelslip { get; private set; }

		public bool IsWheelslipping => wheelslip > 0f;

		public float OrientedMaxWheelslipRpm { get; private set; }

		public float TotalForceLimit { get; private set; }

		public float EngineBrakingForcePerAxle
		{
			get
			{
				if (!IsEngineBraking)
				{
					return 0f;
				}
				return Mathf.Abs(DrivingForce.generatedForce) / (float)NumberOfPoweredAxles;
			}
		}

		public int NumberOfPoweredAxles
		{
			get
			{
				if (numberOfPoweredAxlesPort != null)
				{
					return Mathf.RoundToInt(numberOfPoweredAxlesPort.Value);
				}
				return 2;
			}
		}

		public DrivingForce DrivingForce { get; private set; }

		public event Action<bool> WheelslipStateChanged;

		public void Init(TrainCar car, SimulationFlow simFlow, DrivingForce drivingForce)
		{
			this.car = car;
			DrivingForce = drivingForce;
			if (drivingForce == null)
			{
				Debug.LogError("Unexpected state: Couldn't find drivingForce, WheelslipController can't function. Destroying self");
				UnityEngine.Object.Destroy(this);
				return;
			}
			if (!simFlow.TryGetPort(numberOfPoweredAxlesPortId, out numberOfPoweredAxlesPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: WheelslipController isn't initialized properly!", this);
			}
			simFlow.TryGetPort(sandCoefPortId, out sandCoefPort, canBeNullOrEmpty: true);
			simFlow.TryGetPort(engineBrakingActivePortId, out engineBrakingActivePort, canBeNullOrEmpty: true);
			DirectDriveMaxWheelslipRpmCalculator component = GetComponent<DirectDriveMaxWheelslipRpmCalculator>();
			if (component != null)
			{
				component.Init(this, simFlow);
			}
		}

		public void ResetState()
		{
			wheelslip = 0f;
			OrientedMaxWheelslipRpm = 0f;
			TotalForceLimit = 0f;
			WheelslipControllerSystem.WheelslipOutputData componentData = car.entity.GetComponentData<WheelslipControllerSystem.WheelslipOutputData>();
			componentData.wheelslip = (componentData.wheelslipSmoothRefVel = (componentData.orientedMaxWheelslipRpm = (componentData.totalForceLimit = 0f)));
			car.entity.SetComponentData(componentData);
		}

		public void OverrideMaxWheelslipRpm(float rpm)
		{
			maxWheelslipRpm = rpm;
		}

		internal void ApplyWheelslip(float newWheelslip, float orientedMaxWheelslipRpm, float totalForceLimit)
		{
			TotalForceLimit = totalForceLimit;
			OrientedMaxWheelslipRpm = orientedMaxWheelslipRpm;
			float num = wheelslip;
			wheelslip = newWheelslip;
			if (num == 0f && newWheelslip > 0f)
			{
				this.WheelslipStateChanged?.Invoke(obj: true);
			}
			else if (num > 0f && newWheelslip == 0f)
			{
				this.WheelslipStateChanged?.Invoke(obj: false);
			}
		}
	}
}
