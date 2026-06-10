using System;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Controllers;
using UnityEngine;

namespace NSMedieval
{
	public class SceneController : MonoSingleton<SceneController>
	{
		private readonly object padlock = new object();

		private event Action<float> TickInternal;

		private event Action<float> UnscaledTickInternal;

		public event Action<float> Tick
		{
			add
			{
				lock (padlock)
				{
					TickInternal += value;
				}
			}
			remove
			{
				lock (padlock)
				{
					TickInternal -= value;
				}
			}
		}

		public event Action<float> UnscaledTick
		{
			add
			{
				lock (padlock)
				{
					UnscaledTickInternal += value;
				}
			}
			remove
			{
				lock (padlock)
				{
					UnscaledTickInternal -= value;
				}
			}
		}

		public event Action SceneSetup;

		public event Action<float> TimeTick;

		public event Action<float> FixedTick;

		public event Action<float> LateTick;

		public void SetupScene()
		{
			this.SceneSetup?.Invoke();
		}

		private void Start()
		{
			MonoSingleton<LoadingController>.Instance.HomeSceneLoadedEvent += SceneLoaded;
			MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent += SceneLoaded;
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += OnSceneLeaving;
			MonoSingleton<LoadingController>.Instance.HomeSceneLeavingEvent += OnSceneLeaving;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.HomeSceneLoadedEvent -= SceneLoaded;
				MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent -= SceneLoaded;
				MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= OnSceneLeaving;
				MonoSingleton<LoadingController>.Instance.HomeSceneLeavingEvent -= OnSceneLeaving;
			}
			this.TickInternal = null;
			this.UnscaledTickInternal = null;
			this.SceneSetup = null;
			this.TimeTick = null;
			this.FixedTick = null;
			this.LateTick = null;
		}

		private void OnSceneLeaving()
		{
			Log.Info("Leaving the Home or Main scene. Stopping SceneController", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\SceneController.cs");
			base.enabled = false;
			Reset();
		}

		private void SceneLoaded()
		{
			Log.Info("Scene is loaded. Enabling SceneController", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\SceneController.cs");
			base.enabled = true;
		}

		private void Reset()
		{
			Log.Info("Disposing event listeners", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\SceneController.cs");
			this.SceneSetup = null;
			this.TickInternal = null;
			this.UnscaledTickInternal = null;
			this.TimeTick = null;
			this.FixedTick = null;
			this.LateTick = null;
		}

		private void Update()
		{
			this.TickInternal?.Invoke(Time.deltaTime);
			this.TimeTick?.Invoke(Time.time);
			float obj = ((Time.timeScale != 0f) ? (Time.deltaTime / Time.timeScale) : Time.unscaledDeltaTime);
			this.UnscaledTickInternal?.Invoke(obj);
		}

		private void FixedUpdate()
		{
			this.FixedTick?.Invoke(Time.fixedDeltaTime);
		}

		private void LateUpdate()
		{
			this.LateTick?.Invoke(Time.deltaTime);
		}
	}
}
