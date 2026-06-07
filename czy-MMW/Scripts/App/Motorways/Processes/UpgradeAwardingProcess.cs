using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;

namespace Motorways.Processes
{
	public class UpgradeAwardingProcess : IProcess, IReusable
	{
		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("UpgradeAwardingProcess");

		[Dependency]
		private ClockModel _clock;

		[Dependency]
		private UpgradeDatabaseModel _upgrades;

		[Dependency]
		private City _city;

		[Dependency]
		private GameBehaviourModel _behaviour;

		private GameRules _rules => _city.Rules;

		public void Reset()
		{
		}

		public void Step(ISimulation simulation, Fix64 deltaTime)
		{
			if (_upgrades.upgradeSchedulePaused)
			{
				_upgrades.accumulatedUpgradeScheduleDelayTime += deltaTime;
			}
			int num = _rules.GetExpectedUpgradePackageCount(_clock.ExpansionTime - _upgrades.accumulatedUpgradeScheduleDelayTime) - _upgrades.TotalGrantedUpgradesCount;
			if (num > 0)
			{
				GrantUpgradeChoice(num);
			}
		}

		public void GrantUpgradeChoice(int requiredUpgradeCount)
		{
			Log.Info("Granting upgrade choice");
			for (int i = 0; i < requiredUpgradeCount; i++)
			{
				bool flag = false;
				UpgradeChoice upgradeChoice = _behaviour.GenerateNextUpgradeChoices();
				if (upgradeChoice.choices.Count > 0)
				{
					_upgrades.AddPendingUpgradeChoice(upgradeChoice);
					flag = true;
				}
				if (!flag)
				{
					_upgrades.ApplyUpgradePackage(new UpgradePackageDefinition
					{
						type = UpgradeType.Concrete,
						amount = 0,
						additionalConcrete = 0
					});
				}
			}
		}
	}
}
