using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public sealed class RelativeSource : MarkupExtension
	{
		public static RelativeSource Self => null;

		public static RelativeSource TemplatedParent => null;

		public RelativeSourceMode Mode
		{
			get
			{
				return default(RelativeSourceMode);
			}
			set
			{
			}
		}

		public Type AncestorType
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int AncestorLevel
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal new static RelativeSource CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal RelativeSource(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RelativeSource obj)
		{
			return default(HandleRef);
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return null;
		}

		public RelativeSource()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public RelativeSource(RelativeSourceMode mode)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public RelativeSource(RelativeSourceMode mode, Type type, int level)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public RelativeSource(RelativeSource other)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private IntPtr ProvideValueHelper(object targetObject, DependencyProperty targetProperty)
		{
			return (IntPtr)0;
		}
	}
}
