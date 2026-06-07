using System;

namespace Rewired
{
	public sealed class ControllerAssignmentChangedEventArgs : EventArgs
	{
		private bool uaoVgNNqepBZbGcKZkwihPkVPFYX;

		private int lZxGiiRCjWjNVgZWofZDCyZVhNIF;

		private int iaZAeHIptgfYnzhUoKmpmEkRtvpO;

		private ControllerType ueTsfWyPNTdEyAOjfZNcYrBGNSmq;

		public bool state => uaoVgNNqepBZbGcKZkwihPkVPFYX;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(ueTsfWyPNTdEyAOjfZNcYrBGNSmq, iaZAeHIptgfYnzhUoKmpmEkRtvpO);
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
				return ReInput.players.GetPlayer(lZxGiiRCjWjNVgZWofZDCyZVhNIF);
			}
		}

		internal ControllerAssignmentChangedEventArgs(int P_0, int P_1, ControllerType P_2, bool P_3)
		{
			uaoVgNNqepBZbGcKZkwihPkVPFYX = P_3;
			lZxGiiRCjWjNVgZWofZDCyZVhNIF = P_0;
			iaZAeHIptgfYnzhUoKmpmEkRtvpO = P_1;
			ueTsfWyPNTdEyAOjfZNcYrBGNSmq = P_2;
		}
	}
}
