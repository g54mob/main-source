using System;
using System.Collections;
using System.Linq;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

namespace DV.VFX
{
	public class IndustryScheduledVisuals : MonoBehaviour
	{
		[Serializable]
		public class ScheduleEntry
		{
			[Header("Time")]
			[Range(0f, 23f)]
			public int hourStart;

			[Range(0f, 59f)]
			public int minuteStart;

			[Range(0f, 23f)]
			public int hourEnd;

			[Range(0f, 59f)]
			public int minuteEnd;

			[Header("Stagger")]
			public float staggerTimespan = 5f;

			[Header("Effects")]
			public ParticleSystem[] particlesToStart;

			public ParticleSystem[] particlesToStop;

			public Animator[] animationsToStart;

			public Animator[] animationsToStop;

			public GameObject[] objectsToShow;

			public GameObject[] objectsToHide;

			public Behaviour[] componentsToEnable;

			public Behaviour[] componentsToDisable;

			[Header("Animator parameters")]
			public string runningParam = "Running";

			public string mainLoopState = "MainLoop";

			public string idleState = "Idle";

			public float mainLoopLength = 1f;

			private bool wasOn;

			private float lastDayLength;

			private Coroutine[] coroutines = new Coroutine[8];

			public bool Check()
			{
				if (particlesToStart.Any((ParticleSystem ps) => ps == null))
				{
					return false;
				}
				if (particlesToStop.Any((ParticleSystem ps) => ps == null))
				{
					return false;
				}
				if (animationsToStart.Any((Animator a) => a == null))
				{
					return false;
				}
				if (animationsToStop.Any((Animator a) => a == null))
				{
					return false;
				}
				if (objectsToShow.Any((GameObject o) => o == null))
				{
					return false;
				}
				if (objectsToHide.Any((GameObject o) => o == null))
				{
					return false;
				}
				if (componentsToEnable.Any((Behaviour c) => c == null))
				{
					return false;
				}
				if (componentsToDisable.Any((Behaviour c) => c == null))
				{
					return false;
				}
				return true;
			}

			private bool IsIn(DateTime timestamp)
			{
				int num = timestamp.Hour * 60 + timestamp.Minute;
				int num2 = hourStart * 60 + minuteStart;
				int num3 = hourEnd * 60 + minuteEnd;
				if (num2 < num3)
				{
					if (num >= num2)
					{
						return num <= num3;
					}
					return false;
				}
				if (num > num3)
				{
					return num >= num2;
				}
				return true;
			}

			private void SetState(IndustryScheduledVisuals visuals, bool on, bool forced, float dayTimeInMinutes)
			{
				Coroutine[] array = coroutines;
				foreach (Coroutine coroutine in array)
				{
					if (coroutine != null)
					{
						visuals.StopCoroutine(coroutine);
					}
				}
				coroutines[0] = visuals.StartCoroutine(SetParticleSystemEmissions(particlesToStart, on, staggerTimespan, forced));
				coroutines[1] = visuals.StartCoroutine(SetParticleSystemEmissions(particlesToStop, !on, staggerTimespan, forced));
				coroutines[2] = visuals.StartCoroutine(SetAnimatorRunning(visuals, animationsToStart, on, staggerTimespan, forced, dayTimeInMinutes));
				coroutines[3] = visuals.StartCoroutine(SetAnimatorRunning(visuals, animationsToStop, !on, staggerTimespan, forced, dayTimeInMinutes));
				coroutines[4] = visuals.StartCoroutine(SetObjectsActive(objectsToShow, on, staggerTimespan));
				coroutines[5] = visuals.StartCoroutine(SetObjectsActive(objectsToHide, !on, staggerTimespan));
				coroutines[6] = visuals.StartCoroutine(SetComponentsEnabled(componentsToEnable, on, staggerTimespan));
				coroutines[7] = visuals.StartCoroutine(SetComponentsEnabled(componentsToDisable, !on, staggerTimespan));
			}

			private IEnumerator SetParticleSystemEmissions(ParticleSystem[] systems, bool on, float totalTime, bool forced)
			{
				float period = ((systems.Length > 1) ? (totalTime / (float)(systems.Length - 1)) : (totalTime / 2f));
				foreach (ParticleSystem ps in systems)
				{
					if (!ps)
					{
						continue;
					}
					ParticleSystem.EmissionModule emission = ps.emission;
					emission.enabled = on;
					if (!forced && period > 0f)
					{
						yield return WaitFor.Seconds(UnityEngine.Random.Range(period * 0.75f, period * 1.25f));
					}
					if (forced)
					{
						if (on)
						{
							ps.Simulate(UnityEngine.Random.Range(5f, 10f));
							ps.Play();
						}
						else
						{
							ps.Clear();
						}
					}
				}
			}

