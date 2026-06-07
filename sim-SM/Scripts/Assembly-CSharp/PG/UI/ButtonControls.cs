using UnityEngine;

namespace PG.UI
{
	public class ButtonControls : BaseControls
	{
		[Header("Buttons")]
		public ButtonCustom AccelerationBtn;

		public ButtonCustom BrakeReverseBtn;

		public ButtonCustom LeftSteerBtn;

		public ButtonCustom RightSteerBtn;

		public ButtonCustom HandBrakeBtn;

		public ButtonCustom BoostBtn;

		public override void Init(CarControllerInput userInput)
		{
		}
	}
}
