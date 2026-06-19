using System;

[Serializable]
public class SerializablePreferredLocationInfo
{
	public bool assigned;

	public BehaviorLocationInfo type;

	public PreferredLocationInfoBase baseLocation;

	private PreferredLocationInfoBase GetConditionForType()
	{
		return baseLocation;
	}
}
