using System;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace Noesis
{
	public class Hyperlink : Span
	{
		public ICommand Command
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Uri NavigateUri
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static DependencyProperty CommandProperty => null;

		public static DependencyProperty CommandParameterProperty => null;

		public static DependencyProperty CommandTargetProperty => null;

		public static DependencyProperty NavigateUriProperty => null;

		public static DependencyProperty TargetNameProperty => null;

		public static RoutedEvent ClickEvent => null;

		public static RoutedEvent RequestNavigateEvent => null;

		public object CommandParameter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public UIElement CommandTarget
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string TargetName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event RoutedEventHandler Click
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RequestNavigateEventHandler RequestNavigate
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static Hyperlink CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Hyperlink(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Hyperlink obj)
		{
			return default(HandleRef);
		}

		public Hyperlink()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public Hyperlink(Inline childInline)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private object GetCommandHelper()
		{
			return null;
		}

		private void SetCommandHelper(object command)
		{
		}

		private string GetNavigateUriHelper()
		{
			return null;
		}

		private void SetNavigateUriHelper(string uri)
		{
		}
	}
}
