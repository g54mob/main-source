using System;
using System.Collections;
using Restory.Gameplay.Disassemble;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Infrastructure.ProjectServices;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.OverlayActivators
{
	public class WindowActivatorsController : IInitializable, IDisposable
	{
		private readonly InventoryActivator inventoryActivator;

		private readonly NotepadActivator notepadActivator;

		private readonly PcActivator pcActivator;

		private readonly DisassembleStateMachine disassembleStateMachine;

		private readonly DisassembleGameMode disassembleGameMode;

		private readonly ICoroutineRunner coroutineRunner;

		private Coroutine checkDisassembleModeAfterEndOfFrameCoroutine;

		[Inject]
		public WindowActivatorsController(InventoryActivator inventoryActivator, NotepadActivator notepadActivator, PcActivator pcActivator, DisassembleStateMachine disassembleStateMachine, DisassembleGameMode disassembleGameMode, ICoroutineRunner coroutineRunner)
		{
			this.inventoryActivator = inventoryActivator;
			this.notepadActivator = notepadActivator;
			this.pcActivator = pcActivator;
			this.disassembleStateMachine = disassembleStateMachine;
			this.disassembleGameMode = disassembleGameMode;
			this.coroutineRunner = coroutineRunner;
		}

		public void Initialize()
		{
			disassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
		}

		public void Dispose()
		{
			disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
			if (checkDisassembleModeAfterEndOfFrameCoroutine != null && ((coroutineRunner is MonoBehaviour monoBehaviour && monoBehaviour.MonoShellExists()) || coroutineRunner != null))
			{
				coroutineRunner.Stop(checkDisassembleModeAfterEndOfFrameCoroutine);
			}
		}

		private void ResolveDisassembleStateChanged()
		{
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (!(activeState is DisabledDisassembleState))
			{
				if (!(activeState is DetectionDisassembleState))
				{
					if (!(activeState is TransitionToCleaningDisassembleState) && !(activeState is PaintingDisassembleState))
					{
						if (activeState is TransitionFromCleaningDisassembleState)
						{
							inventoryActivator.IsBlocked = false;
							pcActivator.IsBlocked = false;
						}
					}
					else
					{
						ChangeActivatorsBlockingState(isBlocked: true);
						HideWindows();
					}
				}
				else
				{
					CheckDisassembleModeAfterEndOfFrame();
				}
			}
			else
			{
				ChangeActivatorsBlockingState(isBlocked: false);
			}
		}

		public void ChangeActivatorsBlockingState(bool isBlocked)
		{
			inventoryActivator.IsBlocked = isBlocked;
			notepadActivator.IsBlocked = isBlocked;
			pcActivator.IsBlocked = isBlocked;
		}

		private void HideWindows()
		{
			notepadActivator.HideWindow();
			inventoryActivator.HideWindow();
			pcActivator.HideWindow();
		}

		private void CheckDisassembleModeAfterEndOfFrame()
		{
			if (checkDisassembleModeAfterEndOfFrameCoroutine == null)
			{
				checkDisassembleModeAfterEndOfFrameCoroutine = coroutineRunner.Run(CheckDisassembleModeAfterEndOfFrameCoroutine());
			}
		}

		private IEnumerator CheckDisassembleModeAfterEndOfFrameCoroutine()
		{
			yield return new WaitForEndOfFrame();
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (activeState is DetectionDisassembleState || activeState is DraggingDisassembleState)
			{
				if (disassembleGameMode.IsInCompetition)
				{
					notepadActivator.IsBlocked = true;
					inventoryActivator.IsBlocked = true;
					pcActivator.IsBlocked = true;
					HideWindows();
				}
				else
				{
					notepadActivator.IsBlocked = true;
					inventoryActivator.IsBlocked = false;
					pcActivator.IsBlocked = false;
				}
			}
			checkDisassembleModeAfterEndOfFrameCoroutine = null;
		}
	}
}
