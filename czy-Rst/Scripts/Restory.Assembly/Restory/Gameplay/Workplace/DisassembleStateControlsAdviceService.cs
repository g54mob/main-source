using System;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.Utils;
using Zenject;

namespace Restory.Gameplay.Workplace
{
	public sealed class DisassembleStateControlsAdviceService : IInitializable, IDisposable
	{
		private readonly DisassembleStateMachine disassembleStateMachine;

		private readonly WorkSurface workSurface;

		public DisassembleStateControlsAdviceService(DisassembleStateMachine disassembleStateMachine, WorkSurface workSurface)
		{
			this.workSurface = workSurface;
			this.disassembleStateMachine = disassembleStateMachine;
		}

		public void Initialize()
		{
			disassembleStateMachine.OnStateEntered.AddListener(ResolveStateEntered);
			ResolveStateEntered();
		}

		public void Dispose()
		{
			if (disassembleStateMachine.MonoShellExists())
			{
				disassembleStateMachine.OnStateEntered.RemoveListener(ResolveStateEntered);
			}
		}

		private void ResolveStateEntered()
		{
			WorkSurface obj = workSurface;
			IExitableState activeState = disassembleStateMachine.ActiveState;
			obj.ToggleDisassembleControlsAdvices(!(activeState is EmptyDisassembleState) && !(activeState is DisabledDisassembleState));
		}
	}
}
