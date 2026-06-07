using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

[Serializable]
public class OldSaveDataDictionary<TKey, TValue> : Dictionary<TKey, TValue>
{
	public OldSaveDataDictionary()
	{
	}

	public OldSaveDataDictionary(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public override void OnDeserialization(object sender)
	{
		try
		{
			base.OnDeserialization(sender);
		}
		catch
		{
		}
	}
}
