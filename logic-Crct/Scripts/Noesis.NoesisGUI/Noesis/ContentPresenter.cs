using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ContentPresenter : FrameworkElement
	{
		public static DependencyProperty ContentProperty => null;

		public static DependencyProperty ContentSourceProperty => null;

		public static DependencyProperty ContentStringFormatProperty => null;

		public static DependencyProperty ContentTemplateProperty => null;

		public static DependencyProperty ContentTemplateSelectorProperty => null;

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

		public string ContentSource
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

		internal new static ContentPresenter CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ContentPresenter(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ContentPresenter obj)
		{
			return default(HandleRef);
		}

		public ContentPresenter()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
