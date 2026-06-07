using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TabControl : Selector
	{
		public static DependencyProperty ContentTemplateProperty => null;

		public static DependencyProperty ContentTemplateSelectorProperty => null;

		public static DependencyProperty SelectedContentProperty => null;

		public static DependencyProperty SelectedContentTemplateProperty => null;

		public static DependencyProperty SelectedContentTemplateSelectorProperty => null;

		public static DependencyProperty TabStripPlacementProperty => null;

		public DataTemplate ContentTemplate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DataTemplateSelector ContentTemplateSelector
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object SelectedContent => null;

		public DataTemplate SelectedContentTemplate => null;

		public DataTemplateSelector SelectedContentTemplateSelector => null;

		public Dock TabStripPlacement
		{
			get
			{
				return default(Dock);
			}
			set
			{
			}
		}

		internal new static TabControl CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TabControl(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TabControl obj)
		{
			return default(HandleRef);
		}

		public TabControl()
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
