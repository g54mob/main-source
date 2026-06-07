using UnityEngine;

namespace Data.FactoryFloor.Freighter
{
	[CreateAssetMenu(fileName = "FreighterObjectData", menuName = "Factory/FactoryBehaviour/Freighter/Data")]
	public class FreighterObjectData : ScriptableObject
	{
		public FreighterSlotsBehaviour SlotsBehaviour;

		public FreighterMovementBehaviour MovementBehaviour;

		public FreighterPathBehaviour PathBehaviour;
	}
}
