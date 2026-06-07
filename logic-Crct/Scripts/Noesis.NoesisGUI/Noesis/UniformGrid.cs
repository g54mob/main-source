using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class UniformGrid : Panel
	{
		public static DependencyProperty FirstColumnProperty => null;

		public static DependencyProperty ColumnsProperty => null;

		public static DependencyProperty RowsProperty => null;

		public int FirstColumn
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Columns
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Rows
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal new static UniformGrid CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal UniformGrid(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(UniformGrid obj)
		{
			return default(HandleRef);
		}

		public UniformGrid()
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
