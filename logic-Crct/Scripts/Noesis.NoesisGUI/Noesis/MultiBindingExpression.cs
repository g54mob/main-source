using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class MultiBindingExpression : BindingExpressionBase
	{
		public MultiBinding ParentBinding => null;

		internal new static MultiBindingExpression CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal MultiBindingExpression(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(MultiBindingExpression obj)
		{
			return default(HandleRef);
		}

		protected MultiBindingExpression()
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
