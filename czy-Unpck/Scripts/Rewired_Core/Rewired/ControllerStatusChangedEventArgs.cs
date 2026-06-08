using System;

namespace Rewired
{
	public sealed class ControllerStatusChangedEventArgs : EventArgs
	{
		private string SQlNTEPvaCuPzRHxRVAmonHCzna;

		private int vnEdenUwZllTYBycKwkNdiMcIIS;

		private ControllerType fkEwyowpQQKzBaGTBxLUNmLjHtN;

		public string name => SQlNTEPvaCuPzRHxRVAmonHCzna;

		public int controllerId => vnEdenUwZllTYBycKwkNdiMcIIS;

		public ControllerType controllerType => fkEwyowpQQKzBaGTBxLUNmLjHtN;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(fkEwyowpQQKzBaGTBxLUNmLjHtN, vnEdenUwZllTYBycKwkNdiMcIIS);
			}
		}

		public ControllerStatusChangedEventArgs(string name, int uniqueId, ControllerType controllerType)
		{
			while (true)
			{
				int num = 519580074;
				while (true)
				{
					switch (num ^ 0x1EF829AB)
					{
					case 0:
						break;
					case 1:
						goto IL_0024;
					default:
						fkEwyowpQQKzBaGTBxLUNmLjHtN = controllerType;
						return;
					}
					break;
					IL_0024:
					SQlNTEPvaCuPzRHxRVAmonHCzna = name;
					vnEdenUwZllTYBycKwkNdiMcIIS = uniqueId;
					num = 519580073;
				}
			}
		}
	}
}
