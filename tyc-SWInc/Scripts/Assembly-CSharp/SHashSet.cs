using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AltSerialize;

[Serializable]
public class SHashSet<T> : HashSet<T>, IAltSerializable
{
	public bool CanCache
	{
		get
		{
			return true;
		}
	}

	public SHashSet()
	{
	}

	protected SHashSet(SerializationInfo info, StreamingContext context)
	{
		T[] array = (T[])info.GetValue("Data", typeof(T[]));
		for (int i = 0; i < array.Length; i++)
		{
			Add(array[i]);
		}
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		T[] array = new T[base.Count];
		int num = 0;
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				T current = enumerator.Current;
				array[num] = current;
				num++;
			}
		}
		info.AddValue("Data", array, array.GetType());
	}

	public void Serialize(AltSerializer serializer, int depth)
	{
		serializer.Write(base.Count);
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				T current = enumerator.Current;
				serializer.Serialize(current, depth + 1);
			}
		}
	}

	public IAltSerializable Deserialize(AltSerializer deserializer)
	{
		int num = deserializer.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			Add((T)deserializer.Deserialize());
		}
		return this;
	}
}
