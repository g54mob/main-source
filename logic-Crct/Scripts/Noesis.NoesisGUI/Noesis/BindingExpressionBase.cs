using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BindingExpressionBase : Expression
	{
		public DependencyObject Target => null;

		public DependencyProperty TargetProperty => null;

		public BindingBase ParentBindingBase => null;

		internal new static BindingExpressionBase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal BindingExpressionBase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(BindingExpressionBase obj)
		{
			return default(HandleRef);
		}

		protected BindingExpressionBase()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public virtual void UpdateTarget()
		{
		}

		public virtual void UpdateSource()
		{
		}
	}
}
