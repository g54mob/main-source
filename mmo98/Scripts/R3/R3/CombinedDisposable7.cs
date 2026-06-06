using System;

namespace R3
{
	internal sealed class CombinedDisposable7 : IDisposable
	{
		public CombinedDisposable7(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4, IDisposable disposable5, IDisposable disposable6, IDisposable disposable7)
		{
			_003Cdisposable1_003EP = disposable1;
			_003Cdisposable2_003EP = disposable2;
			_003Cdisposable3_003EP = disposable3;
			_003Cdisposable4_003EP = disposable4;
			_003Cdisposable5_003EP = disposable5;
			_003Cdisposable6_003EP = disposable6;
			_003Cdisposable7_003EP = disposable7;
			base._002Ector();
		}

		public void Dispose()
		{
			_003Cdisposable1_003EP.Dispose();
			_003Cdisposable2_003EP.Dispose();
			_003Cdisposable3_003EP.Dispose();
			_003Cdisposable4_003EP.Dispose();
			_003Cdisposable5_003EP.Dispose();
			_003Cdisposable6_003EP.Dispose();
			_003Cdisposable7_003EP.Dispose();
		}
	}
}
