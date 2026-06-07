using System;

namespace Rewired
{
	public sealed class ControllerAssignmentChangedEventArgs : EventArgs
	{
		private bool izlXsNtkzeVrwiRTnHEudWPIAQhl;

		private int PJfefmBUVHkhpPNwsUWVaITpsyIR;

		private int iLKlpiJGRQLZVJLUaCWpaVJUdOjs;

		private ControllerType PDEfOhGncCCjnajQxLeOdAJIdidOB;

		public bool state => izlXsNtkzeVrwiRTnHEudWPIAQhl;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(PDEfOhGncCCjnajQxLeOdAJIdidOB, iLKlpiJGRQLZVJLUaCWpaVJUdOjs);
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
				return ReInput.players.GetPlayer(PJfefmBUVHkhpPNwsUWVaITpsyIR);
			}
		}

		internal ControllerAssignmentChangedEventArgs(int P_0, int P_1, ControllerType P_2, bool P_3)
		{
			izlXsNtkzeVrwiRTnHEudWPIAQhl = P_3;
			PJfefmBUVHkhpPNwsUWVaITpsyIR = P_0;
			iLKlpiJGRQLZVJLUaCWpaVJUdOjs = P_1;
			PDEfOhGncCCjnajQxLeOdAJIdidOB = P_2;
		}
	}
}
