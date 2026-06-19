using System;
using System.Globalization;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

[Serializable]
[Preserve]
[TypeManager.OverrideTypeHash(3386982922340789878uL)]
public struct BreedToggleSerializedCD : IComponentData, IQueryTypeParameter, IPugJsonSerializer
{
	public int Value;

	public int RuntimeTypeIndex => TypeManager.GetTypeIndex<BreedToggleCD>();

	public ulong SerializedTypeHash => TypeManager.GetTypeInfo<BreedToggleSerializedCD>().StableTypeHash;

	public string SerializeToJson(object data)
	{
		if (!(data is BreedToggleCD breedToggleCD))
		{
			Debug.LogError($"Trying to serialize something not BreedToggleCD: {data}");
			return null;
		}
		return breedToggleCD.breedingDisabled.ToString(CultureInfo.InvariantCulture);
	}

	public object DeserializeFromJson(string json)
	{
		if (bool.TryParse(json, out var result))
		{
			return new BreedToggleCD
			{
				breedingDisabled = result
			};
		}
		return default(BreedToggleCD);
	}
}
