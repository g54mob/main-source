using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;

namespace NSMedieval.Weather
{
	public class WeatherEventsAtHour
	{
		private int hour;

		private List<WeatherEvent> events;

		private float temperature;

		private string localizedText;

		public float Temperature => temperature;

		public int Hour => hour;

		public List<WeatherEvent> Events => events;

		public WeatherEventsAtHour(int hour)
		{
			events = new List<WeatherEvent>();
			this.hour = hour;
		}

		public void SetTemperature(float temperature)
		{
			this.temperature = temperature;
		}

		public bool TryAddEvent(WeatherEvent we)
		{
			if (!CanContainEvent(we))
			{
				return false;
			}
			events.Add(we);
			return true;
		}

		public override string ToString()
		{
			return hour + " : " + string.Join(", ", events);
		}

		public bool CanContainEvent(WeatherEvent we)
		{
			if (!we.Temperature.InRange(temperature))
			{
				return false;
			}
			foreach (WeatherEvent @event in events)
			{
				if (we.SkipIfExists.Contains(@event.GetID()) && @event.SkipIfExists.Contains(we.GetID()))
				{
					return false;
				}
			}
			return true;
		}

		public object GetEventNamesLocalized()
		{
			if (localizedText.Length == 0)
			{
				for (int i = 0; i < events.Count; i++)
				{
					localizedText += MonoSingleton<LocalizationController>.Instance.GetText(events[i].TextKey);
					if (i != events.Count - 1)
					{
						localizedText += ", ";
					}
				}
			}
			return localizedText;
		}

		public void ClearEvents()
		{
			localizedText = string.Empty;
			events.Clear();
		}

		public void RemoveEvent(WeatherEvent clearEvent)
		{
			localizedText = string.Empty;
			events.RemoveAll((WeatherEvent we) => we == clearEvent);
		}
	}
}
