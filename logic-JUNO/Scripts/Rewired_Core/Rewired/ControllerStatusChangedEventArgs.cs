using System;

namespace Rewired
{
	public sealed class ControllerStatusChangedEventArgs : EventArgs
	{
		private string TDHklrmhjjaXaScsYFJlqmloIEnT;

		private int fjjBCiouEqimNxfMznVHEwaFAmQU;

		private ControllerType YDovzaqTmyohtsnrfhGkUMKOUwbF;

		public string name => TDHklrmhjjaXaScsYFJlqmloIEnT;

		public int controllerId => fjjBCiouEqimNxfMznVHEwaFAmQU;

		public ControllerType controllerType => YDovzaqTmyohtsnrfhGkUMKOUwbF;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(YDovzaqTmyohtsnrfhGkUMKOUwbF, fjjBCiouEqimNxfMznVHEwaFAmQU);
			}
		}

		public ControllerStatusChangedEventArgs(string P_0, int P_1, ControllerType P_2)
		{
			TDHklrmhjjaXaScsYFJlqmloIEnT = P_0;
			fjjBCiouEqimNxfMznVHEwaFAmQU = P_1;
			YDovzaqTmyohtsnrfhGkUMKOUwbF = P_2;
		}
	}
}
