using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class NameScope : BaseComponent
	{
		public object this[string key]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static DependencyProperty NameScopeProperty => null;

		internal new static NameScope CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal NameScope(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(NameScope obj)
		{
			return default(HandleRef);
		}

		public NameScope()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public static NameScope GetNameScope(DependencyObject element)
		{
			return null;
		}

		public static void SetNameScope(DependencyObject element, NameScope nameScope)
		{
		}

		public object FindName(string name)
		{
			return null;
		}

		public void RegisterName(string name, object obj)
		{
		}

		public void UnregisterName(string name)
		{
		}

		public void UpdateName(string name, object obj)
		{
		}
	}
}
