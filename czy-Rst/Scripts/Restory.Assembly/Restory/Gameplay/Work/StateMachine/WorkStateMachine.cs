using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.Infrastructure.StateMachines;
using Zenject;

namespace Restory.Gameplay.Work.StateMachine
{
	public sealed class WorkStateMachine : StateMachineMonoBase
	{
		private DisabledWorkState.Factory disabledStateFactory;

		private DetectionWorkState.Factory detectionStateFactory;

		private DraggingWorkState.Factory draggingStateFactory;

		private DialogueWorkState.Factory dialogueStateFactory;

		private HackingWorkState.Factory hackingStateFactory;

		[Inject]
		private void Construct(DisabledWorkState.Factory disabledStateFactory, DetectionWorkState.Factory detectionStateFactory, DraggingWorkState.Factory draggingStateFactory, DialogueWorkState.Factory dialogueStateFactory, HackingWorkState.Factory hackingStateFactory)
		{
			this.disabledStateFactory = disabledStateFactory;
			this.detectionStateFactory = detectionStateFactory;
			this.draggingStateFactory = draggingStateFactory;
			this.dialogueStateFactory = dialogueStateFactory;
			this.hackingStateFactory = hackingStateFactory;
		}

		public override void Initialize()
		{
			states.Add(typeof(DisabledWorkState), disabledStateFactory.Create());
			states.Add(typeof(DetectionWorkState), detectionStateFactory.Create());
			states.Add(typeof(DraggingWorkState), draggingStateFactory.Create());
			states.Add(typeof(DialogueWorkState), dialogueStateFactory.Create());
			states.Add(typeof(HackingWorkState), hackingStateFactory.Create());
			foreach (IExitableState value in states.Values)
			{
				value.Exit();
			}
			Enter<DisabledWorkState>();
		}

		public override void ExitToDefaultState()
		{
			if (!(base.ActiveState is DisabledWorkState))
			{
				Enter<DisabledWorkState>();
			}
		}
	}
}
