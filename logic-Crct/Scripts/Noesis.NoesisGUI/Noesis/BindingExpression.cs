using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BindingExpression : BindingExpressionBase
	{
		public Binding ParentBinding => null;

		internal new static BindingExpression CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal BindingExpression(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(BindingExpression obj)
		{
			return default(HandleRef);
		}

		protected BindingExpression()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public override void UpdateTarget()
		{
		}

		public override void UpdateSource()
		{
		}
	}
}
