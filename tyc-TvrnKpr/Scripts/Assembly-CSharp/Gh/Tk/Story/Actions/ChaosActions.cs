using System;

namespace Gh.Tk.Story.Actions
{
	public static class ChaosActions
	{
		public enum ChaosActionTypes
		{
			None = 0,
			PropExplode = 1,
			PropBreak = 2,
			PropBreakBeyondRepair = 3,
			PropPutOnFireSmall = 4,
			PropPutOnFireLarge = 5,
			PropCoverInFilth = 6,
			PropRepair = 7,
			PropClean = 8,
			PropPolish = 9,
			StaffGetSick = 10,
			StaffGetHappinessBoost = 11,
			StaffGetHappinessPenalty = 12,
			IngredientSpoilageReduces = 13,
			IngredientSpoilageIncreases = 14
		}

		private static Prop FindProp(Predicate<Prop> filter)
		{
			return null;
		}

		public static Staff GetStaff(ChaosActionTypes action)
		{
			return null;
		}

		public static GameItem GetItem(ChaosActionTypes action)
		{
			return null;
		}

		public static Prop GetProp(ChaosActionTypes action)
		{
			return null;
		}

		public static bool ApplyAction(GameObjectX owner, ChaosActionTypes action)
		{
			return false;
		}
	}
}
