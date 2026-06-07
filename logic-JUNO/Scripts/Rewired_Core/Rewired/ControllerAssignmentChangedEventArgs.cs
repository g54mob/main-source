using System;

namespace Rewired
{
	public sealed class ControllerAssignmentChangedEventArgs : EventArgs
	{
		private bool yVcBQXaMoIDqnBuOHuazwJtFhkPpA;

		private int PgouqoSyYpKIyRJpUWxESHtkpCqP;

		private int uiXBaoCQAoGyMeDXhEnaCGhMJePUB;

		private ControllerType XkHtXnFPbyQMydJPTpJFqPhmvYVo;

		public bool state => yVcBQXaMoIDqnBuOHuazwJtFhkPpA;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(XkHtXnFPbyQMydJPTpJFqPhmvYVo, uiXBaoCQAoGyMeDXhEnaCGhMJePUB);
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
				return ReInput.players.GetPlayer(PgouqoSyYpKIyRJpUWxESHtkpCqP);
			}
		}

		internal ControllerAssignmentChangedEventArgs(int P_0, int P_1, ControllerType P_2, bool P_3)
		{
			yVcBQXaMoIDqnBuOHuazwJtFhkPpA = P_3;
			PgouqoSyYpKIyRJpUWxESHtkpCqP = P_0;
			uiXBaoCQAoGyMeDXhEnaCGhMJePUB = P_1;
			XkHtXnFPbyQMydJPTpJFqPhmvYVo = P_2;
		}
	}
}
