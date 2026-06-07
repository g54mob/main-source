using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)2, Pack = 1, Size = 16)]
	internal struct AttributeDataValueInternal : ISettable, IDisposable
	{
		[FieldOffset(0)]
		private long m_AsInt64;

		[FieldOffset(0)]
		private double m_AsDouble;

		[FieldOffset(0)]
		private int m_AsBool;

		[FieldOffset(0)]
		private IntPtr m_AsUtf8;

		[FieldOffset(8)]
		private AttributeType m_ValueType;

		public long? AsInt64
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public double? AsDouble
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool? AsBool
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string AsUtf8
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(AttributeDataValue other)
		{
		}

		public void Set(object other)
		{
		}

		public void Dispose()
		{
		}
	}
}
