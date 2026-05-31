using UnityEngine;
using UnityEngine.EventSystems;

namespace PG.UI
{
	public class SteerWheelUI : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		public float MaxSteerWheelAngle;

		public float SteerWheelToDefaultSpeed;

		private float CurrentSteerAngle;

		private bool WheelIsPressed;

		private Vector2 PrevTouchPos;

		public float HorizontalControl { get; private set; }

		public CarControllerInput UserInput { get; set; }

		private CarController Car => null;

		public void Init(CarControllerInput userInput)
		{
		}

		private void Update()
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}
	}
}
