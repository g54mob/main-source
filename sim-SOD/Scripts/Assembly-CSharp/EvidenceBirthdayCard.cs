using System.Collections.Generic;

public class EvidenceBirthdayCard : Evidence
{
	public Citizen birthdayCitizen;

	public Human from;

	public Acquaintance relationship;

	public EvidenceBirthdayCard(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public override void BuildDataSources()
	{
	}

	public override string GenerateName()
	{
		return null;
	}
}
