using System;
using UnityEngine;

namespace Gh.Tk
{
	public class RezoneButtonContextMenuItem : SelectionButtonContextMenuItem
	{
		private Room _room;

		private RoomZone _zone;

		public RezoneButtonContextMenuItem(Room room, RoomZone zone, Action execute, Func<bool> canExecute = null, Func<bool> isSelected = null, Func<bool> isVisible = null, TooltipData tooltipData = null)
			: base(null, null, null, null, null, null, null)
		{
		}

		public override GameObject CreateGameObject(Transform where)
		{
			return null;
		}
	}
}
