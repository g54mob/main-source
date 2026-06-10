using System.Collections;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Map;
using UnityEngine;
using UnityEngine.Serialization;

namespace NSMedieval.View
{
	public class DayNightWeatherView : NSEipix.Base.View
	{
		[SerializeField]
		private Animator animator;

		[SerializeField]
		private string[] dayNightAnimationStates;

		[FormerlySerializedAs("enviromentUpdate")]
		[SerializeField]
		private EnvironmentUpdate environmentUpdate;

		private float baseAnimationLength;

		private bool loadingFinished;

		private void OnDateTimeInitalize()
		{
			baseAnimationLength = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
		}

		private void UpdateAnimationTime()
		{
			if (MonoSingleton<WeatherManager>.IsInstantiated() && !MonoSingleton<WeatherManager>.IsApplicationIsQuitting())
			{
				WeatherManager instance = MonoSingleton<WeatherManager>.Instance;
				float normalizedTime = (instance.IsDay ? (instance.DayPercent / 2f) : (0.5f + instance.NightPercent / 2f));
				animator.speed = 0f;
				string[] array = dayNightAnimationStates;
				foreach (string stateName in array)
				{
					animator.Play(stateName, -1, normalizedTime);
				}
			}
		}

		private void Start()
		{
			MonoSingleton<WorldTimeManager>.Instance.DateTimeInitalizeEvent += OnDateTimeInitalize;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnLoadingFinished;
		}

		private void OnDestroy()
		{
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.DateTimeInitalizeEvent -= OnDateTimeInitalize;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnLoadingFinished;
			}
		}

		private void Update()
		{
			if (loadingFinished)
			{
				UpdateAnimationTime();
			}
		}

		private void OnLoadingFinished(bool afterLoad)
		{
			loadingFinished = true;
			StartCoroutine(SetAnimator());
		}

		private IEnumerator SetAnimator()
		{
			yield return new WaitForEndOfFrame();
			environmentUpdate.GetValuesFromAnimator();
		}
	}
}
