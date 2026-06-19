using System;

namespace Rewired
{
	public sealed class ControllerAssignmentChangedEventArgs : EventArgs
	{
		private bool wIqaKyBCGvJdlgpgHDzbDRsBjPWKc;

		private int RuaqCPeemKGPaMkXKMgOOSyCAndM;

		private int aWDCwDmmoHRtEUClMNmyOJgzIBWz;

		private ControllerType TXDDvUpLRJXCgwzzTInRsvkSjUCj;

		public bool state => wIqaKyBCGvJdlgpgHDzbDRsBjPWKc;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(TXDDvUpLRJXCgwzzTInRsvkSjUCj, aWDCwDmmoHRtEUClMNmyOJgzIBWz);
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
				return ReInput.players.GetPlayer(RuaqCPeemKGPaMkXKMgOOSyCAndM);
			}
		}

		internal ControllerAssignmentChangedEventArgs(int P_0, int P_1, ControllerType P_2, bool P_3)
		{
			wIqaKyBCGvJdlgpgHDzbDRsBjPWKc = P_3;
			RuaqCPeemKGPaMkXKMgOOSyCAndM = P_0;
			aWDCwDmmoHRtEUClMNmyOJgzIBWz = P_1;
			TXDDvUpLRJXCgwzzTInRsvkSjUCj = P_2;
		}
	}
}
