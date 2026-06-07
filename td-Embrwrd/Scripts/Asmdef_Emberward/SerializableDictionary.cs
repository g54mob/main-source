using System.Collections.Generic;
using System.Runtime.Serialization;

public static class SerializableDictionary
{
	public class Storage<T> : SerializableDictionaryBase.Storage
	{
		public T data;
	}
}
public class SerializableDictionary<TKey, TValue> : SerializableDictionaryBase<TKey, TValue, TValue>
{
	public SerializableDictionary()
	{
	}

	public SerializableDictionary(IDictionary<TKey, TValue> dict)
	{
	}

	protected SerializableDictionary(SerializationInfo info, StreamingContext context)
	{
	}

	protected override TValue GetValue(TValue[] storage, int i)
	{
		return default(TValue);
	}

	protected override void SetValue(TValue[] storage, int i, TValue value)
	{
	}
}
public class SerializableDictionary<TKey, TValue, TValueStorage> : SerializableDictionaryBase<TKey, TValue, TValueStorage> where TValueStorage : SerializableDictionary.Storage<TValue>, new()
{
	public SerializableDictionary()
	{
	}

	public SerializableDictionary(IDictionary<TKey, TValue> dict)
	{
	}

	protected SerializableDictionary(SerializationInfo info, StreamingContext context)
	{
	}

	protected override TValue GetValue(TValueStorage[] storage, int i)
	{
		return default(TValue);
	}

	protected override void SetValue(TValueStorage[] storage, int i, TValue value)
	{
	}
}
