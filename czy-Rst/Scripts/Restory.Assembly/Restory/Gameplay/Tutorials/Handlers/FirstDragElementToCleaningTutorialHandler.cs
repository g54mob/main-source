using Restory.Data.Elements.Condition;
using Restory.Data.Tutorials;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.Tutorials.Settings;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UI.Views.Tooltips;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class FirstDragElementToCleaningTutorialHandler : TutorialHandlerBase
	{
		private readonly DiContainer diContainer;

		private readonly DragElementRegistrator dragElementRegistrator;

		private readonly DisassembleStateMachine disassembleStateMachine;

		private readonly Transform tutorialIconsCanvas;

		private readonly ElementCleaner elementCleaner;

		private readonly FirstDragElementToCleaningTutorialSettings settings;

		private GUI_MouseTooltip mouseTooltip;

		[Inject]
		public FirstDragElementToCleaningTutorialHandler(DiContainer diContainer, DragElementRegistrator dragElementRegistrator, DisassembleStateMachine disassembleStateMachine, [Inject(Id = "GameWorldTutorialIconsCanvas")] Transform tutorialIconsCanvas, ElementCleaner elementCleaner, FirstDragElementToCleaningTutorial tutorial)
			: base(tutorial)
		{
			this.disassembleStateMachine = disassembleStateMachine;
			this.elementCleaner = elementCleaner;
			this.dragElementRegistrator = dragElementRegistrator;
			this.diContainer = diContainer;
			this.tutorialIconsCanvas = tutorialIconsCanvas;
			settings = tutorial.Settings;
		}

		public override void Init()
		{
			dragElementRegistrator.OnElementStartDrag += ResolveStartedDraggingElement;
			dragElementRegistrator.OnElementStopDrag += ResolveStoppedDraggingElement;
			disassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
			ResolveDisassembleStateChanged();
		}

		public override void Cleanup()
		{
			dragElementRegistrator.OnElementStartDrag -= ResolveStartedDraggingElement;
			dragElementRegistrator.OnElementStopDrag -= ResolveStoppedDraggingElement;
			disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
			DestroyMouseTooltip();
		}

		private void ResolveDisassembleStateChanged()
		{
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (activeState is TransitionToCleaningDisassembleState || activeState is CleaningDisassembleState)
			{
				disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
				CompleteTutorial();
			}
		}

		private void ResolveStartedDraggingElement()
		{
			if (!base.IsCompleted && dragElementRegistrator.DraggingElement.ConditionHandler.ElementData.Condition is DirtyElementCondition)
			{
				mouseTooltip = CreateMouseTooltip(elementCleaner.ElementDragMouseTooltipPoint);
				mouseTooltip.PlayDiagonalAnimation();
			}
		}

		private void ResolveStoppedDraggingElement()
		{
			DestroyMouseTooltip();
		}

		private GUI_MouseTooltip CreateMouseTooltip(Transform target)
		{
			DestroyMouseTooltip();
			GUI_MouseTooltip gUI_MouseTooltip = diContainer.InstantiatePrefabForComponent<GUI_MouseTooltip>(settings.TooltipPrefab.gameObject, tutorialIconsCanvas);
			gUI_MouseTooltip.Init(target);
			return gUI_MouseTooltip;
		}

		private void DestroyMouseTooltip()
		{
			if ((bool)mouseTooltip)
			{
				Object.Destroy(mouseTooltip.gameObject);
			}
		}
	}
}
