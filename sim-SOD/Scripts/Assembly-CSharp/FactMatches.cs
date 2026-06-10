using System.Collections.Generic;

public class FactMatches : Fact
{
	public MatchPreset matchPreset;

	public float timeRangeDifference;

	public float travelTime;

	private NewNode closest1;

	private NewNode closest2;

	public FactMatches(FactPreset newPreset, List<Evidence> newFromEvidence, List<Evidence> newToEvidence, List<object> newPassedObjects, List<Evidence.DataKey> overrideFromKeys, List<Evidence.DataKey> overrideToKeys, bool isCustomFact)
		: base(null, null, null, null, null, null, isCustomFact: false)
	{
	}

	public static bool MatchCheck(MatchPreset match, Evidence matchFrom, Evidence matchTo)
	{
		return false;
	}

	public override string GenerateNameSuffix()
	{
		return null;
	}
}
