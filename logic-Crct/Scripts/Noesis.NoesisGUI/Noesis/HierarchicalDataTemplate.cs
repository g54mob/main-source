using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class HierarchicalDataTemplate : DataTemplate
	{
		public Style ItemContainerStyle
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BindingBase ItemsSource
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DataTemplate ItemTemplate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DataTemplateSelector ItemTemplateSelector
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static HierarchicalDataTemplate CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal HierarchicalDataTemplate(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(HierarchicalDataTemplate obj)
		{
			return default(HandleRef);
		}

		public HierarchicalDataTemplate()
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
