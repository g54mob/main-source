using System;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UI.Presenters.CleaningToolsSelectionWindow;
using Restory.Utils;
using Zenject;

namespace Restory.Gameplay.OverlayActivators
{
	public class CleaningToolsSelectionWindowActivator : IInitializable, IDisposable
	{
		private readonly DisassembleStateMachine disassembleStateMachine;

		private GUI_CleaningToolsSelectionWindow cleaningToolsSelectionWindow;

		public CleaningToolsSelectionWindowActivator(DisassembleStateMachine disassembleStateMachine, GUI_CleaningToolsSelectionWindow cleaningToolsSelectionWindow)
		{
			this.disassembleStateMachine = disassembleStateMachine;
			this.cleaningToolsSelectionWindow = cleaningToolsSelectionWindow;
		}

		public void Initialize()
		{
			disassembleStateMachine.OnStateChanged.AddListener(ResolveStateChanged);
		}

		public void Dispose()
		{
			if (disassembleStateMachine.MonoShellExists())
			{
				disassembleStateMachine.OnStateChanged.RemoveListener(ResolveStateChanged);
			}
		}

		private void ResolveStateChanged()
		{
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (activeState is TransitionToCleaningDisassembleState || activeState is CleaningDisassembleState)
			{
				cleaningToolsSelectionWindow.Show();
			}
			else
			{
				cleaningToolsSelectionWindow.Hide();
			}
		}
	}
}
