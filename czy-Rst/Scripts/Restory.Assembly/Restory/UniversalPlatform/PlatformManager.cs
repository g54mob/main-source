using System;
using Alekrus.UnivarsalPlatform;
using Alekrus.UnivarsalPlatform.UserProfiles;
using Alekrus.UnivarsalPlatform.Utilities;
using UnityEngine;
using Zenject;

namespace Restory.UniversalPlatform
{
	public sealed class PlatformManager : MonoBehaviour, Zenject.IInitializable, IDisposable
	{
		private IMain main;

		private ILocalUserProfiles profiles;

		public bool MainIsInitialized
		{
			get
			{
				if (main != null)
				{
					return main.IsInitialized;
				}
				return false;
			}
		}

		public bool ProfilesIsInitialized
		{
			get
			{
				if (profiles != null)
				{
					return profiles.IsInitialized;
				}
				return false;
			}
		}

		public event Action MainInitialized;

		public event Action ProfileInitialized;

		public void Initialize()
		{
			PlatformDebugging.OnLog += Debug.Log;
			PlatformDebugging.OnLogError += Debug.LogError;
			PlatformDebugging.OnLogWarning += Debug.LogWarning;
			main = MainProvider.Create();
			if (main != null)
			{
				main.Initialized += Main_Initialized;
				if (!main.Initialize() && main.CheckForLauncherAndRestart())
				{
					Application.Quit();
				}
			}
		}

		public void Dispose()
		{
			PlatformDebugging.OnLog -= Debug.Log;
			PlatformDebugging.OnLogError -= Debug.LogError;
			PlatformDebugging.OnLogWarning -= Debug.LogWarning;
			Shutdown();
		}

		public T GetSubInterface<T>() where T : ISubInterface<IMain>
		{
			if (main == null)
			{
				return default(T);
			}
			return main.GetSubInterface<T>();
		}

		private void OnApplicationQuit()
		{
			Shutdown();
		}

		private void Update()
		{
			main?.Update();
			profiles?.Update();
		}

		private void Shutdown()
		{
			if (main != null)
			{
				main.Initialized -= Main_Initialized;
				main.Shutdown();
				main = null;
			}
		}

		private void Main_Initialized()
		{
			if (main.CheckForLauncherAndRestart())
			{
				Application.Quit();
				return;
			}
			this.MainInitialized?.Invoke();
			profiles = main.GetSubInterface<ILocalUserProfiles>();
			profiles.Initialized += Profiles_Initialized;
			profiles.Initialize();
		}

		private void Profiles_Initialized()
		{
			this.ProfileInitialized?.Invoke();
		}
	}
}
