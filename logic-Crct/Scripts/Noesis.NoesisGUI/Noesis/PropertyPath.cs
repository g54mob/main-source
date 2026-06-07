using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PropertyPath : BaseComponent
	{
		public string Path
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static PropertyPath CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PropertyPath(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(PropertyPath obj)
		{
			return default(HandleRef);
		}

		public PropertyPath()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public PropertyPath(string str)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public PropertyPath(DependencyProperty dp)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
