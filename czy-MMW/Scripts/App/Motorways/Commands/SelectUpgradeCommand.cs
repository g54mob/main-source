using Factory;
using Motorways.Models;
using Motorways.Processes;
using Motorways.Views;
using Server;

namespace Motorways.Commands
{
	public class SelectUpgradeCommand : Command
	{
		[Dependency]
		private IScope _scope;

		[Dependency]
		private UpgradeDatabaseModel _upgradeDatabase;

		private int _upgradeIndex;

		public override void Execute(ISimulation simulation)
		{
			if (!Diagnostics.Verify(_upgradeIndex >= 0, "Upgrade index must be greater than zero! Not {0}", _upgradeIndex) || !Diagnostics.Verify(_upgradeDatabase.pendingUpgradeChoices.Count > 0, "There are no upgrade choices available! Cancelling SelectUpgradeCommand"))
			{
				return;
			}
			_upgradeDatabase.numChoicesMade--;
			UpgradeChoice upgradeChoice = _upgradeDatabase.pendingUpgradeChoices[0];
			_upgradeDatabase.pendingUpgradeChoices.RemoveAt(0);
			if (Diagnostics.Verify(upgradeChoice.choices.Count > _upgradeIndex, "Index {0} is not a valid choice here!", _upgradeIndex))
			{
				UpgradePackageDefinition upgradePackage = upgradeChoice.choices[_upgradeIndex];
				Command.Log.Info("Choosing upgrade {0}, index {1}", upgradePackage.type, _upgradeIndex);
				_upgradeDatabase.ApplyUpgradePackage(upgradePackage, upgradeChoice.isFree);
				simulation.Scope.Get<UpgradeBarClient>().AddPendingToUpgradeButtonStack(upgradePackage.type, upgradePackage.amount);
				if (upgradePackage.additionalConcrete > 0)
				{
					simulation.Scope.Get<UpgradeBarClient>().AddPendingToUpgradeButtonStack(UpgradeType.Concrete, upgradePackage.additionalConcrete);
				}
			}
			_scope.Release(upgradeChoice);
		}

		public override void Reset()
		{
			base.Reset();
			_upgradeIndex = 0;
		}

		public static SelectUpgradeCommand Create(IScope scope, int upgradeIndex)
		{
			SelectUpgradeCommand selectUpgradeCommand = scope.Get<SelectUpgradeCommand>();
			selectUpgradeCommand._upgradeIndex = upgradeIndex;
			return selectUpgradeCommand;
		}
	}
}
