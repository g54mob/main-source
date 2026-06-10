using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.DevConsole;
using NSMedieval.Manager;
using NSMedieval.View;
using NSMedieval.Weather;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class WeatherDebugPanelView : UIView
	{
		[SerializeField]
		private Image temperatureImage;

		[SerializeField]
		private RectTransform debugPointer;

		[SerializeField]
		private SoundButton closeButton;

		[SerializeField]
		private SoundButton nextSeasonButton;

		[SerializeField]
		private SoundButton debugInfoButton;

		[SerializeField]
		private TooltipViewNew tooltipView;

		private Texture2D dbgTemperatureGraphTexture;

		private void OnEnable()
		{
			MonoSingleton<WeatherManager>.Instance.WeatherEventsGeneratedEvent += OnWeatherEventsGenerated;
			MonoSingleton<WeatherManager>.Instance.ForceStartedEvent += OnForceStartedEvent;
			TryUpdateWeatherGraph();
			UpdateTimePointer();
		}

		private void OnDisable()
		{
			if (MonoSingleton<WeatherManager>.IsInstantiated())
			{
				MonoSingleton<WeatherManager>.Instance.WeatherEventsGeneratedEvent -= OnWeatherEventsGenerated;
				MonoSingleton<WeatherManager>.Instance.ForceStartedEvent -= OnForceStartedEvent;
			}
		}

		private void OnWeatherEventsGenerated()
		{
			TryUpdateWeatherGraph();
			UpdateTimePointer();
		}

		private void OnForceStartedEvent(WeatherEventInstance eventInstance)
		{
			TryUpdateWeatherGraph();
		}

		private void TryUpdateWeatherGraph()
		{
			bool num = dbgTemperatureGraphTexture == null;
			MonoSingleton<WeatherManager>.Instance.GenerateWeatherEventsGraph(ref dbgTemperatureGraphTexture);
			if (num && dbgTemperatureGraphTexture != null && temperatureImage.sprite == null)
			{
				temperatureImage.sprite = Sprite.Create(dbgTemperatureGraphTexture, new Rect(0f, 0f, dbgTemperatureGraphTexture.width, dbgTemperatureGraphTexture.height), Vector2.zero);
			}
		}

		private void OnTimeUpdate()
		{
			if (base.gameObject.activeSelf)
			{
				UpdateTimePointer();
			}
		}

		private void UpdateTimePointer()
		{
			if (debugPointer != null && temperatureImage != null)
			{
				Vector3 localPosition = debugPointer.localPosition;
				localPosition.x = (GlobalSaveController.CurrentVillageData.DateAndTime.SeasonPercent - 0.5f) * temperatureImage.rectTransform.rect.size.x;
				debugPointer.localPosition = localPosition;
			}
		}

		private void OnDateTimeInitalize()
		{
			OnTimeUpdate();
		}

		private void Start()
		{
			MonoSingleton<WorldTimeManager>.Instance.DateTimeInitalizeEvent += OnDateTimeInitalize;
			MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent += OnTimeUpdate;
			closeButton.onClick.AddListener(ToggleDebugView);
			if (nextSeasonButton != null)
			{
				nextSeasonButton.onClick.AddListener(delegate
				{
					MonoSingleton<WeatherManager>.Instance.DebugSeekSeasonTime(1f);
				});
			}
			if (debugInfoButton != null)
			{
				debugInfoButton.onClick.AddListener(delegate
				{
					MonoSingleton<WeatherManager>.Instance.DebugToggleWeatherInfo();
				});
			}
			ClickDetection component = temperatureImage.GetComponent<ClickDetection>();
			if (component != null)
			{
				component.Clicked += OnWeatherPanelClick;
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.DateTimeInitalizeEvent -= OnDateTimeInitalize;
				MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent -= OnTimeUpdate;
			}
			ClickDetection clickDetection = temperatureImage?.GetComponent<ClickDetection>();
			if (clickDetection != null)
			{
				clickDetection.Clicked -= OnWeatherPanelClick;
			}
		}

		private void ToggleDebugView()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("toggleWeatherView");
			if (!MonoSingleton<WeatherManager>.Instance.IsDebugViewEnabled())
			{
				MonoSingleton<DeveloperToolsView>.Instance.RefreshPanel = true;
			}
		}

		private void Update()
		{
			if (MonoSingleton<WeatherManager>.IsInstantiated() && MonoSingleton<WeatherManager>.Instance.IsDebugViewEnabled() && MonoSingleton<TooltipController>.Instance.IsShowing(tooltipView))
			{
				RefreshTooltip();
			}
		}

		private void RefreshTooltip()
		{
			tooltipView.ClearLines();
			RectTransform rectTransform = temperatureImage.rectTransform;
			Vector3 vector = Input.mousePosition - rectTransform.position;
			float num = rectTransform.lossyScale.x * rectTransform.rect.size.x;
			float currentSeasonPercent = vector.x / num + 0.5f;
			WeatherManager instance = MonoSingleton<WeatherManager>.Instance;
			WorldDate dateAndTime = GlobalSaveController.CurrentVillageData.DateAndTime;
			int num2 = (int)(currentSeasonPercent * (float)dateAndTime.DaysInSeason);
			int num3 = (int)(currentSeasonPercent * (float)dateAndTime.DaysInSeason % 1f * (float)dateAndTime.HoursInDay);
			WeatherEventsAtHour eventInSeason = instance.GetEventInSeason(num2 * dateAndTime.HoursInDay + num3);
			instance.CalculateSeasonTemperatures(dateAndTime.Year * dateAndTime.MinutesInYear + dateAndTime.Season.Index * dateAndTime.MinutesInSeason + num2 * dateAndTime.MinutesInDay + num3 * dateAndTime.MinutesInHour, out var soilTemperature, out var waterTemperature);
			tooltipView.AppendLine($"Season percent: {currentSeasonPercent:P1}");
			tooltipView.AppendLine($"Day: {num2}, hour: {num3}");
			tooltipView.AppendLine($"Air  Temp.: {eventInSeason?.Temperature}");
			tooltipView.AppendLine($"Soil Temp.: {soilTemperature}");
			tooltipView.AppendLine($"Water Temp.: {waterTemperature}");
			if (eventInSeason?.Events != null)
			{
				foreach (WeatherEvent @event in eventInSeason.Events)
				{
					tooltipView.AppendLine(" * event: " + @event?.GetID());
				}
			}
			instance.CalculateSunriseSunset(dateAndTime.Season, in currentSeasonPercent, out var sunriseHour, out var sunsetHour, out var sunAngle);
			tooltipView.AppendLine($"Sunrise-sunset: {sunriseHour} - {sunsetHour}");
			tooltipView.AppendLine($"Sun angle: {sunAngle}");
			tooltipView.RefreshTooltip();
		}

		private void OnWeatherPanelClick(Vector3 clickCoords)
		{
			RectTransform rectTransform = temperatureImage.rectTransform;
			Vector3 vector = Input.mousePosition - rectTransform.position;
			float num = rectTransform.lossyScale.x * rectTransform.rect.size.x;
			float percent = vector.x / num + 0.5f;
			MonoSingleton<WeatherManager>.Instance.DebugSeekSeasonTime(percent);
		}
	}
}
