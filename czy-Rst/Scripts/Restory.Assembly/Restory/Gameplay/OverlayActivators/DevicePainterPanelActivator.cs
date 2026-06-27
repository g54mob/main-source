using System;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.UI.Presenters.DevicePaintingTool;
using Restory.Utils;
using Zenject;

namespace Restory.Gameplay.OverlayActivators
{
	public class DevicePainterPanelActivator : IInitializable, IDisposable
	{
		private readonly DisassembleStateMachine disassembleStateMachine;

		private readonly GUI_DevicePainterPanel painterPanel;

		public DevicePainterPanelActivator(DisassembleStateMachine disassembleStateMachine, GUI_DevicePainterPanel painterPanel)
		{
			this.disassembleStateMachine = disassembleStateMachine;
			this.painterPanel = painterPanel;
		}

		public void Initialize()
		{
			disassembleStateMachine.OnStateEntered.AddListener(ResolveStateEntered);
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
			if (disassembleStateMachine.ActiveState is PaintingDisassembleState)
			{
				painterPanel.Show();
			}
			else
			{
				painterPanel.Hide();
			}
		}
	}
}
