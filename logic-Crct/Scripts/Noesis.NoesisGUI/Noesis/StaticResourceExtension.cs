using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class StaticResourceExtension : MarkupExtension
	{
		internal new static StaticResourceExtension CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal StaticResourceExtension(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(StaticResourceExtension obj)
		{
			return default(HandleRef);
		}

		public StaticResourceExtension(object key)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return null;
		}

		public StaticResourceExtension()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public StaticResourceExtension(string key)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private IntPtr ProvideValueHelper(object targetObject, DependencyProperty targetProperty)
		{
			return (IntPtr)0;
		}
	}
}
