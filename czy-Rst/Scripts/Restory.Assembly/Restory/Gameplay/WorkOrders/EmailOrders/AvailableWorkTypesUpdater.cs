using System;
using Restory.Data.Devices.DeviceWorkTypes;
using Restory.Data.Elements.ElementTypes;
using Restory.Data.Equipment;
using Restory.Data.GameConfigs;
using Restory.Data.PC;
using Restory.Data.SaveLoad;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.PC;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.WorkOrders.EmailOrders
{
	public sealed class AvailableWorkTypesUpdater : MonoBehaviour, IInitializable, IDisposable, IPostRestoreComponent
	{
		[SerializeField]
		private DirtType scorchedCircuitDirtType;

		[SerializeField]
		private PcAppCategoryInfo hackingAppCategory;

		private AvailableToolsTrackingService toolsTracker;

		private PcAppManager pcAppManager;

		private AvailableDevicesWorkTypesTrackingService workTypesTracker;

		private GameConfig gameConfig;

		[Inject]
		private void Construct(AvailableToolsTrackingService toolsTracker, PcAppManager pcAppManager, AvailableDevicesWorkTypesTrackingService workTypesTracker, GameConfig gameConfig)
		{
			this.toolsTracker = toolsTracker;
			this.pcAppManager = pcAppManager;
			this.workTypesTracker = workTypesTracker;
			this.gameConfig = gameConfig;
		}

		public void Initialize()
		{
			toolsTracker.OnToolAdded += ResolveToolAdded;
			pcAppManager.OnAppInstalled += ResolveAppInstalled;
		}

		public void Dispose()
		{
			if (toolsTracker.MonoShellExists())
			{
				toolsTracker.OnToolAdded -= ResolveToolAdded;
			}
			if (pcAppManager.MonoShellExists())
			{
				pcAppManager.OnAppInstalled -= ResolveAppInstalled;
			}
		}

		private void ResolveToolAdded(ToolInfo newTool)
		{
			MakeWorkTypeAvailable(newTool);
		}

		private void ResolveAppInstalled(PcAppInfo newApp)
		{
			if (newApp.Category == hackingAppCategory)
			{
				workTypesTracker.MakeWorkTypeAvailable(new DeviceWorkTypeHacking());
			}
		}

		private void MakeWorkTypeAvailable(ToolInfo toolForWork)
		{
			if (toolForWork is SolderingToolInfo)
			{
				workTypesTracker.MakeCleaningWorkTypeAvailable(scorchedCircuitDirtType);
			}
			else if (toolForWork is DevicePainterToolInfo && gameConfig.VersionType == VersionType.Release)
			{
				workTypesTracker.SetAllPaintingWorkTypeAvailable(isAvailable: true);
			}
		}

		public void PostRestore()
		{
			SyncWorkTypesToAvailableTools();
		}

		private void SyncWorkTypesToAvailableTools()
		{
			foreach (ToolInfo availableTool in toolsTracker.AvailableTools)
			{
				MakeWorkTypeAvailable(availableTool);
			}
			foreach (PcAppInfo installedApp in pcAppManager.InstalledApps)
			{
				ResolveAppInstalled(installedApp);
			}
		}
	}
}
