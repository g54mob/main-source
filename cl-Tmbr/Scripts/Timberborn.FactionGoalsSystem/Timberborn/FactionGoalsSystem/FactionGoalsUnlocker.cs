using System.Collections.Immutable;
using Timberborn.FactionSystem;
using Timberborn.GameFactionSystem;
using Timberborn.TickSystem;
using Timberborn.Wellbeing;

namespace Timberborn.FactionGoalsSystem
{
	internal class FactionGoalsUnlocker : ITickableSingleton
	{
		private readonly FactionUnlockingService _factionUnlockingService;

		private readonly WellbeingService _wellbeingService;

		private readonly FactionService _factionService;

		private readonly FactionSpecService _factionSpecService;

		public FactionGoalsUnlocker(FactionUnlockingService factionUnlockingService, WellbeingService wellbeingService, FactionService factionService, FactionSpecService factionSpecService)
		{
			_factionUnlockingService = factionUnlockingService;
			_wellbeingService = wellbeingService;
			_factionService = factionService;
			_factionSpecService = factionSpecService;
		}

		public void Tick()
		{
			ImmutableArray<FactionSpec>.Enumerator enumerator = _factionSpecService.Factions.GetEnumerator();
			while (enumerator.MoveNext())
			{
				FactionSpec current = enumerator.Current;
				if (_factionUnlockingService.IsLocked(current) && UnlockConditionsAreSatisfied(current))
				{
					_factionUnlockingService.UnlockFaction(current);
				}
			}
		}

		private bool UnlockConditionsAreSatisfied(FactionSpec factionSpec)
		{
			UnlockableFactionSpec spec = factionSpec.GetSpec<UnlockableFactionSpec>();
			if (_factionService.Current.Id == spec.PrerequisiteFaction)
			{
				return _wellbeingService.AverageGlobalWellbeing >= spec.AverageWellbeingToUnlock;
			}
			return false;
		}
	}
}
