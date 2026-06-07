using System;

namespace Rewired
{
	public sealed class ControllerAssignmentChangedEventArgs : EventArgs
	{
		private bool AQpCUgrvQaJjZZLPsqXVcYYjHjE;

		private int VUcYiZtcJRatratRXOokIFfcdNSg;

		private int WuIXWewTRtkXNcGHNDHMpyChWRj;

		private ControllerType CiEHnIGrjScHYHuMEoDVXvEgwiy;

		public bool state
		{
			get
			{
				return AQpCUgrvQaJjZZLPsqXVcYYjHjE;
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
				return ReInput.controllers.GetController(CiEHnIGrjScHYHuMEoDVXvEgwiy, WuIXWewTRtkXNcGHNDHMpyChWRj);
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
				return ReInput.players.GetPlayer(VUcYiZtcJRatratRXOokIFfcdNSg);
			}
		}

		internal ControllerAssignmentChangedEventArgs(int playerId, int controllerId, ControllerType controllerType, bool state)
		{
			AQpCUgrvQaJjZZLPsqXVcYYjHjE = state;
			VUcYiZtcJRatratRXOokIFfcdNSg = playerId;
			WuIXWewTRtkXNcGHNDHMpyChWRj = controllerId;
			CiEHnIGrjScHYHuMEoDVXvEgwiy = controllerType;
		}
	}
}
