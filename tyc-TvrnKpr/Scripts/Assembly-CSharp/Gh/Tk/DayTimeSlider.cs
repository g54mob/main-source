using Gh.Tk.UI;
using I18n;
using TMPro;
using UnityEngine;

namespace Gh.Tk
{
	public class DayTimeSlider : MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField _dayTimeSpeedInput;

		private float _lastTimeSpeed;

		[SerializeField]
		private Slider3DUIView _timeOfDaySlider;

		[SerializeField]
		private CheckBox3DUIView _timeSyncCheckBox;

		[SerializeField]
		private TextMeshProI18n _timeText;

		public bool Synced
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		private void UpdateSliderFromVisualTime()
		{
		}

		private void Start()
		{
		}

		private void UpdateDayTimeText()
		{
		}

		public void UpdateVisuals()
		{
		}

		public void UpdateTime()
		{
		}

		public void DisableSettings()
		{
		}
	}
}
