using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Freezable : DependencyObject
	{
		public bool CanFreeze => false;

		public bool IsFrozen => false;

		internal new static Freezable CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Freezable(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Freezable obj)
		{
			return default(HandleRef);
		}

		protected Freezable()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public Freezable Clone()
		{
			return null;
		}

		public Freezable CloneCurrentValue()
		{
			return null;
		}

		public Freezable GetAsFrozen()
		{
			return null;
		}

		public Freezable GetCurrentValueAsFrozen()
		{
			return null;
		}

		protected virtual void CloneCommonCore(Freezable source)
		{
		}

		internal void CallCloneCommonCore(Freezable source)
		{
		}

		public void Freeze()
		{
		}

		public bool CanSeal()
		{
			return false;
		}

		public new bool IsSealed()
		{
			return false;
		}

		public void Seal()
		{
		}

		private IntPtr CloneHelper()
		{
			return (IntPtr)0;
		}

		private IntPtr CloneCurrentValueHelper()
		{
			return (IntPtr)0;
		}

		private IntPtr GetAsFrozenHelper()
		{
			return (IntPtr)0;
		}

		private IntPtr GetCurrentValueAsFrozenHelper()
		{
			return (IntPtr)0;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
