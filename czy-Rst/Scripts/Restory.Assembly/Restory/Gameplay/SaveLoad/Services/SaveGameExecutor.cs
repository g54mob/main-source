using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Work.StateMachine;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.SaveLoad.Services
{
	public class SaveGameExecutor
	{
		private IGameplaySaveLoadService saveLoadService;

		private WorkStateMachine workStateMachine;

		private DisassembleStateMachine disassembleStateMachine;

		[Inject]
		private void Construct(IGameplaySaveLoadService saveLoadService, WorkStateMachine workStateMachine, DisassembleStateMachine disassembleStateMachine)
		{
			this.saveLoadService = saveLoadService;
			this.workStateMachine = workStateMachine;
			this.disassembleStateMachine = disassembleStateMachine;
		}

		public void SaveGame()
		{
			if (!(workStateMachine.ActiveState is DetectionWorkState) && !(disassembleStateMachine.ActiveState is DetectionDisassembleState))
			{
				Debug.LogError("Save game operation is available only in DetectionWorkState or DetectionDisassembleState");
			}
			else
			{
				saveLoadService.SaveProgressAsync();
			}
		}
	}
}
