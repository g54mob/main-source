using System;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

[Serializable]
[Preserve]
[TypeManager.ForcedMemoryOrdering(9923282613123898873uL)]
[TypeManager.OverrideTypeHash(18221140013894219486uL)]
public struct NameSerializedCD : IComponentData, IQueryTypeParameter, IPugJsonSerializer
{
	public FixedString64Bytes Value;

	public int RuntimeTypeIndex => TypeManager.GetTypeIndex<NameCD>();

	public ulong SerializedTypeHash => 9923282613123898873uL;

	public string SerializeToJson(object data)
	{
		if (!(data is NameCD nameCD))
		{
			Debug.LogError($"Trying to serialize something not NameCD: {data}");
			return null;
		}
		return nameCD.Value.Value;
	}

	public object DeserializeFromJson(string json)
	{
		return new NameCD
		{
			Value = json
		};
	}
}
