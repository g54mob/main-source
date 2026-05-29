using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;

namespace CTS.BBT.AI
{
	internal class AgentActionAssignTable : SimpleAgentAction
	{
		public override bool CanBePerformed(Agent agentRef)
		{
			if (!CTSSingleton<LevelParameters>.Instance)
			{
				return false;
			}
			if (!(agentRef is Customer customer))
			{
				return false;
			}
			if ((bool)customer.GroupData.AssignedTable)
			{
				return false;
			}
			return CTSSingleton<LevelParameters>.Instance.Furnitures.DoesAnyExist(Table.AvailableForOne, customer);
		}

		protected override void Execute()
		{
			if (!(base.ActionAgent is Customer customer))
			{
				return;
			}
			if (!TryGetTable(customer, out var outTable))
			{
				if (CTSSingleton<LevelParameters>.Instance.Furnitures.DoesAnyExist(Table.AvailableForOne, customer))
				{
					customer.SeparateFromGroup();
				}
				CancelAction("A table wasn't found");
				return;
			}
			foreach (CustomerGroupData usingGroup in outTable.UsingGroups)
			{
				if (usingGroup.Members[0].IsVampire == customer.IsVampire)
				{
					customer.GroupData.MergeTo(usingGroup.Members[0].GroupData);
					return;
				}
			}
			customer.GroupData.AssignTable(outTable);
		}

		private static bool TryGetTable(Customer customer, out Table outTable)
		{
			SortedList<int, Table> sortedList = new SortedList<int, Table>();
			foreach (Table item in CTSSingleton<LevelParameters>.Instance.Furnitures.Enumerate<Table>())
			{
				RoomBuilding currentRoom = item.Furniture.RoomObject.CurrentRoom;
				if (currentRoom == null || !(1 << currentRoom.NavArea.Area).ExistsInMask(customer.Movement.DefaultAreaMask))
				{
					continue;
				}
				int availableSeatCount = item.AvailableSeatCount;
				if (availableSeatCount < customer.GroupData.Count)
				{
					continue;
				}
				int num = 0;
				bool isVampire = customer.IsVampire;
				bool flag = true;
				if (item.UsingGroups.Count > 0)
				{
					if (!isVampire)
					{
						num += 1000;
					}
					foreach (CustomerGroupData usingGroup in item.UsingGroups)
					{
						if (usingGroup.Members[0].IsVampire != customer.IsVampire)
						{
							flag = false;
						}
					}
					if (!flag)
					{
						num += 1000;
					}
				}
				else if (isVampire)
				{
					num += 1000;
				}
				num += 100 - availableSeatCount;
				if (currentRoom.NavArea.Area != (customer.IsVampire ? customer.VampireFavoriteRoom : customer.HumanFavoriteRoom))
				{
					num += 2000;
				}
				if (!sortedList.ContainsKey(num))
				{
					sortedList.Add(num, item);
				}
			}
			if (sortedList.Count <= 0)
			{
				outTable = null;
				return false;
			}
			outTable = sortedList.Values[0];
			return true;
		}
	}
}
