using System;

namespace Rewired
{
	public sealed class ControllerStatusChangedEventArgs : EventArgs
	{
		private string yUjAEzeGiOBuZJtzfIfbzqBNnorm;

		private int WpXEbkoKRBKouecPKUzLZfImIWUn;

		private ControllerType fqAlEwgMxFGaAryoQsZmZFeliinu;

		public string name => yUjAEzeGiOBuZJtzfIfbzqBNnorm;

		public int controllerId => WpXEbkoKRBKouecPKUzLZfImIWUn;

		public ControllerType controllerType => fqAlEwgMxFGaAryoQsZmZFeliinu;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(fqAlEwgMxFGaAryoQsZmZFeliinu, WpXEbkoKRBKouecPKUzLZfImIWUn);
			}
		}

		public ControllerStatusChangedEventArgs(string P_0, int P_1, ControllerType P_2)
		{
			yUjAEzeGiOBuZJtzfIfbzqBNnorm = P_0;
			WpXEbkoKRBKouecPKUzLZfImIWUn = P_1;
			fqAlEwgMxFGaAryoQsZmZFeliinu = P_2;
		}
	}
}