			private IEnumerator SetAnimatorRunning(IndustryScheduledVisuals parent, Animator[] animators, bool on, float totalStaggerTime, bool jumpStart, float dayTime)
			{
				float period = ((animators.Length > 1) ? (totalStaggerTime / (float)(animators.Length - 1)) : (totalStaggerTime / 2f));
				float dayLength = parent.weatherManager.DayLengthInMinutes;
				if (float.IsNaN(dayLength) || float.IsInfinity(dayLength))
				{
					if (lastDayLength > 0f && !float.IsNaN(lastDayLength) && !float.IsInfinity(lastDayLength))
					{
						dayLength = lastDayLength;
					}
					else
					{
						ScheduleEntry scheduleEntry = this;
						float num;
						dayLength = (num = 120f);
						scheduleEntry.lastDayLength = num;
					}
				}
				else
				{
					lastDayLength = dayLength;
				}
				for (int i = 0; i < animators.Length; i++)
				{
					Animator animator = animators[i];
					if (!animator)
					{
						continue;
					}
					animator.SetBool(runningParam, on);
					if (jumpStart)
					{
						string text = (on ? mainLoopState : idleState);
						float num2 = dayLength / (mainLoopLength / 60f);
						float num3 = 1440f / num2;
						float normalizedTime = Mathf.Repeat(dayTime + (Mathf.Sin(i) * 0.5f + 0.5f) * totalStaggerTime / 60f, num3) / num3;
						if (animator.HasState(0, Animator.StringToHash(text)))
						{
							animator.CrossFadeInFixedTime(text, 0f);
						}
						animator.Update(float.Epsilon);
						for (int j = 0; j < animator.layerCount; j++)
						{
							animator.Play(0, j, normalizedTime);
						}
					}
					if (!jumpStart && period > 0f)
					{
						yield return WaitFor.Seconds(UnityEngine.Random.Range(period * 0.75f, period * 1.25f));
					}
				}
			}

			private IEnumerator SetObjectsActive(GameObject[] objects, bool on, float totalTime)
			{
				float period = ((objects.Length > 1) ? (totalTime / (float)(objects.Length - 1)) : (totalTime / 2f));
				foreach (GameObject gameObject in objects)
				{
					if ((bool)gameObject)
					{
						gameObject.SetActive(on);
						if (period > 0f)
						{
							yield return WaitFor.Seconds(UnityEngine.Random.Range(period * 0.75f, period * 1.25f));
						}
					}
				}
			}

			private IEnumerator SetComponentsEnabled(Behaviour[] components, bool on, float totalTime)
			{
				float period = ((components.Length > 1) ? (totalTime / (float)(components.Length - 1)) : (totalTime / 2f));
				foreach (Behaviour behaviour in components)
				{
					if ((bool)behaviour)
					{
						behaviour.enabled = on;
						if (period > 0f)
						{
							yield return WaitFor.Seconds(UnityEngine.Random.Range(period * 0.75f, period * 1.25f));
						}
					}
				}
			}

			public void Update(IndustryScheduledVisuals visuals, DateTime timestamp, bool force)
			{
				float dayTimeInMinutes = timestamp.Hour * 60 + timestamp.Minute;
				bool flag = IsIn(timestamp);
				if (flag != wasOn || force)
				{
					wasOn = flag;
					SetState(visuals, flag, force, dayTimeInMinutes);
				}
			}
		}

		public ScheduleEntry[] schedule;

		private WeatherPresetManager weatherManager;

		private IEnumerator Start()
		{
			while (!SingletonBehaviour<WeatherDriver>.Instance || schedule == null)
			{
				yield return null;
			}
			weatherManager = SingletonBehaviour<WeatherDriver>.Instance.manager;
			DateTime dateTime = SingletonBehaviour<WeatherDriver>.Instance.manager.DateTime;
			ScheduleEntry[] array = schedule;
			foreach (ScheduleEntry obj in array)
			{
				if (!obj.Check())
				{
					Debug.LogError("There are null entries in IndustryScheduledVisuals component at " + base.gameObject.GetPath(), base.gameObject);
				}
				obj.Update(this, dateTime, force: true);
			}
			weatherManager.MinuteChanged += MinuteTick;
			weatherManager.TimeJump += TimeJump;
		}

		private void TimeJump()
		{
			ScheduleEntry[] array = schedule;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Update(this, weatherManager.DateTime, force: true);
			}
		}

		private void MinuteTick()
		{
			DateTime dateTime = weatherManager.DateTime;
			ScheduleEntry[] array = schedule;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Update(this, dateTime, force: false);
			}
		}

		private void OnDestroy()
		{
			if ((bool)weatherManager)
			{
				weatherManager.MinuteChanged -= MinuteTick;
				weatherManager.TimeJump -= TimeJump;
			}
		}
	}
}
