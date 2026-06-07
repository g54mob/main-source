using System;

namespace Rewired
{
	public sealed class ControllerAssignmentChangedEventArgs : EventArgs
	{
		private bool rtvVnhTQYgCakhFQKHBBPREvwqN;

		private int iueDnAHVXVmEMnNCzSowjkddzOFv;

		private int ruGCBfCWNtGZeTUKxKBCHIMxrSyL;

		private ControllerType xRMUSowrwSVmfxjnqwQXevUgxsr;

		public bool state
		{
			get
			{
				return rtvVnhTQYgCakhFQKHBBPREvwqN;
			}
		}

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(xRMUSowrwSVmfxjnqwQXevUgxsr, ruGCBfCWNtGZeTUKxKBCHIMxrSyL);
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
				return ReInput.players.GetPlayer(iueDnAHVXVmEMnNCzSowjkddzOFv);
			}
		}

		internal ControllerAssignmentChangedEventArgs(int playerId, int controllerId, ControllerType controllerType, bool state)
		{
			rtvVnhTQYgCakhFQKHBBPREvwqN = state;
			iueDnAHVXVmEMnNCzSowjkddzOFv = playerId;
			ruGCBfCWNtGZeTUKxKBCHIMxrSyL = controllerId;
			xRMUSowrwSVmfxjnqwQXevUgxsr = controllerType;
		}
	}
}
