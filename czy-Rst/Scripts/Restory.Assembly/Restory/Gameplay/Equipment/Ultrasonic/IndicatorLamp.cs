using DG.Tweening;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public class IndicatorLamp : MonoBehaviour
	{
		[SerializeField]
		private GameObject lampObject;

		[SerializeField]
		private Light lampLight;

		public void ToggleLamp(bool isActive)
		{
			lampObject.SetActive(isActive);
		}

		public void SetLampColor(Color color)
		{
			lampLight.color = color;
		}

		public Tween TweenLampColor(Color color, float duration)
		{
			return lampLight.DOColor(color, duration);
		}
	}
}
