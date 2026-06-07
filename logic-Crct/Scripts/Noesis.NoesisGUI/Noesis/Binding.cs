using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Binding : BindingBase
	{
		internal static IntPtr DoNothingPtr;

		public static object DoNothing;

		public IValueConverter Converter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string ElementName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object Source
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public RelativeSource RelativeSource
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public PropertyPath Path
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BindingMode Mode
		{
			get
			{
				return default(BindingMode);
			}
			set
			{
			}
		}

		public object ConverterParameter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public UpdateSourceTrigger UpdateSourceTrigger
		{
			get
			{
				return default(UpdateSourceTrigger);
			}
			set
			{
			}
		}

		internal new static Binding CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Binding(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Binding obj)
		{
			return default(HandleRef);
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return null;
		}

		public Binding()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public Binding(string path)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public Binding(DependencyProperty path)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public Binding(string path, object source)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public Binding(DependencyProperty path, object source)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public Binding(string path, string elementName)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public Binding(DependencyProperty path, string elementName)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public Binding(string path, RelativeSource relativeSource)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public Binding(DependencyProperty path, RelativeSource relativeSource)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private static object GetDoNothing()
		{
			return null;
		}

		private IntPtr ProvideValueHelper(object targetObject, DependencyProperty targetProperty)
		{
			return (IntPtr)0;
		}

		private object GetConverterHelper()
		{
			return null;
		}

		private void SetConverterHelper(object converter)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
