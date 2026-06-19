using System;
using System.Globalization;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

[Serializable]
[Preserve]
[TypeManager.ForcedMemoryOrdering(13695103918181693450uL)]
[TypeManager.OverrideTypeHash(12052904543115273478uL)]
public struct PetSkinSerializedCD : IComponentData, IQueryTypeParameter, IPugJsonSerializer
{
	public int skinIndex;

	public int RuntimeTypeIndex => TypeManager.GetTypeIndex<PetSkinCD>();

	public ulong SerializedTypeHash => 13695103918181693450uL;

	public string SerializeToJson(object data)
	{
		if (!(data is PetSkinCD petSkinCD))
		{
			Debug.LogError($"Trying to serialize something not PetSkinCD: {data}");
			return null;
		}
		return petSkinCD.skinIndex.ToString(CultureInfo.InvariantCulture);
	}

	public object DeserializeFromJson(string json)
	{
		if (int.TryParse(json, out var result))
		{
			return new PetSkinCD
			{
				skinIndex = result
			};
		}
		return default(PetSkinCD);
	}
}
