using System;

namespace Rewired
{
	public sealed class ControllerStatusChangedEventArgs : EventArgs
	{
		private string VwNBtZgCtCEfYCkwZIXWYrcvBmuRA;

		private int zdzMAUeEMLydnZjSqcHadVlOZWHfA;

		private ControllerType CactfQuIsHwvJYoxoFjNZENTLmeO;

		public string name => VwNBtZgCtCEfYCkwZIXWYrcvBmuRA;

		public int controllerId => zdzMAUeEMLydnZjSqcHadVlOZWHfA;

		public ControllerType controllerType => CactfQuIsHwvJYoxoFjNZENTLmeO;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(CactfQuIsHwvJYoxoFjNZENTLmeO, zdzMAUeEMLydnZjSqcHadVlOZWHfA);
			}
		}

		public ControllerStatusChangedEventArgs(string P_0, int P_1, ControllerType P_2)
		{
			VwNBtZgCtCEfYCkwZIXWYrcvBmuRA = P_0;
			zdzMAUeEMLydnZjSqcHadVlOZWHfA = P_1;
			CactfQuIsHwvJYoxoFjNZENTLmeO = P_2;
		}
	}
}
