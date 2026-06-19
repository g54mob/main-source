using System;

namespace IdSharp.Utils
{
	public class DataEventArgs<T> : EventArgs
	{
		private T m_Data;

		public T Data => m_Data;

		public DataEventArgs(T data)
		{
			m_Data = data;
		}
	}
}
