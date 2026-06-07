using System;

namespace Rewired
{
	public sealed class ControllerStatusChangedEventArgs : EventArgs
	{
		private string XXuYUuZFvXwuYxiNryIOxzHdIWPU;

		private int iaZAeHIptgfYnzhUoKmpmEkRtvpO;

		private ControllerType ueTsfWyPNTdEyAOjfZNcYrBGNSmq;

		public string name => XXuYUuZFvXwuYxiNryIOxzHdIWPU;

		public int controllerId => iaZAeHIptgfYnzhUoKmpmEkRtvpO;

		public ControllerType controllerType => ueTsfWyPNTdEyAOjfZNcYrBGNSmq;

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

		public ControllerStatusChangedEventArgs(string P_0, int P_1, ControllerType P_2)
		{
			XXuYUuZFvXwuYxiNryIOxzHdIWPU = P_0;
			iaZAeHIptgfYnzhUoKmpmEkRtvpO = P_1;
			ueTsfWyPNTdEyAOjfZNcYrBGNSmq = P_2;
		}
	}
}
