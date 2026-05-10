using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Utilities;

namespace CTS
{
	public static class BBTObjectExtensions
	{
		public static readonly Func<IBBTObject, Worker, bool> IsInAssignation = (IBBTObject obj, Worker worker) => worker.RoomAssignations.HasRoom(obj.RoomObject.CurrentRoom);

		public static bool IsInWorkerAssignation(this IBBTObject obj, Worker worker)
		{
			return worker.RoomAssignations.CanUseRoom(obj.RoomObject.CurrentRoom);
		}

		public static bool IsInAnyMorgueAssignation(this IBBTObject obj)
		{
			if (obj.RoomObject.CurrentRoom.RoomIndex == 0)
			{
				return false;
			}
			Span<StationMorgue> allAssignedMorgues = GetAllAssignedMorgues(obj);
			for (int i = 0; i < allAssignedMorgues.Length; i++)
			{
				StationMorgue morgue = allAssignedMorgues[i];
				if (obj.IsInMorgueAssignation(morgue))
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsInMorgueAssignation(this IBBTObject obj, StationMorgue morgue)
		{
			if (morgue.RoomAssignations.AssignedRooms.Count <= 0)
			{
				return true;
			}
			if ((object)obj.RoomObject.CurrentRoom == morgue.RoomObject.CurrentRoom)
			{
				return true;
			}
			if (obj.RoomObject.CurrentRoom.RoomIndex == 0)
			{
				return false;
			}
			return morgue.RoomAssignations.HasRoom(obj.RoomObject.CurrentRoom);
		}

		public static bool IsInSameMorgueAssignation(this IBBTObject obj1, IBBTObject obj2)
		{
			if (!obj1.IsInAnyMorgueAssignation() && !obj2.IsInAnyMorgueAssignation())
			{
				return true;
			}
			foreach (StationMorgue item in CTSSingleton<BarFurnitures>.Instance.Enumerate<StationMorgue>())
			{
				if (obj1.IsInMorgueAssignation(item) && obj2.IsInMorgueAssignation(item))
				{
					return true;
				}
			}
			return false;
		}

		public static bool CanBodyBeDiscarded(this StationMorgue morgue, DeadBodyData deadBodyData)
		{
			if (!morgue.DeadBodies.Contains(deadBodyData))
			{
				return false;
			}
			if (!morgue.CanBeUsed())
			{
				return false;
			}
			foreach (IBodyDisposalMachine item in CTSSingleton<BarFurnitures>.Instance.Enumerate<IBodyDisposalMachine>())
			{
				if (CanMachineBeUsedToDiscardBody(item, morgue, deadBodyData))
				{
					return true;
				}
			}
			return false;
		}

		public static bool CanBodyBeDiscardedByWorker(this StationMorgue morgue, DeadBodyData deadBodyData, Worker worker)
		{
			if (!morgue.DeadBodies.Contains(deadBodyData))
			{
				return false;
			}
			if (!morgue.CanBeUsed())
			{
				return false;
			}
			foreach (IBodyDisposalMachine item in CTSSingleton<BarFurnitures>.Instance.Enumerate<IBodyDisposalMachine>())
			{
				if (worker.RoomAssignations.CanUseRoom(item.RoomObject.CurrentRoom) && CanMachineBeUsedToDiscardBody(item, morgue, deadBodyData))
				{
					return true;
				}
			}
			return false;
		}

		private static bool CanMachineBeUsedToDiscardBody(IBodyDisposalMachine machine, StationMorgue morgue, DeadBodyData deadBodyData)
		{
			if (!machine.CanBeUsed())
			{
				return false;
			}
			if (!machine.CanBeUsedToDisposeBody(deadBodyData))
			{
				return false;
			}
			if (!machine.IsInMorgueAssignation(morgue))
			{
				return false;
			}
			if (deadBodyData.Credibility > machine.MachineCredibility.Credibility)
			{
				return false;
			}
			return true;
		}

		private static Span<StationMorgue> GetAllAssignedMorgues(IBBTObject obj)
		{
			TemporaryCollection.TemporaryList<StationMorgue> temporaryList = TemporaryCollection.GetTemporaryList<StationMorgue>();
			try
			{
				foreach (StationMorgue item in CTSSingleton<BarFurnitures>.Instance.Enumerate<StationMorgue>())
				{
					if (obj.IsInMorgueAssignation(item))
					{
						temporaryList.List.Add(item);
					}
				}
				return temporaryList.List.ToSpan();
			}
			finally
			{
				temporaryList.Dispose();
			}
		}

		private static bool IsAnyMorgueAvailableForBody(IBBTObject obj)
		{
			Span<StationMorgue> allAssignedMorgues = GetAllAssignedMorgues(obj);
			if (allAssignedMorgues.Length > 0)
			{
				Span<StationMorgue> span = allAssignedMorgues;
				for (int i = 0; i < span.Length; i++)
				{
					if (IsMorgueAvailableForBody(span[i]))
					{
						return true;
					}
				}
			}
			else
			{
				foreach (StationMorgue item in CTSSingleton<BarFurnitures>.Instance.Enumerate<StationMorgue>())
				{
					if (IsMorgueAvailableForBody(item))
					{
						return true;
					}
				}
			}
			return false;
		}

		private static bool IsAnyMorgueAvailableForBodyWithWorker(IBBTObject obj, Worker worker)
		{
			Span<StationMorgue> allAssignedMorgues = GetAllAssignedMorgues(obj);
			if (allAssignedMorgues.Length > 0)
			{
				Span<StationMorgue> span = allAssignedMorgues;
				for (int i = 0; i < span.Length; i++)
				{
					StationMorgue stationMorgue = span[i];
					if (stationMorgue.IsInWorkerAssignation(worker) && IsMorgueAvailableForBody(stationMorgue))
					{
						return true;
					}
				}
			}
			else
			{
				foreach (StationMorgue item in CTSSingleton<BarFurnitures>.Instance.Enumerate<StationMorgue>())
				{
					if (item.IsInWorkerAssignation(worker) && IsMorgueAvailableForBody(item))
					{
						return true;
					}
				}
			}
			return false;
		}

		private static bool IsMorgueAvailableForBody(StationMorgue morgue)
		{
			if (!morgue.CanBeUsed())
			{
				return false;
			}
			return !morgue.IsFull;
		}

		public static bool CanBeDiscardedInMorgue(this Customer customer)
		{
			return IsAnyMorgueAvailableForBody(customer);
		}

		public static bool CanBeDiscardedInMorgue(this BodyBag bodyBag)
		{
			return IsAnyMorgueAvailableForBody(bodyBag);
		}

		public static bool CanBeDiscardedInMorgueByWorker(this Customer customer, Worker worker)
		{
			return IsAnyMorgueAvailableForBodyWithWorker(customer, worker);
		}

		public static bool CanBeDiscardedInMorgueByWorker(this BodyBag bodyBag, Worker worker)
		{
			return IsAnyMorgueAvailableForBodyWithWorker(bodyBag, worker);
		}

		private static bool CanBodyBeDiscardedInMachine(IBBTObject obj, DeadBodyData deadBodyData)
		{
			foreach (IBodyDisposalMachine item in CTSSingleton<BarFurnitures>.Instance.Enumerate<IBodyDisposalMachine>())
			{
				if (CanMachineBeUsedToDiscardBody(item, obj, deadBodyData))
				{
					return true;
				}
			}
			return false;
		}

		private static bool CanBodyBeDiscardInMachineByWorker(IBBTObject obj, DeadBodyData deadBodyData, Worker worker)
		{
			foreach (IBodyDisposalMachine item in CTSSingleton<BarFurnitures>.Instance.Enumerate<IBodyDisposalMachine>())
			{
				if (worker.RoomAssignations.CanUseRoom(item.RoomObject.CurrentRoom) && CanMachineBeUsedToDiscardBody(item, obj, deadBodyData))
				{
					return true;
				}
			}
			return false;
		}

		private static bool CanMachineBeUsedToDiscardBody(IBodyDisposalMachine machine, IBBTObject obj, DeadBodyData deadBodyData)
		{
			if (!machine.CanBeUsed())
			{
				return false;
			}
			if (!machine.CanBeUsedToDisposeBody(deadBodyData))
			{
				return false;
			}
			if (deadBodyData.Credibility > machine.MachineCredibility.Credibility)
			{
				return false;
			}
			if (!obj.IsInSameMorgueAssignation(machine))
			{
				return false;
			}
			return true;
		}

		public static bool CanBeDiscardedInMachine(this Customer customer)
		{
			return CanBodyBeDiscardedInMachine(customer, new DeadBodyData(customer));
		}

		public static bool CanBeDiscardedInMachine(this BodyBag bodyBag)
		{
			return CanBodyBeDiscardedInMachine(bodyBag, bodyBag.BodyData);
		}

		public static bool CanBeDiscardedInMachineByWorker(this Customer customer, Worker worker)
		{
			return CanBodyBeDiscardInMachineByWorker(customer, new DeadBodyData(customer), worker);
		}

		public static bool CanBeDiscardedInMachineByWorker(this BodyBag bodyBag, Worker worker)
		{
			return CanBodyBeDiscardInMachineByWorker(bodyBag, bodyBag.BodyData, worker);
		}

		public static StationMorgue GetNearestAvailableMorgue(this IBBTObject obj)
		{
			TemporaryCollection.TemporaryList<StationMorgue> temporaryList = TemporaryCollection.GetTemporaryList<StationMorgue>();
			try
			{
				List<StationMorgue> list = temporaryList.List;
				Span<StationMorgue> allAssignedMorgues = GetAllAssignedMorgues(obj);
				if (allAssignedMorgues.Length > 0)
				{
					Span<StationMorgue> span = allAssignedMorgues;
					for (int i = 0; i < span.Length; i++)
					{
						StationMorgue stationMorgue = span[i];
						if (stationMorgue.CanBeUsed() && !stationMorgue.IsFull)
						{
							list.Add(stationMorgue);
						}
					}
				}
				else
				{
					foreach (StationMorgue item in CTSSingleton<BarFurnitures>.Instance.Enumerate<StationMorgue>())
					{
						if (item.CanBeUsed() && !item.IsFull)
						{
							list.Add(item);
						}
					}
				}
				float outBestDistance;
				return BBTCollections<StationMorgue>.GetNearest(obj.RoomObject, list, out outBestDistance);
			}
			finally
			{
				temporaryList.Dispose();
			}
		}

		public static IBodyDisposalMachine GetNearestBodyDisposalMachineInMorgueAssignation(this BodyBag bodyBag)
		{
			TemporaryCollection.TemporaryList<IBodyDisposalMachine> temporaryList = TemporaryCollection.GetTemporaryList<IBodyDisposalMachine>();
			try
			{
				List<IBodyDisposalMachine> list = temporaryList.List;
				foreach (IBodyDisposalMachine item in CTSSingleton<BarFurnitures>.Instance.Enumerate<IBodyDisposalMachine>())
				{
					if (item.CanBeUsed() && item.CanBeUsedToDisposeBody(bodyBag.BodyData) && bodyBag.IsInSameMorgueAssignation(item) && bodyBag.BodyData.Credibility <= item.MachineCredibility.Credibility)
					{
						list.Add(item);
					}
				}
				float outBestDistance;
				return BBTCollections<IBodyDisposalMachine>.GetNearest(bodyBag.RoomObject, list, out outBestDistance);
			}
			finally
			{
				temporaryList.Dispose();
			}
		}

		private static Span<T> ToSpan<T>(this List<T> list)
		{
			T[] array = ArrayCache<T>.Get(list.Count);
			for (int i = 0; i < list.Count; i++)
			{
				array[i] = list[i];
			}
			return new Span<T>(array, 0, list.Count);
		}
	}
}
