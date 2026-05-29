using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class ActionAssignSeatAndTable : InstantAction, IGive<Seat>, IGive<Table>
	{
		[SerializeField]
		private SoftReference<Seat> _seat;

		[SerializeField]
		private SoftReference<Table> _table;

		protected override bool PlayAction(ActionSequence sequence)
		{
			Agent playerAgent = sequence.PlayerAgent;
			if ((object)playerAgent == null)
			{
				return false;
			}
			Table table = _table.Get();
			Seat seat = _seat.Get();
			if (!(playerAgent is Customer customer))
			{
				return false;
			}
			if (customer.GroupData.Count > 0)
			{
				customer.SeparateFromGroup();
			}
			Seat assignedSeat = customer.AssignedSeat;
			Table assignedTable = customer.GroupData.AssignedTable;
			if ((bool)assignedSeat && assignedSeat != seat)
			{
				customer.ReleaseSeat();
			}
			if ((bool)assignedTable && assignedTable != table)
			{
				customer.GroupData.ReleaseTable();
			}
			if (!Table.AvailabilityFilter(table, customer))
			{
				FinishAction(wasSuccessful: false);
				return false;
			}
			if ((bool)table.User)
			{
				customer.GroupData.MergeTo(table.User.Cast<Customer>().GroupData);
			}
			else
			{
				customer.GroupData.AssignTable(table);
			}
			customer.AssignSeat(seat);
			return true;
		}

		Seat IGive<Seat>.Get()
		{
			return _seat;
		}

		Table IGive<Table>.Get()
		{
			return _table;
		}
	}
}
