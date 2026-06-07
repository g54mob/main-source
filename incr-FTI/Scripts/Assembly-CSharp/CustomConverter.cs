using System;
using System.Collections.Generic;
using FullSerializer;

public abstract class CustomConverter<TModel> : fsDirectConverter
{
	public override Type ModelType => typeof(TModel);

	public sealed override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
	{
		Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
		fsResult result = DoSerialize((TModel)instance, dictionary);
		serialized = new fsData(dictionary);
		return result;
	}

	public sealed override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
	{
		fsResult success = fsResult.Success;
		fsResult fsResult2 = (success += CheckType(data, fsDataType.Object));
		if (fsResult2.Failed)
		{
			return success;
		}
		TModel model = (TModel)instance;
		success += DoDeserialize(data.AsDictionary, ref model);
		instance = model;
		return success;
	}

	protected abstract fsResult DoSerialize(TModel model, Dictionary<string, fsData> serialized);

	protected abstract fsResult DoDeserialize(Dictionary<string, fsData> data, ref TModel model);

	protected fsResult SerializeProperties(Dictionary<string, fsData> serializedData, Dictionary<string, FlexData> properties)
	{
		return NullSafeSerialize(serializedData, "p", properties);
	}

	protected fsResult DeserializeProperties(Dictionary<string, fsData> data, out Dictionary<string, FlexData> properties)
	{
		if (data.TryGetValue("p", out var _))
		{
			return NullSafeDeserialize<Dictionary<string, FlexData>>(data, "p", out properties);
		}
		if (data.TryGetValue("properties", out var _))
		{
			return NullSafeDeserialize<Dictionary<string, FlexData>>(data, "properties", out properties);
		}
		properties = null;
		return fsResult.Success;
	}

	protected fsResult NullSafeSerialize<T>(Dictionary<string, fsData> data, string name, T value)
	{
		if (value != null)
		{
			return SerializeMember(data, null, name, value);
		}
		return fsResult.Success;
	}

	protected fsResult NullSafeDeserialize<T>(Dictionary<string, fsData> data, string name, out T value)
	{
		if (!data.ContainsKey(name))
		{
			value = default(T);
			return fsResult.Success;
		}
		return DeserializeMember<T>(data, null, name, out value);
	}

	protected fsResult NullSafeSerializeProperty<T>(Dictionary<string, fsData> data, string name, PropertyItem<T> propertyItem)
	{
		if (propertyItem != null)
		{
			return SerializeMember(data, null, name, propertyItem.value);
		}
		return fsResult.Success;
	}

	protected fsResult NullSafeDeserializeProperty<T>(Dictionary<string, fsData> data, string name, out PropertyItem<T> propertyItem)
	{
		if (!data.ContainsKey(name))
		{
			propertyItem = null;
			return fsResult.Success;
		}
		propertyItem = new PropertyItem<T>();
		T value;
		fsResult result = DeserializeMember<T>(data, null, name, out value);
		propertyItem.InitializeValue(value);
		return result;
	}
}
