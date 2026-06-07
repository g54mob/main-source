using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects
{
	public abstract class EquipmentManager : GameMonoBehaviour
	{
		public static int MaxCapacity => 0;

		public List<Equipment> ActiveEquipment { get; }

		public List<Equipment> HiddenEquipment { get; }

		public List<Equipment> RemovedHiddenEquipment { get; }

		public List<Equipment> RemovedEquipment { get; }

		public Equipment GetEquipmentByType(WeaponType equipmentType, bool searchHidden = false)
		{
			return null;
		}

		public Equipment GetRemovedHiddenEquipment(WeaponType equipmentType)
		{
			return null;
		}

		public Equipment GetRemovedEquipment(WeaponType equipmentType)
		{
			return null;
		}

		public void LevelUpAllActiveEquipment()
		{
		}

		public void MaxLevelUpAllEquipment()
		{
		}

		public void AddEquipment(Equipment item)
		{
		}

		public void AddHiddenEquipment(Equipment item)
		{
		}

		public void RemoveEquipment(Equipment item)
		{
		}

		public void RemoveHiddenEquipment(Equipment item)
		{
		}
	}
}
