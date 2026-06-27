using System;
using Restory.EventSystems.ExitEvents;
using SRDebugger.Services;
using SRDebugger.Services.Implementation;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	public class DebugPanelObserver : IInitializable, IDisposable
	{
		private readonly DebugPanelServiceImpl debugPanelService;

		private readonly ExitEventDispatcher exitEventDispatcher;

		[Inject]
		public DebugPanelObserver(DebugPanelServiceImpl debugPanelService, ExitEventDispatcher exitEventDispatcher)
		{
			this.debugPanelService = debugPanelService;
			this.exitEventDispatcher = exitEventDispatcher;
		}

		public void Initialize()
		{
			debugPanelService.VisibilityChanged += ResolveDebugPanelVisibilityChanged;
		}

		public void Dispose()
		{
			debugPanelService.VisibilityChanged -= ResolveDebugPanelVisibilityChanged;
		}

		private void ResolveDebugPanelVisibilityChanged(IDebugPanelService _, bool isDebugPanelVisible)
		{
			exitEventDispatcher.gameObject.SetActive(!isDebugPanelVisible);
		}
	}
}
