using System.Collections.Generic;
using Restory.Data.PC;
using Restory.UI.Presenters;
using Restory.UI.Presenters.PC.Apps;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.PC
{
	public class PcAppFactory
	{
		private readonly DiContainer diContainer;

		private readonly GUI_PcWindowsXpScreen pcScreen;

		private readonly Dictionary<PcAppInfo, GUI_PcAppBase> pooledApps = new Dictionary<PcAppInfo, GUI_PcAppBase>();

		[Inject]
		public PcAppFactory(DiContainer diContainer, GUI_PcWindowsXpScreen pcScreen)
		{
			this.diContainer = diContainer;
			this.pcScreen = pcScreen;
		}

		public GUI_PcAppBase GetPcApp(PcAppInfo pcAppInfo)
		{
			if (!pooledApps.TryGetValue(pcAppInfo, out var value))
			{
				value = diContainer.InstantiatePrefabForComponent<GUI_PcAppBase>(pcAppInfo.PcAppPrefab, pcScreen.AppContainer);
				pooledApps[pcAppInfo] = value;
			}
			value.gameObject.SetActive(value: true);
			return value;
		}

		public void ReleasePcApp(GUI_PcAppBase pcApp)
		{
			PcAppGuiLifecycleMode guiLifecycleMode = pcApp.AppInfo.GuiLifecycleMode;
			if (guiLifecycleMode != PcAppGuiLifecycleMode.Destroy && guiLifecycleMode == PcAppGuiLifecycleMode.Pool)
			{
				if (!pooledApps.TryGetValue(pcApp.AppInfo, out var value))
				{
					pooledApps[pcApp.AppInfo] = pcApp;
				}
				else if (value != pcApp)
				{
					Debug.LogError("Trying to pool app " + pcApp.AppInfo.name + " that is already pooled, but it's not the same instance. Destroying the released one.");
					Object.Destroy(pcApp.gameObject);
					return;
				}
				pcApp.gameObject.SetActive(value: false);
			}
			else
			{
				pooledApps.Remove(pcApp.AppInfo);
				Object.Destroy(pcApp.gameObject);
			}
		}
	}
}
