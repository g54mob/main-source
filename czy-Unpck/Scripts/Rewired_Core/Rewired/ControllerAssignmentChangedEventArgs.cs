using System;

namespace Rewired
{
	public sealed class ControllerAssignmentChangedEventArgs : EventArgs
	{
		private bool lUdstvFpjmjeYgkuzHaSijamfet;

		private int cNcLkMBaCDcdcMeoQVAxVFVuHEv;

		private int vnEdenUwZllTYBycKwkNdiMcIIS;

		private ControllerType fkEwyowpQQKzBaGTBxLUNmLjHtN;

		public bool state => lUdstvFpjmjeYgkuzHaSijamfet;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(fkEwyowpQQKzBaGTBxLUNmLjHtN, vnEdenUwZllTYBycKwkNdiMcIIS);
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
				return ReInput.players.GetPlayer(cNcLkMBaCDcdcMeoQVAxVFVuHEv);
			}
		}

		internal ControllerAssignmentChangedEventArgs(int playerId, int controllerId, ControllerType controllerType, bool state)
		{
			lUdstvFpjmjeYgkuzHaSijamfet = state;
			cNcLkMBaCDcdcMeoQVAxVFVuHEv = playerId;
			vnEdenUwZllTYBycKwkNdiMcIIS = controllerId;
			fkEwyowpQQKzBaGTBxLUNmLjHtN = controllerType;
		}
	}
}
