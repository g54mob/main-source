using DistantLands.Cozy.Data;
using UnityEngine;
using UnityEngine.Events;

namespace DistantLands.Cozy
{
	[RequireComponent(typeof(Collider))]
	public class CozyVolume : MonoBehaviour
	{
		public enum TriggerType
		{
			setWeather = 0,
			triggerEvent = 1,
			setTime = 2,
			setDay = 3,
			setAtmosphere = 4,
			setAmbience = 5
		}

		public enum SetType
		{
			setInstantly = 0,
			transition = 1
		}

		public enum TriggerState
		{
			onEnter = 0,
			onStay = 1,
			onExit = 2
		}

		[SerializeField]
		private TriggerType m_TriggerType;

		[SerializeField]
		private TriggerState m_TriggerState;

		[SerializeField]
		private SetType m_SetType;

		[SerializeField]
		private string m_Tag = "Untagged";

		private CozyWeather m_CozyWeather;

		[SerializeField]
		private WeatherProfile m_WeatherProfile;

		[SerializeField]
		private float m_TransitionTime;

		[SerializeField]
		private UnityEvent m_Event;

		[SerializeField]
		private AtmosphereProfile m_AtmosphereProfile;

		[SerializeField]
		private AmbienceProfile m_AmbienceProfile;

		[SerializeField]
		[MeridiemTime]
		private float time;

		[SerializeField]
		private int day;

		[SerializeField]
		private float transitionTime;

		private void Awake()
		{
			m_CozyWeather = CozyWeather.instance;
		}

		public void Run()
		{
			if (m_SetType == SetType.setInstantly)
			{
				Set();
			}
			else
			{
				Transition();
			}
		}

		public void Transition()
		{
			switch (m_TriggerType)
			{
			case TriggerType.triggerEvent:
				m_Event.Invoke();
				break;
			case TriggerType.setAtmosphere:
				m_CozyWeather.atmosphereModule.ChangeAtmosphere(m_AtmosphereProfile, m_TransitionTime);
				break;
			case TriggerType.setDay:
				m_CozyWeather.timeModule.TransitionTime(time, day);
				break;
			case TriggerType.setTime:
				m_CozyWeather.timeModule.TransitionTime(time, m_CozyWeather.timeModule.currentDay);
				break;
			case TriggerType.setAmbience:
				m_CozyWeather.GetModule<CozyAmbienceModule>().SetAmbience(m_AmbienceProfile, m_TransitionTime);
				break;
			case TriggerType.setWeather:
				break;
			}
		}

		public void Set()
		{
			switch (m_TriggerType)
			{
			case TriggerType.setWeather:
				m_CozyWeather.weatherModule.ecosystem.currentWeather = m_WeatherProfile;
				break;
			case TriggerType.triggerEvent:
				m_Event.Invoke();
				break;
			case TriggerType.setAtmosphere:
				m_CozyWeather.atmosphereModule.atmosphereProfile = m_AtmosphereProfile;
				m_CozyWeather.ResetQuality();
				break;
			case TriggerType.setDay:
				m_CozyWeather.timeModule.currentDay = day;
				break;
			case TriggerType.setTime:
				m_CozyWeather.timeModule.currentTime = time;
				break;
			case TriggerType.setAmbience:
				if (m_CozyWeather.GetModule<CozyAmbienceModule>() != null)
				{
					m_CozyWeather.GetModule<CozyAmbienceModule>().SetAmbience(m_AmbienceProfile, 0f);
				}
				break;
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (m_TriggerState == TriggerState.onEnter && other.gameObject.tag == m_Tag)
			{
				Run();
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (m_TriggerState == TriggerState.onStay && other.gameObject.tag == m_Tag)
			{
				Run();
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (m_TriggerState == TriggerState.onExit && other.gameObject.tag == m_Tag)
			{
				Run();
			}
		}
	}
}
