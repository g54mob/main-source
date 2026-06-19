using System;
using UnityEngine;

namespace Cheats
{
	public static class TesterMode
	{
		public const string UnlockCode = "Wannabetester";

		private static bool _isTester;

		public static bool IsTester => _isTester;

		public static event Action OnEnabled;

		public static void Enable()
		{
			if (!_isTester)
			{
				_isTester = true;
				Debug.Log("[Cheats] Tester mode enabled.");
				TesterMode.OnEnabled?.Invoke();
			}
		}
	}
}
