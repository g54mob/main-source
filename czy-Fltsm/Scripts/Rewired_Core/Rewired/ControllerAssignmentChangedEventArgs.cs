using System;

namespace Rewired
{
	public sealed class ControllerAssignmentChangedEventArgs : EventArgs
	{
		private bool gdcKShkmeljSNEHUUHqCOjqEBAMDA;

		private int VVmklYOUQSNPOxthNtflFaedgTnG;

		private int iReaYHICHVdgjlJoRzHBRypIOGGc;

		private ControllerType TaJPfBNBpRPoIHiVEFPkrWibEgUm;

		public bool state => gdcKShkmeljSNEHUUHqCOjqEBAMDA;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(TaJPfBNBpRPoIHiVEFPkrWibEgUm, iReaYHICHVdgjlJoRzHBRypIOGGc);
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
				return ReInput.players.GetPlayer(VVmklYOUQSNPOxthNtflFaedgTnG);
			}
		}

		internal ControllerAssignmentChangedEventArgs(int P_0, int P_1, ControllerType P_2, bool P_3)
		{
			gdcKShkmeljSNEHUUHqCOjqEBAMDA = P_3;
			VVmklYOUQSNPOxthNtflFaedgTnG = P_0;
			iReaYHICHVdgjlJoRzHBRypIOGGc = P_1;
			TaJPfBNBpRPoIHiVEFPkrWibEgUm = P_2;
		}
	}
}
