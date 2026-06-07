namespace Epic.OnlineServices.Sessions
{
	public class AttributeDataValue : ISettable
	{
		private long? m_AsInt64;

		private double? m_AsDouble;

		private bool? m_AsBool;

		private string m_AsUtf8;

		private AttributeType m_ValueType;

		public long? AsInt64
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public double? AsDouble
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool? AsBool
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string AsUtf8
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AttributeType ValueType
		{
			get
			{
				return default(AttributeType);
			}
			private set
			{
			}
		}

		public static implicit operator AttributeDataValue(long value)
		{
			return null;
		}

		public static implicit operator AttributeDataValue(double value)
		{
			return null;
		}

		public static implicit operator AttributeDataValue(bool value)
		{
			return null;
		}

		public static implicit operator AttributeDataValue(string value)
		{
			return null;
		}

		internal void Set(AttributeDataValueInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
