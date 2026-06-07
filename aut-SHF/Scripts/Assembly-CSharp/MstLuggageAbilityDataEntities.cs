using System;

[Serializable]
public class MstLuggageAbilityDataEntities
{
	public int id;

	public eLuggage luggage;

	public int level;

	public string desc;

	public int triggerCount;

	public string target1;

	public eAbilityEffectId effectId1;

	public float effectParam1;

	public bool isBase1;

	public string target2;

	public eAbilityEffectId effectId2;

	public float effectParam2;

	public bool isBase2;

	public string target3;

	public eAbilityEffectId effectId3;

	public float effectParam3;

	public bool isBase3;
}
