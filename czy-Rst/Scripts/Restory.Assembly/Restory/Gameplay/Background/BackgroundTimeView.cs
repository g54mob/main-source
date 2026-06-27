using System;
using System.Linq;
using Restory.Data.Background;
using Restory.Gameplay.TimeSystems;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Background
{
	public class BackgroundTimeView : MonoBehaviour, ITimeChangeReceiver
	{
		[SerializeField]
		private Renderer renderer;

		[SerializeField]
		private string colorName = "_Tint_Color";

		[SerializeField]
		private string intensityName = "_Emission_Intensity";

		[SerializeField]
		private BackgroundTimePresets presets;

		private BackgroundTimePreset[] sortedPresets;

		private GameCalendar gameCalendar;

		[Inject]
		public void Construct(GameCalendar gameCalendar)
		{
			this.gameCalendar = gameCalendar;
			if (base.isActiveAndEnabled)
			{
				gameCalendar.AddSubscriber(this);
				ProcessTimeChanged();
			}
		}

		public void Awake()
		{
			sortedPresets = presets.Presets.OrderBy((BackgroundTimePreset p) => p.TimeOfDay.InTimeSpan().TotalSeconds).ToArray();
		}

		public void OnEnable()
		{
			if (gameCalendar.MonoShellExists())
			{
				gameCalendar.AddSubscriber(this);
				ProcessTimeChanged();
			}
		}

		public void OnDisable()
		{
			if (gameCalendar.MonoShellExists())
			{
				gameCalendar.RemoveSubscriber(this);
			}
		}

		public void ProcessTimeChanged()
		{
			if (gameCalendar == null || sortedPresets.Length == 0)
			{
				return;
			}
			TimeSpan timeOfDay = gameCalendar.CurrentDateTime.TimeOfDay;
			BackgroundTimePreset backgroundTimePreset = null;
			BackgroundTimePreset backgroundTimePreset2 = null;
			for (int i = 0; i < sortedPresets.Length; i++)
			{
				if (sortedPresets[i].TimeOfDay.InTimeSpan() <= timeOfDay)
				{
					backgroundTimePreset = sortedPresets[i];
				}
				else if (backgroundTimePreset2 == null)
				{
					backgroundTimePreset2 = sortedPresets[i];
					break;
				}
			}
			if (backgroundTimePreset == null)
			{
				backgroundTimePreset = sortedPresets[sortedPresets.Length - 1];
				backgroundTimePreset2 = sortedPresets[0];
			}
			else if (backgroundTimePreset2 == null)
			{
				backgroundTimePreset2 = sortedPresets[0];
			}
			float t = CalculateInterpolationFactor(timeOfDay, backgroundTimePreset.TimeOfDay.InTimeSpan(), backgroundTimePreset2.TimeOfDay.InTimeSpan());
			Color value = Color.Lerp(backgroundTimePreset.Color, backgroundTimePreset2.Color, t);
			float value2 = Mathf.Lerp(backgroundTimePreset.Intensity, backgroundTimePreset2.Intensity, t);
			renderer.material.SetColor(colorName, value);
			renderer.material.SetFloat(intensityName, value2);
		}

		private float CalculateInterpolationFactor(TimeSpan currentTime, TimeSpan prevTime, TimeSpan nextTime)
		{
			double totalSeconds = currentTime.TotalSeconds;
			double totalSeconds2 = prevTime.TotalSeconds;
			double totalSeconds3 = nextTime.TotalSeconds;
			if (totalSeconds3 < totalSeconds2)
			{
				if (totalSeconds >= totalSeconds2)
				{
					double num = 86400.0 - totalSeconds2 + totalSeconds3;
					return (float)((totalSeconds - totalSeconds2) / num);
				}
				double num2 = 86400.0 - totalSeconds2 + totalSeconds3;
				return (float)((86400.0 - totalSeconds2 + totalSeconds) / num2);
			}
			double num3 = totalSeconds3 - totalSeconds2;
			double num4 = totalSeconds - totalSeconds2;
			if (!(num3 > 0.0))
			{
				return 0f;
			}
			return (float)(num4 / num3);
		}
	}
}
