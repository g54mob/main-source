using System;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

[Serializable]
[Preserve]
[TypeManager.ForcedMemoryOrdering(16038764625220822319uL)]
[TypeManager.OverrideTypeHash(3873562367253663128uL)]
public struct TalentsSerializedCD : IBufferElementData, IPugJsonSerializer
{
	public int Talent;

	public int Points;

	public int RuntimeTypeIndex => TypeManager.GetTypeIndex<PetTalentBuffer>();

	public ulong SerializedTypeHash => 16038764625220822319uL;

	public string SerializeToJson(object data)
	{
		if (!(data is PetTalentBuffer petTalentBuffer))
		{
			Debug.LogError($"Trying to serialize something not PetTalentBuffer: {data}");
			return null;
		}
		return JsonUtility.ToJson(new TalentsSerializedCD
		{
			Talent = (int)petTalentBuffer.petTalentID,
			Points = petTalentBuffer.points
		});
	}

	public object DeserializeFromJson(string json)
	{
		TalentsSerializedCD talentsSerializedCD = JsonUtility.FromJson<TalentsSerializedCD>(json);
		return new PetTalentBuffer
		{
			petTalentID = (PetTalent)talentsSerializedCD.Talent,
			points = talentsSerializedCD.Points
		};
	}
}
