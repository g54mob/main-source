using Assets.Scripts.Flight.Sim;
using ModApi.Flight;
using ModApi.Flight.UI;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class TimePanelController : FlightPanelController
	{
		private bool _displayTimeInDays;

		private IFlightSceneUI _flightSceneUi;

		private long _missionTime;

		private XmlElement _modeFast;

		private XmlElement _modeNormal;

		private XmlElement _modeSlow;

		private XmlElement _modeWarp;

		private TimeManager _timeManager;

		private double _timeMultiplier;

		private TextMeshProUGUI _timeText;

		private TextMeshProUGUI _warpButtonText;

		private XmlElement _warpPanel;

		public override void Initialize(FlightSceneUiController flightSceneUiController)
		{
			base.Initialize(flightSceneUiController);
			_timeManager = FlightSceneScript.Instance.TimeManager as TimeManager;
			_flightSceneUi = FlightSceneScript.Instance.FlightSceneUI;
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			_warpPanel = base.xmlLayout.GetElementById("warp-panel");
			_warpPanel.Hide();
			_warpButtonText = base.xmlLayout.GetElementById<TextMeshProUGUI>("warp-text");
			_timeText = base.xmlLayout.GetElementById<TextMeshProUGUI>("time-text");
			_modeSlow = base.xmlLayout.GetElementById("mode-slow");
			_modeNormal = base.xmlLayout.GetElementById("mode-normal");
			_modeFast = base.xmlLayout.GetElementById("mode-fast");
			_modeWarp = base.xmlLayout.GetElementById("mode-warp");
		}

		public override void UpdatePanel(CraftNode craftNode)
		{
			SetMode(_timeManager.CurrentMode);
			UpdateMissionTime();
		}

		private void OnDecreaseWarpClicked()
		{
			_timeManager.DecreaseTimeMultiplier();
		}

		private void OnFastForwardClicked()
		{
			_timeManager.SetFastForwardMode();
		}

		private void OnIncreaseWarpClicked()
		{
			if (_timeManager.CanIncreaseTimeMultiplier(out var failRason))
			{
				_timeManager.IncreaseTimeMultiplier();
			}
			else
			{
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage(failRason);
			}
		}

		private void OnPlayClicked()
		{
			_timeManager.SetNormalSpeedMode();
		}

		private void OnSlowMotionClicked()
		{
			_timeManager.SetSlowMotionMode();
		}

		private void OnTimeClicked()
		{
			_displayTimeInDays = !_displayTimeInDays;
			_missionTime = -1L;
		}

		private void OnWarpModeClicked()
		{
			if (!_timeManager.CurrentMode.WarpMode)
			{
				string failReason = null;
				if (_timeManager.CanSetTimeMultiplierMode(_timeManager.FirstWarpMode, out failReason))
				{
					_timeManager.SetMode(_timeManager.FirstWarpMode);
				}
				else
				{
					_flightSceneUi.ShowMessage(failReason);
				}
			}
		}

		private void SelectButton(XmlElement button, bool select)
		{
			if (select)
			{
				if (!button.HasClass("time-button-selected"))
				{
					button.AddClass("time-button-selected");
				}
			}
			else if (button.HasClass("time-button-selected"))
			{
				button.RemoveClass("time-button-selected");
			}
		}

		private void SetMode(ITimeMultiplierMode mode)
		{
			if (_timeMultiplier != mode.TimeMultiplier)
			{
				_timeMultiplier = mode.TimeMultiplier;
				SelectButton(_modeWarp, mode.WarpMode);
				SelectButton(_modeNormal, mode.TimeMultiplier == 1.0);
				SelectButton(_modeSlow, mode.TimeMultiplier < 1.0);
				SelectButton(_modeFast, mode.TimeMultiplier > 1.0 && !mode.WarpMode);
				if (mode.TimeMultiplier != 1.0)
				{
					_warpPanel.Show();
				}
				else
				{
					_warpPanel.Hide();
				}
				SetWarpModeButtonText();
			}
		}

		private void SetWarpModeButtonText()
		{
			string text;
			if (_timeMultiplier >= 1.0)
			{
				text = $"{(int)_timeMultiplier:n0}<size=60%>x</size>";
			}
			else if (_timeMultiplier > 0.0)
			{
				text = $"1/{(int)(1.0 / _timeMultiplier):n0}<size=60%>x</size>";
			}
			else if (_timeMultiplier == 0.0)
			{
				text = "Paused";
			}
			else
			{
				Debug.LogError($"Unsupported time multiplier: {_timeMultiplier}");
				text = "N/A";
			}
			_warpButtonText.text = text;
		}

		private void UpdateMissionTime()
		{
			long num = (long)FlightSceneScript.Instance.FlightState.Time;
			if (_missionTime == num)
			{
				return;
			}
			if (_displayTimeInDays)
			{
				float num2 = (float)num / 86400f;
				if (num2 >= 1f)
				{
					if (num2 >= 365f)
					{
						int num3 = (int)num2 / 365;
						num2 %= 365f;
						_timeText.text = string.Format("<size=75%>{0:n0} {1}\n{2:n0} {3}</size>", num3, (num3 == 1) ? "year" : "years", num2, (num2 == 1f) ? "day" : "days");
					}
					else
					{
						_timeText.text = string.Format("{0:n0}{1}", num2, (num2 == 1f) ? "day" : "days");
					}
				}
				else
				{
					_timeText.text = $"{num2:.0}days";
				}
			}
			else
			{
				_missionTime = num;
				int num4 = (int)(num % 86400);
				int num5 = num4 / 3600;
				int num6 = (num4 - num5 * 60 * 60) / 60;
				int num7 = num4 % 60;
				_timeText.text = $"{num5:00}:{num6:00}:{num7:00}";
			}
		}
	}
}
