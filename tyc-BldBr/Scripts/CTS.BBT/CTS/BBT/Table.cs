using System;
using System.Collections.Generic;
using System.Linq;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.BBT
{
	[Constructor("Construct")]
	public sealed class Table : FurnitureInteractor, IContextActor
	{
		[SerializeField]
		private List<Seat> _seats = new List<Seat>();

		private readonly List<CustomerGroupData> _usingGroups = new List<CustomerGroupData>();

		public static Func<Table, Customer, bool> AvailabilityFilter { get; } = delegate(Table table, Customer customer)
		{
			RoomBuilding currentRoom = table.Furniture.RoomObject.CurrentRoom;
			if (!currentRoom)
			{
				return false;
			}
			return (1 << currentRoom.NavArea.Area).ExistsInMask(customer.Movement.DefaultAreaMask) && customer.GroupData.Count <= table.AvailableSeatCount;
		};

		public static Func<Table, Customer, bool> AvailableForOne { get; } = delegate(Table table, Customer customer)
		{
			RoomBuilding currentRoom = table.Furniture.RoomObject.CurrentRoom;
			if (!currentRoom)
			{
				return false;
			}
			return (1 << currentRoom.NavArea.Area).ExistsInMask(customer.Movement.DefaultAreaMask) && table.AvailableSeatCount > 0;
		};

		public ReadOnlyList<CustomerGroupData> UsingGroups => _usingGroups;

		public ReadOnlyList<Seat> Seats => _seats;

		[field: SerializeField]
		public ContextActorData ContextActorData { get; private set; }

		[field: Inject(false)]
		public CleanableObject Cleanable { get; }

		public ItemSlot[] ItemSlots { get; private set; }

		public bool IsLow => base.Furniture.Parameters.Tags.HasFlag(EFurnitureTags.LowerTable);

		public int SeatCount
		{
			get
			{
				int num = 0;
				ClearSeats();
				foreach (Seat seat in _seats)
				{
					if (seat.Furniture.Controller.IsPlaced)
					{
						num++;
					}
				}
				return num;
			}
		}

		public int UsedSeatCount
		{
			get
			{
				int num = 0;
				foreach (CustomerGroupData usingGroup in _usingGroups)
				{
					num += usingGroup.Count;
				}
				return Math.Min(num, SeatCount);
			}
		}

		public int AvailableSeatCount
		{
			get
			{
				int num = SeatCount;
				foreach (CustomerGroupData usingGroup in _usingGroups)
				{
					num -= usingGroup.Count;
				}
				return Math.Max(0, num);
			}
		}

		public static event Action<Table, Seat> SeatAdded;

		public static event Action<Table, Seat> SeatRemoved;

		public static event Action SeatCountChanged;

		private void Construct(Furniture furniture, [InjectScope(EGetScope.Children)] ItemSlot[] slots)
		{
			ItemSlots = slots;
		}

		public void AddGroup(CustomerGroupData group)
		{
			if (!_usingGroups.Contains(group))
			{
				_usingGroups.Add(group);
				Table.SeatCountChanged?.Invoke();
			}
		}

		public void RemoveGroup(CustomerGroupData group)
		{
			if (_usingGroups.Remove(group))
			{
				Table.SeatCountChanged?.Invoke();
			}
		}

		protected override void OnFurnitureBecameUnavailable()
		{
			ItemSlot[] itemSlots = ItemSlots;
			for (int i = 0; i < itemSlots.Length; i++)
			{
				itemSlots[i].ClearSlot();
			}
			base.OnFurnitureBecameUnavailable();
		}

		public void AddSeat(Seat p_seat)
		{
			RemoveSeat(p_seat);
			_seats.Add(p_seat);
			Table.SeatAdded?.Invoke(this, p_seat);
		}

		public void RemoveSeat(Seat p_seat)
		{
			_seats.Remove(p_seat);
			Table.SeatRemoved?.Invoke(this, p_seat);
		}

		private void ClearSeats()
		{
			for (int num = _seats.Count - 1; num >= 0; num--)
			{
				Seat seat = _seats[num];
				if (seat == null)
				{
					RemoveSeat(seat);
				}
			}
		}

		public bool HasAvailableSeat(Agent agent)
		{
			foreach (Seat seat in _seats)
			{
				if (seat.CanBeUsed(agent))
				{
					return true;
				}
			}
			return false;
		}

		public bool TryGetASeat(Agent agent, out Seat p_seat)
		{
			p_seat = null;
			if (_seats.Count <= 0)
			{
				return false;
			}
			List<Seat> list = _seats.ToList();
			while (list.Count > 0)
			{
				p_seat = list[UnityEngine.Random.Range(0, list.Count)];
				if (p_seat.ContextActorData.AreInteractionTargetsAvailable(EInteractionKey.RegularUsage, agent) && p_seat.CanBeUsed(agent))
				{
					return true;
				}
				list.Remove(p_seat);
			}
			p_seat = null;
			return false;
		}
	}
}
