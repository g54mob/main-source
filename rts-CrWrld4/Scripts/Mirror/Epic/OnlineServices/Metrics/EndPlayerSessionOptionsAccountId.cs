namespace Epic.OnlineServices.Metrics
{
	public class EndPlayerSessionOptionsAccountId : ISettable
	{
		private MetricsAccountIdType m_AccountIdType;

		private EpicAccountId m_Epic;

		private string m_External;

		public MetricsAccountIdType AccountIdType
		{
			get
			{
				return default(MetricsAccountIdType);
			}
			private set
			{
			}
		}

		public EpicAccountId Epic
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string External
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static implicit operator EndPlayerSessionOptionsAccountId(EpicAccountId value)
		{
			return null;
		}

		public static implicit operator EndPlayerSessionOptionsAccountId(string value)
		{
			return null;
		}

		internal void Set(EndPlayerSessionOptionsAccountIdInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
