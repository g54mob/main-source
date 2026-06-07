namespace Simulator
{
	public struct FloatRuntimeLocaVariable : IRuntimeLocaVariable
	{
		private float m_value;

		public FloatRuntimeLocaVariable(float value)
		{
			m_value = value;
		}

		public string GetLiteralValue()
		{
			return m_value.ToString();
		}

		public bool TryGetIntValue(out int value)
		{
			value = 0;
			return false;
		}

		public bool TryGetFloatValue(out float value)
		{
			value = m_value;
			return true;
		}

		public void SetValue(object value)
		{
			if (value is float value2)
			{
				m_value = value2;
			}
		}
	}
}
