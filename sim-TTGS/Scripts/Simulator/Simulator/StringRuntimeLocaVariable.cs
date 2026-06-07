namespace Simulator
{
	public struct StringRuntimeLocaVariable : IRuntimeLocaVariable
	{
		private string m_value;

		public StringRuntimeLocaVariable(string value)
		{
			m_value = value;
		}

		public string GetLiteralValue()
		{
			return m_value;
		}

		public bool TryGetIntValue(out int value)
		{
			value = 0;
			return false;
		}

		public bool TryGetFloatValue(out float value)
		{
			value = 0f;
			return false;
		}

		public void SetValue(object value)
		{
			if (value is string value2)
			{
				m_value = value2;
			}
		}
	}
}
