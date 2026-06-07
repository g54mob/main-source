using System;
using System.Text.RegularExpressions;
using Assets.Scripts.UI.Controls;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI
{
	internal class Naca4Editor : IAirfoilEditor
	{
		private Regex _naca4Pattern = new Regex("\\ANACA\\s*(\\d)(\\d)(\\d\\d)\\z", RegexOptions.IgnoreCase);

		private SliderControl _sliderCamHeight;

		private SliderControl _sliderCamPos;

		private SliderControl _sliderThickness;

		private bool _ignoreEvents;

		public string Name => "NACA 4-digit";

		public event Action<string> OnAirfoilChanged;

		public Naca4Editor(Widget parent)
		{
			SliderControl sliderControl = new SliderControl(parent.FindWidget("naca4-position"));
			sliderControl.ValueFormatter = Percent;
			sliderControl.Slider.MinValue = 2f;
			sliderControl.Slider.MaxValue = 7f;
			sliderControl.Slider.NumberOfSteps = 6;
			_sliderCamPos = sliderControl;
			SliderControl sliderControl2 = new SliderControl(parent.FindWidget("naca4-height"));
			sliderControl2.ValueFormatter = Percent;
			sliderControl2.Slider.MinValue = 0f;
			sliderControl2.Slider.MaxValue = 9f;
			sliderControl2.Slider.NumberOfSteps = 10;
			_sliderCamHeight = sliderControl2;
			SliderControl sliderControl3 = new SliderControl(parent.FindWidget("naca4-thickness"));
			sliderControl3.ValueFormatter = Percent;
			sliderControl3.Slider.MinValue = 4f;
			sliderControl3.Slider.MaxValue = 24f;
			sliderControl3.Slider.NumberOfSteps = 17;
			_sliderThickness = sliderControl3;
			_sliderCamPos.Slider.Slider.onValueChanged.AddListener(OnSlider);
			_sliderCamHeight.Slider.Slider.onValueChanged.AddListener(OnSlider);
			_sliderThickness.Slider.Slider.onValueChanged.AddListener(OnSlider);
			void OnSlider(float value)
			{
				if (!_ignoreEvents)
				{
					UpdateAirfoil();
				}
			}
			static string Percent(float f)
			{
				return (0.01f * f).ToString("P0");
			}
		}

		public void LoadDefault()
		{
			Load(3, 4, 12);
		}

		public void SetVisible(bool visible)
		{
			_sliderCamHeight.Visible = visible;
			_sliderCamPos.Visible = visible;
			_sliderThickness.Visible = visible;
		}

		public bool TryLoad(string airfoil)
		{
			Match match = _naca4Pattern.Match(airfoil);
			if (match != null && match.Success)
			{
				SetVisible(visible: true);
				GroupCollection groups = match.Groups;
				Load(int.Parse(groups[1].Value), int.Parse(groups[2].Value), int.Parse(groups[3].Value));
				return true;
			}
			return false;
		}

		private void Load(int a, int b, int cd)
		{
			_sliderCamHeight.SetValue(a);
			_sliderCamPos.SetValue(b);
			_sliderThickness.SetValue(cd);
		}

		private void UpdateAirfoil()
		{
			int value = Mathf.RoundToInt(_sliderCamHeight.Value);
			int value2 = Mathf.RoundToInt(_sliderCamPos.Value);
			int value3 = Mathf.RoundToInt(_sliderThickness.Value);
			value = Math.Clamp(value, 0, 9);
			value2 = Math.Clamp(value2, 2, 7);
			value3 = Math.Clamp(value3, 4, 24);
			this.OnAirfoilChanged?.Invoke($"NACA{value}{value2}{value3:00}");
		}
	}
}
