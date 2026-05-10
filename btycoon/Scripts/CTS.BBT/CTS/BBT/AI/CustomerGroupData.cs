using System;
using System.Collections.Generic;
using CTS.AI;
using CTS.Core;

namespace CTS.BBT.AI
{
	public sealed class CustomerGroupData : CTSBehaviour
	{
		public Guid Index = Guid.NewGuid();

		private MoveTarget _leavePoint;

		public MoveTarget LeavePoint
		{
			get
			{
				if (!_leavePoint)
				{
					_leavePoint = Members[0].SpawnPoint.GetGroupDestination();
				}
				return _leavePoint;
			}
			set
			{
				_leavePoint = value;
			}
		}

		public bool CanEnterBar { get; set; }

		public Customer[] Members { get; set; }

		public int Count => Members.Length;

		public Table AssignedTable { get; private set; }

		public int AssignedSeats
		{
			get
			{
				int num = 0;
				Customer[] members = Members;
				for (int i = 0; i < members.Length; i++)
				{
					if ((bool)members[i].AssignedSeat)
					{
						num++;
					}
				}
				return num;
			}
		}

		internal List<GroupOrder> CurrentOrders { get; } = new List<GroupOrder>();

		internal void AssignTable(Table p_table)
		{
			p_table.AddGroup(this);
			AssignedTable = p_table;
		}

		public void ReleaseTable()
		{
			if ((bool)AssignedTable)
			{
				AssignedTable.RemoveGroup(this);
				AssignedTable = null;
			}
		}

		public void SetMembers(params Customer[] members)
		{
			Members = new Customer[members.Length];
			for (int i = 0; i < Members.Length; i++)
			{
				members[i].SetGroup(this, i);
			}
		}

		public void MergeTo(CustomerGroupData group)
		{
			if (!AssignedTable)
			{
				List<Customer> list = new List<Customer>(group.Members);
				list.AddRange(Members);
				group.SetMembers(list.ToArray());
				CustomerGroups.Push(this);
			}
		}

		internal bool TryGetWaitingOrder(out GroupOrder p_order)
		{
			foreach (GroupOrder currentOrder in CurrentOrders)
			{
				if (currentOrder.IsOrderWaiting())
				{
					p_order = currentOrder;
					return true;
				}
			}
			p_order = null;
			return false;
		}

		internal void ClearGroupOrder(GroupOrder p_order)
		{
			if (!p_order.Destroyed)
			{
				p_order.Destroy();
				CurrentOrders.Remove(p_order);
			}
		}
	}
}
