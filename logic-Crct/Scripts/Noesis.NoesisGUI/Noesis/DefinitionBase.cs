using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DefinitionBase : FrameworkElement
	{
		public static DependencyProperty SharedSizeGroupProperty => null;

		public string SharedSizeGroup
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static DefinitionBase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DefinitionBase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DefinitionBase obj)
		{
			return default(HandleRef);
		}

		public DefinitionBase()
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
