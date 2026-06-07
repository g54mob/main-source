using System.Collections.Generic;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Processes;
using Server;

namespace Motorways.Models
{
	public class UpgradeDatabaseModel : UpgradeDatabase, IModel, IReusable, IReleasedFromScopeHandler
	{
		private int[] _claimedPackageCounts = new int[9];

		private int[] _consecutiveWeeksSinceUpgradeLastPresented = new int[9];

		[Serialize(false, null)]
		public int[] timesUpgradePresented = new int[9];

		public List<UpgradeChoice> pendingUpgradeChoices = new List<UpgradeChoice>();

		public int numChoicesMade;

		[Dependency]
		private ClockModel _clock;

		[Serialize(true, null)]
		public Fix64 accumulatedUpgradeScheduleDelayTime = Fix64Consts.Zero;

		[Serialize(true, null)]
		public bool upgradeSchedulePaused;

		[Serialize(true, null)]
		public int TotalClaimedPackages { get; private set; }

		[Serialize(true, null)]
		public UpgradeType LastClaimedPackageType { get; private set; } = UpgradeType.Count;

		public bool IsPendingUpgradeAvailable => pendingUpgradeChoices.Count > 0;

		public virtual int TotalGrantedUpgradesCount => TotalClaimedPackages + pendingUpgradeChoices.Count;

		public bool HasPendingUpgrades => pendingUpgradeChoices.Count > 0;

		public override void Reset()
		{
			base.Reset();
			for (int i = 0; i < 9; i++)
			{
				_claimedPackageCounts[i] = 0;
				_consecutiveWeeksSinceUpgradeLastPresented[i] = 0;
				timesUpgradePresented[i] = 0;
			}
			LastClaimedPackageType = UpgradeType.Count;
			pendingUpgradeChoices.Clear();
			TotalClaimedPackages = 0;
			accumulatedUpgradeScheduleDelayTime = Fix64Consts.Zero;
			upgradeSchedulePaused = false;
		}

		public virtual void AddPendingUpgradeChoice(UpgradeChoice upgradeChoice)
		{
			pendingUpgradeChoices.Add(upgradeChoice);
		}

		public virtual void ApplyUpgradePackage(UpgradePackageDefinition upgradePackage, bool freeUpgrade = false)
		{
			LastClaimedPackageType = upgradePackage.type;
			_totalUpgrades[(int)upgradePackage.type] += upgradePackage.amount;
			_availableUpgrades[(int)upgradePackage.type] += upgradePackage.amount;
			if (!freeUpgrade)
			{
				_claimedPackageCounts[(int)upgradePackage.type]++;
				TotalClaimedPackages++;
			}
			if (upgradePackage.additionalConcrete > 0)
			{
				_totalUpgrades[0] += upgradePackage.additionalConcrete;
				_availableUpgrades[0] += upgradePackage.additionalConcrete;
			}
			NotifyUpgradesChanged();
		}

		public virtual bool HasUpgradeBeenPresented(UpgradeType upgradeType)
		{
			return _consecutiveWeeksSinceUpgradeLastPresented[(int)upgradeType] < _clock.Week;
		}

		public virtual int NumberOfPackagesTakenOf(UpgradeType type)
		{
			return _claimedPackageCounts[(int)type];
		}

		public virtual void OnUpgradeNotPresented(UpgradeType upgradeType)
		{
			_consecutiveWeeksSinceUpgradeLastPresented[(int)upgradeType]++;
		}

		public virtual void OnUpgradePresented(UpgradeType upgradeType)
		{
			timesUpgradePresented[(int)upgradeType]++;
			_consecutiveWeeksSinceUpgradeLastPresented[(int)upgradeType] = 0;
		}

		public virtual int WeeksSinceUpgradePresented(UpgradeType upgradeType)
		{
			return _consecutiveWeeksSinceUpgradeLastPresented[(int)upgradeType];
		}

		public void OnReleasedFromScope(IScope scope)
		{
			foreach (UpgradeChoice pendingUpgradeChoice in pendingUpgradeChoices)
			{
				scope.Release(pendingUpgradeChoice);
			}
			pendingUpgradeChoices.Clear();
		}
	}
}
