using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Wheels
{
	public class DirectDriveMaxWheelslipRpmCalculator : MonoBehaviour
	{
		[PortId(PortValueType.RPM, false)]
		public string engineRpmMaxPortId;

		[PortId(PortValueType.GENERIC, false)]
		public string gearRatioPortId;

		private Port engineRpmMaxPort;

		private Port gearRatioPort;

		private WheelslipController wheelslipController;

		public void Init(WheelslipController wheelslipController, SimulationFlow simFlow)
		{
			this.wheelslipController = wheelslipController;
			if (!simFlow.TryGetPort(engineRpmMaxPortId, out engineRpmMaxPort) || !simFlow.TryGetPort(gearRatioPortId, out gearRatioPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: DirectDriveMaxWheelslipRpmCalculator isn't initialized properly. Destroying self", base.gameObject);
				Object.Destroy(this);
			}
			else
			{
				UpdateMaxWheelslipRpm();
				gearRatioPort.ValueUpdatedInternally += UpdateMaxWheelslipRpm;
				engineRpmMaxPort.ValueUpdatedInternally += UpdateMaxWheelslipRpm;
			}
		}

		private void OnDestroy()
		{
			if (gearRatioPort != null)
			{
				gearRatioPort.ValueUpdatedInternally -= UpdateMaxWheelslipRpm;
			}
			if (engineRpmMaxPort != null)
			{
				engineRpmMaxPort.ValueUpdatedInternally -= UpdateMaxWheelslipRpm;
			}
		}

		private void UpdateMaxWheelslipRpm(float _ = 0f)
		{
			float rpm = engineRpmMaxPort.Value / gearRatioPort.Value;
			wheelslipController.OverrideMaxWheelslipRpm(rpm);
		}
	}
}
