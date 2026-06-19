using System;
using System.Collections.Generic;
using Loxodon.Framework.Observables;
using Michsky.DreamOS;
using Services;
using Services.Enemy;
using UnityEngine;
using Zenject;

namespace UI.Commander
{
	public class BotnetShellModel
	{
		public string ShellName = "BOTNTP";

		public ObservableProperty<bool> IsAttacking = new ObservableProperty<bool>(value: false);

		public CommanderManager.CommandItem ScanNetworkCommand = new CommanderManager.CommandItem();

		public CommanderManager.CommandItem DeployBotsPayloadCommand = new CommanderManager.CommandItem();

		public CommanderManager.CommandItem StopAttackCommand = new CommanderManager.CommandItem();

		public CommanderManager.CommandItem ExitCommand = new CommanderManager.CommandItem();

		public CommanderManager.CommandItem DebugAttackCommand = new CommanderManager.CommandItem();

		public List<CommanderManager.CommandItem> AttackCommands = new List<CommanderManager.CommandItem>();

		public List<CommanderManager.CommandItem> ShellCommands = new List<CommanderManager.CommandItem>();

		private List<string> _disabledURLS = new List<string>();

		private readonly IMoneyService _moneyService;

		private readonly ILoyaltyService _loyaltyService;

		private readonly WebBrowserManager _webBrowserManager;

		private readonly CommanderManager _commanderManager;

		private readonly CommanderViewModel _cmdVM;

		[Inject]
		public BotnetShellModel(IMoneyService moneyService, WebBrowserManager browserManager, CommanderManager commanderManager, CommanderViewModel cmdVM, ILoyaltyService loyaltyService)
		{
			_moneyService = moneyService;
			_webBrowserManager = browserManager;
			_commanderManager = commanderManager;
			_cmdVM = cmdVM;
			_loyaltyService = loyaltyService;
			CreateScanNetworkCommand();
			CreateBaseDeployBots();
			CreateStopAttackCommand();
			CreateDebugAttackCommand();
			CreateExitCommand();
			AttackCommands = new List<CommanderManager.CommandItem>(CreateDeployBotsPayloadCommandsForAllWebsites());
			ShellCommands.Add(ScanNetworkCommand);
			ShellCommands.Add(DeployBotsPayloadCommand);
			ShellCommands.Add(StopAttackCommand);
			ShellCommands.Add(ExitCommand);
			ShellCommands.Add(DebugAttackCommand);
			ShellCommands.AddRange(AttackCommands);
			IsAttacking.ValueChanged += AttackingValueChanged;
		}

		private void CreateExitCommand()
		{
			ExitCommand = new CommanderManager.CommandItem();
			ExitCommand.commandName = "Exit";
			ExitCommand.command = "exit";
			ExitCommand.commandDescription = "Exit Botnet Shell";
			ExitCommand.includeToHelp = true;
			ExitCommand.feedbackText = "Exiting Botnet Shell...";
			ExitCommand.onProcessEvent.AddListener(delegate
			{
				_cmdVM.ExitShell();
				IsAttacking.Value = false;
			});
		}

		private void CreateDebugAttackCommand()
		{
			DebugAttackCommand = new CommanderManager.CommandItem();
			DebugAttackCommand.commandName = "[999] - Debug Attack";
			DebugAttackCommand.command = "999";
			DebugAttackCommand.commandDescription = "Debug Botnet Attack State";
			DebugAttackCommand.feedbackText = "Debugging Botnet Attack State... Current State: " + IsAttacking.Value;
		}

		private void AttackingValueChanged(object sender, EventArgs e)
		{
			Debug.Log("IsAttacking Changed. Value: " + IsAttacking.Value);
			if (IsAttacking.Value)
			{
				DebugAttackCommand.feedbackText = "Debugging Botnet Attack State... Current State: Attacking.";
				StopAttackCommand.feedbackText = "No Active Botnet Attack To Stop.";
				for (int i = 0; i < _webBrowserManager.webLibrary.webPages.Count; i++)
				{
					AttackCommands[i].feedbackText = "Processing attack on ... " + _webBrowserManager.webLibrary.webPages[i].pageURL + ". \n Success.";
				}
				return;
			}
			DebugAttackCommand.feedbackText = "Debugging Botnet Attack State... Current State: Not Attacking.";
			StopAttackCommand.feedbackText = "Stopping Current Botnet Attack... Success!";
			for (int j = 0; j < _webBrowserManager.webLibrary.webPages.Count; j++)
			{
				AttackCommands[j].feedbackText = "Botnet Attack On " + _webBrowserManager.webLibrary.webPages[j].pageURL + " Stopped.";
			}
			foreach (string url in _disabledURLS)
			{
				_webBrowserManager.webLibrary.webPages.Find((WebBrowserLibrary.WebPage p) => p.pageURL == url).IsUp = true;
			}
		}

