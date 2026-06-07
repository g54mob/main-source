using Assets.Scripts.Design;
using Assets.Scripts.Environment;
using Assets.Scripts.Flight;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.XR.UI
{
	public class RadialWindSettingsScript : MonoBehaviour
	{
		private CircularList<string> _windGustList;

		[SerializeField]
		private RadialDragArea _windHeadingDragArea;

		[SerializeField]
		private TextMeshProUGUI _windSpeedLabel;

		[SerializeField]
		private Slider _windSpeedSlider;

		public int WindHeadingInDegrees
		{
			get
			{
				return Mathf.RoundToInt(_windHeadingDragArea.Value * 360f);
			}
			set
			{
				_windHeadingDragArea.Value = (float)value / 360f;
			}
		}

		public int WindSpeedInMph
		{
			get
			{
				return Mathf.RoundToInt(_windSpeedSlider.value * 200f);
			}
			set
			{
				_windSpeedSlider.value = (float)value / 200f;
				UpdateWindSpeedLabel();
			}
		}

		public void OnWindSpeedSliderChanged()
		{
			UpdateWind();
		}

		public void UpdateWind()
		{
			FlightSceneScript.Instance.WindManager.UpdateWind(WindHeadingInDegrees, WindSpeedInMph);
			UpdateWindSpeedLabel();
			FlightSceneScript.Instance.WindManager.SaveWind(WindHeadingInDegrees, WindSpeedInMph, FlightSceneScript.Instance.WindManager.GustMode);
		}

		protected virtual void Awake()
		{
			_windGustList = BuildWindGustsList();
			LoadSettingsToUi();
			_windHeadingDragArea.OnValueChange += OnWindHeadingChanged;
		}

		protected virtual void OnEnable()
		{
			if (!(FlightSceneScript.Instance.WindManager == null))
			{
				LoadSettingsToUi();
			}
		}

		private CircularList<string> BuildWindGustsList()
		{
			CircularList<string> circularList = new CircularList<string>();
			circularList.Add(WindManager.WindGustMode.None.ToString());
			circularList.Add(WindManager.WindGustMode.Light.ToString());
			circularList.Add(WindManager.WindGustMode.Medium.ToString());
			circularList.Add(WindManager.WindGustMode.Heavy.ToString());
			return circularList;
		}

		private void LoadSettingsToUi()
		{
			WindHeadingInDegrees = FlightSceneScript.Instance.WindManager.LoadWindHeading();
			WindSpeedInMph = FlightSceneScript.Instance.WindManager.LoadWindSpeed();
		}

		private void OnWindHeadingChanged(float heading)
		{
			UpdateWind();
		}

		private void UpdateWindSpeedLabel()
		{
			_windSpeedLabel.text = "Wind Speed: " + WindSpeedInMph + "mph";
		}
	}
}
