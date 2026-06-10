using NSMedieval.State.WorkerJobs;

namespace Models.Type
{
	public static class EnumExtensions
	{
		public static bool IsDrafted(this UnitCombatModeType combatType)
		{
			if (combatType != UnitCombatModeType.DraftedDefault)
			{
				return combatType == UnitCombatModeType.DraftedHoldGround;
			}
			return true;
		}
	}
}
