using System.Collections.Generic;
using UnityEngine;

namespace Data.FactoryFloor.Freighter.Actions
{
	[CreateAssetMenu(fileName = "FreighterSlotActionsDatabase", menuName = "Factory/FactoryBehaviour/Freighter/SlotActionsDatabase")]
	public class FreighterSlotActionsDatabase : ScriptableObject
	{
		[SerializeField]
		private FreighterSlotAction[] _freighterSlotActions;

		public IReadOnlyList<FreighterSlotAction> Actions => _freighterSlotActions;
	}
}
