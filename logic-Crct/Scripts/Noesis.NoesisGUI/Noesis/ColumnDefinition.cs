using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ColumnDefinition : DefinitionBase
	{
		public new static DependencyProperty WidthProperty => null;

		public new static DependencyProperty MinWidthProperty => null;

		public new static DependencyProperty MaxWidthProperty => null;

		public new GridLength Width
		{
			get
			{
				return default(GridLength);
			}
			set
			{
			}
		}

		public new float MinWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public new float MaxWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public new float ActualWidth => 0f;

		internal new static ColumnDefinition CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ColumnDefinition(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ColumnDefinition obj)
		{
			return default(HandleRef);
		}

		public ColumnDefinition()
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
