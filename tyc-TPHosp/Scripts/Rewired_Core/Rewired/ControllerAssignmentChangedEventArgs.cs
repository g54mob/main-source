using System;

namespace Rewired
{
	public sealed class ControllerAssignmentChangedEventArgs : EventArgs
	{
		private bool vzyzyWJzMILGaVcOKuNZMHomdFs;

		private int ivfdKpZALpQIAdtIdHmkpPFkwfq;

		private int hVLcwKGZNRwDcwqMxzBMRgucbhPa;

		private ControllerType beJOxBqDtyzXnNjzgKyRzARzFSQ;

		public bool state => vzyzyWJzMILGaVcOKuNZMHomdFs;

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

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(ivfdKpZALpQIAdtIdHmkpPFkwfq);
			}
		}

		internal ControllerAssignmentChangedEventArgs(int playerId, int controllerId, ControllerType controllerType, bool state)
		{
			vzyzyWJzMILGaVcOKuNZMHomdFs = state;
			ivfdKpZALpQIAdtIdHmkpPFkwfq = playerId;
			hVLcwKGZNRwDcwqMxzBMRgucbhPa = controllerId;
			beJOxBqDtyzXnNjzgKyRzARzFSQ = controllerType;
		}
	}
}
