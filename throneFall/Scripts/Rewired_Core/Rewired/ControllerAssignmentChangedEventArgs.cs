using System;

namespace Rewired
{
	public sealed class ControllerAssignmentChangedEventArgs : EventArgs
	{
		private bool VqAHtHcKlvgoUbdHqZKhtCDqgAHWA;

		private int oTOJBeKGTQUePOMwlVVGJaNPsmui;

		private int VWhNuWQLVVaxgQEgjFefLZasGCRC;

		private ControllerType wPnaIdLAoFMnRcbQonUNrLDZmSDh;

		public bool state => VqAHtHcKlvgoUbdHqZKhtCDqgAHWA;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(wPnaIdLAoFMnRcbQonUNrLDZmSDh, VWhNuWQLVVaxgQEgjFefLZasGCRC);
			}
		}

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(oTOJBeKGTQUePOMwlVVGJaNPsmui);
			}
		}

		internal ControllerAssignmentChangedEventArgs(int P_0, int P_1, ControllerType P_2, bool P_3)
		{
			VqAHtHcKlvgoUbdHqZKhtCDqgAHWA = P_3;
			oTOJBeKGTQUePOMwlVVGJaNPsmui = P_0;
			VWhNuWQLVVaxgQEgjFefLZasGCRC = P_1;
			wPnaIdLAoFMnRcbQonUNrLDZmSDh = P_2;
		}
	}
}
