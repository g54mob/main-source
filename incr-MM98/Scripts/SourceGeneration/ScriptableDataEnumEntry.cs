using System;

[Serializable]
public struct ScriptableDataEnumEntry<T> : IScriptableDataEnumEntry
{
	public string key;

	public T value;

	public string Key => key;

	public object Value => value;
}
