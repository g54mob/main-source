using System;

namespace Rewired
{
	public sealed class ControllerAssignmentChangedEventArgs : EventArgs
	{
		private bool JtKJRkqIhLnpoEZgBhBGUCTMzVS;

		private int EpFfrTuakcvBKacoggaztTmGfrG;

		private int HOfXKstauKwTqpMsyTWXViZIbgl;

		private ControllerType VkxeQjDVSfumjFSZdzmQHhgPgAwE;

		public bool state => JtKJRkqIhLnpoEZgBhBGUCTMzVS;

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

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(EpFfrTuakcvBKacoggaztTmGfrG);
			}
		}

		internal ControllerAssignmentChangedEventArgs(int playerId, int controllerId, ControllerType controllerType, bool state)
		{
			JtKJRkqIhLnpoEZgBhBGUCTMzVS = state;
			EpFfrTuakcvBKacoggaztTmGfrG = playerId;
			HOfXKstauKwTqpMsyTWXViZIbgl = controllerId;
			VkxeQjDVSfumjFSZdzmQHhgPgAwE = controllerType;
		}
	}
}
