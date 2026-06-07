using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TransformGroup : Transform
	{
		public static DependencyProperty ChildrenProperty => null;

		public TransformCollection Children
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static TransformGroup CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TransformGroup(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TransformGroup obj)
		{
			return default(HandleRef);
		}

		public TransformGroup()
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
