using System;

namespace Rewired
{
	public sealed class ControllerStatusChangedEventArgs : EventArgs
	{
		private string EqppaAHmTQvmVSSZadzlNpPBbHM;

		private int ruGCBfCWNtGZeTUKxKBCHIMxrSyL;

		private ControllerType xRMUSowrwSVmfxjnqwQXevUgxsr;

		public string name
		{
			get
			{
				return EqppaAHmTQvmVSSZadzlNpPBbHM;
			}
		}

		public int controllerId
		{
			get
			{
				return ruGCBfCWNtGZeTUKxKBCHIMxrSyL;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return xRMUSowrwSVmfxjnqwQXevUgxsr;
			}
		}

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(xRMUSowrwSVmfxjnqwQXevUgxsr, ruGCBfCWNtGZeTUKxKBCHIMxrSyL);
			}
		}

		public ControllerStatusChangedEventArgs(string name, int uniqueId, ControllerType controllerType)
		{
			EqppaAHmTQvmVSSZadzlNpPBbHM = name;
			ruGCBfCWNtGZeTUKxKBCHIMxrSyL = uniqueId;
			xRMUSowrwSVmfxjnqwQXevUgxsr = controllerType;
		}
	}
}
