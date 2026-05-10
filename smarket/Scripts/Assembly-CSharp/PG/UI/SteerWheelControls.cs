using UnityEngine;

namespace PG.UI
{
	public class SteerWheelControls : BaseControls
	{
		public SteerWheelUI SteerWheelUI;

		[Header("Buttons")]
		public ButtonCustom AccelerationBtn;

		public ButtonCustom BrakeReverseBtn;

		public ButtonCustom HandBrakeBtn;

		public ButtonCustom BoostBtn;

		public override void Init(CarControllerInput userInput)
		{
		}

		private void Update()
		{
		}
	}
}
