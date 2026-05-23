using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct Locker : IDisposable
	{
		private object nCWCOIOOofbnfixPcuUIeRfVqGi;

		public Locker(object target)
		{
			nCWCOIOOofbnfixPcuUIeRfVqGi = target;
			if (target != null)
			{
				Monitor.Enter(target);
			}
		}

		public void Dispose()
		{
			if (nCWCOIOOofbnfixPcuUIeRfVqGi == null)
			{
				while (true)
				{
					switch (-838442370 ^ -838442369)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			Monitor.Exit(nCWCOIOOofbnfixPcuUIeRfVqGi);
			nCWCOIOOofbnfixPcuUIeRfVqGi = null;
		}
	}
}
