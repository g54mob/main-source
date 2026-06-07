using System;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public static class TaxManager
	{
		private static bool _suspendTaxes;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void GameHooks_TavernTransactionLogged(object sender, EventArgs<TavernLog.TransactionLogEntry> e)
		{
		}

		public static IDisposable SuspendTaxes()
		{
			return null;
		}

		public static int GetTaxRate(string category)
		{
			return 0;
		}
	}
}
