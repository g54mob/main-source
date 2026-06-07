using System;

namespace Gh.Tk
{
	public abstract class PropZoneRoomRequirement : ZoneRoomRequirement
	{
		protected PropZoneRoomRequirement()
		{
		}

		public PropZoneRoomRequirement(string titleKey, string zone = null, Room room = null)
		{
		}

		private void OnPropsChanged(object sender, EventArgs e)
		{
		}

		protected override void AttachListeners()
		{
		}

		private void RoomOnPropsChanged(object sender, EventArgs<Room> e)
		{
		}

		protected override void DetachListeners()
		{
		}
	}
}
