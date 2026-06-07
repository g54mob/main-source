using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public sealed class TemplateBindingExtension : MarkupExtension
	{
		public DependencyProperty Property
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static TemplateBindingExtension CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TemplateBindingExtension(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TemplateBindingExtension obj)
		{
			return default(HandleRef);
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return null;
		}

		public TemplateBindingExtension()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public TemplateBindingExtension(DependencyProperty dp)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private IntPtr ProvideValueHelper(object targetObject, DependencyProperty targetProperty)
		{
			return (IntPtr)0;
		}
	}
}
