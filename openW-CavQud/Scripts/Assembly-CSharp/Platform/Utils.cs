using System;

namespace Platform
{
	public static class Utils
	{
		public struct OnScopeExit : IDisposable
		{
			public Action Cleanup;

			public OnScopeExit(Action cleanup)
			{
				Cleanup = cleanup;
			}

			public void Dispose()
			{
				Cleanup?.Invoke();
			}
		}

		public static bool IsStrictIO()
		{
			return true;
		}

		public static bool OnlyAOT()
		{
			return false;
		}

		public static bool ShouldOnlyBeCalledOnStandalone(string msg)
		{
			return false;
		}
	}
}
