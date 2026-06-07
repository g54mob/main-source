using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RowDefinition : DefinitionBase
	{
		public new static DependencyProperty HeightProperty => null;

		public new static DependencyProperty MinHeightProperty => null;

		public new static DependencyProperty MaxHeightProperty => null;

		public new GridLength Height
		{
			get
			{
				return default(GridLength);
			}
			set
			{
			}
		}

		public new float MaxHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public new float MinHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public new float ActualHeight => 0f;

		internal new static RowDefinition CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal RowDefinition(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RowDefinition obj)
		{
			return default(HandleRef);
		}

		public RowDefinition()
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
