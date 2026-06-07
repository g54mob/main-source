using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class CombinedGeometry : Geometry
	{
		public static DependencyProperty Geometry1Property => null;

		public static DependencyProperty Geometry2Property => null;

		public static DependencyProperty GeometryCombineModeProperty => null;

		public Geometry Geometry1
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Geometry Geometry2
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public GeometryCombineMode GeometryCombineMode
		{
			get
			{
				return default(GeometryCombineMode);
			}
			set
			{
			}
		}

		internal new static CombinedGeometry CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal CombinedGeometry(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(CombinedGeometry obj)
		{
			return default(HandleRef);
		}

		public CombinedGeometry()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public CombinedGeometry(Geometry geometry1, Geometry geometry2, GeometryCombineMode mode)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public override bool IsEmpty()
		{
			return false;
		}
	}
}
