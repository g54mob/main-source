using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RoutedUICommand : RoutedCommand
	{
		public string Text
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static RoutedUICommand CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal RoutedUICommand(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RoutedUICommand obj)
		{
			return default(HandleRef);
		}

		public RoutedUICommand()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public RoutedUICommand(string text, string name, Type owner)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public RoutedUICommand(string text, string name, Type owner, InputGestureCollection inputGestures)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
