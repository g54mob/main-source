using System.Collections.Generic;

public class EvidenceTelephoneCall : EvidenceTime
{
	public Evidence callFrom;

	public Evidence callTo;

	public EvidenceTelephoneCall(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}
}
