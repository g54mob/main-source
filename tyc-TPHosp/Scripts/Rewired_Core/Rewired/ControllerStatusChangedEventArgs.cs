using System;

namespace Rewired
{
	public sealed class ControllerStatusChangedEventArgs : EventArgs
	{
		private string YckvCvRVVkCnFoBTmVxvWZVKnMr;

		private int hVLcwKGZNRwDcwqMxzBMRgucbhPa;

		private ControllerType beJOxBqDtyzXnNjzgKyRzARzFSQ;

		public string name => YckvCvRVVkCnFoBTmVxvWZVKnMr;

		public int controllerId => hVLcwKGZNRwDcwqMxzBMRgucbhPa;

		public ControllerType controllerType => beJOxBqDtyzXnNjzgKyRzARzFSQ;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(beJOxBqDtyzXnNjzgKyRzARzFSQ, hVLcwKGZNRwDcwqMxzBMRgucbhPa);
			}
		}

		public ControllerStatusChangedEventArgs(string name, int uniqueId, ControllerType controllerType)
		{
			YckvCvRVVkCnFoBTmVxvWZVKnMr = name;
			hVLcwKGZNRwDcwqMxzBMRgucbhPa = uniqueId;
			beJOxBqDtyzXnNjzgKyRzARzFSQ = controllerType;
		}
	}
}
