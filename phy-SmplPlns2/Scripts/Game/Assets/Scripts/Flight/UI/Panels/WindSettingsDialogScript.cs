using Assets.Scripts.Environment;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Levels;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Controls;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Flight.UI.Panels
{
	public class WindSettingsDialogScript : PanelDialogScript, IOverlayCameraRequirement
	{
		private SpinnerControl _gustSpinner;

		private SliderControl _sliderHeading;

		private SliderControl _sliderSpeed;

		private WindManager _windManager;

		public override bool IsModal => false;

		bool IOverlayCameraRequirement.IsOverlayCamRequired => true;

		public int WindHeadingInDegrees => Mathf.RoundToInt(_sliderHeading.Slider.Value);

		public int WindSpeedInMph => Mathf.RoundToInt(_sliderSpeed.Slider.Value);

		public override void Close()
		{
			base.Close();
			LevelBase.CurrentLevel.WindGizmoEnabled = false;
			CameraManagerScript.Instance.UnregisterOverlayCameraRequirement(this);
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_windManager = FlightSceneScript.Instance.WindManager;
			LevelBase.CurrentLevel.WindGizmoEnabled = true;
			CameraManagerScript.Instance.RegisterOverlayCameraRequirement(this);
			_sliderHeading = new SliderControl(widget.FindWidget("slider-heading"));
			_sliderHeading.Slider.MinValue = 0f;
			_sliderHeading.Slider.MaxValue = 360f;
			_sliderHeading.Slider.NumberOfSteps = 360;
			_sliderHeading.Slider.ValueChanged += delegate
			{
				UpdateWind();
			};
			_sliderHeading.ValueFormatter = (float x) => $"{x:0} degrees";
			_sliderHeading.Slider.Value = _windManager.LoadWindHeading();
			_sliderSpeed = new SliderControl(widget.FindWidget("slider-speed"));
			_sliderSpeed.Slider.MinValue = 0f;
			_sliderSpeed.Slider.MaxValue = 200f;
			_sliderSpeed.Slider.NumberOfSteps = 200;
			_sliderSpeed.Slider.ValueChanged += delegate
			{
				UpdateWind();
			};
			_sliderSpeed.ValueFormatter = (float x) => $"{x:0} mph";
			_sliderSpeed.Slider.Value = _windManager.LoadWindSpeed();
			_gustSpinner = new SpinnerControl(base.Widget.FindWidget("spinner-gust"));
			_gustSpinner.Values.Add(WindManager.WindGustMode.None.ToString());
			_gustSpinner.Values.Add(WindManager.WindGustMode.Light.ToString());
			_gustSpinner.Values.Add(WindManager.WindGustMode.Medium.ToString());
			_gustSpinner.Values.Add(WindManager.WindGustMode.Heavy.ToString());
			_gustSpinner.OnValueChanged = delegate
			{
				UpdateWind();
			};
			_gustSpinner.Value = _windManager.LoadWindGustMode().ToString();
			bool host = Game.Instance.NetworkGameManager.NetworkManager.IsHostStarted;
			widget.ExecuteOnWidgetsOfClass("host-only", delegate(Widget x)
			{
				x.Visible = host;
			});
			widget.ExecuteOnWidgetsOfClass("client-only", delegate(Widget x)
			{
				x.Visible = !host;
			});
		}

		public void UpdateWind()
		{
			_windManager.UpdateWind(WindHeadingInDegrees, WindSpeedInMph);
			_windManager.SaveWind(WindHeadingInDegrees, WindSpeedInMph, _windManager.GustMode);
			WindManager.WindGustMode gustMode = WindManager.WindGustModeFromText(_gustSpinner.Value);
			_windManager.UpdateWindGustMode(gustMode);
		}

		private void OnCloseButtonClicked(Widget widget)
		{
			Close();
		}
	}
}
