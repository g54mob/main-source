using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PathFigureCollection : FreezableCollection<PathFigure>
	{
		internal new static PathFigureCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PathFigureCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(PathFigureCollection obj)
		{
			return default(HandleRef);
		}

		public PathFigureCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
