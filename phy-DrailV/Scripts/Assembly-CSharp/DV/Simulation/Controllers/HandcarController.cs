using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class HandcarController : ASimInitializedController
	{
		private const float NEUTRAL_TO_END_POSITION_NORMALIZED_ANIM_TIME = 0.25f;

		public Animator handlebarAnimator;

		public Transform visualHandlebar;

		[PortId(PortType.READONLY_OUT, PortValueType.STATE, true)]
		public string directionPortId;

		[PortId(PortType.READONLY_OUT, PortValueType.STATE, true)]
		public string currentPositionPortId;

		private TrainCar car;

		private Port directionPort;

		private Port currentPositionPort;

		private int crankAnimParameter;

		public override bool ExternalTick => true;

		public float VisualHandlebarRotationX
		{
			get
			{
				float num = visualHandlebar.localEulerAngles.x;
				if (num > 180f)
				{
					num -= 360f;
				}
				if (num <= -180f)
				{
					num += 360f;
				}
				return num;
			}
		}

		public override void Init(TrainCar car, SimulationFlow simFlow)
		{
			this.car = car;
			if (handlebarAnimator == null)
			{
				Debug.LogError("Unexpected state: handlebarAnimator is null. Destroying self");
				Object.Destroy(this);
				return;
			}
			if (!simFlow.TryGetPort(directionPortId, out directionPort) || !simFlow.TryGetPort(currentPositionPortId, out currentPositionPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: ClapperController isn't initialized properly! Destroying self");
				Object.Destroy(this);
				return;
			}
			crankAnimParameter = Animator.StringToHash("crank");
			UpdateWheelslipPrevention();
			car.OnDerailed += OnDerailed;
			car.OnRerailed += OnRerailed;
		}

		public override void Tick(float deltaTime)
		{
			float value = currentPositionPort.Value;
			float num = ((directionPort.Value > 0f) ? (0.25f + (1f - Mathf.Abs(value)) * 0.25f) : (Mathf.Abs(value) * 0.25f));
			if (value < 0f)
			{
				num = 1f - num;
			}
			handlebarAnimator.SetFloat(crankAnimParameter, num);
		}

		private void OnDerailed(TrainCar _)
		{
			UpdateWheelslipPrevention();
		}

		private void OnRerailed()
		{
			UpdateWheelslipPrevention();
		}

		private void UpdateWheelslipPrevention()
		{
			if (car.adhesionController != null && car.adhesionController.wheelslipController.IsSome(out var value))
			{
				value.preventWheelslip = !car.derailed;
			}
		}
	}
}
