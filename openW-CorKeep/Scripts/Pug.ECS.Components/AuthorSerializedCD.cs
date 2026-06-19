using System;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

[Serializable]
[Preserve]
[TypeManager.OverrideTypeHash(11777205729214706712uL)]
public struct AuthorSerializedCD : IComponentData, IQueryTypeParameter, IPugJsonSerializer
{
	public FixedString64Bytes Value;

	public int RuntimeTypeIndex => TypeManager.GetTypeIndex<AuthorCD>();

	public ulong SerializedTypeHash => 920469213874260355uL;

	public string SerializeToJson(object data)
	{
		if (!(data is AuthorCD authorCD))
		{
			Debug.LogError($"Trying to serialize something not AuthorCD: {data}");
			return null;
		}
		return authorCD.Value.Value;
	}

	public object DeserializeFromJson(string json)
	{
		return new AuthorCD
		{
			Value = json
		};
	}
}
