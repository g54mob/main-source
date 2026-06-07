using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ContentControl : Control
	{
		public static DependencyProperty ContentProperty => null;

		public static DependencyProperty ContentStringFormatProperty => null;

		public static DependencyProperty ContentTemplateProperty => null;

		public static DependencyProperty ContentTemplateSelectorProperty => null;

		public static DependencyProperty HasContentProperty => null;

		public object Content
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string ContentStringFormat
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		public bool HasContent => false;

		internal new static ContentControl CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ContentControl(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ContentControl obj)
		{
			return default(HandleRef);
		}

		public override string ToString()
		{
			return null;
		}

		public ContentControl()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		private string ToStringHelper()
		{
			return null;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
