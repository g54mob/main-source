using System.Collections.Generic;
using Computer.Commander;
using Loxodon.Framework.ViewModels;
using Michsky.DreamOS;
using Zenject;

namespace UI.Commander
{
	public class CommanderViewModel : ViewModelBase
	{
		private List<CommanderManager.CommandItem> _baseCommands;

		public BotnetShellModel BotnetShellModel;

		private DiContainer _diContainer;

		private CommanderManager _commanderManager;

		private bool _inShell;

		private string _shellName;

		public bool InShell
		{
			get
			{
				return _inShell;
			}
			set
			{
				Set(ref _inShell, value, "InShell");
			}
		}

		public string ShellName
		{
			get
			{
				return _shellName;
			}
			set
			{
				Set(ref _shellName, value, "ShellName");
			}
		}

		[Inject]
		public CommanderViewModel(DiContainer diContainer, CommanderManager commanderManager)
		{
			_diContainer = diContainer;
			_commanderManager = commanderManager;
			_baseCommands = new List<CommanderManager.CommandItem>(_commanderManager.commands);
			_commanderManager.GetComponent<WindowManager>().onClose.AddListener(ExitShell);
		}

		public void ActivateShell(CommanderShell shell)
		{
			InShell = true;
			ShellName = shell.Name;
			_commanderManager.commands = new List<CommanderManager.CommandItem>(shell.ShellCommands);
		}

		public void ExitShell()
		{
			if (InShell)
			{
				ShellName = "";
				InShell = false;
				_commanderManager.commands = new List<CommanderManager.CommandItem>(_baseCommands);
				BotnetShellModel.IsAttacking.Value = false;
			}
		}

		public void ActivateBotNetShell()
		{
			BotnetShellModel botnetShellModel = (BotnetShellModel = _diContainer.Instantiate<BotnetShellModel>());
			InShell = true;
			ShellName = botnetShellModel.ShellName;
			_commanderManager.commands = new List<CommanderManager.CommandItem>(botnetShellModel.ShellCommands);
		}

		public void UpdateShell()
		{
			if (InShell)
			{
				BotnetShellModel.WriteUpdates();
			}
		}
	}
}
