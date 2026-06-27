using System;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.GameCursor;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class ElementDetectionRegistrator : IInitializable, IDisposable
	{
		private readonly CursorSelectionService cursorSelectionService;

		private readonly DisassembleStateMachine disassembleStateMachine;

		private ElementBase detectedElement;

		public ElementBase DetectedElement => detectedElement;

		public event Action OnDetectionStateChanged;

		[Inject]
		public ElementDetectionRegistrator(CursorSelectionService cursorSelectionService, DisassembleStateMachine disassembleStateMachine)
		{
			this.cursorSelectionService = cursorSelectionService;
			this.disassembleStateMachine = disassembleStateMachine;
		}

		public void Initialize()
		{
			cursorSelectionService.OnDetectionStateChanged += ResolveDetectionStateChanged;
		}

		public void Dispose()
		{
			cursorSelectionService.OnDetectionStateChanged -= ResolveDetectionStateChanged;
		}

		private void ResolveDetectionStateChanged()
		{
			if ((bool)detectedElement)
			{
				detectedElement = null;
				this.OnDetectionStateChanged?.Invoke();
			}
			if (!(disassembleStateMachine.ActiveState is DisabledDisassembleState) && cursorSelectionService.HasDetection && (cursorSelectionService.DetectedGameObject.transform.TryGetComponent<ElementBase>(out var component) || cursorSelectionService.DetectedGameObject.transform.parent.TryGetComponent<ElementBase>(out component)))
			{
				detectedElement = component;
				this.OnDetectionStateChanged?.Invoke();
			}
		}
	}
}
