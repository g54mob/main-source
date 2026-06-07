using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	public abstract class ZoneRoomRequirement : Requirement
	{
		private readonly string _zone;

		protected readonly Room Room;

		protected ZoneRoomRequirement()
		{
		}

		public ZoneRoomRequirement(string titleKey, string zone = null, Room room = null)
		{
		}

		private void OnRoomsOrZonesChanged(object sender, EventArgs e)
		{
		}

		protected override void AttachListeners()
		{
		}

		protected override void DetachListeners()
		{
		}

		protected IEnumerable<Room> GetAffectedRooms()
		{
			return null;
		}
	}
}
