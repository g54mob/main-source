using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace NAudio.CoreAudioApi.Interfaces
{
	[StructLayout((LayoutKind)2)]
	public struct PropVariant
	{
		[FieldOffset(0)]
		public short vt;

		[FieldOffset(2)]
		public short wReserved1;

		[FieldOffset(4)]
		public short wReserved2;

		[FieldOffset(6)]
		public short wReserved3;

		[FieldOffset(8)]
		public sbyte cVal;

		[FieldOffset(8)]
		public byte bVal;

		[FieldOffset(8)]
		public short iVal;

		[FieldOffset(8)]
		public ushort uiVal;

		[FieldOffset(8)]
		public int lVal;

		[FieldOffset(8)]
		public uint ulVal;

		[FieldOffset(8)]
		public int intVal;

		[FieldOffset(8)]
		public uint uintVal;

		[FieldOffset(8)]
		public long hVal;

		[FieldOffset(8)]
		public long uhVal;

		[FieldOffset(8)]
		public float fltVal;

		[FieldOffset(8)]
		public double dblVal;

		[FieldOffset(8)]
		public short boolVal;

		[FieldOffset(8)]
		public int scode;

		[FieldOffset(8)]
		public FILETIME filetime;

		[FieldOffset(8)]
		public Blob blobVal;

		[FieldOffset(8)]
		public IntPtr pointerValue;

		public VarEnum DataType => default(VarEnum);

		public object Value => null;

		public static PropVariant FromLong(long value)
		{
			return default(PropVariant);
		}

		private byte[] GetBlob()
		{
			return null;
		}

		public T[] GetBlobAsArrayOf<T>()
		{
			return null;
		}

		[Obsolete("Call with pointer instead")]
		public void Clear()
		{
		}

		public static void Clear(IntPtr ptr)
		{
		}
	}
}
