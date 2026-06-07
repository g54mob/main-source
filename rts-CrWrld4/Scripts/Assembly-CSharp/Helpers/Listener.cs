using System;

namespace Helpers
{
	public static class Listener
	{
		public static void Create<T>(ref T listener) where T : new()
		{
		}

		public static void Dispose<T>(ref T listener) where T : IDisposable
		{
		}
	}
}
