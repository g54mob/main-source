using System;

namespace Rewired
{
	public sealed class ControllerStatusChangedEventArgs : EventArgs
	{
		private string jMnuxDpeLQhKgkpKQOlnqChJgyRd;

		private int WuIXWewTRtkXNcGHNDHMpyChWRj;

		private ControllerType CiEHnIGrjScHYHuMEoDVXvEgwiy;

		public string name
		{
			get
			{
				return jMnuxDpeLQhKgkpKQOlnqChJgyRd;
			}
		}

		public int controllerId
		{
			get
			{
				return WuIXWewTRtkXNcGHNDHMpyChWRj;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return CiEHnIGrjScHYHuMEoDVXvEgwiy;
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
				return ReInput.controllers.GetController(CiEHnIGrjScHYHuMEoDVXvEgwiy, WuIXWewTRtkXNcGHNDHMpyChWRj);
			}
		}

		public ControllerStatusChangedEventArgs(string name, int uniqueId, ControllerType controllerType)
		{
			jMnuxDpeLQhKgkpKQOlnqChJgyRd = name;
			WuIXWewTRtkXNcGHNDHMpyChWRj = uniqueId;
			CiEHnIGrjScHYHuMEoDVXvEgwiy = controllerType;
		}
	}
}
