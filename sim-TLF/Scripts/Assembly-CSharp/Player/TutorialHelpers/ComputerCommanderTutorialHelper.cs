using Michsky.DreamOS;
using Zenject;

namespace Player.TutorialHelpers
{
	public class ComputerCommanderTutorialHelper : BaseTutorialHelper
	{
		[Inject]
		private CommanderManager _commanderManager;

		private void OnEnable()
		{
			_commanderManager.OnCommandProcessing += TutorialCommandProcess;
		}

		private void TutorialCommandProcess(string commandName)
		{
			if (commandName == _commanderManager.helpCommand)
			{
				EmitStep("checkCommands");
			}
		}
	}
}
