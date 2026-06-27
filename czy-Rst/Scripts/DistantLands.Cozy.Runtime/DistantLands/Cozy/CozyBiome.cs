using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozyBiome : CozySystem
	{
		public enum BiomeMode
		{
			Global = 0,
			Local = 1
		}

		public enum TransitionMode
		{
			Distance = 0,
			Time = 1
		}

		public float transitionTime = 5f;

		public float transitionDistance = 5f;

		public Collider trigger;

		public List<ICozyBiomeModule> modules = new List<ICozyBiomeModule>();

		public CozyWeather cachedWeatherSphere;

		[Range(0f, 1f)]
		public float maxWeight = 1f;

		public BiomeMode mode;

		public TransitionMode transitionMode;

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
		}

		private void Start()
		{
			if (Application.isPlaying)
			{
				weatherSphere.systems.Add(this);
			}
		}

		private void Update()
		{
			if (modules.Count == 0)
			{
				modules = GetComponents<ICozyBiomeModule>().ToList();
			}
			if (mode == BiomeMode.Global)
			{
				targetWeight = maxWeight;
			}
			else if (transitionMode == TransitionMode.Distance)
			{
				SetWeightByDistance();
			}
			else
			{
				SetWeightByTime();
			}
			foreach (ICozyBiomeModule module in modules)
			{
				module.UpdateBiomeModule();
			}
		}

		public void SetWeightByDistance()
		{
			if (!weatherSphere)
			{
				targetWeight = 0f;
			}
			if (mode == BiomeMode.Global)
			{
				targetWeight = maxWeight;
				return;
			}
			if (!trigger)
			{
				targetWeight = 0f;
				trigger = GetComponent<Collider>();
			}
			Vector3 position = weatherSphere.transform.position;
			Vector3 b = trigger.ClosestPoint(position);
			float num = Vector3.Distance(position, b);
			targetWeight = ((num <= transitionDistance) ? CozyUtilities.Remap(0f, transitionDistance, maxWeight, 0f, num) : 0f);
		}

		public void SetWeightByTime()
		{
			if (!weatherSphere)
			{
				targetWeight = 0f;
			}
			if (mode == BiomeMode.Global)
			{
				targetWeight = maxWeight;
				return;
			}
			if (!trigger)
			{
				targetWeight = 0f;
			}
			Vector3 vector = trigger.ClosestPoint(weatherSphere.transform.position);
			if (transitionTime > 0f)
			{
				if (weatherSphere.transform.position == vector)
				{
					targetWeight = Mathf.Clamp01(targetWeight + 1f / transitionTime * Time.deltaTime);
				}
				else
				{
					targetWeight = Mathf.Clamp01(targetWeight - 1f / transitionTime * Time.deltaTime);
				}
			}
			else
			{
				targetWeight = maxWeight;
			}
		}

		public CozyModule GetModule(Type type)
		{
			foreach (ICozyBiomeModule module in modules)
			{
				if (module.GetType() == type)
				{
					return (CozyModule)module;
				}
			}
			return null;
		}

		public T GetModule<T>() where T : CozyModule
		{
			Type typeFromHandle = typeof(T);
			foreach (CozyModule module in modules)
			{
				if (module.GetType() == typeFromHandle)
				{
					return module as T;
				}
			}
			return null;
		}

		public void InitializeModule(Type module)
		{
			if (!GetModule(module))
			{
				ICozyBiomeModule cozyBiomeModule = (ICozyBiomeModule)base.gameObject.AddComponent(module);
				if (!cozyBiomeModule.CheckBiome())
				{
					UnityEngine.Object.DestroyImmediate((CozyModule)cozyBiomeModule);
					return;
				}
				cozyBiomeModule.AddBiome();
				modules.Add(cozyBiomeModule);
			}
		}

		public void RemoveModule(Type module)
		{
			if ((bool)GetModule(module))
			{
				ICozyBiomeModule cozyBiomeModule = modules.Find((ICozyBiomeModule x) => x.GetType() == module);
				cozyBiomeModule.RemoveBiome();
				modules.Remove(cozyBiomeModule);
			}
		}
	}
}
