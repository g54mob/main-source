using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Path : Shape
	{
		public static DependencyProperty DataProperty => null;

		public Geometry Data
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static Path CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Path(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Path obj)
		{
			return default(HandleRef);
		}

		public Path()
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
