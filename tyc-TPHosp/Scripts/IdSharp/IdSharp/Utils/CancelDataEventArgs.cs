namespace IdSharp.Utils
{
	public sealed class CancelDataEventArgs<T> : DataEventArgs<T>
	{
		private bool m_Cancel;

		private string m_CancelReason;

		public bool Cancel
		{
			get
			{
				return m_Cancel;
			}
			set
			{
				m_Cancel = value;
			}
		}

		public string CancelReason
		{
			get
			{
				return m_CancelReason;
			}
			set
			{
				m_CancelReason = value;
			}
		}

		public CancelDataEventArgs(T data)
			: base(data)
		{
			m_Cancel = false;
		}
	}
}
