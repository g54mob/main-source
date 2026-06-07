using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DashStyle : Animatable
	{
		public static DependencyProperty DashesProperty => null;

		public static DependencyProperty OffsetProperty => null;

		public string Dashes
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float Offset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static DashStyle CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DashStyle(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DashStyle obj)
		{
			return default(HandleRef);
		}

		public DashStyle()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
