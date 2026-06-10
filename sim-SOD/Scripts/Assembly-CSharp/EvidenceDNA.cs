using System.Collections.Generic;

public class EvidenceDNA : Evidence
{
	public Citizen citizenController;

	public static int DNAAssign;

	public static int DNAAssignLoop;

	public EvidenceDNA(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public override void OnDiscovery()
	{
	}
}
