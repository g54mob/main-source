using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TemplateBindingExpression : Expression
	{
		public TemplateBindingExtension TemplateBindingExtension => null;

		internal new static TemplateBindingExpression CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TemplateBindingExpression(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TemplateBindingExpression obj)
		{
			return default(HandleRef);
		}

		protected TemplateBindingExpression()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
