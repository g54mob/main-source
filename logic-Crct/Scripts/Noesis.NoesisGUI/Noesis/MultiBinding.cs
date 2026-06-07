using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class MultiBinding : BindingBase
	{
		public IMultiValueConverter Converter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BindingCollection Bindings => null;

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

		internal new static MultiBinding CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal MultiBinding(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(MultiBinding obj)
		{
			return default(HandleRef);
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return null;
		}

		public MultiBinding()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
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
