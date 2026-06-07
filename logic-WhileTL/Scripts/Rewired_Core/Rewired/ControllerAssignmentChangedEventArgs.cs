using System;

namespace Rewired
{
	public sealed class ControllerAssignmentChangedEventArgs : EventArgs
	{
		private bool FDyvDAfrWruDLxFyycUEsPLMGLCq;

		private int KjrBBzjjJWMijsVwJGfzfVcgArYWb;

		private int JJTApEccBgIfJOWwHYEPwbJOOnbjA;

		private ControllerType FHHqpHICfRrjYzaZOfxGJuaReWmv;

		public bool state => FDyvDAfrWruDLxFyycUEsPLMGLCq;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(FHHqpHICfRrjYzaZOfxGJuaReWmv, JJTApEccBgIfJOWwHYEPwbJOOnbjA);
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
				return ReInput.players.GetPlayer(KjrBBzjjJWMijsVwJGfzfVcgArYWb);
			}
		}

		internal ControllerAssignmentChangedEventArgs(int P_0, int P_1, ControllerType P_2, bool P_3)
		{
			FDyvDAfrWruDLxFyycUEsPLMGLCq = P_3;
			KjrBBzjjJWMijsVwJGfzfVcgArYWb = P_0;
			JJTApEccBgIfJOWwHYEPwbJOOnbjA = P_1;
			FHHqpHICfRrjYzaZOfxGJuaReWmv = P_2;
		}
	}
}
