using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Noesis
{
	[TypeConverter(typeof(GeometryConverter))]
	public class StreamGeometry : Geometry
	{
		public static DependencyProperty FillRuleProperty => null;

		public FillRule FillRule
		{
			get
			{
				return default(FillRule);
			}
			set
			{
			}
		}

		internal new static StreamGeometry CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal StreamGeometry(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(StreamGeometry obj)
		{
			return default(HandleRef);
		}

		public override string ToString()
		{
			return null;
		}

		public StreamGeometry(string data)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public StreamGeometry()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public void SetData(string data)
		{
		}

		public StreamGeometryContext Open()
		{
			return null;
		}

		public override bool IsEmpty()
		{
			return false;
		}

		private string ToStringHelper()
		{
			return null;
		}
	}
}
