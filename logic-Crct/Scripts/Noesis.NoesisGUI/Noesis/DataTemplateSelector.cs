using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DataTemplateSelector : BaseComponent
	{
		internal new static DataTemplateSelector CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DataTemplateSelector(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DataTemplateSelector obj)
		{
			return default(HandleRef);
		}

		public virtual DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			return null;
		}

		public DataTemplateSelector()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
