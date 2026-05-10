using UnityEngine;

namespace PG.UI
{
	public class AccelerometerControls : BaseControls
	{
		[Header("Accelerometer settings")]
		public float DeadZone;

		public float MaxAngle;

		public float AccelerometerLerpSpeed;

		[Header("Buttons")]
		public ButtonCustom AccelerationBtn;

		public ButtonCustom BrakeReverseBtn;

		public ButtonCustom HandBrakeBtn;

		public ButtonCustom BoostBtn;

		private float HorizontalAxis;

		private CarController Car => null;

		public override void Init(CarControllerInput userInput)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnApplicationFocus(bool focus)
		{
		}

		private void Update()
		{
		}
	}
}
