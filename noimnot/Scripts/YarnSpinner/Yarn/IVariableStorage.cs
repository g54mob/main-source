namespace Yarn
{
	public interface IVariableStorage
	{
		void SetValue(string variableName, string stringValue);

		void SetValue(string variableName, float floatValue);

		void SetValue(string variableName, bool boolValue);

		bool TryGetValue<T>(string variableName, out T result);

		void Clear();
	}
}
