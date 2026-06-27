using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.GameCursor;

namespace Restory.Gameplay.Equipment.Ultrasonic.States
{
	public class UltrasonicStateContext
	{
		public SonicBath SonicBath { get; }

		public CursorSelectionService CursorSelectionService { get; }

		public DisassembleStateMachine DisassembleStateMachine { get; }

		public UltrasonicStateContext(SonicBath sonicBath, CursorSelectionService cursorSelectionService, DisassembleStateMachine disassembleStateMachine)
		{
			SonicBath = sonicBath;
			CursorSelectionService = cursorSelectionService;
			DisassembleStateMachine = disassembleStateMachine;
		}
	}
}
