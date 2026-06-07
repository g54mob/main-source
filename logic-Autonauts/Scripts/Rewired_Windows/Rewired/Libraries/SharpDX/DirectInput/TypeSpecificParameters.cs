using System;
using System.Runtime.InteropServices;

namespace Rewired.Libraries.SharpDX.DirectInput
{
	internal class TypeSpecificParameters
	{
		private int _bufferSize;

		private byte[] _buffer;

		public virtual int Size
		{
			get
			{
				return _bufferSize;
			}
		}

		protected TypeSpecificParameters()
		{
		}

		internal TypeSpecificParameters(int bufferSize, IntPtr bufferPointer)
		{
			Init(bufferSize, bufferPointer);
		}

		private unsafe void Init(int bufferSize, IntPtr bufferPointer)
		{
			_bufferSize = bufferSize;
			if (_bufferSize > 0 && bufferPointer != IntPtr.Zero)
			{
				_buffer = new byte[bufferSize];
				fixed (byte* buffer = _buffer)
				{
					QiyhMeApbloIAQYCjGAvUEQIhAz.jZaoqafpmcVnUamkQHboGxYtgDI((IntPtr)buffer, bufferPointer, _bufferSize);
				}
			}
		}

		protected virtual TypeSpecificParameters MarshalFrom(int bufferSize, IntPtr bufferPointer)
		{
			Init(bufferSize, bufferPointer);
			return this;
		}

		internal virtual void MarshalFree(IntPtr bufferPointer)
		{
			if (bufferPointer != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(bufferPointer);
			}
		}

		internal unsafe virtual IntPtr MarshalTo()
		{
			IntPtr intPtr = IntPtr.Zero;
			if (_bufferSize > 0 && _buffer != null)
			{
				intPtr = Marshal.AllocHGlobal(_bufferSize);
				fixed (byte* buffer = _buffer)
				{
					QiyhMeApbloIAQYCjGAvUEQIhAz.jZaoqafpmcVnUamkQHboGxYtgDI(intPtr, (IntPtr)buffer, _bufferSize);
				}
			}
			return intPtr;
		}

		public unsafe T As<T>() where T : TypeSpecificParameters, new()
		{
			if ((object)GetType() == typeof(T))
			{
				return (T)this;
			}
			if ((object)GetType() == typeof(TypeSpecificParameters))
			{
				fixed (IntPtr* buffer = _buffer)
				{
					T val = new T();
					return (T)val.MarshalFrom(_bufferSize, (IntPtr)buffer);
				}
			}
			return null;
		}
	}
}
