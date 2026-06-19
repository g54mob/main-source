using System;

namespace Rewired
{
	public sealed class ControllerStatusChangedEventArgs : EventArgs
	{
		private string XXgjQGINCAlihPAAUYevoevMvccD;

		private int rHvCEJgYeXXdLoAqldGTIrjzbVDDA;

		private ControllerType QeqWdXQwSZmnlhZVzEieQLFmrtcK;

		public string name => XXgjQGINCAlihPAAUYevoevMvccD;

		public int controllerId => rHvCEJgYeXXdLoAqldGTIrjzbVDDA;

		public ControllerType controllerType => QeqWdXQwSZmnlhZVzEieQLFmrtcK;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(QeqWdXQwSZmnlhZVzEieQLFmrtcK, rHvCEJgYeXXdLoAqldGTIrjzbVDDA);
			}
		}

		public ControllerStatusChangedEventArgs(string P_0, int P_1, ControllerType P_2)
		{
			XXgjQGINCAlihPAAUYevoevMvccD = P_0;
			rHvCEJgYeXXdLoAqldGTIrjzbVDDA = P_1;
			QeqWdXQwSZmnlhZVzEieQLFmrtcK = P_2;
		}
	}
}
