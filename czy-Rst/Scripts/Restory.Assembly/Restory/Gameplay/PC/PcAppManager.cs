using System;
using System.Collections.Generic;
using Restory.Data.Identifications;
using Restory.Data.PC;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.EventSystems.ExitEvents;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.UI.Presenters;
using Restory.UI.Presenters.PC.Apps;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.PC
{
	public class PcAppManager : MonoBehaviour, IInitializable, IDisposable, IExitEventHandler, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private readonly List<PcAppInfo> installedApps = new List<PcAppInfo>();

		private readonly List<PcAppInfo> availableApps = new List<PcAppInfo>();

		private readonly HashSet<PcAppInfo> guiVisibleApps = new HashSet<PcAppInfo>();

		[SerializeField]
		private UniqueIdentificator identificator;

		private PcAppFactory appFactory;

		private GUI_PcWindowsXpScreen pcScreen;

		private ExitEventDispatcher exitEventDispatcher;

		private GUI_PcAppBase launchedApp;

		private PcAppInfo stashedAppInfo;

		public string ID => identificator.ID;

		public IReadOnlyCollection<PcAppInfo> InstalledApps => installedApps;

		public IReadOnlyCollection<PcAppInfo> AvailableApps => availableApps;

		public GUI_PcAppBase LaunchedApp => launchedApp;

		public event Action<PcAppInfo> OnAppLaunched;

		public event Action<PcAppInfo> OnAppInstalled;

		[Inject]
		private void Construct(PcAppFactory appFactory, GUI_PcWindowsXpScreen pcScreen, ExitEventDispatcher exitEventDispatcher)
		{
			this.pcScreen = pcScreen;
			this.appFactory = appFactory;
			this.exitEventDispatcher = exitEventDispatcher;
		}

		public void Initialize()
		{
			pcScreen.OnStateChanged += ResolvePcScreenStateChanged;
			pcScreen.OnIsVisibleChanged += ResolvePcScreenVisibilityChanged;
			pcScreen.InstallationPanel.OnAppInstalled += ResolveAppInstalled;
			pcScreen.InstallationPanel.OnAppLaunched += ResolveAppIconClick;
			pcScreen.IconsPanel.OnAppIconClick += ResolveAppIconClick;
			pcScreen.Toolbar.OnAppOpenRequested += ResolveAppIconClick;
			pcScreen.StartMenu.OnAppButtonClicked += ResolveAppIconClick;
		}

		public void Dispose()
		{
			pcScreen.OnStateChanged -= ResolvePcScreenStateChanged;
			pcScreen.OnIsVisibleChanged -= ResolvePcScreenVisibilityChanged;
			pcScreen.InstallationPanel.OnAppInstalled -= ResolveAppInstalled;
			pcScreen.InstallationPanel.OnAppLaunched -= ResolveAppIconClick;
			pcScreen.IconsPanel.OnAppIconClick -= ResolveAppIconClick;
			pcScreen.Toolbar.OnAppOpenRequested -= ResolveAppIconClick;
			pcScreen.StartMenu.OnAppButtonClicked -= ResolveAppIconClick;
		}

		public void ActivatePcApp(PcAppInfo appInfo)
		{
			if (!ContainsApp(appInfo))
			{
				availableApps.Add(appInfo);
				pcScreen.InstallationPanel.LaunchAppInstallation(appInfo);
			}
		}

		public void InstallPcApp(PcAppInfo appInfo)
		{
			if (!installedApps.Contains(appInfo))
			{
				availableApps.Remove(appInfo);
				installedApps.Add(appInfo);
				SyncCategoryAppsInGui(appInfo.Category);
				this.OnAppInstalled?.Invoke(appInfo);
			}
		}

		public void LaunchPcApp(PcAppInfo appInfo)
		{
			if (!installedApps.Contains(appInfo))
			{
				Debug.LogError("Attempted to launch app " + appInfo.name + " that is not installed");
				return;
			}
			pcScreen.CurrentState = PcScreenStates.Desktop;
			if ((bool)launchedApp)
			{
				if (launchedApp.AppInfo == appInfo)
				{
					pcScreen.Toolbar.SelectAppButton(appInfo);
					return;
				}
				StopLaunchedApp();
			}
			CreateAndLaunchApp(appInfo);
		}

		public bool ContainsApp(PcAppInfo appInfo)
		{
			if (!availableApps.Contains(appInfo))
			{
				return installedApps.Contains(appInfo);
			}
			return true;
		}

		public bool TryGetLatestVersionOfCategory(PcAppCategoryInfo category, out PcAppInfo latestVersionApp)
		{
			latestVersionApp = null;
			int num = int.MinValue;
			for (int i = 0; i < installedApps.Count; i++)
			{
				PcAppInfo pcAppInfo = installedApps[i];
				if (!(pcAppInfo.Category != category) && pcAppInfo.Version > num)
				{
					num = pcAppInfo.Version;
					latestVersionApp = pcAppInfo;
				}
			}
			return latestVersionApp != null;
		}

		public void ExecuteExit()
		{
			if (!launchedApp)
			{
				Debug.LogError("launchedApp is not found");
			}
			else
			{
				StopLaunchedApp();
			}
		}

		public void ConfirmExitExecution()
		{
			if ((bool)launchedApp)
			{
				Debug.LogError("launchedApp is still running");
				StopLaunchedApp();
			}
		}

		private void ResolvePcScreenStateChanged()
		{
			if (pcScreen.CurrentState != PcScreenStates.Desktop)
			{
				exitEventDispatcher.Unregister(this);
				StopLaunchedApp();
			}
		}

		private void ResolvePcScreenVisibilityChanged()
		{
			if (pcScreen.IsVisible)
			{
				if (availableApps.Count > 0)
				{
					pcScreen.CurrentState = PcScreenStates.InstallingApp;
				}
				else if ((bool)stashedAppInfo)
				{
					pcScreen.CurrentState = PcScreenStates.Desktop;
					CreateAndLaunchApp(stashedAppInfo);
				}
			}
			else if ((bool)launchedApp)
			{
				exitEventDispatcher.Unregister(this);
				stashedAppInfo = launchedApp.AppInfo;
				StopLaunchedApp();
			}
		}

		private void ResolveAppInstalled(PcAppInfo appInfo)
		{
			InstallPcApp(appInfo);
		}

		private void ResolveAppIconClick(PcAppInfo appInfo)
		{
			LaunchPcApp(appInfo);
		}

		private void ResolveAppExitButtonClick()
		{
			exitEventDispatcher.Unregister(this);
			StopLaunchedApp();
		}

		private void CreateAndLaunchApp(PcAppInfo appInfo)
		{
			if (!launchedApp)
			{
				exitEventDispatcher.Register(this);
				stashedAppInfo = null;
				launchedApp = appFactory.GetPcApp(appInfo);
				if (!launchedApp)
				{
					exitEventDispatcher.Unregister(this);
					Debug.LogError("Failed to create app " + appInfo.name);
					return;
				}
				launchedApp.Launch(appInfo);
				launchedApp.ExitButton.onClick.AddListener(ResolveAppExitButtonClick);
				pcScreen.Toolbar.SelectAppButton(appInfo);
				this.OnAppLaunched?.Invoke(appInfo);
			}
		}

		private void StopLaunchedApp()
		{
			if ((bool)launchedApp)
			{
				pcScreen.Toolbar.DeselectAppButton(launchedApp.AppInfo);
				launchedApp.ExitButton.onClick.RemoveAllListeners();
				launchedApp.Stop();
				appFactory.ReleasePcApp(launchedApp);
				launchedApp = null;
			}
		}

		private void HideAppInGui(PcAppInfo appInfo)
		{
			if (guiVisibleApps.Contains(appInfo))
			{
				if ((bool)launchedApp && launchedApp.AppInfo == appInfo)
				{
					exitEventDispatcher.Unregister(this);
					stashedAppInfo = null;
					StopLaunchedApp();
				}
				pcScreen.IconsPanel.RemoveAppIcon(appInfo);
				pcScreen.Toolbar.RemoveAppButton(appInfo);
				pcScreen.StartMenu.RemoveAppButton(appInfo);
				guiVisibleApps.Remove(appInfo);
			}
		}

		private void ShowAppInGui(PcAppInfo appInfo)
		{
			if (!guiVisibleApps.Contains(appInfo))
			{
				pcScreen.IconsPanel.CreateAppIcon(appInfo);
				pcScreen.Toolbar.CreateAppButton(appInfo);
				pcScreen.StartMenu.CreateAppButton(appInfo);
				guiVisibleApps.Add(appInfo);
			}
		}

		private void SyncCategoryAppsInGui(PcAppCategoryInfo category)
		{
			int num = int.MinValue;
			for (int i = 0; i < installedApps.Count; i++)
			{
				PcAppInfo pcAppInfo = installedApps[i];
				if (!(pcAppInfo.Category != category) && pcAppInfo.Version > num)
				{
					num = pcAppInfo.Version;
				}
			}
			for (int j = 0; j < installedApps.Count; j++)
			{
				PcAppInfo pcAppInfo2 = installedApps[j];
				if (!(pcAppInfo2.Category != category))
				{
					if (pcAppInfo2.Version == num)
					{
						ShowAppInGui(pcAppInfo2);
					}
					else
					{
						HideAppInGui(pcAppInfo2);
					}
				}
			}
		}

		private void SyncAllCategoriesInGui()
		{
			HashSet<PcAppCategoryInfo> hashSet = new HashSet<PcAppCategoryInfo>();
			for (int i = 0; i < installedApps.Count; i++)
			{
				hashSet.Add(installedApps[i].Category);
			}
			foreach (PcAppCategoryInfo item in hashSet)
			{
				SyncCategoryAppsInGui(item);
			}
		}

		public object CaptureState()
		{
			try
			{
				return new PcAppManagerSaveData
				{
					InstalledApps = installedApps,
					AvailableApps = availableApps
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				PcAppManagerSaveData pcAppManagerSaveData = DataMigrationWizard.Migrate<PcAppManagerSaveData>(state, base.gameObject);
				installedApps.AddRange(pcAppManagerSaveData.InstalledApps);
				SyncAllCategoriesInGui();
				availableApps.AddRange(pcAppManagerSaveData.AvailableApps);
				foreach (PcAppInfo availableApp in availableApps)
				{
					pcScreen.InstallationPanel.LaunchAppInstallation(availableApp);
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
