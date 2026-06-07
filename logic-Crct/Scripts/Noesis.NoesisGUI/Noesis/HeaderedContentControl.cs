using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class HeaderedContentControl : ContentControl
	{
		public static DependencyProperty HasHeaderProperty => null;

		public static DependencyProperty HeaderProperty => null;

		public static DependencyProperty HeaderStringFormatProperty => null;

		public static DependencyProperty HeaderTemplateProperty => null;

		public static DependencyProperty HeaderTemplateSelectorProperty => null;

		public bool HasHeader => false;

		public object Header
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string HeaderStringFormat
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DataTemplate HeaderTemplate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DataTemplateSelector HeaderTemplateSelector
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static HeaderedContentControl CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal HeaderedContentControl(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(HeaderedContentControl obj)
		{
			return default(HandleRef);
		}

		public HeaderedContentControl()
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
