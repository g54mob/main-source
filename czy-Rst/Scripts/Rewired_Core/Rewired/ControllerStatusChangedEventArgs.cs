using System;

namespace Rewired
{
	public sealed class ControllerStatusChangedEventArgs : EventArgs
	{
		private string SnmmlSvMkOwVbGheiNgWMihCtUZo;

		private int mEAMxJffHPRVQdcMZiPsulmrsboI;

		private ControllerType BeVlKZdFzRdDsiPlLDERmLGyUUXL;

		public string name => SnmmlSvMkOwVbGheiNgWMihCtUZo;

		public int controllerId => mEAMxJffHPRVQdcMZiPsulmrsboI;

		public ControllerType controllerType => BeVlKZdFzRdDsiPlLDERmLGyUUXL;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(BeVlKZdFzRdDsiPlLDERmLGyUUXL, mEAMxJffHPRVQdcMZiPsulmrsboI);
			}
		}

		public ControllerStatusChangedEventArgs(string P_0, int P_1, ControllerType P_2)
		{
			SnmmlSvMkOwVbGheiNgWMihCtUZo = P_0;
			mEAMxJffHPRVQdcMZiPsulmrsboI = P_1;
			BeVlKZdFzRdDsiPlLDERmLGyUUXL = P_2;
		}
	}
}
