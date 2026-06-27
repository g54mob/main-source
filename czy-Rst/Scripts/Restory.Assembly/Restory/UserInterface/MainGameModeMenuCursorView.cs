using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Zenject;

namespace Restory.UserInterface
{
	public sealed class MainGameModeMenuCursorView : MenuCursorView
	{
		private DisassembleStateMachine disassembleStateMachine;

		[Inject]
		private void Construct(DisassembleStateMachine disassembleStateMachine)
		{
			this.disassembleStateMachine = disassembleStateMachine;
		}

		protected override bool ShouldCursorIconUpdate()
		{
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (!(activeState is DraggingDisassembleState))
			{
				return !(activeState is CleaningDisassembleState);
			}
			return false;
		}
	}
}
