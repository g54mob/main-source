using FIMSpace.Basics;
using UnityEngine;
using UnityEngine.UI;

namespace FIMSpace.FProceduralAnimation
{
	public class DEMO_FCameraZoom : MonoBehaviour
	{
		public Fimp_JoyCamera CameraScript;

		public Slider OptionalSlider;

		public Vector2 MinMaxRange = new Vector2(2f, 8f);

		private float targetValue = 0.5f;

		private float animatedValue = 0.5f;

		private float _sd_animVal;

		private void Start()
		{
			if ((bool)OptionalSlider)
			{
				OptionalSlider.value = targetValue;
			}
		}

		private void Update()
		{
			if ((bool)OptionalSlider)
			{
				targetValue = OptionalSlider.value;
			}
			targetValue -= Input.GetAxis("Mouse ScrollWheel") * 1f;
			targetValue = Mathf.Clamp01(targetValue);
			animatedValue = Mathf.SmoothDamp(animatedValue, targetValue, ref _sd_animVal, 0.05f, 10f, Time.unscaledDeltaTime);
			CameraScript.DistanceOffset = Mathf.Lerp(MinMaxRange.x, MinMaxRange.y, animatedValue);
			if ((bool)OptionalSlider)
			{
				OptionalSlider.value = targetValue;
			}
		}
	}
}
