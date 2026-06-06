using System;

namespace R3
{
	internal sealed class CombinedDisposable : IDisposable
	{
		public CombinedDisposable(IDisposable[] disposables)
		{
			_003Cdisposables_003EP = disposables;
			base._002Ector();
		}

		public void Dispose()
		{
			IDisposable[] array = _003Cdisposables_003EP;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Dispose();
			}
		}
	}
}
