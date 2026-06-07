using System;
using UnityEngine;

namespace DV.Wheels
{
	public class WheelRotationBase : MonoBehaviour
	{
		protected const float ROTATIONS_PER_S_TO_DEGREES_PER_S = 360f;

		public float wheelRadius = 0.7f;

		public bool affectedByWheelSlide = true;

		protected TrainCar trainCar;

		private float wheelCircumference;

		protected virtual void Awake()
		{
			trainCar = GetComponentInParent<TrainCar>();
			trainCar.MovementStateChanged += OnMovementStateChanged;
			base.enabled = !trainCar.isEligibleForSleep;
		}

		protected virtual void Start()
		{
			wheelCircumference = 2f * wheelRadius * (float)Math.PI;
		}

		private void OnMovementStateChanged(bool isMoving)
		{
			base.enabled = isMoving;
		}

		protected virtual float GetRPS()
		{
			float num = trainCar.GetForwardSpeed();
			if (Mathf.Abs(num) < 0.005f)
			{
				num = 0f;
			}
			float num2 = num / wheelCircumference;
			if (affectedByWheelSlide && trainCar.adhesionController != null && trainCar.adhesionController.wheelSlide > 0f)
			{
				num2 = Mathf.Lerp(num2, 0f, trainCar.adhesionController.wheelSlide);
			}
			return num2;
		}
	}
}
