using System;
using UnityEngine;

namespace DistantLands.Cozy
{
	public abstract class CozyModule : MonoBehaviour
	{
		public CozyWeather cachedWeatherSphere;

		public CozySystem cachedSystem;

		[HideInInspector]
		public CozyWeather weatherSphere
		{
			get
			{
				if (!cachedWeatherSphere)
				{
					cachedWeatherSphere = CozyWeather.instance;
				}
				return cachedWeatherSphere;
			}
			set
			{
				cachedWeatherSphere = value;
			}
		}

		public CozySystem system
		{
			get
			{
				if (!cachedSystem)
				{
					if ((bool)GetComponent<CozyBiome>())
					{
						cachedSystem = GetComponent<CozyBiome>();
					}
					else
					{
						cachedSystem = weatherSphere;
					}
				}
				return cachedSystem;
			}
			set
			{
				cachedSystem = value;
			}
		}

		public void OnEnable()
		{
			InitializeModule();
		}

		public virtual void InitializeModule()
		{
			if (base.enabled)
			{
				if ((bool)GetComponent<CozyWeather>())
				{
					GetComponent<CozyWeather>().InitializeModule(GetType());
					UnityEngine.Object.DestroyImmediate(this);
					return;
				}
				CozyWeather.OnFrameReset += FrameReset;
				CozyWeather.UpdateWeatherWeights += UpdateWeatherWeights;
				CozyWeather.UpdateFXWeights += UpdateFXWeights;
				CozyWeather.PropogateVariables += PropogateVariables;
				CozyWeather.CozyUpdateLoop += CozyUpdateLoop;
			}
		}

		internal virtual bool CheckIfModuleCanBeRemoved(out string warning)
		{
			warning = "";
			return true;
		}

		internal virtual bool CheckIfModuleCanBeAdded(out string warning)
		{
			warning = "";
			return true;
		}

		public virtual void FrameReset()
		{
		}

		public virtual void UpdateWeatherWeights()
		{
		}

		public virtual void UpdateFXWeights()
		{
		}

		public virtual void PropogateVariables()
		{
		}

		public virtual void CozyUpdateLoop()
		{
		}

		public virtual void OnSceneLoaded()
		{
		}

		public virtual void OnSceneUnloaded()
		{
		}

		public virtual void SetupModule(Type[] requirements)
		{
			if (!base.enabled)
			{
				return;
			}
			foreach (Type type in requirements)
			{
				if (!weatherSphere.GetModule(type))
				{
					weatherSphere.InitializeModule(type);
					Debug.Log(GetType().Name + " requires " + type.Name + " to function. " + type.Name + " has been automatically added to the weather sphere!");
				}
			}
		}

		public void OnDisable()
		{
			DeinitializeModule();
		}

		public virtual void DeinitializeModule()
		{
			if (!GetComponent<CozyBiome>())
			{
				CozyWeather.OnFrameReset -= FrameReset;
				CozyWeather.UpdateWeatherWeights -= UpdateWeatherWeights;
				CozyWeather.UpdateFXWeights -= UpdateFXWeights;
				CozyWeather.PropogateVariables -= PropogateVariables;
				CozyWeather.CozyUpdateLoop -= CozyUpdateLoop;
			}
		}
	}
}
