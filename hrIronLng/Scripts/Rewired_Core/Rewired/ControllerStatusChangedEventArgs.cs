using System;

namespace Rewired
{
	public sealed class ControllerStatusChangedEventArgs : EventArgs
	{
		private string qpIGvFaemznETzYbpRdmOKmaPCL;

		private int HOfXKstauKwTqpMsyTWXViZIbgl;

		private ControllerType VkxeQjDVSfumjFSZdzmQHhgPgAwE;

		public string name => qpIGvFaemznETzYbpRdmOKmaPCL;

		public int controllerId => HOfXKstauKwTqpMsyTWXViZIbgl;

		public ControllerType controllerType => VkxeQjDVSfumjFSZdzmQHhgPgAwE;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(VkxeQjDVSfumjFSZdzmQHhgPgAwE, HOfXKstauKwTqpMsyTWXViZIbgl);
			}
		}

		public ControllerStatusChangedEventArgs(string name, int uniqueId, ControllerType controllerType)
		{
			qpIGvFaemznETzYbpRdmOKmaPCL = name;
			HOfXKstauKwTqpMsyTWXViZIbgl = uniqueId;
			VkxeQjDVSfumjFSZdzmQHhgPgAwE = controllerType;
		}
	}
}
