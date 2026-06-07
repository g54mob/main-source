using System.Collections.Generic;
using System.Linq;

namespace CTS
{
	public abstract class BaseSpecificRoomTypeNumericalGoal : QuestNumericGoal
	{
		protected List<NavigationArea> RoomTypes { get; private set; }

		public BaseSpecificRoomTypeNumericalGoal(Quest quest, int entryID, string variableName, string targetVariableName, params NavigationArea[] roomTypes)
			: base(quest, entryID, variableName, targetVariableName)
		{
			RoomTypes = roomTypes.ToList();
		}
	}
}
