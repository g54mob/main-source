using System;
using System.Collections;
using DistantLands.Cozy.Data;
using UnityEngine;
using UnityEngine.Events;

namespace DistantLands.Cozy
{
	public class CozyEventModule : CozyBiomeModuleBase<CozyEventModule>
	{
		[Serializable]
		public class CozyEvent
		{
			public EventFX fxReference;

			public UnityEvent onPlay;

			public UnityEvent onStop;
		}

		[CozySearchable(new string[] { })]
		public UnityEvent onDawn;

		[CozySearchable(new string[] { })]
		public UnityEvent onMorning;

		[CozySearchable(new string[] { })]
		public UnityEvent onDay;

		[CozySearchable(new string[] { })]
		public UnityEvent onAfternoon;

		[CozySearchable(new string[] { })]
		public UnityEvent onEvening;

		[CozySearchable(new string[] { })]
		public UnityEvent onTwilight;

		[CozySearchable(new string[] { })]
		public UnityEvent onNight;

		[CozySearchable(new string[] { })]
		public UnityEvent onNewMinute;

		[CozySearchable(new string[] { })]
		public UnityEvent onNewHour;

		[CozySearchable(new string[] { })]
		public UnityEvent onNewDay;

		[CozySearchable(new string[] { })]
		public UnityEvent onNewYear;

		[CozySearchable(new string[] { })]
		public UnityEvent onWeatherProfileChange;

		[CozySearchable(new string[] { })]
		public CozyEvent[] cozyEvents;

		public bool inBiome;

		public UnityEvent onEnterBiome;

		public UnityEvent onExitBiome;

		public UnityEvent whileInBiome;

		public override void InitializeModule()
		{
			if (!base.enabled)
			{
				return;
			}
			base.InitializeModule();
			if ((bool)GetComponent<CozyWeather>())
			{
				GetComponent<CozyWeather>().InitializeModule(typeof(CozyEventModule));
				UnityEngine.Object.DestroyImmediate(this);
				Debug.LogWarning("Add modules in the settings tab in COZY 2!");
				return;
			}
			base.isBiomeModule = GetComponent<CozyBiome>();
			if (base.isBiomeModule || !Application.isPlaying)
			{
				return;
			}
			CozyEvent[] array = cozyEvents;
			foreach (CozyEvent cozyEvent in array)
			{
				if ((bool)cozyEvent.fxReference)
				{
					cozyEvent.fxReference.onCall += cozyEvent.onPlay.Invoke;
					cozyEvent.fxReference.onEnd += cozyEvent.onStop.Invoke;
				}
			}
			StartCoroutine(Refresh());
		}

		public override void DeinitializeModule()
		{
			base.DeinitializeModule();
			if (!Application.isPlaying)
			{
				return;
			}
			CozyEvent[] array = cozyEvents;
			foreach (CozyEvent cozyEvent in array)
			{
				if ((bool)cozyEvent.fxReference)
				{
					cozyEvent.fxReference.onCall -= cozyEvent.onPlay.Invoke;
					cozyEvent.fxReference.onEnd -= cozyEvent.onStop.Invoke;
				}
			}
			CozyWeather.Events.onDawn -= onDawn.Invoke;
			CozyWeather.Events.onMorning -= onMorning.Invoke;
			CozyWeather.Events.onDay -= onDay.Invoke;
			CozyWeather.Events.onAfternoon -= onAfternoon.Invoke;
			CozyWeather.Events.onEvening -= onEvening.Invoke;
			CozyWeather.Events.onTwilight -= onTwilight.Invoke;
			CozyWeather.Events.onNight -= onNight.Invoke;
			CozyWeather.Events.onNewMinute -= onNewMinute.Invoke;
			CozyWeather.Events.onNewHour -= onNewHour.Invoke;
			CozyWeather.Events.onNewDay -= onNewDay.Invoke;
			CozyWeather.Events.onNewYear -= onNewYear.Invoke;
			CozyWeather.Events.onWeatherChange -= onWeatherProfileChange.Invoke;
		}

		public IEnumerator Refresh()
		{
			yield return new WaitForEndOfFrame();
			CozyWeather.Events.onDawn += onDawn.Invoke;
			CozyWeather.Events.onMorning += onMorning.Invoke;
			CozyWeather.Events.onDay += onDay.Invoke;
			CozyWeather.Events.onAfternoon += onAfternoon.Invoke;
			CozyWeather.Events.onEvening += onEvening.Invoke;
			CozyWeather.Events.onTwilight += onTwilight.Invoke;
			CozyWeather.Events.onNight += onNight.Invoke;
			CozyWeather.Events.onNewMinute += onNewMinute.Invoke;
			CozyWeather.Events.onNewHour += onNewHour.Invoke;
			CozyWeather.Events.onNewDay += onNewDay.Invoke;
			CozyWeather.Events.onNewYear += onNewYear.Invoke;
			CozyWeather.Events.onWeatherChange += onWeatherProfileChange.Invoke;
		}

		public void LogConsoleEvent()
		{
			Debug.Log("Test Event Passed.");
		}

		public void LogConsoleEvent(string log)
		{
			Debug.Log("Test Event Passed. Log: " + log);
		}

		private void Update()
		{
			if (!base.isBiomeModule)
			{
				ComputeBiomeWeights();
				return;
			}
			if (weight == 1f)
			{
				whileInBiome.Invoke();
				if (!inBiome)
				{
					inBiome = true;
					onEnterBiome.Invoke();
				}
			}
			if (weight == 0f && inBiome)
			{
				inBiome = false;
				onExitBiome.Invoke();
			}
		}
	}
}
