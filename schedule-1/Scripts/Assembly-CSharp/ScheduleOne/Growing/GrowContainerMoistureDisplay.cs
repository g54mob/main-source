using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.Growing
{
	public class GrowContainerMoistureDisplay : MonoBehaviour
	{
		public const float MaxCameraDistance = 2.5f;

		public const float MinCameraDistance = 0.5f;

		public const float FadeInDistance = 0.7f;

		public const float FadeOutDistance = 0.25f;

		public bool SnapToRightAngles;

		[Header("References")]
		public GrowContainer GrowContainer;

		public Transform WaterCanvasContainer;

		public Canvas WaterLevelCanvas;

		public CanvasGroup WaterLevelCanvasGroup;

		public Slider WaterLevelSlider;

		public GameObject NoWaterIcon;

		protected virtual void Awake()
		{
		}

		private void LateUpdate()
		{
		}

		private void UpdateCanvas()
		{
		}

		protected virtual void UpdateCanvasContents()
		{
		}
	}
}
