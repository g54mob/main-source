using System.Runtime.CompilerServices;

namespace CTS.Core
{
	public readonly ref struct TemporaryValueChange<T> where T : unmanaged
	{
		private readonly T _originalValue;

		private unsafe readonly T* _address;

		public unsafe TemporaryValueChange(ref T test)
		{
			_originalValue = test;
			_address = (T*)Unsafe.AsPointer(ref test);
		}

		public unsafe void Dispose()
		{
			*_address = _originalValue;
		}
	}
}
