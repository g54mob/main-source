using System;

namespace Rewired
{
	public sealed class ControllerStatusChangedEventArgs : EventArgs
	{
		private string gbaFwplwRPDIuUufIuWmknaoIHDK;

		private int JJTApEccBgIfJOWwHYEPwbJOOnbjA;

		private ControllerType FHHqpHICfRrjYzaZOfxGJuaReWmv;

		public string name => gbaFwplwRPDIuUufIuWmknaoIHDK;

		public int controllerId => JJTApEccBgIfJOWwHYEPwbJOOnbjA;

		public ControllerType controllerType => FHHqpHICfRrjYzaZOfxGJuaReWmv;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(FHHqpHICfRrjYzaZOfxGJuaReWmv, JJTApEccBgIfJOWwHYEPwbJOOnbjA);
			}
		}

		public ControllerStatusChangedEventArgs(string P_0, int P_1, ControllerType P_2)
		{
			gbaFwplwRPDIuUufIuWmknaoIHDK = P_0;
			JJTApEccBgIfJOWwHYEPwbJOOnbjA = P_1;
			FHHqpHICfRrjYzaZOfxGJuaReWmv = P_2;
		}
	}
}
