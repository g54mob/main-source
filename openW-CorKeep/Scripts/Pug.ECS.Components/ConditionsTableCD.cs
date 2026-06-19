using Unity.Entities;

public struct ConditionsTableCD : IComponentData, IQueryTypeParameter
{
	public BlobAssetReference<ConditionsTableBlob> Value;

	public ConditionInfoBlob GetConditionInfo(ConditionID conditionDataConditionID)
	{
		if ((int)conditionDataConditionID >= Value.Value.infos.Length)
		{
			return default(ConditionInfoBlob);
		}
		return Value.Value.infos[(int)conditionDataConditionID];
	}
}
