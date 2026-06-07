using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class KeyRack : Larder_Tile
	{
		public static HashSet<KeyRack> AllKeyRacks;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private List<RoomReservation> _reservations;

		public long AvailableKeys => 0L;

		public long TotalAmountOfKeys { get; private set; }

		public static event EventHandler<EventArgs> AllKeyRacksChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public GameItem GetAvailableKey()
		{
			return null;
		}

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		public void AddReservation(RoomReservation reservation)
		{
		}

		public void RemoveReservation(RoomReservation reservation)
		{
		}

		public void RemoveReservation(LarderTileBoundGameItem key)
		{
		}

		public bool HasReservation(RoomReservation reservation)
		{
			return false;
		}

		public override void PostBuiltInit()
		{
		}
	}
}
