using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DynamicResourceExtension : MarkupExtension
	{
		internal new static DynamicResourceExtension CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DynamicResourceExtension(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DynamicResourceExtension obj)
		{
			return default(HandleRef);
		}

		public DynamicResourceExtension(object key)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return null;
		}

		public DynamicResourceExtension()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public DynamicResourceExtension(string key)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private IntPtr ProvideValueHelper(object targetObject, DependencyProperty targetProperty)
		{
			return (IntPtr)0;
		}
	}
}
