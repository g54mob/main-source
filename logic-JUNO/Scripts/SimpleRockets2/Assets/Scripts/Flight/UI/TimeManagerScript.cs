using ModApi;
using ModApi.Flight;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.UI
{
	public class TimeManagerScript : MonoBehaviour
	{
		private const float WarpAnimateTime = 0.2f;

		[SerializeField]
		private Button _fastForwardButton;

		[SerializeField]
		private FlightSceneInterfaceScript _flightSceneUi;

		private long _missionTime;

		[SerializeField]
		private TextMeshProUGUI _missionTimeText;

		[SerializeField]
		private Button _playButton;

		private TimeManager _timeManager;

		private double _timeMultiplier;

		private float _warpAnimateTimer;

		[SerializeField]
		private Button _warpButton;

		[SerializeField]
		private TextMeshProUGUI _warpButtonText;

		[SerializeField]
		private GameObject _warpDecreaseButton;

		[SerializeField]
		private GameObject _warpIncreaseButton;

		private bool _warpMode;

		public static string GetTimeString(long missionTime)
		{
			string text = string.Empty;
			int num = (int)(missionTime / 86400);
			if (num >= 1)
			{
				if (num >= 365)
				{
					int num2 = num / 365;
					num %= 365;
					text = $"<size=60%>{num2.ToString():n}-Y {num.ToString()}-D</size>\n";
				}
				else
				{
					text = string.Format("<size=60%>{0} {1}</size>\n", num.ToString(), (num == 1) ? "DAY" : "DAYS");
				}
			}
			int num3 = (int)(missionTime % 86400);
			int num4 = num3 / 3600;
			int num5 = (num3 - num4 * 60 * 60) / 60;
			int num6 = num3 % 60;
			return $"{text}{num4:00}:{num5:00}:{num6:00}";
		}

		public void OnDecreaseWarpButtonClicked()
		{
			_timeManager.DecreaseTimeMultiplier();
		}

		public void OnFastForwardButtonClicked()
		{
			_timeManager.SetFastForwardMode();
		}

		public void OnIncreaseWarpButtonClicked()
		{
			_timeManager.IncreaseTimeMultiplier();
		}

		public void OnPlayButtonClicked()
		{
			_timeManager.SetNormalSpeedMode();
		}

		public void OnWarpButtonClicked()
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

		protected virtual void Awake()
		{
			_timeManager = FlightSceneScript.Instance.TimeManager as TimeManager;
		}

		protected virtual void Update()
		{
			if (_warpAnimateTimer >= 0f)
			{
				_warpAnimateTimer -= Time.unscaledDeltaTime;
				float num = Mathf.Clamp01(_warpAnimateTimer / 0.2f);
				if (_warpMode)
				{
					num = 1f - num;
				}
				RectTransform component = _warpButton.GetComponent<RectTransform>();
				Vector2 sizeDelta = component.sizeDelta;
				sizeDelta.x = 150f + num * 115f;
				component.sizeDelta = sizeDelta;
				bool active = _warpAnimateTimer < 0f && _warpMode;
				_warpIncreaseButton.SetActive(active);
				_warpDecreaseButton.SetActive(active);
			}
			SetMode(_timeManager.CurrentMode);
			UpdateMissionTime();
		}

		private void HighlightButton(Button button, bool highlight)
		{
			Color color = Color.white;
			if (highlight)
			{
				color = Constants.Colors.Primary.Linear;
			}
			ColorBlock colors = button.colors;
			colors.normalColor = color;
			button.colors = colors;
			if (button == _warpButton)
			{
				_warpButtonText.color = color;
			}
		}

		private void SetMode(ITimeMultiplierMode mode)
		{
			if (_timeMultiplier != mode.TimeMultiplier)
			{
				_timeMultiplier = mode.TimeMultiplier;
				if (mode.WarpMode)
				{
					HighlightButton(_playButton, highlight: false);
					HighlightButton(_fastForwardButton, highlight: false);
					HighlightButton(_warpButton, highlight: true);
				}
				else if (mode.TimeMultiplier == 1.0)
				{
					HighlightButton(_playButton, highlight: true);
					HighlightButton(_fastForwardButton, highlight: false);
					HighlightButton(_warpButton, highlight: false);
				}
				else if (mode.TimeMultiplier > 0.0)
				{
					HighlightButton(_playButton, highlight: false);
					HighlightButton(_fastForwardButton, highlight: true);
					HighlightButton(_warpButton, highlight: false);
				}
				if (_warpMode != mode.WarpMode)
				{
					_warpMode = mode.WarpMode;
					_warpAnimateTimer = 0.2f;
				}
				SetWarpModeButtonText();
			}
		}

		private void SetWarpModeButtonText()
		{
			if (_warpMode)
			{
				_warpButtonText.text = $"{(int)_timeMultiplier:n0}<size=60%>x</size>";
			}
			else
			{
				_warpButtonText.text = "WARP";
			}
		}

		private void UpdateMissionTime()
		{
			long num = (long)FlightSceneScript.Instance.FlightState.Time;
			if (_missionTime != num)
			{
				_missionTime = num;
				_missionTimeText.text = GetTimeString(num);
			}
		}
	}
}
