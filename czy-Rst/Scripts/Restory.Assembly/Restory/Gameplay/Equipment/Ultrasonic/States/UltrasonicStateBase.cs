using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.GameCursor;
using Restory.Infrastructure.StateMachine.States.Interfaces;

namespace Restory.Gameplay.Equipment.Ultrasonic.States
{
	public abstract class UltrasonicStateBase : IUltrasonicState
	{
		private readonly UltrasonicStateContext stateContext;

		private readonly UltrasonicStateMachine stateMachine;

		protected SonicBath SonicBath => stateContext.SonicBath;

		protected SonicBathTriggerController TriggerController => stateContext.SonicBath.TriggerController;

		protected SonicBathToggleButton ToggleButton => stateContext.SonicBath.ToggleButton;

		protected SonicBathDrawer Drawer => stateContext.SonicBath.Drawer;

		protected SonicBathCover Cover => stateContext.SonicBath.Cover;

		protected SonicBathTimer Timer => stateContext.SonicBath.Timer;

		protected CursorSelectionService CursorSelectionService => stateContext.CursorSelectionService;

		protected DisassembleStateMachine DisassembleStateMachine => stateContext.DisassembleStateMachine;

		protected IExitableState DisassembleState => stateContext.DisassembleStateMachine.ActiveState;

		protected bool IsPulled => stateContext.SonicBath.Drawer.IsPulled;

		protected bool IsOpen => stateContext.SonicBath.Cover.IsOpen;

		protected IUltrasonicStateSwitcher StateSwitcher => stateMachine;

		protected UltrasonicStateBase(UltrasonicStateContext stateContext, UltrasonicStateMachine stateMachine)
		{
			this.stateContext = stateContext;
			this.stateMachine = stateMachine;
		}

		public abstract void Enter();

		public abstract void Exit();
	}
}
