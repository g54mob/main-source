using System;

namespace Rewired
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class ControllerDisconnectedEventArgs : EventArgs
	{
		public readonly int rewiredId;

		public ControllerDisconnectedEventArgs(int rewiredId)
		{
		}
	}
}
