using System;
using System.Globalization;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

[Serializable]
[Preserve]
[TypeManager.ForcedMemoryOrdering(18362501804100791937uL)]
[TypeManager.OverrideTypeHash(4485583542073257979uL)]
public struct BreedStateSerializedCD : IComponentData, IQueryTypeParameter, IPugJsonSerializer
{
	public int Value;

	public int RuntimeTypeIndex => TypeManager.GetTypeIndex<MealsEatenCD>();

	public ulong SerializedTypeHash => 18362501804100791937uL;

	public string SerializeToJson(object data)
	{
		if (!(data is MealsEatenCD mealsEatenCD))
		{
			Debug.LogError($"Trying to serialize something not MealsEatenCD: {data}");
			return null;
		}
		return mealsEatenCD.Value.ToString(CultureInfo.InvariantCulture);
	}

	public object DeserializeFromJson(string json)
	{
		if (int.TryParse(json, out var result))
		{
			return new MealsEatenCD
			{
				Value = result
			};
		}
		return default(MealsEatenCD);
	}
}
