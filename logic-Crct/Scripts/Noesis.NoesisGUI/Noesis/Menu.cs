using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Menu : MenuBase
	{
		public static DependencyProperty IsMainMenuProperty => null;

		public bool IsMainMenu
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal new static Menu CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Menu(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Menu obj)
		{
			return default(HandleRef);
		}

		public Menu()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
