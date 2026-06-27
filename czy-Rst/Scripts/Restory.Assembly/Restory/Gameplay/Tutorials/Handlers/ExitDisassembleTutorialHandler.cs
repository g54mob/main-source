using Restory.Data.Devices.Quality;
using Restory.Data.Tutorials;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Tutorials.Settings;
using Restory.Gameplay.UserInterface;
using Restory.UI.Views.Tooltips;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class ExitDisassembleTutorialHandler : TutorialHandlerBase
	{
		private readonly DeviceService deviceService;

		private readonly DisassembleStateMachine disassembleStateMachine;

		private readonly GUI_DisassembleObjectGameModeCanvas disassembleCanvas;

		private readonly ExitDisassembleTutorialSettings settings;

		private GUI_TooltipIndicator trackedIndicator;

		private bool wasDeviceRestored;

		[Inject]
		public ExitDisassembleTutorialHandler(DeviceService deviceService, DisassembleStateMachine disassembleStateMachine, GUI_DisassembleObjectGameModeCanvas disassembleCanvas, ExitDisassembleTutorial tutorial)
			: base(tutorial)
		{
			this.deviceService = deviceService;
			this.disassembleStateMachine = disassembleStateMachine;
			this.disassembleCanvas = disassembleCanvas;
			settings = tutorial.Settings;
		}

		public override void Init()
		{
			disassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
			deviceService.OnPlacedDeviceQualityChanged += ResolvePlacedDeviceQualityChanged;
			disassembleCanvas.OnExitAction += ResolveDisassembleCanvasClosed;
		}

		public override void Cleanup()
		{
			disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
			deviceService.OnPlacedDeviceQualityChanged -= ResolvePlacedDeviceQualityChanged;
			disassembleCanvas.OnExitAction -= ResolveDisassembleCanvasClosed;
			trackedIndicator = null;
		}

		private void ResolveDisassembleStateChanged()
		{
			if (!base.IsCompleted && disassembleStateMachine.ActiveState is DetectionDisassembleState && disassembleCanvas.gameObject.activeSelf && wasDeviceRestored && !trackedIndicator)
			{
				trackedIndicator = Object.Instantiate(settings.TooltipIndicator, disassembleCanvas.ExitButton.transform);
				trackedIndicator.Init(settings.IndicatorSize, settings.IndicatorOffset);
			}
		}

		private void ResolvePlacedDeviceQualityChanged()
		{
			if (!base.IsCompleted && (bool)deviceService.PlacedDeviceContainer && deviceService.PlacedDeviceContainer.Quality is IdealDeviceQuality)
			{
				wasDeviceRestored = true;
			}
		}

		private void ResolveDisassembleCanvasClosed()
		{
			if (!base.IsCompleted)
			{
				if ((bool)trackedIndicator)
				{
					Object.Destroy(trackedIndicator.gameObject);
					trackedIndicator = null;
					CompleteTutorial();
				}
				else if (wasDeviceRestored)
				{
					CompleteTutorial();
				}
			}
		}
	}
}
