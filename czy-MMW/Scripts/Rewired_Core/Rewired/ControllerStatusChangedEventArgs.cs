using System;

namespace Rewired
{
	public sealed class ControllerStatusChangedEventArgs : EventArgs
	{
		private string LkEycxvjcVlNpKBtoNkuSqBjycZM;

		private int rCmTRmzHDSTbMhYFRsdMoeOQJKqM;

		private ControllerType QxnoyabpmGRuXmifRQvPaqaFkPoB;

		public string name => LkEycxvjcVlNpKBtoNkuSqBjycZM;

		public int controllerId => rCmTRmzHDSTbMhYFRsdMoeOQJKqM;

		public ControllerType controllerType => QxnoyabpmGRuXmifRQvPaqaFkPoB;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(QxnoyabpmGRuXmifRQvPaqaFkPoB, rCmTRmzHDSTbMhYFRsdMoeOQJKqM);
			}
		}

		public ControllerStatusChangedEventArgs(string P_0, int P_1, ControllerType P_2)
		{
			LkEycxvjcVlNpKBtoNkuSqBjycZM = P_0;
			rCmTRmzHDSTbMhYFRsdMoeOQJKqM = P_1;
			QxnoyabpmGRuXmifRQvPaqaFkPoB = P_2;
		}
	}
}
