using ScheduleOne.Map;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI
{
	public class CartelInfluenceChangePopup : MonoBehaviour
	{
		public const float SLIDER_ANIMATION_DURATION = 1.5f;

		public Animation Anim;

		public Slider Slider;

		public TextMeshProUGUI TitleLabel;

		public TextMeshProUGUI InfluenceCountLabel;

		private void Start()
		{
		}

		public void Show(EMapRegion region, float oldInfluence, float newInfluence)
		{
		}

		private void SetDisplayedInfluence(float influence)
		{
		}
	}
}
