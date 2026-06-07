using System;
using DV.ECS.Train;

namespace DV.Wheels
{
	public class AdhesionController
	{
		public delegate void WheelSlideChanged(TrainCar car, bool wheelSliding);

		private readonly TrainCar car;

		public readonly Option<WheelslipController> wheelslipController;

		public float wheelSlide { get; private set; }

		public bool IsWheelSliding => wheelSlide > 0f;

		public static event WheelSlideChanged AnyWheelSlideStateChanged;

		public event Action<bool> WheelSlideStateChanged;

		public AdhesionController(TrainCar car)
		{
			this.car = car;
			wheelslipController = car.SimController?.wheelslipController;
		}

		public void ResetState()
		{
			wheelSlide = 0f;
			AdhesionControllerSystem.WheelSlideData componentData = car.entity.GetComponentData<AdhesionControllerSystem.WheelSlideData>();
			componentData.wheelSlide = (componentData.wheelSlideSmoothRefVel = 0f);
			car.entity.SetComponentData(componentData);
			if (wheelslipController.IsSome(out var value))
			{
				value.ResetState();
			}
		}

		internal void ApplyWheelSlide(float newWheelSlide)
		{
			float num = wheelSlide;
			wheelSlide = newWheelSlide;
			if (num == 0f && newWheelSlide > 0f)
			{
				InvokeWheelSlideStateChanged(isSliding: true);
			}
			else if (num > 0f && newWheelSlide == 0f)
			{
				InvokeWheelSlideStateChanged(isSliding: false);
			}
		}

		private void InvokeWheelSlideStateChanged(bool isSliding)
		{
			this.WheelSlideStateChanged?.Invoke(isSliding);
			AdhesionController.AnyWheelSlideStateChanged?.Invoke(car, isSliding);
		}
	}
}
