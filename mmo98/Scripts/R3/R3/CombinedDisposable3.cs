using System;

namespace R3
{
	internal sealed class CombinedDisposable3 : IDisposable
	{
		public CombinedDisposable3(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3)
		{
			_003Cdisposable1_003EP = disposable1;
			_003Cdisposable2_003EP = disposable2;
			_003Cdisposable3_003EP = disposable3;
			base._002Ector();
		}

		public void Dispose()
		{
			_003Cdisposable1_003EP.Dispose();
			_003Cdisposable2_003EP.Dispose();
			_003Cdisposable3_003EP.Dispose();
		}
	}
}
