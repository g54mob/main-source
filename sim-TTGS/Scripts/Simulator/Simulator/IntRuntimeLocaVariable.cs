namespace Simulator
{
	public struct IntRuntimeLocaVariable : IRuntimeLocaVariable
	{
		private int m_value;

		public IntRuntimeLocaVariable(int value)
		{
			m_value = value;
		}

		public string GetLiteralValue()
		{
			return m_value.ToString();
		}

		public bool TryGetIntValue(out int value)
		{
			value = m_value;
			return true;
		}

		public bool TryGetFloatValue(out float value)
		{
			value = 0f;
			return false;
		}

		public void SetValue(object value)
		{
			if (value is int value2)
			{
				m_value = value2;
			}
		}
	}
}
