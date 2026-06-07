using System.Collections.Generic;

namespace Yarn
{
	public class MemoryVariableStore : IVariableStorage
	{
		private Dictionary<string, object> variables;

		public bool TryGetValue<T>(string variableName, out T result)
		{
			result = default(T);
			return false;
		}

		public void Clear()
		{
		}

		public void SetValue(string variableName, string stringValue)
		{
		}

		public void SetValue(string variableName, float floatValue)
		{
		}

		public void SetValue(string variableName, bool boolValue)
		{
		}
	}
}