		private void CreateScanNetworkCommand()
		{
			ScanNetworkCommand = new CommanderManager.CommandItem();
			ScanNetworkCommand.commandName = "[1] - Scan";
			ScanNetworkCommand.command = "1";
			ScanNetworkCommand.commandDescription = "Scan Local Network";
			ScanNetworkCommand.includeToHelp = true;
			string text = "";
			text += "Scanning Network For Websites...\n";
			foreach (WebBrowserLibrary.WebPage webPage in _webBrowserManager.webLibrary.webPages)
			{
				text = text + webPage.pageURL + "\n";
			}
			ScanNetworkCommand.feedbackText = text;
			ScanNetworkCommand.onProcessEvent.AddListener(ScanNetwork);
		}

		private void CreateStopAttackCommand()
		{
			StopAttackCommand = new CommanderManager.CommandItem();
			StopAttackCommand.commandName = "[3] - Stop Attack";
			StopAttackCommand.command = "3";
			StopAttackCommand.commandDescription = "Stop Current Botnet Attack";
			StopAttackCommand.includeToHelp = true;
			StopAttackCommand.feedbackText = "No Active Botnet Attack To Stop.";
			StopAttackCommand.onProcessEvent.AddListener(StopBotAttack);
		}

		private void StopBotAttack()
		{
			if (IsAttacking.Value)
			{
				IsAttacking.Value = false;
			}
			else
			{
				StopAttackCommand.feedbackText = "No Active Botnet Attack To Stop.";
			}
		}

		private void CreateBaseDeployBots()
		{
			DeployBotsPayloadCommand = new CommanderManager.CommandItem();
			DeployBotsPayloadCommand.commandName = "[2] - Bots";
			DeployBotsPayloadCommand.command = "2";
			DeployBotsPayloadCommand.commandDescription = "Deploy Bots to URL";
			DeployBotsPayloadCommand.includeToHelp = true;
			DeployBotsPayloadCommand.feedbackText = "Usage: 2 [URL]\nDeploy Bots Payload To Specified URL.";
		}

		private List<CommanderManager.CommandItem> CreateDeployBotsPayloadCommandsForAllWebsites()
		{
			List<CommanderManager.CommandItem> list = new List<CommanderManager.CommandItem>();
			foreach (WebBrowserLibrary.WebPage page in _webBrowserManager.webLibrary.webPages)
			{
				CommanderManager.CommandItem commandItem = new CommanderManager.CommandItem();
				commandItem.commandName = "[2] - Deploy Bots Payload";
				commandItem.command = "2 " + page.pageURL;
				commandItem.commandDescription = "Deploy Bots Payload To ";
				commandItem.includeToHelp = false;
				commandItem.feedbackText = "Deploying Bots Payload To " + page.pageURL + "... Success!";
				commandItem.onProcessDelay = 0f;
				commandItem.onProcessEvent.AddListener(delegate
				{
					TryAttackURL(page.pageURL);
				});
				list.Add(commandItem);
			}
			return list;
		}

		private void TryAttackURL(string url)
		{
			if (!IsAttacking.Value)
			{
				IsAttacking.Value = true;
				_webBrowserManager.webLibrary.webPages.Find((WebBrowserLibrary.WebPage p) => p.pageURL == url).IsUp = false;
				_disabledURLS.Add(url);
			}
			else
			{
				for (int num = 0; num < _webBrowserManager.webLibrary.webPages.Count; num++)
				{
					AttackCommands[num].feedbackText = "Can not process attack on " + _webBrowserManager.webLibrary.webPages[num].pageURL + ". Current Attack In Progress...";
				}
			}
		}

		private void ScanNetwork()
		{
			Debug.Log("Scanning Network");
		}

		public void WriteUpdates()
		{
			double num = UnityEngine.Random.Range(0.003f, 0.01f);
			_moneyService.AddCurrency(num);
			_loyaltyService.AddStressValue((float)num * 150f);
			if (IsAttacking.Value)
			{
				_commanderManager.ClearHistory();
				_commanderManager.AddToHistory($"Attack In Proces. Adding {num} FlyCoin", useTypewriter: false);
			}
		}
	}
}
