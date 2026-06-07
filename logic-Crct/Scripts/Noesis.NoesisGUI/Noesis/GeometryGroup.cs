using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class GeometryGroup : Geometry
	{
		public static DependencyProperty ChildrenProperty => null;

		public static DependencyProperty FillRuleProperty => null;

		public GeometryCollection Children
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		internal new static GeometryGroup CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal GeometryGroup(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(GeometryGroup obj)
		{
			return default(HandleRef);
		}

		public GeometryGroup()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public override bool IsEmpty()
		{
			return false;
		}
	}
}
