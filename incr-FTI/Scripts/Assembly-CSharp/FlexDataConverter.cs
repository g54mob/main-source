using System;
using System.Collections.Generic;
using FullSerializer;

public class FlexDataConverter : CustomConverter<Dictionary<string, FlexData>>
{
	public override object CreateInstance(fsData data, Type storageType)
	{
		return new Dictionary<string, FlexData>();
	}

	protected override fsResult DoSerialize(Dictionary<string, FlexData> model, Dictionary<string, fsData> serialized)
	{
		foreach (KeyValuePair<string, FlexData> item in model)
		{
			fsData value = item.Value.Serialized();
			serialized[item.Key] = value;
		}
		return fsResult.Success;
	}

	protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref Dictionary<string, FlexData> model)
	{
		fsResult success = fsResult.Success;
		foreach (KeyValuePair<string, fsData> datum in data)
		{
			model[datum.Key] = FlexData.Deserialized(datum.Value);
		}
		return success;
	}
}
