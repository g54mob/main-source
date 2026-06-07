using System;

namespace R3
{
	internal sealed class CombinedDisposable2 : IDisposable
	{
		public CombinedDisposable2(IDisposable disposable1, IDisposable disposable2)
		{
			_003Cdisposable1_003EP = disposable1;
			_003Cdisposable2_003EP = disposable2;
			base._002Ector();
		}

		public void Dispose()
		{
			_003Cdisposable1_003EP.Dispose();
			_003Cdisposable2_003EP.Dispose();
		}
	}
}
