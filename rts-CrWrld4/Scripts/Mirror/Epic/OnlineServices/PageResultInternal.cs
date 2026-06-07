using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 12)]
	internal struct PageResultInternal : ISettable, IDisposable
	{
		private int m_StartIndex;

		private int m_Count;

		private int m_TotalCount;

		public int StartIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Count
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int TotalCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public void Set(PageResult other)
		{
		}

		public void Set(object other)
		{
		}

		public void Dispose()
		{
		}
	}
}
