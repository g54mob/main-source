using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.Infrastructure.StateMachines;
using Zenject;

namespace Restory.Gameplay.Disassemble.StateMachine
{
	public sealed class DisassembleStateMachine : StateMachineMonoBase
	{
		private DisabledDisassembleState.Factory disabledStateFactory;

		private EmptyDisassembleState.Factory emptyStateFactory;

		private DetectionDisassembleState.Factory detectionStateFactory;

		private DismantleDisassembleState.Factory dismantleStateFactory;

		private DraggingDisassembleState.Factory draggingStateFactory;

		private InstallingDisassembleState.Factory installingStateFactory;

		private TransitionToCleaningDisassembleState.Factory transitionToCleaningStateFactory;

		private CleaningDisassembleState.Factory cleaningStateFactory;

		private TransitionFromCleaningDisassembleState.Factory transitionFromCleaningStateFactory;

		private CheckDeviceDisassembleState.Factory checkDeviceStateFactory;

		private PaintingDisassembleState.Factory paintingStateFactory;

		private ElementToInventoryConfirmationDialogueDisassembleState.Factory elementToInventoryConfirmationDialogueStateFactory;

		[Inject]
		private void Construct(DisabledDisassembleState.Factory disabledStateFactory, EmptyDisassembleState.Factory emptyStateFactory, DetectionDisassembleState.Factory detectionStateFactory, DismantleDisassembleState.Factory dismantleStateFactory, DraggingDisassembleState.Factory draggingStateFactory, InstallingDisassembleState.Factory installingStateFactory, TransitionToCleaningDisassembleState.Factory transitionToCleaningStateFactory, CleaningDisassembleState.Factory cleaningStateFactory, TransitionFromCleaningDisassembleState.Factory transitionFromCleaningStateFactory, CheckDeviceDisassembleState.Factory checkDeviceStateFactory, PaintingDisassembleState.Factory paintingStateFactory, ElementToInventoryConfirmationDialogueDisassembleState.Factory elementToInventoryConfirmationDialogueStateFactory)
		{
			this.disabledStateFactory = disabledStateFactory;
			this.emptyStateFactory = emptyStateFactory;
			this.detectionStateFactory = detectionStateFactory;
			this.dismantleStateFactory = dismantleStateFactory;
			this.draggingStateFactory = draggingStateFactory;
			this.installingStateFactory = installingStateFactory;
			this.transitionToCleaningStateFactory = transitionToCleaningStateFactory;
			this.cleaningStateFactory = cleaningStateFactory;
			this.transitionFromCleaningStateFactory = transitionFromCleaningStateFactory;
			this.checkDeviceStateFactory = checkDeviceStateFactory;
			this.paintingStateFactory = paintingStateFactory;
			this.elementToInventoryConfirmationDialogueStateFactory = elementToInventoryConfirmationDialogueStateFactory;
		}

		public override void Initialize()
		{
			states.Add(typeof(DisabledDisassembleState), disabledStateFactory.Create());
			states.Add(typeof(EmptyDisassembleState), emptyStateFactory.Create());
			states.Add(typeof(DetectionDisassembleState), detectionStateFactory.Create());
			states.Add(typeof(DismantleDisassembleState), dismantleStateFactory.Create());
			states.Add(typeof(DraggingDisassembleState), draggingStateFactory.Create());
			states.Add(typeof(InstallingDisassembleState), installingStateFactory.Create());
			states.Add(typeof(TransitionToCleaningDisassembleState), transitionToCleaningStateFactory.Create());
			states.Add(typeof(CleaningDisassembleState), cleaningStateFactory.Create());
			states.Add(typeof(TransitionFromCleaningDisassembleState), transitionFromCleaningStateFactory.Create());
			states.Add(typeof(CheckDeviceDisassembleState), checkDeviceStateFactory.Create());
			states.Add(typeof(PaintingDisassembleState), paintingStateFactory.Create());
			states.Add(typeof(ElementToInventoryConfirmationDialogueDisassembleState), elementToInventoryConfirmationDialogueStateFactory.Create());
			foreach (IExitableState value in states.Values)
			{
				value.Exit();
			}
			Enter<DisabledDisassembleState>();
		}

		public override void ExitToDefaultState()
		{
			if (!(base.ActiveState is DisabledDisassembleState))
			{
				Enter<DisabledDisassembleState>();
			}
		}
	}
}
