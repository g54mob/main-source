using Computer.Commander;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using Michsky.DreamOS;
using Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Commander
{
	public class CommanderView : UIView
	{
		[SerializeField]
		private TextMeshProUGUI _shellText;

		[SerializeField]
		private int _updateEveryNSecs = 5;

		private int updateDelay;

		[Inject]
		private IMoneyService _moneyService;

		[Inject]
		private DiContainer _diContainer;

		[Inject]
		private CommanderViewModel _commanderViewModel;

		[Inject]
		private CommanderManager _commanderManager;

		protected override void Start()
		{
			BindingSet<CommanderView, CommanderViewModel> bindingSet = this.CreateBindingSet<CommanderView, CommanderViewModel>();
			CommanderViewModel commanderViewModel = _commanderViewModel;
			this.SetDataContext(commanderViewModel);
			bindingSet.Bind(_shellText).For((TextMeshProUGUI v) => v.text).To((CommanderViewModel vm) => vm.ShellName)
				.OneWay();
			bindingSet.Bind(_shellText.gameObject).For((GameObject v) => v.activeSelf).To((CommanderViewModel vm) => vm.InShell)
				.OneWay();
			bindingSet.Build();
		}

		public void ActivateShell(CommanderShell shell)
		{
			(this.GetDataContext() as CommanderViewModel).ActivateShell(shell);
		}

		public void ActivateBotNetShell()
		{
			(this.GetDataContext() as CommanderViewModel).ActivateBotNetShell();
		}

		public void ShowBalance()
		{
			_commanderManager.AddToHistory($"Your Current Balance is: {_moneyService.CurrencyBalance.FlyCoinsBalance} SkyCoins.", useTypewriter: true, 0.01f, showTime: false);
		}

		private void Update()
		{
			if (updateDelay % 300 == 0)
			{
				(this.GetDataContext() as CommanderViewModel).UpdateShell();
				updateDelay = 0;
			}
			updateDelay++;
		}
	}
}
