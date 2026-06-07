using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RadioButton : ToggleButton
	{
		public static DependencyProperty GroupNameProperty => null;

		public string GroupName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static RadioButton CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal RadioButton(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RadioButton obj)
		{
			return default(HandleRef);
		}

		public RadioButton()
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
